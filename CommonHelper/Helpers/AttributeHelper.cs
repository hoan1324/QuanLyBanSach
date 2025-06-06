using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper.Enum;

namespace CommonHelper.Helpers
{
    public static class AttributeHelper
    {
        public static int GetMethodEnum(string httpMethod="GET")
        {
            if(httpMethod.ToLower()== "get")
            {
                return (int)PermissionMethodEnum.Read; // Read
            }
            else if (httpMethod.ToLower() == "post")
            {
                return (int)PermissionMethodEnum.Create; // Create
            }
            else if (httpMethod.ToLower() == "put")
            {
                return (int)PermissionMethodEnum.Update; // Update
            }
            else if (httpMethod.ToLower() == "delete")
            {
                return (int)PermissionMethodEnum.Delete; // Delete
            }
            return (int)PermissionMethodEnum.Read; // Default to Read if no match found
        }
    }
}
