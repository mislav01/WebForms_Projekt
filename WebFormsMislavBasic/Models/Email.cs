using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsMislavBasic.Models
{
    public class Email
    {
        public int IDEmail { get; set; }
        public string Naziv { get; set; }
        public int OsobaID { get; set; }
    }
}