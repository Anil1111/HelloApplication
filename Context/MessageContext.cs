using HelloApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloApplication.Context
{
    public class MessageContext: DbContext
    {
        public MessageContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MessageContext>());
        }

        public DbSet<MessageEntity> Messages { get; set; }
    }   
}