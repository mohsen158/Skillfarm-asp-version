using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class insert_works : System.Web.UI.Page
    {
        private int randd;
        protected void Page_Load(object sender, EventArgs e)
        {
            randd = 0;
            nav.Visible = false;
            DataClasses1DataContext db = new DataClasses1DataContext();
            var h = from i in db.users select i;
            foreach (var df in h)
            {
               
                user_id.Items.Add(Convert.ToString( df.id));
            }

            var q = from i in db.courses select i;
            foreach (var df in q)
            {

                course_id.Items.Add(Convert.ToString(df.id));
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            nav.Visible = false;
            try
            {
                int maxid = 0;


                DataClasses1DataContext db = new DataClasses1DataContext();
                if(db.works.Count()!=0)
                {  maxid = db.works.Max(x => x.id);}
                else
                {
                    maxid = 0;
                }
                work w = new work();
                w.id = maxid + 1;
                w.user_id = Convert.ToInt32( user_id.Value.ToString());
                w.course_id =Convert.ToInt32(course_id.Value.ToString());
                w.subject = subject.Value.ToString();
                w.detail = details.Value.ToString();
                w.status = status.Value.ToString();
                w.dead_time = Calendar1.SelectedDate;
                db.works.InsertOnSubmit(w);
                db.SubmitChanges();
                Response.Redirect(Request.RawUrl);
                

            }
            catch (Exception ex)
            {
                nav.Visible = true;
                alert.InnerText = e.ToString();
               
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}