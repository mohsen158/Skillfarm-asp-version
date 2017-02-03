using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();
        public IQueryable<work> works;
        protected void Page_Load(object sender, EventArgs e)
        {
            alert.Visible = false;

            string id = Request.QueryString["courseid"];
            if (Request.QueryString.Count > 0)
            {
                PropertyInfo isreadonly =
  typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
  "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("courseid");
                Request.QueryString.Remove("courseid");
                
            }
            if (id != null)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var worksofCourse = from i in db.works
                    where i.course_id == Convert.ToInt32(id) && i.Approve==1
                    select i;
                Repeater1.DataSource = worksofCourse;
                Repeater1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var h = from i in db.works where i.Approve==1
                        select i;
                works = h;
                Repeater1.DataSource = h;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                error.Visible = true;
                error.InnerText = ex.Message;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            { DataClasses1DataContext db = new DataClasses1DataContext();
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName.Equals("Delete")==true)
                    {

                
               
                var cc = from c in db.works
                         where c.id == id
                         select c;
                work bn = cc.First();
                var del = from u in db.acceptances
                          where u.work_id == id
                          select u;
                foreach (var cx in del)
                {
                    db.acceptances.DeleteOnSubmit(cx);
                }


                var del2 = from u in db.applicants
                           where u.work_id == id
                           select u;
                foreach (var cx in del2)
                {
                    db.applicants.DeleteOnSubmit(cx);
                }


                db.SubmitChanges();
                db.works.DeleteOnSubmit(bn);
                db.SubmitChanges();
                Response.Redirect("/WebForm1.aspx");
                }
             else if(e.CommandName.Equals("subject")==true)
                {
                    var cc = from c in db.works
                             where c.id == id
                             select c;
                    work bn = cc.First();

                    
                    Response.Redirect("/workpage.aspx?workid="+bn.id);
                }
            }
            catch (Exception ex)
            {

                alert.Visible = true;
                error.Visible = true;
                error.InnerText = ex.Message;

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var h = from i in db.works where i.user_id == Convert.ToInt32(inputtext.Value.ToString()) select i;
                Repeater1.DataSource = h;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                error.Visible = true;
                error.InnerText = ex.Message;

            }
        }
    }
}