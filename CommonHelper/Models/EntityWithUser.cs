using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper.Models
{
    public class EntityWithUser<TSource, TUser>
    {
        public TSource Source { get; set; }
        public TUser? CreatedBy { get; set; }
        public TUser? ModifiedBy { get; set; }
    }
}
