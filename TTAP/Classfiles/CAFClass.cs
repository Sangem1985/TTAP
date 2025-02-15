using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace TTAP.Classfiles
{
    public partial class CAFClass
    {
        string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        private SqlConnection ConNew = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);


        public string InsertIncentivCommonDataTAB1(IncentivesVOs objvo1)
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
                com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON_NEW]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);
                com.Parameters.AddWithValue("@Uid_NO", objvo1.Uid_NO);
                com.Parameters.AddWithValue("@SectorID", objvo1.sector);
                com.Parameters.AddWithValue("@UnitName", objvo1.UnitName);
                com.Parameters.AddWithValue("@CountryOrigin", objvo1.CountryOrigin);
                //com.Parameters.AddWithValue("@TextileProcessType", objvo1.TextileProcessType);
                com.Parameters.AddWithValue("@DateOfIncorporation", objvo1.DateOfIncorporation);
                com.Parameters.AddWithValue("@IncorpRegistranNumber", objvo1.IncorpRegistranNumber);
                com.Parameters.AddWithValue("@TinNO", objvo1.TinNO);
                com.Parameters.AddWithValue("@PanNo", objvo1.PanNo);

                com.Parameters.AddWithValue("@EMiUdyogAadhar", objvo1.EMiUdyogAadhar);
                com.Parameters.AddWithValue("@UdyogAadharRegdDate", objvo1.UdyogAadharRegdDate);

                //com.Parameters.AddWithValue("@DCP", objvo1.DateOfComm);
                com.Parameters.AddWithValue("@OrgType", objvo1.TypeofOrg);

                com.Parameters.AddWithValue("@SocialStatus", Convert.ToInt32(objvo1.SocialStatus));
                com.Parameters.AddWithValue("@SubCaste", objvo1.SubCaste);
                com.Parameters.AddWithValue("@ApplicantName", objvo1.ApplciantName);
                com.Parameters.AddWithValue("@Gender", objvo1.Gender);
                com.Parameters.AddWithValue("@YearsOfExpinTexttile", objvo1.YearsOfExpinTexttile);
                com.Parameters.AddWithValue("@IsDifferentlyAbled", objvo1.IsDifferentlyAbled);
                com.Parameters.AddWithValue("@TypeofTexttile", objvo1.TypeofTexttile);


                com.Parameters.AddWithValue("@UnitState", objvo1.UnitState);
                com.Parameters.AddWithValue("@UnitDIst", objvo1.UnitDIst);
                com.Parameters.AddWithValue("@UnitMandal", objvo1.UnitMandal);
                com.Parameters.AddWithValue("@UnitVill", objvo1.UnitVill);
                com.Parameters.AddWithValue("@UnitStreet", objvo1.UnitStreet);
                com.Parameters.AddWithValue("@UnitHNO", objvo1.UnitHNO);
                com.Parameters.AddWithValue("@UnitMObileNo", objvo1.UnitMObileNo);
                com.Parameters.AddWithValue("@UnitEmail", objvo1.UnitEmail);
                com.Parameters.AddWithValue("@AadharNumber", objvo1.AadharNumber);


                com.Parameters.AddWithValue("@OffcState", objvo1.OffcState);
                com.Parameters.AddWithValue("@OffcOtherDist", objvo1.OffcOtherDist);
                com.Parameters.AddWithValue("@OffcOtherMandal", objvo1.OffcOtherMandal);
                com.Parameters.AddWithValue("@OffcOtherVillage", objvo1.OffcOtherVillage);
                com.Parameters.AddWithValue("@OffcDIst", objvo1.OffcDIst);

                com.Parameters.AddWithValue("@OffcMandal", objvo1.OffcMandal);
                com.Parameters.AddWithValue("@OffcVill", objvo1.OffcVil);
                com.Parameters.AddWithValue("@OffcHNO", objvo1.OffcHNO);
                com.Parameters.AddWithValue("@OffcStreet", objvo1.OffcStreet);
                com.Parameters.AddWithValue("@OffcEmail", objvo1.OffcEmail);
                com.Parameters.AddWithValue("@OffcMobileNO", objvo1.OffcMobileNO);
                com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);


                com.Parameters.AddWithValue("@IdsustryType", objvo1.IdsustryStatus);
                com.Parameters.AddWithValue("@ExistEnterpriseLand", objvo1.ExistEnterpriseLand);
                com.Parameters.AddWithValue("@ExpansionDiversificationLand", objvo1.ExpansionDiversificationLand);
                com.Parameters.AddWithValue("@ExistEnterpriseBuilding", objvo1.ExistEnterpriseBuilding);
                com.Parameters.AddWithValue("@ExpDiversBuilding", objvo1.ExpDiversBuilding);
                com.Parameters.AddWithValue("@ExistEnterprisePlantMachinery", objvo1.ExistEnterprisePlantMachinery);
                com.Parameters.AddWithValue("@ExpDiversPlantMachinery", objvo1.ExpDiversPlantMachinery);
                com.Parameters.AddWithValue("@ManagementStaffFemale", objvo1.ManagementStaffFemale);
                com.Parameters.AddWithValue("@ManagementStaffMale", objvo1.ManagementStaffMale);
                com.Parameters.AddWithValue("@ManagementStaffMaleindirect", objvo1.ManagementStaffMaleindirect);
                com.Parameters.AddWithValue("@ManagementStaffFemaleindirect", objvo1.ManagementStaffFemaleindirect);

                com.Parameters.AddWithValue("@IpassLand", objvo1.IpassLand);
                com.Parameters.AddWithValue("@IpassBuilding", objvo1.IpassBuilding);
                com.Parameters.AddWithValue("@IpassPlantMachine", objvo1.IpassPlantMachine);
                com.Parameters.AddWithValue("@IpassLandExp", objvo1.IpassLandExp);
                com.Parameters.AddWithValue("@IpassBuildingExp", objvo1.IpassBuildingExp);
                com.Parameters.AddWithValue("@IpassPlantMachineExp", objvo1.IpassPlantMachineExp);

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
        public string InsertLineOfActivityDtlsTAB2(IndustryLineofActivities objNewInds)
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
                com.CommandText = "[USP_INS_LINEOFACTIVITY_NEWINDUSTRY]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Line_of_Activity_Id", objNewInds.slno);
                com.Parameters.AddWithValue("@LineOfActivity", objNewInds.LineOfActivity);
                com.Parameters.AddWithValue("@InstalledCapacity", objNewInds.InstalledCapacity);
                com.Parameters.AddWithValue("@Unit", objNewInds.Unit);
                com.Parameters.AddWithValue("@ValuePerUnit", objNewInds.ValuePerUnitRs);
                com.Parameters.AddWithValue("@ValueRs", objNewInds.ValueRs);
                com.Parameters.AddWithValue("@LOAType", objNewInds.LOAType);
                com.Parameters.AddWithValue("@IncentiveId", objNewInds.IncentiveId);
                com.Parameters.AddWithValue("@Created_by", objNewInds.Created_by);
                com.Parameters.AddWithValue("@TransType", objNewInds.TransType);


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
        public string InsertDirectorDetailsTAB2(IndustryPartnerDtls VosPartner)
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
                com.CommandText = "[USP_INS_Director_Partner_Dtls]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Director_Partner_ID", VosPartner.Slno);
                com.Parameters.AddWithValue("@Incentive_id", VosPartner.IncentiveId);
                com.Parameters.AddWithValue("@DirectorName", VosPartner.Name);
                com.Parameters.AddWithValue("@Designation", VosPartner.Designation);
                com.Parameters.AddWithValue("@Qualification", VosPartner.EducationalQual);
                com.Parameters.AddWithValue("@QualificationOther", VosPartner.EducationalQualOther);
                com.Parameters.AddWithValue("@YearsofExperience", VosPartner.YearsOfExpinTexttileDirector);
                com.Parameters.AddWithValue("@Share", VosPartner.Share);
                com.Parameters.AddWithValue("@PANNumber", VosPartner.PanNO);
                com.Parameters.AddWithValue("@MobileNumber", VosPartner.MobileNo);
                com.Parameters.AddWithValue("@EmailId", VosPartner.Email);
                com.Parameters.AddWithValue("@CreatedBy", VosPartner.Created_by);
                com.Parameters.AddWithValue("@TransType", VosPartner.TransType);

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
        public string InsertIncentivCommonDataTAB2(IncentivesVOs objvo1)
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
                com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON_NEW]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);
                com.Parameters.AddWithValue("@IdsustryType", objvo1.IdsustryStatus);
                com.Parameters.AddWithValue("@IndustryExpansionType", objvo1.IndustryExpansionType);
                com.Parameters.AddWithValue("@TextileProcessType", objvo1.TextileProcessType);
                com.Parameters.AddWithValue("@DCP", objvo1.DateOfComm);
                com.Parameters.AddWithValue("@TextileProcessTypeExp", objvo1.TextileProcessTypeExp);
                com.Parameters.AddWithValue("@DCPExp", objvo1.DateOfCommExp);

                com.Parameters.AddWithValue("@NewOtherTextileProcessType", objvo1.NewOtherTextileProcessType);
                com.Parameters.AddWithValue("@ExistOtherTextileProcessType", objvo1.ExistOtherTextileProcessType);

                com.Parameters.AddWithValue("@AuthorisedPerson", objvo1.AuthorisedSignatory);
                com.Parameters.AddWithValue("@AuthorisedSignatoryDesignation", objvo1.AuthorisedSignatoryDesignationValue);
                com.Parameters.AddWithValue("@Authorized_PAN_NO", objvo1.Authorized_PAN_NO);
                com.Parameters.AddWithValue("@Authorized_EmailId", objvo1.Authorized_EmailId);
                com.Parameters.AddWithValue("@Authorized_MobileNo", objvo1.Authorized_MobileNo);
                com.Parameters.AddWithValue("@Authorized_CorresponAdderess", objvo1.Authorized_CorresponAdderess);


                com.Parameters.AddWithValue("@SpecialIncentiveYN", objvo1.SpecialIncentiveYN);
                com.Parameters.AddWithValue("@GovermentOrderNumber", objvo1.GovermentOrderNumber);
                com.Parameters.AddWithValue("@GovermentOrderDate", objvo1.GovermentOrderDate);
                com.Parameters.AddWithValue("@TechnicalTextileType", objvo1.TechnicalTextileType);

                com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
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
        public string InsertTearmLoanDtlsTAB3(IndustryTermLoanDtls VoTermLoandtls)
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
                com.CommandText = "USP_INS_TERMLOANDTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@TermLoanId", VoTermLoandtls.TermLoanId);
                com.Parameters.AddWithValue("@AvailedTermLoan", VoTermLoandtls.AvailedTermLoan);
                com.Parameters.AddWithValue("@TermLoanApplDate", VoTermLoandtls.TermLoanApplDate);
                com.Parameters.AddWithValue("@InstitutionName", VoTermLoandtls.InstitutionName);
                com.Parameters.AddWithValue("@TermLoanSancRefNo", VoTermLoandtls.TermLoanSancRefNo);
                com.Parameters.AddWithValue("@TermloanSandate", VoTermLoandtls.TermloanSandate);
                com.Parameters.AddWithValue("@TermLoanReleaseddate", VoTermLoandtls.TermLoanReleaseddate);

                com.Parameters.AddWithValue("@Installments", VoTermLoandtls.Installments);
                com.Parameters.AddWithValue("@RateOfInterest", VoTermLoandtls.RateOfInterest);
                com.Parameters.AddWithValue("@SanctionedAmount", VoTermLoandtls.SanctionedAmount);
                com.Parameters.AddWithValue("@TermLoanPeriodFromDate", VoTermLoandtls.TermLoanPeriodFromDate);
                com.Parameters.AddWithValue("@TermLoanPeriodToDate", VoTermLoandtls.TermLoanPeriodToDate);

                com.Parameters.AddWithValue("@IncentiveId", VoTermLoandtls.IncentiveId);
                com.Parameters.AddWithValue("@Created_by", VoTermLoandtls.Created_by);
                com.Parameters.AddWithValue("@TransType", VoTermLoandtls.TransType);

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
        public string InsertIncentivCommonDataTAB3(IncentivesVOs objvo1)
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
                com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON_NEW]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);

                com.Parameters.AddWithValue("@ManagementStaffMale", objvo1.ManagementStaffMale);
                com.Parameters.AddWithValue("@ManagementStaffFemale", objvo1.ManagementStaffFemale);
                com.Parameters.AddWithValue("@SupervisoryMale", objvo1.SupervisoryMale);
                com.Parameters.AddWithValue("@SupervisoryFemale", objvo1.SupervisoryFemale);
                com.Parameters.AddWithValue("@SkilledWorkersMale", objvo1.SkilledWorkersMale);
                com.Parameters.AddWithValue("@SkilledWorkersFemale", objvo1.SkilledWorkersFemale);
                com.Parameters.AddWithValue("@SemiSkilledWorkersMale", objvo1.SemiSkilledWorkersMale);
                com.Parameters.AddWithValue("@SemiSkilledWorkersFemale", objvo1.SemiSkilledWorkersFemale);

                com.Parameters.AddWithValue("@ManagementStaffMaleNonLocal", objvo1.ManagementStaffMaleNonLocal);
                com.Parameters.AddWithValue("@ManagementStaffFemaleNonLocal", objvo1.ManagementStaffFemaleNonLocal);
                com.Parameters.AddWithValue("@SupervisoryMaleNonLocal", objvo1.SupervisoryMaleNonLocal);
                com.Parameters.AddWithValue("@SupervisoryFemaleNonLocal", objvo1.SupervisoryFemaleNonLocal);
                com.Parameters.AddWithValue("@SkilledWorkersMaleNonLocal", objvo1.SkilledWorkersMaleNonLocal);
                com.Parameters.AddWithValue("@SkilledWorkersFemaleNonLocal", objvo1.SkilledWorkersFemaleNonLocal);
                com.Parameters.AddWithValue("@SemiSkilledWorkersMaleNonLocal", objvo1.SemiSkilledWorkersMaleNonLocal);
                com.Parameters.AddWithValue("@SemiSkilledWorkersFemaleNonLocal", objvo1.SemiSkilledWorkersFemaleNonLocal);
                com.Parameters.AddWithValue("@ManagementStaffFemaleindirect", objvo1.ManagementStaffFemaleindirect);
                com.Parameters.AddWithValue("@SupervisoryFemaleindirect", objvo1.SupervisoryFemaleindirect);
                com.Parameters.AddWithValue("@SkilledWorkersFemaleindirect", objvo1.SkilledWorkersFemaleindirect);
                com.Parameters.AddWithValue("@SemiSkilledWorkersMaleindirect", objvo1.SemiSkilledWorkersMaleindirect);
                com.Parameters.AddWithValue("@ManagementStaffMaleindirect", objvo1.ManagementStaffMaleindirect);
                com.Parameters.AddWithValue("@SupervisoryMaleindirect", objvo1.SupervisoryMaleindirect);
                com.Parameters.AddWithValue("@SkilledWorkersMaleindirect", objvo1.SkilledWorkersMaleindirect);
                com.Parameters.AddWithValue("@SemiSkilledWorkersFemaleindirect", objvo1.SemiSkilledWorkersFemaleindirect);

                com.Parameters.AddWithValue("@EmpDirectLocalMaleOther", objvo1.EmpDirectLocalMaleOther);
                com.Parameters.AddWithValue("@EmpDirectLocalFemaleOther", objvo1.EmpDirectLocalFemaleOther);
                com.Parameters.AddWithValue("@EmpDirectNonLocalMaleOther", objvo1.EmpDirectNonLocalMaleOther);
                com.Parameters.AddWithValue("@EmpDirectNonLocalFemaleOther", objvo1.EmpDirectNonLocalFemaleOther);
                com.Parameters.AddWithValue("@EmpIndirectMaleOther", objvo1.EmpIndirectMaleOther);
                com.Parameters.AddWithValue("@EmpIndirectFemaleOther", objvo1.EmpIndirectFemaleOther);

                com.Parameters.AddWithValue("@ExistEnterpriseLand", objvo1.ExistEnterpriseLand);
                com.Parameters.AddWithValue("@ExpansionDiversificationLand", objvo1.ExpansionDiversificationLand);
                com.Parameters.AddWithValue("@LandFixedCapitalInvestPercentage", objvo1.LandFixedCapitalInvestPercentage);
                com.Parameters.AddWithValue("@ExistEnterpriseBuilding", objvo1.ExistEnterpriseBuilding);
                com.Parameters.AddWithValue("@ExpDiversBuilding", objvo1.ExpDiversBuilding);
                com.Parameters.AddWithValue("@BuildingFixedCapitalInvestPercentage", objvo1.BuildingFixedCapitalInvestPercentage);
                com.Parameters.AddWithValue("@ExistEnterprisePlantMachinery", objvo1.ExistEnterprisePlantMachinery);
                com.Parameters.AddWithValue("@ExpDiversPlantMachinery", objvo1.ExpDiversPlantMachinery);
                com.Parameters.AddWithValue("@PlantMachFixedCapitalInvestPercentage", objvo1.PlantMachFixedCapitalInvestPercentage);

                com.Parameters.AddWithValue("@IpassLand", objvo1.IpassLand);
                com.Parameters.AddWithValue("@IpassBuilding", objvo1.IpassBuilding);
                com.Parameters.AddWithValue("@IpassPlantMachine", objvo1.IpassPlantMachine);
                com.Parameters.AddWithValue("@IpassLandExp", objvo1.IpassLandExp);
                com.Parameters.AddWithValue("@IpassBuildingExp", objvo1.IpassBuildingExp);
                com.Parameters.AddWithValue("@IpassPlantMachineExp", objvo1.IpassPlantMachineExp);

                com.Parameters.AddWithValue("@OtherFixedCapital", objvo1.OtherFixedCapital);
                com.Parameters.AddWithValue("@OtherFixedCapitalExp", objvo1.OtherFixedCapitalExp);
                com.Parameters.AddWithValue("@OtherFixedCapitalPercentage", objvo1.OtherFixedCapitalPercentage);

                com.Parameters.AddWithValue("@CurrentInvestmentLandvalue", objvo1.CurrentInvestmentLandvalue);
                com.Parameters.AddWithValue("@CurrentInvestmentBuildingvalue", objvo1.CurrentInvestmentBuildingvalue);
                com.Parameters.AddWithValue("@CurrentInvestmentplantMechValue", objvo1.CurrentInvestmentplantMechValue);
                com.Parameters.AddWithValue("@CurrentInvestmentOtherValue", objvo1.CurrentInvestmentOtherValue);

                com.Parameters.AddWithValue("@Category", objvo1.Category);
                com.Parameters.AddWithValue("@IsPowerApplicable", objvo1.IsPowerApplicable);
                com.Parameters.AddWithValue("@IsPowerApplicableValues", objvo1.IsPowerApplicableValues);
                com.Parameters.AddWithValue("@IsWaterSourceApplicable", objvo1.IsWaterSourceApplicable);
                com.Parameters.AddWithValue("@IsWaterSourceApplicableValues", objvo1.IsWaterSourceApplicableValues);
                com.Parameters.AddWithValue("@NewPowerReleaseDate", objvo1.NewPowerReleaseDate);
                com.Parameters.AddWithValue("@NewConnectedLoad", objvo1.NewConnectedLoad);
                com.Parameters.AddWithValue("@NewContractedLoad", objvo1.NewContractedLoad);
                com.Parameters.AddWithValue("@NewServiceRateUnit", objvo1.NewServiceRateUnit);
                com.Parameters.AddWithValue("@ExistingPowerReleaseDate", objvo1.ExistingPowerReleaseDate);
                com.Parameters.AddWithValue("@ExistingConnectedLoad", objvo1.ExistingConnectedLoad);
                com.Parameters.AddWithValue("@ExistingContractedLoad", objvo1.ExistingContractedLoad);
                com.Parameters.AddWithValue("@ExistingServiceRateUnit", objvo1.ExistingServiceRateUnit);
                com.Parameters.AddWithValue("@ExpanDiverPowerReleaseDate", objvo1.ExpanDiverPowerReleaseDate);
                com.Parameters.AddWithValue("@ExpanDiverConnectedLoad", objvo1.ExpanDiverConnectedLoad);
                com.Parameters.AddWithValue("@ExpanDiverContractedLoad", objvo1.ExpanDiverContractedLoad);
                com.Parameters.AddWithValue("@ExpanServiceRateUnit", objvo1.ExpanServiceRateUnit);

                com.Parameters.AddWithValue("@NewPowerUniqueID", objvo1.NewPowerUniqueID);
                com.Parameters.AddWithValue("@NewPowerCompany", objvo1.NewPowerCompany);
                com.Parameters.AddWithValue("@ExistingPowerUniqueID", objvo1.ExistingPowerUniqueID);
                com.Parameters.AddWithValue("@ExistingPowerCompany", objvo1.ExistingPowerCompany);
                com.Parameters.AddWithValue("@ExpanDiverPowerUniqueID", objvo1.ExpanDiverPowerUniqueID);
                com.Parameters.AddWithValue("@ExpanDiverPowerCompany", objvo1.ExpanDiverPowerCompany);

                com.Parameters.AddWithValue("@waterSource", objvo1.waterSource);
                com.Parameters.AddWithValue("@waterRequirement", objvo1.waterRequirement);
                com.Parameters.AddWithValue("@waterRateperunit", objvo1.waterRateperunit);

                com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
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
        public string InsertIncentivCommonDataTAB4(IncentivesVOs objvo1)
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
                com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON_NEW]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);

                com.Parameters.AddWithValue("@TurnOver_1stYear", objvo1.TurnOver_1stYear);
                com.Parameters.AddWithValue("@TurnOver_2ndYear", objvo1.TurnOver_2ndYear);
                com.Parameters.AddWithValue("@TurnOver_3rdYear", objvo1.TurnOver_3rdYear);
                com.Parameters.AddWithValue("@EBITDA_1stYear", objvo1.EBITDA_1stYear);
                com.Parameters.AddWithValue("@EBITDA_2ndYear", objvo1.EBITDA_2ndYear);
                com.Parameters.AddWithValue("@EBITDA_3rdYear", objvo1.EBITDA_3rdYear);
                com.Parameters.AddWithValue("@Networth_1stYear", objvo1.Networth_1stYear);
                com.Parameters.AddWithValue("@Networth_2ndYear", objvo1.Networth_2ndYear);
                com.Parameters.AddWithValue("@Networth_3rdYear", objvo1.Networth_3rdYear);
                com.Parameters.AddWithValue("@ReservesSurplus_1stYear", objvo1.ReservesSurplus_1stYear);
                com.Parameters.AddWithValue("@ReservesSurplus_2ndYear", objvo1.ReservesSurplus_2ndYear);
                com.Parameters.AddWithValue("@ReservesSurplus_3rdYear", objvo1.ReservesSurplus_3rdYear);
                com.Parameters.AddWithValue("@Share_Capital_1stYear", objvo1.Share_Capital_1stYear);
                com.Parameters.AddWithValue("@Share_Capital_2ndYear", objvo1.Share_Capital_2ndYear);
                com.Parameters.AddWithValue("@Share_Capital_3rdYear", objvo1.Share_Capital_3rdYear);

                com.Parameters.AddWithValue("@ProductionYear1", objvo1.ProductionYear1);
                com.Parameters.AddWithValue("@ProductionQuantity1", objvo1.ProductionQuantity1);
                com.Parameters.AddWithValue("@ProductionValue1", objvo1.ProductionValue1);

                com.Parameters.AddWithValue("@ProductionYear2", objvo1.ProductionYear2);
                com.Parameters.AddWithValue("@ProductionQuantity2", objvo1.ProductionQuantity2);
                com.Parameters.AddWithValue("@ProductionValue2", objvo1.ProductionValue2);

                com.Parameters.AddWithValue("@ProductionYear3", objvo1.ProductionYear3);
                com.Parameters.AddWithValue("@ProductionQuantity3", objvo1.ProductionQuantity3);
                com.Parameters.AddWithValue("@ProductionValue3", objvo1.ProductionValue3);

                com.Parameters.AddWithValue("@PromotersEquity_MF", objvo1.PromotersEquity_MF);
                com.Parameters.AddWithValue("@InstitutionEquity_MF", objvo1.InstitutionEquity_MF);
                com.Parameters.AddWithValue("@TermsLoans_M", objvo1.TermsLoans_MF);
                com.Parameters.AddWithValue("@Others_MF", objvo1.Others_MF);
                com.Parameters.AddWithValue("@SeedCapital_MF", objvo1.SeedCapital_MF);
                com.Parameters.AddWithValue("@SubsidyGrantsAgencies_MF", objvo1.SubsidyGrantsAgencies_MF);
                com.Parameters.AddWithValue("@IsTermLoanAvailed", objvo1.IsTermLoanAvailed);
                com.Parameters.AddWithValue("@LandApprovedProjectCost", objvo1.LandApprovedProjectCost);
                com.Parameters.AddWithValue("@LandLoanSactioned", objvo1.LandLoanSactioned);
                com.Parameters.AddWithValue("@LandPromotersEquity", objvo1.LandPromotersEquity);
                com.Parameters.AddWithValue("@LandLoanAmountReleased", objvo1.LandLoanAmountReleased);
                com.Parameters.AddWithValue("@LandAssetsValuebyFinInstitution", objvo1.LandAssetsValuebyFinInstitution);
                com.Parameters.AddWithValue("@LandAssetsValuebyCA", objvo1.LandAssetsValuebyCA);
                com.Parameters.AddWithValue("@BuildingApprovedProjectCost", objvo1.BuildingApprovedProjectCost);
                com.Parameters.AddWithValue("@BuildingLoanSactioned", objvo1.BuildingLoanSactioned);
                com.Parameters.AddWithValue("@BuildingPromotersEquity", objvo1.BuildingPromotersEquity);
                com.Parameters.AddWithValue("@BuildingLoanAmountReleased", objvo1.BuildingLoanAmountReleased);
                com.Parameters.AddWithValue("@BuildingAssetsValuebyFinInstitution", objvo1.BuildingAssetsValuebyFinInstitution);
                com.Parameters.AddWithValue("@BuildingAssetsValuebyCA", objvo1.BuildingAssetsValuebyCA);
                com.Parameters.AddWithValue("@PlantMachineryApprovedProjectCost", objvo1.PlantMachineryApprovedProjectCost);
                com.Parameters.AddWithValue("@PlantMachineryLoanSactioned", objvo1.PlantMachineryLoanSactioned);
                com.Parameters.AddWithValue("@PlantMachineryPromotersEquity", objvo1.PlantMachineryPromotersEquity);
                com.Parameters.AddWithValue("@PlantMachineryLoanAmountReleased", objvo1.PlantMachineryLoanAmountReleased);
                com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyFinInstitution", objvo1.PlantMachineryAssetsValuebyFinInstitution);
                com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyCA", objvo1.PlantMachineryAssetsValuebyCA);
                com.Parameters.AddWithValue("@MachineryContingenciesApprovedProjectCost", objvo1.MachineryContingenciesApprovedProjectCost);
                com.Parameters.AddWithValue("@MachineryContingenciesLoanSactioned", objvo1.MachineryContingenciesLoanSactioned);
                com.Parameters.AddWithValue("@MachineryContingenciesPromotersEquity", objvo1.MachineryContingenciesPromotersEquity);
                com.Parameters.AddWithValue("@MachineryContingenciesLoanAmountReleased", objvo1.MachineryContingenciesLoanAmountReleased);
                com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyFinInstitution", objvo1.MachineryContingenciesAssetsValuebyFinInstitution);
                com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyCA", objvo1.MachineryContingenciesAssetsValuebyCA);
                com.Parameters.AddWithValue("@ErectionApprovedProjectCost", objvo1.ErectionApprovedProjectCost);
                com.Parameters.AddWithValue("@ErectionLoanSactioned", objvo1.ErectionLoanSactioned);
                com.Parameters.AddWithValue("@ErectionPromotersEquity", objvo1.ErectionPromotersEquity);
                com.Parameters.AddWithValue("@ErectionLoanAmountReleased", objvo1.ErectionLoanAmountReleased);
                com.Parameters.AddWithValue("@ErectionAssetsValuebyFinInstitution", objvo1.ErectionAssetsValuebyFinInstitution);
                com.Parameters.AddWithValue("@ErectionAssetsValuebyCA", objvo1.ErectionAssetsValuebyCA);
                com.Parameters.AddWithValue("@TechnicalfeasibilityApprovedProjectCost", objvo1.TechnicalfeasibilityApprovedProjectCost);
                com.Parameters.AddWithValue("@TechnicalfeasibilityLoanSactioned", objvo1.TechnicalfeasibilityLoanSactioned);
                com.Parameters.AddWithValue("@TechnicalfeasibilityPromotersEquity", objvo1.TechnicalfeasibilityPromotersEquity);
                com.Parameters.AddWithValue("@TechnicalfeasibilityLoanAmountReleased", objvo1.TechnicalfeasibilityLoanAmountReleased);
                com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyFinInstitution", objvo1.TechnicalfeasibilityAssetsValuebyFinInstitution);
                com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyCA", objvo1.TechnicalfeasibilityAssetsValuebyCA);
                com.Parameters.AddWithValue("@WorkingCapitalApprovedProjectCost", objvo1.WorkingCapitalApprovedProjectCost);
                com.Parameters.AddWithValue("@WorkingCapitalLoanSactioned", objvo1.WorkingCapitalLoanSactioned);
                com.Parameters.AddWithValue("@WorkingCapitalPromotersEquity", objvo1.WorkingCapitalPromotersEquity);
                com.Parameters.AddWithValue("@WorkingCapitalLoanAmountReleased", objvo1.WorkingCapitalLoanAmountReleased);
                com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyFinInstitution", objvo1.WorkingCapitalAssetsValuebyFinInstitution);
                com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyCA", objvo1.WorkingCapitalAssetsValuebyCA);

                com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
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
        public string InsertIncentivCommonDataTAB5(IncentivesVOs objvo1)
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
                com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON_NEW]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);

                com.Parameters.AddWithValue("@BankName", objvo1.BankName);
                com.Parameters.AddWithValue("@BranchName", objvo1.BranchName);
                com.Parameters.AddWithValue("@BankAccType", objvo1.BankAccType);
                com.Parameters.AddWithValue("@BankAccountName", objvo1.BankAccName);
                com.Parameters.AddWithValue("@AccNo", objvo1.AccNo);
                com.Parameters.AddWithValue("@IFSCCode", objvo1.IFSCCode);

                com.Parameters.AddWithValue("@AccountauthorizedPerson", objvo1.AccountauthorizedPerson);
                com.Parameters.AddWithValue("@DesignationOfAccountauthorizedPerson", objvo1.DesignationOfAccountauthorizedPerson);

                com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
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
        public DataSet GenericFillDs(string procedurename)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(procedurename, con);
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
        public DataSet GenericFillDs(string procedurename, SqlParameter[] sp)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(procedurename, con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandTimeout = 600;
                da.SelectCommand.Parameters.AddRange(sp);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public string InsertAppliedIncentives(List<AppliedIncentiveStatus> lstAppliedIncentiveStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (AppliedIncentiveStatus objAppliedIncentiveStatus in lstAppliedIncentiveStatus)
                {
                    SqlCommand COMNew = new SqlCommand();
                    COMNew.CommandType = CommandType.StoredProcedure;
                    COMNew.CommandText = "USP_INSERT_APPLIEDINCENTIVE_DATA";
                    COMNew.Transaction = transaction;
                    COMNew.Connection = connection;
                    COMNew.Parameters.AddWithValue("@EnterperIncentiveID", objAppliedIncentiveStatus.EnterperIncentiveID);
                    COMNew.Parameters.AddWithValue("@MstIncentiveId", objAppliedIncentiveStatus.MstIncentiveId);
                    COMNew.Parameters.AddWithValue("@Isactive", objAppliedIncentiveStatus.Isactive);
                    COMNew.Parameters.AddWithValue("@Created_by", objAppliedIncentiveStatus.Created_by);
                    COMNew.ExecuteNonQuery();
                }
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
        public DataTable FetchIncentivesNewINCTypePSRNew(int CasteID, int SectorID, int CategoryID, int ZoneId, bool IsWomenEntrprenaur, int IncentiveType, int EnterpID, string ViewType)
        { return SqlHelper.ExecuteDataset(ConNew, "FetchIncentivesNewINCType_PSRNEW", CasteID, SectorID, CategoryID, ZoneId, IsWomenEntrprenaur, IncentiveType, EnterpID, ViewType).Tables[0]; }

        public string InsertCapitalAssistanceEquipmentDetails(EquipmentDetailsBO objEquipmentDetailsBO)
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
                com.CommandText = "[USP_INS_Equipment_Dtls]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Equipment_ID", objEquipmentDetailsBO.Equipment_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEquipmentDetailsBO.IncentiveId);

                com.Parameters.AddWithValue("@NameoftheEquipment", objEquipmentDetailsBO.NameoftheEquipment);
                com.Parameters.AddWithValue("@EquipmentNameAddressofSupplier", objEquipmentDetailsBO.EquipmentNameAddressofSupplier);
                com.Parameters.AddWithValue("@EquipmentInvoiceNo", objEquipmentDetailsBO.EquipmentInvoiceNo);
                com.Parameters.AddWithValue("@EquipmentInvoiceDate", objEquipmentDetailsBO.EquipmentInvoiceDate);
                com.Parameters.AddWithValue("@EquipmentDateOfLanding", objEquipmentDetailsBO.EquipmentDateOfLanding);
                com.Parameters.AddWithValue("@EquipmentDateOfCommissioning", objEquipmentDetailsBO.EquipmentDateOfCommissioning);
                com.Parameters.AddWithValue("@EquipmentWayBillNumber", objEquipmentDetailsBO.EquipmentWayBillNumber);
                com.Parameters.AddWithValue("@EquipmentDateOfWayBill", objEquipmentDetailsBO.EquipmentDateOfWayBill);
                com.Parameters.AddWithValue("@CostofEquipment", objEquipmentDetailsBO.CostofEquipment);
                com.Parameters.AddWithValue("@Equipmentcgst", objEquipmentDetailsBO.Equipmentcgst);
                com.Parameters.AddWithValue("@Equipmentsgst", objEquipmentDetailsBO.Equipmentsgst);
                com.Parameters.AddWithValue("@EquipmentFreightCharges", objEquipmentDetailsBO.EquipmentFreightCharges);
                com.Parameters.AddWithValue("@EquipmentInitiationCharges", objEquipmentDetailsBO.EquipmentInitiationCharges);
                com.Parameters.AddWithValue("@Total", objEquipmentDetailsBO.Total);
                com.Parameters.AddWithValue("@TypeofEquipmentId", objEquipmentDetailsBO.TypeofEquipmentId);
                com.Parameters.AddWithValue("@TypeofEquipmentName", objEquipmentDetailsBO.TypeofEquipmentName);

                com.Parameters.AddWithValue("@CreatedBy", objEquipmentDetailsBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objEquipmentDetailsBO.TransType);

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

        public string InsertingOfCapitalAssistanceEnergy(CapAssCreationEnergyBO objBO)
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
                com.CommandText = "USP_INS_Capital_Assistance_Energy_Water_Environmental_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objBO.IncentiveID);
                com.Parameters.AddWithValue("@TypeofInfrastructure", objBO.TypeofInfrastructure);
                com.Parameters.AddWithValue("@CreatedCETP", objBO.CreatedCETP);
                com.Parameters.AddWithValue("@TextTileType", objBO.TextTileType);
                com.Parameters.AddWithValue("@TotalCostCapital", objBO.TotalCostCapital);
                com.Parameters.AddWithValue("@OperationalCostMLDofInputWater", objBO.OperationalCostMLDofInputWater);
                com.Parameters.AddWithValue("@GOI", objBO.GOI);
                com.Parameters.AddWithValue("@StateGovt", objBO.StateGovt);
                com.Parameters.AddWithValue("@Beneficiary", objBO.Beneficiary);
                com.Parameters.AddWithValue("@Bank", objBO.Bank);
                com.Parameters.AddWithValue("@AmountSubsidyClaimedEnergy", objBO.AmountSubsidyClaimedEnergy);
                com.Parameters.AddWithValue("@AmountSubsidyClaimedEffluent", objBO.AmountSubsidyClaimedEffluent);

                com.Parameters.AddWithValue("@EnergyEquipment", objBO.EnergyEquipment);
                com.Parameters.AddWithValue("@WaterEquipment", objBO.WaterEquipment);
                com.Parameters.AddWithValue("@EnvironmentalEquipment", objBO.EnvironmentalEquipment);
                com.Parameters.AddWithValue("@EffluentTreatment", objBO.EffluentTreatment);

                com.Parameters.AddWithValue("@CreatedBy", objBO.CreatedBy);

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

        // Power Tariff Methods
        public string InsertPowerTariffLastThreeYearsDetails(PowerUtilizedBO objPowerUtilizedBO)
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
                com.CommandText = "[USP_INS_PowerTariffUtilization_Dtls]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Powerutilized_ID", objPowerUtilizedBO.Powerutilized_ID);
                com.Parameters.AddWithValue("@Incentive_id", objPowerUtilizedBO.IncentiveId);


                com.Parameters.AddWithValue("@FinancialYear", objPowerUtilizedBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objPowerUtilizedBO.FinancialYearText);
                com.Parameters.AddWithValue("@TotalUnits", objPowerUtilizedBO.TotalUnits);
                com.Parameters.AddWithValue("@TotalAmount", objPowerUtilizedBO.TotalAmount);

                com.Parameters.AddWithValue("@CreatedBy", objPowerUtilizedBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objPowerUtilizedBO.TransType);

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

        public string InsertEnergyconsumedDetails(EnergyConsumedBO objEnergyConsumedBO)
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
                com.CommandText = "USP_INS_EnergyConsumed_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@EnergyConsumed_ID", objEnergyConsumedBO.EnergyConsumed_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEnergyConsumedBO.IncentiveId);


                com.Parameters.AddWithValue("@FinancialYear", objEnergyConsumedBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objEnergyConsumedBO.FinancialYearText);

                com.Parameters.AddWithValue("@TypeOfFinancialYear", objEnergyConsumedBO.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objEnergyConsumedBO.TypeOfFinancialYearText);

                com.Parameters.AddWithValue("@ServiceNo", objEnergyConsumedBO.ServiceNo);
                com.Parameters.AddWithValue("@TotalUnitsConsumed", objEnergyConsumedBO.TotalUnits);
                com.Parameters.AddWithValue("@TotalAmount", objEnergyConsumedBO.TotalAmount);

                com.Parameters.AddWithValue("@PurposeofConnection", objEnergyConsumedBO.PurposeofConnection);
                com.Parameters.AddWithValue("@RateofUnit", objEnergyConsumedBO.RateofUnit);
                com.Parameters.AddWithValue("@OtherCharges", objEnergyConsumedBO.OtherCharges);

                com.Parameters.AddWithValue("@FromReadingNumber", objEnergyConsumedBO.FromReadingNumber);
                com.Parameters.AddWithValue("@ToReadingNumber", objEnergyConsumedBO.ToReadingNumber);

                com.Parameters.AddWithValue("@CreatedBy", objEnergyConsumedBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objEnergyConsumedBO.TransType);

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


        public string InsertingOfPowerTariffdetails(PowerTariffSubsidyBO objBO)
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
                com.CommandText = "USP_INS_PowerTariff_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objBO.IncentiveID);
                com.Parameters.AddWithValue("@ExistingPower", objBO.ExistingPower);
                com.Parameters.AddWithValue("@NewPower", objBO.NewPower);
                com.Parameters.AddWithValue("@DateofNewpower", objBO.DateofNewpower);
                com.Parameters.AddWithValue("@CurrentClaimPeriodFrom", objBO.CurrentClaimPeriodFrom);
                com.Parameters.AddWithValue("@CurrentClaimPeriodTo", objBO.CurrentClaimPeriodTo);
                com.Parameters.AddWithValue("@CurrentClaimAmount", objBO.CurrentClaimAmount);
                com.Parameters.AddWithValue("@TotalPowerconnections", objBO.TotalPowerconnections);
                com.Parameters.AddWithValue("@IndustryPowerconnections", objBO.IndustryPowerconnections);

                com.Parameters.AddWithValue("@CreatedBy", objBO.CreatedBy);

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

        // StampDuty

        public string InsertingOfStampdutyDtls(FormVIStampDutyVo objFormVIStampDutyVo)
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
                com.CommandText = "USP_INS_Stampduty_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objFormVIStampDutyVo.IncentiveId);

                com.Parameters.AddWithValue("@NatureofAsset", objFormVIStampDutyVo.NatureofAsset);
                com.Parameters.AddWithValue("@LandPurchased_Sqmtrs", objFormVIStampDutyVo.LandPurchased_Sqmtrs);
                com.Parameters.AddWithValue("@LandPurchasedCostPersqmtrs", objFormVIStampDutyVo.LandPurchasedCostPersqmtrs);
                com.Parameters.AddWithValue("@PlinthAreaBuilding", objFormVIStampDutyVo.PlinthAreaBuilding);
                com.Parameters.AddWithValue("@PlinthAreaofFactoryFiveTmes", objFormVIStampDutyVo.PlinthAreaofFactoryFiveTmes);
                com.Parameters.AddWithValue("@Arearequiredappraisal", objFormVIStampDutyVo.Arearequiredappraisal);
                com.Parameters.AddWithValue("@ArearequiredTSPCB", objFormVIStampDutyVo.ArearequiredTSPCB);
                com.Parameters.AddWithValue("@NatureofTransaction", objFormVIStampDutyVo.NatureofTransaction);
                com.Parameters.AddWithValue("@DateofRegistration", objFormVIStampDutyVo.DateofRegistration);
                com.Parameters.AddWithValue("@SubRegistrarOffice", objFormVIStampDutyVo.SubRegistrarOffice);
                com.Parameters.AddWithValue("@StampDuty_TransferDuty_Paid", objFormVIStampDutyVo.StampDuty_TransferDuty_Paid);
                com.Parameters.AddWithValue("@MortgageHypothecationDutyPaid", objFormVIStampDutyVo.MortgageHypothecationDutyPaid);
                com.Parameters.AddWithValue("@StampDutyExemptionAvailed", objFormVIStampDutyVo.StampDutyExemptionAvailed);
                com.Parameters.AddWithValue("@Termloan", objFormVIStampDutyVo.Termloan);
                com.Parameters.AddWithValue("@CurrentClaimStampDutyTransferDuty", objFormVIStampDutyVo.CurrentClaimStampDutyTransferDuty);
                com.Parameters.AddWithValue("@CurrentClaimMortgageHypothecationDuty", objFormVIStampDutyVo.CurrentClaimMortgageHypothecationDuty);
                com.Parameters.AddWithValue("@AmountAvailed", objFormVIStampDutyVo.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", objFormVIStampDutyVo.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", objFormVIStampDutyVo.DateAvailed);
                com.Parameters.AddWithValue("@LineofActivity", objFormVIStampDutyVo.LineofActivity);

                com.Parameters.AddWithValue("@CreatedBy", objFormVIStampDutyVo.CreatedBy);

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

        // Concession on SGST

        public string InsertConcessiononSGSTDetails(EnergyConsumedBO objEnergyConsumedBO)
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
                com.CommandText = "USP_INS_Reimbursement_AvailedSGST_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SGSTReimbursement_ID", objEnergyConsumedBO.EnergyConsumed_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEnergyConsumedBO.IncentiveId);


                com.Parameters.AddWithValue("@FinancialYear", objEnergyConsumedBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objEnergyConsumedBO.FinancialYearText);

                com.Parameters.AddWithValue("@TypeOfFinancialYear", objEnergyConsumedBO.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objEnergyConsumedBO.TypeOfFinancialYearText);


                com.Parameters.AddWithValue("@TotalAmount", objEnergyConsumedBO.TotalAmount);

                com.Parameters.AddWithValue("@CreatedBy", objEnergyConsumedBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objEnergyConsumedBO.TransType);

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

        public string InsertingOfConcessiononSGSTDtls(ConcessionSGST objConcessionSGST)
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
                com.CommandText = "USP_INS_ConcessionSGST_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objConcessionSGST.IncentiveId);

                com.Parameters.AddWithValue("@GSTIdentificationNumber", objConcessionSGST.GSTIdentificationNumber);
                com.Parameters.AddWithValue("@DateofEstablishmentofUnit", objConcessionSGST.DateofEstablishmentofUnit);
                com.Parameters.AddWithValue("@Installedcapacity", objConcessionSGST.Installedcapacity);
                com.Parameters.AddWithValue("@Year1", objConcessionSGST.Year1);
                com.Parameters.AddWithValue("@Enterprises1", objConcessionSGST.Enterprises1);
                com.Parameters.AddWithValue("@TotalProduction1", objConcessionSGST.TotalProduction1);
                com.Parameters.AddWithValue("@Year2", objConcessionSGST.Year2);
                com.Parameters.AddWithValue("@Enterprises2", objConcessionSGST.Enterprises2);
                com.Parameters.AddWithValue("@TotalProduction2", objConcessionSGST.TotalProduction2);
                com.Parameters.AddWithValue("@Year3", objConcessionSGST.Year3);
                com.Parameters.AddWithValue("@Enterprises3", objConcessionSGST.Enterprises3);
                com.Parameters.AddWithValue("@TotalProduction3", objConcessionSGST.TotalProduction3);
                com.Parameters.AddWithValue("@ClaimApplicationsubmitted", objConcessionSGST.ClaimApplicationsubmitted);
                com.Parameters.AddWithValue("@Taxpaid", objConcessionSGST.Taxpaid);
                com.Parameters.AddWithValue("@CurrentClaimAmountRs", objConcessionSGST.CurrentClaimAmountRs);

                com.Parameters.AddWithValue("@MoratoriumFrom", objConcessionSGST.MoratoriumFrom);
                com.Parameters.AddWithValue("@MoratoriumTo", objConcessionSGST.MoratoriumTo);
                com.Parameters.AddWithValue("@MoratoriumInvestmentAmount", objConcessionSGST.MoratoriumInvestmentAmount);

                com.Parameters.AddWithValue("@TaxPaid1", objConcessionSGST.TaxPaid1);
                com.Parameters.AddWithValue("@TaxPaid2", objConcessionSGST.TaxPaid2);
                com.Parameters.AddWithValue("@TaxPaid3", objConcessionSGST.TaxPaid3);

                com.Parameters.AddWithValue("@CreatedBy", objConcessionSGST.CreatedBy);

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

        public string InsertSGSTSaleDetails(ProductSaleDetailsBO objProductSaleDetailsBO)
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
                com.CommandText = "USP_INS_TAX_SALE_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SaleID", objProductSaleDetailsBO.SaleID);
                com.Parameters.AddWithValue("@Incentive_id", objProductSaleDetailsBO.IncentiveId);

                com.Parameters.AddWithValue("@SaleYear", objProductSaleDetailsBO.SaleYear);
                com.Parameters.AddWithValue("@NameoftheProduct", objProductSaleDetailsBO.NameoftheProduct);
                com.Parameters.AddWithValue("@SaleQuantity", objProductSaleDetailsBO.SaleQuantity);
                com.Parameters.AddWithValue("@SaleUnit", objProductSaleDetailsBO.SaleUnit);
                com.Parameters.AddWithValue("@TotalSaleValue", objProductSaleDetailsBO.TotalSaleValue);

                com.Parameters.AddWithValue("@CreatedBy", objProductSaleDetailsBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objProductSaleDetailsBO.TransType);

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
        //Energy Coservation

        public string InsertingOfAssistanceforEnergyDtls(AssistanceEnergy objAssistanceEnergy)
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
                com.CommandText = "USP_INS_AssistanceforEnergy_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objAssistanceEnergy.IncentiveId);
                com.Parameters.AddWithValue("@CreatedBy", objAssistanceEnergy.CreatedBy);

                com.Parameters.AddWithValue("@DateofEstablishmentofUnit", objAssistanceEnergy.DateofEstablishmentofUnit);
                com.Parameters.AddWithValue("@CommercialProduction", objAssistanceEnergy.CommercialProduction);
                com.Parameters.AddWithValue("@TypeofInfrastructure", objAssistanceEnergy.TypeofInfrastructure);
                com.Parameters.AddWithValue("@AssistanceRequired", objAssistanceEnergy.AssistanceRequired);
                com.Parameters.AddWithValue("@EnergyAuditDateofAudit", objAssistanceEnergy.EnergyAuditDateofAudit);
                com.Parameters.AddWithValue("@EnergyAuditNameofAuditorAuditFirm", objAssistanceEnergy.EnergyAuditNameofAuditorAuditFirm);
                com.Parameters.AddWithValue("@EnergyAuditCostIncurred", objAssistanceEnergy.EnergyAuditCostIncurred);
                com.Parameters.AddWithValue("@EnergyAuditInvoiceNumber", objAssistanceEnergy.EnergyAuditInvoiceNumber);
                com.Parameters.AddWithValue("@EnergyAuditDateofInvoice", objAssistanceEnergy.EnergyAuditDateofInvoice);
                com.Parameters.AddWithValue("@WaterDateofAudit", objAssistanceEnergy.WaterDateofAudit);
                com.Parameters.AddWithValue("@WaterNameofAuditorAuditFirm", objAssistanceEnergy.WaterNameofAuditorAuditFirm);
                com.Parameters.AddWithValue("@WaterCostIncurred", objAssistanceEnergy.WaterCostIncurred);
                com.Parameters.AddWithValue("@WaterInvoiceNumber", objAssistanceEnergy.WaterInvoiceNumber);
                com.Parameters.AddWithValue("@WaterDateofInvoice", objAssistanceEnergy.WaterDateofInvoice);
                com.Parameters.AddWithValue("@EnvironmentalComplianceDateofAudit", objAssistanceEnergy.EnvironmentalComplianceDateofAudit);
                com.Parameters.AddWithValue("@NameofCompliance", objAssistanceEnergy.NameofCompliance);
                com.Parameters.AddWithValue("@CertifyingAgency", objAssistanceEnergy.CertifyingAgency);
                com.Parameters.AddWithValue("@EnvironmentalComplianceCostIncurred", objAssistanceEnergy.EnvironmentalComplianceCostIncurred);
                com.Parameters.AddWithValue("@EnvironmentalComplianceInvoiceNumber", objAssistanceEnergy.EnvironmentalComplianceInvoiceNumber);
                com.Parameters.AddWithValue("@EnvironmentalComplianceDateofInvoice", objAssistanceEnergy.EnvironmentalComplianceDateofInvoice);
                com.Parameters.AddWithValue("@DateofLastClaim", objAssistanceEnergy.DateofLastClaim);
                com.Parameters.AddWithValue("@NatureofExpenses", objAssistanceEnergy.NatureofExpenses);
                com.Parameters.AddWithValue("@ClaimAmount", objAssistanceEnergy.ClaimAmount);
                com.Parameters.AddWithValue("@ReimbursementReceived", objAssistanceEnergy.ReimbursementReceived);
                com.Parameters.AddWithValue("@GovernmentAmountAvailed", objAssistanceEnergy.GovernmentAmountAvailed);
                com.Parameters.AddWithValue("@GovernmentDateAvailed", objAssistanceEnergy.GovernmentDateAvailed);
                com.Parameters.AddWithValue("@CurrentClaimEnergyAudit", objAssistanceEnergy.CurrentClaimEnergyAudit);
                com.Parameters.AddWithValue("@CurrentClaimWaterAudit", objAssistanceEnergy.CurrentClaimWaterAudit);
                com.Parameters.AddWithValue("@CurrentClaimEnvironmentalCompliance", objAssistanceEnergy.CurrentClaimEnvironmentalCompliance);

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

        // Acquisition of New Technology
        public string InsertingOfAcquisitionofNewTechnologyDtls(AssistanceAcquisition objAssistanceAcquisition)
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
                com.CommandText = "USP_INS_Acquisition_New_Technology_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objAssistanceAcquisition.IncentiveId);
                com.Parameters.AddWithValue("@NewTechnologyDeveloped", objAssistanceAcquisition.NewTechnologyDeveloped);
                com.Parameters.AddWithValue("@IstheTechnologyImported", objAssistanceAcquisition.IstheTechnologyImported);
                com.Parameters.AddWithValue("@Valueadditionnewtechnology", objAssistanceAcquisition.Valueadditionnewtechnology);
                com.Parameters.AddWithValue("@CostIncurredinDevelopment", objAssistanceAcquisition.CostIncurredinDevelopment);
                com.Parameters.AddWithValue("@CurrentClaim", objAssistanceAcquisition.CurrentClaim);
                com.Parameters.AddWithValue("@Benefitavailed", objAssistanceAcquisition.Benefitavailed);

                com.Parameters.AddWithValue("@Newtechnologydevelopedadaptation", objAssistanceAcquisition.Newtechnologydevelopedadaptation);
                com.Parameters.AddWithValue("@RDDetails", objAssistanceAcquisition.RDDetails);

                com.Parameters.AddWithValue("@CreatedBy", objAssistanceAcquisition.CreatedBy);

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

        //  
        public string InsertExportIntensiveTextileDetails(EnergyConsumedBO objEnergyConsumedBO)
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
                com.CommandText = "USP_INS_Export_Intensive_Textile_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Export_Intensive_Textile_ID", objEnergyConsumedBO.EnergyConsumed_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEnergyConsumedBO.IncentiveId);


                com.Parameters.AddWithValue("@FinancialYear", objEnergyConsumedBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objEnergyConsumedBO.FinancialYearText);

                com.Parameters.AddWithValue("@TypeOfFinancialYear", objEnergyConsumedBO.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objEnergyConsumedBO.TypeOfFinancialYearText);


                com.Parameters.AddWithValue("@TotalAmount", objEnergyConsumedBO.TotalAmount);

                com.Parameters.AddWithValue("@CreatedBy", objEnergyConsumedBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objEnergyConsumedBO.TransType);

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

        public string InsertingOfTransportSubsidyExportIntensiveTextileDtls(TransportSubsidy objTransportSubsidy)
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
                com.CommandText = "USP_INS_Transport_Export_Intensive_Textile_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objTransportSubsidy.IncentiveId);

                com.Parameters.AddWithValue("@DateofEstablishmentofUnit", objTransportSubsidy.DateofEstablishmentofUnit);
                com.Parameters.AddWithValue("@NatureofBusiness", objTransportSubsidy.NatureofBusiness);
                com.Parameters.AddWithValue("@PercentageTotalRevenue", objTransportSubsidy.TotalRevenue);
                com.Parameters.AddWithValue("@NearestAirport", objTransportSubsidy.NearestAirport);
                com.Parameters.AddWithValue("@NearestSeaport", objTransportSubsidy.NearestSeaport);
                com.Parameters.AddWithValue("@NearestDryPort", objTransportSubsidy.NearestDryPort);
                com.Parameters.AddWithValue("@TypeofExport", objTransportSubsidy.TypeofExport);
                com.Parameters.AddWithValue("@DetailsRawMaterialsImported", objTransportSubsidy.DetailsRawMaterialsImported);
                com.Parameters.AddWithValue("@DetailsFinishedProducts", objTransportSubsidy.DetailsFinishedProducts);
                com.Parameters.AddWithValue("@FinishedProductsExported", objTransportSubsidy.FinishedProductsExported);
                com.Parameters.AddWithValue("@CurrentClaim", objTransportSubsidy.CurrentClaim);
                com.Parameters.AddWithValue("@ExportRevenue", objTransportSubsidy.ExportRevenue);
                com.Parameters.AddWithValue("@ModeofTransport", objTransportSubsidy.ModeofTransport);

                com.Parameters.AddWithValue("@CreatedBy", objTransportSubsidy.CreatedBy);

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

        //

        public string InsertingOfDesignProductDevelopmentDiversificationDtls(ProductDevelopment ObjProduct)
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
                com.CommandText = "USP_INS_Design_Product_Development_Diversification_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", ObjProduct.IncentiveId);
                com.Parameters.AddWithValue("@DesignDeveloped", ObjProduct.DesignDeveloped);
                com.Parameters.AddWithValue("@ExpenditureIncurred", ObjProduct.ExpenditureIncurred);
                com.Parameters.AddWithValue("@EarlierClaimsMade", ObjProduct.EarlierClaimsMade);
                com.Parameters.AddWithValue("@EarlierCliamYear", ObjProduct.EarlierCliamYear);
                com.Parameters.AddWithValue("@amountclaimed", ObjProduct.amountclaimed);
                com.Parameters.AddWithValue("@CurrentClaim", ObjProduct.CurrentClaim);

                com.Parameters.AddWithValue("@CreatedBy", ObjProduct.CreatedBy);

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

        // Form XIV: Assistance towards Training Infrastructure in Apparel Design and Development
        public string InsertingOfTrainingInfrastructureApparelDesignDevelopmentDtls(TraningInfrastructure ObjTraning)
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
                com.CommandText = "USP_INS_Training_Infrastructure_Apparel_Design_Development_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", ObjTraning.IncentiveId);

                com.Parameters.AddWithValue("@NameofTrainingCentre", ObjTraning.NameofTrainingCentre);
                com.Parameters.AddWithValue("@EmpanelledDHT", ObjTraning.EmpanelledDHT);
                com.Parameters.AddWithValue("@LocationofTrainingCentre", ObjTraning.LocationofTrainingCentre);
                com.Parameters.AddWithValue("@Coursesoffered", ObjTraning.Coursesoffered);
                com.Parameters.AddWithValue("@Building", ObjTraning.Building);
                com.Parameters.AddWithValue("@PlantMachinery", ObjTraning.PlantMachinery);
                com.Parameters.AddWithValue("@InstallationCharges", ObjTraning.InstallationCharges);
                com.Parameters.AddWithValue("@Electrification", ObjTraning.Electrification);
                com.Parameters.AddWithValue("@TrainingAids", ObjTraning.TrainingAids);
                com.Parameters.AddWithValue("@Furniture", ObjTraning.Furniture);
                com.Parameters.AddWithValue("@TotalInvestment", ObjTraning.TotalInvestment);
                com.Parameters.AddWithValue("@CurrentClaim", ObjTraning.CurrentClaim);
                com.Parameters.AddWithValue("@TypeofTrainingCentre", ObjTraning.TypeofTrainingCentre);
                com.Parameters.AddWithValue("@TrainingCentrePurpose", ObjTraning.TrainingCentrePurpose);

                com.Parameters.AddWithValue("@CreatedBy", ObjTraning.CreatedBy);

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

        // 

        public string InsertingOfTrainingSubsidyDtls(TrainingSubsidy objsubsidy)
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
                com.CommandText = "USP_INS_Training_Subsidy_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objsubsidy.IncentiveId);

                com.Parameters.AddWithValue("@NumberofEmployees", objsubsidy.NumberofEmployees);
                com.Parameters.AddWithValue("@SkillName", objsubsidy.SkillName);
                com.Parameters.AddWithValue("@TrainingInstituteName", objsubsidy.TrainingInstituteName);
                com.Parameters.AddWithValue("@NumberofEmployeesTrained", objsubsidy.NumberofEmployeesTrained);
                com.Parameters.AddWithValue("@ExpenditureIncurredTraining", objsubsidy.ExpenditureIncurredTraining);
                com.Parameters.AddWithValue("@MonthsEmployment", objsubsidy.MonthsEmployment);
                com.Parameters.AddWithValue("@CurrentClaim", objsubsidy.CurrentClaim);

                com.Parameters.AddWithValue("@AmountAvailed", objsubsidy.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", objsubsidy.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", objsubsidy.DateAvailed);
                com.Parameters.AddWithValue("@NumberofEmployeesTrainedNonLocal", objsubsidy.NumberofEmployeesTrainedNonLocal);

                com.Parameters.AddWithValue("@CreatedBy", objsubsidy.CreatedBy);

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

        //
        public string InsertingOfDevelopmentWorkerHousingDtls(WorkerHousing objworker)
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
                com.CommandText = "USP_INS_WorkerHousing_Dormitories_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objworker.IncentiveId);
                com.Parameters.AddWithValue("@DateofEstablishmentofUnit", objworker.DateofEstablishmentofUnit);
                com.Parameters.AddWithValue("@WorkerHousingLocation", objworker.WorkerHousingLocation);
                com.Parameters.AddWithValue("@Landpurchased", objworker.Landpurchased);
                com.Parameters.AddWithValue("@BuildingPlinthArea", objworker.BuildingPlinthArea);
                com.Parameters.AddWithValue("@BuildingAreaRequired", objworker.BuildingAreaRequired);
                com.Parameters.AddWithValue("@LandInvestment", objworker.LandInvestment);
                com.Parameters.AddWithValue("@LandConversionCharges", objworker.LandConversionCharges);
                com.Parameters.AddWithValue("@PurchasedLandCost", objworker.PurchasedLandCost);
                com.Parameters.AddWithValue("@HousingOccupantsLoad", objworker.HousingOccupantsLoad);
                com.Parameters.AddWithValue("@OccupancyRate", objworker.OccupancyRate);
                com.Parameters.AddWithValue("@QuartersStartDate", objworker.QuartersStartDate);
                com.Parameters.AddWithValue("@QuartersEndDate", objworker.QuartersEndDate);
                com.Parameters.AddWithValue("@CurrentClaim", objworker.CurrentClaim);

                com.Parameters.AddWithValue("@TextileOrApparelArea", objworker.TextileOrApparelArea);
                com.Parameters.AddWithValue("@TotalLandUsedForWorker", objworker.TotalLandUsedForWorker);
                com.Parameters.AddWithValue("@Landpurchasedrateper", objworker.Landpurchasedrateper);

                com.Parameters.AddWithValue("@CreatedBy", objworker.CreatedBy);

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

        //
        public string InsertingOfCETPETPDtls(RebateCharges ObjRebateCharges)
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
                com.CommandText = "USP_INS_CETP_ETP_Environment_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", ObjRebateCharges.IncentiveId);

                com.Parameters.AddWithValue("@TypeofETP", ObjRebateCharges.TypeofETP);
                com.Parameters.AddWithValue("@OtherETP", ObjRebateCharges.OtherETP);
                com.Parameters.AddWithValue("@CETPETPDetails", ObjRebateCharges.CETPETPDetails);
                com.Parameters.AddWithValue("@CaptiveCommonETP", ObjRebateCharges.CaptiveCommonETP);
                com.Parameters.AddWithValue("@ETPCost", ObjRebateCharges.ETPCost);
                com.Parameters.AddWithValue("@RebateClaimed", ObjRebateCharges.RebateClaimed);
                com.Parameters.AddWithValue("@YearoftheClaim", ObjRebateCharges.YearoftheClaim);
                com.Parameters.AddWithValue("@AnyGovtAgency", ObjRebateCharges.AnyGovtAgency);
                com.Parameters.AddWithValue("@YearsCommercialProduction", ObjRebateCharges.YearsCommercialProduction);
                com.Parameters.AddWithValue("@CommencementCommercialOperation", ObjRebateCharges.CommencementCommercialOperation);
                com.Parameters.AddWithValue("@DateofCommencementUtilization", ObjRebateCharges.DateofCommencementUtilization);
                com.Parameters.AddWithValue("@CurrentClaim", ObjRebateCharges.CurrentClaim);
                com.Parameters.AddWithValue("@ApprovedProjectCost", ObjRebateCharges.ApprovedProjectCost);
                com.Parameters.AddWithValue("@UtilizationETPCETP", ObjRebateCharges.UtilizationETPCETP);
                com.Parameters.AddWithValue("@ActualCostInvested", ObjRebateCharges.ActualCostInvested);

                com.Parameters.AddWithValue("@AmountAvailed", ObjRebateCharges.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", ObjRebateCharges.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", ObjRebateCharges.DateAvailed);

                com.Parameters.AddWithValue("@CreatedBy", ObjRebateCharges.CreatedBy);

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

        public string InsertETPChargesLastSixmonthsDetails(EPTChargesVo objEPTChargesVo)
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
                com.CommandText = "[USP_INS_ETPCharges_Dtls]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@ETPCharges_ID", objEPTChargesVo.ETPCharges_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEPTChargesVo.IncentiveId);


                //com.Parameters.AddWithValue("@MonthYear", objEPTChargesVo.MonthYear);
                com.Parameters.AddWithValue("@FinancialYear", objEPTChargesVo.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objEPTChargesVo.FinancialYearText);

                com.Parameters.AddWithValue("@TypeOfFinancialYear", objEPTChargesVo.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objEPTChargesVo.TypeOfFinancialYearText);

                com.Parameters.AddWithValue("@ComponentId", objEPTChargesVo.ComponentId);

                com.Parameters.AddWithValue("@EffluentTreated", objEPTChargesVo.EffluentTreated);
                com.Parameters.AddWithValue("@EffluentTreatmentCharges", objEPTChargesVo.EffluentTreatmentCharges);

                com.Parameters.AddWithValue("@CreatedBy", objEPTChargesVo.Created_by);
                com.Parameters.AddWithValue("@TransType", objEPTChargesVo.TransType);

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

        //Form – XI: Other Infrastructure Support

        public string InsertingOfInfrastructureSupportDtls(OtherInfrastructure objInfrastructure)
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
                com.CommandText = "USP_INS_Other_Infrastructure_Support_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objInfrastructure.IncentiveId);

                com.Parameters.AddWithValue("@IndustrialArea", objInfrastructure.IndustrialArea);
                com.Parameters.AddWithValue("@CategoryofBusiness", objInfrastructure.CategoryofBusiness);
                com.Parameters.AddWithValue("@YearsofOperation", objInfrastructure.YearsofOperation);
                com.Parameters.AddWithValue("@Justificationforlocation", objInfrastructure.Justificationforlocation);
                com.Parameters.AddWithValue("@ProposedInfrastructureJustification", objInfrastructure.ProposedInfrastructureJustification);
                com.Parameters.AddWithValue("@SourceOfFinance", objInfrastructure.SourceOfFinance);
                com.Parameters.AddWithValue("@RoadsPowerWaterDescription", objInfrastructure.RoadsPowerWaterDescription);
                com.Parameters.AddWithValue("@SupportInfrastructureDescription", objInfrastructure.SupportInfrastructureDescription);
                com.Parameters.AddWithValue("@SupportEstimateCost", objInfrastructure.SupportEstimateCost);

                com.Parameters.AddWithValue("@EstimateCostRoadsPowerWater", objInfrastructure.EstimateCostRoadsPowerWater);
                com.Parameters.AddWithValue("@EstimateCostPower", objInfrastructure.EstimateCostPower);
                com.Parameters.AddWithValue("@EstimateCostWater", objInfrastructure.EstimateCostWater);
                com.Parameters.AddWithValue("@EstimateCostDrainageLine", objInfrastructure.EstimateCostDrainageLine);

                com.Parameters.AddWithValue("@CharteredEngineerName", objInfrastructure.CharteredEngineerName);
                com.Parameters.AddWithValue("@EstimateCostSupport15", objInfrastructure.EstimateCostSupport15);
                com.Parameters.AddWithValue("@EstimateCostRoadsPowerWater15", objInfrastructure.EstimateCostRoadsPowerWater15);

                com.Parameters.AddWithValue("@EstimateCostPower15", objInfrastructure.EstimateCostPower15);
                com.Parameters.AddWithValue("@EstimateCostWater15", objInfrastructure.EstimateCostWater15);

                com.Parameters.AddWithValue("@ProjectDuration", objInfrastructure.ProjectDuration);
                com.Parameters.AddWithValue("@Measuresproposed", objInfrastructure.Measuresproposed);
                com.Parameters.AddWithValue("@maintenancecost", objInfrastructure.maintenancecost);
                com.Parameters.AddWithValue("@AssistanceAvailed", objInfrastructure.AssistanceAvailed);

                com.Parameters.AddWithValue("@AmountAvailed", objInfrastructure.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", objInfrastructure.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", objInfrastructure.DateAvailed);

                com.Parameters.AddWithValue("@CreatedBy", objInfrastructure.CreatedBy);

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

        // Land Lease

        public string InsertRentalSubsidyReimbursementAvailedDetails(EnergyConsumedBO objEnergyConsumedBO)
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
                com.CommandText = "USP_INS_Rental_SubsidyReimbursement_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Rental_SubsidyAvailed_ID", objEnergyConsumedBO.EnergyConsumed_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEnergyConsumedBO.IncentiveId);


                com.Parameters.AddWithValue("@FinancialYear", objEnergyConsumedBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objEnergyConsumedBO.FinancialYearText);

                com.Parameters.AddWithValue("@TypeOfFinancialYear", objEnergyConsumedBO.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objEnergyConsumedBO.TypeOfFinancialYearText);


                com.Parameters.AddWithValue("@TotalAmount", objEnergyConsumedBO.TotalAmount);

                com.Parameters.AddWithValue("@CreatedBy", objEnergyConsumedBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objEnergyConsumedBO.TransType);

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

        public string InsertRentalSubsidyReimbursementCurrentClaimDetails(EnergyConsumedBO objEnergyConsumedBO)
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
                com.CommandText = "USP_INS_Rental_SubsidyReimbursementCurrentClaim_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Rental_SubsidyAvailed_ID", objEnergyConsumedBO.EnergyConsumed_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEnergyConsumedBO.IncentiveId);


                com.Parameters.AddWithValue("@FinancialYear", objEnergyConsumedBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objEnergyConsumedBO.FinancialYearText);

                com.Parameters.AddWithValue("@TypeOfFinancialYear", objEnergyConsumedBO.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objEnergyConsumedBO.TypeOfFinancialYearText);


                com.Parameters.AddWithValue("@TotalAmount", objEnergyConsumedBO.TotalAmount);

                com.Parameters.AddWithValue("@CreatedBy", objEnergyConsumedBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objEnergyConsumedBO.TransType);

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

        public string InsertingOfRentalLeaseSubsidyBuiltSpaceDtls(RentalSubsify ObjProduct)
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
                com.CommandText = "USP_INS_Rental_Lease_Subsidy_Built_Space_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", ObjProduct.IncentiveId);

                com.Parameters.AddWithValue("@DateofEstablishmentofUnit", ObjProduct.DateofEstablishmentofUnit);
                com.Parameters.AddWithValue("@TextileOrApparelArea", ObjProduct.TextileOrApparelArea);
                com.Parameters.AddWithValue("@RentalInformationType", ObjProduct.RentalInformationType);
                com.Parameters.AddWithValue("@OtherLeasingArrangement", ObjProduct.OtherLeasingArrangement);
                com.Parameters.AddWithValue("@BuiltUpSpaceOccupied", ObjProduct.BuiltUpSpaceOccupied);
                com.Parameters.AddWithValue("@RentLeaseAmountPerSqMtr", ObjProduct.RentLeaseAmountPerSqMtr);
                com.Parameters.AddWithValue("@TotalMonthlyNetRent", ObjProduct.TotalMonthlyNetRent);
                com.Parameters.AddWithValue("@PeriodofLeaseFromDate", ObjProduct.PeriodofLeaseFromDate);
                com.Parameters.AddWithValue("@PeriodofLeaseToDate", ObjProduct.PeriodofLeaseToDate);
                com.Parameters.AddWithValue("@IsAnyothersubsidy", ObjProduct.IsAnyothersubsidy);
                com.Parameters.AddWithValue("@SubsidySource", ObjProduct.SubsidySource);
                com.Parameters.AddWithValue("@SubsidySourceAmount", ObjProduct.SubsidySourceAmount);
                com.Parameters.AddWithValue("@ClaimApplicationsubmitted", ObjProduct.ClaimApplicationsubmitted);
                com.Parameters.AddWithValue("@FromDateOfClaimAmount", ObjProduct.FromDateOfClaimAmount);
                com.Parameters.AddWithValue("@ToDateOfClaimAmount", ObjProduct.ToDateOfClaimAmount);
                com.Parameters.AddWithValue("@ReimbursementAmountClaimed", ObjProduct.ReimbursementAmountClaimed);
                com.Parameters.AddWithValue("@TypeOfUse", ObjProduct.TypeOfUse);
                com.Parameters.AddWithValue("@ProductionPersonsTrained", ObjProduct.ProductionPersonsTrained);

                com.Parameters.AddWithValue("@RentalLeaseReg", ObjProduct.RentalLeaseReg);
                com.Parameters.AddWithValue("@DeedNumber", ObjProduct.DeedNumber);
                com.Parameters.AddWithValue("@Deeddate", ObjProduct.Deeddate);

                com.Parameters.AddWithValue("@CreatedBy", ObjProduct.CreatedBy);

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

        //
        public string InsertingOfReturningMigrantsDtls(MigratIncentive ObjTraning)
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
                com.CommandText = "USP_INS_Returning_Migrants_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", ObjTraning.IncentiveId);

                com.Parameters.AddWithValue("@CapitalInvestment", ObjTraning.CapitalInvestment);
                com.Parameters.AddWithValue("@Scheme", ObjTraning.Scheme);
                com.Parameters.AddWithValue("@WeaversPercentage", ObjTraning.WeaversPercentage);
                com.Parameters.AddWithValue("@Contributiontoinvestment", ObjTraning.Contributiontoinvestment);
                com.Parameters.AddWithValue("@Building", ObjTraning.Building);
                com.Parameters.AddWithValue("@PlantMachinery", ObjTraning.PlantMachinery);
                com.Parameters.AddWithValue("@InstallationCharges", ObjTraning.InstallationCharges);
                com.Parameters.AddWithValue("@Electrification", ObjTraning.Electrification);
                com.Parameters.AddWithValue("@Others", ObjTraning.Others);
                com.Parameters.AddWithValue("@TotalInvestment", ObjTraning.TotalInvestment);
                com.Parameters.AddWithValue("@CurrentClaim", ObjTraning.CurrentClaim);

                com.Parameters.AddWithValue("@AmountAvailed", ObjTraning.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", ObjTraning.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", ObjTraning.DateAvailed);

                com.Parameters.AddWithValue("@PercentageGOIContribution", ObjTraning.PercentageGOIContribution);

                com.Parameters.AddWithValue("@CreatedBy", ObjTraning.CreatedBy);

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

        // Office Flow

        public string UpdateApplicationStatusAdmin(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_APPLICATION_ADMIN";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                com.Parameters.AddWithValue("@QueryLetterID", objApplicationStatus.QueryLetterID);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);

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

        public string UpdateApplicationStatusDLOStage1(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_SCHEDULE_INSPECTION_QUERY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@InspectionDate", objApplicationStatus.InspectionDate);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                com.Parameters.AddWithValue("@QueryLetterID", objApplicationStatus.QueryLetterID);

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

        public string UpdateQueryResponseofApplicant(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "[USP_UPD_QUERYRESPONSE_APPLICANT]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@QueryId", objApplicationStatus.QueryId);
                com.Parameters.AddWithValue("@IncentiveID", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@QueryResponse", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@UserFlag", objApplicationStatus.TransType);
                com.Parameters.AddWithValue("@Created_by", objApplicationStatus.CreatedBy);

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

        public string UpdateInspectionReport(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_INSPECTION_REPORT";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@InspectionDate", objApplicationStatus.InspectionDate);

                com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@IndustryPersonName", objApplicationStatus.IndustryPersonName);
                com.Parameters.AddWithValue("@SystemRecommended", objApplicationStatus.SystemRecommended);

                com.Parameters.AddWithValue("@CapitalSubsidyAmount", objApplicationStatus.CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@AdditionalCapitalSubsidyAmount", objApplicationStatus.AdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@SystemCapitalSubsidyAmount", objApplicationStatus.SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.SystemAdditionalCapitalSubsidyAmount);


                com.Parameters.AddWithValue("@Actual_RecommendedAmount", objApplicationStatus.Actual_RecommendedAmount);
                com.Parameters.AddWithValue("@Actual_SystemRecommended", objApplicationStatus.Actual_SystemRecommended);
                com.Parameters.AddWithValue("@Actual_CapitalSubsidyAmount", objApplicationStatus.Actual_CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_AdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_AdditionalCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemCapitalSubsidyAmount", objApplicationStatus.Actual_SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_SystemAdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@Category", objApplicationStatus.Ins_Category);
                com.Parameters.AddWithValue("@TypeOfTextile", objApplicationStatus.Ins_TypeOfTextile);
                com.Parameters.AddWithValue("@Flag", objApplicationStatus.Ins_Flag);

                com.Parameters.AddWithValue("@PMXml", objApplicationStatus.PMXml);
                com.Parameters.AddWithValue("@AttachmentXml", objApplicationStatus.AttachmentXml);
                com.Parameters.AddWithValue("@DLOManualRecommendAmount", objApplicationStatus.DLOManualRecommendAmount);
                com.Parameters.AddWithValue("@InterestXml", objApplicationStatus.InterestXml);
                com.Parameters.AddWithValue("@BuildingXml", objApplicationStatus.BuildingXml);
                com.Parameters.AddWithValue("@EquipmentXml", objApplicationStatus.EquipmentXml);
                com.Parameters.AddWithValue("@DLOCalculatedLandAmount", objApplicationStatus.DLOCalculatedLandAmount);
                com.Parameters.AddWithValue("@DLOCalculatedBuildingAmount", objApplicationStatus.DLOCalculatedBuildingAmount);
                com.Parameters.AddWithValue("@DLOCalculatedPMAmount", objApplicationStatus.DLOCalculatedPMAmount);
                com.Parameters.AddWithValue("@DLOCalculatedOthersAmount", objApplicationStatus.DLOCalculatedOthersAmount);
                com.Parameters.AddWithValue("@DLOLandPerAcreValue", objApplicationStatus.DLOLandPerAcreValue);
                com.Parameters.AddWithValue("@DLOLandPerAcreRemarks", objApplicationStatus.DLOLandPerAcreRemarks);
                com.Parameters.AddWithValue("@DLORecommendedLandExtent", objApplicationStatus.DLORecommendedLandExtent);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);

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

        public string UpdateReInspectionReport(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_RE_INSPECTION_REPORT";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@InspectionDate", objApplicationStatus.InspectionDate);

                com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@IndustryPersonName", objApplicationStatus.IndustryPersonName);
                com.Parameters.AddWithValue("@SystemRecommended", objApplicationStatus.SystemRecommended);

                com.Parameters.AddWithValue("@CapitalSubsidyAmount", objApplicationStatus.CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@AdditionalCapitalSubsidyAmount", objApplicationStatus.AdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@SystemCapitalSubsidyAmount", objApplicationStatus.SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.SystemAdditionalCapitalSubsidyAmount);


                com.Parameters.AddWithValue("@Actual_RecommendedAmount", objApplicationStatus.Actual_RecommendedAmount);
                com.Parameters.AddWithValue("@Actual_SystemRecommended", objApplicationStatus.Actual_SystemRecommended);
                com.Parameters.AddWithValue("@Actual_CapitalSubsidyAmount", objApplicationStatus.Actual_CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_AdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_AdditionalCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemCapitalSubsidyAmount", objApplicationStatus.Actual_SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_SystemAdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@Category", objApplicationStatus.Ins_Category);
                com.Parameters.AddWithValue("@TypeOfTextile", objApplicationStatus.Ins_TypeOfTextile);
                com.Parameters.AddWithValue("@Flag", objApplicationStatus.Ins_Flag);

                com.Parameters.AddWithValue("@PMXml", objApplicationStatus.PMXml);
                com.Parameters.AddWithValue("@AttachmentXml", objApplicationStatus.AttachmentXml);
                com.Parameters.AddWithValue("@DLOManualRecommendAmount", objApplicationStatus.DLOManualRecommendAmount);
                com.Parameters.AddWithValue("@InterestXml", objApplicationStatus.InterestXml);
                com.Parameters.AddWithValue("@BuildingXml", objApplicationStatus.BuildingXml);
                com.Parameters.AddWithValue("@DLOCalculatedLandAmount", objApplicationStatus.DLOCalculatedLandAmount);
                com.Parameters.AddWithValue("@DLOCalculatedBuildingAmount", objApplicationStatus.DLOCalculatedBuildingAmount);
                com.Parameters.AddWithValue("@DLOCalculatedPMAmount", objApplicationStatus.DLOCalculatedPMAmount);
                com.Parameters.AddWithValue("@DLOCalculatedOthersAmount", objApplicationStatus.DLOCalculatedOthersAmount);
                com.Parameters.AddWithValue("@DLOLandPerAcreValue", objApplicationStatus.DLOLandPerAcreValue);
                com.Parameters.AddWithValue("@DLOLandPerAcreRemarks", objApplicationStatus.DLOLandPerAcreRemarks);
                com.Parameters.AddWithValue("@DLORecommendedLandExtent", objApplicationStatus.DLORecommendedLandExtent);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);

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

        public string UpdateInspectionReportdraft(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_INSPECTION_REPORT_DRAFT";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@InspectionDate", objApplicationStatus.InspectionDate);

                com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@IndustryPersonName", objApplicationStatus.IndustryPersonName);
                com.Parameters.AddWithValue("@SystemRecommended", objApplicationStatus.SystemRecommended);

                com.Parameters.AddWithValue("@CapitalSubsidyAmount", objApplicationStatus.CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@AdditionalCapitalSubsidyAmount", objApplicationStatus.AdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@SystemCapitalSubsidyAmount", objApplicationStatus.SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.SystemAdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@Actual_RecommendedAmount", objApplicationStatus.Actual_RecommendedAmount);
                com.Parameters.AddWithValue("@Actual_SystemRecommended", objApplicationStatus.Actual_SystemRecommended);
                com.Parameters.AddWithValue("@Actual_CapitalSubsidyAmount", objApplicationStatus.Actual_CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_AdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_AdditionalCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemCapitalSubsidyAmount", objApplicationStatus.Actual_SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_SystemAdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@Category", objApplicationStatus.Ins_Category);
                com.Parameters.AddWithValue("@TypeOfTextile", objApplicationStatus.Ins_TypeOfTextile);
                com.Parameters.AddWithValue("@Flag", objApplicationStatus.Ins_Flag);
                com.Parameters.AddWithValue("@IndustryDeptFlag", objApplicationStatus.IndustryDeptFlag);
                com.Parameters.AddWithValue("@IndustryDeptPersonName", objApplicationStatus.IndustryDeptPersonName);
                com.Parameters.AddWithValue("@IndustryDeptRemarks", objApplicationStatus.IndustryDeptRemarks);
                com.Parameters.AddWithValue("@IndustryDeptReportStatus", objApplicationStatus.IndustryDeptReportStatus);
                com.Parameters.AddWithValue("@DLOManualRecommendAmount", objApplicationStatus.DLOManualRecommendAmount);
                com.Parameters.AddWithValue("@PMXml", objApplicationStatus.PMXml);
                com.Parameters.AddWithValue("@InterestXml", objApplicationStatus.InterestXml);
                com.Parameters.AddWithValue("@BuildingXml", objApplicationStatus.BuildingXml);
                com.Parameters.AddWithValue("@EquipmentXml", objApplicationStatus.EquipmentXml);
                com.Parameters.AddWithValue("@DLOCalculatedLandAmount", objApplicationStatus.DLOCalculatedLandAmount);
                com.Parameters.AddWithValue("@DLOCalculatedBuildingAmount", objApplicationStatus.DLOCalculatedBuildingAmount);
                com.Parameters.AddWithValue("@DLOCalculatedPMAmount", objApplicationStatus.DLOCalculatedPMAmount);
                com.Parameters.AddWithValue("@DLOCalculatedOthersAmount", objApplicationStatus.DLOCalculatedOthersAmount);
                com.Parameters.AddWithValue("@DLOLandPerAcreValue", objApplicationStatus.DLOLandPerAcreValue);
                com.Parameters.AddWithValue("@DLOLandPerAcreRemarks", objApplicationStatus.DLOLandPerAcreRemarks);
                com.Parameters.AddWithValue("@DLORecommendedLandExtent", objApplicationStatus.DLORecommendedLandExtent);


                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);

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
        public string UpdateReInspectionReportdraft(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_RE_INSPECTION_REPORT_DRAFT";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@InspectionDate", objApplicationStatus.InspectionDate);

                com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@IndustryPersonName", objApplicationStatus.IndustryPersonName);
                com.Parameters.AddWithValue("@SystemRecommended", objApplicationStatus.SystemRecommended);

                com.Parameters.AddWithValue("@CapitalSubsidyAmount", objApplicationStatus.CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@AdditionalCapitalSubsidyAmount", objApplicationStatus.AdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@SystemCapitalSubsidyAmount", objApplicationStatus.SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.SystemAdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@Actual_RecommendedAmount", objApplicationStatus.Actual_RecommendedAmount);
                com.Parameters.AddWithValue("@Actual_SystemRecommended", objApplicationStatus.Actual_SystemRecommended);
                com.Parameters.AddWithValue("@Actual_CapitalSubsidyAmount", objApplicationStatus.Actual_CapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_AdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_AdditionalCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemCapitalSubsidyAmount", objApplicationStatus.Actual_SystemCapitalSubsidyAmount);
                com.Parameters.AddWithValue("@Actual_SystemAdditionalCapitalSubsidyAmount", objApplicationStatus.Actual_SystemAdditionalCapitalSubsidyAmount);

                com.Parameters.AddWithValue("@Category", objApplicationStatus.Ins_Category);
                com.Parameters.AddWithValue("@TypeOfTextile", objApplicationStatus.Ins_TypeOfTextile);
                com.Parameters.AddWithValue("@Flag", objApplicationStatus.Ins_Flag);
                com.Parameters.AddWithValue("@IndustryDeptFlag", objApplicationStatus.IndustryDeptFlag);
                com.Parameters.AddWithValue("@IndustryDeptPersonName", objApplicationStatus.IndustryDeptPersonName);
                com.Parameters.AddWithValue("@IndustryDeptRemarks", objApplicationStatus.IndustryDeptRemarks);
                com.Parameters.AddWithValue("@IndustryDeptReportStatus", objApplicationStatus.IndustryDeptReportStatus);
                com.Parameters.AddWithValue("@DLOManualRecommendAmount", objApplicationStatus.DLOManualRecommendAmount);
                com.Parameters.AddWithValue("@PMXml", objApplicationStatus.PMXml);
                com.Parameters.AddWithValue("@InterestXml", objApplicationStatus.InterestXml);
                com.Parameters.AddWithValue("@BuildingXml", objApplicationStatus.BuildingXml);
                com.Parameters.AddWithValue("@DLOCalculatedLandAmount", objApplicationStatus.DLOCalculatedLandAmount);
                com.Parameters.AddWithValue("@DLOCalculatedBuildingAmount", objApplicationStatus.DLOCalculatedBuildingAmount);
                com.Parameters.AddWithValue("@DLOCalculatedPMAmount", objApplicationStatus.DLOCalculatedPMAmount);
                com.Parameters.AddWithValue("@DLOCalculatedOthersAmount", objApplicationStatus.DLOCalculatedOthersAmount);
                com.Parameters.AddWithValue("@DLOLandPerAcreValue", objApplicationStatus.DLOLandPerAcreValue);
                com.Parameters.AddWithValue("@DLOLandPerAcreRemarks", objApplicationStatus.DLOLandPerAcreRemarks);
                com.Parameters.AddWithValue("@DLORecommendedLandExtent", objApplicationStatus.DLORecommendedLandExtent);


                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);

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
        public string QueryGenerationAttachemntDetails(AttachmentsQueriesParent ObjAttachmentsQueriesParent)
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
                com.CommandText = "USP_INS_UPD_QUERY_ATTACHMENT_LETTER";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@MainQueryID", ObjAttachmentsQueriesParent.MainQueryID);
                com.Parameters.AddWithValue("@IncentiveId", ObjAttachmentsQueriesParent.IncentiveId);
                com.Parameters.AddWithValue("@TransType", ObjAttachmentsQueriesParent.TransType);
                com.Parameters.AddWithValue("@QXml", ObjAttachmentsQueriesParent.xml);
                com.Parameters.AddWithValue("@Created_by", ObjAttachmentsQueriesParent.Created_by);

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
        public string GetCapitalSubsidySelected(string IncentiveID, string SubIncentiveId, string BuildingCalculatedIds, string PMIds, string Category, string TypeOfTextile, string Flag, ApplicationStatus objApplicationStatus, out string CalSystemSubsidy, out string CalSystemAdditionalCapitalSubsidy, out string LandValue,
            out string BuildingValue, out string PMValue, out string OthersValue)
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
                com.CommandText = "USP_CALCULATE_RECOMMENDED_AMOUNT";
                /* if (Flag == "Y") {
                     com.CommandText = "USP_CALCULATE_RECOMMENDED_AMOUNT_MODIFY";
                 }*/

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", IncentiveID);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);
                com.Parameters.AddWithValue("@BuildingCalculatedIds", BuildingCalculatedIds);
                com.Parameters.AddWithValue("@UnitCategory", Category);
                com.Parameters.AddWithValue("@UnitTypeofTextile", TypeOfTextile);
                /* if (Flag == "Y")
                 {
                     com.Parameters.AddWithValue("@UnitCategory", Category);
                     com.Parameters.AddWithValue("@UnitTypeofTextile", TypeOfTextile);
                 }*/

                com.Parameters.AddWithValue("@PMIds", PMIds);
                com.Parameters.AddWithValue("@PMXml", objApplicationStatus.PMXml);
                com.Parameters.AddWithValue("@BuildingXml", objApplicationStatus.BuildingXml);

                com.Parameters.Add("@RECOMMENDED_AMOUNT", SqlDbType.VarChar, 500);
                com.Parameters.Add("@CalSystemSubsidy", SqlDbType.VarChar, 500);
                com.Parameters.Add("@CalSystemAdditionalCapitalSubsidy", SqlDbType.VarChar, 500);
                com.Parameters.Add("@TotalLandValueOut", SqlDbType.VarChar, 500);
                com.Parameters.Add("@TotalBuildingValueOut", SqlDbType.VarChar, 500);
                com.Parameters.Add("@TotalPlantMachinaryValueOut", SqlDbType.VarChar, 500);
                com.Parameters.Add("@TotalOtherCostOut", SqlDbType.VarChar, 500);

                com.Parameters["@RECOMMENDED_AMOUNT"].Direction = ParameterDirection.Output;
                com.Parameters["@CalSystemSubsidy"].Direction = ParameterDirection.Output;
                com.Parameters["@CalSystemAdditionalCapitalSubsidy"].Direction = ParameterDirection.Output;
                com.Parameters["@TotalLandValueOut"].Direction = ParameterDirection.Output;
                com.Parameters["@TotalBuildingValueOut"].Direction = ParameterDirection.Output;
                com.Parameters["@TotalPlantMachinaryValueOut"].Direction = ParameterDirection.Output;
                com.Parameters["@TotalOtherCostOut"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@RECOMMENDED_AMOUNT"].Value.ToString();
                CalSystemSubsidy = com.Parameters["@CalSystemSubsidy"].Value.ToString();
                CalSystemAdditionalCapitalSubsidy = com.Parameters["@CalSystemAdditionalCapitalSubsidy"].Value.ToString();
                LandValue = com.Parameters["@TotalLandValueOut"].Value.ToString();
                BuildingValue = com.Parameters["@TotalBuildingValueOut"].Value.ToString();
                PMValue = com.Parameters["@TotalPlantMachinaryValueOut"].Value.ToString();
                OthersValue = com.Parameters["@TotalOtherCostOut"].Value.ToString();

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


        public string InsertTraineeDetails(TraineeDetailsBO objTraineeDetailsBO)
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
                com.CommandText = "[USP_INS_Trainee_Dtls]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Trainee_ID", objTraineeDetailsBO.Trainee_ID);
                com.Parameters.AddWithValue("@Incentive_id", objTraineeDetailsBO.IncentiveId);

                com.Parameters.AddWithValue("@NameoftheTrainee", objTraineeDetailsBO.NameoftheTrainee);
                com.Parameters.AddWithValue("@Trainingfromdate", objTraineeDetailsBO.Trainingfromdate);
                com.Parameters.AddWithValue("@Trainingtodate", objTraineeDetailsBO.Trainingtodate);
                com.Parameters.AddWithValue("@ExpenditureIncurred", objTraineeDetailsBO.ExpenditureIncurred);

                com.Parameters.AddWithValue("@TypeofTraining", objTraineeDetailsBO.TypeofTraining);
                com.Parameters.AddWithValue("@TraineeLocalization", objTraineeDetailsBO.TraineeLocalization);
                com.Parameters.AddWithValue("@TypeofTrainingText", objTraineeDetailsBO.TypeofTrainingText);
                com.Parameters.AddWithValue("@TraineeLocalizationText", objTraineeDetailsBO.TraineeLocalizationText);

                com.Parameters.AddWithValue("@CreatedBy", objTraineeDetailsBO.CreatedBy);
                com.Parameters.AddWithValue("@TransType", objTraineeDetailsBO.TransType);

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

        public string InsertISCurrentCliamDetails(EnergyConsumedBO objEnergyConsumedBO, out string DbErrorMsg)
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
                com.CommandText = "USP_INS_IS_CURRENTCLAIM_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@ISClaimPeriod_ID", objEnergyConsumedBO.EnergyConsumed_ID);
                com.Parameters.AddWithValue("@Incentive_id", objEnergyConsumedBO.IncentiveId);
                com.Parameters.AddWithValue("@FinancialYear", objEnergyConsumedBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objEnergyConsumedBO.FinancialYearText);
                com.Parameters.AddWithValue("@TypeOfFinancialYear", objEnergyConsumedBO.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objEnergyConsumedBO.TypeOfFinancialYearText);
                /*com.Parameters.AddWithValue("@TotalAmount", objEnergyConsumedBO.TotalAmount);*/
                com.Parameters.AddWithValue("@CreatedBy", objEnergyConsumedBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objEnergyConsumedBO.TransType);
                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;

                com.Parameters.Add("@DbErrorMsg", SqlDbType.VarChar, 500);
                com.Parameters["@DbErrorMsg"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();
                DbErrorMsg = com.Parameters["@DbErrorMsg"].Value.ToString();
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

        public string InsertISAdditionalInformationDetails(AdditionalinformationBO AdditionalinformationBOBO)
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
                com.CommandText = "USP_INS_IS_AADITIONALINFORMATION_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@AdditionalinformationId", AdditionalinformationBOBO.AdditionalinformationId);
                com.Parameters.AddWithValue("@Incentive_id", AdditionalinformationBOBO.IncentiveId);

                com.Parameters.AddWithValue("@TermLoan", AdditionalinformationBOBO.TermLoan);
                com.Parameters.AddWithValue("@MonthId", AdditionalinformationBOBO.MonthId);
                com.Parameters.AddWithValue("@MonthName", AdditionalinformationBOBO.Months);
                com.Parameters.AddWithValue("@BankId", AdditionalinformationBOBO.BankId);
                com.Parameters.AddWithValue("@BankName", AdditionalinformationBOBO.BankName);
                com.Parameters.AddWithValue("@AccountNumber", AdditionalinformationBOBO.AccountNumber);
                com.Parameters.AddWithValue("@TearmLoanAmount", AdditionalinformationBOBO.TearmLoanAmount);
                com.Parameters.AddWithValue("@InstallmentNo", AdditionalinformationBOBO.InstallmentNo);
                com.Parameters.AddWithValue("@RateofInterestAmountDue", AdditionalinformationBOBO.RateofInterestAmountDue);
                com.Parameters.AddWithValue("@InterestPaid", AdditionalinformationBOBO.InterestPaid);
                com.Parameters.AddWithValue("@ClosingBalance", AdditionalinformationBOBO.ClosingBalance);
                com.Parameters.AddWithValue("@EligibleRateInterest", AdditionalinformationBOBO.EligibleRateInterest);
                com.Parameters.AddWithValue("@EligibleInterest", AdditionalinformationBOBO.EligibleInterest);

                com.Parameters.AddWithValue("@CreatedBy", AdditionalinformationBOBO.Created_by);
                com.Parameters.AddWithValue("@TransType", AdditionalinformationBOBO.TransType);

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

        public string InsertingOfLandCostDtls(LandCostSubsidy objLandCostSubsidy)
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
                com.CommandText = "USP_INS_LANDCOSTSUBSIDY_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", objLandCostSubsidy.IncentiveId);

                com.Parameters.AddWithValue("@DateofEstablishmentofUnit", objLandCostSubsidy.DateofEstablishmentofUnit);
                com.Parameters.AddWithValue("@UtilizationETPCETP", objLandCostSubsidy.UtilizationETPCETP);
                com.Parameters.AddWithValue("@TexttileLocationTS", objLandCostSubsidy.TexttileLocationTS);
                com.Parameters.AddWithValue("@LandAllotmentInformation", objLandCostSubsidy.LandAllotmentInformation);
                com.Parameters.AddWithValue("@TotalPlinthArea", objLandCostSubsidy.TotalPlinthArea);
                com.Parameters.AddWithValue("@TotalExtentOfLandPurchased", objLandCostSubsidy.TotalExtentOfLandPurchased);
                com.Parameters.AddWithValue("@RatePerAcre", objLandCostSubsidy.RatePerAcre);
                com.Parameters.AddWithValue("@TotalInvestmentinLand", objLandCostSubsidy.TotalInvestmentinLand);
                com.Parameters.AddWithValue("@AmountAvailed", objLandCostSubsidy.AmountAvailed);
                com.Parameters.AddWithValue("@Source", objLandCostSubsidy.Source);
                com.Parameters.AddWithValue("@DateAvailed", objLandCostSubsidy.DateAvailed);
                com.Parameters.AddWithValue("@CurrentClaim", objLandCostSubsidy.CurrentClaim);
                com.Parameters.AddWithValue("@CreatedBy", objLandCostSubsidy.CreatedBy);

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


        public string InsertCapitalAssistanceExistingUnit(CapitalAssistanceforNewUnit cafnu)
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
                com.CommandText = "[USP_INS_CAPITAL_ASSISTANCE_EXISTINGUNIT]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Incentive_id", cafnu.IncentiveID);
                com.Parameters.AddWithValue("@NewTechnologiesfortextileprocessing", cafnu.NewTechnologiesfortextileprocessing);
                com.Parameters.AddWithValue("@Total", cafnu.Total);
                com.Parameters.AddWithValue("@AmountAvailed", cafnu.AmountAvailed);
                com.Parameters.AddWithValue("@SanctionOrderNo", cafnu.SanctionOrderNo);
                com.Parameters.AddWithValue("@DateAvailed", cafnu.DateAvailed);
                com.Parameters.AddWithValue("@CurrentClaimAmount", cafnu.CurrentClaimAmount);
                com.Parameters.AddWithValue("@CreatedBy", cafnu.UserId);

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

        public int RTGSNEFTPaymentDtls(RTGSNEFTPayment ObjRTGSNEFTPayment, List<OnlinePaymentDtls> lstOnlinePaymentDtls)
        {
            int valid = 0;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction trans = null;

            connection.Open();
            trans = connection.BeginTransaction();
            SqlCommand command = new SqlCommand("USP_INS_RTGS_NEFT_DTLS", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlCommand command1 = null;

            try
            {
                command.Parameters.AddWithValue("@IncentiveID", ObjRTGSNEFTPayment.IncentiveID);
                command.Parameters.AddWithValue("@TTAPBillerID", ObjRTGSNEFTPayment.TTAPBillerID);
                command.Parameters.AddWithValue("@PaymentMode", ObjRTGSNEFTPayment.PaymentMode);
                command.Parameters.AddWithValue("@UTRNo", ObjRTGSNEFTPayment.UTRNo);
                command.Parameters.AddWithValue("@DateofRemittance", ObjRTGSNEFTPayment.DateofRemittance);
                command.Parameters.AddWithValue("@ACTUALAMOUNT", ObjRTGSNEFTPayment.ACTUALAMOUNT);
                command.Parameters.AddWithValue("@Amount", ObjRTGSNEFTPayment.Amount);
                command.Parameters.AddWithValue("@NameoftheBank", ObjRTGSNEFTPayment.NameoftheBank);
                command.Parameters.AddWithValue("@Branch", ObjRTGSNEFTPayment.Branch);
                command.Parameters.AddWithValue("@CreatedBy", ObjRTGSNEFTPayment.CreatedBy);
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;

                command.Transaction = trans;
                command.ExecuteNonQuery();
                valid = (Int32)command.Parameters["@VALID"].Value;

                if (valid >= 0)
                {
                    foreach (OnlinePaymentDtls objOnlinePaymentDtls in lstOnlinePaymentDtls)
                    {
                        command1 = new SqlCommand("USP_INSERT_PaymentDtls", connection);
                        command1.CommandType = CommandType.StoredProcedure;
                        command1.Parameters.AddWithValue("@ApplicationNumber", objOnlinePaymentDtls.ApplicationNumber);
                        command1.Parameters.AddWithValue("@IncentiveID", objOnlinePaymentDtls.IncentiveID);
                        command1.Parameters.AddWithValue("@SubIncentiveID", objOnlinePaymentDtls.SubIncentiveID);
                        command1.Parameters.AddWithValue("@TTAPBillerID", objOnlinePaymentDtls.TTAPBillerID);
                        command1.Parameters.AddWithValue("@PaymentMode", objOnlinePaymentDtls.PaymentMode);
                        command1.Parameters.AddWithValue("@ApplicationFee", objOnlinePaymentDtls.ApplicationFee);
                        command1.Parameters.AddWithValue("@Tax_Amount", objOnlinePaymentDtls.Tax_Amount);
                        command1.Parameters.AddWithValue("@Total_Amount", objOnlinePaymentDtls.Total_Amount);
                        command1.Parameters.AddWithValue("@CreatedBy", objOnlinePaymentDtls.CreatedBy);
                        command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                        command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                        command1.Transaction = trans;
                        command1.ExecuteNonQuery();
                        valid = (Int32)command1.Parameters["@VALID"].Value;
                    }
                }
                trans.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                trans.Rollback();

                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public int RTGSNEFTPaymentDtls_1(RTGSNEFTPayment ObjRTGSNEFTPayment)
        {
            int valid = 0;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction trans = null;

            connection.Open();
            trans = connection.BeginTransaction();
            SqlCommand command = new SqlCommand("USP_INSERT_PaymentDtls_PG", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.Parameters.AddWithValue("@ApplicationNumber", ObjRTGSNEFTPayment.ApplicationNumber);
                command.Parameters.AddWithValue("@IncentiveID", ObjRTGSNEFTPayment.IncentiveID);
                command.Parameters.AddWithValue("@TTAPBillerID", ObjRTGSNEFTPayment.TTAPBillerID);
                command.Parameters.AddWithValue("@PaymentMode", ObjRTGSNEFTPayment.PaymentMode);
                command.Parameters.AddWithValue("@ApplicationFee", ObjRTGSNEFTPayment.ApplicationFee);
                command.Parameters.AddWithValue("@Tax_Amount", ObjRTGSNEFTPayment.Tax_Amount);
                command.Parameters.AddWithValue("@Total_Amount", ObjRTGSNEFTPayment.Total_Amount);
                command.Parameters.AddWithValue("@PGRefNo", ObjRTGSNEFTPayment.PGRefNo);
                command.Parameters.AddWithValue("@CreatedBy", ObjRTGSNEFTPayment.CreatedBy);
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;

                command.Transaction = trans;
                command.ExecuteNonQuery();
                valid = (Int32)command.Parameters["@VALID"].Value;
                trans.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                trans.Rollback();

                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public int UpdateManualPayment(string TTAPBillerID, decimal ApplicationFee, decimal Tax_Amount, string PGRefNo)
        {
            int valid = 0;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction trans = null;

            connection.Open();
            trans = connection.BeginTransaction();
            SqlCommand command = new SqlCommand("USP_INSERT_Manual_PaymentDtls_PG", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.Parameters.AddWithValue("@TTAPBillerID", TTAPBillerID);
                command.Parameters.AddWithValue("@ApplicationFee", ApplicationFee);
                command.Parameters.AddWithValue("@Tax_Amount", Tax_Amount);
                command.Parameters.AddWithValue("@PGRefNo", PGRefNo);
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;

                command.Transaction = trans;
                command.ExecuteNonQuery();
                valid = (Int32)command.Parameters["@VALID"].Value;
                trans.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                trans.Rollback();

                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        public int OnlinePaymentDtls(List<OnlinePaymentDtls> lstOnlinePaymentDtls)
        {
            int valid = 0;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction trans = null;
            connection.Open();
            trans = connection.BeginTransaction();
            SqlCommand command1 = null;

            try
            {
                foreach (OnlinePaymentDtls objOnlinePaymentDtls in lstOnlinePaymentDtls)
                {
                    command1 = new SqlCommand("USP_INSERT_PaymentDtls", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@ApplicationNumber", objOnlinePaymentDtls.ApplicationNumber);
                    command1.Parameters.AddWithValue("@IncentiveID", objOnlinePaymentDtls.IncentiveID);
                    command1.Parameters.AddWithValue("@SubIncentiveID", objOnlinePaymentDtls.SubIncentiveID);
                    command1.Parameters.AddWithValue("@TTAPBillerID", objOnlinePaymentDtls.TTAPBillerID);
                    command1.Parameters.AddWithValue("@PaymentMode", objOnlinePaymentDtls.PaymentMode);
                    command1.Parameters.AddWithValue("@ApplicationFee", objOnlinePaymentDtls.ApplicationFee);
                    command1.Parameters.AddWithValue("@Tax_Amount", objOnlinePaymentDtls.Tax_Amount);
                    command1.Parameters.AddWithValue("@Total_Amount", objOnlinePaymentDtls.Total_Amount);
                    command1.Parameters.AddWithValue("@PGRefNo", objOnlinePaymentDtls.PGRefNo);
                    command1.Parameters.AddWithValue("@CreatedBy", objOnlinePaymentDtls.CreatedBy);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }

                trans.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                trans.Rollback();

                throw ex;
            }
            finally
            {
                command1.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }

        public string UpdateNEFTRTGSPaymentStatus(DeptPaymentApprovalStatus ObjDeptPaymentApprovalStatus)
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
                com.CommandText = "USP_UPD_NEFTRTGSPAYMENT_DETAILS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", ObjDeptPaymentApprovalStatus.IncentiveID);
                com.Parameters.AddWithValue("@OnlineOrderNumber", ObjDeptPaymentApprovalStatus.OnlineOrderNumber);
                com.Parameters.AddWithValue("@Status", ObjDeptPaymentApprovalStatus.Status);
                com.Parameters.AddWithValue("@Remarks", ObjDeptPaymentApprovalStatus.Remarks);
                com.Parameters.AddWithValue("@CreatedBy", ObjDeptPaymentApprovalStatus.CreatedBy);

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

        public string InsertIndirectEmployment(IndirectEmploymentVo objIndirectEmploymentVo)
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
                com.CommandText = "USP_INS_IndirectEmployment_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IndirectEmploymentID", objIndirectEmploymentVo.IndirectEmploymentID);
                com.Parameters.AddWithValue("@Category", objIndirectEmploymentVo.Category);
                com.Parameters.AddWithValue("@IndirectMale", objIndirectEmploymentVo.IndirectMale);
                com.Parameters.AddWithValue("@IndirectFemale", objIndirectEmploymentVo.IndirectFemale);
                com.Parameters.AddWithValue("@IncentiveId", objIndirectEmploymentVo.IncentiveId);
                com.Parameters.AddWithValue("@Created_by", objIndirectEmploymentVo.Created_by);
                com.Parameters.AddWithValue("@TransType", objIndirectEmploymentVo.TransType);


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

        public string InsertExportRevenueTransportSubsidy(ExportRevenueBO objExportRevenueBO)
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
                com.CommandText = "USP_INS_Export_Revenue_Details";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@ExportRevenueID", objExportRevenueBO.ExportRevenueID);
                com.Parameters.AddWithValue("@Incentive_id", objExportRevenueBO.IncentiveId);
                com.Parameters.AddWithValue("@FinancialYear", objExportRevenueBO.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objExportRevenueBO.FinancialYearText);

                com.Parameters.AddWithValue("@ProductionValue", objExportRevenueBO.ProductionValue);
                com.Parameters.AddWithValue("@SaleRevenue", objExportRevenueBO.SaleRevenue);
                com.Parameters.AddWithValue("@ExportSalesValue", objExportRevenueBO.ExportSalesValue);
                com.Parameters.AddWithValue("@FreightCharges", objExportRevenueBO.FreightCharges);

                com.Parameters.AddWithValue("@CreatedBy", objExportRevenueBO.Created_by);
                com.Parameters.AddWithValue("@TransType", objExportRevenueBO.TransType);

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

        public string InsertCurrentFinancialYearTransportSubsidy(CurrentClaimFinancialBo objCurrentClaimFinancialBo)
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
                com.CommandText = "USP_INS_CurrentFinancialClaim_Details";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CurrentClaimFinancialID", objCurrentClaimFinancialBo.CurrentClaimFinancialID);
                com.Parameters.AddWithValue("@Incentive_id", objCurrentClaimFinancialBo.IncentiveId);
                com.Parameters.AddWithValue("@FinancialYear", objCurrentClaimFinancialBo.FinancialYear);
                com.Parameters.AddWithValue("@FinancialYearText", objCurrentClaimFinancialBo.FinancialYearText);

                com.Parameters.AddWithValue("@TypeOfFinancialYear", objCurrentClaimFinancialBo.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", objCurrentClaimFinancialBo.TypeOfFinancialYearText);

                com.Parameters.AddWithValue("@CurrentClaimmadeYear", objCurrentClaimFinancialBo.CurrentClaimmadeYear);
                com.Parameters.AddWithValue("@CurrentClaimmadeYearText", objCurrentClaimFinancialBo.CurrentClaimmadeYearText);


                com.Parameters.AddWithValue("@Totalproduction", objCurrentClaimFinancialBo.Totalproduction);
                com.Parameters.AddWithValue("@TotalSaleRevenue", objCurrentClaimFinancialBo.TotalSaleRevenue);
                com.Parameters.AddWithValue("@TotalExportRevenue", objCurrentClaimFinancialBo.TotalExportRevenue);
                com.Parameters.AddWithValue("@FreightPurchaseRawMaterial", objCurrentClaimFinancialBo.FreightPurchaseRawMaterial);
                com.Parameters.AddWithValue("@FreightExportFinishedGoods", objCurrentClaimFinancialBo.FreightExportFinishedGoods);

                com.Parameters.AddWithValue("@CreatedBy", objCurrentClaimFinancialBo.Created_by);
                com.Parameters.AddWithValue("@TransType", objCurrentClaimFinancialBo.TransType);

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

        public DataSet GetFinancialYears(string Date)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DCP",SqlDbType.VarChar)
           };
            pp[0].Value = Date;
            Dsnew = GenericFillDs("USP_GET_LASTTHREE_FINANCIALYEARS", pp);
            return Dsnew;
        }
        public DataSet GetClaimFinancialYear(string Count, string incentiveid, string SubIncentiveID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@YEARS",SqlDbType.VarChar),
                new SqlParameter("@incentiveid",SqlDbType.VarChar),
                new SqlParameter("@SubIncentiveID",SqlDbType.VarChar)
           };
            pp[0].Value = Count;
            pp[1].Value = incentiveid;
            pp[2].Value = SubIncentiveID;
            Dsnew = GenericFillDs("USP_GET_FINANCIALYEARS_CLAIM", pp);
            return Dsnew;
        }
        public string InsertISMoratoriumPeriodDetails(MoratoriumPeriodBO MoratoriumPeriodBO)
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
                com.CommandText = "USP_INS_IS_MoratoriumPeriod_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@MoratoriumPeriod_ID", MoratoriumPeriodBO.MoratoriumPeriod_ID);
                com.Parameters.AddWithValue("@Incentive_id", MoratoriumPeriodBO.IncentiveId);
                com.Parameters.AddWithValue("@TypeOfFinancialYear", MoratoriumPeriodBO.TypeOfFinancialYear);
                com.Parameters.AddWithValue("@TypeOfFinancialYearText", MoratoriumPeriodBO.TypeOfFinancialYearText);

                com.Parameters.AddWithValue("@FromDate", MoratoriumPeriodBO.FromDate);
                com.Parameters.AddWithValue("@Todate", MoratoriumPeriodBO.Todate);
                com.Parameters.AddWithValue("@RateofInterest", MoratoriumPeriodBO.RateofInterest);
                com.Parameters.AddWithValue("@BankID", MoratoriumPeriodBO.BankID);

                com.Parameters.AddWithValue("@CreatedBy", MoratoriumPeriodBO.Created_by);
                com.Parameters.AddWithValue("@TransType", MoratoriumPeriodBO.TransType);

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

        public string InsertPMAbstract(PMAbstractVo objPMAbstractVo)
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
                com.CommandText = "USP_INS_PMAbstract_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@PMAbstractID", objPMAbstractVo.PMAbstractID);
                com.Parameters.AddWithValue("@TypeOfMachinery", objPMAbstractVo.TypeOfMachinery);
                com.Parameters.AddWithValue("@Noofmachines", objPMAbstractVo.Noofmachines);
                com.Parameters.AddWithValue("@AttachmentId", objPMAbstractVo.AttachmentId);
                //com.Parameters.AddWithValue("@AttachmentId2", objPMAbstractVo.AttachmentId2);
                com.Parameters.AddWithValue("@IncentiveId", objPMAbstractVo.IncentiveId);
                com.Parameters.AddWithValue("@Created_by", objPMAbstractVo.Created_by);
                com.Parameters.AddWithValue("@TransType", objPMAbstractVo.TransType);

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

        public string UpdateApplicationStatusDLOStage3(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_RECOMMENDATION_QUERY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@ReInspectionDate", objApplicationStatus.ReInspectionDate);
                com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);

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

        public string UpdateApplicationStatusJDStage4(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_JD_RECOMMENDATION_QUERY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                if (objApplicationStatus.PartialSanction == "P" || objApplicationStatus.PartialSanction == "CP")
                {
                    com.Parameters.AddWithValue("@JDRecommendedAmount", objApplicationStatus.JDRecommendedAmount);
                    com.Parameters.AddWithValue("@PartialRemarks", objApplicationStatus.PartialRemarks);
                    com.Parameters.AddWithValue("@PartialSanction", objApplicationStatus.PartialSanction);
                }
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

        public DataSet GetDLCYetGenerateAgenda(string DistID, string Stage)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            Dsnew = GenericFillDs("USP_GET_DLC_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetSLCYetGenerateAgenda(string DistID, string Stage, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_SLC_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetDLSVCYetGenerateAgenda(string DistID, string Stage)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            Dsnew = GenericFillDs("USP_GET_DLSVC_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetSVCYetGenerateAgenda(string DistID, string Stage, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_SVC_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetDLCYetGenerateAgendaList(string Cast, string IncetiveID, string distid, string Stage)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;

            Dsnew = GenericFillDs("USP_GET_DLC_AGENDA_LIST", pp);
            return Dsnew;
        }
        public DataSet GetSLCYetGenerateAgendaList(string Cast, string IncetiveID, string distid, string Stage, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;
            pp[4].Value = PartialSanction;

            Dsnew = GenericFillDs("USP_GET_SLC_AGENDA_LIST", pp);
            return Dsnew;
        }
        public DataSet GetDLSVCYetGenerateAgendaList(string Cast, string IncetiveID, string distid, string Stage)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;

            Dsnew = GenericFillDs("USP_GET_DLSVC_AGENDA_LIST", pp);
            return Dsnew;
        }
        public DataSet GetSVCYetGenerateAgendaList(string Cast, string IncetiveID, string distid, string Stage, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;
            pp[4].Value = PartialSanction;

            Dsnew = GenericFillDs("USP_GET_SVC_AGENDA_LIST", pp);
            return Dsnew;
        }
        public string GenerateDLCProposedAgenda(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_UPDATEPROPOSEDDIPCDATE";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ProposedDLCDate", objApplicationStatus.ProposedDLCDate);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);

                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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

        public string GenerateSLCProposedAgenda(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_UPDATEPROPOSEDDIPCDATE";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ProposedDLCDate", objApplicationStatus.ProposedDLCDate);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.AddWithValue("@PartialSanction", objApplicationStatus.PartialSanction);
                    com.Parameters.AddWithValue("@TISId", objApplicationStatus.TISId);

                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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

        public string GenerateDLSVCProposedAgenda(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_UPDATEPROPOSED_DLSVCDATE";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ProposedDLCDate", objApplicationStatus.ProposedDLCDate);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.AddWithValue("@PartialSanction", objApplicationStatus.PartialSanction);
                    com.Parameters.AddWithValue("@TISId", objApplicationStatus.TISId);

                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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

        public DataSet GetDLCGenerateDAgendaProposedDates(string DistID, string Stage, string transType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = transType;
            Dsnew = GenericFillDs("USP_GET_PROPOSED_DLC_DATES", pp);
            return Dsnew;
        }
        public DataSet GetSLCGenerateDAgendaProposedDates(string DistID, string Stage, string transType, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = transType;
            pp[3].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_PROPOSED_SLC_DATES", pp);
            return Dsnew;
        }
        public DataSet GetDLSVCGenerateDAgendaProposedDates(string DistID, string Stage, string transType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = transType;
            Dsnew = GenericFillDs("USP_GET_PROPOSED_DLSVC_DATES", pp);
            return Dsnew;
        }
        public DataSet GetSVCGenerateDAgendaProposedDates(string DistID, string Stage, string transType, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = transType;
            pp[3].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_PROPOSED_SVC_DATES", pp);
            return Dsnew;
        }
        public DataSet GetDLCGeneratedAgenda(string DistID, string Stage, string Date, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = Date;
            pp[3].Value = TransType;
            Dsnew = GenericFillDs("USP_GET_DLC_GENERATED_AGENDA_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetSLCGeneratedAgenda(string DistID, string Stage, string Date, string TransType, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = Date;
            pp[3].Value = TransType;
            pp[4].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_SLC_GENERATED_AGENDA_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetDLSVCGeneratedAgenda(string DistID, string Stage, string Date, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = Date;
            pp[3].Value = TransType;
            Dsnew = GenericFillDs("USP_GET_DLSVC_GENERATED_AGENDA_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetSVCGeneratedAgenda(string DistID, string Stage, string Date, string TransType, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTID",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = DistID;
            pp[1].Value = Stage;
            pp[2].Value = Date;
            pp[3].Value = TransType;
            pp[4].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_SVC_GENERATED_AGENDA_ABSTRACT", pp);
            return Dsnew;
        }
        public DataSet GetDLCGeneratedAgendaList(string Cast, string IncetiveID, string distid, string Stage, string Date, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;
            pp[4].Value = Date;
            pp[5].Value = TransType;
            Dsnew = GenericFillDs("USP_GET_DLC_GENERATED_AGENDA_LIST", pp);
            return Dsnew;
        }
        public DataSet GetSLCGeneratedAgendaList(string Cast, string IncetiveID, string distid, string Stage, string Date, string TransType, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;
            pp[4].Value = Date;
            pp[5].Value = TransType;
            pp[6].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_SLC_GENERATED_AGENDA_LIST", pp);
            return Dsnew;
        }
        public DataSet GetSLCGeneratedIssueList(string IncentiveId, string SubIncentiveId, string distid)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = distid;
            Dsnew = GenericFillDs("USP_GET_SLC_GENERATED_ISSUED_LIST", pp);
            return Dsnew;
        }
        public DataSet GetDLSVCGeneratedAgendaList(string Cast, string IncetiveID, string distid, string Stage, string Date, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;
            pp[4].Value = Date;
            pp[5].Value = TransType;
            Dsnew = GenericFillDs("USP_GET_DLSVC_GENERATED_AGENDA_LIST", pp);
            return Dsnew;
        }
        public DataSet GetSVCGeneratedAgendaList(string Cast, string IncetiveID, string distid, string Stage, string Date, string TransType, string PartialSanction)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar),
               new SqlParameter("@distid",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@Date",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar),
               new SqlParameter("@PartialSanction",SqlDbType.VarChar)
           };
            pp[0].Value = IncetiveID;
            pp[1].Value = Cast;
            pp[2].Value = distid;
            pp[3].Value = Stage;
            pp[4].Value = Date;
            pp[5].Value = TransType;
            pp[6].Value = PartialSanction;
            Dsnew = GenericFillDs("USP_GET_SVC_GENERATED_AGENDA_LIST", pp);
            return Dsnew;
        }
        public string UpdateGeneratedDLCProposedAgenda(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_DLC_DETAILS";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ApproveStatus", objApplicationStatus.ApproveStatus);
                    com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                    com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                    com.Parameters.AddWithValue("@FilePath", objApplicationStatus.FilePath);
                    com.Parameters.AddWithValue("@ProposedDLCDate", objApplicationStatus.ProposedDLCDate);
                    com.Parameters.AddWithValue("@DLCNo", objApplicationStatus.DLCNo);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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
        public string UpdateGeneratedSLCProposedAgenda(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_SLC_DETAILS";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ApproveStatus", objApplicationStatus.ApproveStatus);
                    com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                    com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                    com.Parameters.AddWithValue("@FilePath", objApplicationStatus.FilePath);
                    com.Parameters.AddWithValue("@ProposedDLCDate", objApplicationStatus.ProposedDLCDate);
                    com.Parameters.AddWithValue("@DLCNo", objApplicationStatus.DLCNo);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.AddWithValue("@PartialSanction", objApplicationStatus.PartialSanction);
                    com.Parameters.AddWithValue("@TISId", objApplicationStatus.TISId);
                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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
        public string IssueSanctuionedLetter(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_ISSUE_SANCTIONED_LETTER";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@SanctionedLetterFilePath", objApplicationStatus.SanctionedLetterFilePath);
                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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
        public string UpdateGeneratedDLSVCProposedAgenda(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_DLSVC_DETAILS";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ApproveStatus", objApplicationStatus.ApproveStatus);
                    com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                    com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                    com.Parameters.AddWithValue("@FilePath", objApplicationStatus.FilePath);
                    com.Parameters.AddWithValue("@ProposedDLCDate", objApplicationStatus.ProposedDLCDate);
                    com.Parameters.AddWithValue("@DLCNo", objApplicationStatus.DLCNo);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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

        public string UpdateGeneratedSVCProposedAgenda(List<ApplicationStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ApplicationStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_UPD_SVC_DETAILS";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ApproveStatus", objApplicationStatus.ApproveStatus);
                    com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                    com.Parameters.AddWithValue("@RecommendedAmount", objApplicationStatus.RecommendedAmount);
                    com.Parameters.AddWithValue("@TextileSanctionedAmount", objApplicationStatus.TextileSanctionedAmount);
                    com.Parameters.AddWithValue("@IndustriesSanctionedAmount", objApplicationStatus.IndustriesSanctionedAmount);
                    com.Parameters.AddWithValue("@FilePath", objApplicationStatus.FilePath);
                    com.Parameters.AddWithValue("@ProposedDLCDate", objApplicationStatus.ProposedDLCDate);
                    com.Parameters.AddWithValue("@DLCNo", objApplicationStatus.DLCNo);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@PartialSanction", objApplicationStatus.PartialSanction);
                    com.Parameters.AddWithValue("@TISId", objApplicationStatus.TISId);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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

        public string GOfundRegistration(GOUploads objGOUploads)
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
                com.CommandText = "USP_INS_Tbl_GO_Fund_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@GOID", objGOUploads.GOID);
                com.Parameters.AddWithValue("@TransType", objGOUploads.TransType);

                com.Parameters.AddWithValue("@GONo", objGOUploads.GONo);
                com.Parameters.AddWithValue("@GODate", objGOUploads.GODate);
                com.Parameters.AddWithValue("@LOCNo", objGOUploads.LOCNo);
                com.Parameters.AddWithValue("@LOCDate", objGOUploads.LOCDate);
                com.Parameters.AddWithValue("@GOPathID", objGOUploads.GOPathID);
                com.Parameters.AddWithValue("@AmountReleased", objGOUploads.AmountReleased);
                com.Parameters.AddWithValue("@CreatedBy", objGOUploads.CreatedBy);
                com.Parameters.AddWithValue("@Remarks", objGOUploads.Remarks);

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
        public string UpdateUplodedFileName(string IncentiveId, string SubIncentiveID, string FileDesc, string DocID)
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
                com.CommandText = "USP_UPD_DOC_FILEDESCRIPTION";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveID", SubIncentiveID);
                com.Parameters.AddWithValue("@FileDesc", FileDesc);
                com.Parameters.AddWithValue("@DocID", DocID);

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
        public DataSet GetReleaseList(string Stage, string ApplicationMode, string Category, string SubIncentiveID, string GOID, string IncentiveID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@ApplicationMode",SqlDbType.VarChar),
               new SqlParameter("@Category",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveID",SqlDbType.VarChar),
               new SqlParameter("@GOID",SqlDbType.VarChar),
               new SqlParameter("@IncentiveID",SqlDbType.VarChar)
           };

            pp[0].Value = Stage;
            pp[1].Value = ApplicationMode;
            pp[2].Value = Category;
            pp[3].Value = SubIncentiveID;
            pp[4].Value = GOID;
            pp[5].Value = IncentiveID;

            Dsnew = GenericFillDs("USP_GET_RELEASE_LIST", pp);
            return Dsnew;
        }
        public DataSet GetPartialReleaseListView(string Stage, string ApplicationMode, string Category, string SubIncentiveID, string GOID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@ApplicationMode",SqlDbType.VarChar),
               new SqlParameter("@Category",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveID",SqlDbType.VarChar),
               new SqlParameter("@GOID",SqlDbType.VarChar)
           };

            pp[0].Value = Stage;
            pp[1].Value = ApplicationMode;
            pp[2].Value = Category;
            pp[3].Value = SubIncentiveID;
            pp[4].Value = GOID;

            Dsnew = GenericFillDs("USP_GET_PARTIAL_RELEASE_LIST_VIEW", pp);
            return Dsnew;
        }
        public DataSet GetCompleteReleasedIncentivesList(string Stage)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Stage",SqlDbType.VarChar)
           };

            pp[0].Value = Stage;

            Dsnew = GenericFillDs("USP_GET_COMPLETE_RELEASED_INCENTIVES", pp);
            return Dsnew;
        }
        public DataSet GetNoOfPartialIncentivesReleases(string IncentiveId, string SubIncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar)
           };

            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;

            Dsnew = GenericFillDs("USP_GET_INCENTIVES_PARTAIL_RELEASE_DTLS", pp);
            return Dsnew;
        }
        public string ReleaseProceedingsInsert(List<ReleaseProceedingStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ReleaseProceedingStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_INS_RELEASES_PROCEEDINGS";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ReleasedAmount", objApplicationStatus.ReleasedAmount);
                    com.Parameters.AddWithValue("@FilePath", objApplicationStatus.FilePath);
                    com.Parameters.AddWithValue("@ReleaseProcedingDate", objApplicationStatus.ReleaseProcedingDate);
                    com.Parameters.AddWithValue("@ReleaseProcedingNo", objApplicationStatus.ReleaseProcedingNo);
                    com.Parameters.AddWithValue("@GOID", objApplicationStatus.GOID);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.AddWithValue("@ReleaseFlag", objApplicationStatus.ReleaseFlag);

                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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

        public string PartialReleaseProceedingsInsert(List<ReleaseProceedingStatus> lstApplicationStatus)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (ReleaseProceedingStatus objApplicationStatus in lstApplicationStatus)
                {
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "USP_INS_PARTIAL_RELEASES_PROCEEDINGS";

                    com.Transaction = transaction;
                    com.Connection = connection;

                    com.Parameters.AddWithValue("@IncentiveId", objApplicationStatus.IncentiveId);
                    com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                    com.Parameters.AddWithValue("@ReleasedAmount", objApplicationStatus.ReleasedAmount);
                    com.Parameters.AddWithValue("@FilePath", objApplicationStatus.FilePath);
                    com.Parameters.AddWithValue("@ReleaseProcedingDate", objApplicationStatus.ReleaseProcedingDate);
                    com.Parameters.AddWithValue("@ReleaseProcedingNo", objApplicationStatus.ReleaseProcedingNo);
                    com.Parameters.AddWithValue("@GOID", objApplicationStatus.GOID);
                    com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                    com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                    com.Parameters.AddWithValue("@ReleaseFlag", objApplicationStatus.ReleaseFlag);

                    com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                    com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();

                    valid = com.Parameters["@Valid"].Value.ToString();
                }
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

        public DataSet GetPartialReleaseList(string Stage, string ApplicationMode, string Category, string SubIncentiveID, string GOID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@ApplicationMode",SqlDbType.VarChar),
               new SqlParameter("@Category",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveID",SqlDbType.VarChar),
               new SqlParameter("@GOID",SqlDbType.VarChar)
           };

            pp[0].Value = Stage;
            pp[1].Value = ApplicationMode;
            pp[2].Value = Category;
            pp[3].Value = SubIncentiveID;
            pp[4].Value = GOID;

            Dsnew = GenericFillDs("USP_GET_PARTIAL_RELEASE_LIST", pp);
            return Dsnew;
        }

        public string Check_RegularIncentive(string IncentiveId, string SubIncentiveID, string CreatedBy)
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
                com.CommandText = "USP_CHECK_REGULARINCENTIVE";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveID", SubIncentiveID);
                com.Parameters.AddWithValue("@CreatedBy", CreatedBy);

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

        public string Check_EnableCapital_Subsidy(string CreatedBy)
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
                com.CommandText = "USP_CHECK_ENABLE_CAPITAL_SUBSIDY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@CreatedBy", CreatedBy);

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

        public string Check_LandAndBuildingDetailsEntry(string IncentiveId, string IndsType, string CreatedBy)
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
                com.CommandText = "USP_CHECK_LandAndBuildingDtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@IndsType", IndsType);
                com.Parameters.AddWithValue("@CreatedBy", CreatedBy);

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

        public string Check_CafDataValidation(IncentivesVOs objvo)
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
                com.CommandText = "USP_CHECK_VALIDDATA";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo.IncentveID);
                com.Parameters.AddWithValue("@DCP", objvo.DateOfComm);
                com.Parameters.AddWithValue("@DCPExp", objvo.DateOfCommExp);
                com.Parameters.AddWithValue("@AppsLevel", objvo.AppsLevel);

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
        public string InsertQueryletterGenerationDetails(QueryGenerationVo ObjQueryGenerationVo, out string MainQueryID)
        {
            string valid = "";
            MainQueryID = "0";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_QueryLetterGeneration_Dtls";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@MainQueryID", ObjQueryGenerationVo.MainQueryID);
                com.Parameters.AddWithValue("@QueryId", ObjQueryGenerationVo.QueryId);
                com.Parameters.AddWithValue("@IncentiveId", ObjQueryGenerationVo.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveID", ObjQueryGenerationVo.SubIncentiveID);
                com.Parameters.AddWithValue("@Query", ObjQueryGenerationVo.Query);
                com.Parameters.AddWithValue("@CreatedBy", ObjQueryGenerationVo.Created_by);
                com.Parameters.AddWithValue("@TransType", ObjQueryGenerationVo.TransType);

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;

                com.Parameters.Add("@NewMainQueryID", SqlDbType.VarChar, 500);
                com.Parameters["@NewMainQueryID"].Direction = ParameterDirection.Output;

                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();
                MainQueryID = com.Parameters["@NewMainQueryID"].Value.ToString();

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

        public string InsertQueryletterApprovals(QueryGenerationVo ObjQueryGenerationVo)
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
                com.CommandText = "USP_INS_QUERYLETTER_PROCESS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", ObjQueryGenerationVo.IncentiveId);
                com.Parameters.AddWithValue("@MainQueryID", ObjQueryGenerationVo.MainQueryID);
                com.Parameters.AddWithValue("@TransType", ObjQueryGenerationVo.TransType);
                com.Parameters.AddWithValue("@CreatedBy", ObjQueryGenerationVo.Created_by);
                com.Parameters.AddWithValue("@Transfered", ObjQueryGenerationVo.Transfered);

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

        public string DeleteUploadedAttachment(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "[USP_DELETE_UploadedAttachment]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@AttachmentUploadedID", objApplicationStatus.AttachmentUploadedID);
                com.Parameters.AddWithValue("@TransType", objApplicationStatus.TransType);
                com.Parameters.AddWithValue("@Created_by", objApplicationStatus.CreatedBy);

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
        public string InseringModuleDetails(ModuleVos ObjModuleVos)
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
                com.CommandText = "[USP_INS_MODULE_DTLS]";

                com.Transaction = transaction;
                com.Connection = connection;


                com.Parameters.AddWithValue("@ApplicationId", ObjModuleVos.ApplicationId);
                com.Parameters.AddWithValue("@MainModule_Code", ObjModuleVos.MainModule_Code);
                com.Parameters.AddWithValue("@MainModule", ObjModuleVos.MainModule);


                com.Parameters.AddWithValue("@TransType", ObjModuleVos.TransType);
                com.Parameters.AddWithValue("@CreatedBy", ObjModuleVos.Created_by);

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
        public string InseringSubModuleDetails(ModuleVos ObjModuleVos)
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
                com.CommandText = "USP_INS_SUB_MODULE_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@ApplicationId", ObjModuleVos.ApplicationId);
                com.Parameters.AddWithValue("@MainModule_Code", ObjModuleVos.MainModule_Code);
                com.Parameters.AddWithValue("@Module_Code", ObjModuleVos.Module_Code);
                com.Parameters.AddWithValue("@SubModule", ObjModuleVos.SubModule);


                com.Parameters.AddWithValue("@TransType", ObjModuleVos.TransType);
                com.Parameters.AddWithValue("@CreatedBy", ObjModuleVos.Created_by);

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
        public string MapSubModuleDetails(ModuleVos ObjModuleVos)
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
                com.CommandText = "[USP_INS_SUB_MODULE_USER_MAP_DTLS]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@MappingID", ObjModuleVos.MappingID);
                com.Parameters.AddWithValue("@ApplicationId", ObjModuleVos.ApplicationId);
                com.Parameters.AddWithValue("@MainModule_Code", ObjModuleVos.MainModule_Code);
                com.Parameters.AddWithValue("@Module_Code", ObjModuleVos.Module_Code);
                com.Parameters.AddWithValue("@UserID", ObjModuleVos.UserID);

                com.Parameters.AddWithValue("@TransType", ObjModuleVos.TransType);
                com.Parameters.AddWithValue("@CreatedBy", ObjModuleVos.Created_by);

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
        public string Check_ApplicantData(string UidNo)
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
                com.CommandText = "USP_CHECK_APPLICANT_PREVIOUS_DTLS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@Uidno", UidNo);

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
        public string Check_Applicant_Is_Eligible_PM_Dtls(string IncentiveID)
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
                com.CommandText = "USP_CHECK_APPLICANT_ELIGIBILITY_FOR_ADD_PM";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveID);

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
        public string Check_Applicant_Eligibility(string UnitId)
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
                com.CommandText = "USP_CHECK_APPLICANT_ELIGIBILITY_TO_APPLY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@UnitId", UnitId);

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
        public string Check_IsFirstTime(string UnitId)
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
                com.CommandText = "USP_CHECK_IS_FIRST_TIME";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@UnitId", UnitId);

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
        public string Check_RevisedInspectionReport(string IncentiveId, string Sub_IncentiveId)
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
                com.CommandText = "USP_CHECK_REVISED_INSPECTION_INCENTIVE";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", Sub_IncentiveId);

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
        public string Check_Applicant_Is_Eligible_Edit_Civil_Works(string IncentiveID)
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
                com.CommandText = "USP_CHECK_APPLICANT_ELIGIBILITY_FOR_EDIT_CILVIL";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveID);

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
        public string Check_Incentive_Eligibility(string IncentiveId, string IncentiveType)
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
                com.CommandText = "USP_CHECK_ELIGIBILITY_TO_APPLY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@Type", IncentiveType);

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
        public string Check_Edit_PlantandMachinary(string IncentiveID)
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
                com.CommandText = "USP_CHECK_APPLICANT_ELIGIBILITY_EDIT_PM";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveID);

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
        public string UpdatetoIndustriesDept(string IncentiveId, string SubIncentiveId)
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
                com.CommandText = "USP_UPD_Industries_Inspection_Flag";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);

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
        public string UpdateSanctionStatus(string IncentiveId, string SubIncentiveId, string Status, string TISId, string Remarks, string IsPartial, string IsFileUpload, string FilePath)
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
                com.CommandText = "USP_UPD_SANCTION_STATUS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);
                com.Parameters.AddWithValue("@Status", Status);
                com.Parameters.AddWithValue("@TIS", TISId);
                com.Parameters.AddWithValue("@Remarks", Remarks);
                com.Parameters.AddWithValue("@IsPartial", IsPartial);
                com.Parameters.AddWithValue("@IsFileUpload", IsFileUpload);
                com.Parameters.AddWithValue("@FilePath", FilePath);

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
        public string UpdateWorkingStatus(string IncentiveId, string SubIncentiveId, string Status, string TISId, string Remarks, string UpdType, string UserId)
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
                com.CommandText = "USP_UPD_UNIT_WORKING_STATUS";

                com.Transaction = transaction;
                com.Connection = connection;
                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);
                com.Parameters.AddWithValue("@Status", Status);
                com.Parameters.AddWithValue("@TIS", TISId);
                com.Parameters.AddWithValue("@Remarks", Remarks);
                com.Parameters.AddWithValue("@UpdType", UpdType);
                com.Parameters.AddWithValue("@Updateby", UserId);

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
        public string InsertNewBankDetails(int IncentiveId, int SubIncentiveId, int BankId, string Branch, string AccType, string AccNo,
            string IFSC, string AuthPerson, string Designation, int CreateBy)
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
                com.CommandText = "[USP_INSERT_NEW_BANK_DETAILS]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);
                com.Parameters.AddWithValue("@BankId", BankId);
                com.Parameters.AddWithValue("@BranchName", Branch);
                com.Parameters.AddWithValue("@BankAccType", AccType);
                com.Parameters.AddWithValue("@AccNo", AccNo);
                com.Parameters.AddWithValue("@IFSCCode", IFSC);
                com.Parameters.AddWithValue("@AccountauthorizedPerson", AuthPerson);
                com.Parameters.AddWithValue("@Designation", Designation);
                com.Parameters.AddWithValue("@Createdby", CreateBy);
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
        public string AssignInspectingOfficer(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "USP_UPD_GM_STAUS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", Convert.ToInt32(objApplicationStatus.IncentiveId));
                com.Parameters.AddWithValue("@SubIncentiveId", Convert.ToInt32(objApplicationStatus.SubIncentiveId));
                com.Parameters.AddWithValue("@OfficerId", Convert.ToInt32(objApplicationStatus.OfficerId));
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                com.Parameters.AddWithValue("@Transaction", objApplicationStatus.TransType);
                com.Parameters.AddWithValue("@QueryReason", objApplicationStatus.QueryReason);
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
        public string UpdateGMResponseIPOBeforeInsp(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "[USP_UPD_QUERYRESPONSE_TO_IPO]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@QueryId", objApplicationStatus.QueryId);
                com.Parameters.AddWithValue("@IncentiveID", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@QueryResponse", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                com.Parameters.AddWithValue("@AttachmentId", objApplicationStatus.QueryLetterID);
                com.Parameters.AddWithValue("@Flag", objApplicationStatus.TransType);

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

        public string InsertClerkDetails(DLOApplication DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_UPDATECLERKACTION";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@SUBINCENTIVEID", DLODetails.SUBINCENTIVEID);
                com.Parameters.AddWithValue("@ACTIONID", DLODetails.ACTIONID);
                com.Parameters.AddWithValue("@RECOMMENDEAMOUNT", DLODetails.RECOMMENDEAMOUNT);
                com.Parameters.AddWithValue("@QUERY_REMARKS", DLODetails.QUERY_REMARKS);
                com.Parameters.AddWithValue("@SSCINSP_REMARKS", DLODetails.SSCINSP_REMARKS);
                com.Parameters.AddWithValue("@ABEYANCE_REMARKS", DLODetails.ABEYANCE_REMARKS);
                com.Parameters.AddWithValue("@FORWARDTO", DLODetails.FORWARDTO);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InsertSUPDTLevel(DLOApplication DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_UPDATESUPDTACTION";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@SUBINCENTIVEID", DLODetails.SUBINCENTIVEID);
                com.Parameters.AddWithValue("@ACTIONID", DLODetails.ACTIONID);
                com.Parameters.AddWithValue("@RECOMMENDEAMOUNT", DLODetails.RECOMMENDEAMOUNT);
                com.Parameters.AddWithValue("@QUERY_REMARKS", DLODetails.QUERY_REMARKS);
                com.Parameters.AddWithValue("@SSCINSP_REMARKS", DLODetails.SSCINSP_REMARKS);
                com.Parameters.AddWithValue("@ABEYANCE_REMARKS", DLODetails.ABEYANCE_REMARKS);
                com.Parameters.AddWithValue("@RETURN_REMARKS", DLODetails.RETURN_REMARKS);
                com.Parameters.AddWithValue("@FORWARDTO", DLODetails.FORWARDTO);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InsertADLevel(DLOApplication DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_UPDATEADACTION";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@SUBINCENTIVEID", DLODetails.SUBINCENTIVEID);
                com.Parameters.AddWithValue("@ACTIONID", DLODetails.ACTIONID);
                com.Parameters.AddWithValue("@RECOMMENDEAMOUNT", DLODetails.RECOMMENDEAMOUNT);
                com.Parameters.AddWithValue("@QUERY_REMARKS", DLODetails.QUERY_REMARKS);
                com.Parameters.AddWithValue("@SSCINSP_REMARKS", DLODetails.SSCINSP_REMARKS);
                com.Parameters.AddWithValue("@ABEYANCE_REMARKS", DLODetails.ABEYANCE_REMARKS);
                com.Parameters.AddWithValue("@RETURN_REMARKS", DLODetails.RETURN_REMARKS);
                com.Parameters.AddWithValue("@FORWARDTO", DLODetails.FORWARDTO);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InsertDDLevel(DLOApplication DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_UPDATEDDACTION";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@SUBINCENTIVEID", DLODetails.SUBINCENTIVEID);
                com.Parameters.AddWithValue("@ACTIONID", DLODetails.ACTIONID);
                com.Parameters.AddWithValue("@RECOMMENDEAMOUNT", DLODetails.RECOMMENDEAMOUNT);
                com.Parameters.AddWithValue("@QUERY_REMARKS", DLODetails.QUERY_REMARKS);
                com.Parameters.AddWithValue("@SSCINSP_REMARKS", DLODetails.SSCINSP_REMARKS);
                com.Parameters.AddWithValue("@ABEYANCE_REMARKS", DLODetails.ABEYANCE_REMARKS);
                com.Parameters.AddWithValue("@RETURN_REMARKS", DLODetails.RETURN_REMARKS);
                com.Parameters.AddWithValue("@FORWARDTO", DLODetails.FORWARDTO);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InsertJDLevel(DLOApplication DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_UPDATEJDACTION";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@SUBINCENTIVEID", DLODetails.SUBINCENTIVEID);
                com.Parameters.AddWithValue("@ACTIONID", DLODetails.ACTIONID);
                com.Parameters.AddWithValue("@RECOMMENDEAMOUNT", DLODetails.RECOMMENDEAMOUNT);
                com.Parameters.AddWithValue("@QUERY_REMARKS", DLODetails.QUERY_REMARKS);
                com.Parameters.AddWithValue("@SSCINSP_REMARKS", DLODetails.SSCINSP_REMARKS);
                com.Parameters.AddWithValue("@ABEYANCE_REMARKS", DLODetails.ABEYANCE_REMARKS);
                com.Parameters.AddWithValue("@RETURN_REMARKS", DLODetails.RETURN_REMARKS);
                com.Parameters.AddWithValue("@FORWARDTO", DLODetails.FORWARDTO);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);

                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string UpdateGMRecommendationtoCoi(ApplicationStatus objApplicationStatus)
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
                com.CommandText = "[USP_UPD_GM_VERIFICATION_AFTER_INSP]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveID", objApplicationStatus.IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", objApplicationStatus.SubIncentiveId);
                com.Parameters.AddWithValue("@GMAmount", objApplicationStatus.GMRecommendedAmount);
                com.Parameters.AddWithValue("@Remarks", objApplicationStatus.Remarks);
                com.Parameters.AddWithValue("@CreatedBy", objApplicationStatus.CreatedBy);
                com.Parameters.AddWithValue("@AttachmentId", objApplicationStatus.QueryLetterID);
                com.Parameters.AddWithValue("@Flag", objApplicationStatus.TransType);
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

        public string INSERT_PAVALLAVADDICLAIMLOANCOUNT(InterestSubsidyclaimloanproperties OBJPallavaddiclaimloanproperties)
        {
            int valid = 0;
            string resp = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand com = new SqlCommand("PV_insertInterestSubsidyclaimloancount", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Transaction = transaction;
            try
            {
                //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
                //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();
                if (OBJPallavaddiclaimloanproperties.Incentiveid == null)
                {
                    com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.Incentiveid;
                }
                if (OBJPallavaddiclaimloanproperties.APCDPVID == null)
                {
                    com.Parameters.Add("@APCDPVID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@APCDPVID", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.APCDPVID;
                }
                if (OBJPallavaddiclaimloanproperties.ClaimPeriodID == "" || OBJPallavaddiclaimloanproperties.ClaimPeriodID == null)
                {
                    com.Parameters.Add("@ClaimPeriodID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ClaimPeriodID", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.ClaimPeriodID.Trim();
                }
                if (OBJPallavaddiclaimloanproperties.ClaimPeriodName == "" || OBJPallavaddiclaimloanproperties.ClaimPeriodName == null)
                {
                    com.Parameters.Add("@ClaimPeriodName", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ClaimPeriodName", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.ClaimPeriodName.Trim();
                }
                if (OBJPallavaddiclaimloanproperties.@LoanCount == null)
                {
                    com.Parameters.Add("@LoanCount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@LoanCount", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.LoanCount;
                }
                if (OBJPallavaddiclaimloanproperties.Createdby == "" || OBJPallavaddiclaimloanproperties.Createdby == null)
                {
                    com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.Createdby.Trim();
                }
                if (OBJPallavaddiclaimloanproperties.CreatedIP == "" || OBJPallavaddiclaimloanproperties.CreatedIP == null)
                {
                    com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.CreatedIP.Trim();
                }
                if (OBJPallavaddiclaimloanproperties.FinancialYear == "" || OBJPallavaddiclaimloanproperties.FinancialYear == null)
                {
                    com.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.FinancialYear.Trim();
                }


                com.Parameters.Add("@Valid", SqlDbType.Int, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                //com.ExecuteScalar();
                valid = (Int32)com.Parameters["@Valid"].Value;


                resp = Convert.ToString(valid);
                //con.CloseConnection();
                //con.OpenConnection();
                //com.Connection = con.GetConnection;

                transaction.Commit();
                connection.Close();
                //return com.ExecuteNonQuery();
                //return Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                com.Dispose();
                //con.CloseConnection();
                connection.Close();
            }
            return resp;

        }
        public string INSERT_PAVALLAVADDICLAIMPERIODLOANDETAILS(InterestSubsidyclaimLoandetailsproperties OBJPVclaimLoandetailsproperties)
        {
            int valid = 0;
            string resp = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand com = new SqlCommand("PV_insertInterestSubsidyClaimloanFyDetails", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Transaction = transaction;
            try
            {
                //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
                //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();

                //if (OBJPVclaimLoandetailsproperties.incapplnno == "" || OBJPVclaimLoandetailsproperties.incapplnno == null)
                //{
                //    com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = DBNull.Value;
                //}
                //else
                //{
                //    com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.incapplnno.Trim();
                //}

                if (OBJPVclaimLoandetailsproperties.Incentiveid == null)
                {
                    com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Incentiveid;
                }

                if (OBJPVclaimLoandetailsproperties.APCDPVID == null)
                {
                    com.Parameters.Add("@APCDPVID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@APCDPVID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.APCDPVID;
                }

                if (OBJPVclaimLoandetailsproperties.ClaimPeriodID == "" || OBJPVclaimLoandetailsproperties.ClaimPeriodID == null)
                {
                    com.Parameters.Add("@ClaimPeriodID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ClaimPeriodID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.ClaimPeriodName == "" || OBJPVclaimLoandetailsproperties.ClaimPeriodName == null)
                {
                    com.Parameters.Add("@ClaimPeriodName", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ClaimPeriodName", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodName.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.LoanNumber == null)
                {
                    com.Parameters.Add("@LoanNumber", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@LoanNumber", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.LoanNumber;
                }
                if (OBJPVclaimLoandetailsproperties.ClaimPeriodFYID == "" || OBJPVclaimLoandetailsproperties.ClaimPeriodFYID == null)
                {
                    com.Parameters.Add("@ClaimPeriodFYID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ClaimPeriodFYID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodFYID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.ClaimPeriodFYSubID == "" || OBJPVclaimLoandetailsproperties.ClaimPeriodFYSubID == null)
                {
                    com.Parameters.Add("@ClaimPeriodFYSubID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ClaimPeriodFYSubID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodFYSubID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.IS1st2dhalfyear == "" || OBJPVclaimLoandetailsproperties.IS1st2dhalfyear == null)
                {
                    com.Parameters.Add("@IS1st2dhalfyear", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@IS1st2dhalfyear", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.IS1st2dhalfyear.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.dcpdate == null)
                {
                    com.Parameters.Add("@dcpdate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@dcpdate", SqlDbType.DateTime).Value = OBJPVclaimLoandetailsproperties.dcpdate;
                }
                if (OBJPVclaimLoandetailsproperties.loaninstallmentstartdate == null)
                {
                    com.Parameters.Add("@loaninstallmentstartdate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@loaninstallmentstartdate", SqlDbType.DateTime).Value = OBJPVclaimLoandetailsproperties.loaninstallmentstartdate;
                }
                if (OBJPVclaimLoandetailsproperties.tottermloanavil == null)
                {
                    com.Parameters.Add("@tottermloanavil", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@tottermloanavil", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.tottermloanavil;
                }
                if (OBJPVclaimLoandetailsproperties.Periodofinstallmentid == "" || OBJPVclaimLoandetailsproperties.Periodofinstallmentid == null)
                {
                    com.Parameters.Add("@Periodofinstallmentid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Periodofinstallmentid", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Periodofinstallmentid.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.Periodofinstallmentname == "" || OBJPVclaimLoandetailsproperties.Periodofinstallmentname == null)
                {
                    com.Parameters.Add("@Periodofinstallmentname", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Periodofinstallmentname", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Periodofinstallmentname.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.Noofinstallmentforloan == null)
                {
                    com.Parameters.Add("@Noofinstallmentforloan", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Noofinstallmentforloan", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Noofinstallmentforloan;
                }
                if (OBJPVclaimLoandetailsproperties.Installmentamountforloan == null)
                {
                    com.Parameters.Add("@Installmentamountforloan", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Installmentamountforloan", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Installmentamountforloan;
                }



                if (OBJPVclaimLoandetailsproperties.Rateofinterestforloan == null)
                {
                    com.Parameters.Add("@Rateofinterestforloan", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Rateofinterestforloan", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Rateofinterestforloan;
                }
                if (OBJPVclaimLoandetailsproperties.Eligibleratereimbursementforlaon == null)
                {
                    com.Parameters.Add("@Eligibleratereimbursementforlaon", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Eligibleratereimbursementforlaon", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Eligibleratereimbursementforlaon;
                }
                if (OBJPVclaimLoandetailsproperties.NoofinstallmentcompletedfortheloanFY == null)
                {
                    com.Parameters.Add("@NoofinstallmentcompletedfortheloanFY", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofinstallmentcompletedfortheloanFY", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofinstallmentcompletedfortheloanFY;
                }
                if (OBJPVclaimLoandetailsproperties.principalamountdueforhalfyrFY == null)
                {
                    com.Parameters.Add("@principalamountdueforhalfyrFY", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@principalamountdueforhalfyrFY", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.principalamountdueforhalfyrFY;
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1ID == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1ID == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth1ID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth1ID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1ID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1Name == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1Name == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth1Name", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth1Name", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1Name.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth1 == null)
                {
                    com.Parameters.Add("@PrincipalamountdueMonth1", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PrincipalamountdueMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth1;
                }
                if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth1 == null)
                {
                    com.Parameters.Add("@NoofInstallmentMonth1", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofInstallmentMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth1;
                }
                if (OBJPVclaimLoandetailsproperties.rateofinterestMonth1 == null)
                {
                    com.Parameters.Add("@rateofinterestMonth1", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@rateofinterestMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth1;
                }
                if (OBJPVclaimLoandetailsproperties.interestamountMonth1 == null)
                {
                    com.Parameters.Add("@interestamountMonth1", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@interestamountMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth1;
                }
                if (OBJPVclaimLoandetailsproperties.unitholdercontMonth1 == null)
                {
                    com.Parameters.Add("@unitholdercontMonth1", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@unitholdercontMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth1;
                }
                if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth1 == null)
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth1", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth1;
                }
                if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth1 == null)
                {
                    com.Parameters.Add("@eligibleinterestamountMonth1", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligibleinterestamountMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth1;
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2ID == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2ID == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth2ID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth2ID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2ID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2Name == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2Name == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth2Name", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth2Name", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2Name.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth2 == null)
                {
                    com.Parameters.Add("@PrincipalamountdueMonth2", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PrincipalamountdueMonth2", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth2;
                }
                if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth2 == null)
                {
                    com.Parameters.Add("@NoofInstallmentMonth2", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofInstallmentMonth2", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth2;
                }
                if (OBJPVclaimLoandetailsproperties.rateofinterestMonth2 == null)
                {
                    com.Parameters.Add("@rateofinterestMonth2", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@rateofinterestMonth2", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth2;
                }
                if (OBJPVclaimLoandetailsproperties.interestamountMonth2 == null)
                {
                    com.Parameters.Add("@interestamountMonth2", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@interestamountMonth2", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth2;
                }
                if (OBJPVclaimLoandetailsproperties.unitholdercontMonth2 == null)
                {
                    com.Parameters.Add("@unitholdercontMonth2", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@unitholdercontMonth2", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth2;
                }
                if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth2 == null)
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth2", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth2", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth2;
                }
                if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth2 == null)
                {
                    com.Parameters.Add("@eligibleinterestamountMonth2", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligibleinterestamountMonth2", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth2;
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3ID == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3ID == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth3ID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth3ID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3ID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3Name == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3Name == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth3Name", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth3Name", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3Name.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth3 == null)
                {
                    com.Parameters.Add("@PrincipalamountdueMonth3", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PrincipalamountdueMonth3", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth3;
                }
                if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth3 == null)
                {
                    com.Parameters.Add("@NoofInstallmentMonth3", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofInstallmentMonth3", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth3;
                }
                if (OBJPVclaimLoandetailsproperties.rateofinterestMonth3 == null)
                {
                    com.Parameters.Add("@rateofinterestMonth3", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@rateofinterestMonth3", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth3;
                }
                if (OBJPVclaimLoandetailsproperties.interestamountMonth3 == null)
                {
                    com.Parameters.Add("@interestamountMonth3", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@interestamountMonth3", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth3;
                }
                if (OBJPVclaimLoandetailsproperties.unitholdercontMonth3 == null)
                {
                    com.Parameters.Add("@unitholdercontMonth3", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@unitholdercontMonth3", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth3;
                }
                if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth3 == null)
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth3", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth3", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth3;
                }
                if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth3 == null)
                {
                    com.Parameters.Add("@eligibleinterestamountMonth3", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligibleinterestamountMonth3", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth3;
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4ID == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4ID == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth4ID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth4ID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4ID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4Name == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4Name == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth4Name", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth4Name", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4Name.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth4 == null)
                {
                    com.Parameters.Add("@PrincipalamountdueMonth4", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PrincipalamountdueMonth4", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth4;
                }
                if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth4 == null)
                {
                    com.Parameters.Add("@NoofInstallmentMonth4", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofInstallmentMonth4", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth4;
                }
                if (OBJPVclaimLoandetailsproperties.rateofinterestMonth4 == null)
                {
                    com.Parameters.Add("@rateofinterestMonth4", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@rateofinterestMonth4", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth4;
                }
                if (OBJPVclaimLoandetailsproperties.interestamountMonth4 == null)
                {
                    com.Parameters.Add("@interestamountMonth4", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@interestamountMonth4", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth4;
                }
                if (OBJPVclaimLoandetailsproperties.unitholdercontMonth4 == null)
                {
                    com.Parameters.Add("@unitholdercontMonth4", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@unitholdercontMonth4", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth4;
                }
                if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth4 == null)
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth4", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth4", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth4;
                }
                if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth4 == null)
                {
                    com.Parameters.Add("@eligibleinterestamountMonth4", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligibleinterestamountMonth4", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth4;
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5ID == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5ID == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth5ID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth5ID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5ID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5Name == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5Name == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth5Name", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth5Name", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5Name.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth5 == null)
                {
                    com.Parameters.Add("@PrincipalamountdueMonth5", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PrincipalamountdueMonth5", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth5;
                }
                if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth5 == null)
                {
                    com.Parameters.Add("@NoofInstallmentMonth5", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofInstallmentMonth5", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth5;
                }
                if (OBJPVclaimLoandetailsproperties.rateofinterestMonth5 == null)
                {
                    com.Parameters.Add("@rateofinterestMonth5", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@rateofinterestMonth5", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth5;
                }
                if (OBJPVclaimLoandetailsproperties.interestamountMonth5 == null)
                {
                    com.Parameters.Add("@interestamountMonth5", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@interestamountMonth5", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth5;
                }
                if (OBJPVclaimLoandetailsproperties.unitholdercontMonth5 == null)
                {
                    com.Parameters.Add("@unitholdercontMonth5", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@unitholdercontMonth5", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth5;
                }
                if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth5 == null)
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth5", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth5", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth5;
                }
                if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth5 == null)
                {
                    com.Parameters.Add("@eligibleinterestamountMonth5", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligibleinterestamountMonth5", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth5;
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6ID == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6ID == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth6ID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth6ID", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6ID.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6Name == "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6Name == null)
                {
                    com.Parameters.Add("@PeriodofClaimMonth6Name", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PeriodofClaimMonth6Name", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6Name.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth6 == null)
                {
                    com.Parameters.Add("@PrincipalamountdueMonth6", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@PrincipalamountdueMonth6", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth6;
                }
                if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth6 == null)
                {
                    com.Parameters.Add("@NoofInstallmentMonth6", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofInstallmentMonth6", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth6;
                }
                if (OBJPVclaimLoandetailsproperties.rateofinterestMonth6 == null)
                {
                    com.Parameters.Add("@rateofinterestMonth6", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@rateofinterestMonth6", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth6;
                }
                if (OBJPVclaimLoandetailsproperties.interestamountMonth6 == null)
                {
                    com.Parameters.Add("@interestamountMonth6", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@interestamountMonth6", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth6;
                }
                if (OBJPVclaimLoandetailsproperties.unitholdercontMonth6 == null)
                {
                    com.Parameters.Add("@unitholdercontMonth6", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@unitholdercontMonth6", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth6;
                }
                if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth6 == null)
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth6", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligiblerateofintersetMonth6", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth6;
                }
                if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth6 == null)
                {
                    com.Parameters.Add("@eligibleinterestamountMonth6", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligibleinterestamountMonth6", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth6;
                }
                if (OBJPVclaimLoandetailsproperties.totmonthseligibleinterestamount == null)
                {
                    com.Parameters.Add("@totmonthseligibleinterestamount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totmonthseligibleinterestamount", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totmonthseligibleinterestamount;
                }
                if (OBJPVclaimLoandetailsproperties.totmonthsinterestamountMonth == null)
                {
                    com.Parameters.Add("@totmonthsinterestamountMonth", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totmonthsinterestamountMonth", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totmonthsinterestamountMonth;
                }
                if (OBJPVclaimLoandetailsproperties.eligibleperiodinmonths == null)
                {
                    com.Parameters.Add("@eligibleperiodinmonths", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@eligibleperiodinmonths", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleperiodinmonths;
                }
                if (OBJPVclaimLoandetailsproperties.CPL_interestamountpaidaspercal == null)
                {
                    com.Parameters.Add("@CPL_interestamountpaidaspercal", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_interestamountpaidaspercal", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_interestamountpaidaspercal;
                }
                if (OBJPVclaimLoandetailsproperties.CPL_actualinterestamountpaid == null)
                {
                    com.Parameters.Add("@CPL_actualinterestamountpaid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_actualinterestamountpaid", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_actualinterestamountpaid;
                }
                if (OBJPVclaimLoandetailsproperties.CPL_Conamountforcalintreimberest == null)
                {
                    com.Parameters.Add("@CPL_Conamountforcalintreimberest", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_Conamountforcalintreimberest", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_Conamountforcalintreimberest;
                }
                if (OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal == null)
                {
                    com.Parameters.Add("@CPL_interestreimbersementcal", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_interestreimbersementcal", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal;
                }

                if (OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPE == "" || OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPE == null)
                {
                    com.Parameters.Add("@CPL_ELIGIBLETYPE", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_ELIGIBLETYPE", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPE.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPEName == "" || OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPEName == null)
                {
                    com.Parameters.Add("@CPL_ELIGIBLETYPEName", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_ELIGIBLETYPEName", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPEName.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal_finaleligibletype == "" || OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal_finaleligibletype == null)
                {
                    com.Parameters.Add("@CPL_interestreimbersementcal_finaleligibletype", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_interestreimbersementcal_finaleligibletype", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal_finaleligibletype.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.CPL_gmrecommendedamount == null)
                {
                    com.Parameters.Add("@CPL_gmrecommendedamount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_gmrecommendedamount", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_gmrecommendedamount;
                }
                if (OBJPVclaimLoandetailsproperties.CPL_FINALELIGIBLEAMOUNT == null)
                {
                    com.Parameters.Add("@CPL_FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CPL_FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_FINALELIGIBLEAMOUNT;
                }
                if (OBJPVclaimLoandetailsproperties.totince_interestamountpaidaspercal == null)
                {
                    com.Parameters.Add("@totince_interestamountpaidaspercal", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totince_interestamountpaidaspercal", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_interestamountpaidaspercal;
                }
                if (OBJPVclaimLoandetailsproperties.totince_actualinterestamountpaid == null)
                {
                    com.Parameters.Add("@totince_actualinterestamountpaid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totince_actualinterestamountpaid", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_actualinterestamountpaid;
                }
                if (OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal == null)
                {
                    com.Parameters.Add("@totince_interestreimbersementcal", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totince_interestreimbersementcal", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal;
                }
                if (OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal_finaleligibletype == "" || OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal_finaleligibletype == null)
                {
                    com.Parameters.Add("@totince_interestreimbersementcal_finaleligibletype", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totince_interestreimbersementcal_finaleligibletype", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal_finaleligibletype.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.totince_gmrecommendedamount == null)
                {
                    com.Parameters.Add("@totince_gmrecommendedamount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totince_gmrecommendedamount", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_gmrecommendedamount;
                }
                if (OBJPVclaimLoandetailsproperties.totince_FINALELIGIBLEAMOUNT == null)
                {
                    com.Parameters.Add("@totince_FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totince_FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_FINALELIGIBLEAMOUNT;
                }
                if (OBJPVclaimLoandetailsproperties.Createdby == "" || OBJPVclaimLoandetailsproperties.Createdby == null)
                {
                    com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Createdby.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.CreatedIP == "" || OBJPVclaimLoandetailsproperties.CreatedIP == null)
                {
                    com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CreatedIP.Trim();
                }
                if (OBJPVclaimLoandetailsproperties.totince_Conamountforcalintreimberest == null)
                {
                    com.Parameters.Add("@totince_Conamountforcalintreimberest", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@totince_Conamountforcalintreimberest", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_Conamountforcalintreimberest;
                }

                if (OBJPVclaimLoandetailsproperties.IsMortage == null)
                {
                    com.Parameters.Add("@IsMortage", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@IsMortage", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.IsMortage;
                }

                if (OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompleted == null)
                {
                    com.Parameters.Add("@ActualNoofinstallmentsCompleted", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ActualNoofinstallmentsCompleted", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompleted;
                }

                if (OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompletedMonths == null)
                {
                    com.Parameters.Add("@ActualNoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@ActualNoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompletedMonths;
                }
                if (OBJPVclaimLoandetailsproperties.Actualprincipalamtfornextyrs == null)
                {
                    com.Parameters.Add("@Actualprincipalamtfornextyrs", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Actualprincipalamtfornextyrs", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Actualprincipalamtfornextyrs;
                }
                if (OBJPVclaimLoandetailsproperties.NoofinstallmentsCompletedMonths == null)
                {
                    com.Parameters.Add("@NoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@NoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofinstallmentsCompletedMonths;
                }
                if (OBJPVclaimLoandetailsproperties.IsprevMoratorium == null)
                {
                    com.Parameters.Add("@IsprevMoratorium", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@IsprevMoratorium", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.IsprevMoratorium;
                }
                if (OBJPVclaimLoandetailsproperties.Moratoriumrowone == null)
                {
                    com.Parameters.Add("@Moratoriumrowone", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Moratoriumrowone", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowone;
                }
                if (OBJPVclaimLoandetailsproperties.Moratoriumrowtwo == null)
                {
                    com.Parameters.Add("@Moratoriumrowtwo", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Moratoriumrowtwo", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowtwo;
                }
                if (OBJPVclaimLoandetailsproperties.Moratoriumrowthree == null)
                {
                    com.Parameters.Add("@Moratoriumrowthree", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Moratoriumrowthree", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowthree;
                }
                if (OBJPVclaimLoandetailsproperties.Moratoriumrowfour == null)
                {
                    com.Parameters.Add("@Moratoriumrowfour", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Moratoriumrowfour", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowfour;
                }
                if (OBJPVclaimLoandetailsproperties.Moratoriumrowfive == null)
                {
                    com.Parameters.Add("@Moratoriumrowfive", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Moratoriumrowfive", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowfive;
                }
                if (OBJPVclaimLoandetailsproperties.Moratoriumrowsix == null)
                {
                    com.Parameters.Add("@Moratoriumrowsix", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@Moratoriumrowsix", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowsix;
                }
                if (OBJPVclaimLoandetailsproperties.IsMortageRateOfInterest == null)
                {
                    com.Parameters.Add("@IsMortageRateOfInterest", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    com.Parameters.Add("@IsMortageRateOfInterest", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.IsMortageRateOfInterest;
                }
                com.Parameters.Add("@Valid", SqlDbType.Int, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                //com.ExecuteScalar();
                valid = (Int32)com.Parameters["@Valid"].Value;
                resp = Convert.ToString(valid);
                //con.CloseConnection();
                //con.OpenConnection();
                //com.Connection = con.GetConnection;

                transaction.Commit();
                connection.Close();
                //return com.ExecuteNonQuery();
                //return Convert.ToInt32(com.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                com.Dispose();
                //con.CloseConnection();
                connection.Close();
            }
            return resp;

        }
        public bool DB_INSERTPVCALIMSDATALOAN(InterestSubsidysubproperties objgriduploads)
        {
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            bool retValue = false;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand cmdpacd = new SqlCommand("USP_INS_InterestSubsidyClaimsbyloansid", connection);
                cmdpacd.CommandType = CommandType.StoredProcedure;
                cmdpacd.Transaction = transaction;

                //if (objgriduploads.INCENTIVEID == "" || objgriduploads.INCENTIVEID == null)
                //{
                //    cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
                //}
                //else
                //{
                //    cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INCENTIVEID);
                //}


                if (objgriduploads.INCENTIVEID == "" || objgriduploads.INCENTIVEID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INCENTIVEID);
                }
                if (objgriduploads.CLAIMPERIOD_Grid == "" || objgriduploads.CLAIMPERIOD_Grid == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CLAIMPERIOD_Grid);
                }
                if (objgriduploads.PERIODOFINSTALMENT_MAINTABLE == "" || objgriduploads.PERIODOFINSTALMENT_MAINTABLE == null)
                {
                    cmdpacd.Parameters.AddWithValue("@PERIODOFINSTALMENT_MAINTABLE", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@PERIODOFINSTALMENT_MAINTABLE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFINSTALMENT_MAINTABLE);
                }
                if (objgriduploads.NOOFINSTALLMENTS_MAINTABLE == "" || objgriduploads.NOOFINSTALLMENTS_MAINTABLE == null)
                {
                    cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENTS_MAINTABLE", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENTS_MAINTABLE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALLMENTS_MAINTABLE);
                }
                if (objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid == "" || objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid == null)
                {
                    cmdpacd.Parameters.AddWithValue("@NOOFINSTALMENTSCOMPLETED_Grid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@NOOFINSTALMENTSCOMPLETED_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid);
                }
                if (objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID == "" || objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_ID_GRID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_ID_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID);
                }
                if (objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID == "" || objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_VALUE_GRID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_VALUE_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID);
                }
                if (objgriduploads.PRINCIPALAMOUNTDUE_GRID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@PRINCIPALAMOUNTDUE_GRID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@PRINCIPALAMOUNTDUE_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PRINCIPALAMOUNTDUE_GRID);
                }
                if (objgriduploads.NOOFINSTALLMENT_GRID == "" || objgriduploads.NOOFINSTALLMENT_GRID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENT_GRID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENT_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALLMENT_GRID);
                }
                if (objgriduploads.INTERESTAMOUNT_GRID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNT_GRID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNT_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTAMOUNT_GRID);
                }
                if (objgriduploads.InstallmentAmount == null)
                {
                    cmdpacd.Parameters.AddWithValue("@InstallmentAmount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@InstallmentAmount", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.InstallmentAmount);
                }
                if (objgriduploads.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID);
                }
                if (objgriduploads.ACTUALINTERESTAMOUNTPAID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@ACTUALINTERESTAMOUNTPAID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@ACTUALINTERESTAMOUNTPAID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ACTUALINTERESTAMOUNTPAID);
                }
                if (objgriduploads.INTERESTREIMBERSEMENTCALCULATED == null)
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTREIMBERSEMENTCALCULATED);
                }
                if (objgriduploads.ELIGIBLETYPE == "" || objgriduploads.ELIGIBLETYPE == null)
                {
                    cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPE", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ELIGIBLETYPE);
                }
                if (objgriduploads.INTERESTREIMBERSEMENTCALCULATED_FINAL == null)
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTREIMBERSEMENTCALCULATED_FINAL);
                }
                if (objgriduploads.GMRECOMMENDEDAMOUNT == null)
                {
                    cmdpacd.Parameters.AddWithValue("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.GMRECOMMENDEDAMOUNT);
                }
                if (objgriduploads.FINALELIGIBLEAMOUNT == null)
                {
                    cmdpacd.Parameters.AddWithValue("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.FINALELIGIBLEAMOUNT);
                }
                if (objgriduploads.IPADDRESS == "" || objgriduploads.IPADDRESS == null)
                {
                    cmdpacd.Parameters.AddWithValue("@IPADDRESS", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@IPADDRESS", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.IPADDRESS);
                }
                if (objgriduploads.CREATED_BY == "" || objgriduploads.CREATED_BY == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CREATED_BY", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CREATED_BY);
                }
                if (objgriduploads.interestegliblereimbursement == null)
                {
                    cmdpacd.Parameters.AddWithValue("@interestegliblereimbursement", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@interestegliblereimbursement", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.interestegliblereimbursement);
                }
                if (objgriduploads.SUBPallvaid == null)
                {
                    cmdpacd.Parameters.AddWithValue("@SUBPallvaid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@SUBPallvaid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.SUBPallvaid);
                }
                if (objgriduploads.CLAIMPERIODName_Grid == "" || objgriduploads.CLAIMPERIODName_Grid == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CLAIMPERIODName_Grid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CLAIMPERIODName_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CLAIMPERIODName_Grid);
                }
                if (objgriduploads.PeriodofinstallmentName == "" || objgriduploads.PeriodofinstallmentName == null)
                {
                    cmdpacd.Parameters.AddWithValue("@PeriodofinstallmentName", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@PeriodofinstallmentName", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PeriodofinstallmentName);
                }
                if (objgriduploads.principalamountduefornexthalfyr_grid == null)
                {
                    cmdpacd.Parameters.AddWithValue("@principalamountduefornexthalfyr_grid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@principalamountduefornexthalfyr_grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.principalamountduefornexthalfyr_grid);
                }
                if (objgriduploads.ELIGIBLETYPEName == "" || objgriduploads.ELIGIBLETYPEName == null)
                {
                    cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPEName", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPEName", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ELIGIBLETYPEName);
                }
                if (objgriduploads.eligibleperiodinmonths == null)
                {
                    cmdpacd.Parameters.AddWithValue("@eligibleperiodinmonths", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@eligibleperiodinmonths", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.eligibleperiodinmonths);
                }
                if (objgriduploads.dcpdate == null)
                {
                    cmdpacd.Parameters.AddWithValue("@dcpdate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@dcpdate", SqlDbType.DateTime).Value = objgriduploads.dcpdate;
                }
                if (objgriduploads.installmentstartmonthyear == "" || objgriduploads.installmentstartmonthyear == null)
                {
                    cmdpacd.Parameters.AddWithValue("@installmentstartmonthyear", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@installmentstartmonthyear", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.installmentstartmonthyear);
                }
                if (objgriduploads.LoanNumber == null)
                {
                    cmdpacd.Parameters.AddWithValue("@LoanNumber", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@LoanNumber", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.LoanNumber);
                }
                if (objgriduploads.unitholdercont == null)
                {
                    cmdpacd.Parameters.AddWithValue("@unitholdercont", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@unitholdercont", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.unitholdercont);
                }
                if (objgriduploads.eligiblerateofinterset == null)
                {
                    cmdpacd.Parameters.AddWithValue("@eligiblerateofinterset", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@eligiblerateofinterset", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.eligiblerateofinterset);
                }
                if (objgriduploads.eligibleinterestamount == null)
                {
                    cmdpacd.Parameters.AddWithValue("@eligibleinterestamount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@eligibleinterestamount", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.eligibleinterestamount);
                }
                if (objgriduploads.CPL_interestamountpaidaspercal == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_interestamountpaidaspercal", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_interestamountpaidaspercal", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_interestamountpaidaspercal);
                }
                if (objgriduploads.CPL_actualinterestamountpaid == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_actualinterestamountpaid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_actualinterestamountpaid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_actualinterestamountpaid);
                }
                if (objgriduploads.CPL_Conamountforcalintreimberest == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_Conamountforcalintreimberest", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_Conamountforcalintreimberest", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_Conamountforcalintreimberest);
                }
                if (objgriduploads.CPL_interestreimbersementcal == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_interestreimbersementcal);
                }
                if (objgriduploads.CPL_interestreimbersementcal_finaleligibletype == "" || objgriduploads.CPL_interestreimbersementcal_finaleligibletype == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal_finaleligibletype", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal_finaleligibletype", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_interestreimbersementcal_finaleligibletype);
                }
                if (objgriduploads.CPL_gmrecommendedamount == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_gmrecommendedamount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_gmrecommendedamount", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_gmrecommendedamount);
                }
                if (objgriduploads.CPL_FINALELIGIBLEAMOUNT == null)
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@CPL_FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_FINALELIGIBLEAMOUNT);
                }
                if (objgriduploads.Conamountforcalintreimberest == null)
                {
                    cmdpacd.Parameters.AddWithValue("@Conamountforcalintreimberest", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@Conamountforcalintreimberest", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.Conamountforcalintreimberest);
                }
                if (objgriduploads.PVCPLHFID == null)
                {
                    cmdpacd.Parameters.AddWithValue("@PVCPLHFID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@PVCPLHFID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PVCPLHFID);
                }
                if (objgriduploads.IsMortage == "" || objgriduploads.IsMortage == null)
                {
                    cmdpacd.Parameters.AddWithValue("@IsMortage", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@IsMortage", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.IsMortage);
                }
                if (objgriduploads.ActualNoofinstallmentsCompleted == null)
                {
                    cmdpacd.Parameters.AddWithValue("@ActualNoofinstallmentsCompleted", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@ActualNoofinstallmentsCompleted", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ActualNoofinstallmentsCompleted);
                }
                if (objgriduploads.tottermloanavil == null)
                {
                    cmdpacd.Parameters.AddWithValue("@tottermloanavil", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@tottermloanavil", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.tottermloanavil);
                }
                if (objgriduploads.totmonthseligibleinterestamount == null)
                {
                    cmdpacd.Parameters.AddWithValue("@totmonthseligibleinterestamount", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@totmonthseligibleinterestamount", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.totmonthseligibleinterestamount);
                }
                if (objgriduploads.totmonthsinterestamountMonth == null)
                {
                    cmdpacd.Parameters.AddWithValue("@totmonthsinterestamountMonth", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@totmonthsinterestamountMonth", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.totmonthsinterestamountMonth);
                }
                if (objgriduploads.Rateofinterestforloan == null)
                {
                    cmdpacd.Parameters.AddWithValue("@Rateofinterestforloan", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@Rateofinterestforloan", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.Rateofinterestforloan);
                }
                if (objgriduploads.Eligibleratereimbursementforlaon == null)
                {
                    cmdpacd.Parameters.AddWithValue("@Eligibleratereimbursementforlaon", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@Eligibleratereimbursementforlaon", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.Eligibleratereimbursementforlaon);
                }
                if (objgriduploads.MonthRateofinterest == null)
                {
                    cmdpacd.Parameters.AddWithValue("@MonthRateofinterest", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@MonthRateofinterest", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.MonthRateofinterest);
                }
                if (objgriduploads.IsMortageRateOfInterest == "" || objgriduploads.IsMortageRateOfInterest == null)
                {
                    cmdpacd.Parameters.AddWithValue("@IsMortageRateOfInterest", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmdpacd.Parameters.AddWithValue("@IsMortageRateOfInterest", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.IsMortageRateOfInterest);
                }
                cmdpacd.ExecuteNonQuery();
                retValue = true;
                //retValue = cmdpacd.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return retValue;
        }

        public string InterestSubsidyCommonDetails(ApprasialProperties DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSAPPRAISALINTRESTSUBSIDY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INC_INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@INC_NAMEOFINDUSTRIAL", DLODetails.NAMEOFINDUSTRIAL);
                com.Parameters.AddWithValue("@INC_LOCATIONOFINDUSTRIAL", DLODetails.LOCATIONOFINDUSTRIAL);
                com.Parameters.AddWithValue("@INC_NAMEOFPROMOTER", DLODetails.NAMEOFPROMOTER);
                com.Parameters.AddWithValue("@INC_ConstitutionOFINDUSTRIAL", DLODetails.ConstitutionOFINDUSTRIAL);
                com.Parameters.AddWithValue("@INC_SOCIALSTATUS", DLODetails.SOCIALSTATUS);
                com.Parameters.AddWithValue("@INC_WOMENENTERPRENEUR", DLODetails.WOMENENTERPRENEUR);
                com.Parameters.AddWithValue("@INC_PMTSSIREGISTRATIONNO", DLODetails.PMTSSIREGISTRATIONNO);
                // com.Parameters.AddWithValue("@INC_PMTSSIREGISTRATIONDATE", DLODetails.PMTSSIREGISTRATIONDATE);
                com.Parameters.AddWithValue("@INC_NED_UNIT", DLODetails.NED_UNIT);
                //com.Parameters.AddWithValue("@INC_DATEOFPRODUCTION", DLODetails.DATEOFPRODUCTION);
                //com.Parameters.AddWithValue("@INC_DICFILLINGDATE", DLODetails.DICFILLINGDATE);
                com.Parameters.AddWithValue("@INC_NAMEFINANCINGUNIT", DLODetails.NAMEFINANCINGUNIT);
                com.Parameters.AddWithValue("@INC_CASTE", DLODetails.CASTE);
                com.Parameters.AddWithValue("@INC_GENDER", DLODetails.GENDER);
                com.Parameters.AddWithValue("@INC_CATEGORY", DLODetails.CATEGORY);
                com.Parameters.AddWithValue("@INC_ENTERPRISE", DLODetails.ENTERPRISE);
                com.Parameters.AddWithValue("@INC_SECTOR", DLODetails.SECTOR);
                com.Parameters.AddWithValue("@INC_CREATEDBY", DLODetails.CREATEDBY);
                com.Parameters.AddWithValue("@INC_CREATEDBYIP", DLODetails.CREATEDBY);
                com.Parameters.AddWithValue("@Remarks", DLODetails.Remarks);
                com.Parameters.AddWithValue("@ELIGIBLESANCTIONEDAMOUNT", DLODetails.ELIGIBLESANCTIONEDAMOUNT);
                com.Parameters.AddWithValue("@CLAIMPERIODID", DLODetails.CLAIMPERIODID);
                com.Parameters.AddWithValue("@CLAIMPERIOD", DLODetails.CLAIMPERIOD);
                //com.Parameters.AddWithValue("@DATEOFCOMMENCEMENTOFACTIVITY", DLODetails.DATEOFCOMMENCEMENTOFACTIVITY);
                com.Parameters.AddWithValue("@PERIODOFINSTALMENTID", DLODetails.PERIODOFINSTALMENTID);
                com.Parameters.AddWithValue("@INSTALMENTPERIOD", DLODetails.INSTALMENTPERIOD);
                com.Parameters.AddWithValue("@NOOFINSTALMENTS", DLODetails.NOOFINSTALMENTS);
                com.Parameters.AddWithValue("@INSTALMENTAMOUNT", DLODetails.INSTALMENTAMOUNT);
                com.Parameters.AddWithValue("@INSTALMENTSTARTMONTHYEAR_ID", DLODetails.INSTALMENTSTARTMONTHYEAR_ID);
                com.Parameters.AddWithValue("@INSTALMENTSTARTMONTHYEAR_VALUE", DLODetails.INSTALMENTSTARTMONTHYEAR_VALUE);
                com.Parameters.AddWithValue("@RATEOFINTEREST", DLODetails.RATEOFINTEREST);
                com.Parameters.AddWithValue("@ELIGIBLERATEOFREUMBERSEMENT", DLODetails.ELIGIBLERATEOFREUMBERSEMENT);
                com.Parameters.AddWithValue("@NOOFINSTALMENTS_COMPLETED", DLODetails.NOOFINSTALMENTS_COMPLETED);
                com.Parameters.AddWithValue("@PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR", DLODetails.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR);
                com.Parameters.AddWithValue("@INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS", DLODetails.INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS);
                com.Parameters.AddWithValue("@ACTUALINTERESTAMOUNT_PAID", DLODetails.ACTUALINTERESTAMOUNT_PAID);
                com.Parameters.AddWithValue("@INTERESTREIMBURSEMENTCALCULATED", DLODetails.INTERESTREIMBURSEMENTCALCULATED);
                com.Parameters.AddWithValue("@ELIGIBLETYPE", DLODetails.ELIGIBLETYPE);
                com.Parameters.AddWithValue("@INTERESTREIMBURSEMENTCALCULATED_FINAL", DLODetails.INTERESTREIMBURSEMENTCALCULATED_FINAL);
                com.Parameters.AddWithValue("@GMRECOMMENDEDAMOUNT", DLODetails.GMRECOMMENDEDAMOUNT);
                com.Parameters.AddWithValue("@FINALELIGIBLEAMOUNT", DLODetails.FINALELIGIBLEAMOUNT);
                com.Parameters.AddWithValue("@modified_by", DLODetails.modified_by);
                com.Parameters.AddWithValue("@EglibleTypeID", DLODetails.EglibleTypeID);
                com.Parameters.AddWithValue("@EglibleTypeName", DLODetails.EglibleTypeName);


                com.Parameters.AddWithValue("@INTERESTREIMBURSEMENTCALCULATEDaftereglibletype", DLODetails.INTERESTREIMBURSEMENTCALCULATEDaftereglibletype);
                com.Parameters.AddWithValue("@PERIODOFINSTALMENTName", DLODetails.PERIODOFINSTALMENTName);
                com.Parameters.AddWithValue("@Noofclaimperiods", DLODetails.Noofclaimperiods);
                com.Parameters.AddWithValue("@Valid", DLODetails.Valid);
                com.Parameters.AddWithValue("@createdIP", DLODetails.createdIP);
                com.Parameters.AddWithValue("@ModifiedIP", DLODetails.ModifiedIP);
                com.Parameters.AddWithValue("@Conreburismentamount", DLODetails.Conreburismentamount);
                com.Parameters.AddWithValue("@Yrsfrmdcpdate", DLODetails.Yrsfrmdcpdate);
                com.Parameters.AddWithValue("@Scheme", DLODetails.Scheme);
                com.Parameters.AddWithValue("@caste_IR", DLODetails.caste_IR);
                com.Parameters.AddWithValue("@gender_IR", DLODetails.gender_IR);
                com.Parameters.AddWithValue("@category_IR", DLODetails.category_IR);
                com.Parameters.AddWithValue("@enterprise_IR", DLODetails.enterprisetype_IR);
                com.Parameters.AddWithValue("@sector_IR", DLODetails.sector_IR);
                com.Parameters.AddWithValue("@serviceType_IR", DLODetails.servicetype_IR);
                com.Parameters.AddWithValue("@transportNonTrans_IR", DLODetails.transNonTrans_IR);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InterestSubsidyMoratoriumDetails(ApprasialProperties DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_INTERESTSUBSIDYMORATORIUM";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("IRID", DLODetails.IDENTITYCOCUMN);
                com.Parameters.AddWithValue("DCPDATE", DLODetails.DATEOFPRODUCTION);
                com.Parameters.AddWithValue("LOANAMOUNT", DLODetails.LOANAMOUNT);
                com.Parameters.AddWithValue("RATEOFINT", DLODetails.RATEOFINTEREST);
                com.Parameters.AddWithValue("INTERESTDUEANNUM", DLODetails.INTERESTDUEANNUM);
                com.Parameters.AddWithValue("INTERESTDUEMONTH", DLODetails.INTERESTDUEMONTH);
                com.Parameters.AddWithValue("MONTHLYINT75", DLODetails.MONTHLYINT75);
                com.Parameters.AddWithValue("MONTHLYINT8", DLODetails.MONTHLYINT8);
                com.Parameters.AddWithValue("ACTUALINTEREDLOWER", DLODetails.ACTUALINTEREDLOWER);
                com.Parameters.AddWithValue("MORATORIUMMONTH", DLODetails.MORATORIUMMONTH);
                com.Parameters.AddWithValue("ELIGIBLEINTEREST", DLODetails.ELIGIBLERATEOFREUMBERSEMENT);
                com.Parameters.AddWithValue("GMRECOMMENDED", DLODetails.GMRECOMMENDEDAMOUNT);
                com.Parameters.AddWithValue("FINALELIGIBLEAMOUNT", DLODetails.FINALELIGIBLEAMOUNT);
                com.Parameters.AddWithValue("Remarks", DLODetails.Remarks);
                com.Parameters.AddWithValue("UPLOAD", DLODetails.UPLOAD);
                com.Parameters.AddWithValue("CREATEDBY", DLODetails.CREATEDBY);
                com.Parameters.AddWithValue("MODIFIEDBY", DLODetails.modified_by);
                com.Parameters.AddWithValue("INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("SUBINCENTIVEID", DLODetails.SUBINCENTIVEID);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }

        public string InsertCaptialSubsidyAppraisal(ApprasialProperties DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSAPPRAISAL_CAPITALSUBSIDY";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INC_INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@INC_NAMEOFINDUSTRIAL", DLODetails.NAMEOFINDUSTRIAL);
                com.Parameters.AddWithValue("@INC_LOCATIONOFINDUSTRIAL", DLODetails.LOCATIONOFINDUSTRIAL);
                com.Parameters.AddWithValue("@INC_NAMEOFPROMOTER", DLODetails.NAMEOFPROMOTER);
                com.Parameters.AddWithValue("@INC_CONSTITUTIONOFINDUSTRIAL", DLODetails.ConstitutionOFINDUSTRIAL);
                com.Parameters.AddWithValue("@INC_SOCIALSTATUS", DLODetails.SOCIALSTATUS);
                com.Parameters.AddWithValue("@INC_WOMENENTERPRENEUR", DLODetails.WOMENENTERPRENEUR);
                com.Parameters.AddWithValue("@INC_PMTSSIREGISTRATIONNO", DLODetails.PMTSSIREGISTRATIONNO);
                com.Parameters.AddWithValue("@INC_TYPEOFUNIT", DLODetails.TypeOfUnit);
                com.Parameters.AddWithValue("@INC_CATEGORY", DLODetails.CATEGORY);
                com.Parameters.AddWithValue("@INC_SECTOR", DLODetails.SECTOR);
                com.Parameters.AddWithValue("@INC_TEXTILETYPE", DLODetails.TextileType);
                com.Parameters.AddWithValue("@INC_TECHNICALTEXTILETYPE", DLODetails.TechnicalTextileType);
                com.Parameters.AddWithValue("@INC_ACTIVITYOFUNIT", DLODetails.ActivityOfUnit);
                com.Parameters.AddWithValue("@UID_NO", DLODetails.UID_NO);
                com.Parameters.AddWithValue("@APPLICATION_NO", DLODetails.Application_No);
                com.Parameters.AddWithValue("@DATEOFPRODUCTION", DLODetails.DATEOFPRODUCTION);//
                com.Parameters.AddWithValue("@DICFILLINGDATE", DLODetails.DICFILLINGDATE);//
                com.Parameters.AddWithValue("@POWERCONNECTIONRLSDATE", DLODetails.PowerConnectionRlsDate);
                com.Parameters.AddWithValue("@NAMEFINANCINGUNIT", DLODetails.NAMEFINANCINGUNIT);
                
                com.Parameters.AddWithValue("@APPROVEDLANDCOST", DLODetails.ApprovedLandCost);
                com.Parameters.AddWithValue("@APPROVEDBUILDINGCOST", DLODetails.ApprovedBuildingCost);
                com.Parameters.AddWithValue("@APPROVEDPMCOST", DLODetails.ApprovedPMCost);
                com.Parameters.AddWithValue("@APPROVEDKEYCOST", DLODetails.ApprovedKeyCost);
                com.Parameters.AddWithValue("@APPROVEDTOTALCOST", DLODetails.ApprovedTotalCost);
                com.Parameters.AddWithValue("@COMPUTEDLANDCOST", DLODetails.ComputedLandCost);
                com.Parameters.AddWithValue("@COMPUTEDBUILDINGCOST", DLODetails.ComputedBuildingCost);
                com.Parameters.AddWithValue("@COMPUTEDPMCOST", DLODetails.ComputedPMCost);
                com.Parameters.AddWithValue("@COMPUTEDKEYCOST", DLODetails.ComputedKeyCost);
                com.Parameters.AddWithValue("@COMPUTEDTOTALCOST", DLODetails.ComputedTotalCost);
                com.Parameters.AddWithValue("@EMPLOYMENTINSPECTION", DLODetails.EmploymentInspection);
                com.Parameters.AddWithValue("@INDUSTRYSTATUS", DLODetails.IndustryStatus);
                com.Parameters.AddWithValue("@TEXTILETYPEASPERINSPECTION", DLODetails.TextileTypeAsPerInspection);
                com.Parameters.AddWithValue("@NATUREASPERINSPECTION", DLODetails.NatureAsPerInspection);
                com.Parameters.AddWithValue("@CATEGORYASPERINSPECTION", DLODetails.CategoryAsPerInspection);
                com.Parameters.AddWithValue("@SOCIALSTATUSASPERINSPECTION", DLODetails.SocialStatusAsPerInspection);
                com.Parameters.AddWithValue("@GENDERASPERINSPECTION", DLODetails.GenderAsPerInspection);
                com.Parameters.AddWithValue("@TYPE", DLODetails.Type);
                com.Parameters.AddWithValue("@ELIGIBLEPERCENTAGE", DLODetails.EligiblePercentage);
                com.Parameters.AddWithValue("@ELIGIBLESUBSIDYAMOUNT", DLODetails.EligibleSubsidyAmount);
                com.Parameters.AddWithValue("@ADDITIONALSUBSIDYAMOUNT", DLODetails.AdditionalSubsidyAmount);
                com.Parameters.AddWithValue("@TOTALSUBSIDYAMOUNT", DLODetails.TotalSubsidyAmount);
                com.Parameters.AddWithValue("@FORWARDTO", DLODetails.ForwardTo);
                com.Parameters.AddWithValue("@WORKSHEETPATH", DLODetails.WorkSheetPath);
                com.Parameters.AddWithValue("@REMARKS", DLODetails.Remarks);
                com.Parameters.AddWithValue("@GMAMOUNT", DLODetails.GMRecommendedAmount);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);
                com.Parameters.AddWithValue("@CREATEDIP", DLODetails.CREATEDBY);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }

        public string InsertTaxAppraisal(ApprasialProperties DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_APPRAISAL_TAX";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@UNITNAME", DLODetails.NAMEOFINDUSTRIAL);
                com.Parameters.AddWithValue("@ADDRESS", DLODetails.LOCATIONOFINDUSTRIAL);
                com.Parameters.AddWithValue("@PROPRIETOR_NAME", DLODetails.NAMEOFPROMOTER);
                com.Parameters.AddWithValue("@CONSTITUTION_ORGANIZATION", DLODetails.ConstitutionOFINDUSTRIAL);
                com.Parameters.AddWithValue("@SOCIAL_STATUS", DLODetails.SOCIALSTATUS);
                com.Parameters.AddWithValue("@SHARE_OF_SC_ST_WOMEN", DLODetails.WOMENENTERPRENEUR);
                com.Parameters.AddWithValue("@REGISTRATION_NO", DLODetails.PMTSSIREGISTRATIONNO);
                com.Parameters.AddWithValue("@TYPE_OF_UNIT", DLODetails.TypeOfUnit);
                com.Parameters.AddWithValue("@CATEGORY", DLODetails.CATEGORY);
                com.Parameters.AddWithValue("@TYPE_OF_SECTOR", DLODetails.SECTOR);
                com.Parameters.AddWithValue("@TYPE_OF_TEXTILE", DLODetails.TextileType);
                com.Parameters.AddWithValue("@TECHNICAL_TEXTILE_TYPE", DLODetails.TechnicalTextileType);
                com.Parameters.AddWithValue("@ACTIVITY", DLODetails.ActivityOfUnit);
                com.Parameters.AddWithValue("@UID_NO", DLODetails.UID_NO);
                com.Parameters.AddWithValue("@APPLICATION_NO", DLODetails.Application_No);
                com.Parameters.AddWithValue("@POWER_CONNECTION_RELEASE_DT", DLODetails.PowerConnectionRlsDate);
                com.Parameters.AddWithValue("@DCP", DLODetails.DATEOFPRODUCTION);
                com.Parameters.AddWithValue("@APPLIEDDATE", DLODetails.DICFILLINGDATE);
                com.Parameters.AddWithValue("@TYPE_OF_UNIT_INS", DLODetails.TypeOfUnitIns);
                
                com.Parameters.AddWithValue("@PRODUCTION", DLODetails.Production);
                com.Parameters.AddWithValue("@TAX_PAID_SGST", DLODetails.TaxPaidSGST);
                com.Parameters.AddWithValue("@BASE_PRODUCTION", DLODetails.BaseProduction);
                com.Parameters.AddWithValue("@ELIGIBLE_PRODUCTION_QTY", DLODetails.EligibleProductionQty);
                com.Parameters.AddWithValue("@PROPORTINATE_SGST", DLODetails.ProportinateSGST);
                com.Parameters.AddWithValue("@CAPITAL_ELIGIBLE_INV", DLODetails.CapitalEligibleInv);
                com.Parameters.AddWithValue("@ALREADY_SANCTIONED_AMOUNT", DLODetails.AlreadySanctionedAmount);
                com.Parameters.AddWithValue("@CATEGORY_INS", DLODetails.CategoryAsPerInspection);
                com.Parameters.AddWithValue("@AMOUNT", DLODetails.AMOUNT);
                com.Parameters.AddWithValue("@ELIGIBILITY_TYPE", DLODetails.Type);
                com.Parameters.AddWithValue("@GM_REC_AMOUNT", DLODetails.GMRecommendedAmount);
                com.Parameters.AddWithValue("@ELIGIBLE_AMOUNT", DLODetails.EligibleSubsidyAmount);
                com.Parameters.AddWithValue("@FINAL_SUBSIDY_AMOUNT", DLODetails.TotalSubsidyAmount);
                com.Parameters.AddWithValue("@REMARKS", DLODetails.Remarks);
                com.Parameters.AddWithValue("@WORKSHEET_PATH", DLODetails.WorkSheetPath);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);
                com.Parameters.AddWithValue("@CREATEDIP", DLODetails.CREATEDBYIP);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
        public string InsertPowerAppraisal(ApprasialProperties DLODetails)
        {
            string Result = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_APPRAISAL_POWER";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@INCENTIVEID", DLODetails.INCENTIVEID);
                com.Parameters.AddWithValue("@UNITNAME", DLODetails.NAMEOFINDUSTRIAL);
                com.Parameters.AddWithValue("@ADDRESS", DLODetails.LOCATIONOFINDUSTRIAL);
                com.Parameters.AddWithValue("@PROPRIETOR_NAME", DLODetails.NAMEOFPROMOTER);
                com.Parameters.AddWithValue("@CONSTITUTION_ORGANIZATION", DLODetails.ConstitutionOFINDUSTRIAL);
                com.Parameters.AddWithValue("@SOCIAL_STATUS", DLODetails.SOCIALSTATUS);
                com.Parameters.AddWithValue("@SHARE_OF_SC_ST_WOMEN", DLODetails.WOMENENTERPRENEUR);
                com.Parameters.AddWithValue("@REGISTRATION_NO", DLODetails.PMTSSIREGISTRATIONNO);
                com.Parameters.AddWithValue("@TYPE_OF_UNIT", DLODetails.TypeOfUnit);
                com.Parameters.AddWithValue("@CATEGORY", DLODetails.CATEGORY);
                com.Parameters.AddWithValue("@TYPE_OF_SECTOR", DLODetails.SECTOR);
                com.Parameters.AddWithValue("@TYPE_OF_TEXTILE", DLODetails.TextileType);
                com.Parameters.AddWithValue("@TECHNICAL_TEXTILE_TYPE", DLODetails.TechnicalTextileType);
                com.Parameters.AddWithValue("@ACTIVITY", DLODetails.ActivityOfUnit);
                com.Parameters.AddWithValue("@UID_NO", DLODetails.UID_NO);
                com.Parameters.AddWithValue("@APPLICATION_NO", DLODetails.Application_No);
                com.Parameters.AddWithValue("@POWER_CONNECTION_RELEASE_DT", DLODetails.PowerConnectionRlsDate);
                com.Parameters.AddWithValue("@DCP", DLODetails.DATEOFPRODUCTION);
                com.Parameters.AddWithValue("@APPLIEDDATE", DLODetails.DICFILLINGDATE);
                com.Parameters.AddWithValue("@TYPE_OF_TEXTILE_INS", DLODetails.TextileTypeAsPerInspection);
                com.Parameters.AddWithValue("@CATEGORY_INS", DLODetails.CategoryAsPerInspection);
                com.Parameters.AddWithValue("@NATURE_OF_INDUSTRY_INS", DLODetails.NatureAsPerInspection);
                com.Parameters.AddWithValue("@CLAIM_PERIOD", DLODetails.CLAIMPERIOD);
                com.Parameters.AddWithValue("@FINANCIAL_YEAR", DLODetails.FinancialYear);
                com.Parameters.AddWithValue("@MONTH1", DLODetails.Month1);
                com.Parameters.AddWithValue("@MONTH2", DLODetails.Month2);
                com.Parameters.AddWithValue("@MONTH3", DLODetails.Month3);
                com.Parameters.AddWithValue("@MONTH4", DLODetails.Month4);
                com.Parameters.AddWithValue("@MONTH5", DLODetails.Month5);
                com.Parameters.AddWithValue("@MONTH6", DLODetails.Month6);
                com.Parameters.AddWithValue("@UNITS_CONSUMED1", DLODetails.UnitsConsumed1);
                com.Parameters.AddWithValue("@UNITS_CONSUMED2", DLODetails.UnitsConsumed2);
                com.Parameters.AddWithValue("@UNITS_CONSUMED3", DLODetails.UnitsConsumed3);
                com.Parameters.AddWithValue("@UNITS_CONSUMED4", DLODetails.UnitsConsumed4);
                com.Parameters.AddWithValue("@UNITS_CONSUMED5", DLODetails.UnitsConsumed5);
                com.Parameters.AddWithValue("@UNITS_CONSUMED6", DLODetails.UnitsConsumed6);
                com.Parameters.AddWithValue("@PAID_BILL_AMOUNT1", DLODetails.PaidBillAmount1);
                com.Parameters.AddWithValue("@PAID_BILL_AMOUNT2", DLODetails.PaidBillAmount2);
                com.Parameters.AddWithValue("@PAID_BILL_AMOUNT3", DLODetails.PaidBillAmount3);
                com.Parameters.AddWithValue("@PAID_BILL_AMOUNT4", DLODetails.PaidBillAmount4);
                com.Parameters.AddWithValue("@PAID_BILL_AMOUNT5", DLODetails.PaidBillAmount5);
                com.Parameters.AddWithValue("@PAID_BILL_AMOUNT6", DLODetails.PaidBillAmount6);
                com.Parameters.AddWithValue("@ELIGIBLE_RATE1", DLODetails.EligibleRate1);
                com.Parameters.AddWithValue("@ELIGIBLE_RATE2", DLODetails.EligibleRate2);
                com.Parameters.AddWithValue("@ELIGIBLE_RATE3", DLODetails.EligibleRate3);
                com.Parameters.AddWithValue("@ELIGIBLE_RATE4", DLODetails.EligibleRate4);
                com.Parameters.AddWithValue("@ELIGIBLE_RATE5", DLODetails.EligibleRate5);
                com.Parameters.AddWithValue("@ELIGIBLE_RATE6", DLODetails.EligibleRate6);
                com.Parameters.AddWithValue("@ELIGIBLE_AMOUNT1", DLODetails.EligibleAmount1);
                com.Parameters.AddWithValue("@ELIGIBLE_AMOUNT2", DLODetails.EligibleAmount2);
                com.Parameters.AddWithValue("@ELIGIBLE_AMOUNT3", DLODetails.EligibleAmount3);
                com.Parameters.AddWithValue("@ELIGIBLE_AMOUNT4", DLODetails.EligibleAmount4);
                com.Parameters.AddWithValue("@ELIGIBLE_AMOUNT5", DLODetails.EligibleAmount5);
                com.Parameters.AddWithValue("@ELIGIBLE_AMOUNT6", DLODetails.EligibleAmount6);
                com.Parameters.AddWithValue("@TOTAL_AMOUNT", DLODetails.ComputedTotalCost);
                com.Parameters.AddWithValue("@ELIGIBILITY_TYPE", DLODetails.Type);
                com.Parameters.AddWithValue("@TOTAL_ELIGIBLE_AMOUNT", DLODetails.EligibleSubsidyAmount);
                com.Parameters.AddWithValue("@GM_REC_AMOUNT", DLODetails.GMRecommendedAmount);
                com.Parameters.AddWithValue("@FINAL_ELIGIBLE_AMOUNT", DLODetails.TotalSubsidyAmount);
                com.Parameters.AddWithValue("@REMARKS", "");
                com.Parameters.AddWithValue("@WORKSHEET_PATH", DLODetails.WorkSheetPath);
                com.Parameters.AddWithValue("@CREATEDBY", DLODetails.CREATEDBY);
                com.Parameters.AddWithValue("@CREATEDIP", DLODetails.CREATEDBYIP);
                com.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                com.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                Result = com.Parameters["@RESULT"].Value.ToString();
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
            return Result;
        }
    }
}