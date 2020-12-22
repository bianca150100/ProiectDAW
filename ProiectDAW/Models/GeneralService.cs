using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class GeneralService
    {
        [Key]
        public int GeneralServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string RecoveryPeriod { get; set; }

        public virtual ICollection<Service> Services { get; set; }

    }
}