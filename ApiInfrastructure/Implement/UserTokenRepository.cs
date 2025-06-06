using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDomain.Base;
using ApiDomain.Contract;
using ApiDomain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiInfrastructure.Implement
{
     public class UserTokenRepository:IUserTokenRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserToken> _userTokenRepository;
        public UserTokenRepository(IUnitOfWork unitOfWork, IRepository<UserToken> userTokenRepository)
        {
            _unitOfWork = unitOfWork;
            _userTokenRepository = userTokenRepository;
        }
        public async Task<UserToken> FindUserTokenById(Guid id)
        {
            return await _userTokenRepository.FindAsync(id);
        }

        public async Task<UserToken?> FindUserTokenByUserId(Guid id)
        {
            return await _userTokenRepository.GetByExpression(n => n.UserId == id).FirstOrDefaultAsync();

        }

        public async Task<UserToken> InsertUserTokenAsync(UserToken request)
        {
            await _userTokenRepository.AddAsync(request);
            await _unitOfWork.SaveAsync();
            return request;
        }

        public async Task<UserToken> UpdateUserTokenAsync(UserToken request)
        {
            var update = await _userTokenRepository.UpdateAsync(request);
            await _unitOfWork.SaveAsync();
            return update;
        }
        public async Task<List<UserToken>> DeleteUserTokenAsync(Guid userId)
        {
            var position = await _userTokenRepository.GetByExpression(n => n.UserId == userId).ToListAsync();
            await _userTokenRepository.DeleteRangeAsync(position);
            await _unitOfWork.SaveAsync();
            return position;
        }

        public Task<UserToken?> FindUserTokenByRefreshToken(string refreshToken)
        {
            return _userTokenRepository.GetByExpression(n => n.RefreshToken == refreshToken).FirstOrDefaultAsync();
        }
    }
}
