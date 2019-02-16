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
    public partial class Pocetna : System.Web.UI.MasterPage
    {

        public void SwitchBackgroundColor(string theme)
        {
            body.Attributes["style"] = $"background-color: {theme};";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Osoba osobaSesija = null;
            SetFooter();
            osobaSesija = HideShowButtons();

            if (osobaSesija != null)
            {
                btnUser.Text = $"{osobaSesija.Ime} {osobaSesija.Prezime}";
            }
            else
            {
                btnUser.Visible = false;
                btnLogOut.Visible = false;
            }
        }

        private Osoba HideShowButtons()
        {
            if (Session["userSession"] != null)
            {
                return Session["userSession"] as Osoba;
            }
            else if (Request.Cookies["userCookie"]?.Value != null)
            {
                return CreateOsobaFromCookie(Request.Cookies["userCookie"]?.Value);
            }

            return null;
        }

        private Osoba CreateOsobaFromCookie(string userCookieString)
        {
            char DELIMITER = '|';
            string[] tokens = userCookieString.Split(DELIMITER);
            Osoba osoba = new Osoba
            {
                IDOsoba = int.Parse(tokens[0]),
                Ime = tokens[1],
                Prezime = tokens[2]
                //Telefon = tokens[3],
                //Lozinka = tokens[4],
                //Email = tokens[5],
                //StatusID = int.Parse(tokens[6]),
                //GradID = int.Parse(tokens[7])
            };

            return osoba;
        }

        private void SetFooter()
        {
            lblFooter.Text = DateTime.Now.ToLongDateString() + " | " + "RWA - <span style='color: red; '>WebForms</span> - Project";
            lblRepoInfo.Text = "Repository" + " - " + RepoFactory.repoSwitch;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Remove("userCookie");
            Response.Redirect("~/Login.aspx");
        }

        protected void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DodavanjeOsoba.aspx");
        }

        protected void btnEditData_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AzuriranjeOsoba.aspx");
        }

        protected void btnPersonList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PrikazOsoba.aspx");
        }

        protected void btnSetup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Postavke.aspx");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("mailto:{osobaSesija.Email0}");
        }

        public void ChangeButtonColor(int btn)
        {
            switch (btn)
            {
                case 1:
                    btnAddNewPerson.CssClass = "btn btn-primary";
                    break;
                case 2:
                    btnEditData.CssClass = "btn btn-primary";
                    break;
                case 3:
                    btnPersonList.CssClass = "btn btn-primary";
                    break;
                case 4:
                    btnSetup.CssClass = "btn btn-primary";
                    break;
            }
        }
    }
}