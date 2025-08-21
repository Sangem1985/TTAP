using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace BusinessLogic
{
    public class DML
    {

        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);        

        public DataTable InsUpdDeltblIncentiveMapping(string flag, int MaapingID, int CasteID, int SectorID, bool DIfferentlyAbled, bool Women, bool Minority, bool NewOrOld, bool isNewvh, int Incentive, int Created_by) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltblIncentiveMapping", flag, MaapingID, CasteID, SectorID, DIfferentlyAbled, Women, Minority, NewOrOld, isNewvh, Incentive, Created_by).Tables[0]; }

        public DataTable InsUpdDeltd_Incentive_Uploads(int EntrpID, int IncentiveID, int AttachmentId, string FileNm, string FilePath, int Createdby) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltd_Incentive_Uploads", EntrpID, IncentiveID, AttachmentId, FileNm, FilePath, Createdby).Tables[0]; }

        //public string InsincentiveDtl(int EntprId, int IsNeworExistingEntrepenuer, int Createdby, DataTable IncentiveTransType) { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtl", EntprId, IsNeworExistingEntrepenuer, Createdby, IncentiveTransType)); }

        public string InsincentiveDtl(int EnterperIncentiveID, int IsNeworExistingEntrepenuer, bool isVehicleIncentive, int Createdby, DataTable IncentiveTransType) { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtl", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType)); }

        //public string InsUpdDeltbl_Incentive(string EMiUdyogAadhar, string UnitName, string ApplciantName, string Gender, int Caste, string EmailID, string MobileNo, int natureOfAct, int Category, decimal Landvalue, decimal BuildingValue, decimal PlantMachineryValue, decimal EquipmentValue, decimal Total, string landstatus, string BuildingStatus, int District, int TypeofOrg, int TotalEmployment, string BankName, string AccNo, string BranchName, string IFSCCode, int Createdby, bool IsDifferentlyAbled, bool IsWomen, bool IsMinority, string Addressofunit, int mdid, int vlid, int sector, string NatureofBussiness, bool IsGHMCandOtherMuncp)
        //{ return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_Incentive", EMiUdyogAadhar, UnitName, ApplciantName, Gender, Caste, EmailID, MobileNo, natureOfAct, Category, Landvalue, BuildingValue, PlantMachineryValue, EquipmentValue, Total, landstatus, BuildingStatus, District, TypeofOrg, TotalEmployment, BankName, AccNo, BranchName, IFSCCode, Createdby, IsDifferentlyAbled, IsWomen, IsMinority, Addressofunit, mdid, vlid, sector, NatureofBussiness, IsGHMCandOtherMuncp)); }

        public string InsUpdDeltbl_Incentive(string EMiUdyogAadhar, string UnitName, string ApplciantName, string Gender, int Caste, string EmailID, string MobileNo, int natureOfAct, int Category, decimal Landvalue, decimal BuildingValue, decimal PlantMachineryValue, decimal EquipmentValue, decimal Total, string landstatus, string BuildingStatus, int District, int TypeofOrg, int TotalEmployment, string BankName, string AccNo, string BranchName, string IFSCCode, int Createdby, bool IsDifferentlyAbled, bool IsWomen, bool IsMinority, string Addressofunit, int mdid, int vlid, int sector, string NatureofBussiness, bool IsGHMCandOtherMuncp, bool isVehicleIncentive, DateTime DCP, string VehicleNumber, bool IsMeeSevaApplication, string MeeSevaUserID, bool IsMeesevaPayDone)
        { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_Incentive", EMiUdyogAadhar, UnitName, ApplciantName, Gender, Caste, EmailID, MobileNo, natureOfAct, Category, Landvalue, BuildingValue, PlantMachineryValue, EquipmentValue, Total, landstatus, BuildingStatus, District, TypeofOrg, TotalEmployment, BankName, AccNo, BranchName, IFSCCode, Createdby, IsDifferentlyAbled, IsWomen, IsMinority, Addressofunit, mdid, vlid, sector, NatureofBussiness, IsGHMCandOtherMuncp, isVehicleIncentive, DCP, VehicleNumber, IsMeeSevaApplication, MeeSevaUserID, IsMeesevaPayDone)); }


        public string InsUpdDeltbl_Incentive(string EMiUdyogAadhar, string UnitName, string ApplciantName, string Gender, int Caste, string EmailID, string MobileNo, int natureOfAct, int Category, decimal Landvalue, decimal BuildingValue, decimal PlantMachineryValue, decimal EquipmentValue, decimal Total, string landstatus, string BuildingStatus, int District, int TypeofOrg, int TotalEmployment, string BankName, string AccNo, string BranchName, string IFSCCode, int Createdby, bool IsDifferentlyAbled, bool IsWomen, bool IsMinority)
        { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_Incentive", EMiUdyogAadhar, UnitName, ApplciantName, Gender, Caste, EmailID, MobileNo, natureOfAct, Category, Landvalue, BuildingValue, PlantMachineryValue, EquipmentValue, Total, landstatus, BuildingStatus, District, TypeofOrg, TotalEmployment, BankName, AccNo, BranchName, IFSCCode, Createdby, IsDifferentlyAbled, IsWomen, IsMinority)); }
              

        //added by chinna 
        public DataTable InsUpdCOI_Incentive_Attachments(int AttachmentType, int IncentiveID, int MasterIncentiveID, int SlcNumber, string FileNm, string FilePath, int Createdby,string FileDescription)
        {
            return SqlHelper.ExecuteDataset(con, "usp_InsUpdCOI_Uploads_Incentive", AttachmentType, MasterIncentiveID, IncentiveID, SlcNumber, FileNm, FilePath, Createdby, FileDescription).Tables[0];
        }        

        public DataSet InsUpdDelRawmaterial(string flag, int ID, string EMNoUdyogAadhaar, string TypeofApplication, string UnitName, string District, string Mandal, string Address, string RawmaterialforAllotment, string Requirement, string Usagedetails, string ExistingAllotmentOrder, string ValidCFO, string BoilerDetails, string Proofofproductiontillpreviousmonth, string VAT, string RG1Register, string ProcessDescriptionFlowChart, string Createdby, DateTime CreatedDate, string modifiedby, DateTime Modified_dt, string uom) { return SqlHelper.ExecuteDataset(con, "InsUpdDelRawmaterial", flag, ID, EMNoUdyogAadhaar, TypeofApplication, UnitName, District, Mandal, Address, RawmaterialforAllotment, Requirement, Usagedetails, ExistingAllotmentOrder, ValidCFO, BoilerDetails, Proofofproductiontillpreviousmonth, VAT, RG1Register, ProcessDescriptionFlowChart, Createdby, CreatedDate, modifiedby, Modified_dt, uom); }

        

        public int InsUpdDeltbl_InspectionDet(string flag, int intInspectionid, string UnitName, string Location_District, string Location_Mandal, string Location_Village, string Inspection_Authority_Desg, DateTime Date_Inspection, DateTime Date_Uploading_Inspection, string Unique_Number, string File_Link, string Department)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_InspectionDet", flag, intInspectionid, UnitName, Location_District, Location_Mandal, Location_Village, Inspection_Authority_Desg, Date_Inspection, Date_Uploading_Inspection, Unique_Number, File_Link, Department));
        }        

        public DataSet FetchConstitutionUnit()
        {
            return SqlHelper.ExecuteDataset(con, "USP_GETCONSTITUTIONUNIT");
        }
        public DataTable FetchIncentiveViewNew(int CreatedBy, int IncentveID)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncentiveViewNew", CreatedBy, IncentveID).Tables[0];
        }
        public DataTable FetchIncentiveDtlsbyIncentiveIDNew(string IncentiveId)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveIDNew", IncentiveId).Tables[0];
        }
        public DataTable InsUpdDeltd_Incentive_UploadsIncentives(int IncentiveID, int AttachmentId, string FileNm, string FilePath, int Createdby)
        {
            return SqlHelper.ExecuteDataset(con, "InsUpdDeltd_Incentive_Uploads_Incentives", IncentiveID, AttachmentId, FileNm, FilePath, Createdby).Tables[0];
        }
        // Incentives New- Endss

        // Incentives Enterprenuer side methods added on 17.06.2017 

        // TypeofIncentivesNew.aspx method
        public string InsincentiveDtlNew(int EnterperIncentiveID, int IsNeworExistingEntrepenuer, bool isVehicleIncentive, int Createdby, DataTable IncentiveTransType)
        {
            //return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtl", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType));
            return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtlNewIncType", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType));
        }

        // SingleUploadsNew.aspx method
        public DataTable InsUpdDeltd_Incentive_UploadsNew(int EntrpID, int IncentiveID, int AttachmentId, string FileNm, string FilePath, int Createdby) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltd_Incentive_Uploads_New", EntrpID, IncentiveID, AttachmentId, FileNm, FilePath, Createdby).Tables[0]; }


    }

    public class Fetch
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);

        public DataSet FetchConstitutionUnit()
        {
            return SqlHelper.ExecuteDataset(con, "USP_GETCONSTITUTIONUNIT");
        }
        public DataTable FetchIncentiveViewNew(int CreatedBy, int IncentveID)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncentiveViewNew", CreatedBy, IncentveID).Tables[0];
        }
        public DataTable FetchIncentiveDtlsbyIncentiveIDNew(string IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveIDNew", IncentiveId).Tables[0]; }

        public DataTable FetchBankMst() { return SqlHelper.ExecuteDataset(con, "FetchBankMst").Tables[0]; }

        public DataTable FetchDistrictMst() { return SqlHelper.ExecuteDataset(con, "FetchDistrictMst").Tables[0]; }

        public DataTable FetchLineofActivity() { return SqlHelper.ExecuteDataset(con, "FetchLineofActivity").Tables[0]; }

        public DataTable FetchCategory() { return SqlHelper.ExecuteDataset(con, "FetchCategory").Tables[0]; }

        public DataTable FetchIncentiveMasterDtl(int EntrpID, int IncentiveType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveMasterDtl", EntrpID, IncentiveType).Tables[0]; }

        //public DataSet FetchIncentiveUploads(int EntprId, int IncType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveUploads", EntprId, IncType); }

        public DataTable FetchIncentiveUploads(int EntprId, int IncType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveUploads", EntprId, IncType).Tables[0]; }

        public DataTable FetchIncentiveDtls(string createdby) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtls", createdby).Tables[0]; }

        public DataTable FetchMandals(int disid) { return SqlHelper.ExecuteDataset(con, "FetchMandals", disid).Tables[0]; }

        public DataTable FetchVillages(int VillageId) { return SqlHelper.ExecuteDataset(con, "FetchVillages", VillageId).Tables[0]; }

        public DataTable FetchIncentivesNewINCTypePSRNew(int CasteID, int SectorID, int CategoryID, int ZoneId, bool IsWomenEntrprenaur, int IncentiveType, int EnterpID)
        { return SqlHelper.ExecuteDataset(con, "FetchIncentivesNewINCType_PSRNEW", CasteID, SectorID, CategoryID, ZoneId, IsWomenEntrprenaur, IncentiveType, EnterpID).Tables[0]; }

        public DataTable FetchIncentiveTypes() { return SqlHelper.ExecuteDataset(con, "FetchIncentiveTypes").Tables[0]; }

        public DataTable FetchIncentivesyCasterSector(int intCasteID, int IntSector, int IntIncentiveID, int EnterpID)
        { return SqlHelper.ExecuteDataset(con, "FetchIncentivesyCasterSector", intCasteID, IntSector, IntIncentiveID, EnterpID).Tables[0]; }

        public DataTable FetchIncentivesbyID(int IncentiveID) { return SqlHelper.ExecuteDataset(con, "FetchIncentivesbyID", IncentiveID).Tables[0]; }

        public DataTable FetchIncentiveMst() { return SqlHelper.ExecuteDataset(con, "FetchIncentiveMst").Tables[0]; }

        public DataTable FetchtblIncentiveMapping(int Casteid, int SectorID, bool DiffAbled, bool Women, bool Minority, bool NeworOld, int IncentiveId, bool VehicleIncentive) { return SqlHelper.ExecuteDataset(con, "FetchtblIncentiveMapping", Casteid, SectorID, DiffAbled, Women, Minority, NeworOld, IncentiveId, VehicleIncentive).Tables[0]; }

        public DataTable FetchtblIncentiveMapping_Min(int Casteid, int SectorID, bool DiffAbled, int IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchtblIncentiveMapping_Min", Casteid, SectorID, DiffAbled, IncentiveId).Tables[0]; }

        public DataTable FetchviewIncentive(int EntrpId) { return SqlHelper.ExecuteDataset(con, "FetchviewIncentive", EntrpId).Tables[0]; }

        public DataTable FetchIncentives(int CasteID, int SectorID, bool IsBelongstoGHMCandOtherMunicipalCorpState, int IsNewIncentive, int CategoryID, bool physicallyhandicapped, bool VehicleIncentive, int IncentiveType, int EnterpID)
        { return SqlHelper.ExecuteDataset(con, "FetchIncentives", CasteID, SectorID, IsBelongstoGHMCandOtherMunicipalCorpState, IsNewIncentive, CategoryID, physicallyhandicapped, VehicleIncentive, IncentiveType, EnterpID).Tables[0]; }

        public DataTable FetchIncentivesNewINCType(int CasteID, int SectorID, bool IsBelongstoGHMCandOtherMunicipalCorpState, int IsNewIncentive, int CategoryID, bool physicallyhandicapped, bool VehicleIncentive, int IncentiveType, int EnterpID)
        { return SqlHelper.ExecuteDataset(con, "FetchIncentivesNewINCTypeTTAP", CasteID, SectorID, IsBelongstoGHMCandOtherMunicipalCorpState, IsNewIncentive, CategoryID, physicallyhandicapped, VehicleIncentive, IncentiveType, EnterpID).Tables[0]; }

        public DataTable FetchIncentiveView(int CreatedBy) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveView", CreatedBy).Tables[0]; }

        public DataTable FetchIncentiveTypesView(int EntrpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveTypesView", EntrpID).Tables[0]; }

        public DataTable FetchIncetiveUploadsView(int EntrpID, int IncentiveID) { return SqlHelper.ExecuteDataset(con, "FetchIncetiveUploadsView", EntrpID, IncentiveID).Tables[0]; }

        public DataTable FetchEligibleIncentives(int CasteID, int SectorID, bool IsBelongstoGHMCandOtherMunicipalCorpState, int IsNewIncentive, int CategoryID, bool physicallyhandicapped, bool VehicleIncentive) { return SqlHelper.ExecuteDataset(con, "FetchEligibleIncentives", CasteID, SectorID, IsBelongstoGHMCandOtherMunicipalCorpState, IsNewIncentive, CategoryID, physicallyhandicapped, VehicleIncentive).Tables[0]; }

        public DataTable FetchIncentiveDtls_MeeSeva(string createdby) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtls_MeeSeva", createdby).Tables[0]; }

        public DataTable Fetch_MeeSevaBeforPayment(int IncentiveId) { return SqlHelper.ExecuteDataset(con, "Fetch_MeeSevaBeforPayment", IncentiveId).Tables[0]; }

        public DataTable FetchIncentiveDtlsbyIncentiveID(string IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveID", IncentiveId).Tables[0]; }

        public DataSet FetchIncentivesApplied(string IncentiveID, string EnterpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentivesApplied", IncentiveID, EnterpID); }

        // added on 26.11.2017
        public DataSet FetchIncentivesAppliedNewly(string IncentiveID, string EnterpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentivesAppliedNewly", IncentiveID, EnterpID); }

        public DataSet InsUpdDeltbl_CAFFeeDetails(string uid, string Dept, double TSSPDCL_DEVL_CHRGS, double TSSPDCL_SEC_DEP, double TSSPDCL_SUP_CHRGS, double TSSPDCL_COST_MATERIAL, int CreatedBy, string Additionalpaymentraiseddate, string DemandNoticeFilepath) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltbl_CAFFeeDetails_New", uid, Dept, TSSPDCL_DEVL_CHRGS, TSSPDCL_SEC_DEP, TSSPDCL_SUP_CHRGS, TSSPDCL_COST_MATERIAL, CreatedBy, Additionalpaymentraiseddate, DemandNoticeFilepath); }

        public DataTable FetchIncetiveUploadsViewNewINCType(int EntrpID, int IncentiveID)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncetiveUploadsViewNewINCType", EntrpID, IncentiveID).Tables[0]; // FetchIncetiveUploadsView_NewIncType
        }

        // added on 17.06.2017
        public DataTable FetchIncentiveUploadsNewINCType(int EntprId, int IncType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveUploadsNewINCType", EntprId, IncType).Tables[0]; }

        public DataTable FetchIncentiveTypesView_NewIncType(int EntrpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveTypesView_NewIncType", EntrpID).Tables[0]; }

        public DataTable FetchIncentiveDtlsbyIncentiveID_NewIncType(string IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveID_NewIncType", IncentiveId).Tables[0]; }

        public DataTable FetchIncetiveUploadsViewNewIncType(int EntrpID, int IncentiveID) { return SqlHelper.ExecuteDataset(con, "FetchIncetiveUploadsView_NewIncType", EntrpID, IncentiveID).Tables[0]; }
        public DataTable FetchIncentiveMandatoryDocuments(int EntrpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveMandatoryDocuments", EntrpID).Tables[0]; }

    }

}
