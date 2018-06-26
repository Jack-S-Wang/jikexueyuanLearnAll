using jikexueyuan.Infrastructure;
using jikexueyuan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jikexueyuan.Infrastructure
{
    public class AppManageUser:UserManager<AppUser>
    {
        public AppManageUser(IUserStore<AppUser> store) : base(store)
        {

        }

        public static AppManageUser Creat(
            IdentityFactoryOptions<AppManageUser> options,
                IOwinContext context)
        {
            //从OWIN上下文中获取Database Context
            var db = context.Get < AppIdentityDBContext >();
            //UserStore<T>是包含在Microsoft.AspNet.Identity.EntityFramework中，
            //它实现了ManageUser类中与用户操作相关的方法.
            //也就是说UserStore<T>类中的方法（注入：FindById,FindByNameAsnc...)
            //通过EntityFramework检索和持久化UserInfo到数据库中
            var manager = new AppManageUser(new UserStore<AppUser>(db));
            return manager;
        }
    }
}