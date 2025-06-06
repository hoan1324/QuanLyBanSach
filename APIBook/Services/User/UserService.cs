using Api.Domain.Contracts;

using Api.Infrastructure.Implement;
using APIBook.Dtos;
using APIBook.Services;
using ApiDomain.Contract;
using ApiDomain.Entity;
using AutoMapper;
using Azure.Core;
using Cache;
using CommonHelper.Helpers;
using CommonHelper.Models;
using Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Net.WebSockets;

namespace Api.Services
{
	public class UserService : IUserService
	{
		private readonly ICacheService _cacheService;
		private readonly IUserRepository _userRepository;
		private readonly IPermissionService _userPermissionRepository;
		private readonly IMapper _mapper;
		private readonly IAuthService _authService;
		public UserService(IUserRepository userRepository, IMapper mapper, IAuthService authService, IPermissionService userPermissionRepository, ICacheService cacheService)
		{
			_mapper = mapper;
			_cacheService = cacheService;
			_authService = authService;
			_userRepository = userRepository;
			_userPermissionRepository = userPermissionRepository;
		}
		public async Task<UserCreateDto> CreateAsync(UserCreateDto request)
		{
			//var currentUser = await _authService.CurrentUser();
			request.Id = Guid.NewGuid();
			if (await _userRepository.IsExistUser(request.UserName))
				return null;

			var user = _mapper.Map<UserCreateDto, User>(request);
			//user.CreatedBy = currentUser.Id;
			user.Password = CryptionHander.EncryptString(request.Password);
			user.CreateDate = DateTime.Now;
			await _userRepository.CreateAsync(user);

			await _cacheService.LoadUserToCache(request.Id);
			return _mapper.Map<User, UserCreateDto>(user);
		}

		public async Task<UserCreateDto> DeleteAsync(Guid id)
		{
			var user = await _userRepository.FindByIdAsync(id);
			if (user != null)
			{
				await _userRepository.DeleteAsync(id);
				return _mapper.Map<UserCreateDto>(user);
			}
			_cacheService.RemoveUserFromCache(id);
			return null;
		}

		public async Task<UserViewDto> GetProfileAsync(Guid id)
		{
			var user = await _userRepository.FindByIdAsync(id);
			if (user != null)
				return _mapper.Map<UserViewDto>(user);
			return null;
		}

		public async Task<UserCreateDto> GetByIdAsync(Guid id)
		{
			var user = await _userRepository.FindByIdAsync(id);
			if (user != null)
				return _mapper.Map<UserCreateDto>(user);
			return null;
		}

		public async Task<PaginationModel<UserCreateDto>> GetListAsync(FilterRequest request)
		{
			var currentUser = await _authService.CurrentUser();
			var req = _mapper.Map<PaginationRequestModel>(request);
			var userPosition = await _userRepository.GetPaggination(req, currentUser.IsAdmin ?? false);
			return _mapper.Map<PaginationModel<UserCreateDto>>(userPosition);
		}
		
		public async Task<UserCreateDto> UpdateAsync(UserCreateDto request)
		{
			//var currentUser = await _authService.CurrentUser();
			request.ModifiedDate = DateTime.Now;
			var user = await _userRepository.FindByIdAsync(request.Id);
			var userMapped = _mapper.Map<UserCreateDto, User>(request, user);
			//userMapped.ModifiedBy = currentUser.Id;
			userMapped.ModifiedDate = DateTime.Now;
			await _userRepository.UpdateAsync(userMapped);

			await _cacheService.LoadUserToCache(request.Id, true);
			return request;
		}

		public async Task<List<UserCreateDto>> GetByPositionAsync(string code)
		{
			var data = await _userRepository.GetByRole(code);
			if (data != null)
			{
				return _mapper.Map<List<UserCreateDto>>(data);
			}
			return null;
		}
		public async Task<bool> UpdatePasswordAsync(Guid userID, string userName, string newPass, string oldPass)
		{
			newPass = CryptionHander.EncryptString(newPass);
			oldPass = CryptionHander.EncryptString(oldPass);
			//var currentUser = await _authService.CurrentUser();

			var obj = await _userRepository.FindByIdAsync(userID);
			if (obj == null)
			{
				return false;
			}
			if (!obj.UserName.Equals(userName))
			{
				return false;
			}
			if (obj.Password != oldPass)
			{
				return false;
			}
			obj.Password = newPass;
			var res = await _userRepository.UpdatePasswordAsync(userID, newPass);

			return res != null;
		}

		public async Task<UserCreateDto> ResetPasswordAsync(Guid id)
		{
			var newPassword = StringHelper.RandomString(8);
			var currentUser = await _authService.CurrentUser();
			var user = await _userRepository.FindByIdAsync(id);
			if (user == null) return null;
			user.Password = CryptionHander.EncryptString(newPassword);
			user.ModifiedBy = currentUser.Id;
			user.ModifiedDate = DateTime.Now;
			await _userRepository.UpdateAsync(user);
			return _mapper.Map<UserCreateDto>(new User
			{
				Id = id,
				Password = newPassword,
				UserName = user.UserName,
			});
		}
	}
}
