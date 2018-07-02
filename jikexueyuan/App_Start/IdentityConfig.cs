using jikexueyuan.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jikexueyuan.App_Start
{
    public class IdentityConfig
    {
        /// <summary>
        /// 默认配置名称，webcofig里指定到类就行
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
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
        /// <summary>
        /// 自定义方法名称，webconig需要指定到方法名称
        /// </summary>
        /// <param name="app"></param>
        public void Config2(IAppBuilder app)
        {
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
                LoginPath = new Microsoft.Owin.PathString("/Identity/Login"),
            });
        }

    }
}