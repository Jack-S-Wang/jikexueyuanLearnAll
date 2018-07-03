using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using jikexueyuan.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(jikexueyuan.Startup))]

namespace jikexueyuan
{
    //using System.IO;
    //using System.Text;
    //using appFun = Func<IDictionary<string, object>, Task>;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Use(new Func<appFun, appFun>(next => async nve =>
            //{
            //    string befor = "\r\nbefor";
            //    string after = "\r\nafter";
            //    var response = nve["owin.ResponseBody"] as Stream;
            //    await response.WriteAsync(Encoding.UTF8.GetBytes(befor), 0, befor.Length);
            //    await next.Invoke(nve);
            //    await response.WriteAsync(Encoding.UTF8.GetBytes(after), 0, after.Length);
            //}));

            //app.Run(content => content.Response.WriteAsync("\r\nhelloword"));
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            //通过CreatPerOwinContext方法将AppIdentityDBContext
            //和AppManageUser的实例注册到OwinContext中，这样确保每一次请求都能获取到
            //相关ASP.NET Identity对象，而且还能保证全局唯一。
            app.CreatePerOwinContext(AppIdentityDBContext.Create);
            app.CreatePerOwinContext<AppManageUser>(AppManageUser.Create);
            //UserCookieAuthentication方法指定了身份验证类型为ApplicationCookie,同时指定
            //LoginPath属性，当Http请求内容认证不通过时重定向到指定的URL
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
            });

        }
    }
}
