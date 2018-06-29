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
using PagedList;

namespace jikexueyuan.Controllers
{
    [Authorize(Roles ="admin")]//设置所有的请求网页都得认证登入才可以加载
    
    public class IdentityController : Controller
    {
        public ActionResult AutoComplete(string term)
        {
            var model = manageUser.Users.Where
                (s => s.UserName.StartsWith(term)).Take(10)
                .Select(m => new
                { label = m.UserName });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /*
         * 子请求进行缓存与父请求缓存设置不同的时间长度
        [ChildActionOnly]
        [OutputCache(Duration =60)]
        */

        [AllowAnonymous]//不需要登入认证
        [OutputCache(CacheProfile ="long",VaryByHeader ="Accept.Language")]//缓存保存60秒
        // GET: Identity
        public ActionResult Index(string seachEmail, string searchName,int page=1)
        {
            var emailList = new List<string>();
            var el = from u in manageUser.Users
                     select u.Email;
            emailList.AddRange(el.Distinct());
            ViewBag.seachEmail = new SelectList(emailList);
            var user = from m in manageUser.Users
                       select m;

            if (seachEmail != null)
            {
                user = user.Where(s => s.Email == seachEmail);
            }
            if (!String.IsNullOrEmpty(searchName))
            {
                user = user.Where(s => s.UserName.Contains(searchName));
            }
            var userList = user.OrderByDescending(s => s.Id).ToPagedList(page, 10);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_partialUser", userList);
            }
            //可以获取web.config文件里的内容
            //var a = ConfigurationManager.AppSettings["ClientValidationEnabled"];
            return View(userList);
        }
        
        public ActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Creat(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //实例化一个AppUser对象，将ViewModel转化为AppUser对象
                var user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
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
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
}