﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Nume serviciu")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Descriere")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Perioada necesara de recuperare")]
        public string RecoveryPeriod { get; set; }

        public virtual ICollection<Service> Services { get; set; }

    }
}