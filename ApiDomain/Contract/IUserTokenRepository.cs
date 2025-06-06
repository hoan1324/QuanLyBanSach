using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApiDomain.Entity;

namespace ApiDomain.Contract
{
    public interface IUserTokenRepository
    {
        Task<UserToken> InsertUserTokenAsync(UserToken request);
        Task<UserToken> UpdateUserTokenAsync(UserToken request);
        Task<List<UserToken>> DeleteUserTokenAsync(Guid userId);
        Task<UserToken> FindUserTokenById(Guid id);
        Task<UserToken?> FindUserTokenByUserId(Guid id);
        Task<UserToken?> FindUserTokenByRefreshToken(string refreshToken);
      

    }
}
