using jikexueyuan.Infrastructure;
using jikexueyuan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace jikexueyuan.Controllers
{
    
    public class IdentityController : Controller
    {
        // GET: Identity
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
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
                    Email = model.Email,
                };
                IdentityResult result = await manageUser.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
            foreach(string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}