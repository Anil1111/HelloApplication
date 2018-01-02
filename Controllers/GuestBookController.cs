using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloApplication.Models;
using HelloApplication.Context;
using HelloApplication.Entities;
using System.Text;

namespace HelloApplication.Controllers
{
    public class GuestBookController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            using (var dbContext = new MessageContext())
            {
                var messages =
                    dbContext.Messages
                    .OrderBy(messageEntity => messageEntity.Id)
                    .Skip((page - 1) * Constants.PageSize)
                    .Take(Constants.PageSize)
                    .Select(messageEntity =>
                        new Message
                        {
                            Id = messageEntity.Id,
                            Post = messageEntity.Post
                        })
                    .ToList();

                var count = dbContext.Messages.Count();
                ViewBag.CurrentPage = page;
                ViewBag.Count = count;
                ViewBag.ControllerName = ControllerContext.RouteData.Values["controller"].ToString();                
               
                return View(messages);
            }
        }


        public ActionResult Post(Message message)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new MessageContext())
                {
                    var messageEntity = new MessageEntity()
                    {
                        Post = message.Post
                    };
                    dbContext.Messages.Add(messageEntity);
                    dbContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            using (var dbContext = new MessageContext())
            {
                var message = dbContext.Messages.Find(id);
                if (message != null)
                {
                    dbContext.Messages.Remove(message);
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            } 
        }
    } 
}