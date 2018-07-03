using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(owin.host.Startup))]

namespace owin.host
{
    using System.IO;
    using System.Text;
    using appFun = Func<IDictionary<string, object>, Task>;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            app.Use(new Func<appFun, appFun>(next => async nve =>
            {
                string befor = "\r\nbefor";
                string after = "\r\nafter";
                var response = nve["owin.ResponseBody"] as Stream;
                await response.WriteAsync(Encoding.UTF8.GetBytes(befor), 0, befor.Length);
                await next.Invoke(nve);
                await response.WriteAsync(Encoding.UTF8.GetBytes(after), 0, after.Length);
            }));

            app.Run(content => content.Response.WriteAsync("\r\nhelloword"));

           

        }
    }
}
