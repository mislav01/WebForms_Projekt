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
    public partial class AzuriranjeOsoba : MyPage
    {
        private IRepo repo = RepoFactory.GetRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize(2);
            (Master as Pocetna).ChangeButtonColor(2);
            IEnumerable<Osoba> osobe = repo.GetOsobe();

            if (int.TryParse(Request.QueryString["Id"], out int idOsobe))
            {
                Osoba osoba = osobe.First(o => o.IDOsoba == idOsobe);

                AddPerson(osoba, 1);
            }
            else
            {
                foreach (Osoba osoba in osobe)
                {
                    AddPerson(osoba, 0);
                }
            }
        }

        private void AddPerson(Osoba osoba, int center)
        {
            OsobaKontrola osobaKontrola = (OsobaKontrola)LoadControl("~/OsobaKontrola.ascx");
            osobaKontrola.CreateOsoba(osoba, center);
            phOsobe.Controls.Add(osobaKontrola);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}