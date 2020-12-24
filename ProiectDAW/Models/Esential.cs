using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Esential
    {
        public string Nume { get; set; }
        public string Data { get; set; }
        public string Ora { get; set; }

        public Esential(string lastName, string data, string ora)
        {
            Nume = lastName;
            Data = data;
            Ora = ora;
        }
    }
}