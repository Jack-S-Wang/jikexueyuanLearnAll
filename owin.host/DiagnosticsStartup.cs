using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Diagnostics;

[assembly: OwinStartup(typeof(owin.host.DiagnosticsStartup))]

namespace owin.host
{
    public class DiagnosticsStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseWelcomePage("/");
            app.UseErrorPage();
            app.Run(content =>
            {
                //将请求记录在控制台
                Trace.WriteLine(content.Request.Uri);
                if (content.Request.Path.ToString().Equals("/error"))
                {
                    throw new Exception("抛出异常");
                }
                return content.Response.WriteAsync("hello word");
            });
        }
    }
}
