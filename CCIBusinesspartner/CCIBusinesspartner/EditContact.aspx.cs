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
    
    public partial class EditContact : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["contactid"] = Request.QueryString["contactid"].ToString();
                string contactid = Session["contactid"].ToString();
                string firstname = "";
                string lastname = "";
                string email = "";
                string contactno = "";
                string accountname = "";
                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("select c.contact_firstname,c.contact_lastname,c.contact_email,c.contact_number,b.account_name from contacts c, business_partner_account b where b.account_id = c.account_id and c.contact_id="+contactid, con))
                    {

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    firstname = rdr["contact_firstname"].ToString();
                                    lastname = rdr["contact_lastname"].ToString();
                                    email = rdr["contact_email"].ToString();
                                    contactno = rdr["contact_number"].ToString();
                                    accountname = rdr["account_name"].ToString();

                                }
                            }
                        }
                    }
                }
                Txtfirstname.Text = firstname;
                Txtlastname.Text = lastname;
                Txtemail.Text = email;
                Txtcontactno.Text = contactno;
                Lblaccountname.Text = accountname;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string contactid = Session["contactid"].ToString();
            using (var con = new MySqlConnection(connStr))
            {
                //string eventid = Session["eventid"].ToString();
                con.Open();
                string query = "update contacts set contact_firstname='"+Txtfirstname.Text+"', contact_lastname='"+Txtlastname.Text+"', contact_number='"+Txtcontactno.Text+"',contact_email= '"+Txtemail.Text+"' where contact_id=" + contactid;
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Updated Successfully";
                Label1.Visible = true;
                Response.Redirect("ListOfContacts.aspx");
            }
        }
         protected void Button2_Click(object sender, EventArgs e)
        {
            string contactid = Session["contactid"].ToString();
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                string query = "delete from contacts where contact_id=" + contactid;
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Updated Successfully";
                Label1.Visible = true;
                Response.Redirect("ListOfContacts.aspx");
            }
        }

         protected void Button3_Click(object sender, EventArgs e)
         {
             Response.Redirect("ListOfContacts.aspx");
         }

    }
}