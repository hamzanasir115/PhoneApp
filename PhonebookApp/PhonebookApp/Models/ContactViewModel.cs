using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhonebookApp.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Contact Id")]
        public int ContactId { get; set; }
        [Display(Name ="Person Id")]
        public int PersonId { get; set; }
        [Display(Name = "Contact Number")]
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Type { get; set; }
    }
}