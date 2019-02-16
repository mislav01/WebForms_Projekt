using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WebFormsMislavBasic.Models.Dal
{
    public class Repository : IRepo
    {

        private static DataSet ds;
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void CreateEmail(List<Email> emailList)
        {
            foreach (Email email in emailList)
            {
                SqlHelper.ExecuteNonQuery(cs, "CreateEmail", email.Naziv, email.OsobaID);
            }
        }

        public void CreateOsoba(Osoba osoba)
        {
            SqlHelper.ExecuteNonQuery
                (cs, "CreateOsoba", osoba.Ime, osoba.Prezime, osoba.Telefon, osoba.Lozinka, osoba.StatusID, osoba.GradID);
        }

        public void DeleteEmail(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteEmail", id);
        }

        public void DeleteOsoba(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteOsoba", id);
        }

        public void EditEmail(Email email)
        {
            SqlHelper.ExecuteNonQuery
                (cs, "EditEmail", email.IDEmail, email.Naziv, email.OsobaID);
        }

        public void EditOsoba(Osoba osoba)
        {
            SqlHelper.ExecuteNonQuery
                (cs, "EditOsoba", osoba.IDOsoba, osoba.Ime, osoba.Prezime, osoba.Telefon, osoba.Lozinka, osoba.GradID, osoba.StatusID); ;
        }

        public List<Email> GetEmails()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetEmails");
            List<Email> emailList = new List<Email>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                emailList.Add(new Email
                {
                    IDEmail = (int)row["IDEmail"],
                    Naziv = row["Naziv"].ToString(),
                    OsobaID = (int)row["OsobaID"]
                });
            }

            return emailList;
        }

        public IEnumerable<Grad> GetGradovi()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetGradovi");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new Grad
                {
                    IDGrad = (int)row["IDGrad"],
                    Naziv = row["Naziv"].ToString()
                };
            }
        }

        public List<Osoba> GetOsobe()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetOsobe");
            List<Osoba> osobaList = new List<Osoba>();
            

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                osobaList.Add( new Osoba
                {
                    IDOsoba = (int)row["IDOsoba"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Telefon = row["Telefon"].ToString(),
                    Email = GetEmails().Where(item => item.OsobaID == (int)row["IDOsoba"]).ToList(),
                    Lozinka = row["Lozinka"].ToString(),
                    StatusID = (int)row["StatusID"],
                    GradID = (int)row["GradID"]
                });
            }

            return osobaList;

        }

        public IEnumerable<Status> GetStatus()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetStatus");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new Status
                {
                    IDStatus = (int)row["IDStatus"],
                    Naziv = row["Naziv"].ToString()
                };
            }
        }

        public bool Login(string email, string password, out Osoba cookieOsoba)
        {
            IEnumerable<Email> emailovi = GetEmails();
            IEnumerable<Osoba> osobe = GetOsobe();
            

            foreach (Email e in emailovi)
            {
                if (email.Equals(e.Naziv))
                {
                    foreach (Osoba o in osobe)
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
    }
}