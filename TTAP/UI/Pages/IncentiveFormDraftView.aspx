<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="IncentiveFormDraftView.aspx.cs" Inherits="TTAP.UI.Pages.IncentiveFormDraftView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

        td.style6, td.style4 {
    border: 1px solid #000;
}
    </style>
    <div>
        <div class="container">
        <div class="row mt-4">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item active"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item">General information </li>
                </ol>
            </nav>
        </div>
            <div class="box box-success">
            <div class="box-header with-border">
                <h3 class="box-title">Section A: General information
                    <br />
                    <br />
                </h3>
            </div>
                
                <h6>1. DETAILS OF ENTERPRISE</h6>
        <table align="center" class="style1" style="border: 1px solid #000; width: 100%">
            <col width="3%" />
            <col width="15%" />
                    <col width="15%" />
                    <col width="67%" />
            
           
            <tr>
             <td class="style4">1.1</td>
                <td class="style4" colspan="2">Name of the Enterprise:
                </td>
                <td class="style4">
                    <asp:Label ID="lblNameEnterprise" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">1.2</td>
                <td class="style6" colspan="2">Country of Origin (In case of MNC):
                </td>
                <td class="style4">
                    <asp:Label ID="lblCountryofOrigin" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td rowspan="6">1.3</td>
                <td rowspan="6" class="style6">
                    <center><h6>Registered Address of Enterprise</h6></center>
                </td>
            </tr>
            <tr>
                <td class="style6">Plot No. & Area:
                </td>
                <td class="style4">
                    <asp:Label ID="lblNewPlotArea" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">City / Town / Village:
                </td>
                <td class="style4">
                    <asp:Label ID="lblNewCityTownVillage" runat="server"></asp:Label>
                </td>

            </tr>

            <tr>
                <td class="style6">District:
                </td>
                <td class="style4">
                    <asp:Label ID="lblNewDistrict" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">State :
                </td>
                <td class="style4">
                    <asp:Label ID="lblNewState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Postal Code:
                </td>
                <td class="style4">
                    <asp:Label ID="lblNewPostalCode" runat="server"></asp:Label>
                </td>

            </tr>
            
            <tr>
                <td class="style4" rowspan="6">1.4</td>
                <td rowspan="6">
                    <center><h6>Correspondence Address</h6></center>
                </td>
            </tr>
            <tr>
                <td class="style6">Plot No. & Area:
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondencePlotNoArea" runat="server"></asp:Label>
            </tr>
            <tr>
                <td class="style6">City / Town / Village:
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondenceCityTownVillage" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">District:
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondenceDistrict" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">State :
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondenceState" runat="server"></asp:Label>
            </tr>
            <tr>
                <td class="style6">Postal Code:
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondencePostalCode" runat="server"></asp:Label>
            </tr>
            <tr>
                <td class="style4">1.5</td>
                <td class="style6" colspan="2">Phone Number :
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondencePhoneNumber" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td />
                <td class="style6" colspan="2">Type of the Product :
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondenceTypeoftheProduct" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td />
                <td class="style6" colspan="2">Textile Process Type (Ginning, Spinning, Weaving, Garmenting, etc):
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondenceTextileProcessType" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style4" >1.6</td>
                <td class="style6" colspan="2">Email Address:
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondenceEmailAddress" runat="server"></asp:Label>
                </td>

            </tr>

            <tr id="trWebsite" runat="server" visible="false">
                <td>1.7</td>
                <td class="style6" colspan="2">Website:
                </td>
                <td class="style4">
                    <asp:Label ID="lblWebsite" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style4" rowspan="3">1.8</td>
                <td rowspan="3" class="style6">
                    <center><h6>Incorporation Details</h6></center>
                </td>
            </tr>
            <tr>
                <td class="style6">Date of Incorporation:
                </td>
                
                <td class="style4">
                    <asp:Label ID="lblDateofIncorporation" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Incorporation / Registration Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblIncorporationRegistrationNumber" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">1.9</td>
                <td class="style6" colspan="2">GST Registration Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblNewGSTRegistrationNumber" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style4">1.10</td>
                <td class="style6" colspan="2">PAN and  TAN Number :
                </td>
                <td class="style4">
                    <asp:Label ID="lblNewPANandTANNumber" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style4">1.11</td>
                <td colspan="2" class="style4">Constitution of Organisation:</td>
                <td class="style4">
                    <asp:Label ID="lblNewConstitution" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">1.12</td>
                <td colspan="2">Social Status:</td>
                <td class="style4">
                    <asp:Label ID="lblNewSocialStatus" runat="server"></asp:Label>
                </td>
            </tr>

        </table>
                <br />
                <br />
                2. DETAILS OF ENTREPRENEUR
        <table align="center" class="style1" style="border: thin solid #008080; width: 100%">
            <col width="3%" />
            <col width="15%" />
                    <col width="15%" />
                    <col width="67%" />
            <tr id="trSalutation" runat="server" visible="false">

                <td>Name of the Proprietor / Managing Partner :</td>
                <td>
                    <asp:CheckBox ID="Mr" Text="Mr" runat="server" /><br />
                    <asp:CheckBox ID="Mrs" Text="Mrs" runat="server" /><br />
                    <asp:CheckBox ID="Ms" Text="Ms" runat="server" /><br />
                    <asp:CheckBox ID="Dr" Text="Dr" runat="server" /></td>
            </tr>
            
            
            <tr>
                <td class="style6">2.1</td>
                <td class="style6" colspan="2">Name:
                </td>
                <td class="style4">
                    <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr id="trMiddleName" runat="server" visible="false">
                <td class="style6">Middle Name:
                </td>
                <td class="style4">
                    <asp:Label ID="lblMiddleName" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr id="trLastName" runat="server" visible="false">
                <td class="style6">Last Name:
                </td>
                <td class="style4">
                    <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td rowspan="6" class="style6">2.2</td>
                <td rowspan="6" class="style4">
                    <center><h6>Contact Details of Proprietor / Managing Partner / Managing Director</h6></center>
                </td>
            </tr>
            <tr>
                <td class="style6">Designation & Company:
                </td>
                <td class="style4">
                    <asp:Label ID="lblDesignationCompany" runat="server" Text=""></asp:Label>
                </td>

            </tr>

            <tr>
                <td class="style6">Address:
                </td>
                <td class="style4">
                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Phone Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Mobile Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblMobileNumber" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">Email Address :
                </td>
                <td class="style4">
                    <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td />
                <td class="style6">Educational Qualification :
                </td>
                <td />
                <td class="style4">
                    <asp:Label ID="lblEducationalQualification" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td />
                <td class="style6">No of Years of Experience in Textiles :
                </td>
                <td />
                <td class="style4">
                    <asp:Label ID="lblExperienceTextiles" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr id="trlblPANDINNumber" runat="server" visible="false">
               <td class="style6">2.3</td>
                <td class="style6" colspan="2">PAN and DIN Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblPANDINNumber" runat="server" Text=""></asp:Label>
                </td>

            </tr>
        </table>



                <br />
                <br />
                <h6>3. AUTHORISED SIGNATORY / CONTACT PERSON DETAILS</h6>
        <table style="width: 100%">
            <col width="3%" />
            
                    <col width="15%" />
                    <col width="82%" />
            <tr id="trSalutation2" runat="server" visible="false">
                <td>Name :</td>
                <td>
                    <asp:CheckBox ID="Mr1" Text="Mr" runat="server" /><br />
                    <asp:CheckBox ID="Mrs1" Text="Mrs" runat="server" /><br />
                    <asp:CheckBox ID="Ms1" Text="Ms" runat="server" /><br />
                    <asp:CheckBox ID="Dr1" Text="Dr" runat="server" /></td>
            </tr>
            <tr>
               <td class="style6">3.1</td>
                <td class="style6">First Name:
                </td>
                <td class="style4">
                    <asp:Label ID="lblFirstName2" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr id="trMiddleName2" runat="server" visible="false">
                <td class="style6">Middle Name:
                </td>
                <td class="style4">
                    <asp:Label ID="MiddleName2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr id="trLastName2" runat="server" visible="false">
                <td class="style6">Last Name:
                </td>
                <td class="style4">
                    <asp:Label ID="lblLastName2" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                        ControlToValidate="LastName1" ErrorMessage="!!" ForeColor="Red"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">3.2</td>
                <td class="style6">Designation and Company:
                </td>
                <td class="style4">
                    <asp:Label ID="lblDesignationCompany2" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">3.3</td>
                <td class="style6">Correspondence Address :
                </td>
                <td class="style4">
                    <asp:Label ID="lblCorrespondenceAddress" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">3.4</td>
                <td class="style6">Phone Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblPhoneNumbe2" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">3.5</td>
                <td class="style6">Email Address:
                </td>
                <td class="style4">
                    <asp:Label ID="lblEmailAddress2" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style6">3.6</td>
                <td class="style6">PAN Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblPANNumber2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
                <br />
                <br />
                <h6>4 BACKGROUND OF THE ENTERPRISE / PROMOTER</h6>
        <table style="width: 100%">
            <col width="3%" />
            <col width="15%" />
                    <col width="15%" />

            <col width="20%" />
            <col width="20%" />
                    <col width="27%" />
            <tr>
                <td class="style4">4.1</td>
                <td class="style6" colspan="2">Year of Establishment:
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblYearofEstablishment" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style4">4.2</td>
                <td class="style6" colspan="2">Number of Employees (on Rolls and Contract):
                </td>
               <td class="style4" colspan="3">
                    <asp:Label ID="lblNumberofEmployees" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                 <td class="style4">4.3</td>
                <td class="style6" colspan="2">Products Manufactured :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblProductsManufactured" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                 <td class="style4">4.4</td>
                <td class="style6" colspan="2">Number of Other Existing Establishments with Location :
                </td>
               <td class="style4" colspan="3">
                    <asp:Label ID="lblExistingEstablishments" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                 <td class="style4">4.5</td>
                <td class="style6">Financial Indicator</td>
                <td class="style6">(Last 3 years in Rs Crores) :
                </td>
                <td class="style4">
                    <asp:Label ID="Year1" runat="server" Text="Year1"></asp:Label>
                    </td>
                <td class="style4">
                    <asp:Label ID="Year2" runat="server" Text="Year2"></asp:Label>
                    </td>
                <td class="style4">
                    <asp:Label ID="Year3" runat="server" Text="Year3"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4"/>
                <td class="style4"/>
              
                <td class="style6">Turnover:</td>
                <td class="style6" />
                   <td class="style6" />
                <td class="style4"> <asp:Label ID="lblTurnover" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="style4"/>
                <td class="style4"/>
                <td class="style6">EBITDA:
                </td>
                <td class="style6" />
                   <td class="style6" />
               <td 
                   class="style4"/>
                    <asp:Label ID="lblEBITDA" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
              <td class="style4"/>
                <td class="style4"/>
                <td class="style6">Networth:
                </td>
                <td class="style6" />
                   <td class="style6" />
                <td  class="style4"/>
                    <asp:Label ID="lblNetworth" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4"/>
                <td class="style4"/>
                <td class="style6">Reserves & Surplus:
                </td>
                <td class="style6" />
                   <td class="style6" />
                <td class="style4">
                    <asp:Label ID="lblReservesSurplus" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4"/>
                <td class="style4"/>
                <td class="style6">Share Capital:
                </td>
                <td class="style6" />
                   <td class="style6" />
                <td class="style4">
                    <asp:Label ID="lblShareCapital" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
                <br />
                <br />
                <h6>5. DETAILS OF NEW UNIT</h6>
        <table style="width: 100%">
          <col width="3%" />
            <col width="15%" />
                    <col width="15%" />
                    <col width="67%" />
            <tr>
                 <td class="style6" rowspan="6">5.1 </td>
                <td rowspan="6" class="style6">
                    <center><h6>Location of New Unit</h6></center>
                </td>
            </tr>
            <tr>
                <td class="style6">Plot No. & Area:
                </td>
                <td class="style4">
                    <asp:Label ID="lblPlotArea" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">City / Town / Village:
                </td>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">District:
                </td>
                <td class="style4">
                    <asp:Label ID="lblDistrict" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">State:
                </td>
                <td class="style4">
                    <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Postal Code:
                </td>
                <td class="style4">
                    <asp:Label ID="lblPostalCode" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">5.2</td>
                <td class="style6" colspan="2">Nature of Industry:
                </td>
                <td class="style4">
                    <asp:Label ID="lblNatureIndustry" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">5.3</td>
                <td class="style6" colspan="2">Products:
                </td>
                <td class="style4">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr id="trInstalledCapacity" runat="server" visible="false">
                <td class="style4">5.4</td>
                <td>Installed Capacity/Annum:</td>
                <td>
                    <asp:CheckBox ID="MetricTons" Text="MetricTons" runat="server" /><br />
                    <asp:CheckBox ID="Kilolitres" Text="Kilolitres" runat="server" /><br />
                    <asp:CheckBox ID="Numbers" Text="Numbers" runat="server" /><br />
                    <asp:CheckBox ID="CubicMetres" Text="CubicMetres" runat="server" /><br />
                    <asp:CheckBox ID="OthersSpecify" Text="OthersSpecify" runat="server" /></td>
            </tr>
            <tr runat="server" visible="false">
                <td class="style6">Capacity:
                </td>
                <td class="style4">
                    <asp:Label ID="lblCapacity" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td class="style6">Commencement of Commercial Production:
                </td>
                <td class="style4">
                    <asp:Label ID="lblCommercialProduction" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr id="trEIN" runat="server" visible="false">
                <td colspan="2">
                    <center><h3> EIN / IEM / IL</h3></center>
                </td>
            </tr>

            <tr id="trDate" runat="server" visible="false">
                <td class="style6">Date:
                </td>
                <td class="style4">
                    <asp:Label ID="Date" runat="server" Text="Date"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server"
                        ControlToValidate="Date" ErrorMessage="!!" ForeColor="Red"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trNumber" runat="server" visible="false">
                <td class="style6">Number:
                </td>
                <td class="style4">
                    <asp:Label ID="Number" runat="server" Text="Number"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server"
                        ControlToValidate="Number" ErrorMessage="!!" ForeColor="Red"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                 <td class="style4" >5.6</td>
                <td class="style6" colspan="2">GST Registration Number:
                </td>
                <td class="style4">
                    <asp:Label ID="lblGSTRegistrationNumber" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" >5.7</td>
                <td class="style6" colspan="2">Social Status:
                </td>
                <td class="style4">
                    <asp:Label ID="lblSocialStatus" runat="server" Text=""></asp:Label>
                </td>
            </tr>

        </table>
                <br />
                <br />
                <h6>6. FIXED INVESTMENT IN NEW UNIT:</h6>
        <table style="width: 100%">
          <col width="3%" />
            <col width="37%" />
                    <col width="15%" />
            <col width="15%" />
                    <col width="30%" />
            <tr>
                <td class="style4" rowspan="4">6.1</td>
                <td  colspan="4" class="style6">
                    <left><h6> Land:</h6></left>
                </td>
                
            </tr>
            
            <tr>
                <td class="style6">Five times Plinth area of the Factory Building Constructed(In Acres)
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblFactoryBuildingConstructed" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Rate per Acre (In Rupees) :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblNewRateperAcre" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6" >Total Investment in Land:
                </td>
                <td class="style6" colspan="3">
                    <asp:Label ID="lblNewTotalInvestmentLand" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr id="trallotted" runat="server" visible="false">
                <td class="auto-style2" colspan="2">
                    <center><h3> Whether allotted by the Government</h3></center>
                </td>
            </tr>
            <tr>
                <td class="style4" rowspan="5">6.2</td>
                <td class="style4">Building</td>
                <td class="style4">Built up Area (In Sq.ft.)</td>
                <td class="style4">Rate per Sq.ft.(In Rupees)</td>
                <td class="style4">Total(In Rupees)</td>
            </tr>
            <tr>
                <td class="style4">Factory Building</td>
                <td class="style4">
                    <asp:Label ID="lblBuildipArea1" runat="server" /></td>
                <td class="style4">
                    <asp:Label ID="lblBuildipArea2" runat="server" /></td>
                    <td class="style4">
                    <asp:Label ID="lblBuildipArea3" runat="server" /></td>
            </tr>
            <tr>
                       <td class="style4">Infrastructure (Other than Land & Land Development)</td>
                       <td class="style4">
                    <asp:Label ID="lblInfrastructure1" runat="server" /></td>
                <td class="style4">
                    <asp:Label ID="lblInfrastructure2" runat="server" /></td>
                  <td class="style4">
                    <asp:Label ID="lblInfrastructure3" runat="server" /></td>
            </tr>
            <tr>
                       <td class="style4">Other Productive Assets (Specify) </td>
                       <td class="style4">
                    <asp:Label ID="lblOtherProductive1" runat="server" /></td>
                       <td class="style4">
                    <asp:Label ID="lblOtherProductive2" runat="server" /></td>
                       <td class="style4">
                    <asp:Label ID="lblOtherProductive3" runat="server" /></td>
            </tr>
            <tr>
                <td class="style6">Total Investment in Building (In Rupees):
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblTotalInvestmentBuilding" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" rowspan="7">6.3</td>
                <td class="style4">
                    <left> <h6> <b>Plant and Machinery</b></h6></left>
                </td>
                <td class="style4" colspan="3"><center><b>Amount in Rupes</b></center></td>
            </tr>
            <tr>
                <td class="style6">Plant and machinery and other Productive Assets:
                </td>
               <td class="style4" colspan="3">
                    <asp:Label ID="lblPlantmachinery" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Transportation :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblTransportation" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Erection :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblErection" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Electrification:
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblElectrification" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Other Assets :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblOtherAssets" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Total Investment in Plant & Machinery(In Rupees) :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblTotalInvestmentPlant" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                 <td class="style4" >6.4</td>
                <td class="style6">Total Fixed Capital Investment in Land, Building and Plant & Machinery (In Rupees):
                </td>
               <td class="style4" colspan="3">
                    <asp:Label ID="lblTotalFixedCapitalInvestment" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
        </table>
                <br />
                <br />
                <h6>7. EMPLOYMENT DETAILS IN THE NEW UNIT:</h6>
        <table style="width: 100%">
          

            <table style="width: 100%">
                <col width="3%" />
            <col width="37%" />
                    <col width="15%" />
            <col width="15%" />
                    <col width="30%" />
                <tr>
                    <td class="style4" rowspan="6">7.1</td>
                    <td class="style4" >Employment Break-Up</td>
                    <td class="style4" >Female</td>
                   <td class="style4" >Male</td>
                    <td class="style4" style="display:none">Total</td>
                </tr>
                <tr>
                    <td class="style4" >Managerial</td>
                    <td class="style4" >
                        <asp:Label ID="lblMale1" runat="server" /></td>
                    <td class="style4" >
                        <asp:Label ID="lblfemale1" runat="server" /></td>
                   <td class="style4" style="display:none">
                        <asp:Label ID="lblTotal1" runat="server"/></td>
                </tr>
                <tr>
                    <td class="style4" >Supervisory  </td>
                    <td class="style4" >
                        <asp:Label ID="lblMale2" runat="server" /></td>
                   <td class="style4" >
                        <asp:Label ID="lblfemale2" runat="server" /></td>
                    <td class="style4" style="display:none" >
                        <asp:Label ID="lblTotal2" runat="server" /></td>
                </tr>
                <tr>
                    <td class="style4" >Skilled</td>
                    <td class="style4" >
                        <asp:Label ID="lblMale3" runat="server" /></td>
                    <td class="style4" >
                        <asp:Label ID="lblfemale3" runat="server" /></td>
                   <td class="style4" style="display:none" >
                        <asp:Label ID="lblTotal3" runat="server" /></td>
                </tr>
                <tr>
                    <td class="style4" >Unskilled</td>
                    <td class="style4" >
                        <asp:Label ID="lblMale4" runat="server" /></td>
                    <td class="style4" >
                        <asp:Label ID="lblfemale4" runat="server" /></td>
                   <td class="style4" style="display:none" >
                        <asp:Label ID="lblTotal4" runat="server" /></td>
                </tr>
                <tr id="trOthers" runat="server" visible="false">
                    <td class="style4" >Others</td>
                   <td class="style4" >
                        <asp:Label ID="TextBox20" runat="server" /></td>
                    <td class="style4" >
                        <asp:Label ID="TextBox21" runat="server" /></td>
                    <td class="style4" >
                        <asp:Label ID="TextBox22" runat="server" /></td>
                </tr>
                <tr id="trTotalEmployment" runat="server" visible="false">
                    <td class="style4" >7.2</td>
                    <td class="style4" >Total Employment
                    </td>
                   <td class="style4" >
                        <asp:Label ID="TextBox23" runat="server" /></td>
                   <td class="style4" >
                        <asp:Label ID="TextBox24" runat="server" /></td>
                   <td class="style4" >
                        <asp:Label ID="TextBox25" runat="server" /></td>
                </tr>
            </table>
            <br />
            <br />
            <%--<h6>8. CATEGORY OF NEW UNIT UNDER THE T-TAP POLICY:</h6>--%>
            <table id="tblCategory" runat="server" visible="false" style="width: 100%">
                <col width="10%" />
                <col width="10%" />
                <col width="80%" />
                <tr>

                    <td colspan="3"
                        style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;"></td>
                </tr>
                <tr>
                    <td>Category of New Unit as per TTAP Policy :</td>
                    <td>
                        <asp:CheckBox ID="A1" Text="A1 (Investment less than Rs 10 crores or Minimum Employment of 50)" runat="server" /><br />
                        <asp:CheckBox ID="A2" Text="A2 (Investment between Rs 10-50 crores or Minimum Employment of 200)" runat="server" /><br />
                        <asp:CheckBox ID="A3" Text="A3 (Investment between Rs 50-100 crores or Minimum Employment of 300)" runat="server" /><br />
                        <asp:CheckBox ID="A4" Text="A4 (Investment between Rs 50-100 crores or Minimum Employment of 300)" runat="server" /><br />
                        <asp:CheckBox ID="A5" Text="A5 (Investment more than Rs 200 crores or Minimum Employment of 1000))" runat="server" /></td>
                </tr>


            </table>
            <br />
            <br />
            <h6>9. PROJECT COST OF THE NEW UNIT (IN RUPEES):</h6>
            <table style="width: 100%">
                <col width="3%" />
                <col width="27%" />
                <col width="70%" />
                <tr>
                     <td class="style4" >9.1</td>
                    <td class="style6">Land and Site Development:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblLandSiteDevelopment" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >9.2</td>
                    <td class="style6">Building:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblBuilding" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >9.3</td>
                    <td class="style6">Plant and Machinery :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblPlantMachinery1" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >9.4</td>
                    <td class="style6">Working Capital Margin:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblWorkingCapitalMargin" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >9.5</td>
                    <td class="style6">Contingencies :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblContingencies" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                 
                <tr id="trProjectCostOthers" runat="server" visible="false">
                    <td class="style4" >9.6</td>
                    <td class="style6">Others:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblOthers" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>

                <tr id="trTotalProjectCost" runat="server" visible="false">
                     <td class="style4" >9.7</td>
                    <td class="style6">Total Project Cost :
                    </td>
                    <td class="style4">
                        <asp:Label ID="TotalProjectCost" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <h6>10. MEANS OF FINANCE (IN RUPEES):</h6>
            <table style="width: 100%">
                 <col width="3%" />
                <col width="27%" />
                <col width="70%" />
                <tr>
                    <td class="style4" >10.1</td>
                    <td class="style6">Promoter’s Equity:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblPromoterEquity" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >10.2</td>
                    <td class="style6">Institution Equity :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblInstitutionEquity" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >10.3</td>
                    <td class="style6">Term Loans:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblTermLoans" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >10.4</td>
                    <td class="style6">Others:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblFinanceOthers" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >10.5</td>
                    <td class="style6">Seed Capital :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblSeedCapital" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4" >10.6</td>
                    <td class="style6">Subsidy / Grants through other agencies :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblSubsidyGrants" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <h6>11. IMPLEMENTATION STEPS UNDERTAKEN FOR ESTABLISHING NEW UNIT:</h6>
            <table style="width: 100%">
                <col width="3%" />
            <col width="15%" />
                    <col width="20%" />
                    <col width="62%" />
                <tr>
                     <td class="style4" rowspan="4">11.1</td>
                    <td class="style4" rowspan="4">
                        <center><h6> Term Loan</h6> </center>
                    </td>
                </tr>
                <tr id="trAlreadyApplied" runat="server" visible="false">
                    <td>Already Applied:</td>
                    <td>
                        <asp:CheckBox ID="Yes" Text="Yes" runat="server" /><asp:CheckBox ID="No" Text="No" runat="server" /></td>
                </tr>
                <tr>
                    <td class="style6">Name of the Bank / Institution with Branch:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblNameBank" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Date of Application:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblDateofApplication" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Term Loan Sanction Date:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblTermLoanSanctionDate" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" rowspan="5">11.2</td>
                    <td class="style4" rowspan="5">
                        <center><h6> Power</h6> </center>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Release Date :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblReleaseDate" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Contracted Load (In KVA)  :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblContractedLoad" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Connected Load (In KVA)  :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblConnectedLoad" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Rate per unit in Rupees   :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblRateperunitRupees" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <td class="style4" rowspan="4">11.3</td>
                    <td class="style4" rowspan="4">
                    <center><h6>Water</h6> </center>
                </td>
                <tr>
                    <td class="style6">Source :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblSource" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Requirement (In Unit) :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblRequirement" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Rate per unit in Rupees   :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblWaterRateperunitRupees" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" rowspan="4" runat="server" visible="false">11.4</td>
                     <td id="tdClearancesHead" runat="server" visible="false" class="auto-style2" colspan="2">
                    <center><h6>Clearances and Approval Received</h6> </center>
                </td>
                    <td class="style4" />
                </tr>
               
                <tr id="tdClearancesCategory" runat="server" visible="false">
                    <td>Category of New Unit as per TTAP Policy :</td>
                    <td>
                        <asp:CheckBox ID="ApprovalDirector" Text="Approval of Director of Factorie" runat="server" /><br />
                        <asp:CheckBox ID="BoilersCertificate" Text="Boilers Certificate" runat="server" /><br />
                        <asp:CheckBox ID="ApprovalofDirector" Text="Approval  of   Director  of   Town  &  Country  Planning  / UDA" runat="server" /><br />
                        <asp:CheckBox ID="Regularbuildingplans" Text="Regular building plans approval of Municipality  or Gram Panchayat" runat="server" /><br />
                        <asp:CheckBox ID="ConsentforOperation" Text="Consent for Operation from TSPCB / Acknowledgement from the General Manager, DIC concerned" runat="server" /><br />
                        <asp:CheckBox ID="PowerreleaseCertificate" Text="Power release Certificate from TSTRANSCO/ DISCOM" runat="server" /><br />
                        <asp:CheckBox ID="EnvironmentalClearance" Text="Environmental Clearance" runat="server" /><br />
                        <asp:CheckBox ID="Otherstatutoryapprovals" Text="Other statutory approvals (specify)" runat="server" />
                    </td>
                </tr>

                <tr runat="server" visible="false">
                    <td class="style4" rowspan="2">11.5</td>
                    <td class="style6">Subsidies / Incentives availed from other Sate or Central Government Schemes</td>
                    <td class="style4">
                        <asp:Label ID="lblSubsidies" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>

                <tr id="tdIfYesAmount" runat="server" visible="false">
                    <td class="style6">Amount in Rupees   :
                    </td>
                    <td class="style4">
                        <asp:Label ID="IfYesAmount" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" >11.6</td>
                    <td class="style6" colspan="2">Name of the Scheme, Agency / Department / Ministry :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblNameoftheScheme" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>

            </table>
            <br />
            <br />
            <h6>12. DETAILS OF THE EXISTING UNIT:</h6>
            <table style="width: 100%">
              <col width="3%" />
            <col width="15%" />
                    <col width="20%" />
                    <col width="62%" />
                <tr>
                    <td class="style4" rowspan="6">12.1</td>
                    <td class="style6" rowspan="6">
                        <center><h6>Location of Existing Unit</h6> </center>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Plot No. & Area:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExistingPlotNoArea" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">City / Town / Village:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExistingCityTownVillage" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">District:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExistingDistrict" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">State :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExistingState" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Postal Code :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExistingPostalCode" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td class="style4">12.2</td>
                    <td class="style6" colspan="2">Nature of Industry of Existing Unit:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExistingNatureofIndustry" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">12.3</td>
                    <td class="style6" colspan="2">
                    Products of Existing Unit :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblProductsofExistingUnit" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <td id="tdEIN" runat="server" visible="false" class="auto-style2" colspan="2">
                    <center><h3>EIN / IEM / IL</h3> </center>
                </td>
                <tr id="trExistingDate" runat="server" visible="false">
                    <td class="style6">Date  :
                    </td>
                    <td class="style4">
                        <asp:Label ID="Date2" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr id="trExistingNumber" runat="server" visible="false">
                    <td class="style6">Number  :
                    </td>
                    <td class="style4">
                        <asp:Label ID="Number2" runat="server" Width="120px"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server"
                            ControlToValidate="Number2" ErrorMessage="!!" ForeColor="Red"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">12.5</td>
                    <td class="style6" colspan="2">
                    GST Registration Number :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExistingGSTRegistrationNumber" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">12.6</td>
                    <td class="style6" colspan="2">
                    Social Status :</td>
                    <td class="style4">
                        <asp:Label ID="lblExistingSocialStatus" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <h6>13. DETAILS OF EXPANSION / DIVERSIFICATION / MODERNIZATION PROJECT:</h6>
            <table style="width: 100%">
                <col width="3%" />
            <col width="15%" />
                    <col width="20%" />
                    <col width="62%" />
                <tr>
                    
                        <td class="style4" rowspan="6">13.1</td>
                    <td class="style6" rowspan="6">
                        <center><h6>Location of Expansion / Diversification / Modernization Project</h6> </center>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Plot No. & Area:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExpansionPlotNoArea" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">City / Town / Village:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExpansionCityTownVillage" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">District:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExpansionDistrict" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">State :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExpansionState" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Postal Code :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExpansionPostalCode" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>

                <tr>
                     <td class="style4" >13.2</td>
                    <td class="style4" colspan="2">Application :</td>
                    <td class="style4">
                        <asp:Label ID="lblApplication" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" >13.3</td>
                    <td class="style4" colspan="2">
                    Nature of Industry of Expansion / Diversification / Modernization Project :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblExpansionNatureofIndustry" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" >13.4</td>
                    <td class="style4" colspan="2">
                   Products of Existing Unit before undergoing Diversification / Expansion / Modernization :
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblProductsofExisting" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" >13.5</td>
                    <td class="style4" colspan="2">
                   Commencement of Commercial Production of Expansion / Diversification / Modernization Project:
                    </td>
                    <td class="style4">
                        <asp:Label ID="lblCommencementofCommercial" runat="server" Width="120px"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <h6>14. LINE OF ACTIVITY AND CAPACITIES:</h6>
            <table style="width: 100%">
                <col width="3%" />
            <col width="15%" />
                    <col width="20%" />
                <col width="20%" />
                    <col width="42%" />

                
                    <tr>
                        <td class="style4" colspan="2"/>
                        <td class="style4" >Line of Activity</td>
                        <td class="style4" >Installed Capacity (in units)</td>
                        <td class="style4" >% of increase in Capacity under Expansion </td>
                        
                    </tr>
                    <tr>
                        <td class="style4" >14.1</td>
                       <td class="style4" >Existing Unit</td>
                   <td class="style4" >
                            <asp:Label ID="lblLineofActivity1" runat="server" /></td>
                        <td class="style4" >
                            <asp:Label ID="lblInstalledCapacity1" runat="server" /></td>
                       <td class="style4" >
                            <asp:Label ID="lblpercentageIncrease1" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="style4" >14.2</td>
                       <td class="style4" >Expansion / Diversification / Modernization Project  </td>
                       <td class="style4" >
                            <asp:Label ID="lblLineofActivity2" runat="server" /></td>
                        <td class="style4" >
                            <asp:Label ID="lblInstalledCapacity2" runat="server" /></td>
                       <td class="style4" >
                            <asp:Label ID="lblpercentageIncrease2" runat="server" /></td>
                    </tr>
                </table>
            <br />
            <br />
            <h6>15. FIXED INVESTMENT IN EXPANSION / DIVERSIFICATION / MODERNIZATION PROJECT:</h6>
            <table style="width: 100%">
          <col width="3%" />
            <col width="37%" />
                    <col width="15%" />
            <col width="15%" />
                    <col width="30%" />
            <tr>
                <td class="style4" rowspan="4">15.1</td>
                <td  colspan="4" class="style6">
                    <left><h6> Land:</h6></left>
                </td>
                
            </tr>
            
            <tr>
                <td class="style6">Five times Plinth area of the Factory Building Constructed(In Acres)
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionFactoryBuildingConstructed" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Rate per Acre (In Rupees) :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblRateperAcre" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6" >Total Investment in Land:
                </td>
                <td class="style6" colspan="3">
                    <asp:Label ID="lblTotalInvestmentLand" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr id="tr1" runat="server" visible="false">
                <td class="auto-style2" colspan="2">
                    <center><h3> Whether allotted by the Government</h3></center>
                </td>
            </tr>
            <tr>
                <td class="style4" rowspan="5">15.2</td>
                <td class="style4">Building</td>
                <td class="style4">Built up Area (In Sq.ft.)</td>
                <td class="style4">Rate per Sq.ft.(In Rupees)</td>
                <td class="style4">Total(In Rupees)</td>
            </tr>
            <tr>
                <td class="style4">Factory Building</td>
                <td class="style4">
                    <asp:Label ID="lblExpansionBuildipArea1" runat="server" /></td>
                <td class="style4">
                    <asp:Label ID="lblExpansionBuildipArea2" runat="server" /></td>
                    <td class="style4">
                    <asp:Label ID="lblExpansionBuildipArea3" runat="server" /></td>
            </tr>
            <tr>
                       <td class="style4">Infrastructure (Other than Land & Land Development)</td>
                       <td class="style4">
                    <asp:Label ID="lblExpansionInfrastructure1" runat="server" /></td>
                <td class="style4">
                    <asp:Label ID="lblExpansionInfrastructure2" runat="server" /></td>
                  <td class="style4">
                    <asp:Label ID="lblExpansionInfrastructure3" runat="server" /></td>
            </tr>
            <tr>
                       <td class="style4">Other Productive Assets (Specify) </td>
                       <td class="style4">
                    <asp:Label ID="lblExpansionOtherProductive1" runat="server" /></td>
                       <td class="style4">
                    <asp:Label ID="lblExpansionOtherProductive2" runat="server" /></td>
                       <td class="style4">
                    <asp:Label ID="lblExpansionOtherProductive3" runat="server" /></td>
            </tr>
            <tr>
                <td class="style6">Total Investment in Building (In Rupees):
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionTotalInvestmentBuilding" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" rowspan="7">15.3</td>
                <td class="style4">
                    <left> <h6> <b>Plant and Machinery</b></h6></left>
                </td>
                <td class="style4" colspan="3"><center><b>Amount in Rupes</b></center></td>
            </tr>
            <tr>
                <td class="style6">Plant and machinery and other Productive Assets:
                </td>
               <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionPlantmachinery" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Transportation :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionTransportation" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Erection :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionErection" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Electrification:
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionElectrification" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Other Assets :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionOtherAssets" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">Total Investment in Plant & Machinery(In Rupees) :
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionTotalInvestmentPlant" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr>
                 <td class="style4" >15.4</td>
                <td class="style6">Total Fixed Capital Investment in Land, Building and Plant & Machinery (In Rupees):
                </td>
               <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionTotalFixedCapitalInvestment" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
                <tr>
                 <td class="style4" >15.5</td>
                <td class="style6">Pereentage increase in A over existing Fixed Capital investment:
                </td>
               <td class="style4" colspan="3">
                    <asp:Label ID="lblExpansionPercentageincrease" runat="server" Width="120px"></asp:Label>
                </td>
            </tr>
        </table>
            <br />
            <br />
            <h6>16. NATURE OF INVESTMENT - EXPANSION / DIVERSIFICATION / MODERNIZATION (IN RUPEES)</h6>
                
                    <table style="width: 100%">
                      <col width="3%" />
            <col width="37%" />
                    <col width="15%" />
            <col width="15%" />
                    <col width="30%" />

                     
                            <tr>
                               
                                 <td class="style4" colspan="2">Nature of Assets </td>
                                <td class="style4">Existing Enterprise</td>
                                <td class="style4">Expansion/ Diversification Project</td>
                                <td class="style4">% of increase under Expansion/ Diversification</td>
                            </tr>
                            <tr>
                                <td class="style4">16.1</td>
                                <td class="style4">Land</td>
                                <td class="style4">
                                    <asp:Label ID="lblExpansionLand1" runat="server" /></td>
                                <td class="style4">
                                    <asp:Label ID="lblExpansionPlant1" runat="server" /></td>
                               <td class="style4">
                                    <asp:Label ID="lblExpansionTotal1" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="style4">16.2</td>
                                <td class="style4">Plant & Machinery</td>
                                <td class="style4">
                                    <asp:Label ID="lblExpansionLand2" runat="server" /></td>
                               <td class="style4">
                                    <asp:Label ID="lblExpansionPlant2" runat="server" /></td>
                                <td class="style4">
                                    <asp:Label ID="lblExpansionTotal2" runat="server" /></td>
                            </tr>
                            <tr>
                                <td class="style4">16.3</td>
                                <td class="style4">Total</td>
                                <td class="style4">
                                    <asp:Label ID="lblExpansionLand3" runat="server" /></td>
                               <td class="style4">
                                    <asp:Label ID="lblExpansionPlant3" runat="server" /></td>
                                <td class="style4">
                                    <asp:Label ID="lblExpansionTotal3" runat="server" /></td>
                            </tr>


                        </table>

                        <table id="tbl17" runat="server" visible="false" style="width: 100%">
                            <tr>
                                <td colspan="3"
                                    style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;">APPLICATION OF INCENTIVES UNDER T-TAP:</td>
                            </tr>
                            <tr>
                                <td>Incentives that the Applicant / Unit would apply for under T-TAP :</td>
                                <td>
                                    <asp:CheckBox ID="CapitalAssistance" Text="Capital Assistance" runat="server" /><br />
                                    <asp:CheckBox ID="CapitalAssistance12" Text="Capital  Assistance  for  Creation  of  Energy,  Water  and  Environmental  Conservation Infrastructure" runat="server" /><br />
                                    <asp:CheckBox ID="InterestSubsidy" Text="Interest Subsidy" runat="server" /><br />
                                    <asp:CheckBox ID="PowerTariffSubsidy" Text="Power Tariff Subsidy" runat="server" /><br />
                                    <asp:CheckBox ID="StampDutyReimbursement" Text="Stamp Duty Reimbursement " runat="server" /><br />
                                    <asp:CheckBox ID="ConcessiononSGST" Text="Concession on SGST" runat="server" /><br />
                                    <asp:CheckBox ID="AssistanceAcquisition" Text="Assistance for Acquisition of New Technology" runat="server" /><br />
                                    <asp:CheckBox ID="TransportSubsidy" Text="Transport Subsidy to Export-Intensive Textile / Apparel Units " runat="server" /><br />
                                    <asp:CheckBox ID="DesignProductDevelopment" Text="Design. Product Development and Diversification Assistance" runat="server" /><br />
                                    <asp:CheckBox ID="AssistanceforLand" Text="Assistance for Land" runat="server" /><br />
                                    <asp:CheckBox ID="AssistanceforBuilt" Text="Assistance for Built-up Space" runat="server" /><br />
                                    <asp:CheckBox ID="AssistanceInfrastructure" Text="Assistance for Other Infrastructure" runat="server" /><br />
                                    <asp:CheckBox ID="AssistanceEnvironmental" Text="Assistance for Environmental Infrastructure " runat="server" /><br />
                                    <asp:CheckBox ID="AssistanceDevelopment" Text="Assistance for Development of Worker Housing / Dormitories" runat="server" /><br />
                                    <asp:CheckBox ID="TrainingSubsidy" Text="TrainingSubsidy" runat="server" /><br />
                                    <asp:CheckBox ID="AssistanceTowardsTraining" Text="Assistance Towards Training Infrastructure In Apparel Design & Development" runat="server" /><br />
                            </td>
                                    </tr>


                        </table>

                    </table>
    </div>
            </div>
        </div>
    

</asp:Content>
