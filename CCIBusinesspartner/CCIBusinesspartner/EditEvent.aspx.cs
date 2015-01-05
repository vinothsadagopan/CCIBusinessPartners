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
    public partial class EditEvent : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
           
        {
            if (!IsPostBack)

        {
            Label1.Visible = false;
            string accountname = Request.QueryString["accountname"].ToString();
            string eventdatetime;
            eventdatetime = Request.QueryString["eventdate"].ToString();
            DateTime dt = Convert.ToDateTime(eventdatetime);
            string eventdate = dt.ToString("yyyy-MM-dd");
             Session ["eventid"] = Request.QueryString["eventid"].ToString();
            string eventname = "";
            string eventtime = "";
            string contactid = "";
            string contactname = "";
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("select e.event_name, e.event_time,e.contact_id from events e, business_partner_account b where b.account_id = e.account_id and e.event_date ='" + eventdate + "'and b.account_id=(select account_id from business_partner_account where lower(account_name)='" + accountname + "');", con))
                {

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                eventname = rdr["event_name"].ToString();
                                eventtime = rdr["event_time"].ToString();
                                contactid = rdr["contact_id"].ToString();

                            }
                        }
                    }
                }
                using (MySqlCommand cmd1 = new MySqlCommand("select contact_lastname from contacts where contact_id='"+contactid+"'", con))
                {
                    using (MySqlDataReader rdr1 = cmd1.ExecuteReader())
                    {
                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                contactname = rdr1["contact_lastname"].ToString();

                            }
                        }
                    }
                }
            }
            Txteventname.Text = eventname;
            Txteventdate.Text = eventdate;
            Txttimings.Text = eventtime;
            LblContactPerson.Text = contactname;
            Lablcompany.Text = accountname;
                       

        }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var con = new MySqlConnection(connStr))
            {
                string eventid = Session["eventid"].ToString();
                con.Open();
             string query = "update events set event_name='" + Txteventname.Text + "',event_date='" + Txteventdate.Text + "', event_time='" + Txttimings.Text + "' where event_id="+eventid;
               MySqlCommand cmd = new MySqlCommand(query, con);
               cmd.ExecuteNonQuery();
               con.Close();
              Label1.Text = "Updated Successfully";
               Label1.Visible = true;
               Response.Redirect("EventManager.aspx");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (var con = new MySqlConnection(connStr))
            {
                string eventid = Session["eventid"].ToString();
                con.Open();
                string query = "delete from events where event_id =" + eventid;
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
               // Label1.Text = "Updated Successfully";
               // Label1.Visible = true;
                Response.Redirect("EventManager.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventManager.aspx");
        }

    }
}