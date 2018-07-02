using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace jikexueyuan.Infrastructure
{
    public class CustomPasswordValidator:PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            IdentityResult result = await base.ValidateAsync(password);
            if (password.Contains("@"))
            {
                //将异常信息添加到Errors集合中
                //注意：Errors集合只读
                List<string> errors = result.Errors.ToList();
                errors.Add("密码不能包含特殊符号");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}