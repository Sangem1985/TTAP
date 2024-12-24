using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TTAP.Classfiles
{
    public partial class CAFClass
    {
        #region Plant and Machinery
        public int InsertPlantandMachinery(PlantandMachinery pm, out string ERROR_MSG)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_I_PLANTANDMACHINERY]";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@PMId", pm.PMId);
                com.Parameters.AddWithValue("@IncentiveId", pm.IncentiveID);
                com.Parameters.AddWithValue("@MachineName", pm.MachineName);
                com.Parameters.AddWithValue("@VendorName", pm.VendorName);
                com.Parameters.AddWithValue("@TypeofMachineId", pm.TypeofMachineId);
                com.Parameters.AddWithValue("@InstalledMachinery", pm.InstalledMachinery);
                com.Parameters.AddWithValue("@ManufacturerName", pm.ManufacturerName);
                com.Parameters.AddWithValue("@InvoiceNo", pm.InvoiceNo);
                com.Parameters.AddWithValue("@InvoiceDate", pm.InvoiceDate);
                com.Parameters.AddWithValue("@MachineLandingDate", pm.MachineLandingDate);
                com.Parameters.AddWithValue("@VaivleNo", pm.VaivleNo);
                com.Parameters.AddWithValue("@VaivleDate", pm.VaivleDate);
                com.Parameters.AddWithValue("@IntiationDate", pm.IntiationDate);
                com.Parameters.AddWithValue("@MachineCost", pm.MachineCost);
                com.Parameters.AddWithValue("@ForeignMachineCost", pm.ForeignMachineCost);
                com.Parameters.AddWithValue("@EligilbiltyId", pm.EligilbiltyId);
                com.Parameters.AddWithValue("@CustomCountry", pm.CustomCountry);
                com.Parameters.AddWithValue("@CustomPaid", pm.CustomPaid);
                com.Parameters.AddWithValue("@Importduty", pm.Importduty);
                com.Parameters.AddWithValue("@Portcharges", pm.portcharges);
                com.Parameters.AddWithValue("@Statutorytaxes", pm.statutorytaxes);
                com.Parameters.AddWithValue("@ForeignCurrency", pm.ForeignCurrency);

                
                com.Parameters.AddWithValue("@MachinaryParts", pm.MachinaryParts);
                com.Parameters.AddWithValue("@InstalledMachinerytype", pm.InstalledMachinerytype);
                com.Parameters.AddWithValue("@AttachmentId2", pm.AttachmentId2);

                com.Parameters.AddWithValue("@ClassificationMachinery", pm.ClassificationMachinery);

                com.Parameters.AddWithValue("@ActualMachineCost", pm.ActualMachineCost);
                com.Parameters.AddWithValue("@FreightCharges", pm.FreightCharges);
                com.Parameters.AddWithValue("@TransportCharges", pm.TransportCharges);
                com.Parameters.AddWithValue("@Cgst", pm.Cgst);
                com.Parameters.AddWithValue("@Sgst", pm.Sgst);
                com.Parameters.AddWithValue("@Igst", pm.Igst);
                com.Parameters.AddWithValue("@Remarks", pm.Remarks);

                com.Parameters.Add("@ERROR_MSG", SqlDbType.VarChar, 500);
                com.Parameters["@ERROR_MSG"].Direction = ParameterDirection.Output;

                valid = com.ExecuteNonQuery();

                ERROR_MSG = com.Parameters["@ERROR_MSG"].Value.ToString();

                
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
        public int InsertPlantandMachineryExistUnit(PlantandMachinery pm,out string ERROR_MSG)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_I_PLANTANDMACHINERY_EXISTING_UNIT]";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@PMId", pm.PMId);
                com.Parameters.AddWithValue("@IncentiveId", pm.IncentiveID);
                com.Parameters.AddWithValue("@MachineName", pm.MachineName);
                com.Parameters.AddWithValue("@VendorName", pm.VendorName);
                com.Parameters.AddWithValue("@TypeofMachineId", pm.TypeofMachineId);
                com.Parameters.AddWithValue("@InstalledMachinery", pm.InstalledMachinery);
                com.Parameters.AddWithValue("@ManufacturerName", pm.ManufacturerName);
                com.Parameters.AddWithValue("@InvoiceNo", pm.InvoiceNo);
                com.Parameters.AddWithValue("@InvoiceDate", pm.InvoiceDate);
                com.Parameters.AddWithValue("@MachineLandingDate", pm.MachineLandingDate);
                com.Parameters.AddWithValue("@VaivleNo", pm.VaivleNo);
                com.Parameters.AddWithValue("@VaivleDate", pm.VaivleDate);
                com.Parameters.AddWithValue("@IntiationDate", pm.IntiationDate);
                com.Parameters.AddWithValue("@MachineCost", pm.MachineCost);
                com.Parameters.AddWithValue("@ForeignMachineCost", pm.ForeignMachineCost);
                com.Parameters.AddWithValue("@EligilbiltyId", pm.EligilbiltyId);
                com.Parameters.AddWithValue("@CustomCountry", pm.CustomCountry);
                com.Parameters.AddWithValue("@CustomPaid", pm.CustomPaid);
                com.Parameters.AddWithValue("@Importduty", pm.Importduty);
                com.Parameters.AddWithValue("@Portcharges", pm.portcharges);
                com.Parameters.AddWithValue("@Statutorytaxes", pm.statutorytaxes);
                com.Parameters.AddWithValue("@ForeignCurrency", pm.ForeignCurrency);

                com.Parameters.AddWithValue("@MachinaryParts", pm.MachinaryParts);
                com.Parameters.AddWithValue("@InstalledMachinerytype", pm.InstalledMachinerytype);

                com.Parameters.AddWithValue("@AttachmentId2", pm.AttachmentId2);
                com.Parameters.AddWithValue("@ClassificationMachinery", pm.ClassificationMachinery);

                com.Parameters.AddWithValue("@ActualMachineCost", pm.ActualMachineCost);
                com.Parameters.AddWithValue("@FreightCharges", pm.FreightCharges);
                com.Parameters.AddWithValue("@TransportCharges", pm.TransportCharges);
                com.Parameters.AddWithValue("@Cgst", pm.Cgst);
                com.Parameters.AddWithValue("@Sgst", pm.Sgst);
                com.Parameters.AddWithValue("@Igst", pm.Igst);
                com.Parameters.AddWithValue("@Remarks", pm.Remarks);

                com.Parameters.Add("@ERROR_MSG", SqlDbType.VarChar, 500);
                com.Parameters["@ERROR_MSG"].Direction = ParameterDirection.Output;

                valid = com.ExecuteNonQuery();

                ERROR_MSG = com.Parameters["@ERROR_MSG"].Value.ToString();

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
        public DataSet getEligibilityList()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da = new SqlDataAdapter("usp_r_getEligibilityList", con);
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
                con.Close();
            }
        }
        public DataSet getCurrencyList()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da = new SqlDataAdapter("USP_GET_CURRENCY_MASTER", con);
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
                con.Close();
            }
        }
        public DataSet getTechnicalTextileList()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da = new SqlDataAdapter("USP_GET_TechnicalTextile_Master", con);
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
                con.Close();
            }
        }
        public int DeletePlantandMachinery(int PMId, int IncentiveId)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_DeletePandMByPMId]";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@PMId", PMId);
                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                valid = com.ExecuteNonQuery();
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
        public int DeletePlantandMachineryExistUnit(int PMId, int IncentiveId)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_DeletePandMByPMId_ExistingUnit]";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@PMId", PMId);
                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                valid = com.ExecuteNonQuery();
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
        #region 1 of 18 tabs
        public string InsertCapitalAssistanceNewUnit(CapitalAssistanceforNewUnit cafnu)
        {
            string valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_I_INCENTIVE_CAF_NEWUNIT]";
                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@UserId", cafnu.UserId);
                com.Parameters.AddWithValue("@IncentiveId", cafnu.IncentiveID);
                com.Parameters.AddWithValue("@TypeofUnit", cafnu.TypeofUnit);
                com.Parameters.AddWithValue("@PurchasedLandExtent", cafnu.PurchasedLandExtent);
                com.Parameters.AddWithValue("@PurchasedLandValue", cafnu.PurchasedLandValue);
                com.Parameters.AddWithValue("@LeasedLandExtent", cafnu.LeasedLandExtent);
                com.Parameters.AddWithValue("@LeasedLandValue", cafnu.LeasedLandValue);

                com.Parameters.AddWithValue("@Buliding_Type", cafnu.Buliding_Type);

                com.Parameters.AddWithValue("@InheritedLandExtent", cafnu.InheritedLandExtent);
                com.Parameters.AddWithValue("@InheritedLandValue", cafnu.InheritedLandValue);
                com.Parameters.AddWithValue("@GovtLandExtent", cafnu.GovtLandExtent);
                com.Parameters.AddWithValue("@GovtLandValue", cafnu.GovtLandValue);
                com.Parameters.AddWithValue("@MainFactoryShedArea", cafnu.MainFactoryShedArea);
                com.Parameters.AddWithValue("@MainFactoryShedCost", cafnu.MainFactoryShedCost);
                com.Parameters.AddWithValue("@WarehouseArea", cafnu.WarehouseArea);
                com.Parameters.AddWithValue("@WarehouseCost", cafnu.WarehouseCost);
                com.Parameters.AddWithValue("@OfficeRoomArea", cafnu.OfficeRoomArea);
                com.Parameters.AddWithValue("@OfficeRoomCost", cafnu.OfficeRoomCost);
                com.Parameters.AddWithValue("@CoolingPondsArea", cafnu.CoolingPondsArea);
                com.Parameters.AddWithValue("@CoolingPondsCost", cafnu.CoolingPondsCost);
                com.Parameters.AddWithValue("@BoilerShedArea", cafnu.BoilerShedArea);
                com.Parameters.AddWithValue("@BoilerShedCost", cafnu.BoilerShedCost);
                com.Parameters.AddWithValue("@EffluentPondsArea", cafnu.EffluentPondsArea);
                com.Parameters.AddWithValue("@EffluentPondsCost", cafnu.EffluentPondsCost);
                com.Parameters.AddWithValue("@OverHeadTankArea", cafnu.OverHeadTankArea);
                com.Parameters.AddWithValue("@OverHeadTankCost", cafnu.OverHeadTankCost);
                com.Parameters.AddWithValue("@FencingArea", cafnu.FencingArea);
                com.Parameters.AddWithValue("@FencingCost", cafnu.FencingCost);
                com.Parameters.AddWithValue("@ArchitectFeeArea", cafnu.ArchitectFeeArea);
                com.Parameters.AddWithValue("@ArchitectFeeCost", cafnu.ArchitectFeeCost);
                com.Parameters.AddWithValue("@CompoundWallArea", cafnu.CompoundWallArea);
                com.Parameters.AddWithValue("@CompoundWallCost", cafnu.CompoundWallCost);
                com.Parameters.AddWithValue("@WorksersHouseArea", cafnu.WorksersHouseArea);
                com.Parameters.AddWithValue("@WorkersHouseCost", cafnu.WorkersHouseCost);
                com.Parameters.AddWithValue("@CanteenArea", cafnu.CanteenArea);
                com.Parameters.AddWithValue("@CanteenCost", cafnu.CanteenCost);
                com.Parameters.AddWithValue("@RestHouseArea", cafnu.RestHouseArea);
                com.Parameters.AddWithValue("@RestHouseCost", cafnu.RestHouseCost);
                com.Parameters.AddWithValue("@TimeOfficeArea", cafnu.TimeOfficeArea);
                com.Parameters.AddWithValue("@TimeOfficeCost", cafnu.TimeOfficeCost);
                com.Parameters.AddWithValue("@VehicleStandArea", cafnu.VehicleStandArea);
                com.Parameters.AddWithValue("@VehicleStandCost", cafnu.VehicleStandCost);
                com.Parameters.AddWithValue("@SecurityShedArea", cafnu.SecurityShedArea);
                com.Parameters.AddWithValue("@SecurityShedCost", cafnu.SecurityShedCost);
                com.Parameters.AddWithValue("@ToiletArea", cafnu.ToiletArea);
                com.Parameters.AddWithValue("@ToiletCost", cafnu.ToiletCost);
                com.Parameters.AddWithValue("@RoadsArea", cafnu.RoadsArea);
                com.Parameters.AddWithValue("@RoadsCost", cafnu.RoadsCost);
                //com.Parameters.AddWithValue("@Detailedproject", cafnu.Detailedproject);
                //com.Parameters.AddWithValue("@ApprovalofProject", cafnu.ApprovalofProject);
                //com.Parameters.AddWithValue("@ProjectCompletion", cafnu.ProjectCompletion);
                //com.Parameters.AddWithValue("@Declarationstating", cafnu.Declarationstating);
                //com.Parameters.AddWithValue("@linedepartment", cafnu.linedepartment);
                //com.Parameters.AddWithValue("@Documentsevidencing", cafnu.Documentsevidencing);
                com.Parameters.AddWithValue("@CurrentClaimAmount", cafnu.CurrentClaimAmount);

                com.Parameters.AddWithValue("@LaboratoriesforResearchQualityControl", cafnu.LaboratoriesforResearchQualityControl);
                com.Parameters.AddWithValue("@UtilitiesPowerWater", cafnu.UtilitiesPowerWater);
                com.Parameters.AddWithValue("@OtherFixedAssets", cafnu.OtherFixedAssets);
                com.Parameters.AddWithValue("@Total", cafnu.Total);
                com.Parameters.AddWithValue("@AmountAvailed", cafnu.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", cafnu.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", cafnu.DateAvailed);
                com.Parameters.AddWithValue("@SavingFrom", cafnu.SavingFrom);

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
        #region 3 of 18 tabs
        public string InsertTermLoanAvailed(TermLoanAvaied tla)
        {
            string valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_I_INCENTIVE_TERMLOANAVAILED]";
                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@ISId", tla.ISId);
                com.Parameters.AddWithValue("@IncentiveId", tla.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", tla.SubIncentiveId);
                com.Parameters.AddWithValue("@BankId", tla.BankId);
                com.Parameters.AddWithValue("@BankName", tla.BankName);
                com.Parameters.AddWithValue("@BranchName", tla.BranchName);
                com.Parameters.AddWithValue("@IFSCode", tla.IFSCode);
                com.Parameters.AddWithValue("@LoanAccNo", tla.LoanAccNo);
                com.Parameters.AddWithValue("@SanctionOrderNo", tla.SanctionOrderNo);
                com.Parameters.AddWithValue("@SanctionOrderDate", tla.SanctionOrderDate);
                com.Parameters.AddWithValue("@SanctionedAmount", tla.SanctionedAmount);
                com.Parameters.AddWithValue("@ReleasedDate", tla.ReleasedDate);
                com.Parameters.AddWithValue("@TransType", tla.TransType);
                com.Parameters.AddWithValue("@Created_by", tla.Created_by);

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
        public string InsertTermLoanRepaid(TermLoanRepaid tlr)
        {
            string valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_I_TERMLOANREPAID]";
                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@TLRId", tlr.TLRId);
                com.Parameters.AddWithValue("@IncentiveId", tlr.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", tlr.SubIncentiveId);
                /*com.Parameters.AddWithValue("@FinYear", tlr.FinYear);
                com.Parameters.AddWithValue("@HalfFinYear", tlr.HalfFinYear); Not in New Version (Commemnted on 11-05-2023) */
                com.Parameters.AddWithValue("@BankId", tlr.BankId);
                com.Parameters.AddWithValue("@BankName", tlr.BankName);
                com.Parameters.AddWithValue("@PrincipalAmt", tlr.PrincipalAmt);
                com.Parameters.AddWithValue("@RateOfInterest", tlr.RateOfInterest); 
                com.Parameters.AddWithValue("@InterestAmt", tlr.InterestAmt);
                com.Parameters.AddWithValue("@PaymentDate", tlr.PaymentDate);
                /*added on 11-05-2023*/
                com.Parameters.AddWithValue("@TermLoanNo", tlr.TermLoanNo);
                com.Parameters.AddWithValue("@AccountNo", tlr.AccountNo); 
                com.Parameters.AddWithValue("@OpeningBalanceStartofHalfYear", tlr.OpeningBalanceStartofHalfYear);
                com.Parameters.AddWithValue("@ClosingBalanceEndofHalfYear", tlr.ClosingBalanceEndofHalfYear);
                /**/
                com.Parameters.AddWithValue("@TransType", tlr.TransType);
                com.Parameters.AddWithValue("@Created_by", tlr.Created_by);

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
        public string InsertTotalTermLoanRepaid(TotalTermLoanRepaid tlr)
        {
            string valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_I_TOTALTERMLOANREPAID]";
                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@TTLRId", tlr.TTLRId);
                com.Parameters.AddWithValue("@IncentiveId", tlr.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", tlr.SubIncentiveId);
                com.Parameters.AddWithValue("@BankId", tlr.BankId);
                com.Parameters.AddWithValue("@TotalNoofInstallments", tlr.TotalNoofInstallments);
                com.Parameters.AddWithValue("@InstallmentAmount", tlr.InstallmentAmount);
                com.Parameters.AddWithValue("@TotalAmountRepaid", tlr.TotalAmountRepaid);
                com.Parameters.AddWithValue("@TransType", tlr.TransType);
                com.Parameters.AddWithValue("@Created_by", tlr.Created_by);

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
        public int InsertInterestSubsidy(InterestSubsidy1 isd)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_I_INCENTIVE_INTERESTSUBSIDY]";
                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@IncentiveId", isd.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", isd.SubIncentiveId);
                com.Parameters.AddWithValue("@CCP_From", isd.CCP_From);
                com.Parameters.AddWithValue("@CCP_To", isd.CCP_To);
                com.Parameters.AddWithValue("@CCP_Type", isd.CCP_Type);
                com.Parameters.AddWithValue("@CCA", isd.CCA);
                com.Parameters.AddWithValue("@IsMoratorium", isd.IsMoratorium);
                com.Parameters.AddWithValue("@IsOtherAgency", isd.IsOtherAgency);
                com.Parameters.AddWithValue("@AmountAvailed", isd.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", isd.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", isd.DateAvailed);

                valid = com.ExecuteNonQuery();
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
        public int InsertOfficerQuery(int IncentiveId,int SubIncentiveId,int UserId,string Query)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_INSERT_QUERY]";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);
                com.Parameters.AddWithValue("@FromUser", UserId);
                com.Parameters.AddWithValue("@OfficerQuery", Query);
                valid = com.ExecuteNonQuery();
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
        public int ScheduleInspection(int IncentiveId, int SubIncentiveId, int UserId, string ScheduleDate)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_SCHEDULE_INSPECTION]";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);
                com.Parameters.AddWithValue("@OfficerId", UserId);
                com.Parameters.AddWithValue("@SchduledDate", ScheduleDate);
                valid = com.ExecuteNonQuery();
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


        public string ValidateMandatoryAttachments(string IncentiveId, string SubIncentiveId)
        {
            string Message;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_CHECK_MANDATORY_ATTACHMENTS]";
                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@IncentveID", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 1000);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Message = com.Parameters["@Valid"].Value.ToString();

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
            return Message;
        }

        public int InsertGrossBlackPlantandMachinery(PlantandMachineryGrossBlock pm, out string ERROR_MSG)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_PM_GROSSBLOCK_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@GBId", pm.GBId);
                com.Parameters.AddWithValue("@IncentiveId", pm.IncentiveID);
                com.Parameters.AddWithValue("@AuditedBalanceSheetYear", pm.AuditedBalanceSheetYear);
                com.Parameters.AddWithValue("@AmountGrossBlock", pm.AmountGrossBlock);
                com.Parameters.AddWithValue("@CertifiedBy", pm.CertifiedBy);
                com.Parameters.AddWithValue("@CertifiedDate", pm.CertifiedDate);
                com.Parameters.AddWithValue("@TransType", pm.TransType);
                com.Parameters.AddWithValue("@Created_by", pm.Created_by);
                com.Parameters.AddWithValue("@AttachmentId2", pm.AttachmentId2);

                com.Parameters.Add("@ERROR_MSG", SqlDbType.VarChar, 500);
                com.Parameters["@ERROR_MSG"].Direction = ParameterDirection.Output;

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                ERROR_MSG = com.Parameters["@ERROR_MSG"].Value.ToString();
                valid = Convert.ToInt32(com.Parameters["@Valid"].Value.ToString());

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

        public int InsertPMPaymentDetails(PMPaymentProofs pm, out string ERROR_MSG)
        {
            int valid;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_PM_TRANSACTION_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@PMPFId", pm.PMPFId);
                com.Parameters.AddWithValue("@PMTMId", pm.PMTMId);
                com.Parameters.AddWithValue("@IncentiveId", pm.IncentiveID);
                com.Parameters.AddWithValue("@PMId", pm.PMId);
                com.Parameters.AddWithValue("@PMRegTrnsactionID", pm.PMRegTrnsactionID);
                com.Parameters.AddWithValue("@PMTrnsactionID", pm.PMTrnsactionID);
                com.Parameters.AddWithValue("@TrnsactionDate", pm.TrnsactionDate);
                com.Parameters.AddWithValue("@Remittingbank", pm.Remittingbank);
                com.Parameters.AddWithValue("@Beneficiarybank", pm.Beneficiarybank);
                com.Parameters.AddWithValue("@TrnsactionAmount", pm.TrnsactionAmount);
                com.Parameters.AddWithValue("@PMAmount", pm.PMTrnsactionMachinaryCost); 
                com.Parameters.AddWithValue("@AttachmentId", pm.AttachmentId);
                com.Parameters.AddWithValue("@TransType", pm.TransType);
                com.Parameters.AddWithValue("@Created_by", pm.Created_by);

                com.Parameters.AddWithValue("@Industry_Type", pm.Industry_Type);

                com.Parameters.Add("@ERROR_MSG", SqlDbType.VarChar, 500);
                com.Parameters["@ERROR_MSG"].Direction = ParameterDirection.Output;

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                ERROR_MSG = com.Parameters["@ERROR_MSG"].Value.ToString();
                valid = Convert.ToInt32(com.Parameters["@Valid"].Value.ToString());

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