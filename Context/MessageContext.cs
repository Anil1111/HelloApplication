using HelloApplication.Entities;
using HelloApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloApplication.Context
{
    public class MessageContext: ApplicationDbContext
    {
        public MessageContext()
        {
            Database.SetInitializer(new MyInitializer());
        }

        public DbSet<MessageEntity> Messages { get; set; }
    }   
}