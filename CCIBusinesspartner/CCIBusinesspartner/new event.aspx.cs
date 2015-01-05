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
    public partial class new_event : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindcompanydropdown();
                //bindcontactsdropdown();

            }

        }
        public void bindcompanydropdown()
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
             string value = DropDownList1.SelectedValue.ToString();
             DataTable Dt = null;
             {
                 using (var con = new MySqlConnection(connStr))
                 {
                     con.Open();
                     using (var Adp = new MySqlDataAdapter("select contact_lastname from contacts where account_id = (select account_id from business_partner_account where lower(account_name) ='" + value + "')", con))
                     {
                         Dt = new DataTable();
                         Adp.Fill(Dt);
                         DropDownList2.DataSource = Dt;
                         DropDownList2.DataBind();
                         DropDownList2.DataTextField = "contact_lastname";
                         DropDownList2.DataValueField = "contact_lastname";
                         DropDownList2.DataBind();


                     }
                 }

             }

             
        }
        public string getcompanyid(string compnayname)
        {
            string companyid ="";
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("select account_id from business_partner_account where lower(account_name) = '"+compnayname+"'", con))
                {

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                companyid = rdr["account_id"].ToString();
                            }
                        }
                    }
                }
            }
            return companyid;

        }
        protected string getcontactid(string contactname)
        {
            string contactid = "";
            
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("select contact_id from contacts where contact_lastname= '" + contactname + "'", con))
                {

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                contactid = rdr["contact_id"].ToString();
                            }
                        }
                    }
                }
            }
            return contactid;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string eventname = TextBox1.Text.ToString();
            string eventdate = TextBox2.Text.ToString();
            string eventtime = DropDownList3.SelectedValue.ToString();
            string companyid = getcompanyid(DropDownList1.SelectedValue.ToString());
            string contactid = getcontactid(DropDownList2.SelectedValue.ToString());
             using (var con = new MySqlConnection(connStr))
             {
                 con.Open();
                 string query = "insert into events(event_name,event_date,event_time,account_id,contact_id) values ('" + eventname + "','" + eventdate + "','" + eventtime + "','" + companyid + "','" + contactid + "')";
                 MySqlCommand cmd = new MySqlCommand(query,con);
                 cmd.ExecuteNonQuery();
                 con.Close();
                 Label1.Text = "Inserted Successfully";
                 Response.Redirect("EventManager.aspx");
             }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventManager.aspx");
        }

        
    }
    
}