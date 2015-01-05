using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using Telerik.Web.UI;

namespace CCIBusinesspartner
{
    public partial class ListAccount : System.Web.UI.Page
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
                using (var Adp = new MySqlDataAdapter("select * from business_partner_account", con))
                {
                    Dt = new DataTable();
                    Adp.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                    

                }
            }
            return Dt;
        }
        protected void Lnkedit_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string accountid = GridView1.DataKeys[gvrow.DataItemIndex]["account_id"].ToString();
            Response.Redirect("EditAccount.aspx?accountid=" + accountid);
        }

        
    }
}