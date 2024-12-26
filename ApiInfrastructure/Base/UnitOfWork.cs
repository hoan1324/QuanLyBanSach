using ApiDomain.Base;
using ApiInfrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInfrastructure.Base
{
	public class UnitOfWork : IUnitOfWork
	{
		#region context
		private ApplicationDBContext _dbFactory;
		private Hashtable _repositories;
		public ApplicationDBContext DbContext { get { return _dbFactory; } }
		public IRepository<T> GetRepository<T>() where T : class
		{
			if (_repositories == null) _repositories = new Hashtable();
			var repoType = typeof(T).Name;
			if (!_repositories.ContainsKey(repoType))
			{
				var repositoryInstance = new Repository<T>(_dbFactory);
				_repositories.Add(repoType, repositoryInstance);
			}
			return (IRepository<T>)_repositories[repoType];
		}
		#endregion
		public UnitOfWork(ApplicationDBContext dbFactory)
		{
			_dbFactory = dbFactory;
		}
		public async Task<IDbContextTransaction> BeginTransactionAsync()
		{
			return await _dbFactory.Database.BeginTransactionAsync();
		}
		public async Task<int> SaveAsync()
		{
			return await _dbFactory.SaveChangesAsync();
		}
		public DbContext GetDbContext()
		{
			return _dbFactory;
		}
		public void Dispose()
		{
			_dbFactory.Dispose();
		}
	}

}
