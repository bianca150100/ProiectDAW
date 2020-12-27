using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [DisplayName("Nume")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Subiect")]
        public string Subject { get; set; }
        [Required]
        [DisplayName("Mesaj")]
        public string Message { get; set; }
    }
}