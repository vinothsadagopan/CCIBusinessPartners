using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace CCIBusinesspartner
{
    public partial class About : System.Web.UI.Page
        {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string accountname = TextBox1.Text.ToString();
            string city = TextBox2.Text.ToString();
            string domain = DropDownList1.SelectedValue.ToString();
            string technology = DropDownList2.SelectedValue.ToString();
            string datecreated = DateTime.Now.ToString("yyyy-MM-dd");
            string description = TxtDescription.Text;
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                string query = "insert into business_partner_account(account_name,date_created,city,domain,technology,description) values ('" + accountname + "','" + datecreated + "','" + city + "','" + domain + "','" + technology + "','" + description + "')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Visible = true;
                Label1.Text = "Inserted Successfully";
                Response.Redirect("ListAccount.aspx");
            }
          
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}
