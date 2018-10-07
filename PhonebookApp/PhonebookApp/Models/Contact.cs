using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public String ContactNumber { get; set; }
        public String Type { get; set; }
        public int PersonId { get; set; }
    }
}