using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsMislavBasic.Models
{
    public class Osoba
    {
        public int IDOsoba { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Lozinka { get; set; }
        public int StatusID { get; set; }
        public int GradID { get; set; }

        public List<Email> Email { get; set; }
        public string NazivStatus { get; set; }
        public string NazivGrad { get; set; }

        public override string ToString()
        {
            string DELIMITER = "|";
            return String.Join(DELIMITER, IDOsoba, Ime, Prezime/*, Telefon, Lozinka, Email, StatusID, GradID*/);
        }
    }
}