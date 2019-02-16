using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using WebFormsMislavBasic.Models;
using WebFormsMislavBasic.Models.Dal;

namespace WebFormsMislavBasic
{
    public class MyPage : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            string theme = Request.Cookies["cookieTema"]?.Value;
            string repository = Request.Cookies["cookieRepo"]?.Value;

            if (!(theme == string.Empty))
            {
                (Master as Pocetna).SwitchBackgroundColor(theme);
            }

            if (!(repository == string.Empty))
            {
                RepoFactory.repoSwitch = repository;
            }
        }

        public void Authorize(int status)
        {
            if (Session["userSession"] != null)
            {
                Osoba osobaSesija = Session["userSession"] as Osoba;
                if (osobaSesija.StatusID < status)
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();

            string culture = Request.Cookies["cookieLanguage"]?.Value;

            if (!(culture == null))
            {
                CultureInfo cultureInfo;

                if (culture.Equals("hr"))
                {
                    cultureInfo = new CultureInfo("hr");
                }
                else
                {
                    cultureInfo = new CultureInfo("en");
                }

                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }
        }
    }
}