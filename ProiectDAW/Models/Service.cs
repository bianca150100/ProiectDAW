using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nume")]
        public string Name { get; set; }

        [Required]
        public string Pret { get; set; }

        [Required]
        public int GeneralServiceId { get; set; }

        [ForeignKey("GeneralServiceId")]
        public GeneralService GeneralService { get; set; }
    }
}