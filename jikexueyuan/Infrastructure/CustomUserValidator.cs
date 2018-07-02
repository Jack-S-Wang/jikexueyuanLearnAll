using jikexueyuan.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace jikexueyuan.Infrastructure
{
    public class CustomUserValidator:UserValidator<AppUser>
    {
        public CustomUserValidator(AppManageUser mgr)
            :base(mgr)
        {

        }
        public override async Task<IdentityResult> ValidateAsync(AppUser item)
        {
            IdentityResult result = await base.ValidateAsync(item);
            if (!item.Email.ToLower().EndsWith("@jkxy.com"))
            {
                List<string> errors = result.Errors.ToList();
                errors.Add("Email地址只支持jkxy域名");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}