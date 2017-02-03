using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class insert_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var maxValue = db.users.Max(x => x.id);
                user us = new user();
               us.id = maxValue + 1;
                us.name = name.Text.ToString();
                us.email = email.Text.ToString();
                us.password = pass.Text.ToString();
                db.users.InsertOnSubmit(us);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();

            }



        }

    }
}