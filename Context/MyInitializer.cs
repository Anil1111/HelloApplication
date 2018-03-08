using HelloApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloApplication.Context
{
    public class MyInitializer: CreateDatabaseIfNotExists<MessageContext>
    {
        protected override void Seed(MessageContext context)
        {
            base.Seed(context);

            var store = new UserStore<ApplicationUser>(context);
            var user = new ApplicationUser { UserName = Constants.UserAdmin };
            var userManager = new ApplicationUserManager(store);
            userManager.Create(user, "Test1234");
        }
    }
}