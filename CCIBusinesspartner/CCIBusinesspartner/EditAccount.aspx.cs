using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CCIBusinesspartner
{
    public partial class EditAccount : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["accountid"] = Request.QueryString["accountid"].ToString();
                string accountid = Session["accountid"].ToString();
                string accountname = "";
                string city = "";
                string domain = "";
                string technology = "";
                string description = "";
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("select account_name, city,domain,technology,description from business_partner_account where account_id=" + accountid, con))
                    {

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    accountname = rdr["account_name"].ToString();
                                    city = rdr["city"].ToString();
                                    domain = rdr["domain"].ToString();
                                    technology = rdr["technology"].ToString();
                                    description = rdr["description"].ToString();
                                }
                            }
                        }
                    }

                }
                Txtaccountname.Text = accountname;
                Txtcity.Text = city;
                Txtdomain.Text = domain;
                Txttechnology.Text = technology;
                TextBox1.Text = description;

            }

        }

        protected void Button1_Click(object sender, EventArgs e)

        {
            string accountid = Session["accountid"].ToString();
            using (var con = new MySqlConnection(connStr))
            {
                //string eventid = Session["eventid"].ToString();
                con.Open();
                string query = "update business_partner_account set account_name= '"+Txtaccountname.Text+"', city ='"+Txtcity.Text+"' , domain ='"+Txtdomain.Text+"' , technology ='"+Txttechnology.Text+"', description='"+ TextBox1.Text+"'  where account_id="+accountid;
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Updated Successfully";
                Label1.Visible = true;
                Response.Redirect("ListAccount.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (var con = new MySqlConnection(connStr))
            {
                string accountid = Session["accountid"].ToString();
                con.Open();
                string query = "delete from business_partner_account where account_id =" + accountid;
                MySqlCommand cmd1 = new MySqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                con.Close();
                // Label1.Text = "Updated Successfully";
                // Label1.Visible = true;
                Response.Redirect("ListAccount.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAccount.aspx");
        }

    }
}