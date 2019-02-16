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
    public partial class Login : MyPage
    {
        private IRepo repo = RepoFactory.GetRepo();
        private string email;
        private string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Osoba osoba = null;
            email = txtEmail.Text;
            password = txtPassword.Text;
            
            if (repo.Login(email, password, out osoba))
            {
                Session["userSession"] = osoba;
                Session.Add("userSession", osoba);

                if (cbZapamtiMe.Checked)
                {
                    var cookie = new HttpCookie("userCookie", osoba.ToString());
                    cookie.Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies.Add(cookie);
                }

                
                Response.Redirect("~/PrikazOsoba.aspx");
            }
            else
            {
                txtEmail.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }
    }
}