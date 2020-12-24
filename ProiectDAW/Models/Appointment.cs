using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{

    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string Ora { get; set; }

        [Required]
        public int MedicId { get; set; }

        [ForeignKey("MedicId")]
        public Medic Medic { get; set; }

    }
}