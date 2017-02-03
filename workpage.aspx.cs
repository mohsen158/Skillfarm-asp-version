using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public work mywork;
        public int randd;
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl alg = (HtmlGenericControl)this.Master.FindControl("alert");
            alg.Visible = false;
            randd = 0;
            try
            {
                 DataClasses1DataContext db = new DataClasses1DataContext();
                string id = Request.QueryString["workid"];
                var works = from i in db.works
                    where
                    i.id == Convert.ToInt32(id)
                    select i;
                var a = works.First();
                mywork = a;
                subject.InnerText = a.subject.ToString();
                detail.InnerText = a.detail.ToString();
                //Label1.Text = a.subject.ToString();
                
                int ii = a.dead_time.ToUniversalTime().Subtract(DateTime.Now).Days;
                time.InnerText = Convert.ToString(ii);
                Random rnd = new Random();
                int imgrand = rnd.Next(1, 9); // creates a number between 1 and 12


                var ap = mywork.applicants;
                var all = from i in db.applicants
                          join x in db.users on i.user_id equals x.id
                          where i.work_id == mywork.id
                          select x;

                Repeater1.DataSource = all;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {

                HtmlGenericControl er = (HtmlGenericControl)this.Master.FindControl("error");
                HtmlGenericControl al = (HtmlGenericControl)this.Master.FindControl("alert");
                al.Visible = true;
                er.Visible = true;
                er.InnerText = ex.Message;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                if (e.CommandName.Equals("acceptreq") == true)
                {
                    int maxValue;
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    acceptance n = new acceptance();
                    if (db.acceptances.Count() > 0)
                    {
                         maxValue = db.acceptances.Max(x => x.id);
                    }
                    else
                    {
                         maxValue = 0;
                    }
                    n.user_id = id;
                    n.work_id = mywork.id;
                    n.id = maxValue+1;
                    n.dead_time = DateTime.Now;
                    n.detail = ":D";
                    n.cost = 100;
                    var hj = from i in db.acceptances where i.user_id == n.user_id && i.work_id==n.work_id select i;
                    if(hj.Count()>0)
                    {
                        Exception c = new Exception("this user alredy accepted");
                        throw c;
                    }
                    db.acceptances.InsertOnSubmit(n);
                    db.SubmitChanges();
                }
                else if(e.CommandName.Equals("Delete") == true)
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    var requestdelete = from i in db.applicants
                        where i.user_id == id
                        select i;
                    applicant ap = requestdelete.First();
                    db.applicants.DeleteOnSubmit(ap);
                    db.SubmitChanges();

                }
            }
            catch (Exception ex)
            {
                HtmlGenericControl er = (HtmlGenericControl)this.Master.FindControl("error");
                HtmlGenericControl al = (HtmlGenericControl)this.Master.FindControl("alert");
                al.Visible = true;
                er.Visible = true;
                er.InnerText = ex.Message;
            }
        }

      

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                acceptance ac = new acceptance();
                ac.user_id = Convert.ToInt32(TextBox1.ToString());
                ac.user_id = Convert.ToInt32(usid.Value.ToString());
                ac.work_id = mywork.id;
                ac.detail = details.Value.ToString();
                ac.dead_time = Convert.ToDateTime(date.Value.ToString());
                DataClasses1DataContext db = new DataClasses1DataContext();
                var hj = from i in db.acceptances where i.user_id == ac.user_id && i.work_id == ac.work_id select i;
                if (hj.Count() > 0)
                {
                    Exception c = new Exception("this user alredy accepted");
                    throw c;
                }
                var maxValue = db.acceptances.Max(x => x.id);
                ac.id = maxValue + 1;
                db.acceptances.InsertOnSubmit(ac);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                HtmlGenericControl er = (HtmlGenericControl)this.Master.FindControl("error");
                HtmlGenericControl al = (HtmlGenericControl)this.Master.FindControl("alert");
                al.Visible = true;
                er.Visible = true;
                er.InnerText = ex.Message;
            }
        }

        protected void Acceptances(object sender, EventArgs e)
        {
            Response.Redirect("acceptances.aspx?id="+mywork.id);
        }

        protected void addrequest(object sender, EventArgs e)
        {
            Response.Redirect("request.aspx?id=" + mywork.id);
        }
    }
}