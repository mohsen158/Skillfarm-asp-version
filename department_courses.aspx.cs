using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class department_courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl alg = (HtmlGenericControl)this.Master.FindControl("alert");
            alg.Visible = false;
            DataClasses1DataContext db = new DataClasses1DataContext();
            var deps = from i in db.departments
                       select i;
            GridView1.DataSource = deps;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var cc = from i in db.departments
                     where i.id == Convert.ToInt32(TextBox1.Text.ToString())
                     select i;
            try
            {
                if (cc.Count() != 0)
                {
                   GridView1.DataSource= cc.First().courses;
                    GridView1.DataBind();
                }
                else
                {
                    Exception ex = new Exception("this id does not exist");
                    throw ex;
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
    }
}