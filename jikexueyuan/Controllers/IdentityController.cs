using jikexueyuan.Infrastructure;
using jikexueyuan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace jikexueyuan.Controllers
{

    public class IdentityController : Controller
    {
        // GET: Identity
        public ActionResult Index(string seachEmail, string searchName)
        {
            var emailList = new List<string>();
            var el = from u in manageUser.Users
                     select u.Email;
            emailList.AddRange(el.Distinct());
            ViewBag.seachEmail = new SelectList(emailList);
            var user = from m in manageUser.Users
                       select m;
            if (!String.IsNullOrEmpty(seachEmail))
            {
                user = user.Where(s => s.Email == seachEmail);
            }
            if (!String.IsNullOrEmpty(searchName))
            {
                user = user.Where(s => s.UserName.Contains(searchName));
            }
            //可以获取web.config文件里的内容
            //var a = ConfigurationManager.AppSettings["ClientValidationEnabled"];
            return View(user);
        }
        public ActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Creat(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //实例化一个AppUser对象，将ViewModel转化为AppUser对象
                var user = new AppUser
                {
                    UserName = model.Name,
                };
                IdentityResult result = await manageUser.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    result = await manageUser.CreateAsync(user, model.Email);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
                
                AddErrorsFormResult(result);
            }
            return View(model);
        }
        private AppManageUser manageUser
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppManageUser>();
            }
        }

        private void AddErrorsFormResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public string welcome(string name)
        {
            return HttpUtility.HtmlEncode(name);//这个防止黑客的参数攻击
            //也可写成server.HtmlEncode(name)
        }
    }
}