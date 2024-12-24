using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;
using BusinessLogic;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class VisitorRegistration : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        private SqlConnection ConNew = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        Fetch objFetch = new Fetch();
        General Objgeneral = new General();
        comFunctions cmf = new comFunctions();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Value=="")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter your Name');", true);
                    return;
                }
                if (txtEmail.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter your email');", true);
                    return;
                }
                if (txtCountry.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter your Country');", true);
                    return;
                }
                if (txtMobile.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter your Mobile Number');", true);
                    return;
                }
                if (txtMobile.Value.Length < 10)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter 10 digit Mobile Number');", true);
                    return;
                }
                string Name = txtName.Value;
                string City = "";
                string MobileNo = txtMobile.Value;
                string Email = txtEmail.Value;
                string Country = txtCountry.Value;
                string Organization = txtCity.Value;
                string Products = txtProduct.Value;
                string Suggestions = txtSuggestion.Value;
                string TypeofReg = "AIF";

                string Validstatus = InsertVisitorDetails(Name, City, MobileNo, Email, Country, Organization, Products, Suggestions, TypeofReg);
                if (Validstatus != null && Validstatus != "" && Validstatus != "2")
                {

                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Details Saved Successfully);", true);
                    txtName.Value = "";
                    txtCity.Value = "";
                    txtMobile.Value = "";
                    txtEmail.Value = "";
                    txtCountry.Value = "";
                    txtCity.Value = "";
                    txtProduct.Value = "";
                    txtSuggestion.Value = "";
                    divMain.Visible = false;
                    divFooter.InnerText = "You are successfully registered. Your Registration No. is  " + Validstatus + ".";
                    divFooter.Visible = true;
                }
                else
                {
                    if (Validstatus == "2")
                    {
                        divFooter.InnerText = "Mobile Number already Exists";
                        divFooter.Style.Add("background-color", "red");
                        divFooter.Visible = true;
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Failed to Submit');", true);
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
            }
        }
        public string InsertVisitorDetails(string Name, string City, string MobileNo, string Email, string Country, string Organization,
            string Products, string Suggestions, string TypeofReg)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_VISITOR_DETAILS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Name", Name);
                com.Parameters.AddWithValue("@City", City);
                com.Parameters.AddWithValue("@MobileNo", MobileNo);
                com.Parameters.AddWithValue("@Email", Email);
                com.Parameters.AddWithValue("@Country", Country);
                com.Parameters.AddWithValue("@Organization", Organization);
                com.Parameters.AddWithValue("@Products", Products);
                com.Parameters.AddWithValue("@Suggestions", Suggestions);
                com.Parameters.AddWithValue("@TypeofReg", TypeofReg);
                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
    }
}