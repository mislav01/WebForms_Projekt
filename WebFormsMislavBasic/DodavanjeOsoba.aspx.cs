using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMislavBasic.Models;
using WebFormsMislavBasic.Models.Dal;

namespace WebFormsMislavBasic
{
    public partial class DodavanjeOsoba : MyPage
    {
        private IRepo repo = RepoFactory.GetRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize(2);
            (Master as Pocetna).ChangeButtonColor(1);

            if (!IsPostBack)
            {
                HideTxtEmail();

                ddlCity.DataSource = repo.GetGradovi();
                ddlCity.DataBind();

                ddlStatus.DataSource = repo.GetStatus();
                ddlStatus.DataBind();
            }
        }

        private void HideTxtEmail()
        {
            txtEmail1.Visible = false;
            txtEmail2.Visible = false;
        }

        protected void btnAddEmail_Click(object sender, EventArgs e)
        {
            if (!txtEmail1.Visible && !txtEmail2.Visible)
            {
                txtEmail1.Visible = true;
                return;
            }

            if (txtEmail1.Visible && !txtEmail2.Visible)
            {
                txtEmail2.Visible = true;
                btnAddEmail.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Osoba osoba = new Osoba
            {
                IDOsoba = repo.GetOsobe().Last().IDOsoba + 1,
                Ime = txtName.Text,
                Prezime = txtSurname.Text,
                Telefon = txtTelephone.Text,
                Lozinka = txtPassword.Text,
                StatusID = ddlStatus.SelectedIndex + 1,
                GradID = ddlCity.SelectedIndex + 1
            };

            repo.CreateOsoba(osoba);

            Osoba lastOsoba = repo.GetOsobe().Last();

            List<Email> emailList = new List<Email>();

            emailList.Add(new Email
            {
                IDEmail = repo.GetEmails().Last().IDEmail + 1,
                Naziv = txtEmail.Text,
                OsobaID = lastOsoba.IDOsoba
            });

            if (txtEmail1.Text != string.Empty)
            {
                emailList.Add(new Email
                {
                    IDEmail = repo.GetEmails().Last().IDEmail + 2,
                    Naziv = txtEmail1.Text,
                    OsobaID = lastOsoba.IDOsoba
                });
            }

            if (txtEmail2.Text != string.Empty)
            {
                emailList.Add(new Email
                {
                    IDEmail = repo.GetEmails().Last().IDEmail + 3,
                    Naziv = txtEmail2.Text,
                    OsobaID = lastOsoba.IDOsoba
                });
            }

            repo.CreateEmail(emailList);
            
        }
    }
}