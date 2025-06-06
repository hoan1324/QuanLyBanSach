using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDomain.Base;

namespace ApiDomain.Entity
{
    public class GroupPermission : Entity<Guid>
    {
        public  string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; } //0:hoatj dong,//1 ban

       public DateTime? CreatedDate { get; set; }
       public Guid? CreatedBy { get; set; }
       public DateTime? ModifiedDate { get; set; }
       public Guid? ModifiedBy { get; set; }

        public ICollection<Permission>? Permissions { get; set; }
        

    }
}
