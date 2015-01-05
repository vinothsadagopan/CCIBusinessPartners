using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Telerik.Web.UI;

namespace CCIBusinesspartner
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               // Panel1.Visible = false;
                displaycount();
                DisplayRecord();
                Panel1.Visible = true;
            }

        }
        public void displaycount()

        {
             using (var con = new MySqlConnection(connStr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select count(account_id) from business_partner_account",con) ; 
                cmd.CommandType= System.Data.CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                String value= rdr[0].ToString();

                Label1.Text = value;
                con.Close();

                
            }
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DisplayRecord();
            Panel1.Visible = true;

        }
        protected DataTable DisplayRecord()
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
                    RadGrid1.AutoGenerateColumns = false;
                    RadGrid1.DataSource = Dt;
                    DefineRadGridColumns();
                    RadGrid1.DataBind();

                }
            }
            return Dt;
        }

        private void DefineRadGridColumns()
        {
            try
            {
           

                GridBoundColumn idCol = new GridBoundColumn();
                idCol.HeaderText = "Id";
                idCol.DataField = "account_id";
                RadGrid1.Columns.Add(idCol);


                GridBoundColumn nameCol = new GridBoundColumn();
                nameCol.HeaderText = "Name";
                nameCol.DataField = "account_name";
                RadGrid1.Columns.Add(nameCol);


                 //account_name	date_created
                GridBoundColumn descol = new GridBoundColumn();
                descol.HeaderText = "Description";
                descol.DataField = "description";
                RadGrid1.Columns.Add(descol);
               
            }
            catch(Exception)
            {

            }
        }
        
    }
}
