using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelloApplication.Entities
{
    [Table("Messages")]
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Post { get; set; }
    }
}