using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Base
{
	public interface IUnitOfWork: IDisposable
	{
		Task<IDbContextTransaction> BeginTransactionAsync();
		IRepository<T> GetRepository<T>() where T : class;
		DbContext GetDbContext();
		Task<int> SaveAsync();
	}
}
