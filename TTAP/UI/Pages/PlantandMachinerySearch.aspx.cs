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
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace TTAP.UI.Pages
{
    public partial class PlantandMachinerySearch : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetPlantMachinary(string AppNo)
        {
            List<Incentive> listIncentive = new List<Incentive>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_PLANTANDMACHINERY_HTML", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@ApplicationNo",
                    Value = AppNo
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Incentive incentive = new Incentive();
                    incentive.PMId = rdr["PMId"].ToString();
                    incentive.IncentiveId = rdr["IncentiveId"].ToString();
                    incentive.MachineName = rdr["MachineName"].ToString();
                    incentive.VendorName = rdr["VendorName"].ToString();
                    incentive.TypeofMachine = rdr["TypeofMachine"].ToString();
                    incentive.CustomCountry = rdr["CustomCountry"].ToString();
                    incentive.CustomPaid = rdr["CustomPaid"].ToString();
                    incentive.ManufacturerName = rdr["ManufacturerName"].ToString();
                    incentive.InvoiceNo = rdr["InvoiceNo"].ToString();
                    incentive.MahineLandingDate = rdr["MahineLandingDate"].ToString();
                    incentive.VaivleNo = rdr["VaivleNo"].ToString();
                    incentive.VaivleDate = rdr["VaivleDate"].ToString();
                    incentive.IntiationDate = rdr["IntiationDate"].ToString();
                    incentive.MachineCost = rdr["MachineCost"].ToString();
                    incentive.Eligibility = rdr["Eligibility"].ToString();
                    incentive.InstalledMachinery = rdr["InstalledMachinery"].ToString();
                    incentive.ForeignMachineCost = rdr["ForeignMachineCost"].ToString();
                    incentive.InstalledMachineryText = rdr["InstalledMachineryText"].ToString();
                    incentive.Importduty = rdr["Importduty"].ToString();
                    incentive.Portcharges = rdr["Portcharges"].ToString();
                    incentive.Statutorytaxes = rdr["Statutorytaxes"].ToString();
                    incentive.ForeignCurrency = rdr["ForeignCurrency"].ToString();
                    incentive.MachinaryPartstext = rdr["MachinaryPartstext"].ToString();
                    incentive.InstalledMachinerytypetext = rdr["InstalledMachinerytypetext"].ToString();
                    incentive.InvoiceDate = rdr["InvoiceDate"].ToString();
                    incentive.FilePathMerge2 = rdr["FilePathMerge2"].ToString();
                    incentive.ClassificationMachineryText = rdr["ClassificationMachineryText"].ToString();
                    incentive.Phase = rdr["Phase"].ToString();
                    incentive.ActualMachineCost = rdr["ActualMachineCost"].ToString();
                    incentive.FreightCharges = rdr["FreightCharges"].ToString();
                    incentive.TransportCharges = rdr["TransportCharges"].ToString();
                    incentive.Cgst = rdr["Cgst"].ToString();
                    incentive.Sgst = rdr["Sgst"].ToString();
                    incentive.Igst = rdr["Igst"].ToString();
                    incentive.UnitName = rdr["UnitName"].ToString();

                    listIncentive.Add(incentive);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            return js.Serialize(listIncentive);
        }
        public class Incentive
        {
            public string UnitName { get; set; }
            public string IncentiveName { get; set; }
            public string ClaimPeriod { get; set; }
            public string ApplicationNumber { get; set; }
            public string IncentiveId { get; set; }
            public string NoofClaims { get; set; }
            public string TotalAmountClaimed { get; set; }


            public string PMId { get; set; }
            
            public string MachineName { get; set; }
            public string VendorName { get; set; }
            public string TypeofMachine { get; set; }
            public string CustomCountry { get; set; }
            public string CustomPaid { get; set; }
            public string ManufacturerName { get; set; }
            public string InvoiceNo { get; set; }
            public string MahineLandingDate { get; set; }
            public string VaivleNo { get; set; }
            public string VaivleDate { get; set; }
            public string IntiationDate { get; set; }
            public string MachineCost { get; set; }
            public string Eligibility { get; set; }
            public string InstalledMachinery { get; set; }
            public string ForeignMachineCost { get; set; }
            public string InstalledMachineryText { get; set; }
            public string Importduty { get; set; }
            public string Portcharges { get; set; }
            public string Statutorytaxes { get; set; }
            public string ForeignCurrency { get; set; }
            public string MachinaryPartstext { get; set; }
            public string InstalledMachinerytypetext { get; set; }
            public string InvoiceDate { get; set; }
            public string FilePathMerge2 { get; set; }
            public string ClassificationMachineryText { get; set; }
            public string MachineAvailability { get; set; }
            public string MachineAvailabilityText { get; set; }
            public string Phase { get; set; }
            public string ActualMachineCost { get; set; }
            public string FreightCharges { get; set; } 
            public string TransportCharges { get; set; }
            public string Cgst { get; set; }
            public string Sgst { get; set; }
            public string Igst { get; set; }
        }
    }
}