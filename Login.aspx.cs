using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            var loginuser = from i in db.users
                            where i.name == name.Value.ToString() && i.password == password.Value.ToString()
                            select i;
            if (loginuser.Count()>0)
            {
                user us = loginuser.First();
                Session["user_id"] = us.id;
                Response.Redirect("worksofuser.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username or password is wrong')", true);
            }
        }
    }
}