using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Configuration;
using DataAccessLayer;

namespace TTAP.Classfiles
{
    public class General
    {
        private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        //Globavaribles gbp = new Globavaribles();

        DB.DB con = new DB.DB();
        //DataSet ds;
        //DataTable dt;
        //SqlDataAdapter myDataAdapter;

        comFunctions cmf = new comFunctions();

        public DataSet GetIALAParks_Incentives(int IALACode, int DistrictCd)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_IALA_INDUSTRIALPARKS_INCENTIVES", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (IALACode != 0)
                    da.SelectCommand.Parameters.AddWithValue("@IALA_Cd", IALACode);
                if (DistrictCd != 0)
                    da.SelectCommand.Parameters.AddWithValue("@DISTRICTCD", DistrictCd);

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GenericFillDs(string procedurename, SqlParameter[] sp)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(procedurename, con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddRange(sp);

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

        }

        public int deleteGroupSavingData1(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deletemanufacturedata";

            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;


            con.OpenConnection();
            cmd.Connection = con.GetConnection;

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();

            }
        }

        public DataSet getStates()
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("getstates", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetDistrictsbystate(string intstateid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("getDistrictsbystate", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (intstateid.Trim() == "" || intstateid.Trim() == null || intstateid.Trim() == "--Select--")
                    da.SelectCommand.Parameters.Add("@intstateid", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@intstateid", SqlDbType.VarChar).Value = intstateid.ToString();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }


        public DataSet GetDistrictsWithoutHYD()
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("GetDistrictsHYD", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetMandals(string District)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("GetMandals", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (District.Trim() == "" || District.Trim() == null)
                    da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = District.ToString();

                da.Fill(ds);
                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetVillages(string Mandal)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("GetVillages", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "--Select--")
                    da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = Mandal.ToString();

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetUnderLimitsOfVillage(string intVillageid)
        {

            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("[GET_UNDERLIMITSOF_VILLAGE]", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;



                if (intVillageid.Trim().ToString() == "" || intVillageid.ToString().Trim() == null || intVillageid.ToString().Trim() == "--Select--")
                    da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    da.SelectCommand.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = intVillageid.Trim();
                da.Fill(ds);
                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet getUdyogAadharType()
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_UDYOG_AADHAAR_TYPE", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }


        public DataSet GetIncentivesdata(string userid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("[USP_GET_INCENTIVES_DATA]", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (userid != "" && userid != null)
                    da.SelectCommand.Parameters.Add("@user_code", SqlDbType.VarChar).Value = userid;
                else
                    da.SelectCommand.Parameters.Add("@user_code", SqlDbType.VarChar).Value = "%";

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

        }

        public string InsertCommonData(IncentivesVOs objvo1)
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
                com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON]";

                com.Transaction = transaction;
                com.Connection = connection;

                if (objvo1.User_Id != null)
                    com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);
                if (objvo1.UnitName != null)
                    com.Parameters.AddWithValue("@UnitName", objvo1.UnitName);
                else
                    com.Parameters.AddWithValue("@UnitName", null);
                if (objvo1.ApplciantName != null)
                    com.Parameters.AddWithValue("@ApplicantName", objvo1.ApplciantName);
                else
                    com.Parameters.AddWithValue("@ApplicantName", null);
                if (objvo1.TinNO != null)
                    com.Parameters.AddWithValue("@TinNO", objvo1.TinNO);
                else
                    com.Parameters.AddWithValue("@TinNO", null);
                if (objvo1.PanNo != null)
                    com.Parameters.AddWithValue("@PanNo", objvo1.PanNo);
                else
                    com.Parameters.AddWithValue("@PanNo", null);
                if (objvo1.UnitDIst != null)
                    com.Parameters.AddWithValue("@UnitDIst", objvo1.UnitDIst);
                else
                    com.Parameters.AddWithValue("@UnitDIst", null);
                if (objvo1.UnitMandal != null)
                    com.Parameters.AddWithValue("@UnitMandal", objvo1.UnitMandal);
                else
                    com.Parameters.AddWithValue("@UnitMandal", null);
                if (objvo1.UnitVill != null)
                    com.Parameters.AddWithValue("@UnitVill", objvo1.UnitVill);
                else
                    com.Parameters.AddWithValue("@UnitVill", null);
                if (objvo1.UnitHNO != null)
                    com.Parameters.AddWithValue("@UnitHNO", objvo1.UnitHNO);
                else
                    com.Parameters.AddWithValue("@UnitHNO", null);
                if (objvo1.UnitStreet != null)
                    com.Parameters.AddWithValue("@UnitStreet", objvo1.UnitStreet);
                else
                    com.Parameters.AddWithValue("@UnitStreet", null);
                if (objvo1.OffcDIst != null)
                    com.Parameters.AddWithValue("@OffcDIst", objvo1.OffcDIst);
                else
                    com.Parameters.AddWithValue("@OffcDIst", null);
                if (objvo1.OffcMandal != null)
                    com.Parameters.AddWithValue("@OffcMandal", objvo1.OffcMandal);
                else
                    com.Parameters.AddWithValue("@OffcMandal", null);
                if (objvo1.OffcVil != null)
                    com.Parameters.AddWithValue("@OffcVill", objvo1.OffcVil);
                else
                    com.Parameters.AddWithValue("@OffcVill", null);
                if (objvo1.OffcHNO != null)
                    com.Parameters.AddWithValue("@OffcHNO", objvo1.OffcHNO);
                else
                    com.Parameters.AddWithValue("@OffcHNO", null);
                if (objvo1.OffcStreet != null)
                    com.Parameters.AddWithValue("@OffcStreet", objvo1.OffcStreet);
                else
                    com.Parameters.AddWithValue("@OffcStreet", null);

                // added newly
                if (objvo1.UnitMObileNo != null)
                    com.Parameters.AddWithValue("@UnitMObileNo", objvo1.UnitMObileNo);
                else
                    com.Parameters.AddWithValue("@UnitMObileNo", null);
                if (objvo1.UnitEmail != null)
                    com.Parameters.AddWithValue("@UnitEmail", objvo1.UnitEmail);
                else
                    com.Parameters.AddWithValue("@UnitEmail", null);

                if (objvo1.OffcEmail != null)
                    com.Parameters.AddWithValue("@OffcEmail", objvo1.OffcEmail);
                else
                    com.Parameters.AddWithValue("@OffcEmail", null);
                if (objvo1.OffcMobileNO != null)
                    com.Parameters.AddWithValue("@OffcMobileNO", objvo1.OffcMobileNO);
                else
                    com.Parameters.AddWithValue("@OffcMobileNO", null);
                //

                if (objvo1.Category != null)
                    com.Parameters.AddWithValue("@Category", objvo1.Category);
                else
                    com.Parameters.AddWithValue("@Category", null);
                if (objvo1.TypeofOrg != null)
                    com.Parameters.AddWithValue("@OrgType", objvo1.TypeofOrg);
                else
                    com.Parameters.AddWithValue("@OrgType", null);
                if (objvo1.IdsustryStatus != null)
                    com.Parameters.AddWithValue("@IdsustryStatus", objvo1.IdsustryStatus);
                else
                    com.Parameters.AddWithValue("@IdsustryStatus", null);
                if (objvo1.ExistingPercentageincreaseunderExpansionORDiversification != null)
                    com.Parameters.AddWithValue("@ExistingPercentageincreaseunderExpansionORDiversification", objvo1.ExistingPercentageincreaseunderExpansionORDiversification);
                else
                    com.Parameters.AddWithValue("@ExistingPercentageincreaseunderExpansionORDiversification", null);
                if (objvo1.ExpansionDiversificationLOA != null)
                    com.Parameters.AddWithValue("@ExpansionDiversificationLOA", objvo1.ExpansionDiversificationLOA);
                else
                    com.Parameters.AddWithValue("@ExpansionDiversificationLOA", null);

                if (objvo1.ExistingInstalledCapacityinEnter != null)
                    com.Parameters.AddWithValue("@ExistingInstalledCapacityinEnter", objvo1.ExistingInstalledCapacityinEnter);
                else
                    com.Parameters.AddWithValue("@ExistingInstalledCapacityinEnter", null);

                if (objvo1.ExpanORDiversInstalledCapacityinEnter != null)
                    com.Parameters.AddWithValue("@ExpanORDiversInstalledCapacityinEnter", objvo1.ExpanORDiversInstalledCapacityinEnter);
                else
                    com.Parameters.AddWithValue("@ExpanORDiversInstalledCapacityinEnter", null);
                if (objvo1.ExpanORDiversPercentIncreaseunderExpansionORDiversification != null)
                    com.Parameters.AddWithValue("@ExpanORDiversPercentIncreaseunderExpansionORDiversification", objvo1.ExpanORDiversPercentIncreaseunderExpansionORDiversification);
                else
                    com.Parameters.AddWithValue("@ExpanORDiversPercentIncreaseunderExpansionORDiversification", null);
                if (objvo1.ExistEnterpriseLand != null)
                    com.Parameters.AddWithValue("@ExistEnterpriseLand", objvo1.ExistEnterpriseLand);
                else
                    com.Parameters.AddWithValue("@ExistEnterpriseLand", null);
                if (objvo1.ExistEnterpriseBuilding != null)
                    com.Parameters.AddWithValue("@ExistEnterpriseBuilding", objvo1.ExistEnterpriseBuilding);
                else
                    com.Parameters.AddWithValue("@ExistEnterpriseBuilding", null);
                if (objvo1.ExistEnterprisePlantMachinery != null)
                    com.Parameters.AddWithValue("@ExistEnterprisePlantMachinery", objvo1.ExistEnterprisePlantMachinery);
                else
                    com.Parameters.AddWithValue("@ExistEnterprisePlantMachinery", null);
                if (objvo1.ExpansionDiversificationLand != null)
                    com.Parameters.AddWithValue("@ExpansionDiversificationLand", objvo1.ExpansionDiversificationLand);
                else
                    com.Parameters.AddWithValue("@ExpansionDiversificationLand", null);
                if (objvo1.ExpDiversBuilding != null)
                    com.Parameters.AddWithValue("@ExpDiversBuilding", objvo1.ExpDiversBuilding);
                else
                    com.Parameters.AddWithValue("@ExpDiversBuilding", null);
                if (objvo1.ExpDiversPlantMachinery != null)
                    com.Parameters.AddWithValue("@ExpDiversPlantMachinery", objvo1.ExpDiversPlantMachinery);
                else com.Parameters.AddWithValue("@ExpDiversPlantMachinery", null);
                //if (objvo1.Userid_No != null)
                if (objvo1.LandFixedCapitalInvestPercentage != null)
                    com.Parameters.AddWithValue("@LandFixedCapitalInvestPercentage", objvo1.LandFixedCapitalInvestPercentage);
                else
                    com.Parameters.AddWithValue("@LandFixedCapitalInvestPercentage", null);

                if (objvo1.BuildingFixedCapitalInvestPercentage != null)
                    com.Parameters.AddWithValue("@BuildingFixedCapitalInvestPercentage", objvo1.BuildingFixedCapitalInvestPercentage);
                else
                    com.Parameters.AddWithValue("@BuildingFixedCapitalInvestPercentage", null);
                if (objvo1.PlantMachFixedCapitalInvestPercentage != null)
                    com.Parameters.AddWithValue("@PlantMachFixedCapitalInvestPercentage", objvo1.PlantMachFixedCapitalInvestPercentage);
                else
                    com.Parameters.AddWithValue("@PlantMachFixedCapitalInvestPercentage", null);
                if (objvo1.SocialStatus != null)
                    com.Parameters.AddWithValue("@SocialStatus", Convert.ToInt32(objvo1.SocialStatus));
                else
                    com.Parameters.AddWithValue("@SocialStatus", null);

                // added newly 
                if (objvo1.NewPowerReleaseDate != null)
                    com.Parameters.AddWithValue("@NewPowerReleaseDate", objvo1.NewPowerReleaseDate);
                else
                    com.Parameters.AddWithValue("@NewPowerReleaseDate", null);
                if (objvo1.NewConnectedLoad != null)
                    com.Parameters.AddWithValue("@NewConnectedLoad", objvo1.NewConnectedLoad);
                else com.Parameters.AddWithValue("@NewConnectedLoad", null);
                if (objvo1.NewContractedLoad != null)
                    com.Parameters.AddWithValue("@NewContractedLoad", objvo1.NewContractedLoad);
                else
                    com.Parameters.AddWithValue("@NewContractedLoad", null);

                if (objvo1.ServiceConnectionNO != null)
                    com.Parameters.AddWithValue("@ServiceConnectionNO", objvo1.ServiceConnectionNO);
                else
                    com.Parameters.AddWithValue("@ServiceConnectionNO", null);

                if (objvo1.ExistingConnectedLoad != null)
                    com.Parameters.AddWithValue("@ExistingConnectedLoad", objvo1.ExistingConnectedLoad);
                else com.Parameters.AddWithValue("@ExistingConnectedLoad", null);
                if (objvo1.ExistingContractedLoad != null)
                    com.Parameters.AddWithValue("@ExistingContractedLoad", objvo1.ExistingContractedLoad);
                else
                    com.Parameters.AddWithValue("@ExistingContractedLoad", null);

                if (objvo1.ExistingPowerReleaseDate != null)
                    com.Parameters.AddWithValue("@ExistingPowerReleaseDate", objvo1.ExistingPowerReleaseDate);
                else
                    com.Parameters.AddWithValue("@ExistingPowerReleaseDate", null);
                if (objvo1.ExistingServiceConnectionNO != null)
                    com.Parameters.AddWithValue("@ExistingServiceConnectionNO", objvo1.ExistingServiceConnectionNO);
                else
                    com.Parameters.AddWithValue("@ExistingServiceConnectionNO", null);

                if (objvo1.ExpanDiverConnectedLoad != null)
                    com.Parameters.AddWithValue("@ExpanDiverConnectedLoad", objvo1.ExpanDiverConnectedLoad);
                else com.Parameters.AddWithValue("@ExpanDiverConnectedLoad", null);
                if (objvo1.ExpanDiverContractedLoad != null)
                    com.Parameters.AddWithValue("@ExpanDiverContractedLoad", objvo1.ExpanDiverContractedLoad);
                else
                    com.Parameters.AddWithValue("@ExpanDiverContractedLoad", null);
                if (objvo1.ExpanDiverPowerReleaseDate != null)
                    com.Parameters.AddWithValue("@ExpanDiverPowerReleaseDate", objvo1.ExpanDiverPowerReleaseDate);
                else
                    com.Parameters.AddWithValue("@ExpanDiverPowerReleaseDate", null);
                if (objvo1.ExpanDiverServiceConnectionNO != null)
                    com.Parameters.AddWithValue("@ExpanDiverServiceConnectionNO", objvo1.ExpanDiverServiceConnectionNO);
                else
                    com.Parameters.AddWithValue("@ExpanDiverServiceConnectionNO", null);

                //

                if (objvo1.ManagementStaffMale != null)
                    com.Parameters.AddWithValue("@ManagementStaffMale", objvo1.ManagementStaffMale);
                else
                    com.Parameters.AddWithValue("@ManagementStaffMale", null);
                if (objvo1.ManagementStaffFemale != null)
                    com.Parameters.AddWithValue("@ManagementStaffFemale", objvo1.ManagementStaffFemale);
                else
                    com.Parameters.AddWithValue("@ManagementStaffFemale", null);
                if (objvo1.SupervisoryMale != null)
                    com.Parameters.AddWithValue("@SupervisoryMale", objvo1.SupervisoryMale);
                else
                    com.Parameters.AddWithValue("@SupervisoryMale", null);
                if (objvo1.SupervisoryFemale != null)
                    com.Parameters.AddWithValue("@SupervisoryFemale", objvo1.SupervisoryFemale);
                else com.Parameters.AddWithValue("@SupervisoryFemale", null);

                // added newly
                if (objvo1.SkilledWorkersMale != null)
                    com.Parameters.AddWithValue("@SkilledWorkersMale", objvo1.SkilledWorkersMale);
                else
                    com.Parameters.AddWithValue("@SkilledWorkersMale", null);
                if (objvo1.SkilledWorkersFemale != null)
                    com.Parameters.AddWithValue("@SkilledWorkersFemale", objvo1.SkilledWorkersFemale);
                else
                    com.Parameters.AddWithValue("@SkilledWorkersFemale", null);

                if (objvo1.SemiSkilledWorkersMale != null)
                    com.Parameters.AddWithValue("@SemiSkilledWorkersMale", objvo1.SemiSkilledWorkersMale);
                else
                    com.Parameters.AddWithValue("@SemiSkilledWorkersMale", null);
                if (objvo1.SemiSkilledWorkersFemale != null)
                    com.Parameters.AddWithValue("@SemiSkilledWorkersFemale", objvo1.SemiSkilledWorkersFemale);
                else
                    com.Parameters.AddWithValue("@SemiSkilledWorkersFemale", null);
                //

                if (objvo1.ProjectFinance != null)
                    com.Parameters.AddWithValue("@ProjectFinance", objvo1.ProjectFinance);
                else
                    com.Parameters.AddWithValue("@ProjectFinance", null);
                if (objvo1.TermLoanApplDate != null)
                    com.Parameters.AddWithValue("@TermLoanApplDate", objvo1.TermLoanApplDate);
                else
                    com.Parameters.AddWithValue("@TermLoanApplDate", null);
                if (objvo1.InstitutionName != null)
                    com.Parameters.AddWithValue("@InstitutionName", objvo1.InstitutionName);
                else
                    com.Parameters.AddWithValue("@InstitutionName", null);
                if (objvo1.TermLoanSancRefNo != null)
                    com.Parameters.AddWithValue("@TermLoanSancRefNo", objvo1.TermLoanSancRefNo);
                else
                    com.Parameters.AddWithValue("@TermLoanSancRefNo", null);

                //if (objvo1.AvailedSubsidyEarlier != null)
                //    com.Parameters.AddWithValue("@AvailedSubsidyEarlier", objvo1.AvailedSubsidyEarlier);
                //else
                //    com.Parameters.AddWithValue("@AvailedSubsidyEarlier", null);
                //if (objvo1.TotalSubsidyAlreadyAvailedScheme != null)
                //    com.Parameters.AddWithValue("@TotalSubsidyAlreadyAvailedScheme", objvo1.TotalSubsidyAlreadyAvailedScheme);
                //else
                //    com.Parameters.AddWithValue("@TotalSubsidyAlreadyAvailedScheme", null);
                //if (objvo1.TotalSubsidyAlreadyAvailedAmount != null)
                //    com.Parameters.AddWithValue("@TotalSubsidyAlreadyAvailedAmount", objvo1.TotalSubsidyAlreadyAvailedAmount);
                //else
                //    com.Parameters.AddWithValue("@TotalSubsidyAlreadyAvailedAmount", null);

                if (objvo1.SecondHandMachVal != null)
                    com.Parameters.AddWithValue("@SecondHandMachVal", objvo1.SecondHandMachVal);
                else
                    com.Parameters.AddWithValue("@SecondHandMachVal", null);

                //// '@EnterpriseTypeExisting', 
                if (objvo1.ExistingEnterpriseLOA != null)
                    com.Parameters.AddWithValue("@ExistingEnterpriseLOA", objvo1.ExistingEnterpriseLOA);
                else
                    com.Parameters.AddWithValue("@ExistingEnterpriseLOA", null);
                if (objvo1.NewMachVal != null)
                    com.Parameters.AddWithValue("@NewMachVal", objvo1.NewMachVal);
                else
                    com.Parameters.AddWithValue("@NewMachVal", null);
                if (objvo1.Newand2ndlMachTotVal != null)
                    com.Parameters.AddWithValue("@Newand2ndlMachTotVal", objvo1.Newand2ndlMachTotVal);
                else
                    com.Parameters.AddWithValue("@Newand2ndlMachTotVal", null);
                if (objvo1.PercentageSHMValinTotMachVal != null)
                    com.Parameters.AddWithValue("@PercentageSHMValinTotMachVal", objvo1.PercentageSHMValinTotMachVal);
                else
                    com.Parameters.AddWithValue("@PercentageSHMValinTotMachVal", null);
                if (objvo1.MachValPrchasedfromAPIDCorAPSFCBank != null)
                    com.Parameters.AddWithValue("@MachValPrchasedfromAPIDCorAPSFCBank", objvo1.MachValPrchasedfromAPIDCorAPSFCBank);
                else
                    com.Parameters.AddWithValue("@MachValPrchasedfromAPIDCorAPSFCBank", null);

                if (objvo1.TotalMachVal != null)
                    com.Parameters.AddWithValue("@TotalMachVal", objvo1.TotalMachVal);
                else
                    com.Parameters.AddWithValue("@TotalMachVal", null);

                // Bank details 
                if (objvo1.BankName != null)
                    com.Parameters.AddWithValue("@BankName", objvo1.BankName);
                else
                    com.Parameters.AddWithValue("@BankName", null);

                if (objvo1.AccNo != null)
                    com.Parameters.AddWithValue("@AccNo", objvo1.AccNo);
                else
                    com.Parameters.AddWithValue("@AccNo", null);

                if (objvo1.BranchName != null)
                    com.Parameters.AddWithValue("@BranchName", objvo1.BranchName);
                else
                    com.Parameters.AddWithValue("@BranchName", null);

                if (objvo1.IFSCCode != null)
                    com.Parameters.AddWithValue("@IFSCCode", objvo1.IFSCCode);
                else
                    com.Parameters.AddWithValue("@IFSCCode", null);

                if (objvo1.WhetherPower != null)
                    com.Parameters.AddWithValue("@WhetherPower", objvo1.WhetherPower);
                else
                    com.Parameters.AddWithValue("@WhetherPower", null);

                if (objvo1.RequesttoDept != null)
                    com.Parameters.AddWithValue("@RequesttoDept", objvo1.RequesttoDept);
                else
                    com.Parameters.AddWithValue("@RequesttoDept", null);

                ///////
                if (objvo1.EMiUdyogAadhar != null)
                    com.Parameters.AddWithValue("@EMiUdyogAadhar", objvo1.EMiUdyogAadhar);
                else
                    com.Parameters.AddWithValue("@EMiUdyogAadhar", null);

                if (objvo1.sector != null)
                    com.Parameters.AddWithValue("@SectorID", objvo1.sector);
                else
                    com.Parameters.AddWithValue("@SectorID", null);

                if (objvo1.natureOfAct != null)
                    com.Parameters.AddWithValue("@NatureOfActivity", objvo1.natureOfAct);
                else
                    com.Parameters.AddWithValue("@NatureOfActivity", null);

                if (objvo1.NatureofBussiness != null)
                    com.Parameters.AddWithValue("@NatureofBussiness", objvo1.NatureofBussiness);
                else
                    com.Parameters.AddWithValue("@NatureofBussiness", null);

                if (objvo1.IsGHMCandOtherMuncpOrp != null)
                    com.Parameters.AddWithValue("@IsGHMCandOtherMuncpOrp", objvo1.IsGHMCandOtherMuncpOrp);
                else
                    com.Parameters.AddWithValue("@IsGHMCandOtherMuncpOrp", null);

                if (objvo1.IsDifferentlyAbled != null)
                    com.Parameters.AddWithValue("@IsDifferentlyAbled", objvo1.IsDifferentlyAbled);
                else
                    com.Parameters.AddWithValue("@IsDifferentlyAbled", null);

                if (objvo1.isVehicleIncentive != null)
                    com.Parameters.AddWithValue("@isVehicleIncentive", objvo1.isVehicleIncentive);
                else
                    com.Parameters.AddWithValue("@isVehicleIncentive", null);

                //// Vat No
                if (objvo1.Vatno != null)
                    com.Parameters.AddWithValue("@VATNo", objvo1.Vatno);
                else
                    com.Parameters.AddWithValue("@VATNo", null);

                if (objvo1.Cstno != null)
                    com.Parameters.AddWithValue("@CSTNo", objvo1.Cstno);
                else
                    com.Parameters.AddWithValue("@CSTNo", null);

                //if (objvo1.MobileNo != null)
                //    com.Parameters.AddWithValue("@MobileNo", objvo1.MobileNo);
                //else
                //    com.Parameters.AddWithValue("@MobileNo", null);

                //if (objvo1.EmailID != null)
                //    com.Parameters.AddWithValue("@EmailID", objvo1.EmailID);
                //else
                //    com.Parameters.AddWithValue("@EmailID", null);

                if (objvo1.Gender != null)
                    com.Parameters.AddWithValue("@Gender", objvo1.Gender);
                else
                    com.Parameters.AddWithValue("@Gender", null);
                //////

                // added newly
                if (objvo1.CSTRegDate != null)
                    com.Parameters.AddWithValue("@CSTRegDate", objvo1.CSTRegDate);
                else
                    com.Parameters.AddWithValue("@CSTRegDate", null);
                if (objvo1.CSTRegAuthority != null)
                    com.Parameters.AddWithValue("@CSTRegAuthority", objvo1.CSTRegAuthority);
                else
                    com.Parameters.AddWithValue("@CSTRegAuthority", null);
                if (objvo1.CSTRegAuthAddress != null)
                    com.Parameters.AddWithValue("@CSTRegAuthAddress", objvo1.CSTRegAuthAddress);
                else
                    com.Parameters.AddWithValue("@CSTRegAuthAddress", null);
                if (objvo1.PowerStatus != null)
                    com.Parameters.AddWithValue("@PowerType", Convert.ToInt32(objvo1.PowerStatus));
                else
                    com.Parameters.AddWithValue("@PowerType", null);

                if (objvo1.IsMinority != null)
                    com.Parameters.AddWithValue("@IsMinority", objvo1.IsMinority);
                else
                    com.Parameters.AddWithValue("@IsMinority", null);
                // added
                if (objvo1.isSecondHandMachVal != null)
                    com.Parameters.AddWithValue("@isSecondHandMachVal", objvo1.isSecondHandMachVal);
                else
                    com.Parameters.AddWithValue("@isSecondHandMachVal", null);
                if (objvo1.TermLoanApplDate != null)
                    com.Parameters.AddWithValue("@TermLoanSanDate", objvo1.TermLoanApplDate);
                else
                    com.Parameters.AddWithValue("@TermLoanSanDate", null);


                if (objvo1.eepinscapUnit != null)
                    com.Parameters.AddWithValue("@eepinscapUnit", objvo1.eepinscapUnit);
                else
                    com.Parameters.AddWithValue("@eepinscapUnit", null);
                if (objvo1.edpinscapUnit != null)
                    com.Parameters.AddWithValue("@edpinscapUnit", objvo1.edpinscapUnit);
                else
                    com.Parameters.AddWithValue("@edpinscapUnit", null);

                if (objvo1.DateOfComm != null)
                    com.Parameters.AddWithValue("@DCP", objvo1.DateOfComm);
                else
                    com.Parameters.AddWithValue("@DCP", null);

                //added on 08.06.2017
                if (objvo1.UnitState != null)
                    com.Parameters.AddWithValue("@UnitState", objvo1.UnitState);
                else
                    com.Parameters.AddWithValue("@UnitState", null);

                if (objvo1.OffcState != null)
                    com.Parameters.AddWithValue("@OffcState", objvo1.OffcState);
                else
                    com.Parameters.AddWithValue("@OffcState", null);

                if (objvo1.OffcOtherDist != null)
                    com.Parameters.AddWithValue("@OffcOtherDist", objvo1.OffcOtherDist);
                else
                    com.Parameters.AddWithValue("@OffcOtherDist", null);

                if (objvo1.OffcOtherMandal != null)
                    com.Parameters.AddWithValue("@OffcOtherMandal", objvo1.OffcOtherMandal);
                else
                    com.Parameters.AddWithValue("@OffcOtherMandal", null);

                if (objvo1.OffcOtherVillage != null)
                    com.Parameters.AddWithValue("@OffcOtherVillage", objvo1.OffcOtherVillage);
                else
                    com.Parameters.AddWithValue("@OffcOtherVillage", null);

                if (objvo1.EMPart != null)
                    com.Parameters.AddWithValue("@EMPartNo", objvo1.EMPart);
                else
                    com.Parameters.AddWithValue("@EMPartNo", null);

                // added on 18.06.2017
                if (objvo1.SubCaste != null)
                    com.Parameters.AddWithValue("@SubCaste", objvo1.SubCaste);
                else
                    com.Parameters.AddWithValue("@SubCaste", null);

                if (objvo1.GSTNO != null)
                    com.Parameters.AddWithValue("@GSTNO", objvo1.GSTNO);
                else
                    com.Parameters.AddWithValue("@GSTNO", null);

                if (objvo1.GSTDate != null)
                    com.Parameters.AddWithValue("@GSTDate", objvo1.GSTDate);
                else
                    com.Parameters.AddWithValue("@GSTDate", null);

                if (objvo1.IndustryExpansionType != null)
                    com.Parameters.AddWithValue("@IndusExpanType", objvo1.IndustryExpansionType);
                else
                    com.Parameters.AddWithValue("@IndusExpanType", null);

                // power new unit
                if (objvo1.PowNewConnectUnit != null)
                    com.Parameters.AddWithValue("@PowNewConnectUnit", objvo1.PowNewConnectUnit);
                else
                    com.Parameters.AddWithValue("@PowNewConnectUnit", null);

                if (objvo1.PowNewContractUnit != null)
                    com.Parameters.AddWithValue("@PowNewContractUnit", objvo1.PowNewContractUnit);
                else
                    com.Parameters.AddWithValue("@PowNewContractUnit", null);
                // existing power
                if (objvo1.PowExistConnectUnit != null)
                    com.Parameters.AddWithValue("@PowExistConnectUnit", objvo1.PowExistConnectUnit);
                else
                    com.Parameters.AddWithValue("@PowExistConnectUnit", null);

                if (objvo1.PowExistContractUnit != null)
                    com.Parameters.AddWithValue("@PowExistContractUnit", objvo1.PowExistContractUnit);
                else
                    com.Parameters.AddWithValue("@PowExistContractUnit", null);
                // Diversification power
                if (objvo1.PowDiversConnectUnit != null)
                    com.Parameters.AddWithValue("@PowDiversConnectUnit", objvo1.PowDiversConnectUnit);
                else
                    com.Parameters.AddWithValue("@PowDiversConnectUnit", null);

                if (objvo1.PowDiversContractUnit != null)
                    com.Parameters.AddWithValue("@PowDiversContractUnit", objvo1.PowDiversContractUnit);
                else
                    com.Parameters.AddWithValue("@PowDiversContractUnit", null);

                if (objvo1.IsPowerApplicable != null)
                    com.Parameters.AddWithValue("@IsPowerApplicable", objvo1.IsPowerApplicable);
                else
                    com.Parameters.AddWithValue("@IsPowerApplicable", null);

                if (objvo1.AuthorisedSignatory != null)
                    com.Parameters.AddWithValue("@AuthorisedSignatory", objvo1.AuthorisedSignatory);
                else
                    com.Parameters.AddWithValue("@AuthorisedSignatory", null);

                if (objvo1.UdyogAadharType != null)
                    com.Parameters.AddWithValue("@UdyogAadharType", objvo1.UdyogAadharType);
                else
                    com.Parameters.AddWithValue("@UdyogAadharType", null);


                if (objvo1.UdyogAadharRegdDate != null)
                    com.Parameters.AddWithValue("@UdyogAadharRegdDate", objvo1.UdyogAadharRegdDate);
                else
                    com.Parameters.AddWithValue("@UdyogAadharRegdDate", null);


                if (objvo1.IsTermLoanAvailed != null)
                    com.Parameters.AddWithValue("@IsTermLoanAvailed", objvo1.IsTermLoanAvailed);
                else
                    com.Parameters.AddWithValue("@IsTermLoanAvailed", null);


                if (objvo1.BankAccType != null)
                    com.Parameters.AddWithValue("@BankAccType", objvo1.BankAccType);
                else
                    com.Parameters.AddWithValue("@BankAccType", null);


                if (objvo1.BankAccName != null)
                    com.Parameters.AddWithValue("@BankAccountName", objvo1.BankAccName);
                else
                    com.Parameters.AddWithValue("@BankAccountName", null);

                if (objvo1.VehicleNumber != null)
                    com.Parameters.AddWithValue("@VehicleNumber", objvo1.VehicleNumber);
                else
                    com.Parameters.AddWithValue("@VehicleNumber", null);

                if (objvo1.AuthorisedSignatoryDesignation != null)
                    com.Parameters.AddWithValue("@AuthorisedSignatoryDesignation", objvo1.AuthorisedSignatoryDesignation);
                else
                    com.Parameters.AddWithValue("@AuthorisedSignatoryDesignation", null);


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

        public string SaveNameofAssets(IncentiveVosA objvoA)
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
                com.CommandText = "[USP_INSERT_INCENTIVES_ApprovedEstimated_ProjectCost]";

                com.Transaction = transaction;
                com.Connection = connection;

                if (objvoA.User_id != "" && objvoA.User_id != null)
                    com.Parameters.AddWithValue("@User_id", objvoA.User_id);
                else
                    com.Parameters.AddWithValue("@User_id", null);

                if (objvoA.Incentive_id != "" && objvoA.Incentive_id != null)
                    com.Parameters.AddWithValue("@Incentive_id", objvoA.Incentive_id);
                else
                    com.Parameters.AddWithValue("@Incentive_id", null);

                if (objvoA.CfeQuid != "" && objvoA.CfeQuid != null)
                    com.Parameters.AddWithValue("@CfeQuid", objvoA.CfeQuid);
                else
                    com.Parameters.AddWithValue("@CfeQuid", null);

                if (objvoA.CfoQuid != "" && objvoA.CfoQuid != null)
                    com.Parameters.AddWithValue("@CfoQuid", objvoA.CfoQuid);
                else
                    com.Parameters.AddWithValue("@CfoQuid", null);

                if (objvoA.LandApprovedProjectCost != "" && objvoA.LandApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@LandApprovedProjectCost", objvoA.LandApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@LandApprovedProjectCost", null);

                if (objvoA.LandLoanSactioned != "" && objvoA.LandLoanSactioned != null)
                    com.Parameters.AddWithValue("@LandLoanSactioned", objvoA.LandLoanSactioned);
                else
                    com.Parameters.AddWithValue("@LandLoanSactioned", null);

                if (objvoA.LandPromotersEquity != "" && objvoA.LandPromotersEquity != null)
                    com.Parameters.AddWithValue("@LandPromotersEquity", objvoA.LandPromotersEquity);
                else
                    com.Parameters.AddWithValue("@LandPromotersEquity", null);

                if (objvoA.LandLoanAmountReleased != "" && objvoA.LandLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@LandLoanAmountReleased", objvoA.LandLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@LandLoanAmountReleased", null);

                if (objvoA.LandAssetsValuebyFinInstitution != "" && objvoA.LandAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@LandAssetsValuebyFinInstitution", objvoA.LandAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@LandAssetsValuebyFinInstitution", null);

                if (objvoA.LandAssetsValuebyCA != "" && objvoA.LandAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@LandAssetsValuebyCA", objvoA.LandAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@LandAssetsValuebyCA", null);

                if (objvoA.BuildingApprovedProjectCost != "" && objvoA.BuildingApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@BuildingApprovedProjectCost", objvoA.BuildingApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@BuildingApprovedProjectCost", null);

                if (objvoA.BuildingLoanSactioned != "" && objvoA.BuildingLoanSactioned != null)
                    com.Parameters.AddWithValue("@BuildingLoanSactioned", objvoA.BuildingLoanSactioned);
                else
                    com.Parameters.AddWithValue("@BuildingLoanSactioned", null);

                if (objvoA.BuildingPromotersEquity != "" && objvoA.BuildingPromotersEquity != null)
                    com.Parameters.AddWithValue("@BuildingPromotersEquity", objvoA.BuildingPromotersEquity);
                else
                    com.Parameters.AddWithValue("@BuildingPromotersEquity", null);

                if (objvoA.BuildingLoanAmountReleased != "" && objvoA.BuildingLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@BuildingLoanAmountReleased", objvoA.BuildingLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@BuildingLoanAmountReleased", null);

                if (objvoA.BuildingAssetsValuebyFinInstitution != "" && objvoA.BuildingAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyFinInstitution", objvoA.BuildingAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyFinInstitution", null);

                if (objvoA.BuildingAssetsValuebyCA != "" && objvoA.BuildingAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyCA", objvoA.BuildingAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyCA", null);

                if (objvoA.PlantMachineryApprovedProjectCost != "" && objvoA.PlantMachineryApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@PlantMachineryApprovedProjectCost", objvoA.PlantMachineryApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@PlantMachineryApprovedProjectCost", null);

                if (objvoA.PlantMachineryLoanSactioned != "" && objvoA.PlantMachineryLoanSactioned != null)
                    com.Parameters.AddWithValue("@PlantMachineryLoanSactioned", objvoA.PlantMachineryLoanSactioned);
                else
                    com.Parameters.AddWithValue("@PlantMachineryLoanSactioned", null);

                if (objvoA.PlantMachineryPromotersEquity != "" && objvoA.PlantMachineryPromotersEquity != null)
                    com.Parameters.AddWithValue("@PlantMachineryPromotersEquity", objvoA.PlantMachineryPromotersEquity);
                else
                    com.Parameters.AddWithValue("@PlantMachineryPromotersEquity", null);

                if (objvoA.PlantMachineryLoanAmountReleased != "" && objvoA.PlantMachineryLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@PlantMachineryLoanAmountReleased", objvoA.PlantMachineryLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@PlantMachineryLoanAmountReleased", null);

                if (objvoA.PlantMachineryAssetsValuebyFinInstitution != "" && objvoA.PlantMachineryAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyFinInstitution", objvoA.PlantMachineryAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyFinInstitution", null);

                if (objvoA.PlantMachineryAssetsValuebyCA != "" && objvoA.PlantMachineryAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyCA", objvoA.PlantMachineryAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyCA", null);

                if (objvoA.MachineryContingenciesApprovedProjectCost != "" && objvoA.MachineryContingenciesApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesApprovedProjectCost", objvoA.MachineryContingenciesApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesApprovedProjectCost", null);

                if (objvoA.MachineryContingenciesLoanSactioned != "" && objvoA.MachineryContingenciesLoanSactioned != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanSactioned", objvoA.MachineryContingenciesLoanSactioned);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanSactioned", null);

                if (objvoA.MachineryContingenciesPromotersEquity != "" && objvoA.MachineryContingenciesPromotersEquity != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesPromotersEquity", objvoA.MachineryContingenciesPromotersEquity);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesPromotersEquity", null);

                if (objvoA.MachineryContingenciesLoanAmountReleased != "" && objvoA.MachineryContingenciesLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanAmountReleased", objvoA.MachineryContingenciesLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanAmountReleased", null);

                if (objvoA.MachineryContingenciesAssetsValuebyFinInstitution != "" && objvoA.MachineryContingenciesAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyFinInstitution", objvoA.MachineryContingenciesAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyFinInstitution", null);

                if (objvoA.MachineryContingenciesAssetsValuebyCA != "" && objvoA.MachineryContingenciesAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyCA", objvoA.MachineryContingenciesAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyCA", null);

                if (objvoA.ErectionApprovedProjectCost != "" && objvoA.ErectionApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@ErectionApprovedProjectCost", objvoA.ErectionApprovedProjectCost);
                else com.Parameters.AddWithValue("@ErectionApprovedProjectCost", null);

                if (objvoA.ErectionLoanSactioned != "" && objvoA.ErectionLoanSactioned != null)
                    com.Parameters.AddWithValue("@ErectionLoanSactioned", objvoA.ErectionLoanSactioned);
                else
                    com.Parameters.AddWithValue("@ErectionLoanSactioned", null);

                if (objvoA.ErectionLoanAmountReleased != "" && objvoA.ErectionLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@ErectionLoanAmountReleased", objvoA.ErectionLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@ErectionLoanAmountReleased", null);

                if (objvoA.ErectionPromotersEquity != "" && objvoA.ErectionPromotersEquity != null)
                    com.Parameters.AddWithValue("@ErectionPromotersEquity", objvoA.ErectionPromotersEquity);
                else
                    com.Parameters.AddWithValue("@ErectionPromotersEquity", null);

                if (objvoA.ErectionAssetsValuebyFinInstitution != "" && objvoA.ErectionAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyFinInstitution", objvoA.ErectionAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyFinInstitution", null);

                if (objvoA.ErectionAssetsValuebyCA != "" && objvoA.ErectionAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyCA", objvoA.ErectionAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyCA", null);

                if (objvoA.TechnicalfeasibilityApprovedProjectCost != "" && objvoA.TechnicalfeasibilityApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityApprovedProjectCost", objvoA.TechnicalfeasibilityApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityApprovedProjectCost", null);

                if (objvoA.TechnicalfeasibilityLoanSactioned != "" && objvoA.TechnicalfeasibilityLoanSactioned != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanSactioned", objvoA.TechnicalfeasibilityLoanSactioned);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanSactioned", null);

                if (objvoA.TechnicalfeasibilityPromotersEquity != "" && objvoA.TechnicalfeasibilityPromotersEquity != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityPromotersEquity", objvoA.TechnicalfeasibilityPromotersEquity);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityPromotersEquity", null);

                if (objvoA.TechnicalfeasibilityLoanAmountReleased != "" && objvoA.TechnicalfeasibilityLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanAmountReleased", objvoA.TechnicalfeasibilityLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanAmountReleased", null);

                if (objvoA.TechnicalfeasibilityAssetsValuebyFinInstitution != "" && objvoA.TechnicalfeasibilityAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyFinInstitution", objvoA.TechnicalfeasibilityAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyFinInstitution", null);

                if (objvoA.TechnicalfeasibilityAssetsValuebyCA != "" && objvoA.TechnicalfeasibilityAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyCA", objvoA.TechnicalfeasibilityAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyCA", null);

                if (objvoA.WorkingCapitalApprovedProjectCost != "" && objvoA.WorkingCapitalApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@WorkingCapitalApprovedProjectCost", objvoA.WorkingCapitalApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalApprovedProjectCost", null);

                if (objvoA.WorkingCapitalLoanSactioned != "" && objvoA.WorkingCapitalLoanSactioned != null)
                    com.Parameters.AddWithValue("@WorkingCapitalLoanSactioned", objvoA.WorkingCapitalLoanSactioned);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalLoanSactioned", null);

                if (objvoA.WorkingCapitalPromotersEquity != "" && objvoA.WorkingCapitalPromotersEquity != null)
                    com.Parameters.AddWithValue("@WorkingCapitalPromotersEquity", objvoA.WorkingCapitalPromotersEquity);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalPromotersEquity", null);

                if (objvoA.WorkingCapitalLoanAmountReleased != "" && objvoA.WorkingCapitalLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@WorkingCapitalLoanAmountReleased", objvoA.WorkingCapitalLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalLoanAmountReleased", null);

                if (objvoA.WorkingCapitalAssetsValuebyFinInstitution != "" && objvoA.WorkingCapitalAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyFinInstitution", objvoA.WorkingCapitalAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyFinInstitution", null);

                if (objvoA.WorkingCapitalAssetsValuebyCA != "" && objvoA.WorkingCapitalAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyCA", objvoA.WorkingCapitalAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyCA", null);

                if (objvoA.created_by != "" && objvoA.created_by != null)
                    com.Parameters.AddWithValue("@created_by", objvoA.created_by);
                else
                    com.Parameters.AddWithValue("@created_by", null);

                if (objvoA.created_dt != "" && objvoA.created_dt != null)
                    com.Parameters.AddWithValue("@created_dt", objvoA.created_dt);
                else
                    com.Parameters.AddWithValue("@created_dt", null);

                if (objvoA.Modified_by != "" && objvoA.Modified_by != null)
                    com.Parameters.AddWithValue("@Modified_by", objvoA.Modified_by);
                else
                    com.Parameters.AddWithValue("@Modified_by", null);

                if (objvoA.Modified_dt != "" && objvoA.Modified_dt != null)
                    com.Parameters.AddWithValue("@Modified_dt", objvoA.Modified_dt);
                else
                    com.Parameters.AddWithValue("@Modified_dt", null);

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

        public DataSet GetQueryDetailsdept(string UserID, string incentiveID, string IncentiveType, string ApplicationLevel, string JdOrGMflag)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("[FETCHINC_QUERYDETAILS_ID]", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                da.SelectCommand.Parameters.Add("@incentiveIDNew", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@IncentiveType", SqlDbType.VarChar).Value = IncentiveType;
                da.SelectCommand.Parameters.Add("@ApplicationLevel", SqlDbType.VarChar).Value = ApplicationLevel;
                da.SelectCommand.Parameters.Add("@JdOrGMflag", SqlDbType.VarChar).Value = JdOrGMflag;

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }
        public string UpdateTideaTprimeFlag(string incentiveid)
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
                com.CommandText = "USP_UPDATE_TIDEA_TPRIDE_FLAG";

                com.Transaction = transaction;
                com.Connection = connection;

                if (incentiveid != null)
                    com.Parameters.AddWithValue("@INCENTIVEID", incentiveid);
                else
                    com.Parameters.AddWithValue("@INCENTIVEID", null);

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

        public int bulkInsertNewEnterPrise(DataTable dt, string incentiveId)
        {
            con.OpenConnection();
            int i = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["Column5"] = incentiveId;
                }

                SqlBulkCopy bulkCopy = new SqlBulkCopy(con.GetConnection);
                SqlBulkCopyColumnMapping mapping1 = new SqlBulkCopyColumnMapping("Column1", "LineofActivity");
                SqlBulkCopyColumnMapping mapping2 = new SqlBulkCopyColumnMapping("Column2", "NameofUnit");
                SqlBulkCopyColumnMapping mapping3 = new SqlBulkCopyColumnMapping("Column3", "InstalledCapacity");
                SqlBulkCopyColumnMapping mapping4 = new SqlBulkCopyColumnMapping("Column4", "Value");
                SqlBulkCopyColumnMapping mapping5 = new SqlBulkCopyColumnMapping("Created_by", "Created_by");
                SqlBulkCopyColumnMapping mapping6 = new SqlBulkCopyColumnMapping("Column5", "Incentive_id");

                bulkCopy.ColumnMappings.Add(mapping1);
                bulkCopy.ColumnMappings.Add(mapping2);
                bulkCopy.ColumnMappings.Add(mapping3);
                bulkCopy.ColumnMappings.Add(mapping4);
                bulkCopy.ColumnMappings.Add(mapping5);
                bulkCopy.ColumnMappings.Add(mapping6);

                bulkCopy.DestinationTableName = ("Incentives_Line_of_Activity");
                bulkCopy.WriteToServer(dt);
                i = 1;
            }
            catch (Exception ex)
            {
                i = 0;
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return i;
        }

        public int bulkInsertDirectorPartner(DataTable dt, string incentiveId)
        {
            con.OpenConnection();
            int i = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["Column8"] = incentiveId;
                }

                SqlBulkCopy bulkCopy = new SqlBulkCopy(con.GetConnection);
                SqlBulkCopyColumnMapping mapping1 = new SqlBulkCopyColumnMapping("Column1", "NameofDrctr");
                SqlBulkCopyColumnMapping mapping2 = new SqlBulkCopyColumnMapping("Column2", "Community");
                SqlBulkCopyColumnMapping mapping3 = new SqlBulkCopyColumnMapping("Column3", "Share");
                SqlBulkCopyColumnMapping mapping4 = new SqlBulkCopyColumnMapping("Column4", "Percentage");
                SqlBulkCopyColumnMapping mapping5 = new SqlBulkCopyColumnMapping("Created_by", "Created_by");
                SqlBulkCopyColumnMapping mapping6 = new SqlBulkCopyColumnMapping("Column8", "Incentive_id");
                SqlBulkCopyColumnMapping mapping7 = new SqlBulkCopyColumnMapping("Column7", "Gender");
                SqlBulkCopyColumnMapping mapping8 = new SqlBulkCopyColumnMapping("Column5", "AuthorisedSign");
                SqlBulkCopyColumnMapping mapping9 = new SqlBulkCopyColumnMapping("Column6", "Authdesignation");    // --  AuthorisedSign  Authdesignation

                bulkCopy.ColumnMappings.Add(mapping1);
                bulkCopy.ColumnMappings.Add(mapping2);
                bulkCopy.ColumnMappings.Add(mapping3);
                bulkCopy.ColumnMappings.Add(mapping4);
                bulkCopy.ColumnMappings.Add(mapping5);
                bulkCopy.ColumnMappings.Add(mapping6);
                bulkCopy.ColumnMappings.Add(mapping7);
                bulkCopy.ColumnMappings.Add(mapping8);
                bulkCopy.ColumnMappings.Add(mapping9);

                bulkCopy.DestinationTableName = ("Incentives_DirectorPartner_Details");
                bulkCopy.WriteToServer(dt);
                i = 1;
            }
            catch (Exception ex)
            {
                i = 0;
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return i;
        }

        public int bulkInsertNewEnterPriseExpanLOA(DataTable dt, string incentiveId)
        {
            con.OpenConnection();
            int i = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["Column5"] = incentiveId;
                }

                SqlBulkCopy bulkCopy = new SqlBulkCopy(con.GetConnection);
                SqlBulkCopyColumnMapping mapping1 = new SqlBulkCopyColumnMapping("Column1", "LineofActivity");
                SqlBulkCopyColumnMapping mapping2 = new SqlBulkCopyColumnMapping("Column2", "NameofUnit");
                SqlBulkCopyColumnMapping mapping3 = new SqlBulkCopyColumnMapping("Column3", "InstalledCapacity");
                SqlBulkCopyColumnMapping mapping4 = new SqlBulkCopyColumnMapping("Column4", "Value");
                SqlBulkCopyColumnMapping mapping5 = new SqlBulkCopyColumnMapping("Created_by", "Created_by");
                SqlBulkCopyColumnMapping mapping6 = new SqlBulkCopyColumnMapping("Column5", "Incentive_id");
                SqlBulkCopyColumnMapping mapping7 = new SqlBulkCopyColumnMapping("Column6", "LOAType");

                bulkCopy.ColumnMappings.Add(mapping1);
                bulkCopy.ColumnMappings.Add(mapping2);
                bulkCopy.ColumnMappings.Add(mapping3);
                bulkCopy.ColumnMappings.Add(mapping4);
                bulkCopy.ColumnMappings.Add(mapping5);
                bulkCopy.ColumnMappings.Add(mapping6);
                bulkCopy.ColumnMappings.Add(mapping7);

                bulkCopy.DestinationTableName = ("Incentives_Line_of_Activity");
                bulkCopy.WriteToServer(dt);
                i = 1;
            }
            catch (Exception ex)
            {
                i = 0;
                throw ex;
                
            }
            finally
            {
                con.CloseConnection();
            }
            return i;
        }

        public int bulkInsertTermLoanDetails(DataTable dt, string incentiveId)
        {
            con.OpenConnection();
            int i = 0;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["Column5"] = incentiveId;
                }

                SqlBulkCopy bulkCopy = new SqlBulkCopy(con.GetConnection);
                SqlBulkCopyColumnMapping mapping1 = new SqlBulkCopyColumnMapping("Column1", "TermLoanNo");
                SqlBulkCopyColumnMapping mapping2 = new SqlBulkCopyColumnMapping("Column2", "TermLoanApplDate");
                SqlBulkCopyColumnMapping mapping3 = new SqlBulkCopyColumnMapping("Column3", "InstitutionName");
                SqlBulkCopyColumnMapping mapping4 = new SqlBulkCopyColumnMapping("Column4", "TermloanSandate");
                SqlBulkCopyColumnMapping mapping5 = new SqlBulkCopyColumnMapping("Created_by", "Createdby");
                SqlBulkCopyColumnMapping mapping6 = new SqlBulkCopyColumnMapping("Column5", "IncentveID");
                SqlBulkCopyColumnMapping mapping7 = new SqlBulkCopyColumnMapping("Column7", "TermLoanSancRefNo");
                SqlBulkCopyColumnMapping mapping8 = new SqlBulkCopyColumnMapping("Column6", "TermLoanReleaseddate");

                bulkCopy.ColumnMappings.Add(mapping1);
                bulkCopy.ColumnMappings.Add(mapping2);
                bulkCopy.ColumnMappings.Add(mapping3);
                bulkCopy.ColumnMappings.Add(mapping4);
                bulkCopy.ColumnMappings.Add(mapping5);
                bulkCopy.ColumnMappings.Add(mapping6);
                bulkCopy.ColumnMappings.Add(mapping7);
                bulkCopy.ColumnMappings.Add(mapping8);

                bulkCopy.DestinationTableName = ("Incentives_TermLoan_dtls");
                bulkCopy.WriteToServer(dt);
                i = 1;
            }
            catch (Exception ex)
            {
                i = 0;
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return i;
        }

        public DataSet GETINCENTIVESCAFDATA(string createdby, string incentiveid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_INCENTIVES_CAF_DATA", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (createdby != null)
                    da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = createdby.ToString();

                if (incentiveid != null)
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
                else
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = null;

                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet getBankAccountTypeMaster()
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_BANK_ACCOUNT_TYPE_MASTER", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }


        public DataSet GetEnterPriseIs_Incentive(string EnterpriseCost, string EnterPriseType)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("GetEnterPriseIs_incentive", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (EnterpriseCost.Trim() == "" || EnterpriseCost.Trim() == null)
                    da.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@EnterpriseCost", SqlDbType.VarChar).Value = EnterpriseCost.ToString();


                if (EnterPriseType.Trim() == "" || EnterPriseType.Trim() == null)
                    da.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@EnterPriseType", SqlDbType.VarChar).Value = EnterPriseType.ToString();

                da.Fill(ds);
                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetAuthorisedSignatory(string OrgType)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_AUTHORISED_SIGNATORY", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ORGTYPE", SqlDbType.VarChar).Value = OrgType.ToString();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetEducationQualification()
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_Education_Qualification", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }
        public DataSet GetOnMComponents()
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_OnM_Components", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }
        public int insertCapAssNewUnitDB(CapitalAssistanceNewUnitvo obj)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmdsrc = new SqlCommand("usp_insertcapitalAssistancenewuntidetails", con);
                    cmdsrc.Parameters.AddWithValue("@IncentiveID", obj.IncentiveID);
                    cmdsrc.Parameters.AddWithValue("@TypeofUnit", obj.TypeofUnit);
                    cmdsrc.Parameters.AddWithValue("@FactoryShedsandBuildings", obj.FactoryShedsandBuildings);
                    cmdsrc.Parameters.AddWithValue("@LandnotAllottedbyGov", obj.LandnotAllottedbyGov);
                    cmdsrc.Parameters.AddWithValue("@PlandandMachinery", obj.PlandandMachinery);
                    cmdsrc.Parameters.AddWithValue("@Laboratories", obj.Laboratories);
                    cmdsrc.Parameters.AddWithValue("@Utilities", obj.Utilities);
                    cmdsrc.Parameters.AddWithValue("@OtherFixedAssets", obj.OtherFixedAssets);
                    cmdsrc.Parameters.AddWithValue("@Total", obj.Total);
                    cmdsrc.Parameters.AddWithValue("@AmountSubsidyClaimed", obj.AmountSubsidyClaimed);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    result = cmdsrc.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //General.LogerrorDB(ex, "DB");
                //result = "Fail";
                throw ex;
            }
            return result;
        }

        public int insertCapAssExistingUnitDB(ExistingUnitBO obj)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmdsrc = new SqlCommand("usp_insertcapitalAssistanceExistingUnitdetails", con);
                    cmdsrc.Parameters.AddWithValue("@IncentiveID", obj.IncentiveID);
                    cmdsrc.Parameters.AddWithValue("@UpgradationofUnit", obj.UpgradationofUnit);
                    cmdsrc.Parameters.AddWithValue("@PlandandMachinery", obj.PlandandMachinery);
                    cmdsrc.Parameters.AddWithValue("@NewTechnologies", obj.NewTechnologies);
                    cmdsrc.Parameters.AddWithValue("@Total", obj.Total);
                    cmdsrc.Parameters.AddWithValue("@AmountSubsidyClaimed", obj.AmountSubsidyClaimed);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    result = cmdsrc.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //General.LogerrorDB(ex, "DB");
                //result = "Fail";
                throw ex;
            }
            return result;
        }

        //public int insertCapAssCreationEnergyDB(CapAssCreationEnergyBO obj, List<EquipmentDetailsBO> listgridBO)
        //{
        //    int result = 0;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(str))
        //        {
        //            SqlCommand cmdsrc = new SqlCommand("usp_insertcapitalAssistanceCreationEnergydetails", con);

        //            cmdsrc.Parameters.AddWithValue("@IncentiveID", obj.IncentiveID);
        //            cmdsrc.Parameters.AddWithValue("@TypeofInfrastructure", obj.TypeofInfrastructure);
        //            cmdsrc.Parameters.AddWithValue("@CreatedCETP", obj.CreatedCETP);
        //            cmdsrc.Parameters.AddWithValue("@TotalCost", obj.TotalCost);
        //            cmdsrc.Parameters.AddWithValue("@GOI", obj.GOI);
        //            cmdsrc.Parameters.AddWithValue("@StateGovt", obj.StateGovt);
        //            cmdsrc.Parameters.AddWithValue("@Beneficiary", obj.Beneficiary);
        //            cmdsrc.Parameters.AddWithValue("@Bank", obj.Bank);
        //            cmdsrc.Parameters.AddWithValue("@OperationalCost", obj.OperationalCost);
        //            cmdsrc.Parameters.AddWithValue("@CostofEnergy", obj.CostofEnergy);
        //            cmdsrc.Parameters.AddWithValue("@CostofWater", obj.CostofWater);
        //            cmdsrc.Parameters.AddWithValue("@CostofEnvironmental", obj.CostofEnvironmental);
        //            cmdsrc.Parameters.AddWithValue("@CostofEffluent", obj.CostofEffluent);
        //            cmdsrc.Parameters.AddWithValue("@Instalment1", obj.Instalment1);
        //            cmdsrc.Parameters.AddWithValue("@Instalment2", obj.Instalment2);
        //            cmdsrc.Parameters.AddWithValue("@AmountSubsidyClaimedEnergy", obj.AmountSubsidyClaimedEnergy);
        //            cmdsrc.Parameters.AddWithValue("@AmountSubsidyClaimedEffluent", obj.AmountSubsidyClaimedEffluent);
        //            cmdsrc.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
        //            cmdsrc.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
        //            cmdsrc.CommandType = CommandType.StoredProcedure;
        //            con.Open();
        //            result = cmdsrc.ExecuteNonQuery();
        //            if (result >= 1)
        //            {
        //                foreach (EquipmentDetailsBO objEquipmentBO in listgridBO)
        //                {
        //                    using (SqlCommand cmd = new SqlCommand("usp_insertEquipmentPurchasedDetails", con))
        //                    {
        //                        cmd.CommandType = CommandType.StoredProcedure;
        //                        cmd.Parameters.AddWithValue("@IncentiveID", objEquipmentBO.IncentiveID);
        //                        cmd.Parameters.AddWithValue("@NameoftheEquipment", objEquipmentBO.NameoftheEquipment);
        //                        cmd.Parameters.AddWithValue("@NameandAddress", objEquipmentBO.NameandAddress);
        //                        cmd.Parameters.AddWithValue("@BillandDate", objEquipmentBO.BillandDate);
        //                        cmd.Parameters.AddWithValue("@CostofEquipment", objEquipmentBO.CostofEquipment);
        //                        cmd.Parameters.AddWithValue("@CGST", objEquipmentBO.CGST);
        //                        cmd.Parameters.AddWithValue("@SGST", objEquipmentBO.SGST);
        //                        cmd.Parameters.AddWithValue("@FreightCharges", objEquipmentBO.FreightCharges);
        //                        cmd.Parameters.AddWithValue("@OtherCharges", objEquipmentBO.OtherCharges);
        //                        cmd.Parameters.AddWithValue("@Total", objEquipmentBO.Total);
        //                        cmd.Parameters.AddWithValue("@CreatedBy", objEquipmentBO.CreatedBy);
        //                        cmd.ExecuteNonQuery();
        //                    }
        //                }
        //                result = 1;
        //            }
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //General.LogerrorDB(ex, "DB");
        //        //result = "Fail";
        //        throw ex;
        //    }
        //    return result;
        //}

        public int insertInterestSubsidyDB(InterestSubsidyBO obj, List<TermLoanBO> listTermLoanBO, List<TermLoanRepaidBO> listTermLoanRepaidBO)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmdsrc = new SqlCommand("usp_insertInterestSubsidydetails", con);
                    cmdsrc.Parameters.AddWithValue("@IncentiveID", obj.IncentiveID);
                    cmdsrc.Parameters.AddWithValue("@NameofFinance", obj.NameofFinance);
                    cmdsrc.Parameters.AddWithValue("@SanctionDetails", obj.SanctionDetails);
                    cmdsrc.Parameters.AddWithValue("@CurrentclaimPeriod", obj.CurrentclaimPeriod);
                    cmdsrc.Parameters.AddWithValue("@MoratoriumPeriod", obj.MoratoriumPeriod);
                    cmdsrc.Parameters.AddWithValue("@FirstHalf", obj.FirstHalf);
                    cmdsrc.Parameters.AddWithValue("@SecondHalf", obj.SecondHalf);
                    cmdsrc.Parameters.AddWithValue("@CurrentClaimAmount", obj.CurrentClaimAmount);
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);

                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    int Count = cmdsrc.ExecuteNonQuery();
                    if (Count > 0)
                    {
                        foreach (TermLoanBO objTermLoanBO in listTermLoanBO)
                        {
                            using (SqlCommand cmd = new SqlCommand("usp_insertTermLoanDetails", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@IncentiveID", objTermLoanBO.IncentiveID);
                                cmd.Parameters.AddWithValue("@Bank", objTermLoanBO.Bank);
                                cmd.Parameters.AddWithValue("@LoanAccountNo", objTermLoanBO.LoanAccountNo);
                                cmd.Parameters.AddWithValue("@SanctionOrderNo", objTermLoanBO.SanctionOrderNo);
                                cmd.Parameters.AddWithValue("@AmountSanctioned", objTermLoanBO.AmountSanctioned);
                                cmd.Parameters.AddWithValue("@RateofInterest", objTermLoanBO.RateofInterest);
                                cmd.Parameters.AddWithValue("@TermLoanReleased", objTermLoanBO.TermLoanReleased);
                                cmd.Parameters.AddWithValue("@CreatedBy", objTermLoanBO.CreatedBy);
                                int Count2 = cmd.ExecuteNonQuery();
                                if (Count2 > 0)
                                {
                                    foreach (TermLoanRepaidBO objTermLoanRepaidBO in listTermLoanRepaidBO)
                                    {
                                        using (SqlCommand cmdr = new SqlCommand("usp_insertTermLoanRepaidDetails", con))
                                        {
                                            cmdr.CommandType = CommandType.StoredProcedure;
                                            cmdr.Parameters.AddWithValue("@IncentiveID", objTermLoanRepaidBO.IncentiveID);
                                            cmdr.Parameters.AddWithValue("@Year", objTermLoanRepaidBO.Year);
                                            cmdr.Parameters.AddWithValue("@BankFI", objTermLoanRepaidBO.BankFI);
                                            cmdr.Parameters.AddWithValue("@Principal", objTermLoanRepaidBO.Principal);
                                            cmdr.Parameters.AddWithValue("@Interest", objTermLoanRepaidBO.Interest);
                                            cmdr.Parameters.AddWithValue("@CreatedBy", objTermLoanBO.CreatedBy);
                                            cmdr.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        result = 1;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //General.LogerrorDB(ex, "DB");
                //result = "Fail";
                throw ex;
            }
            return result;
        }

        //public int insertPowerTariffSubsidyDB(PowerTariffSubsidyBO obj, List<PowerUtilizedBO> listPowerUtilizedBO, List<EnergyConsumedBO> listEnergyConsumedBO)
        //{
        //    int result = 0;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(str))
        //        {
        //            SqlCommand cmdsrc = new SqlCommand("usp_insertPowerTariffSubsidydetails", con);
        //            cmdsrc.Parameters.AddWithValue("@IncentiveID", obj.IncentiveID);
        //            cmdsrc.Parameters.AddWithValue("@ExistingPower", obj.ExistingPower);
        //            cmdsrc.Parameters.AddWithValue("@NewPower", obj.NewPower);
        //            cmdsrc.Parameters.AddWithValue("@DateofNewpower", obj.DateofNewpower);
        //            cmdsrc.Parameters.AddWithValue("@CurrentClaimPeriod", obj.CurrentClaimPeriod);
        //            cmdsrc.Parameters.AddWithValue("@CurrentClaimAmount", obj.CurrentClaimAmount);
        //            cmdsrc.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
        //            cmdsrc.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);

        //            cmdsrc.CommandType = CommandType.StoredProcedure;
        //            con.Open();
        //            int Count = cmdsrc.ExecuteNonQuery();
        //            if (Count > 0)
        //            {
        //                foreach (PowerUtilizedBO objPowerUtilizedBO in listPowerUtilizedBO)
        //                {
        //                    using (SqlCommand cmdP = new SqlCommand("usp_insertPowerutilizationDetails", con))
        //                    {
        //                        cmdP.CommandType = CommandType.StoredProcedure;
        //                        cmdP.Parameters.AddWithValue("@IncentiveID", objPowerUtilizedBO.IncentiveId);
        //                        cmdP.Parameters.AddWithValue("@FinancialYear", objPowerUtilizedBO.FinancialYear);
        //                        cmdP.Parameters.AddWithValue("@TotalUnits", objPowerUtilizedBO.TotalUnits);
        //                        cmdP.Parameters.AddWithValue("@TotalAmount", objPowerUtilizedBO.TotalAmount);
        //                        cmdP.Parameters.AddWithValue("@CreatedBy", objPowerUtilizedBO.Created_by);
        //                        int Count2 = cmdP.ExecuteNonQuery();
        //                        if (Count2 > 0)
        //                        {
        //                            foreach (EnergyConsumedBO objEnergyConsumedBO in listEnergyConsumedBO)
        //                            {
        //                                using (SqlCommand cmdE = new SqlCommand("usp_insertEnergyConsumedDetails", con))
        //                                {
        //                                    cmdE.CommandType = CommandType.StoredProcedure;
        //                                    cmdE.Parameters.AddWithValue("@IncentiveID", objEnergyConsumedBO.IncentiveID);
        //                                    cmdE.Parameters.AddWithValue("@NoofUnits", objEnergyConsumedBO.NoofUnits);
        //                                    cmdE.Parameters.AddWithValue("@AmountPaid", objEnergyConsumedBO.AmountPaid);
        //                                    cmdE.Parameters.AddWithValue("@SecondNoofunits", objEnergyConsumedBO.SecondNoofunits);
        //                                    cmdE.Parameters.AddWithValue("@SecondAmountPaid", objEnergyConsumedBO.SecondAmountPaid);
        //                                    cmdE.Parameters.AddWithValue("@CreatedBy", objEnergyConsumedBO.CreatedBy);
        //                                    result = cmdE.ExecuteNonQuery();
        //                                }
        //                            }

        //                        }
        //                    }

        //                }
        //                result = 1;
        //            }
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //General.LogerrorDB(ex, "DB");
        //        //result = "Fail";
        //        throw ex;
        //    }
        //    return result;
        //}



        #region "Eligible Criteria"
        public DataSet GET_ELIGIBLE_INCENTIVES_COMMON_DATA(string createdby, string incentiveid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_ELIGIBLE_INCENTIVES_COMMON_DATA", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (createdby != null)
                    da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = createdby.ToString();

                if (incentiveid != null)
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
                else
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = null;

                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetIncetiveApplicationStatus(string incentiveid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_INCENTIVE_APPLICATION_STATUS", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (incentiveid != null)
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
                else
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = null;

                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetAllIncentives(string CreatedBy)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("[FetchIncentives_CAF]", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@createdBy", SqlDbType.VarChar).Value = CreatedBy;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GETINCENTIVESCHECKLIST(string createdby, string incentiveid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_INCENTIVES_CHECKLST", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (createdby != null)
                    da.SelectCommand.Parameters.Add("@CSCreatedBy", SqlDbType.VarChar).Value = createdby.ToString();

                if (incentiveid != null)
                    da.SelectCommand.Parameters.Add("@CSIncentiveId", SqlDbType.VarChar).Value = incentiveid.ToString();
                else
                    da.SelectCommand.Parameters.Add("@CSIncentiveId", SqlDbType.VarChar).Value = null;

                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public string InsertCheckSlip(IncentiveVosIncetForms objvo1)
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
                com.CommandText = "[Usp_Ins_CheckSlip]";

                com.Transaction = transaction;
                com.Connection = connection;

                if (objvo1.CSCreatedBy != null)
                    com.Parameters.AddWithValue("@CSCreatedBy", objvo1.CSCreatedBy);
                else
                    com.Parameters.AddWithValue("@CSCreatedBy", null);

                if (objvo1.CSIncentiveId != null)
                    com.Parameters.AddWithValue("@CSIncentiveId", objvo1.CSIncentiveId);
                else
                    com.Parameters.AddWithValue("@CSIncentiveId", null);

                if (objvo1.CSbillsofinstitutfinancedEnterpriseindustries != null)
                    com.Parameters.AddWithValue("@CSbillsofinstitutfinancedEnterpriseindustries", objvo1.CSbillsofinstitutfinancedEnterpriseindustries);
                else
                    com.Parameters.AddWithValue("@CSbillsofinstitutfinancedEnterpriseindustries", null);

                if (objvo1.CSbillandpymtproofrespectofselffinancedEnterprisesindustries != null)
                    com.Parameters.AddWithValue("@CSbillandpymtproofrespectofselffinancedEnterprisesindustries", objvo1.CSbillandpymtproofrespectofselffinancedEnterprisesindustries);
                else
                    com.Parameters.AddWithValue("@CSbillandpymtproofrespectofselffinancedEnterprisesindustries", null);

                if (objvo1.CasteCertificatesSCST != null)
                    com.Parameters.AddWithValue("@CSCasteCertificatesSCST", objvo1.CasteCertificatesSCST);
                else
                    com.Parameters.AddWithValue("@CSCasteCertificatesSCST", null);

                if (objvo1.CSEntrepreneurAadhar != null)
                    com.Parameters.AddWithValue("@CSEntrepreneurAadhar", objvo1.CSEntrepreneurAadhar);
                else
                    com.Parameters.AddWithValue("@CSEntrepreneurAadhar", null);

                if (objvo1.CSEntrepreneurPANCard != null)
                    com.Parameters.AddWithValue("@CSEntrepreneurPANCard", objvo1.CSEntrepreneurPANCard);
                else
                    com.Parameters.AddWithValue("@CSEntrepreneurPANCard", null);

                if (objvo1.CSCertificateofCA != null)
                    com.Parameters.AddWithValue("@CSCertificateofCA", objvo1.CSCertificateofCA);
                else
                    com.Parameters.AddWithValue("@CSCertificateofCA", null);

                if (objvo1.CSRegdPartnershipDeedArticles != null)
                    com.Parameters.AddWithValue("@CSRegdPartnershipDeedArticles", objvo1.CSRegdPartnershipDeedArticles);
                else
                    com.Parameters.AddWithValue("@CSRegdPartnershipDeedArticles", null);

                if (objvo1.CSApprovalDirectorFactories != null)
                    com.Parameters.AddWithValue("@CSApprovalDirectorFactories", objvo1.CSApprovalDirectorFactories);
                else
                    com.Parameters.AddWithValue("@CSApprovalDirectorFactories", null);

                if (objvo1.CSBoilersCertificate != null)
                    com.Parameters.AddWithValue("@CSBoilersCertificate", objvo1.CSBoilersCertificate);
                else
                    com.Parameters.AddWithValue("@CSBoilersCertificate", null);

                if (objvo1.CSApprovalDirectorTownCountryPlanningUDA != null)
                    com.Parameters.AddWithValue("@CSApprovalDirectorTownCountryPlanningUDA", objvo1.CSApprovalDirectorTownCountryPlanningUDA);
                else
                    com.Parameters.AddWithValue("@CSApprovalDirectorTownCountryPlanningUDA", null);

                if (objvo1.CSRegularbuildingplansapprovalofMunicipalityGramPanchayat != null)
                    com.Parameters.AddWithValue("@CSRegularbuildingplansapprovalofMunicipalityGramPanchayat", objvo1.CSRegularbuildingplansapprovalofMunicipalityGramPanchayat);
                else
                    com.Parameters.AddWithValue("@CSRegularbuildingplansapprovalofMunicipalityGramPanchayat", null);

                if (objvo1.CSOperationTSPCBAcknowledgementGM != null)
                    com.Parameters.AddWithValue("@CSOperationTSPCBAcknowledgementGM", objvo1.CSOperationTSPCBAcknowledgementGM);
                else
                    com.Parameters.AddWithValue("@CSOperationTSPCBAcknowledgementGM", null);

                if (objvo1.CSPowerreleaseCertificatefrmTSTRANSCODISCOM != null)
                    com.Parameters.AddWithValue("@CSPowerreleaseCertificatefrmTSTRANSCODISCOM", objvo1.CSPowerreleaseCertificatefrmTSTRANSCODISCOM);
                else
                    com.Parameters.AddWithValue("@CSPowerreleaseCertificatefrmTSTRANSCODISCOM", null);

                if (objvo1.CSEnvironmentalclearance != null)
                    com.Parameters.AddWithValue("@CSEnvironmentalclearance", objvo1.CSEnvironmentalclearance);
                else
                    com.Parameters.AddWithValue("@CSEnvironmentalclearance", null);

                if (objvo1.CSOtherstatutoryapprovalsspecif != null)
                    com.Parameters.AddWithValue("@CSOtherstatutoryapprovalsspecif", objvo1.CSOtherstatutoryapprovalsspecif);
                else
                    com.Parameters.AddWithValue("@CSOtherstatutoryapprovalsspecif", null);

                if (objvo1.CSEMPartIfullsetIEMIL != null)
                    com.Parameters.AddWithValue("@CSEMPartIfullsetIEMIL", objvo1.CSEMPartIfullsetIEMIL);
                else
                    com.Parameters.AddWithValue("@CSEMPartIfullsetIEMIL", null);

                if (objvo1.CSEMPartIIfullsetIEMIL != null)
                    com.Parameters.AddWithValue("@CSEMPartIIfullsetIEMIL", objvo1.CSEMPartIIfullsetIEMIL);
                else
                    com.Parameters.AddWithValue("@CSEMPartIIfullsetIEMIL", null);

                if (objvo1.CSUdyogAadhar != null)
                    com.Parameters.AddWithValue("@CSUdyogAadhar", objvo1.CSUdyogAadhar);
                else
                    com.Parameters.AddWithValue("@CSUdyogAadhar", null);

                if (objvo1.CSProjectReport != null)
                    com.Parameters.AddWithValue("@CSProjectReport", objvo1.CSProjectReport);
                else
                    com.Parameters.AddWithValue("@CSProjectReport", null);

                if (objvo1.CSTermloansanctionletters != null)
                    com.Parameters.AddWithValue("@CSTermloansanctionletters", objvo1.CSTermloansanctionletters);
                else
                    com.Parameters.AddWithValue("@CSTermloansanctionletters", null);

                if (objvo1.CSBoardResolutionauthorizing != null)
                    com.Parameters.AddWithValue("@CSBoardResolutionauthorizing", objvo1.CSBoardResolutionauthorizing);
                else
                    com.Parameters.AddWithValue("@CSBoardResolutionauthorizing", null);

                if (objvo1.CSRegisteredlandSaledeedPremisesLeasedeed != null)
                    com.Parameters.AddWithValue("@CSRegisteredlandSaledeedPremisesLeasedeed", objvo1.CSRegisteredlandSaledeedPremisesLeasedeed);
                else
                    com.Parameters.AddWithValue("@CSRegisteredlandSaledeedPremisesLeasedeed", null);

                if (objvo1.CSCACECertificateregarding2handplantmachinery != null)
                    com.Parameters.AddWithValue("@CSCACECertificateregarding2handplantmachinery", objvo1.CSCACECertificateregarding2handplantmachinery);
                else
                    com.Parameters.AddWithValue("@CSCACECertificateregarding2handplantmachinery", null);

                if (objvo1.CSCECertificateSelffabricatedmachinery != null)
                    com.Parameters.AddWithValue("@CSCECertificateSelffabricatedmachinery", objvo1.CSCECertificateSelffabricatedmachinery);
                else
                    com.Parameters.AddWithValue("@CSCECertificateSelffabricatedmachinery", null);

                if (objvo1.CSBISCertificate != null)
                    com.Parameters.AddWithValue("@CSBISCertificate", objvo1.CSBISCertificate);
                else
                    com.Parameters.AddWithValue("@CSBISCertificate", null);

                if (objvo1.CSDrugLicense != null)
                    com.Parameters.AddWithValue("@CSDrugLicense", objvo1.CSDrugLicense);
                else
                    com.Parameters.AddWithValue("@CSDrugLicense", null);

                if (objvo1.CSExplosiveLicense != null)
                    com.Parameters.AddWithValue("@CSExplosiveLicense", objvo1.CSExplosiveLicense);
                else
                    com.Parameters.AddWithValue("@CSExplosiveLicense", null);

                if (objvo1.CSVATCSTSGSTCertificate != null)
                    com.Parameters.AddWithValue("@CSVATCSTSGSTCertificate", objvo1.CSVATCSTSGSTCertificate);
                else
                    com.Parameters.AddWithValue("@CSVATCSTSGSTCertificate", null);

                if (objvo1.CSFormA != null)
                    com.Parameters.AddWithValue("@CSFormA", objvo1.CSFormA);
                else
                    com.Parameters.AddWithValue("@CSFormA", null);

                if (objvo1.CSFormB != null)
                    com.Parameters.AddWithValue("@CSFormB", objvo1.CSFormB);
                else
                    com.Parameters.AddWithValue("@CSFormB", null);

                if (objvo1.CSProductionParticulars3Years != null)
                    com.Parameters.AddWithValue("@CSProductionParticulars3Years", objvo1.CSProductionParticulars3Years);
                else
                    com.Parameters.AddWithValue("@CSProductionParticulars3Years", null);

                if (objvo1.CSRTACertificate != null)
                    com.Parameters.AddWithValue("@CSRTACertificate", objvo1.CSRTACertificate);
                else
                    com.Parameters.AddWithValue("@CSRTACertificate", null);

                if (objvo1.CSPHCertificate != null)
                    com.Parameters.AddWithValue("@CSPHCertificate", objvo1.CSPHCertificate);
                else
                    com.Parameters.AddWithValue("@CSPHCertificate", null);

                if (objvo1.CSUndertakingForm != null)
                    com.Parameters.AddWithValue("@CSUndertakingForm", objvo1.CSUndertakingForm);
                else
                    com.Parameters.AddWithValue("@CSUndertakingForm", null);

                if (objvo1.CSUndertakingForm != null)
                    com.Parameters.AddWithValue("@ApplicantVehPhoto", objvo1.ApplicantVehPhoto);
                else
                    com.Parameters.AddWithValue("@ApplicantVehPhoto", null);

                if (objvo1.COBORROWER != null)
                    com.Parameters.AddWithValue("@COBORROWER", objvo1.COBORROWER);
                else
                    com.Parameters.AddWithValue("@COBORROWER", null);

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

        #endregion





        public int InsertEnclosures_DB(string IncentiveID, int AttachmentId, string FileNm, string FilePath, string Createdby)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    //return SqlHelper.ExecuteDataset(con, "Usp_InsertEnclosures", IncentiveID, AttachmentId, FileNm, FilePath, Createdby).Tables[0];

                    SqlCommand cmd = new SqlCommand("Usp_InsertEnclosures", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IncentiveID", IncentiveID);
                    cmd.Parameters.AddWithValue("@AttachmentId", AttachmentId);
                    cmd.Parameters.AddWithValue("@FileNm", FileNm);
                    cmd.Parameters.AddWithValue("@FilePath", FilePath);
                    cmd.Parameters.AddWithValue("@Createdby", Createdby);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataSet IncentiveEnclosures_ChecklistDB(int createdby, int incentiveid)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                try
                {
                    da = new SqlDataAdapter("usp_get_IncentiveEnclosures_Checklist", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;


                    //if (createdby != null)
                    da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = createdby.ToString();

                    //if (incentiveid != null)
                    da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.VarChar).Value = incentiveid.ToString();
                    //else
                    //    da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.VarChar).Value = null;

                    da.Fill(ds);
                    return ds;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public int InsertCheckListDB(EnclosuresBO obj)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("usp_InsertCheckList", con);
                    cmd.Parameters.AddWithValue("@CSCreatedBy", obj.CSCreatedBy);
                    cmd.Parameters.AddWithValue("@CSIncentiveId", obj.CSIncentiveId);
                    cmd.Parameters.AddWithValue("@CSbillsofinstitutfinancedEnterpriseindustries", obj.CSbillsofinstitutfinancedEnterpriseindustries);
                    cmd.Parameters.AddWithValue("@CSbillandpymtproofrespectofselffinancedEnterprisesindustries", obj.CSbillandpymtproofrespectofselffinancedEnterprisesindustries);
                    cmd.Parameters.AddWithValue("@CSCasteCertificatesSCST", obj.CasteCertificatesSCST);
                    cmd.Parameters.AddWithValue("@CSEntrepreneurAadhar", obj.CSEntrepreneurAadhar);
                    cmd.Parameters.AddWithValue("@CSEntrepreneurPANCard", obj.CSEntrepreneurPANCard);
                    cmd.Parameters.AddWithValue("@CSCertificateofCA", obj.CSCertificateofCA);
                    cmd.Parameters.AddWithValue("@CSRegdPartnershipDeedArticles", obj.CSRegdPartnershipDeedArticles);
                    cmd.Parameters.AddWithValue("@CSApprovalDirectorFactories", obj.CSApprovalDirectorFactories);
                    cmd.Parameters.AddWithValue("@CSBoilersCertificate", obj.CSBoilersCertificate);
                    cmd.Parameters.AddWithValue("@CSApprovalDirectorTownCountryPlanningUDA", obj.CSApprovalDirectorTownCountryPlanningUDA);
                    cmd.Parameters.AddWithValue("@CSRegularbuildingplansapprovalofMunicipalityGramPanchayat", obj.CSRegularbuildingplansapprovalofMunicipalityGramPanchayat);
                    cmd.Parameters.AddWithValue("@CSOperationTSPCBAcknowledgementGM", obj.CSOperationTSPCBAcknowledgementGM);
                    cmd.Parameters.AddWithValue("@CSPowerreleaseCertificatefrmTSTRANSCODISCOM ", obj.CSPowerreleaseCertificatefrmTSTRANSCODISCOM);
                    cmd.Parameters.AddWithValue("@CSEnvironmentalclearance", obj.CSEnvironmentalclearance);
                    cmd.Parameters.AddWithValue("@CSOtherstatutoryapprovalsspecif", obj.CSOtherstatutoryapprovalsspecif);
                    cmd.Parameters.AddWithValue("@CSEMPartIfullsetIEMIL", obj.CSEMPartIfullsetIEMIL);
                    cmd.Parameters.AddWithValue("@CSUdyogAadhar", obj.CSUdyogAadhar);
                    cmd.Parameters.AddWithValue("@CSProjectReport", obj.CSProjectReport);
                    cmd.Parameters.AddWithValue("@CSTermloansanctionletters ", obj.CSTermloansanctionletters);
                    cmd.Parameters.AddWithValue("@CSBoardResolutionauthorizing", obj.CSBoardResolutionauthorizing);
                    cmd.Parameters.AddWithValue("@CSRegisteredlandSaledeedPremisesLeasedeed", obj.CSRegisteredlandSaledeedPremisesLeasedeed);
                    cmd.Parameters.AddWithValue("@CSCACECertificateregarding2handplantmachinery", obj.CSCACECertificateregarding2handplantmachinery);
                    cmd.Parameters.AddWithValue("@CSCECertificateSelffabricatedmachinery", obj.CSCECertificateSelffabricatedmachinery);
                    cmd.Parameters.AddWithValue("@CSBISCertificate", obj.CSBISCertificate);
                    cmd.Parameters.AddWithValue("@CSDrugLicense", obj.CSDrugLicense);
                    cmd.Parameters.AddWithValue("@CSExplosiveLicense", obj.CSExplosiveLicense);
                    cmd.Parameters.AddWithValue("@CSVATCSTSGSTCertificate", obj.CSVATCSTSGSTCertificate);
                    cmd.Parameters.AddWithValue("@CSFormA", obj.CSFormA);
                    cmd.Parameters.AddWithValue("@CSFormB", obj.CSFormB);
                    cmd.Parameters.AddWithValue("@CSProductionParticulars3Years ", obj.CSProductionParticulars3Years);
                    cmd.Parameters.AddWithValue("@CSRTACertificate", obj.CSRTACertificate);
                    cmd.Parameters.AddWithValue("@CSPHCertificate", obj.CSPHCertificate);
                    cmd.Parameters.AddWithValue("@CSUndertakingForm", obj.CSUndertakingForm);
                    cmd.Parameters.AddWithValue("@ApplicantVehPhoto", obj.ApplicantVehPhoto);
                    cmd.Parameters.AddWithValue("@Fisrsalebill", obj.firstsalebill);
                    cmd.Parameters.AddWithValue("@COBORROWER", obj.COBORROWER);

                    cmd.Parameters.AddWithValue("@CopyofPan", obj.CopyofPan);
                    cmd.Parameters.AddWithValue("@DocFirstInvestment", obj.DocFirstInvestment);
                    cmd.Parameters.AddWithValue("@InvestmentCertificate", obj.InvestmentCertificate);
                    cmd.Parameters.AddWithValue("@EngineersCertificate", obj.EngineersCertificate);
                    cmd.Parameters.AddWithValue("@CopyofReceipts", obj.CopyofReceipts);
                    cmd.Parameters.AddWithValue("@ExpenditureCertificate", obj.ExpenditureCertificate);


                    cmd.Parameters.AddWithValue("@Created_by", obj.CSCreatedBy);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //General.LogerrorDB(ex, "DB");
                //result = "Fail";
                throw ex;
            }
            return result;
        }
        public int InsertIncentiveUploads(string IncentiveID, string MstIncentiveId, string AttachmentId, string FileNm, string FilePath, string FileDescription, string DocUploadedUserType, string IsDigiLocker, string EnclTpeesign, string Createdby, string QueryId)
        {
            int valid = 0;
            try
            {
                con.OpenConnection();
                SqlDataAdapter myDataAdapter;
                myDataAdapter = new SqlDataAdapter("USP_INSERT_Incentives_DOCUMENTS", con.GetConnection);
                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                myDataAdapter.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
                myDataAdapter.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId;
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentId", SqlDbType.VarChar).Value = AttachmentId;
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = FileNm;
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath;
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription;
                myDataAdapter.SelectCommand.Parameters.Add("@DocUploadedUserType", SqlDbType.VarChar).Value = DocUploadedUserType;
                myDataAdapter.SelectCommand.Parameters.Add("@IsDigiLocker", SqlDbType.VarChar).Value = IsDigiLocker;
                myDataAdapter.SelectCommand.Parameters.Add("@EnclTpeesign", SqlDbType.VarChar).Value = EnclTpeesign;
                myDataAdapter.SelectCommand.Parameters.Add("@QueryId", SqlDbType.VarChar).Value = QueryId;
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;

                myDataAdapter.SelectCommand.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                myDataAdapter.SelectCommand.Parameters["@Valid"].Direction = ParameterDirection.Output;
                myDataAdapter.SelectCommand.ExecuteNonQuery();

                string Output = myDataAdapter.SelectCommand.Parameters["@Valid"].Value.ToString();
                if (!string.IsNullOrEmpty(Output))
                    valid = Convert.ToInt32(myDataAdapter.SelectCommand.Parameters["@Valid"].Value.ToString());
                else
                    valid = 0;
                //int n = myDataAdapter.SelectCommand.ExecuteNonQuery();
                //if (n >= -1)
                //{
                //    return 1;
                //}
                //else
                //{
                //    return 0;
                //}
            }
            catch (Exception ex)
            {
                con.CloseConnection();
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return valid;
        }
        public string DeleteFilefromDB(string AttachemntID, string AttachemntSubID, string Created_by)
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
                com.CommandText = "[USP_DELETE_Incentives_DOCUMENTS]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@AttachemntID", AttachemntID);
                com.Parameters.AddWithValue("@AttachemntSubID", AttachemntSubID);
                com.Parameters.AddWithValue("@Created_by", Created_by);

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
        public string InsertIncentiveUploadsPM(string IncentiveID, string MstIncentiveId, string AttachmentId, string FileNm, string FilePath, string FileDescription, string DocUploadedUserType, string IsDigiLocker, string EnclTpeesign, string Createdby, string QueryId)
        {
            string valid = "";
            try
            {
                con.OpenConnection();
                SqlDataAdapter myDataAdapter;
                myDataAdapter = new SqlDataAdapter("[USP_INSERT_Incentives_DOCUMENTS_PM]", con.GetConnection);
                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                myDataAdapter.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
                myDataAdapter.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId;
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentId", SqlDbType.VarChar).Value = AttachmentId;
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = FileNm;
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath;
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription;
                myDataAdapter.SelectCommand.Parameters.Add("@DocUploadedUserType", SqlDbType.VarChar).Value = DocUploadedUserType;
                myDataAdapter.SelectCommand.Parameters.Add("@IsDigiLocker", SqlDbType.VarChar).Value = IsDigiLocker;
                myDataAdapter.SelectCommand.Parameters.Add("@EnclTpeesign", SqlDbType.VarChar).Value = EnclTpeesign;
                myDataAdapter.SelectCommand.Parameters.Add("@QueryId", SqlDbType.VarChar).Value = QueryId;
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;

                myDataAdapter.SelectCommand.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                myDataAdapter.SelectCommand.Parameters["@Valid"].Direction = ParameterDirection.Output;
                myDataAdapter.SelectCommand.ExecuteNonQuery();

                valid = myDataAdapter.SelectCommand.Parameters["@Valid"].Value.ToString();
            }
            catch (Exception ex)
            {
                con.CloseConnection();
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return valid;
        }

        public int InsertIncentiveProceedingsUploads(string IncentiveID, string MstIncentiveId, string AttachmentId, string FileNm, string FilePath, string FileDescription, string DocUploadedUserType, string IsDigiLocker, string EnclTpeesign, string Createdby, string DLCNumber, string DLCDate)
        {
            try
            {
                con.OpenConnection();
                SqlDataAdapter myDataAdapter;
                myDataAdapter = new SqlDataAdapter("[USP_INSERT_Incentives_DOCUMENTS_PROCEEDINGS]", con.GetConnection);
                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                myDataAdapter.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
                myDataAdapter.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId;
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentId", SqlDbType.VarChar).Value = AttachmentId;
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = FileNm;
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath;
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription;
                myDataAdapter.SelectCommand.Parameters.Add("@DocUploadedUserType", SqlDbType.VarChar).Value = DocUploadedUserType;
                myDataAdapter.SelectCommand.Parameters.Add("@IsDigiLocker", SqlDbType.VarChar).Value = IsDigiLocker;
                myDataAdapter.SelectCommand.Parameters.Add("@EnclTpeesign", SqlDbType.VarChar).Value = EnclTpeesign;
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;

                myDataAdapter.SelectCommand.Parameters.Add("@MeetingNumber", SqlDbType.VarChar).Value = DLCNumber;
                myDataAdapter.SelectCommand.Parameters.Add("@MeetingDate", SqlDbType.VarChar).Value = DLCDate;

                int n = myDataAdapter.SelectCommand.ExecuteNonQuery();
                if (n > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                con.CloseConnection();
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }
        public string InsertStampDuty(StampDutyVo ObjStampDuty)
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
                com.CommandText = "Sp_INS_StampDuty";

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@incentiveid", ObjStampDuty.insentiveid);
                com.Parameters.AddWithValue("@NatureofAsset", ObjStampDuty.NatureofAsset);
                com.Parameters.AddWithValue("@LandPurchased", ObjStampDuty.LandPurchased);
                com.Parameters.AddWithValue("@PlinthBuilding", ObjStampDuty.PlinthBuilding);
                com.Parameters.AddWithValue("@FactoryBuildings", ObjStampDuty.FactoryBuildings);
                com.Parameters.AddWithValue("@Factoryappraisal", ObjStampDuty.Factoryappraisal);
                com.Parameters.AddWithValue("@TSPCB", ObjStampDuty.TSPCB);
                com.Parameters.AddWithValue("@NatureTransaction", ObjStampDuty.NatureTransaction);
                com.Parameters.AddWithValue("@SubRegistrar", ObjStampDuty.SubRegistrar);
                com.Parameters.AddWithValue("@StampDuty", ObjStampDuty.StampDuty);
                com.Parameters.AddWithValue("@StampExemption", ObjStampDuty.StampExemption);
                com.Parameters.AddWithValue("@Termloan", ObjStampDuty.Termloan);
                com.Parameters.AddWithValue("@CurrentClaim", ObjStampDuty.CurrentClaim);
                com.Parameters.AddWithValue("@createdby", ObjStampDuty.createdby);


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



        public DataSet GetIncentivesCaste(string createdby, string incentiveid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_INCENTIVES_CASTE", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (createdby != null)
                    da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = createdby.ToString();

                if (incentiveid != null)
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = incentiveid.ToString();
                else
                    da.SelectCommand.Parameters.Add("@INCENTIVEID", SqlDbType.VarChar).Value = null;

                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public void UpdateIncentivesCAFStatus(string incentiveid)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            //SqlCommand cmd = null;

            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_UPDATE_CAF_STATUS", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;



                if (incentiveid.Trim() == "" || incentiveid.Trim() == null)
                    da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = "%";
                else
                    da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = incentiveid.ToString();

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetAllIncentivesByid(string CreatedBy)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("[FetchIncentives_CAF_ID]", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = CreatedBy;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataSet GetAllIncentivesDeptView(string CreatedBy)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("[FetchIncentives_CAF_DEPT]", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = CreatedBy;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        public DataTable GetCAFdetails_DB(int IncentiveId, int createdby)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmdsrc = new SqlCommand("USP_GET_INCENTIVES_CAF_DATA", con);
                    cmdsrc.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                    cmdsrc.Parameters.AddWithValue("@createdby", createdby);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmdsrc);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public int InsertSlcFileUploading(string SlcNo, string AttachmentId, string FileNm, string FilePath, string FileDescription, string DocUploadedUserType, string IsDigiLocker, string EnclTpeesign, string Createdby, string QueryId,string Type)
        {
            int valid = 0;
            try
            {
                con.OpenConnection();
                SqlDataAdapter myDataAdapter;
                myDataAdapter = new SqlDataAdapter("USP_INSERT_SLC_AGENDA_DOCUMENTS", con.GetConnection);
                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                myDataAdapter.SelectCommand.Parameters.Add("@SlcNo", SqlDbType.VarChar).Value = SlcNo;
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentId", SqlDbType.VarChar).Value = AttachmentId;
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = FileNm;
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath;
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription;
                myDataAdapter.SelectCommand.Parameters.Add("@DocUploadedUserType", SqlDbType.VarChar).Value = DocUploadedUserType;
                myDataAdapter.SelectCommand.Parameters.Add("@IsDigiLocker", SqlDbType.VarChar).Value = IsDigiLocker;
                myDataAdapter.SelectCommand.Parameters.Add("@EnclTpeesign", SqlDbType.VarChar).Value = EnclTpeesign;
                myDataAdapter.SelectCommand.Parameters.Add("@QueryId", SqlDbType.VarChar).Value = QueryId;
                myDataAdapter.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;

                myDataAdapter.SelectCommand.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                myDataAdapter.SelectCommand.Parameters["@Valid"].Direction = ParameterDirection.Output;
                myDataAdapter.SelectCommand.ExecuteNonQuery();

                string Output = myDataAdapter.SelectCommand.Parameters["@Valid"].Value.ToString();
                if (!string.IsNullOrEmpty(Output))
                    valid = Convert.ToInt32(myDataAdapter.SelectCommand.Parameters["@Valid"].Value.ToString());
                else
                    valid = 0;
                //int n = myDataAdapter.SelectCommand.ExecuteNonQuery();
                //if (n >= -1)
                //{
                //    return 1;
                //}
                //else
                //{
                //    return 0;
                //}
            }
            catch (Exception ex)
            {
                con.CloseConnection();
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return valid;
        }
        public int InsertImageFileUploading(string IncentiveID, string SubIncentiveId, string FileNm, string FilePath, string FileDescription, string DocUploadedUserType, string IsDigiLocker, string EnclTpeesign, string Createdby, string AttachmentId)
        {
            int valid = 0;
            try
            {
                con.OpenConnection();
                SqlDataAdapter myDataAdapter;
                myDataAdapter = new SqlDataAdapter("USP_INSERT_DLO_IMAGE", con.GetConnection);
                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                myDataAdapter.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.VarChar).Value = IncentiveID;
                myDataAdapter.SelectCommand.Parameters.Add("@SubIncentiveId", SqlDbType.VarChar).Value = SubIncentiveId;
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentId", SqlDbType.VarChar).Value = AttachmentId;
                myDataAdapter.SelectCommand.Parameters.Add("@FileNm", SqlDbType.VarChar).Value = FileNm;
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath;
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription;
                myDataAdapter.SelectCommand.Parameters.Add("@DocUploadedUserType", SqlDbType.VarChar).Value = DocUploadedUserType;
                myDataAdapter.SelectCommand.Parameters.Add("@IsDigiLocker", SqlDbType.VarChar).Value = IsDigiLocker;
                myDataAdapter.SelectCommand.Parameters.Add("@EnclTpeesign", SqlDbType.VarChar).Value = EnclTpeesign;
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
                myDataAdapter.SelectCommand.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                myDataAdapter.SelectCommand.Parameters["@Valid"].Direction = ParameterDirection.Output;
                myDataAdapter.SelectCommand.ExecuteNonQuery();

                string Output = myDataAdapter.SelectCommand.Parameters["@Valid"].Value.ToString();
                if (!string.IsNullOrEmpty(Output))
                    valid = Convert.ToInt32(myDataAdapter.SelectCommand.Parameters["@Valid"].Value.ToString());
                else
                    valid = 0;
            }
            catch (Exception ex)
            {
                con.CloseConnection();
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
            return valid;
        }
        public DataSet GetBasicUnitDetails_Proforma_lettersPSR(string incentiveID, string MstIncentiveID)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_UNIT_DTLS_RECOMMENDATION_LETTERS_PSRNEW", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
                {
                    // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                    da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                }
                if (MstIncentiveID.ToString() != "" || MstIncentiveID.ToString() != null)
                {
                    da.SelectCommand.Parameters.Add("@MstIncentiveID", SqlDbType.VarChar).Value = MstIncentiveID;
                }

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }
        public string Encrypt(string strPassword, string EncKey)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(strPassword);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(EncKey,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);

        }
        private byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }


    }
}