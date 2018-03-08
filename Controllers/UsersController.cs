using HelloApplication.Context;
using HelloApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloApplication.Controllers
{
    [Authorize(Users = Constants.UserAdmin)]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index(int page = 1)
        {
            using (var context = new MessageContext())
            {
                var users = context.Users.OrderBy(u => u.UserName)                    
                    .Select(u => new User
                    {
                        UserName = u.UserName
                    })
                    .Skip((page - 1) * Constants.PageSize)
                    .Take(Constants.PageSize)
                    .ToList();
                
                ViewBag.CurrentPage = page;
                ViewBag.Count = context.Users.Count();
                ViewBag.ControllerName = ControllerContext.RouteData.Values["controller"].ToString();

                return View(users);
            }
        }
    }
}