<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/UserMaster.Master" CodeBehind="frmConcessionsgsts.aspx.cs" Inherits="TTAP.UI.Pages.frmConcessionsgsts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script src="../../../Resource/Styles/SideMenu/script.js"></script>
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>



    <asp:UpdatePanel ID="upd1" runat="server">


      
        <ContentTemplate>
            <div class="container">
                <div class="row mt-4">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item active"><a href="Home.aspx">Home</a></li>
                            <li class="breadcrumb-item">Concession on SGST</li>
                        </ol>
                    </nav>
                </div>
                <div class="box box-success">
                    <div class="box-header with-border">
                        <h6 class="box-title">
                            <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="1000px"> Concession on SGST<font 
                                                            color="red">*</font></asp:Label>
                            <br />
                            <br />
                        </h6>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="divData" runat="server" visible="true">
                                <div class="form-group">

                                    <div class="row">
                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            1.
                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK"> Installed capacity of the
existing Enterprise as
certified by the financial
institution/ chartered
accountant
                                                          <font color="red">*</font></asp:Label>
                                        </div>

                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtInstalledCapacity" runat="server" class="form-control txtbox"
                                                TabIndex="1"
                                                ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="txtInstalledCapacity"
                                                ErrorMessage="Please Enter Type of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            2.
                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK">Claim Application submitted by the 
Enterprise/Industry for the 1st Half 
Yare/2nd Half Year:<font 
                                                            color="red">*</font></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtClaimApplication" runat="server" class="form-control txtbox"
                                                TabIndex="1"
                                                ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="txtClaimApplication"
                                                ErrorMessage="Please Enter  the Claim Application"
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            3. 
                                            <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK"> Tax paid by the Enterprise during the 
1
st Half Year/2nd half year as certified 
by the Commercial Tax Department<font  color="red">*</font></asp:Label>
                                        </div>

                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtTaxpaid"
                                                runat="server" class="form-control txtbox"
                                                TabIndex="1"
                                                ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                ControlToValidate="txtTaxPaid"
                                                ErrorMessage="Please Enter the Location of Training Centre "
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            4.
                                            <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK">
                                                                  Current Claim
<font 
                                                            color="red">*</font></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="txtCurrentClaim" runat="server" class="form-control txtbox"
                                                TabIndex="1"
                                                ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                ControlToValidate="txtCurrentClaim"
                                                ErrorMessage="Please enter the Courses offered in the Training Centre" InitialValue="--Select--"
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </div>



                                        <table>

                                            <thead>
                                                <th>Year
                                                </th>

                                                <th>Enterprises
                                                </th>

                                                <th>Total production
                                                </th>


                                            </thead>

                                            <tbody>

                                                <tr>

                                                    <td>
                                                        <asp:TextBox ID="txtYear1" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtEnterprises1" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="txtToatalproduction1" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>




                                                </tr>

                                                <tr>

                                                    <td>
                                                        <asp:TextBox ID="txtYear2" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtEnterprises2" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="txtToatalproduction2" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>




                                                </tr>


                                                <tr>

                                                    <td>
                                                        <asp:TextBox ID="txtYear3" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox ID="txtEnterprises3" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>

                                                    <td>
                                                        <asp:TextBox ID="txtToatalproduction3" runat="server" class="form-control txtbox"
                                                            TabIndex="1"></asp:TextBox></td>




                                                </tr>




                                            </tbody>



                                        </table>


                                        <table style="width: 950px">



                                            <tr>
                                                <th rowspan="6">SGST reimbursement
already availed by
Enterprise from the Date of
Commencement of
Production (Maximum for 7 years)</th>


                                            </tr>

                                            <tr>




                                                <td style="padding: 5px; margin: 5px">

                                                    <span>1st Half Year
                                                            <asp:TextBox ID="txthalfyear1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox></span>


                                                </td>




                                                <td style="padding: 5px; margin: 5px">

                                                    <br />
                                                    <br />
                                                    <asp:TextBox ID="txtHalfyear11" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                        ControlToValidate="txtHalfyear1"
                                                        ErrorMessage="Please enter the Plant & Machinery"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>





                                            </tr>

                                            <tr>




                                                <td style="padding: 5px; margin: 5px">

                                                    <span>2nd Half Year
                                                            <asp:TextBox ID="txtHalfyear2" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox></span>


                                                </td>




                                                <td style="padding: 5px; margin: 5px">

                                                    <br />
                                                    <br />
                                                    <asp:TextBox ID="txtHalfyear22" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                        ControlToValidate="txtHalfyear2"
                                                        ErrorMessage="Please enter the Plant & Machinery"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>





                                            </tr>

                                            <tr>




                                                <td style="padding: 5px; margin: 5px">1st Half Year
                                                        <asp:TextBox ID="txthalfyear3" runat="server" class="form-control txtbox"
                                                            Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>


                                                </td>




                                                <td style="padding: 5px; margin: 5px">

                                                    <br />
                                                    <br />
                                                    <asp:TextBox ID="txthalfyear33" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                        ControlToValidate="txtHalfyear1"
                                                        ErrorMessage="Please enter the Plant & Machinery"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>





                                            </tr>

                                            <tr>




                                                <td style="padding: 5px; margin: 5px">

                                                    <span>2nd Half Year<asp:TextBox ID="txthalfyear4" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox></span>


                                                </td>




                                                <td style="padding: 5px; margin: 5px">

                                                    <br />
                                                    <br />
                                                    <asp:TextBox ID="txthalfYear44" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                        ControlToValidate="txtHalfyear1"
                                                        ErrorMessage="Please enter the Plant & Machinery"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>





                                            </tr>
                                            <tr>




                                                <td style="padding: 5px; margin: 5px">

                                                    <label>Total</label>


                                                </td>




                                                <td style="padding: 5px; margin: 5px">

                                                    <asp:TextBox ID="txtTotal" runat="server" class="form-control txtbox"
                                                        Height="28px" MaxLength="40" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                        ControlToValidate="txtTotal"
                                                        ErrorMessage="Please enter the Plant & Machinery"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                </td>





                                            </tr>




                                        </table>




                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">


                                            <Triggers>

                                                <asp:PostBackTrigger ControlID="btnSaleInvoice" />
                                                <asp:PostBackTrigger ControlID="btnconcernedCTo" />
                                                   <asp:PostBackTrigger ControlID="btnproductionParticulars" />
                                                <asp:PostBackTrigger ControlID="btnTSPCBOperation" />
                                            </Triggers>
                                            <ContentTemplate>



                                                <table runat="server" style="text-align: center">

                                                    <tr runat="server" style="text-align: center">

                                                        <td style="text-align: center"><b>Enclosures</b></td>


                                                    </tr>


                                                    <tr id="trEnclosures" runat="server" style="text-align: center">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">1</td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">) First Sale Invoice
                                                    <br />
                                                            <asp:HyperLink ID="HyperLinkCivilEngineersFormat" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Civil Engineers Certificate Format.pdf">Click here for Prescribed Format</asp:HyperLink>
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuSaleInvoice" runat="server" CssClass="CS" />
                                                            <asp:Button ID="btnSaleInvoice" runat="server" OnClick="btnSaleInvoice_Click" Text="Click here to Upload" /></td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="hySaleInvoice" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                Target="_blank"></asp:HyperLink>
                                                            <asp:Label ID="lblSaleInvoice" runat="server" Font-Bold="true" ForeColor="Green" Visible="false" />
                                                        </td>
                                                    </tr>

                                                    <tr id="tr1" runat="server" style="text-align: center">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">2</td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Certificate from concerned CTO as prescribed at Form No A<br />
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Civil Engineers Certificate Format.pdf">Click here for Prescribed Format</asp:HyperLink>
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuconcernedCTo" runat="server" CssClass="CS" />
                                                            <asp:Button ID="btnconcernedCTo" runat="server" OnClick="btnconcernedCTo_Click" Text="Click here to Upload" /></td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="hypconcernedCTo" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                Target="_blank"></asp:HyperLink>
                                                            <asp:Label ID="lblconcernedCTo" runat="server" Font-Bold="true" ForeColor="Green" Visible="false" />
                                                        </td>
                                                    </tr>

                                                    <tr id="tr2" runat="server" style="text-align: center">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">3</td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Production Particulars for the last –3- years and Column No. 5 & 6 of the application duly certified
by Chartered Accountant for the first time of the claim, if it is Expansion/Diversification Project.<br />
                                                            <asp:HyperLink ID="HyperLink2" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Civil Engineers Certificate Format.pdf">Click here for Prescribed Format</asp:HyperLink>
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuProductionParticulars" runat="server" CssClass="CS" />
                                                            <asp:Button ID="btnproductionParticulars" runat="server" OnClick="btnproductionParticulars_Click" Text="Click here to Upload" /></td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="hyroductionParticulars" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                Target="_blank"></asp:HyperLink>
                                                            <asp:Label ID="lblroductionParticulars" runat="server" Font-Bold="true" ForeColor="Green" Visible="false" />
                                                        </td>
                                                    </tr>



                                                    <tr id="tr3" runat="server" style="text-align: center">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">4</td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Valid Consent for Operation (CFO) from TSPCB/Acknowledgement from General Manager, District
Industries Centre concerned on pollution angle.<br />
                                                            <asp:HyperLink ID="HyperLink4" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Civil Engineers Certificate Format.pdf">Click here for Prescribed Format</asp:HyperLink>
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuTSPCBOperation" runat="server" CssClass="CS" />
                                                            <asp:Button ID="btnTSPCBOperation" runat="server" OnClick="btnTSPCBOperation_Click" Text="Click here to Upload" /></td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="hyTSPCBOperation" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                Target="_blank"></asp:HyperLink>
                                                            <asp:Label ID="lblTSPCBOperation" runat="server" Font-Bold="true" ForeColor="Green" Visible="false" />
                                                        </td>
                                                    </tr>




                                                         <tr>
                <td class="style5">&nbsp;</td>
                <td class="style4"><br />
                    <asp:Button ID="BtnPrevious" class="btn bg-blue text-white" Text="Previous" runat="server" ValidationGroup="Submit" OnClick="BtnPrevious_Click" />
                    &nbsp;&nbsp;
                <asp:Button ID="BtnSave1" runat="server" class="btn bg-blue text-white"
                                                        TabIndex="10" Text="SaveAndNext" OnClick="BtnSave1_Click"
                                                        ValidationGroup="group" CausesValidation="False" />
                    &nbsp;&nbsp;
                                <asp:Button ID="Button1" class="btn bg-blue text-white" Text="Next" runat="server" OnClick="BtnNext_Click" />
                    &nbsp;&nbsp;
                                <asp:Button ID="Button2" class="btn bg-blue text-white" Text="Clear" runat="server" OnClick="btnclear_Click" />
                    &nbsp;&nbsp;
                </td>

                             
                                                             </tr>
                                                  
                                                 
                                          
                                                 
                                                  
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                            <div id="success" runat="server" visible="false" class="alert alert-success">

                                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>


                                                </table>







                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                            <ProgressTemplate>
                                <div class="update">
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
