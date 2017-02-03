using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class delete_department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl alg = (HtmlGenericControl)this.Master.FindControl("alert");
            alg.Visible = false;

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var cc = from c in db.departments
                         where c.id == Convert.ToInt32(TextBox1.Text.ToString())
                         select c;
                department bn = cc.First();
                db.departments.DeleteOnSubmit(bn);
                db.SubmitChanges();
                Response.Redirect("/delete_department.aspx");

            }
            catch(Exception ex)
            {
                HtmlGenericControl er = (HtmlGenericControl)this.Master.FindControl("error");
                HtmlGenericControl al = (HtmlGenericControl)this.Master.FindControl("alert");
                al.Visible = true;
                er.Visible = true;
                er.InnerText = ex.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}