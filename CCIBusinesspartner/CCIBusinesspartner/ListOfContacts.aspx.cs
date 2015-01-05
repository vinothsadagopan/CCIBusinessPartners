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
    public partial class Contacts : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayRecord();
            }
        }
        public DataTable DisplayRecord()
        {
            DataTable Dt = null;


            using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                using (var Adp = new MySqlDataAdapter("select c.contact_id,c.contact_firstname,c.contact_lastname,c.contact_number,c.contact_email,b.account_name from business_partner_account b, contacts c where b.account_id=c.account_id", con))
                {
                    Dt = new DataTable();
                    Adp.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();


                }
            }
            return Dt;
        }
        protected void lnkedit_click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string contactid = GridView1.DataKeys[gvrow.DataItemIndex]["contact_id"].ToString();
            Response.Redirect("EditContact.aspx?contactid=" + contactid);
        }
    }
}