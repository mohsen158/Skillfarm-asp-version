using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class acceptances : System.Web.UI.Page
    {
        public string  workid;
        public int randd;
        protected void Page_Load(object sender, EventArgs e)
        {
            randd = 0;

            string id = Request.QueryString["id"];
            workid = id;
            DataClasses1DataContext db = new DataClasses1DataContext();
            var f = from i in db.acceptances
                join y in db.users on i.user_id equals y.id
                where i.work_id == Convert.ToInt32(id)
                    select new
                    {
                        i,y
                    }
            ;

            acceptancesList.DataSource = f;
            acceptancesList.DataBind();

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName.Equals("Delete") == true)
                {
                    var cc = from c in db.acceptances
                             where c.id == id
                             select c;
                    acceptance bn = cc.First();
                  

                    
                    db.acceptances.DeleteOnSubmit(bn);
                    db.SubmitChanges();
                    Response.Redirect("acceptances.aspx?id=" + workid);
                }
                
            }
            catch (Exception ex)
            {

              

            }
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               
              //  user u = (user) e.Item.DataItem;
                var sd = e.Item.DataItem;
                dynamic gg = e.Item.DataItem as dynamic;

                user us =(user) gg.y;
                Repeater childRepeater = (Repeater) e.Item.FindControl("ChildRepeater");
                DataClasses1DataContext db = new DataClasses1DataContext();
                var f = from i in db.course_users
                        join y in db.courses on i.course_id equals y.id
                        where i.user_id == us.id
                        select y
                    ;
                childRepeater.DataSource = f;
                childRepeater.DataBind();
            }
        }

        protected void course_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            DataClasses1DataContext db = new DataClasses1DataContext();
            var worksofCourse = from i in db.works
                where i.course_id == id
                select i;
            Response.Redirect("worksofuser.aspx?courseid="+id);

        }
    }
}