using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlContinents.AppendDataBoundItems = true;
                String strConnString = ConfigurationManager.ConnectionStrings["QBDataConnectionString"].ConnectionString;
                String strQuery = "select distinct billaddress_addr1 from Invoices order by 1";
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlContinents.DataSource = cmd.ExecuteReader();
                    ddlContinents.DataTextField = "billaddress_addr1";
                    ddlContinents.DataValueField = "billaddress_addr1";
                    ddlContinents.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        protected void customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem("--Select Invoice--", ""));
            

            ddlCountry.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
                .ConnectionStrings["QBDataConnectionString"].ConnectionString;
            String strQuery = "select distinct refnumber from Invoices where billaddress_addr1=@ContinentID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@ContinentID",
                ddlContinents.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlCountry.DataSource = cmd.ExecuteReader();
                ddlCountry.DataTextField = "refnumber";
                ddlCountry.DataValueField = "refnumber";
                ddlCountry.DataBind();
                if (ddlCountry.Items.Count > 1)
                {
                    ddlCountry.Enabled = true;
                }
                else
                {
                    ddlCountry.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblResults.Text = "You Selected " +
                              ddlContinents.SelectedItem.Text + " -----> " +
                              ddlCountry.SelectedItem.Text;
            String strConnString = ConfigurationManager
                .ConnectionStrings["QBDataConnectionString"].ConnectionString;
            String strQuery = "SELECT Item, Description, Amount, Tax FROM InvoiceItems WHERE RefNumber=@InvoiceID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@InvoiceID",
                ddlCountry.SelectedItem.Text);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();
            SqlCommand command2 = con.CreateCommand();

            command2.CommandText = "SELECT timecreated, refnumber, BillAddress_Addr1, BillAddress_Addr2, BillAddress_City, BillAddress_State, BillAddress_PostalCode, IsPaid, SalesTaxPercentage, SalesTaxTotal, Subtotal, (cast (subtotal as float)+cast (salestaxpercentage as float) ) as Total FROM Invoices WHERE RefNumber=@InvoiceID";
            command2.Parameters.AddWithValue("@InvoiceID", ddlCountry.SelectedItem.Text);
            reader = command2.ExecuteReader();
            
            while(reader.Read())
            {
                lblResults.Text = "<strong>Invoice " + reader["refnumber"] + "</strong><br /><strong>Date:</strong> " + reader["timecreated"]+"<br /><br /><strong>Bill To:</strong><br />"+reader["BillAddress_Addr1"]+"<br />"+reader["BillAddress_Addr2"]+"<br />"+reader["BillAddress_City"]+ ", " +reader["BillAddress_State"]+ " "+reader["BillAddress_PostalCode"];
                if (reader["IsPaid"].ToString().ToLower() == "true") { lblResults.Text += "<br /><br /><strong>PAID</strong><br />"; }
                lblFooter.Text = "<strong>Sales Tax (%):</strong>" + reader["SalesTaxPercentage"] + "<br /><strong>Sales Tax:</strong>" + reader["SalesTaxTotal"] + "<br /><br /><strong>Sub Total:</strong>"+reader["Subtotal"]+"<br /><br /><strong>Total: </strong>"+reader["Total"];
            }
            reader.Close();

            con.Close();
            con.Dispose();
            

            
        }
        
    }
}