using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public static class CacheKeyBuilder
    {
        private const string CurrentUserKey = "CURRENT_USER";
        private const string UserPositionKey = "ROLE";
        public static string BuildCurrentUserCacheKey(Guid userId)
        {
            return $"{CurrentUserKey}_{userId.ToString()}";
        }
        public static string BuildCurrentUserPermissionKey(Guid userId)
        {
            return $"{CurrentUserKey}_Permission_{userId.ToString()}";
        }
        public static string BuildCurrentRolePermissionKey(Guid roleId)
        {
            return $"{UserPositionKey}_Permission_{roleId.ToString()}";
        }
    }
}
