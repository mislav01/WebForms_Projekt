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
    public partial class OsobaKontrola : System.Web.UI.UserControl
    {
        private IRepo repo = RepoFactory.GetRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlStatus.DataSource = repo.GetStatus();
                ddlStatus.DataBind();

                ddlCity.DataSource = repo.GetGradovi();
                ddlCity.DataBind();
            }
        }

        public void CreateOsoba(Osoba osoba, int center)
        {
            txtID.Value = osoba.IDOsoba.ToString();
            txtName.Text = osoba.Ime;
            txtSurname.Text = osoba.Prezime;
            txtPhone.Text = osoba.Telefon;
            txtEmail.Text = osoba.Email.First().Naziv;
            ddlEmail.DataSource = osoba.Email;
            ddlEmail.DataBind();
            txtPassword.Text = osoba.Lozinka;
            ddlStatus.SelectedValue = osoba.StatusID.ToString();
            ddlCity.SelectedValue = osoba.GradID.ToString();

            if (center == 1)
            {
                mojDiv.Attributes["class"] = "myPerson1";
            }
        }

        protected void ddlEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Text = ddlEmail.SelectedItem.Text;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtID.Value) == 1)
            {
                return;
            }

            Osoba osoba = new Osoba
            {
                IDOsoba = int.Parse(txtID.Value),
                Ime = txtName.Text,
                Prezime = txtSurname.Text,
                Telefon = txtPhone.Text,
                Lozinka = txtPassword.Text,
                StatusID = int.Parse(ddlStatus.SelectedValue),
                GradID = int.Parse(ddlCity.SelectedValue)
            };
            repo.EditOsoba(osoba);

            Email email0 = new Email
            {
                IDEmail = int.Parse(ddlEmail.Items[0].Value),
                Naziv = ddlEmail.Items[0].ToString(),
                OsobaID = int.Parse(txtID.Value)
            };
            repo.EditEmail(email0);

            if (ddlEmail.Items.Count > 1)
            {
                Email email1 = new Email
                {
                    IDEmail = int.Parse(ddlEmail.Items[1].Value),
                    Naziv = ddlEmail.Items[1].ToString(),
                    OsobaID = int.Parse(txtID.Value)
                };
                repo.EditEmail(email1);
            }
            else if (ddlEmail.Items.Count > 2)
            {
                Email email2 = new Email
                {
                    IDEmail = int.Parse(ddlEmail.Items[2].Value),
                    Naziv = ddlEmail.Items[2].ToString(),
                    OsobaID = int.Parse(txtID.Value)
                };
                repo.EditEmail(email2);
            }

            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtID.Value) == 1)
            {
                return;
            }

            if (ddlEmail.Items.Count == 3)
            {
                repo.DeleteEmail(int.Parse(ddlEmail.Items[0].Value));
                repo.DeleteEmail(int.Parse(ddlEmail.Items[1].Value));
                repo.DeleteEmail(int.Parse(ddlEmail.Items[2].Value));
            }
            else if (ddlEmail.Items.Count == 2)
            {
                repo.DeleteEmail(int.Parse(ddlEmail.Items[0].Value));
                repo.DeleteEmail(int.Parse(ddlEmail.Items[1].Value));
            }
            else if (ddlEmail.Items.Count == 1)
            {
                repo.DeleteEmail(int.Parse(ddlEmail.Items[0].Value));
            }

            repo.DeleteOsoba(int.Parse(txtID.Value));

            this.Response.Redirect(this.Request.RawUrl);

        }

        protected void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtID.Value) == 1)
            {
                this.Response.Redirect(this.Request.RawUrl);
                return;
            }

            ddlEmail.SelectedItem.Text = txtEmail.Text;
        }
    }
}