using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Telerik.Web.UI;

namespace CCIBusinesspartner
{
    public partial class Reports : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                displayaccountsgrid();
               displayeventsgrid();
               displaycontactsgrid();
            }
        }
        public void displayaccountsgrid()
        {
            DataTable Dt = null;
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (var Adp = new MySqlDataAdapter("select * from business_partner_account", con))
                {
                    Dt = new DataTable();
                    Adp.Fill(Dt);
                    //GridView1.DataSource = Dt;
                    //GridView1.DataBind();
                    RadGrid1.AutoGenerateColumns = true;
                    RadGrid1.DataSource = Dt;
                    //DefineRadGridColumns();
                    RadGrid1.DataBind();

                }
            }

        }
        public void displayeventsgrid()
        {
            DataTable Dt = null;
            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (var Adp = new MySqlDataAdapter("select e.event_id,e.event_name, e.event_date, b.account_name,c.contact_lastname as name  from business_partner_account b, events e, contacts c  where b.account_id = e.account_id and e.contact_id = c.contact_id ", con))
                {
                    Dt = new DataTable();
                    Adp.Fill(Dt);
                    con.Close();
                    //GridView1.DataSource = Dt;
                    //GridView1.DataBind();
                    RadGrid2.AutoGenerateColumns = true;
                    RadGrid2.DataSource = Dt;
                    RadGrid2.DataBind();

                }
            }
        }
        public void displaycontactsgrid()
        {
            DataTable Dt = null;


            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (var Adp = new MySqlDataAdapter("select c.contact_id,c.contact_firstname,c.contact_lastname,c.contact_number,c.contact_email,b.account_name from business_partner_account b, contacts c where b.account_id=c.account_id", con))
                {
                    Dt = new DataTable();
                    Adp.Fill(Dt);
                    RadGrid3.DataSource = Dt;
                    RadGrid3.DataBind();


                }
            }
        }
      
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            RadGrid1.MasterTableView.ExportToPdf();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            RadGrid2.MasterTableView.ExportToPdf();
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            RadGrid3.MasterTableView.ExportToPdf();
        }

    }
}