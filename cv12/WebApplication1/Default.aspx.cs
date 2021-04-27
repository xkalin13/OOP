using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {

        ServiceReference1.Service1Client sluzba = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = sluzba.Spocti(decimal.Parse(TextBox1.Text), decimal.Parse(TextBox2.Text), DropDownList1.SelectedValue).ToString();
        }
    }
}