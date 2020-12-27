using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProiectDAW.Models.CustomValidation;

namespace ProiectDAW.Models
{

    public class Appointment
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [DisplayName("Prenume")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Nume")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Data programarii")]
        [DataValidation(ErrorMessage = "Data trebuie sa fie in formatul yyyy-MM-dd si in viitor")]
        public string Data { get; set; }

        [Required]
        [DisplayName("Ora programarii")]
        [OraValidation(ErrorMessage = "Programarile se fac in intervalul orar 8-18")]
        public string Ora { get; set; }

        [Required]
        public int MedicId { get; set; }

        [ForeignKey("MedicId")]
        public Medic Medic { get; set; }

    }
}