using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Medic
    {
        [Key]
        public int MedicId { get; set; }

        [Required]
        [DisplayName("Prenume")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Nume")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Experienta")]
        public int Experience { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Numar telefon")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Functia")]
        public string Function { get; set; }

        [Required]
        [DisplayName("Sumar medic")]
        public string Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}