using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormsMislavBasic.Models.Dal
{
    public interface IRepo
    {
        List<Osoba> GetOsobe();
        IEnumerable<Grad> GetGradovi();
        IEnumerable<Status> GetStatus();
        List<Email> GetEmails();
        void CreateEmail(List<Email> emailList);
        void CreateOsoba(Osoba osoba);
        bool Login(string email, string password, out Osoba osoba);
        void EditOsoba(Osoba osoba);
        void EditEmail(Email email);
        void DeleteOsoba(int id);
        void DeleteEmail(int id);
    }
}
