using jikexueyuan.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace jikexueyuan.Infrastructure
{
    public class AppIdentityDBContext:IdentityDbContext<AppUser>
    {
        /// <summary>
        ///构造函数调用基类构造函数并将数据库连接字符串的Name作为参数传递,它将作为连接数据库         
        /// </summary>
        public AppIdentityDBContext()
            :base("IdentityDB")
        {

        }
        /// <summary>
        /// 静态构造函数调用Database.SetInitializer方法Seed数据库而且只执行一次
        /// </summary>
        static AppIdentityDBContext()
        {
            Database.SetInitializer(new IdentityDBInit());
        }

        /// <summary>
        /// 创建Database Context实例
        /// </summary>
        /// <returns></returns>
        public static AppIdentityDBContext Create()
        {
            return new AppIdentityDBContext();
        }
    }

    public class IdentityDBInit : DropCreateDatabaseIfModelChanges<AppIdentityDBContext>
    {
        protected override void Seed(AppIdentityDBContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        private void PerformInitialSetup(AppIdentityDBContext context)
        {
            //初始化操作
        }
    }
}