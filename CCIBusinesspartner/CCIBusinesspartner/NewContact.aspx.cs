using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace CCIBusinesspartner
{
    public partial class NewContact : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddropdown();
            }
        }
        protected void binddropdown()
        {
            DataTable Dt = null;
            {
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    using (var Adp = new MySqlDataAdapter("select account_name from business_partner_account", con))
                    {
                        Dt = new DataTable();
                        Adp.Fill(Dt);
                        DropDownList1.DataSource = Dt;
                        DropDownList1.DataBind();
                        DropDownList1.DataTextField = "account_name";
                        DropDownList1.DataValueField = "account_name";
                        DropDownList1.DataBind();


                    }
                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            new_event ne = new new_event();
            string firstname = TextBox1.Text;
            string lastname = TextBox2.Text;
            string contactno = TextBox3.Text;
            string email = TextBox4.Text;
            string companyid = ne.getcompanyid(DropDownList1.Text.ToString());
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                string query = "insert into contacts(contact_firstname,contact_lastname,contact_number,contact_email,account_id)values ('" + firstname + "','" + lastname + "','" + contactno + "','" + email + "','" + companyid+"')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Inserted Successfully";
                Response.Redirect("ListOfContacts.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListOfContacts.aspx");
        }
        

    }
}