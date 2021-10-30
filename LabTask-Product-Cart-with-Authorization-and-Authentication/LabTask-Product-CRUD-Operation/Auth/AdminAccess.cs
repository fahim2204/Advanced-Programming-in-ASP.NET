using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask_Product_CRUD_Operation.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var type = httpContext.User.Identity.Name;
                if (type == "admin")
                {
                    return true;
                }
                else { return false; }
            }
            else 
                return false;
        }
    }
}