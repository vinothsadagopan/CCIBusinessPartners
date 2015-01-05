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
    }
}