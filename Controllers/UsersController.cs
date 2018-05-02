using HelloApplication.Context;
using HelloApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
                        Id = u.Id,
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
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                using (var context = new MessageContext())
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var user = manager.FindById(id);                    
                    manager.Delete(user);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new Exception("Произошла некоторая ошибка");
            }

            return RedirectToAction("Index");
        }
    }
}