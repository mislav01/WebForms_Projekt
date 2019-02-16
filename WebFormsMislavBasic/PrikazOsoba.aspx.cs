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
    public partial class PrikazOsoba : MyPage
    {
        private IRepo repo = RepoFactory.GetRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize(1);
            (Master as Pocetna).ChangeButtonColor(3);

            gridViewOsobe.DataSource = repo.GetOsobe();
            gridViewOsobe.DataBind();

            List<Osoba> osobeList = repo.GetOsobe();

            repeaterOsobe.DataSource = PrepareForRepeater(osobeList);
            repeaterOsobe.DataBind();
        }

        private List<Osoba> PrepareForRepeater(List<Osoba> osobaList)
        {
            List<Osoba> osobaListPerpaerd = osobaList;
            List<Status> statusList = repo.GetStatus().ToList();
            List<Grad> gradList = repo.GetGradovi().ToList();

            foreach (Osoba osoba in osobaListPerpaerd)
            {
                foreach (Grad grad in gradList)
                {
                    if (osoba.GradID == grad.IDGrad)
                    {
                        osoba.NazivGrad = grad.Naziv;
                    }
                }
                foreach (Status status in statusList)
                {
                    if (osoba.StatusID == status.IDStatus)
                    {
                        osoba.NazivStatus = status.Naziv;
                    }
                }
            }
            return osobaListPerpaerd;
        }

        protected void gridOsobe_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gridOsobe_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gridOsobe_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void Clicked_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/AzuriranjeOsoba.aspx?Id=" + e.CommandArgument);
        }
    }
}