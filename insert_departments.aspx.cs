using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class insert_departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl alg = (HtmlGenericControl)this.Master.FindControl("alert");
            alg.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataClasses1DataContext db = new DataClasses1DataContext();
                department dp = new department();
                var maxValue = db.departments.Max(x => x.id);
                dp.name = TextBox1.Text;
                dp.id = maxValue + 1;
                db.departments.InsertOnSubmit(dp);
                db.SubmitChanges();
                var h = from j in db.departments
                        select j;
                
                GridView1.DataSource = h;
              
             GridView1.DataBind();

                /////////////////// ;|
                foreach (var gh in h)
                {

                  
                   /* TableRow tr = new TableRow();
                  Table1.Rows.Add(tr);
                    TableCell tc = new TableCell();
                    tc.Text = gh.name.ToString();

                    TableCell tc2 = new TableCell();
                    Button bt = new Button();
                    

                    bt.Attributes.Add("runat", "server");
                    tc.Controls.Add(bt);
                    tr.Cells.Add(tc);
                    tr.Cells.Add(tc2);
                    form1.Controls.Add(Table1);*/
                }
                /////////////////////////////:< 
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = sender.ToString();
        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/mainmenu.aspx");
        }
    }
}