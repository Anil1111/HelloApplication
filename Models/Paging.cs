using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloApplication.Models
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
        public List<int> Pages { get; set; }
        public string ControllerName { get; set; }
    }
}