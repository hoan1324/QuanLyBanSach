using ApiDomain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Entity
{
    public class UserToken: Entity<Guid>
    {
        public Guid UserId { get;set; }
        public string AccessToken { get;set; }
        public string RefreshToken { get;set; }
        public DateTime AccessTokenExpire { get;set; }
        public DateTime RefreshTokenExpire { get;set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual User? User { get; set; }
    }
}
