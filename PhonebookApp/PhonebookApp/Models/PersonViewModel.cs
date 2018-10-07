using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhonebookApp.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public String MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Added On")]
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }
        [Display(Name = "Added By")]
        [DataType(DataType.Date)]
        public String AddedBy { get; set; }
        [Required]
        [Display(Name = "Home Address")]
        public String HomeAddress { get; set; }
        [Required]
        [Display(Name = "Home City")]
        public String HomeCity { get; set; }
        [Display(Name = "Facebook Id")]
        public String FaceBookAccountId { get; set; }
        [Display(Name = "LinkedIn Id")]
        public String LinkedInId { get; set; }
        [Display(Name = "Update On")]
        [DataType(DataType.Date)]
        public DateTime UpdateOn { get; set; }
        [Display(Name = "Image Path")]
        public String ImagePath { get; set; }
        [Display(Name = "Twitter Id")]
        public String TwitterId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Id")]
        public String EmailId { get; set; }




    }
}