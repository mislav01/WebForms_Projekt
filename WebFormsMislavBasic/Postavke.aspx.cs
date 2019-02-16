using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsMislavBasic
{
    public partial class Postavke : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize(2);
            (Master as Pocetna).ChangeButtonColor(4);
        }

        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTheme.SelectedIndex == 0)
            {
                return;
            }

            var cookie = new HttpCookie("cookieTema", ddlTheme.SelectedItem.ToString());
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);
            Response.Redirect(Request.RawUrl);
        }

        protected void ddlLangChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLangChoose.SelectedIndex == 0)
            {
                return;
            }

            var cookie = new HttpCookie("cookieLanguage", ddlLangChoose.SelectedValue);
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void ddlRepoChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRepoChoose.SelectedIndex == 0)
            {
                return;
            }

            var cookie = new HttpCookie("cookieRepo", ddlRepoChoose.SelectedValue);
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);
            this.Response.Redirect(this.Request.RawUrl);
        }
    }
}