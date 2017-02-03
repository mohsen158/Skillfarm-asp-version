using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Adminpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var works = from i in db.works select i;
            worksrepeat.DataSource = works;
            worksrepeat.DataBind();
        }

        protected void ApOrDecCommand(object source, RepeaterCommandEventArgs e)
        {
            DataClasses1DataContext db =new DataClasses1DataContext();
            int id = Convert.ToInt32( e.CommandArgument.ToString());
            var workupdate = from i in db.works
                where i.id == id
                select i;
            work w = workupdate.First();
            if (e.CommandName=="Approve")
            {
                w.Approve = 1;
              
            }
            else if (e.CommandName=="Decline")
            {
                w.Approve = 0;
            }
            db.SubmitChanges();
        }
    }
}