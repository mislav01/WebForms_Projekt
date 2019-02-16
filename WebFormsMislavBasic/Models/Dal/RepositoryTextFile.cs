using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebFormsMislavBasic.Models.Dal
{
    public class RepositoryTextFile : IRepo
    {
        private IRepo repository;
        private const string repoFileEmail = "D:/repositoryEmail.txt";
        private const string repoFileOsoba = "D:/repositoryOsoba.txt";
        private const string repoFileGrad = "D:/repositoryGrad.txt";
        private const string repoFileStatus = "D:/repositoryStatus.txt";
        private const string DELIMITER = "|";
        private const char DELIMITER_CHAR = '|';

        public RepositoryTextFile()
        {
            repository = new Repository();

            if (!File.Exists(repoFileEmail))
            {
                CreateEmail(repository.GetEmails());
            }
            if (!File.Exists(repoFileOsoba))
            {
                List<Osoba> repoOsobe = repository.GetOsobe();
                foreach (Osoba osoba in repoOsobe)
                {
                    CreateOsoba(osoba);
                }
            }
            if (!File.Exists(repoFileGrad))
            {
                List<Grad> repoGradovi = repository.GetGradovi().ToList();
                CreateGrad(repoGradovi);
            }
            if (!File.Exists(repoFileStatus))
            {
                List<Status> repoStatus = repository.GetStatus().ToList();
                CreateStatus(repoStatus);
            }
        }

        public void CreateStatus(List<Status> statusList)
        {
            foreach (Status status in statusList)
            {
                string statusString = string.Join(DELIMITER, "STATUS", status.IDStatus, status.Naziv);
                File.AppendAllText(repoFileStatus, statusString + Environment.NewLine);
            }
        }

        public void CreateGrad(List<Grad> gradList)
        {
            foreach (Grad grad in gradList)
            {
                string gradString = string.Join(DELIMITER, "GRAD", grad.IDGrad, grad.Naziv);
                File.AppendAllText(repoFileGrad, gradString + Environment.NewLine);
            }
        }
        public void CreateEmail(List<Email> emailList)
        {
            foreach (Email email in emailList)
            {
                string emailString = string.Join(DELIMITER, "EMAIL", email.IDEmail, email.Naziv, email.OsobaID);
                File.AppendAllText(repoFileEmail, emailString + Environment.NewLine);
            }
        }

        public void CreateOsoba(Osoba osoba)
        {
            string osobaString = string.Join(DELIMITER, "OSOBA", osoba.IDOsoba, osoba.Ime, osoba.Prezime, osoba.Telefon, osoba.Lozinka, osoba.StatusID, osoba.GradID);
            File.AppendAllText(repoFileOsoba, osobaString + Environment.NewLine);
        }

        public List<Email> GetEmails()
        {
            List<Email> listaMejlova = new List<Email>();

            List<string> repoFileRead = File.ReadAllLines(repoFileEmail).ToList();
            foreach (string email in repoFileRead)
            {
                string[] emailPolje = email.Split(DELIMITER_CHAR);
                listaMejlova.Add( new Email
                {
                    IDEmail = int.Parse(emailPolje[1]),
                    Naziv = emailPolje[2],
                    OsobaID = int.Parse(emailPolje[3])
                });
                
            }

            return listaMejlova;
        }

        public IEnumerable<Grad> GetGradovi()
        {
            List<Grad> listaGradova = new List<Grad>();

            List<string> repoFileRead = File.ReadAllLines(repoFileGrad).ToList();
            foreach (string grad in repoFileRead)
            {
                string[] gradPolje = grad.Split(DELIMITER_CHAR);
                listaGradova.Add(new Grad
                {
                    IDGrad = int.Parse(gradPolje[1]),
                    Naziv = gradPolje[2]
                });

            }

            return listaGradova;
        }

        public List<Osoba> GetOsobe()
        {
            List<Osoba> listaOsoba = new List<Osoba>();
            List<string> repoFileRead = File.ReadAllLines(repoFileOsoba).ToList();

            foreach (string osoba in repoFileRead)
            {
                string[] osobaPolje = osoba.Split(DELIMITER_CHAR);
                listaOsoba.Add(new Osoba
                {
                    IDOsoba = int.Parse(osobaPolje[1]),
                    Ime = osobaPolje[2],
                    Prezime = osobaPolje[3],
                    Telefon = osobaPolje[4],
                    Email = GetEmails().Where(item => item.OsobaID == int.Parse(osobaPolje[1])).ToList(),
                    Lozinka = osobaPolje[5],
                    StatusID = int.Parse(osobaPolje[6]),
                    GradID = int.Parse(osobaPolje[7])
                });
            }
            return listaOsoba;
        }

        public IEnumerable<Status> GetStatus()
        {
            List<Status> listaStatusa = new List<Status>();

            List<string> repoFileRead = File.ReadAllLines(repoFileStatus).ToList();
            foreach (string status in repoFileRead)
            {
                string[] statusPolje = status.Split(DELIMITER_CHAR);
                listaStatusa.Add(new Status
                {
                    IDStatus = int.Parse(statusPolje[1]),
                    Naziv = statusPolje[2]
                });

            }

            return listaStatusa;
        }

        public bool Login(string email, string password, out Osoba cookieOsoba)
        {
            List<Email> listaEmailova = GetEmails();
            List<Osoba> listaOsoba = GetOsobe();

            foreach (Email e in listaEmailova)
            {
                if (email.Equals(e.Naziv))
                {
                    foreach (Osoba o in listaOsoba)
                    {
                        if (password.Equals(o.Lozinka) && o.IDOsoba.Equals(e.OsobaID))
                        {
                            cookieOsoba = o;
                            return true;
                        }
                    }
                }
            }

            cookieOsoba = null;
            return false;
        }

        public void EditOsoba(Osoba osoba)
        {
            List<Osoba> osobeList = GetOsobe();
            File.WriteAllText(repoFileOsoba, string.Empty);
            

            foreach (Osoba o in osobeList)
            {
                if (o.IDOsoba == osoba.IDOsoba)
                {
                    o.IDOsoba = osoba.IDOsoba;
                    o.Ime = osoba.Ime;
                    o.Prezime = osoba.Prezime;
                    o.Telefon = osoba.Telefon;
                    o.Lozinka = osoba.Lozinka;
                    o.StatusID = osoba.StatusID;
                    o.GradID = osoba.GradID;
                }
                string osobaString = string.Join(DELIMITER, "OSOBA", o.IDOsoba, o.Ime, o.Prezime, o.Telefon, o.Lozinka, o.StatusID, o.GradID);
                File.AppendAllText(repoFileOsoba, osobaString + Environment.NewLine);
            }
            
        }

        public void EditEmail(Email email)
        {
            List<Email> emailList = GetEmails();
            File.WriteAllText(repoFileEmail, string.Empty);


            foreach (Email e in emailList)
            {
                if (e.IDEmail == email.IDEmail)
                {
                    e.IDEmail = email.IDEmail;
                    e.Naziv = email.Naziv;
                    e.OsobaID = email.OsobaID;
                }
                string emailString = string.Join(DELIMITER, "EMAIL", e.IDEmail, e.Naziv, e.OsobaID);
                File.AppendAllText(repoFileEmail, emailString + Environment.NewLine);
            }
        }

        public void DeleteOsoba(int id)
        {
            List<Osoba> osobeList = GetOsobe();
            File.WriteAllText(repoFileOsoba, string.Empty);


            foreach (Osoba o in osobeList)
            {
                if (o.IDOsoba != id)
                {
                    string osobaString = string.Join(DELIMITER, "OSOBA", o.IDOsoba, o.Ime, o.Prezime, o.Telefon, o.Lozinka, o.StatusID, o.GradID);
                    File.AppendAllText(repoFileOsoba, osobaString + Environment.NewLine);
                }
            }
        }

        public void DeleteEmail(int id)
        {
            List<Email> emailList = GetEmails();
            File.WriteAllText(repoFileEmail, string.Empty);


            foreach (Email e in emailList)
            {
                if (e.IDEmail != id)
                {
                    string emailString = string.Join(DELIMITER, "EMAIL", e.IDEmail, e.Naziv, e.OsobaID);
                    File.AppendAllText(repoFileEmail, emailString + Environment.NewLine);
                }
            }
        }
    }
}