using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.Net;
using System.Net.Mail;
namespace CCIBusinesspartner
{
    public partial class EventManager : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        //List<string> dates = new List<string>();
        List<DateTime> dates = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {

            GetEventDates();
        }

        protected void RadCalendar1_DayRender(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
        {


            foreach (DateTime dt in dates)
            {
                if (e.Day.Date == dt)
                {
                    e.Cell.Style["background-color"] = "Red";
                }
            }


        }
        private void GetEventDates()
        {
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("select event_date from events", con))
                {

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                //dates.Add(rdr.ToString());
                                //dates.Ad-dated(rdr.GetDateTime());
                                DateTime dt = Convert.ToDateTime(rdr["event_date"]);
                                dates.Add(dt);
                            }
                        }
                    }
                }
            }

        }


        protected void RadCalendar1_SelectionChanged(object sender, Telerik.Web.UI.Calendar.SelectedDatesEventArgs e)
        {
            DataTable Dt = null;
            if (dates.Contains(RadCalendar1.SelectedDate))
            {
                string dts = RadCalendar1.SelectedDate.ToString("yyyy-MM-dd");

                using (var con = new MySqlConnection(connStr))
                {
                    con.Open();
                    using (var Adp = new MySqlDataAdapter("select e.event_id,e.event_name, e.event_date, b.account_name,c.contact_lastname as name  from business_partner_account b, events e, contacts c  where b.account_id = e.account_id and e.contact_id = c.contact_id and e.event_date='" + dts + "'", con))
                    {
                        Dt = new DataTable();
                        Adp.Fill(Dt);
                        con.Close();
                        //GridView1.DataSource = Dt;
                        //GridView1.DataBind();
                        RadGrid1.DataSource = Dt;
                        RadGrid1.DataBind();

                    }
                }
                Panel1.Visible = true;

            }
            else
            {
                Label1.Visible = true;
            }

        }
        protected void LnkRemind_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            // getting particular row link button
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //Getting last name of the particular row.
            string lastname = RadGrid1.DataKeys[gvrow.DataItemIndex]["name"].ToString();
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress("vinothinkumar@gmail.com");
            string emailaddress = "";

            using (var con = new MySqlConnection(connStr))
            {
               con.Open();
              using (MySqlCommand cmd = new MySqlCommand("select contact_email from contacts where lower(contact_lastname)='"+lastname+"'", con))
                {

                   using (MySqlDataReader rdr = cmd.ExecuteReader())
                   {
                        if (rdr.HasRows)
                       {
                          while (rdr.Read())
                           {
                                 emailaddress = Convert.ToString(rdr["contact_email"]);
                           }
                       }
                   }
               }
            }
            //recepient e-mail address
            //msg.To.Add(emailaddress);
            //string mailbody = "Hello, This is a reminder email regarding the event taking place at UNCC.The event is on 1/6/2015.Please do attend, Thanks And Regards UNCC Business Partners.";
            //msg.Body = mailbody;
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.Credentials = new NetworkCredential("vinothinkumar@gmail.com","MamaSm0kes","smtp.gmail.com");
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Send(msg);
            //msg = null;
            //Page.RegisterStartupScript("UserMsg", "<script>alert('Mail sent thank you...');if(alert){ window.location='EventManager.aspx';}</script>");
            SendEmail(emailaddress);

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("new event.aspx");
        }
        protected void Lnkedit_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string accountname = RadGrid1.DataKeys[gvrow.DataItemIndex]["account_name"].ToString();
            string eventdate = RadGrid1.DataKeys[gvrow.DataItemIndex]["event_date"].ToString();
            string eventid = RadGrid1.DataKeys[gvrow.DataItemIndex]["event_id"].ToString();
            Response.Redirect("EditEvent.aspx?accountname=" + accountname + "&eventdate=" + eventdate + "&eventid=" + eventid);
        }
        private void SendEmail(string address)
        {
            try
            {
                MailMessage mail = new MailMessage("vinothinkumar@gmail.com", address);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("vinothinkumar@gmail.com", "MamaSm0kes");
          
                mail.Subject = "this is a reminder email for upcoming event in UNCC.";
                mail.Body = "Hello Sir/Mam .. This email is to remind you about the upcoming event in UNCC .Awaitng yur presence . Thank you.";
                client.Send(mail);
                Page.RegisterStartupScript("UserMsg", "<script>alert('Mail sent thank you...');if(alert){ window.location='EventManager.aspx';}</script>");
            }
            catch (Exception)
            {

            }
        }
    }
}