using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTAP.Classfiles
{
    public class AllPropertiesClass
    {
    }
    public class UserRegistrationOldVo
    {

        public string Firstname
        {
            get;
            set;
        }
        public string Lastname
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public string PANcardno
        {
            get;
            set;
        }
        public string MobileNo
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        public string IP
        {
            get;
            set;
        }
        public string AadharNo
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string OTPMail
        {
            get;
            set;
        }
        public string OTPMsg
        {
            get;
            set;
        }

        public string Pwdflag
        {
            get;
            set;
        }
    }

    public class UserLoginVo
    {
        public string UserName
        {
            get;
            set;
        }
        public string User_id
        {
            get;
            set;
        }
        public string User_level
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
        public string Role_Code
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Fillflag
        {
            get;
            set;
        }
    }
    public class UserLoginNewVo
    {
        public string uid
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        public string user_id
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public string userlevel
        {
            get;
            set;
        }
        public string user_type
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string usernameAppl
        {
            get;
            set;
        }
        public string DistrictID
        {
            get;
            set;
        }
        public string User_Code
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
        public string Role_Code
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string intDeptid
        {
            get;
            set;
        }
        public string Visibleflag
        {
            get;
            set;
        }
        public string DummyLogin
        {
            get;
            set;
        }
        public string DefaultPwd
        {
            get;
            set;
        }
        public string PwdEncryflag
        {
            get;
            set;
        }
        public string ECAF
        {
            get;
            set;
        }
        public string DigiLockerID
        {
            get;
            set;
        }
        public string RoleId
        {
            get;
            set;
        }
        public string Mandal_Id
        {
            get;
            set;
        }
        public string Application_Name
        {
            get;
            set;
        }
        public string RDD_Dist
        {
            get;
            set;
        }
        public string Encpassword
        {
            get;
            set;
        }
    }

    public class HdClassVo
    {
        public string Sysip
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public string Created_by
        {
            get;
            set;
        }
        public string Hd_Id
        {
            get;
            set;
        }
        public string Hd_Sub_Id
        {
            get;
            set;
        }
        public string MainHd_Id
        {
            get;
            set;
        }
        public string MainHd_Sub_Id
        {
            get;
            set;
        }
        public string FeedbackReg
        {
            get;
            set;
        }
        public string Hd_Remarks
        {
            get;
            set;
        }
        public string Hd_Remarks_DevTeam
        {
            get;
            set;
        }
        public string FeedBackType
        {
            get;
            set;
        }
        public string UserUserId
        {
            get;
            set;
        }
        public string FwdFlag
        {
            get;
            set;
        }

        public string MainModule { get; set; }
        public string SubModule { get; set; }
        public string ProblemType { get; set; }
        public string MobileNumber { get; set; }

        public string ApprovalStaus { get; set; }
        public string ApplicationCode { get; set; }

        public string PriorityId { get; set; }
    }
    // [Serializable]
    public class HdClassVoDepartment
    {
        public string UserId
        {
            get;
            set;
        }
        public string Hd_Id
        {
            get;
            set;
        }
        public string Hd_Sub_Id
        {
            get;
            set;
        }

    }

    public class IncentivesVOs
    {
        public string Uid_NO { get; set; }
        public string AuthorisedSignatory { get; set; }
        public string UnitDIstId { get; set; }
        public string UnitMandalId { get; set; }
        public string UnitVillId { get; set; }
        public string IncentveID { get; set; } //	int	4
        public string User_Id { get; set; } //	varchar	10
        public string EMiUdyogAadhar { get; set; } //	varchar	30
        public string UnitName { get; set; } //	varchar	100
        public string ApplciantName { get; set; } //	varchar	150
        public string Gender { get; set; } //	varchar	1
        public string Caste { get; set; } //	int	4
        public string EmailID { get; set; } //	varchar	100
        public string MobileNo { get; set; } //	varchar	10
        public string natureOfAct { get; set; } //	int	4
        public string Category { get; set; } //	int	4
        public string Landvalue { get; set; } //	decimal	9
        public string BuildingValue { get; set; } //	decimal	9
        public string PlantMachineryValue { get; set; } //	decimal	9
        public string EquipmentValue { get; set; } //	decimal	9
        public string Total { get; set; } //	decimal	9
        public string landstatus { get; set; } //	varchar	20
        public string BuildingStatus { get; set; } //	varchar	20
        public string District { get; set; } //	int	4
        public string TypeofOrg { get; set; } //	int	4
        public string TotalEmployment { get; set; } //	int	4
        public string BankName { get; set; } //	varchar	50
        public string AccNo { get; set; } //	varchar	50
        public string BranchName { get; set; } //	varchar	50
        public string IFSCCode { get; set; } //	varchar	20
        public string AccountauthorizedPerson { get; set; }
        public string DesignationOfAccountauthorizedPerson { get; set; }
        public string IsActive { get; set; } //	char	1

        public string IsDifferentlyAbled { get; set; } //	char	1
        public string IsWomen { get; set; } //	char	1
        public string IsMinority { get; set; } //	char	1
        public string TypeofTexttile { get; set; }

        public string Addressofunit { get; set; } //	varchar	500
        public string manadalid { get; set; } //	int	4
        public string villageid { get; set; } //	int	4
        public string sector { get; set; } //	int	4
        public string NatureofBussiness { get; set; } //	varchar	500
        public string IsOneTimeIncentive { get; set; } //	int	4
        public bool IsGHMCandOtherMuncpOrp { get; set; } //	char	1
        public bool isVehicleIncentive { get; set; } //	char	1
        public string DCP { get; set; } //	datetime	8
        public string VehicleNumber { get; set; } //	varchar	15
        public string IsMeeSevaApplication { get; set; } //	char	1
        public string MeeSevaUserID { get; set; } //	varchar	40
        public string sMeeSevaPayDone { get; set; } //	char	1
        public string MeeSevaTransactionNo { get; set; } //	varchar	40
        public string WhetherPower { get; set; } //	varchar	12
        public string RequesttoDept { get; set; } //	varchar	450
        public string TinNO { get; set; } //	varchar	20
        public string PanNo { get; set; } //	varchar	100
        public string UnitDIst { get; set; } //	int	4
        public string UnitMandal { get; set; } //	int	4
        public string UnitVill { get; set; } //	int	4
        public string UnitSyNO { get; set; } //	varchar	-1
        public string UnitHNO { get; set; } //	varchar	100
        public string UnitStreet { get; set; } //	varchar	-1

        public string UnitEmail { get; set; } //		varchar	200
        public string UnitMObileNo { get; set; } //	varchar	12  
        public string AadharNumber { get; set; } //	varchar	12  

        public string OffcDIst { get; set; } //	int	4
        public string OffcMandal { get; set; } //	int	4
        public string OffcVil { get; set; } //l	int	4
        public string OffcStreet { get; set; } //	varchar	-1
        public string OffcHNO { get; set; } //	varchar	-1

        public string OffcEmail { get; set; } //	varchar	200
        public string OffcMobileNO { get; set; } //		varchar	12

        public string OrgType { get; set; } //	varchar	10
        public string IdsustryStatus { get; set; } //	varchar	100
        public string ExistingEnterpriseLOA { get; set; } //	varchar	50
        public string ExistingInstalledCapacityinEnter { get; set; } //	varchar	10
        public string ExistingPercentageincreaseunderExpansionORDiversification { get; set; } //	int	4
        public string ExpansionDiversificationLOA { get; set; } //	varchar	50
        public string ExpanORDiversInstalledCapacityinEnter { get; set; } //	varchar	10
        public string ExpanORDiversPercentIncreaseunderExpansionORDiversification { get; set; } //	int	4
        public string ExistEnterpriseLand { get; set; } //	varchar	20
        public string ExistEnterpriseBuilding { get; set; } //	varchar	20
        public string ExistEnterprisePlantMachinery { get; set; } //	varchar	20
        public string ExpansionDiversificationLand { get; set; } //	varchar	20
        public string ExpDiversBuilding { get; set; } //	varchar	20
        public string ExpDiversPlantMachinery { get; set; } //varchar	20
        public string LandFixedCapitalInvestPercentage { get; set; } //varchar	10
        public string BuildingFixedCapitalInvestPercentage { get; set; } //varchar	10
        public string PlantMachFixedCapitalInvestPercentage { get; set; } //varchar	10
        public string SocialStatus { get; set; } //varchar	10

        public string OtherFixedCapital { get; set; }
        public string OtherFixedCapitalExp { get; set; }
        public string OtherFixedCapitalPercentage { get; set; }

        public string CurrentInvestmentLandvalue { get; set; }
        public string CurrentInvestmentBuildingvalue { get; set; }
        public string CurrentInvestmentplantMechValue { get; set; }
        public string CurrentInvestmentOtherValue { get; set; }

        public string NewPowerUniqueID { get; set; }
        public string NewPowerCompany { get; set; }
        public string NewPowerReleaseDate { get; set; } //		date	3
        public string NewConnectedLoad { get; set; } //	varchar	20
        public string NewContractedLoad { get; set; } //		varchar	10
        public string ServiceConnectionNO { get; set; } //		varchar	30
        public string NewServiceRateUnit { get; set; } //		varchar	30

        public string ExistingPowerUniqueID { get; set; }
        public string ExistingPowerCompany { get; set; }
        public string ExistingPowerReleaseDate { get; set; } //		date	3
        public string ExistingConnectedLoad { get; set; } //	varchar	20
        public string ExistingContractedLoad { get; set; } //		varchar	10
        public string ExistingServiceConnectionNO { get; set; } //		varchar	30
        public string ExistingServiceRateUnit { get; set; } //		varchar	30

        public string ExpanDiverPowerUniqueID { get; set; }
        public string ExpanDiverPowerCompany { get; set; }
        public string ExpanDiverPowerReleaseDate { get; set; } //		date	3
        public string ExpanDiverConnectedLoad { get; set; } //	varchar	20
        public string ExpanDiverContractedLoad { get; set; } //	varchar	10
        public string ExpanDiverServiceConnectionNO { get; set; } //	varchar	30
        public string ExpanServiceRateUnit { get; set; } //		varchar	30

        public string waterSource { get; set; }
        public string waterRequirement { get; set; }
        public string waterRateperunit { get; set; }

        public int ManagementStaffMale { get; set; } //int	4
        public int ManagementStaffFemale { get; set; } //int	4
        public int SupervisoryMale { get; set; } //int	4
        public int SupervisoryFemale { get; set; } //int	4


        public int SkilledWorkersMale { get; set; } //	int	4
        public int SkilledWorkersFemale { get; set; } //	int	4
        public int SemiSkilledWorkersMale { get; set; } //		int	4
        public int SemiSkilledWorkersFemale { get; set; } //	int	4

        public int ManagementStaffMaleNonLocal { get; set; } //int	4
        public int ManagementStaffFemaleNonLocal { get; set; } //int	4
        public int SupervisoryMaleNonLocal { get; set; } //int	4
        public int SupervisoryFemaleNonLocal { get; set; } //int	4


        public int SkilledWorkersMaleNonLocal { get; set; } //	int	4
        public int SkilledWorkersFemaleNonLocal { get; set; } //	int	4
        public int SemiSkilledWorkersMaleNonLocal { get; set; } //		int	4
        public int SemiSkilledWorkersFemaleNonLocal { get; set; } //	int	4

        public int ManagementStaffFemaleindirect { get; set; } //int	4
        public int SupervisoryFemaleindirect { get; set; } //int	4
        public int SkilledWorkersFemaleindirect { get; set; } //	int	4
        public int SemiSkilledWorkersMaleindirect { get; set; } //		int	4

        public int ManagementStaffMaleindirect { get; set; } //int	4
        public int SupervisoryMaleindirect { get; set; } //int	4
        public int SkilledWorkersMaleindirect { get; set; } //	int	4
        public int SemiSkilledWorkersFemaleindirect { get; set; } //	int	4

        public int EmpDirectLocalMaleOther { get; set; }
        public int EmpDirectLocalFemaleOther { get; set; }
        public int EmpDirectNonLocalMaleOther { get; set; }
        public int EmpDirectNonLocalFemaleOther { get; set; }
        public int EmpIndirectMaleOther { get; set; }
        public int EmpIndirectFemaleOther { get; set; }

        public string ProjectFinance { get; set; } //decimal	9
        public string TermLoanApplDate { get; set; } //date	3
        public string InstitutionName { get; set; } //varchar	100
        public string TermLoanSancRefNo { get; set; } //varchar	50

        //public string AvailedSubsidyEarlier { get; set; } //char	1
        //public string TotalSubsidyAlreadyAvailedScheme { get; set; } //decimal	9
        //public string TotalSubsidyAlreadyAvailedAmount { get; set; } //decimal	9

        public string SecondHandMachVal { get; set; } //decimal	9
        public string NewMachVal { get; set; } //decimal	9
        public string Newand2ndlMachTotVal { get; set; } //decimal	9
        public string PercentageSHMValinTotMachVal { get; set; } //decimal	9
        public string MachValPrchasedfromAPIDCorAPSFCBank { get; set; } //decimal	9
        public string TotalMachVal { get; set; } //decimal	9

        //public string InvestimentSubsidy { get; set; } //decimal	9
        //public string AdditionalInvSubsidyForWomen { get; set; } //decimal	9
        //public string AdditionalInvSubsidyForSCORST { get; set; } //decimal	9
        //public string AdditionalInvSubsidyForWomenInScheduledAreas { get; set; } //decimal	9
        //public string TotalAppliedIncetives { get; set; } //decimal	9

        public string CfeQuid { get; set; } //int	4
        public string CfoQuid { get; set; } //int	4
        public string intStatusid { get; set; } //int	4
        public string Createdby { get; set; } //int	4
        public string Created_dt { get; set; } //datetime	8
        public string Modifiedby { get; set; } //int	4
        public string Modified_dt { get; set; } //datetime	8
        public string InvSubsidyFlg { get; set; } //varchar	1
        public string PowerSubsidyFlg { get; set; } //varchar	1
        public string VATSubsidyFlg { get; set; } //varchar	1
        public string PavlaVaddiFlg { get; set; } //varchar	1
        public string StampDutyFlg { get; set; } //varchar	1
        public string AdvSubsidyFlg { get; set; } //varchar	1
        public string QualityFlg { get; set; } //varchar	1
        public string DateOfComm { get; set; } //varchar	1
        public string DateOfCommExp { get; set; } //varchar	1

        public string Vatno { get; set; } //varchar	1
        public string Cstno { get; set; } //varchar	1

        public string CSTRegDate { get; set; } //	varchar	15
        public string CSTRegAuthority { get; set; } //	varchar	-1
        public string CSTRegAuthAddress { get; set; } //	varchar	-1
        public string PowerStatus { get; set; } //	varchar	-1


        // 06/06/2017
        public string isSecondHandMachVal { get; set; } //decimal	9  added on 05/06/2017
        public string isSecondHandMachValValue { get; set; }
        public string TermLoanSanDate { get; set; } //date	3
        public string eepinscapUnit { get; set; } //decimal	9  added on 05/06/2017
        public string edpinscapUnit { get; set; } //decimal	9  added on 05/06/2017

        public string UnitState { get; set; }
        public string OffcState { get; set; }
        public string OffcOtherDist { get; set; }
        public string OffcOtherMandal { get; set; }
        public string OffcOtherVillage { get; set; }
        public string EMPart { get; set; }

        public string SubCaste { get; set; } //	Varchar	20 
        public string GSTNO { get; set; } //	Varchar	50

        public string GSTDate { get; set; } //	Varchar	20 
        public string IndustryExpansionType { get; set; } //	Varchar	20

        //public string PowNewConnectUnit { get; set; } //	Varchar	20 
        //public string PowNewContractUnit { get; set; } //	Varchar	20
        //public string PowExistConnectUnit { get; set; } //	Varchar	20 
        //public string PowExistContractUnit { get; set; } //	Varchar	20
        //public string PowDiversConnectUnit { get; set; } //	Varchar	20 
        //public string PowDiversContractUnit { get; set; } //	Varchar	20
        //public string IsPowerApplicable { get; set; } //	Varchar	20
        //public string IsPowerApplicableValues { get; set; } //	Varchar	20

        public string PowNewConnectUnit { get; set; } //	Varchar	20 
        public string PowNewConnectUnitValue { get; set; } //	Varchar	20 
        public string PowNewContractUnit { get; set; } //	Varchar	20
        public string PowNewContractUnitValue { get; set; } //	Varchar	20

        public string PowExistConnectUnit { get; set; } //	Varchar	20 
        public string PowExistConnectUnitValue { get; set; } //	Varchar	20 
        public string PowExistContractUnit { get; set; } //	Varchar	20
        public string PowExistContractUnitValue { get; set; } //	Varchar	20
        public string PowDiversConnectUnit { get; set; } //	Varchar	20 
        public string PowDiversConnectUnitValue { get; set; } //	Varchar	20 
        public string PowDiversContractUnit { get; set; } //	Varchar	20
        public string PowDiversContractUnitValue { get; set; } //	Varchar	20
        public string IsPowerApplicable { get; set; } //	Varchar	20
        public string IsPowerApplicableValues { get; set; } //	Varchar	20

        public string IsWaterSourceApplicable { get; set; } //	Varchar	20
        public string IsWaterSourceApplicableValues { get; set; } //	Varchar	20


        public string UdyogAadharType { get; set; } //	Varchar	20
        public string UdyogAadharRegdDate { get; set; } //	Varchar	20

        public string IsTermLoanAvailed { get; set; } //	Varchar	20
        public string BankAccType { get; set; } //	Varchar	20
        public string BankAccName { get; set; } //	Varchar	20

        // DIPC Entry Screen VOs
        public string incentiveTypeID { get; set; } //    Varchar    20
        public string incentiveTypename { get; set; } //    Varchar    20

        public decimal recommendedAnount { get; set; } //    Varchar    20
        public decimal sanctionAmount { get; set; } //    Varchar    20


        public string sanctionDate { get; set; } //    Varchar    20
        public string DIPCNO { get; set; } //    Varchar    20
        public string DIPCDate { get; set; } //    Varchar    20

        public string SLCNO { get; set; } //    Varchar    20
        public string SLCDate { get; set; } //    Varchar    20
        public string SCHEMEName { get; set; } //    Varchar    20
        public string Committee { get; set; } //    Varchar    20
        public string Status { get; set; } //    Varchar    20
        public string Remarks { get; set; } //    Varchar    20

        // 29072017
        public string Sector { get; set; } //    Varchar    20
        public string IndsCategory { get; set; } //    Varchar    20
        public string TypeOfAccount { get; set; } //    Varchar    20
        public string financialyear { get; set; } //    Varchar    20
        public string SeriatumNo { get; set; } //    Varchar    20 UnitStateId
        public string UnitStateId { get; set; } //    Varchar    20 
        public string FinHalfYear { get; set; } //    Varchar    20 

        public string Pride { get; set; } //    Varchar    20 
        public string UidNoInc { get; set; } //    Varchar    20 

        public string AuthorisedSignatoryDesignation { get; set; }
        public string AuthorisedSignatoryDesignationValue { get; set; }
        public string isIALA { get; set; } //    Varchar    20 
        public int IndusParkList { get; set; } //    Varchar    20 
        public string AppsLevel { get; set; } //    Varchar    20 

        public string DateOfIncorporation { get; set; }
        public string IncorpRegistranNumber { get; set; }
        public string CountryOrigin { get; set; }
        public string TextileProcessType { get; set; }
        public string TechnicalTextileType { get; set; }
        public string TextileProcessTypeExp { get; set; }


        public string SpecialIncentiveYN { get; set; }
        public string GovermentOrderNumber { get; set; }
        public string GovermentOrderDate { get; set; }

        public string NewOtherTextileProcessType { get; set; }
        public string ExistOtherTextileProcessType { get; set; }


        public string YearsOfExpinTexttile { get; set; }
        public string EducationalQual { get; set; }

        public string Percentge_FixedCapitalInvestment { get; set; }
        public string Nature_Industry { get; set; }
        public string InstalledCapacityperAnnum { get; set; }
        public string WhetherAllotedByGovt { get; set; }
        public string CategoryTTAP { get; set; }

        public string Products_Manufactured { get; set; }
        public string NO_OtherEstablishments { get; set; }
        public string Authorized_MobileNo { get; set; }
        public string Authorized_EmailId { get; set; }
        public string Authorized_PAN_NO { get; set; }
        public string Authorized_CorresponAdderess { get; set; }

        public string PromotersEquity_MF { get; set; }
        public string InstitutionEquity_MF { get; set; }
        public string TermsLoans_MF { get; set; }
        public string Others_MF { get; set; }
        public string SeedCapital_MF { get; set; }
        public string SubsidyGrantsAgencies_MF { get; set; }

        public string IncentivesAvaild_StateCentrlGovt { get; set; }
        public string NameOfScheme_Agency { get; set; }

        public string PlinthArea { get; set; }
        public string RateperAcre { get; set; }
        public string TotalInvestment { get; set; }
        public string Infrastructure1 { get; set; }
        public string Infrastructure2 { get; set; }
        public string Infrastructure3 { get; set; }
        public string OtherProductive1 { get; set; }
        public string OtherProductive2 { get; set; }
        public string OtherProductive3 { get; set; }
        public string TotalInvestmentBuilding { get; set; }
        public string Transportation { get; set; }
        public string Erection { get; set; }
        public string Electrification { get; set; }
        public string OtherAssets { get; set; }
        public string TotalPlantMechinery { get; set; }
        public string TotalCapitalInvestment { get; set; }

        public string Source { get; set; }
        public string Requirement { get; set; }
        public string RateperUnit { get; set; }
        public bool IsSubsidiesIncentives { get; set; }
        public string IsSubsidiesIncentivesAmount { get; set; }
        public string NameoftheScheme { get; set; }
        public string EstablishmentYear { get; set; }
        public string NumberofEmployees { get; set; }



        public string TurnOver_1stYear { get; set; }
        public string TurnOver_2ndYear { get; set; }
        public string TurnOver_3rdYear { get; set; }

        public string EBITDA_1stYear { get; set; }
        public string EBITDA_2ndYear { get; set; }
        public string EBITDA_3rdYear { get; set; }

        public string Networth_1stYear { get; set; }
        public string Networth_2ndYear { get; set; }
        public string Networth_3rdYear { get; set; }

        public string ReservesSurplus_1stYear { get; set; }
        public string ReservesSurplus_2ndYear { get; set; }
        public string ReservesSurplus_3rdYear { get; set; }

        public string Share_Capital_1stYear { get; set; }
        public string Share_Capital_2ndYear { get; set; }
        public string Share_Capital_3rdYear { get; set; }


        public string LandApprovedProjectCost { get; set; } //	decimal	9
        public string LandLoanSactioned { get; set; } //	decimal	9
        public string LandPromotersEquity { get; set; } //	decimal	9
        public string LandLoanAmountReleased { get; set; } //	decimal	9
        public string LandAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string LandAssetsValuebyCA { get; set; } //	decimal	9
        public string BuildingApprovedProjectCost { get; set; } //	decimal	9
        public string BuildingLoanSactioned { get; set; } //	decimal	9
        public string BuildingPromotersEquity { get; set; } //	decimal	9
        public string BuildingLoanAmountReleased { get; set; } //	decimal	9
        public string BuildingAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string BuildingAssetsValuebyCA { get; set; } //	decimal	9
        public string PlantMachineryApprovedProjectCost { get; set; } //	decimal	9
        public string PlantMachineryLoanSactioned { get; set; } //	decimal	9
        public string PlantMachineryPromotersEquity { get; set; } //	decimal	9
        public string PlantMachineryLoanAmountReleased { get; set; } //	decimal	9
        public string PlantMachineryAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string PlantMachineryAssetsValuebyCA { get; set; } //	decimal	9
        public string MachineryContingenciesApprovedProjectCost { get; set; } //	decimal	9
        public string MachineryContingenciesLoanSactioned { get; set; } //	decimal	9
        public string MachineryContingenciesPromotersEquity { get; set; } //	decimal	9
        public string MachineryContingenciesLoanAmountReleased { get; set; } //	decimal	9
        public string MachineryContingenciesAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string MachineryContingenciesAssetsValuebyCA { get; set; } //	decimal	9
        public string ErectionApprovedProjectCost { get; set; } //	decimal	9
        public string ErectionLoanSactioned { get; set; } //	decimal	9
        public string ErectionLoanAmountReleased { get; set; } //	decimal	9
        public string ErectionPromotersEquity { get; set; } //	decimal	9
        public string ErectionAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string ErectionAssetsValuebyCA { get; set; } //	decimal	9
        public string TechnicalfeasibilityApprovedProjectCost { get; set; } //	decimal	9
        public string TechnicalfeasibilityLoanSactioned { get; set; } //	decimal	9
        public string TechnicalfeasibilityPromotersEquity { get; set; } //	decimal	9
        public string TechnicalfeasibilityLoanAmountReleased { get; set; } //	decimal	9
        public string TechnicalfeasibilityAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string TechnicalfeasibilityAssetsValuebyCA { get; set; } //	decimal	9
        public string WorkingCapitalApprovedProjectCost { get; set; } //	decimal	9
        public string WorkingCapitalLoanSactioned { get; set; } //	decimal	9
        public string WorkingCapitalPromotersEquity { get; set; } //	decimal	9
        public string WorkingCapitalLoanAmountReleased { get; set; } //	decimal	9
        public string WorkingCapitalAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string WorkingCapitalAssetsValuebyCA { get; set; } //	decimal	9

        public string ProductionYear1 { get; set; }
        public string ProductionQuantity1 { get; set; }
        public string ProductionValue1 { get; set; }

        public string ProductionYear2 { get; set; }
        public string ProductionQuantity2 { get; set; }
        public string ProductionValue2 { get; set; }

        public string ProductionYear3 { get; set; }
        public string ProductionQuantity3 { get; set; }
        public string ProductionValue3 { get; set; }

        public string IpassLand { get; set; }
        public string IpassLandExp { get; set; }
        public string IpassBuilding { get; set; }
        public string IpassBuildingExp { get; set; }
        public string IpassPlantMachine { get; set; }
        public string IpassPlantMachineExp { get; set; }
    }

    public class AppliedIncentiveStatus
    {
        public int EnterperIncentiveID { get; set; }
        public int MstIncentiveId { get; set; }
        public string Created_by { get; set; }
        public string Isactive { get; set; }
    }

    public class BackgroundDetails
    {

        public string Incentive_id { get; set; }
        public string created_by { get; set; }
        public string TurnOver_1stYear { get; set; }
        public string TurnOver_2ndYear { get; set; }
        public string TurnOver_3rdYear { get; set; }

        public string EBITDA_1stYear { get; set; }
        public string EBITDA_2ndYear { get; set; }
        public string EBITDA_3rdYear { get; set; }

        public string Networth_1stYear { get; set; }
        public string Networth_2ndYear { get; set; }
        public string Networth_3rdYear { get; set; }

        public string ReservesSurplus_1stYear { get; set; }
        public string ReservesSurplus_2ndYear { get; set; }
        public string ReservesSurplus_3rdYear { get; set; }

        public string Share_Capital_1stYear { get; set; }
        public string Share_Capital_2ndYear { get; set; }
        public string Share_Capital_3rdYear { get; set; }
    }
    public class IncentiveVosA
    {
        public string User_id { get; set; } //	int	4
        public string Incentive_id { get; set; } //	varchar	20
        public string CfeQuid { get; set; } //	int	4
        public string CfoQuid { get; set; } //	int	4
        public string LandApprovedProjectCost { get; set; } //	decimal	9
        public string LandLoanSactioned { get; set; } //	decimal	9
        public string LandPromotersEquity { get; set; } //	decimal	9
        public string LandLoanAmountReleased { get; set; } //	decimal	9
        public string LandAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string LandAssetsValuebyCA { get; set; } //	decimal	9
        public string BuildingApprovedProjectCost { get; set; } //	decimal	9
        public string BuildingLoanSactioned { get; set; } //	decimal	9
        public string BuildingPromotersEquity { get; set; } //	decimal	9
        public string BuildingLoanAmountReleased { get; set; } //	decimal	9
        public string BuildingAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string BuildingAssetsValuebyCA { get; set; } //	decimal	9
        public string PlantMachineryApprovedProjectCost { get; set; } //	decimal	9
        public string PlantMachineryLoanSactioned { get; set; } //	decimal	9
        public string PlantMachineryPromotersEquity { get; set; } //	decimal	9
        public string PlantMachineryLoanAmountReleased { get; set; } //	decimal	9
        public string PlantMachineryAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string PlantMachineryAssetsValuebyCA { get; set; } //	decimal	9
        public string MachineryContingenciesApprovedProjectCost { get; set; } //	decimal	9
        public string MachineryContingenciesLoanSactioned { get; set; } //	decimal	9
        public string MachineryContingenciesPromotersEquity { get; set; } //	decimal	9
        public string MachineryContingenciesLoanAmountReleased { get; set; } //	decimal	9
        public string MachineryContingenciesAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string MachineryContingenciesAssetsValuebyCA { get; set; } //	decimal	9
        public string ErectionApprovedProjectCost { get; set; } //	decimal	9
        public string ErectionLoanSactioned { get; set; } //	decimal	9
        public string ErectionLoanAmountReleased { get; set; } //	decimal	9
        public string ErectionPromotersEquity { get; set; } //	decimal	9
        public string ErectionAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string ErectionAssetsValuebyCA { get; set; } //	decimal	9
        public string TechnicalfeasibilityApprovedProjectCost { get; set; } //	decimal	9
        public string TechnicalfeasibilityLoanSactioned { get; set; } //	decimal	9
        public string TechnicalfeasibilityPromotersEquity { get; set; } //	decimal	9
        public string TechnicalfeasibilityLoanAmountReleased { get; set; } //	decimal	9
        public string TechnicalfeasibilityAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string TechnicalfeasibilityAssetsValuebyCA { get; set; } //	decimal	9
        public string WorkingCapitalApprovedProjectCost { get; set; } //	decimal	9
        public string WorkingCapitalLoanSactioned { get; set; } //	decimal	9
        public string WorkingCapitalPromotersEquity { get; set; } //	decimal	9
        public string WorkingCapitalLoanAmountReleased { get; set; } //	decimal	9
        public string WorkingCapitalAssetsValuebyFinInstitution { get; set; } //	decimal	9
        public string WorkingCapitalAssetsValuebyCA { get; set; } //	decimal	9
        public string created_by { get; set; } //	int	4
        public string created_dt { get; set; } //	datetime	8
        public string Modified_by { get; set; } //	int	4
        public string Modified_dt { get; set; } //	datetime	8

    }

    public class IncentiveVosIncetForms
    {
        //Is
        public string IncentveID { get; set; } //int
        public string AvldSubsidyScheme { get; set; } //	varchar
        public string AvldSubsidyAmt { get; set; } //	varchar
        public string SchemeEligible { get; set; } //varchar
        public string AppldInvestSubsidy { get; set; } //varchar
        public string AppldAddlAmtWomen { get; set; } //varchar
        public string AppldTotInvestSubsidy { get; set; } //varchar
        public string Created_by { get; set; } //int
        public string Created_dt { get; set; } //datetime
        public string status { get; set; } //	int
        public string Modified_by { get; set; } //int
        public string Modified_dt { get; set; } //datetime

        // added on 17.06.2017  
        public string ISubsidySCSCT { get; set; } //varchar(100)
        public string ISubsidyScheduledAreas { get; set; } //varchar(100)

        // stamp Duty

        public string AreaRegdSaledeed { get; set; } // varchar	100
        public string PlnthAreaBuild { get; set; } // varchar	50
        public string FivePlnthAreaBuild { get; set; } // varchar	50
        public string AreaReqdAppraisal { get; set; } // varchar	50
        public string AreaReqdTSPCB { get; set; } // varchar	50
        public string NatureofTrans { get; set; } // varchar	50
        public string SubRegOffc { get; set; } // varchar	-1
        public string RegdDeedNo { get; set; } // varchar	50
        public DateTime RegnDate { get; set; } // datetime	8
        public string StampTranfrDutyAP { get; set; } // varchar	50
        public string MortgageHypothDutyAP { get; set; } // varchar	50
        public string LandConvrChrgAP { get; set; } // 	50
        public string LandCostIeIdaIpAP { get; set; } // varchar	50
        public string StampTranfrDutyAC { get; set; } // varchar	50
        public string MortgageHypothDutyAC { get; set; } // varchar	50
        public string LandConvrChrgAC { get; set; } // varchar	50
        public string LandCostIeIdaIpAC { get; set; } // varchar	50

        // Advanced Subsidy for SC/ST
        public string TotalEquity { get; set; } // varchar	50
        public string OwnCapital { get; set; } // varchar	50
        public string Borrowed { get; set; } // varchar	50
        public string AdvSubClaimed { get; set; } // varchar	50


        // IID FUND

        public string UnitLocatedinIndustArea { get; set; } // 	char	1
        public string JustLocation { get; set; } // 	-1
        public string FinanceSource { get; set; } // 	varchar	500
        public string ReqdInfraFacilities { get; set; } // varchar	-1
        public string ProposedInfraCritical { get; set; } // varchar	-1
        public string EstimatesInfra { get; set; } // varchar	100
        public string CAName { get; set; } // varchar	500
        public string ProjDuration { get; set; } // varchar	50
                                                 //public string MeasuresProposed { get; set; } // varchar	500
        public string MaintanCostAnnum { get; set; } // varchar	50 
        public string AmtClaimed { get; set; } // varchar	50

        // Check Slip

        public string CSIncentiveId { get; set; } // 	int	4
        public string CSEntprId { get; set; } // 	int	4
        public string CSCreatedBy { get; set; } // 	int	4
        public string CSbillsofinstitutfinancedEnterpriseindustries { get; set; } // 	char	1
        public string CSbillandpymtproofrespectofselffinancedEnterprisesindustries { get; set; } // 	char	1
        public string CasteCertificatesSCST { get; set; } // 	char	1
        public string CSEntrepreneurAadhar { get; set; } // 	char	1
        public string CSEntrepreneurPANCard { get; set; } // 	char	1
        public string CSCertificateofCA { get; set; } // 	char	1
        public string CSRegdPartnershipDeedArticles { get; set; } // 	char	1
        public string CSApprovalDirectorFactories { get; set; } // 	char	1
        public string CSBoilersCertificate { get; set; } // 	char	1
        public string CSApprovalDirectorTownCountryPlanningUDA { get; set; } // 	char	1
        public string CSRegularbuildingplansapprovalofMunicipalityGramPanchayat { get; set; } // 	char	1
        public string CSOperationTSPCBAcknowledgementGM { get; set; } // 	char	1
        public string CSPowerreleaseCertificatefrmTSTRANSCODISCOM { get; set; } // 	char	1
        public string CSEnvironmentalclearance { get; set; } // 	char	1
        public string CSOtherstatutoryapprovalsspecif { get; set; } // 	char	1
        public string CSEMPartIfullsetIEMIL { get; set; } // 	char	1
        public string CSEMPartIIfullsetIEMIL { get; set; } // 	char	1
        public string CSUdyogAadhar { get; set; } // 	char	1
        public string CSProjectReport { get; set; } // 	char	1
        public string CSTermloansanctionletters { get; set; } // 	char	1
        public string CSBoardResolutionauthorizing { get; set; } // 	char	1
        public string CSRegisteredlandSaledeedPremisesLeasedeed { get; set; } // 	char	1
        public string CSCACECertificateregarding2handplantmachinery { get; set; } // 	char	1
        public string CSCECertificateSelffabricatedmachinery { get; set; } // 	char	1
        public string CSBISCertificate { get; set; } // 	char	1
        public string CSDrugLicense { get; set; } // 	char	1
        public string CSExplosiveLicense { get; set; } // 	char	1
        public string CSVATCSTSGSTCertificate { get; set; } // 	char	1
        public string CSFormA { get; set; } // 	char	1
        public string CSFormB { get; set; } // 	char	1
        public string Status { get; set; } // 	char	1

        public string CSProductionParticulars3Years { get; set; } // 	char	1   
        public string CSRTACertificate { get; set; } // 	char	1   
        public string CSPHCertificate { get; set; } // 	char	1   
        public string CSUndertakingForm { get; set; } // 	char	1  

        public string ApplicantVehPhoto { get; set; } // 	char	1 
        public string COBORROWER { get; set; } // 	char	1 
        public string firstsalebill { get; set; } // 	char	1 
    }

    public class IndustryLineofActivities
    {
        public string slno { get; set; }
        public string LineOfActivity { get; set; }
        public string InstalledCapacity { get; set; }
        public string Unit { get; set; }
        public string ValueRs { get; set; }
        public string ValuePerUnitRs { get; set; }
        public string Created_by { get; set; }
        public string IncentiveId { get; set; }
        public string LOAType { get; set; }
        public string TransType { get; set; }

    }

    public class IndirectEmploymentVo
    {
        public string IndirectEmploymentID { get; set; }
        public string IncentiveId { get; set; }
        public string Category { get; set; }
        public string IndirectMale { get; set; }
        public string IndirectFemale { get; set; }
        public string Created_by { get; set; }
        public string TransType { get; set; }
    }
    public class PMAbstractVo
    {
        public string PMAbstractID { get; set; }
        public string IncentiveId { get; set; }
        public string TypeOfMachinery { get; set; }
        public string Noofmachines { get; set; }
        public string AttachmentId { get; set; }
        //public string AttachmentId2 { get; set; }
        public string Created_by { get; set; }
        public string TransType { get; set; }
    }
    public class IndustryPartnerDtls
    {
        public string Slno { get; set; }
        public string Name { get; set; }
        public string Share { get; set; }
        public string Community { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public string EducationalQual { get; set; }
        public string EducationalQualOther { get; set; }
        public string YearsOfExpinTexttileDirector { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string PanNO { get; set; }
        public string Created_by { get; set; }
        public string IncentiveId { get; set; }
        public string TransType { get; set; }

    }


    public class IndustryTermLoanDtls
    {
        public string TermLoanId { get; set; }
        public string IncentiveId { get; set; }
        public string AvailedTermLoan { get; set; }
        public string TermLoanApplDate { get; set; }
        public string InstitutionName { get; set; }
        public string TermLoanSancRefNo { get; set; }
        public string TermloanSandate { get; set; }
        public string TermLoanReleaseddate { get; set; }
        public string Installments { get; set; }
        public string RateOfInterest { get; set; }
        public string SanctionedAmount { get; set; }
        public string TermLoanPeriodFromDate { get; set; }
        public string TermLoanPeriodToDate { get; set; }
        public string TransType { get; set; }
        public string Created_by { get; set; }
    }

    public class CapitalAssistanceNewUnitvo
    {
        public string IncentiveID { get; set; }
        public string TypeofUnit { get; set; }
        public string FactoryShedsandBuildings { get; set; }
        public string LandnotAllottedbyGov { get; set; }
        public string PlandandMachinery { get; set; }
        public string Laboratories { get; set; }
        public string Utilities { get; set; }
        public string OtherFixedAssets { get; set; }
        public string Total { get; set; }
        public string AmountSubsidyClaimed { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class ExistingUnitBO
    {
        public string IncentiveID { get; set; }

        public string UpgradationofUnit { get; set; }

        public string PlandandMachinery { get; set; }

        public string NewTechnologies { get; set; }

        public string Total { get; set; }

        public string AmountSubsidyClaimed { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }

    public class CapAssCreationEnergyBO
    {
        public string IncentiveID { get; set; }
        public string TypeofInfrastructure { get; set; }
        public string CreatedCETP { get; set; }
        public string TextTileType { get; set; }
        public string TotalCostCapital { get; set; }
        public string GOI { get; set; }
        public string StateGovt { get; set; }
        public string Beneficiary { get; set; }
        public string Bank { get; set; }
        public string OperationalCostMLDofInputWater { get; set; }

        //public string CostofEnergy { get; set; }
        //public string CostofWater { get; set; }
        //public string CostofEnvironmental { get; set; }
        //public string CostofEffluent { get; set; }

        public string EnergyEquipment { get; set; }
        public string WaterEquipment { get; set; }
        public string EnvironmentalEquipment { get; set; }
        public string EffluentTreatment { get; set; }

        public string Instalment1 { get; set; }
        public string Instalment2 { get; set; }
        public string NameoftheEquipment { get; set; }
        public string NameandAddress { get; set; }
        public string BillandDate { get; set; }
        public string CostofEquipment { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string FreightCharges { get; set; }
        public string OtherCharges { get; set; }
        public string Total { get; set; }
        public string AmountSubsidyClaimedEnergy { get; set; }
        public string AmountSubsidyClaimedEffluent { get; set; }
        public DataTable GridData { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class TraineeDetailsBO
    {
        public string Trainee_ID { get; set; }
        public string IncentiveId { get; set; }
        public string NameoftheTrainee { get; set; }
        public string Trainingfromdate { get; set; }
        public string Trainingtodate { get; set; }
        public string ExpenditureIncurred { get; set; }
        public string TransType { get; set; }
        public string CreatedBy { get; set; }

        public string TypeofTraining { get; set; }
        public string TraineeLocalization { get; set; }

        public string TypeofTrainingText { get; set; }
        public string TraineeLocalizationText { get; set; }
    }
    public class EquipmentDetailsBO
    {
        public string Equipment_ID { get; set; }
        public string IncentiveId { get; set; }
        public string NameoftheEquipment { get; set; }
        public string EquipmentNameAddressofSupplier { get; set; }
        public string EquipmentInvoiceNo { get; set; }
        public string EquipmentInvoiceDate { get; set; }
        public string EquipmentDateOfLanding { get; set; }
        public string EquipmentDateOfCommissioning { get; set; }
        public string EquipmentWayBillNumber { get; set; }
        public string EquipmentDateOfWayBill { get; set; }
        public string CostofEquipment { get; set; }
        public string Equipmentcgst { get; set; }
        public string Equipmentsgst { get; set; }
        public string EquipmentFreightCharges { get; set; }
        public string EquipmentInitiationCharges { get; set; }
        public string Total { get; set; }
        public string TransType { get; set; }
        public string Created_by { get; set; }
        public string TypeofEquipmentId { get; set; }
        public string TypeofEquipmentName { get; set; }
    }

    public class InterestSubsidyBO
    {
        public string IncentiveID { get; set; }
        public string NameofFinance { get; set; }
        public string SanctionDetails { get; set; }

        public string Bank { get; set; }
        public string LoanAccountNo { get; set; }
        public string SanctionOrderNo { get; set; }
        public string AmountSanctioned { get; set; }
        public string RateofInterest { get; set; }
        public string TermLoanReleased { get; set; }

        public string Year { get; set; }
        public string BankFI { get; set; }
        public string Principal { get; set; }
        public string Interest { get; set; }

        public string CurrentclaimPeriod { get; set; }
        public string MoratoriumPeriod { get; set; }
        public string FirstHalf { get; set; }
        public string SecondHalf { get; set; }
        public string CurrentClaimAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class TermLoanBO
    {
        public string IncentiveID { get; set; }
        public string Bank { get; set; }
        public string LoanAccountNo { get; set; }
        public string SanctionOrderNo { get; set; }
        public string AmountSanctioned { get; set; }
        public string RateofInterest { get; set; }
        public string TermLoanReleased { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }

    public class TermLoanRepaidBO
    {
        public string IncentiveID { get; set; }
        public string Year { get; set; }
        public string BankFI { get; set; }
        public string Principal { get; set; }
        public string Interest { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class PowerTariffSubsidyBO
    {
        public string IncentiveID { get; set; }
        public string ExistingPower { get; set; }
        public string NewPower { get; set; }
        public string TotalPowerconnections { get; set; }
        public string IndustryPowerconnections { get; set; }
        public string DateofNewpower { get; set; }

        public string FinancialYear { get; set; }
        public string TotalUnits { get; set; }
        public string TotalAmount { get; set; }

        public string NoofUnits { get; set; }
        public string AmountPaid { get; set; }
        public string SecondNoofunits { get; set; }
        public string SecondAmountPaid { get; set; }

        public string CurrentClaimPeriodFrom { get; set; }
        public string CurrentClaimPeriodTo { get; set; }

        public string CurrentClaimAmount { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }

    public class PowerUtilizedBO
    {
        public string Powerutilized_ID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string FinancialYear { get; set; }
        public string FinancialYearText { get; set; }
        public string TotalUnits { get; set; }
        public string TotalAmount { get; set; }
        public string Created_by { get; set; }

    }
    public class EPTChargesVo
    {
        public string ETPCharges_ID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string MonthYear { get; set; }
        public string EffluentTreated { get; set; }
        public string EffluentTreatmentCharges { get; set; }

        public string FinancialYear { get; set; }
        public string FinancialYearText { get; set; }

        public string TypeOfFinancialYear { get; set; }
        public string TypeOfFinancialYearText { get; set; }
        public string ComponentId { get; set; }
        public string Created_by { get; set; }

    }
    public class AdditionalinformationBO
    {
        public string AdditionalinformationId { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string Created_by { get; set; }

        public string AmountDueDate { get; set; }
        public string TypeOfFinancialYear { get; set; }
        public string TypeOfFinancialYearText { get; set; }
        public string TearmLoanAmount { get; set; }
        public string NoOfInstallments { get; set; }
        public string RateofInterestAmountDue { get; set; }
        public string InterestDue { get; set; }
        public string UnitHolderContribution { get; set; }
        public string EligibleRateInterest { get; set; }
        public string EligibleInterest { get; set; }
        public string MonthId { get; set; }
        public string Months { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public int InstallmentNo { get; set; }
        public string InterestPaid { get; set; }
        public string ClosingBalance { get; set; }
        public string TermLoan { get; set; }
    }

    public class CurrentClaimFinancialBo
    {
        public string CurrentClaimFinancialID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string FinancialYear { get; set; }
        public string FinancialYearText { get; set; }

        public string TypeOfFinancialYear { get; set; }
        public string TypeOfFinancialYearText { get; set; }

        public string CurrentClaimmadeYear { get; set; }
        public string CurrentClaimmadeYearText { get; set; }

        public string Totalproduction { get; set; }
        public string TotalSaleRevenue { get; set; }
        public string TotalExportRevenue { get; set; }
        public string FreightPurchaseRawMaterial { get; set; }
        public string FreightExportFinishedGoods { get; set; }

        public string Created_by { get; set; }
    }
    public class EnergyConsumedBO
    {
        public string EnergyConsumed_ID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string FinancialYear { get; set; }
        public string FinancialYearText { get; set; }

        public string TypeOfFinancialYear { get; set; }
        public string TypeOfFinancialYearText { get; set; }

        public string ServiceNo { get; set; }
        public string TotalUnits { get; set; }
        public string TotalAmount { get; set; }

        public string PurposeofConnection { get; set; }
        public string RateofUnit { get; set; }
        public string OtherCharges { get; set; }

        public string FromReadingNumber { get; set; }
        public string ToReadingNumber { get; set; }

        public string Created_by { get; set; }
    }

    public class MoratoriumPeriodBO
    {
        public string MoratoriumPeriod_ID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string TypeOfFinancialYear { get; set; }
        public string TypeOfFinancialYearText { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public string BankID { get; set; }
        public string RateofInterest { get; set; }

        public string Created_by { get; set; }
    }
    public class ExportRevenueBO
    {
        public string ExportRevenueID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string FinancialYear { get; set; }
        public string FinancialYearText { get; set; }

        public string ProductionValue { get; set; }
        public string SaleRevenue { get; set; }
        public string ExportSalesValue { get; set; }
        public string FreightCharges { get; set; }

        public string Created_by { get; set; }
    }

    public class ProductSaleDetailsBO
    {
        public string SaleID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string SaleYear { get; set; }
        public string NameoftheProduct { get; set; }
        public string SaleQuantity { get; set; }
        public string SaleUnit { get; set; }
        public string TotalSaleValue { get; set; }

        public string Created_by { get; set; }
    }
    public class WorkerHousing
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string DateofEstablishmentofUnit { get; set; }
        public string WorkerHousingLocation { get; set; }
        public string Landpurchased { get; set; }
        public string BuildingPlinthArea { get; set; }
        public string BuildingAreaRequired { get; set; }
        public string LandInvestment { get; set; }
        public string LandConversionCharges { get; set; }
        public string PurchasedLandCost { get; set; }
        public string HousingOccupantsLoad { get; set; }
        public string OccupancyRate { get; set; }
        public string QuartersStartDate { get; set; }
        public string QuartersEndDate { get; set; }
        public string CurrentClaim { get; set; }
        public string TextileOrApparelArea { get; set; }

        public string TotalLandUsedForWorker { get; set; }
        public string Landpurchasedrateper { get; set; }
    }

    public class TrainingSubsidy
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string NumberofEmployees { get; set; }
        public string SkillName { get; set; }
        public string TrainingInstituteName { get; set; }
        public string NumberofEmployeesTrained { get; set; }
        public string NumberofEmployeesTrainedNonLocal { get; set; }
        public string ExpenditureIncurredTraining { get; set; }
        public string MonthsEmployment { get; set; }
        public string CurrentClaim { get; set; }
        public string AmountAvailed { get; set; }
        public string SanctionOrderNo { get; set; }
        public string DateAvailed { get; set; }
    }
    public class MigratIncentive
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string CapitalInvestment { get; set; }
        public string Scheme { get; set; }
        public string WeaversPercentage { get; set; }
        public string Contributiontoinvestment { get; set; }
        public string Building { get; set; }
        public string PlantMachinery { get; set; }
        public string InstallationCharges { get; set; }
        public string Electrification { get; set; }
        public string Others { get; set; }
        public string TotalInvestment { get; set; }
        public string CurrentClaim { get; set; }

        public string AmountAvailed { get; set; }
        public string SanctionOrderNo { get; set; }
        public string DateAvailed { get; set; }
        public string PercentageGOIContribution { get; set; }

    }
    public class TraningInfrastructure
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string NameofTrainingCentre { get; set; }
        public string EmpanelledDHT { get; set; }
        public string LocationofTrainingCentre { get; set; }
        public string Coursesoffered { get; set; }
        public string Building { get; set; }
        public string PlantMachinery { get; set; }
        public string InstallationCharges { get; set; }
        public string Electrification { get; set; }
        public string TrainingAids { get; set; }
        public string Furniture { get; set; }
        public string TotalInvestment { get; set; }
        public string CurrentClaim { get; set; }
        public string TypeofTrainingCentre { get; set; }
        public string TrainingCentrePurpose { get; set; }
    }

    public class RebateCharges
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string TypeofETP { get; set; }
        public string OtherETP { get; set; }
        public string CETPETPDetails { get; set; }
        public string CaptiveCommonETP { get; set; }
        public string ETPCost { get; set; }
        public string RebateClaimed { get; set; }
        public string YearoftheClaim { get; set; }
        public string AnyGovtAgency { get; set; }
        public string YearsCommercialProduction { get; set; }
        public string CommencementCommercialOperation { get; set; }
        public string DateofCommencementUtilization { get; set; }
        public string CurrentClaim { get; set; }
        public string ApprovedProjectCost { get; set; }
        public string ActualCostInvested { get; set; }

        public string UtilizationETPCETP { get; set; }

        public string AmountAvailed { get; set; }
        public string SanctionOrderNo { get; set; }
        public string DateAvailed { get; set; }
    }

    public class OtherInfrastructure
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string IndustrialArea { get; set; }
        public string CategoryofBusiness { get; set; }
        public string YearsofOperation { get; set; }
        public string Justificationforlocation { get; set; }
        public string ProposedInfrastructureJustification { get; set; }
        public string SourceOfFinance { get; set; }
        public string RoadsPowerWaterDescription { get; set; }
        public string SupportInfrastructureDescription { get; set; }
        public string SupportEstimateCost { get; set; }
        public string EstimateCostRoadsPowerWater { get; set; }
        public string CharteredEngineerName { get; set; }
        public string EstimateCostSupport15 { get; set; }
        public string EstimateCostRoadsPowerWater15 { get; set; }
        public string ProjectDuration { get; set; }
        public string Measuresproposed { get; set; }
        public string maintenancecost { get; set; }
        public string AssistanceAvailed { get; set; }
        public string AmountAvailed { get; set; }
        public string SanctionOrderNo { get; set; }
        public string DateAvailed { get; set; }

        public string EstimateCostPower { get; set; }
        public string EstimateCostWater { get; set; }
        public string EstimateCostDrainageLine { get; set; }

        public string EstimateCostPower15 { get; set; }
        public string EstimateCostWater15 { get; set; }
    }

    public class EnclosuresBO
    {
        public int CSCreatedBy { get; set; }
        public int CSIncentiveId { get; set; }
        public string CSbillsofinstitutfinancedEnterpriseindustries { get; set; }
        public string CSbillandpymtproofrespectofselffinancedEnterprisesindustries { get; set; }
        public string CasteCertificatesSCST { get; set; }
        public string CSEntrepreneurAadhar { get; set; }
        public string CSEntrepreneurPANCard { get; set; }
        public string CSCertificateofCA { get; set; }
        public string CSRegdPartnershipDeedArticles { get; set; }
        public string CSApprovalDirectorFactories { get; set; }
        public string CSBoilersCertificate { get; set; }
        public string CSApprovalDirectorTownCountryPlanningUDA { get; set; }
        public string CSRegularbuildingplansapprovalofMunicipalityGramPanchayat { get; set; }
        public string CSOperationTSPCBAcknowledgementGM { get; set; }
        public string CSPowerreleaseCertificatefrmTSTRANSCODISCOM { get; set; }
        public string CSEnvironmentalclearance { get; set; }
        public string CSOtherstatutoryapprovalsspecif { get; set; }
        public string CSEMPartIfullsetIEMIL { get; set; }
        public string CSUdyogAadhar { get; set; }
        public string CSProjectReport { get; set; }
        public string CSTermloansanctionletters { get; set; }
        public string CSBoardResolutionauthorizing { get; set; }
        public string CSRegisteredlandSaledeedPremisesLeasedeed { get; set; }
        public string CSCACECertificateregarding2handplantmachinery { get; set; }
        public string CSCECertificateSelffabricatedmachinery { get; set; }
        public string CSBISCertificate { get; set; }
        public string CSDrugLicense { get; set; }
        public string CSExplosiveLicense { get; set; }
        public string CSVATCSTSGSTCertificate { get; set; }
        public string CSFormA { get; set; }
        public string CSFormB { get; set; }
        public string CSProductionParticulars3Years { get; set; }
        public string CSRTACertificate { get; set; }
        public string CSPHCertificate { get; set; }
        public string CSUndertakingForm { get; set; }
        public string ApplicantVehPhoto { get; set; }
        public string firstsalebill { get; set; }
        public string COBORROWER { get; set; }

        public string CopyofPan { get; set; }
        public string DocFirstInvestment { get; set; }
        public string InvestmentCertificate { get; set; }
        public string EngineersCertificate { get; set; }
        public string CopyofReceipts { get; set; }
        public string ExpenditureCertificate { get; set; }
    }



    public class RentalSubsify
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string DateofEstablishmentofUnit { get; set; }
        public string TypeOfUse { get; set; }
        public string ProductionPersonsTrained { get; set; }
        public string TextileOrApparelArea { get; set; }
        public string RentalInformationType { get; set; }
        public string OtherLeasingArrangement { get; set; }
        public string BuiltUpSpaceOccupied { get; set; }
        public string RentLeaseAmountPerSqMtr { get; set; }
        public string TotalMonthlyNetRent { get; set; }
        public string PeriodofLeaseFromDate { get; set; }
        public string PeriodofLeaseToDate { get; set; }
        public string IsAnyothersubsidy { get; set; }
        public string SubsidySource { get; set; }
        public string SubsidySourceAmount { get; set; }
        public string ClaimApplicationsubmitted { get; set; }
        public string FromDateOfClaimAmount { get; set; }
        public string ToDateOfClaimAmount { get; set; }
        public string ReimbursementAmountClaimed { get; set; }

        public string RentalLeaseReg { get; set; }
        public string DeedNumber { get; set; }
        public string Deeddate { get; set; }
    }

    public class StampDutyVo
    {
        protected string _Action;
        protected string _insentiveid;
        protected string _NatureofAsset;
        protected string _LandPurchased;
        protected string _PlinthBuilding;
        protected string _FactoryBuildings;
        protected string _Factoryappraisal;
        protected string _TSPCB;
        protected string _NatureTransaction;
        protected string _SubRegistrar;
        protected string _StampDuty;
        protected string _StampExemption;
        protected string _Termloan;
        protected string _CurrentClaim;
        protected string _createdby;
        protected string _updatedBY;

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public string insentiveid
        {
            get { return _insentiveid; }
            set { _insentiveid = value; }
        }

        public string NatureofAsset
        {
            get { return _NatureofAsset; }
            set { _NatureofAsset = value; }
        }

        public string LandPurchased
        {
            get { return _LandPurchased; }
            set { _LandPurchased = value; }
        }

        public string PlinthBuilding
        {
            get { return _PlinthBuilding; }
            set { _PlinthBuilding = value; }
        }

        public string FactoryBuildings
        {
            get { return _FactoryBuildings; }
            set { _FactoryBuildings = value; }
        }

        public string Factoryappraisal
        {
            get { return _Factoryappraisal; }
            set { _Factoryappraisal = value; }
        }

        public string TSPCB
        {
            get { return _TSPCB; }
            set { _TSPCB = value; }
        }

        public string NatureTransaction
        {
            get { return _NatureTransaction; }
            set { _NatureTransaction = value; }
        }

        public string SubRegistrar
        {
            get { return _SubRegistrar; }
            set { _SubRegistrar = value; }
        }

        public string StampDuty
        {
            get { return _StampDuty; }
            set { _StampDuty = value; }
        }

        public string StampExemption
        {
            get { return _StampExemption; }
            set { _StampExemption = value; }
        }

        public string Termloan
        {
            get { return _Termloan; }
            set { _Termloan = value; }
        }

        public string CurrentClaim
        {
            get { return _CurrentClaim; }
            set { _CurrentClaim = value; }
        }

        public string createdby
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

        public string updatedBY
        {
            get { return _updatedBY; }
            set { _updatedBY = value; }
        }
    }

    public class LandCostSubsidy
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }
        public string DateofEstablishmentofUnit { get; set; }
        public string UtilizationETPCETP { get; set; }
        public string TexttileLocationTS { get; set; }
        public string LandAllotmentInformation { get; set; }
        public string TotalExtentOfLandPurchased { get; set; }
        public string TotalPlinthArea { get; set; }
        public string RatePerAcre { get; set; }
        public string TotalInvestmentinLand { get; set; }
        public string AmountAvailed { get; set; }
        public string Source { get; set; }
        public string DateAvailed { get; set; }
        public string CurrentClaim { get; set; }
    }
    public class ConcessionSGST
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string GSTIdentificationNumber { get; set; }
        public string DateofEstablishmentofUnit { get; set; }
        public string Installedcapacity { get; set; }
        public string Year1 { get; set; }
        public string Enterprises1 { get; set; }
        public string TotalProduction1 { get; set; }
        public string Year2 { get; set; }
        public string Enterprises2 { get; set; }
        public string TotalProduction2 { get; set; }
        public string Year3 { get; set; }
        public string Enterprises3 { get; set; }
        public string TotalProduction3 { get; set; }
        public string ClaimApplicationsubmitted { get; set; }
        public string Taxpaid { get; set; }
        public string CurrentClaimAmountRs { get; set; }
        public string MoratoriumFrom { get; set; }
        public string MoratoriumTo { get; set; }
        public string MoratoriumInvestmentAmount { get; set; }

        public string TaxPaid1 { get; set; }
        public string TaxPaid2 { get; set; }
        public string TaxPaid3 { get; set; }
    }
    public class ProductDevelopment
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string DesignDeveloped { get; set; }
        public string ExpenditureIncurred { get; set; }
        public string EarlierClaimsMade { get; set; }
        public string EarlierCliamYear { get; set; }
        public string amountclaimed { get; set; }
        public string CurrentClaim { get; set; }
    }
    public class AssistanceAcquisition
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string NewTechnologyDeveloped { get; set; }
        public string IstheTechnologyImported { get; set; }
        public string Valueadditionnewtechnology { get; set; }
        public string CostIncurredinDevelopment { get; set; }
        public string CurrentClaim { get; set; }
        public string Benefitavailed { get; set; }
        public string Newtechnologydevelopedadaptation { get; set; }
        public string RDDetails { get; set; }
    }

    public class AssistanceEnergy
    {
        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }
        public string DateofEstablishmentofUnit { get; set; }
        public string CommercialProduction { get; set; }
        public string TypeofInfrastructure { get; set; }
        public string AssistanceRequired { get; set; }
        public string EnergyAuditDateofAudit { get; set; }
        public string EnergyAuditNameofAuditorAuditFirm { get; set; }
        public string EnergyAuditCostIncurred { get; set; }
        public string EnergyAuditInvoiceNumber { get; set; }
        public string EnergyAuditDateofInvoice { get; set; }
        public string WaterDateofAudit { get; set; }
        public string WaterNameofAuditorAuditFirm { get; set; }
        public string WaterCostIncurred { get; set; }
        public string WaterInvoiceNumber { get; set; }
        public string WaterDateofInvoice { get; set; }
        public string EnvironmentalComplianceDateofAudit { get; set; }
        public string NameofCompliance { get; set; }
        public string CertifyingAgency { get; set; }
        public string EnvironmentalComplianceCostIncurred { get; set; }
        public string EnvironmentalComplianceInvoiceNumber { get; set; }
        public string EnvironmentalComplianceDateofInvoice { get; set; }
        public string DateofLastClaim { get; set; }
        public string NatureofExpenses { get; set; }
        public string ClaimAmount { get; set; }
        public string ReimbursementReceived { get; set; }
        public string GovernmentAmountAvailed { get; set; }
        public string GovernmentDateAvailed { get; set; }
        public string CurrentClaimEnergyAudit { get; set; }
        public string CurrentClaimWaterAudit { get; set; }
        public string CurrentClaimEnvironmentalCompliance { get; set; }
    }

    public class TransportSubsidy
    {

        public string IncentiveId { get; set; }
        public string CreatedBy { get; set; }

        public string DateofEstablishmentofUnit { get; set; }
        public string NatureofBusiness { get; set; }
        public string TotalRevenue { get; set; }
        public string NearestAirport { get; set; }
        public string NearestSeaport { get; set; }
        public string NearestDryPort { get; set; }
        public string TypeofExport { get; set; }
        public string ModeofTransport { get; set; }
        public string DetailsRawMaterialsImported { get; set; }
        public string DetailsFinishedProducts { get; set; }
        public string FinishedProductsExported { get; set; }
        public string CurrentClaim { get; set; }
        public string ExportRevenue { get; set; }
    }
    public class PlantandMachineryGrossBlock
    {
        public int GBId { get; set; }
        public int IncentiveID { get; set; }
        public string AttachmentId2 { get; set; }

        public string AuditedBalanceSheetYear { get; set; }
        public string AmountGrossBlock { get; set; }
        public string CertifiedBy { get; set; }
        public string CertifiedDate { get; set; }

        public string TransType { get; set; }
        public string Created_by { get; set; }
    }
    public class PMPaymentProofs
    {
        public int PMPFId { get; set; }
        public int IncentiveID { get; set; }
        public int PMId { get; set; }
        public int PMTMId { get; set; }
        public int PMRegTrnsactionID { get; set; }
        public string PMTrnsactionID { get; set; }
        public string TrnsactionDate { get; set; }
        public string Remittingbank { get; set; }
        public string Beneficiarybank { get; set; }
        public string TrnsactionAmount { get; set; }
        public string PMTrnsactionMachinaryCost { get; set; }
        public string AttachmentId { get; set; }
        public string TransType { get; set; }
        public string Industry_Type { get; set; }
        public string Created_by { get; set; }
    }
    public class PlantandMachinery
    {
        public int PMId { get; set; }
        public int IncentiveID { get; set; }
        public string MachineName { get; set; }
        public string VendorName { get; set; }
        public int TypeofMachineId { get; set; }
        public string InstalledMachinery { get; set; }
        public string InstalledMachinerytype { get; set; }
        public string ManufacturerName { get; set; }
        public string InvoiceNo { get; set; }
        public string MachineLandingDate { get; set; }
        public string VaivleNo { get; set; }
        public string VaivleDate { get; set; }
        public string IntiationDate { get; set; }
        public decimal MachineCost { get; set; }
        public decimal ForeignMachineCost { get; set; }
        public string ForeignCurrency { get; set; }
        public int EligilbiltyId { get; set; }
        public string CustomCountry { get; set; }
        public decimal CustomPaid { get; set; }

        public decimal Importduty { get; set; }
        public decimal portcharges { get; set; }
        public decimal statutorytaxes { get; set; }
        public string MachinaryParts { get; set; }

        public string InvoiceDate { get; set; }

        public string AttachmentId2 { get; set; }
        public string ClassificationMachinery { get; set; }
        public decimal ActualMachineCost { get; set; }
        public decimal FreightCharges { get; set; }
        public decimal TransportCharges { get; set; }
        public decimal Cgst { get; set; }
        public decimal Sgst { get; set; }
        public decimal Igst { get; set; }
        public string Remarks { get; set; }
    }

    public class CapitalAssistanceforNewUnit
    {
        public string UserId { get; set; }
        public int IncentiveID { get; set; }
        public string TypeofUnit { get; set; }
        public decimal PurchasedLandExtent { get; set; }
        public decimal PurchasedLandValue { get; set; }
        public decimal LeasedLandExtent { get; set; }
        public decimal LeasedLandValue { get; set; }
        public string Buliding_Type { get; set; }
        public decimal InheritedLandExtent { get; set; }
        public decimal InheritedLandValue { get; set; }
        public decimal GovtLandExtent { get; set; }
        public decimal GovtLandValue { get; set; }

        public decimal MainFactoryShedArea { get; set; }
        public decimal MainFactoryShedCost { get; set; }
        public decimal WarehouseArea { get; set; }
        public decimal WarehouseCost { get; set; }
        public decimal OfficeRoomArea { get; set; }
        public decimal OfficeRoomCost { get; set; }
        public decimal CoolingPondsArea { get; set; }
        public decimal CoolingPondsCost { get; set; }
        public decimal BoilerShedArea { get; set; }
        public decimal BoilerShedCost { get; set; }
        public decimal EffluentPondsArea { get; set; }
        public decimal EffluentPondsCost { get; set; }
        public decimal OverHeadTankArea { get; set; }
        public decimal OverHeadTankCost { get; set; }
        public decimal FencingArea { get; set; }
        public decimal FencingCost { get; set; }
        public decimal ArchitectFeeArea { get; set; }
        public decimal ArchitectFeeCost { get; set; }
        public decimal CompoundWallArea { get; set; }
        public decimal CompoundWallCost { get; set; }
        public decimal WorksersHouseArea { get; set; }
        public decimal WorkersHouseCost { get; set; }
        public decimal CanteenArea { get; set; }
        public decimal CanteenCost { get; set; }
        public decimal RestHouseArea { get; set; }
        public decimal RestHouseCost { get; set; }
        public decimal TimeOfficeArea { get; set; }
        public decimal TimeOfficeCost { get; set; }
        public decimal VehicleStandArea { get; set; }
        public decimal VehicleStandCost { get; set; }
        public decimal SecurityShedArea { get; set; }
        public decimal SecurityShedCost { get; set; }
        public decimal ToiletArea { get; set; }
        public decimal ToiletCost { get; set; }
        public decimal RoadsArea { get; set; }
        public decimal RoadsCost { get; set; }
        public string Documentsevidencing { get; set; }
        public string Detailedproject { get; set; }
        public string ApprovalofProject { get; set; }
        public string ProjectCompletion { get; set; }
        public string Declarationstating { get; set; }
        public string linedepartment { get; set; }
        public string CurrentClaimAmount { get; set; }

        public string LaboratoriesforResearchQualityControl { get; set; }
        public string UtilitiesPowerWater { get; set; }
        public string OtherFixedAssets { get; set; }
        public string Total { get; set; }
        public string AmountAvailed { get; set; }
        public string SanctionOrderNo { get; set; }
        public string DateAvailed { get; set; }
        public string NewTechnologiesfortextileprocessing { get; set; }
        public string SavingFrom { get; set; }
    }

    public class TermLoanAvaied
    {
        public int ISId { get; set; }
        public int IncentiveId { get; set; }
        public int SubIncentiveId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string IFSCode { get; set; }
        public string LoanAccNo { get; set; }
        public string SanctionOrderNo { get; set; }
        public string SanctionOrderDate { get; set; }
        public string SanctionedAmount { get; set; }
        public string ReleasedDate { get; set; }
        public string TransType { get; set; }
        public string Created_by { get; set; }

    }
    public class TermLoanRepaid
    {
        public int TLRId { get; set; }
        public int IncentiveId { get; set; }
        public int SubIncentiveId { get; set; }
        public string FinYear { get; set; }
        public string HalfFinYear { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public decimal PrincipalAmt { get; set; }
        public decimal RateOfInterest { get; set; }
        public decimal InterestAmt { get; set; }
        public string PaymentDate { get; set; }
        public string TransType { get; set; }
        public string Created_by { get; set; }

        public string TermLoanNo { get; set; }
        public string AccountNo { get; set; }
        public decimal OpeningBalanceStartofHalfYear { get; set; }
        public decimal ClosingBalanceEndofHalfYear { get; set; }
        public int TermLoanNoId { get; set; }
        
    }
    public class TotalTermLoanRepaid
    {
        public int TTLRId { get; set; }
        public int IncentiveId { get; set; }
        public int SubIncentiveId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string TotalNoofInstallments { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal TotalAmountRepaid { get; set; }
        public string TransType { get; set; }
        public string Created_by { get; set; }
    }
    public class InterestSubsidy1
    {
        public int IncentiveId { get; set; }
        public int SubIncentiveId { get; set; }
        public string CCP_From { get; set; }
        public string CCP_To { get; set; }
        public int CCP_Type { get; set; }
        public decimal CCA { get; set; }
        public string AmountAvailed { get; set; }
        public string SanctionOrderNo { get; set; }
        public string DateAvailed { get; set; }
        public int IsMoratorium { get; set; }
        public int IsOtherAgency { get; set; }
    }

    public class FormVIStampDutyVo
    {
        public string IncentiveId { get; set; }
        public string NatureofAsset { get; set; }
        public string LandPurchased_Sqmtrs { get; set; }
        public string LandPurchasedCostPersqmtrs { get; set; }
        public string PlinthAreaBuilding { get; set; }
        public string PlinthAreaofFactoryFiveTmes { get; set; }
        public string Arearequiredappraisal { get; set; }
        public string ArearequiredTSPCB { get; set; }
        public string NatureofTransaction { get; set; }
        public string DateofRegistration { get; set; }
        public string SubRegistrarOffice { get; set; }
        public string StampDuty_TransferDuty_Paid { get; set; }
        public string MortgageHypothecationDutyPaid { get; set; }
        public string StampDutyExemptionAvailed { get; set; }
        public string Termloan { get; set; }
        public string CurrentClaimStampDutyTransferDuty { get; set; }
        public string CurrentClaimMortgageHypothecationDuty { get; set; }
        public string CreatedBy { get; set; }
        public string AmountAvailed { get; set; }
        public string SanctionOrderNo { get; set; }
        public string DateAvailed { get; set; }
        public string LineofActivity { get; set; }
    }
    public class InspectionPlantandMachinary
    {
        public string PMID { get; set; }
        public string IncentiveId { get; set; }
        public string MachineAvailability { get; set; }
        public string Remarks { get; set; }
        public string MachineCost { get; set; }
    }
    public class InspectionEquipment
    {
        public string EquipmentId { get; set; }
        public string EquipmentAvailability { get; set; }
        public string IncentiveId { get; set; }
        public string EquipmentName { get; set; }
        public string Remarks { get; set; }
        public string EquipmentCost { get; set; }
        public string Category { get; set; }
    }
    public class InspectionBuildingDetails
    {
        public string BuildingId { get; set; }
        public string CivilWorkName { get; set; }
        public string PlinthArea { get; set; }
        public string DLOPlinthArea { get; set; }
        public string ActualValue { get; set; }
        public string DLOValue { get; set; }
        public string DLORemarks { get; set; }
        public string PurchasedLandValueDLO { get; set; }
        public string DLOLandPerAcreValue { get; set; }
        public string DLOSqmterValue { get; set; }
        public string DLORecommendedLandExtent { get; set; }

        public string ApprovedLandValue { get; set; }
        public string InvestedLandValue { get; set; }
        public string ApprovedBuildingValue { get; set; }
        public string InvestedBuildingValue { get; set; }
        public string ApprovedPMValue { get; set; }
        public string InvestedPMValue { get; set; }
        public string OthersCost { get; set; }
        public string IncentiveId { get; set; }

    }
    public class InspectionInterestSubsidy
    {
        public string AdditionalinformationId { get; set; }
        public string IncentiveId { get; set; }
        public string ActualEligibleInterest { get; set; }
        public string Remarks { get; set; }
        public string DLORecommendedEligibleInterest { get; set; }
    }
    public class InspectionAttachments
    {
        public string Category { get; set; }
        public string AttachmentId { get; set; }
        public string AttachmentName { get; set; }
        public string MstIncentiveId { get; set; }
        public string VerifyStatus { get; set; }
        public string IncentiveId { get; set; }
        public string SubIncentiveId { get; set; }
        public string Verifieddt { get; set; }
    }
    

    public class AttachmentsQueries
    {
        public string MainQueryID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string SubIncentiveID { get; set; }
        public string AttachmentId { get; set; }
        public string Created_by { get; set; }
        public string Remarks { get; set; }
        public string ActionTaken { get; set; }
        public string CAFFlag { get; set; }
        
    }
    public class AttachmentsQueriesParent
    {
        public string MainQueryID { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string Created_by { get; set; }
        public string xml { get; set; }

    }
    public class ApplicationStatus
    {
        public string QueryId { get; set; }
        public string IncentiveId { get; set; }
        public string SubIncentiveId { get; set; }
        public string IndustryPersonName { get; set; }
        public string SystemRecommended { get; set; }
        public string InspectionDate { get; set; }
        public string ProposedDLCDate { get; set; }
        public string DLCNo { get; set; }
        public string FilePath { get; set; }
        public string SanctionedLetterFilePath { get; set; }
        public string ApproveStatus { get; set; }
        public string Remarks { get; set; }
        public string RecommendedAmount { get; set; }
        public string AttachmentId { get; set; }
        public string AttachmentUploadedID { get; set; }
        public string TransType { get; set; }
        public string CreatedBy { get; set; }

        public string CapitalSubsidyAmount { get; set; }
        public string AdditionalCapitalSubsidyAmount { get; set; }

        public string SystemCapitalSubsidyAmount { get; set; }
        public string SystemAdditionalCapitalSubsidyAmount { get; set; }

        public string Actual_CapitalSubsidyAmount { get; set; }
        public string Actual_AdditionalCapitalSubsidyAmount { get; set; }
                      
        public string Actual_SystemCapitalSubsidyAmount { get; set; }
        public string Actual_SystemAdditionalCapitalSubsidyAmount { get; set; }
        public string Actual_RecommendedAmount { get; set; }
        public string Actual_SystemRecommended { get; set; }
        public string Ins_Flag { get; set; }
        public string Ins_Category { get; set; }
        public string Ins_TypeOfTextile { get; set; }
        public string JDRecommendedAmount { get; set; }
        public string PartialSanction { get; set; }
        public string PartialRemarks { get; set; }
        public string TISId { get; set; }


        public string PMXml { get; set; }
        public string InterestXml { get; set; }
        public string AttachmentXml { get; set; }
        public string BuildingXml { get; set; }
        public string EquipmentXml { get; set; }

        public string QueryLetterID { get; set; }
        public string ReInspectionDate { get; set; }
        public string IndustryDeptFlag { get; set; }
        public string IndustryDeptPersonName { get; set; }
        public string IndustryDeptRemarks { get; set; }
        public string IndustryDeptReportStatus { get; set; }

        public string TextileSanctionedAmount { get; set; }
        public string IndustriesSanctionedAmount { get; set; }
        public string DLOManualRecommendAmount { get; set; }
        public string DLOCalculatedLandAmount { get; set; }
        public string DLOCalculatedBuildingAmount { get; set; }
        public string DLOCalculatedPMAmount { get; set; }
        public string DLOCalculatedOthersAmount { get; set; }
        public string DLOLandPerAcreValue { get; set; }
        public string DLOLandPerAcreRemarks { get; set; }
        public string DLORecommendedLandExtent { get; set; }
        public string OfficerId { get; set; }
        public string Status { get; set; }
        public string QueryReason { get; set; }
        public string GMRecommendedAmount { get; set; }

    }

    public class ReleaseProceedingStatus
    {
        public string IncentiveId { get; set; }
        public string SubIncentiveId { get; set; }

        public string ReleaseProcedingDate { get; set; }
        public string ReleaseProcedingNo { get; set; }
        public string FilePath { get; set; }
        public string ReleasedAmount { get; set; }
        public string RemainingAmount { get; set; }
        public string TransType { get; set; }
        public string CreatedBy { get; set; }
        public string GOID { get; set; }
        public string ReleaseFlag { get; set; }

    }
    public class RTGSNEFTPayment
    {
        public string IncentiveID { get; set; }
        public string TTAPBillerID { get; set; }
        public string PaymentMode { get; set; }
        public string UTRNo { get; set; }
        public string DateofRemittance { get; set; }
        public string ACTUALAMOUNT { get; set; }
        public string Amount { get; set; }
        public string NameoftheBank { get; set; }
        public string Branch { get; set; }
        public string CreatedBy { get; set; }
        public string ApplicationNumber { get; set; }
        public string PGRefNo { get; set; }
        public string ApplicationFee { get; set; }
        public string Tax_Amount { get; set; }
        public string Total_Amount { get; set; }
    }
    public class OnlinePaymentDtls
    {
        public string ApplicationNumber { get; set; }
        public string IncentiveID { get; set; }
        public string SubIncentiveID { get; set; }
        public string TTAPBillerID { get; set; }
        public string PaymentMode { get; set; }
        public string ApplicationFee { get; set; }
        public string Tax_Amount { get; set; }
        public string Total_Amount { get; set; }
        public string CreatedBy { get; set; }
        public string PGRefNo { get; set; }
    }
    public class DeptPaymentApprovalStatus
    {
        public string IncentiveID { get; set; }
        public string OnlineOrderNumber { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }

    public class paymentresponseVOs
    {
        public string MerchantID_0
        {
            get;
            set;
        }
        public string CustomerID_1
        {
            get;
            set;
        }
        public string TxnReferenceNo_2
        {
            get;
            set;
        }
        public string BankReferenceNo_3
        {
            get;
            set;
        }
        public string TxnAmount_4
        {
            get;
            set;
        }
        public string BankID_5
        {
            get;
            set;
        }
        public string BIN_6
        {
            get;
            set;
        }
        public string TxnType_7
        {
            get;
            set;
        }
        public string CurrencyName_8
        {
            get;
            set;
        }
        public string ItemCode_9
        {
            get;
            set;
        }
        public string SecurityType_10
        {
            get;
            set;
        }
        public string SecurityID_11
        {
            get;
            set;
        }
        public string SecurityPassword_12
        {
            get;
            set;
        }
        public string TxnDate_13
        {
            get;
            set;
        }
        public string AuthStatus_14
        {
            get;
            set;
        }
        public string SettlementType_15
        {
            get;
            set;
        }
        public string AdditionalInfo1_16
        {
            get;
            set;
        }
        public string AdditionalInfo2_17
        {
            get;
            set;
        }
        public string AdditionalInfo3_18
        {
            get;
            set;
        }
        public string AdditionalInfo4_19
        {
            get;
            set;
        }
        public string AdditionalInfo5_20
        {
            get;
            set;
        }
        public string AdditionalInfo6_21
        {
            get;
            set;
        }
        public string AdditionalInfo7_22
        {
            get;
            set;
        }
        public string ErrorStatus_23
        {
            get;
            set;
        }
        public string ErrorDescription_24
        {
            get;
            set;
        }
        public string CheckSum_25
        {
            get;
            set;
        }
        public string Createdby
        {
            get;
            set;
        }
    }

    public class GOUploads
    {
        public string GONo { get; set; }
        public string GODate { get; set; }
        public string LOCNo { get; set; }
        public string LOCDate { get; set; }
        public string AmountReleased { get; set; }
        public string GOPathID { get; set; }
        public string CreatedBy { get; set; }
        public string GOID { get; set; }
        public string TransType { get; set; }
        public string Remarks { get; set; }
    }
    public class SMS
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string message { get; set; }
        public string phoneNo { get; set; }
        public string Client_ID { get; set; }
        public string unicode { get; set; }
    }
    public class QueryGenerationVo
    {
        public string MainQueryID { get; set; }
        public string QueryId { get; set; }
        public string TransType { get; set; }
        public string IncentiveId { get; set; }
        public string SubIncentiveID { get; set; }
        public string Query { get; set; }
        public string Transfered { get; set; }
        public string Created_by { get; set; }
    }

    public class paymendepartwisetresponseVOs
    {
        public string Questionnaireid
        {
            get;
            set;
        }
        public string intApprovalid
        {
            get;
            set;
        }
        public string intEnterprenerid
        {
            get;
            set;
        }
        public string Departmentid
        {
            get;
            set;
        }
        public string Createdby
        {
            get;
            set;
        }
        public string MerchantID_0
        {
            get;
            set;
        }
        public string DeptAmount
        {
            get;
            set;
        }
        public string CustomerID_1
        {
            get;
            set;
        }
        public string TxnReferenceNo_2
        {
            get;
            set;
        }
        public string BankReferenceNo_3
        {
            get;
            set;
        }
        public string TxnAmount_4
        {
            get;
            set;
        }
        public string BankID_5
        {
            get;
            set;
        }
        public string BIN_6
        {
            get;
            set;
        }
        public string TxnType_7
        {
            get;
            set;
        }
        public string CurrencyName_8
        {
            get;
            set;
        }
        public string ItemCode_9
        {
            get;
            set;
        }
        public string SecurityType_10
        {
            get;
            set;
        }
        public string SecurityID_11
        {
            get;
            set;
        }
        public string SecurityPassword_12
        {
            get;
            set;
        }
        public string TxnDate_13
        {
            get;
            set;
        }
        public string AuthStatus_14
        {
            get;
            set;
        }
        public string SettlementType_15
        {
            get;
            set;
        }
        public string AdditionalInfo1_16
        {
            get;
            set;
        }
        public string AdditionalInfo2_17
        {
            get;
            set;
        }
        public string AdditionalInfo3_18
        {
            get;
            set;
        }
        public string AdditionalInfo4_19
        {
            get;
            set;
        }
        public string AdditionalInfo5_20
        {
            get;
            set;
        }
        public string AdditionalInfo6_21
        {
            get;
            set;
        }
        public string AdditionalInfo7_22
        {
            get;
            set;
        }
        public string ErrorStatus_23
        {
            get;
            set;
        }
        public string ErrorDescription_24
        {
            get;
            set;
        }
        public string CheckSum_25
        {
            get;
            set;
        }
        public string AdditionalPaymentFlag
        {
            get;
            set;
        }

        public string HDRemarks
        {
            get;
            set;
        }
        public string HDid
        {
            get;
            set;
        }
        public string Ipaddress
        {
            get;
            set;
        }
        public string TransactionType
        {
            get;
            set;
        }
        public string DocPath
        {
            get;
            set;
        }
        public string TypeofOfflineUpdate
        {
            get;
            set;
        }
    }

    //public class SMSLogText
    //{
    //    public string OTPRefNo { get; set; }
    //    public string OTPValue { get; set; }
    //    public string SMSText { get; set; }
    //    public string UserId { get; set; }
    //    public string MobileNo { get; set; }
    //    public string SMSStatus { get; set; }
    //}

    public class ModuleVos
    {
        public int ApplicationId { get; set; }
        public int MainModule_Code { get; set; }
        public string MainModule { get; set; }
        public string SubModule { get; set; }
        public string Module_Code { get; set; }
        public string MappingID { get; set; }
        public string UserID { get; set; }
        public string TransType { get; set; }
        public string Created_by { get; set; }
    }
    public class DLOApplication
    {
        public string INCENTIVEID { get; set; }
        public string SUBINCENTIVEID { get; set; }
        public string ACTIONID { get; set; }
        public string RECOMMENDEAMOUNT { get; set; }
        public string QUERY_REMARKS { get; set; }
        public string SSCINSP_REMARKS { get; set; }
        public string ABEYANCE_REMARKS { get; set; }
        public string FORWARDTO { get; set; }
        public string RETURN_REMARKS { get; set; }
        public string CREATEDBY { get; set; }

    }
}