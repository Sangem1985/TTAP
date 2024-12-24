<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmGenerateQuery.aspx.cs" Inherits="TTAP.UI.Pages.QueryGeneration.frmGenerateQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../Js/validations.js"></script>

    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .fa.fa-hand-o-right {
            margin-right: 12px;
        }

        .head2 {
            font-weight: bold;
            color: tomato;
            font-size: 16px;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        .DivBorder {
            padding: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
            margin: 10px 0px 0px 0px;
            border: 1px solid #000;
        }

        .stepper-wrapper {
            margin-top: auto;
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
        }

        .stepper-item {
            position: relative;
            display: flex;
            flex-direction: column;
            align-items: center;
            flex: 1;

            @media (max-width: 768px) {
                font-size: 12px;
            }
        }

            .stepper-item::before {
                position: absolute;
                content: "";
                border-bottom: 2px solid #ccc;
                width: 100%;
                top: 20px;
                left: -50%;
                z-index: 2;
            }

            .stepper-item::after {
                position: absolute;
                content: "";
                border-bottom: 2px solid #ccc;
                width: 100%;
                top: 20px;
                left: 50%;
                z-index: 2;
            }

            .stepper-item .step-counter {
                position: relative;
                z-index: 5;
                display: flex;
                justify-content: center;
                align-items: center;
                width: 40px;
                height: 40px;
                border-radius: 50%;
                background: #ccc;
                margin-bottom: 6px;
            }

            .stepper-item.active {
                font-weight: bold;
            }

            .stepper-item.completed .step-counter {
                background-color: #4bb543;
            }

            .stepper-item.completed::after {
                position: absolute;
                content: "";
                border-bottom: 2px solid #4bb543;
                width: 100%;
                top: 20px;
                left: 50%;
                z-index: 3;
            }

            .stepper-item:first-child::before {
                content: none;
            }

            .stepper-item:last-child::after {
                content: none;
            }

        .c-stepper__desc {
            color: grey;
            font-size: clamp(0.85rem, 2vw, 1rem);
            padding-left: var(--spacing);
            padding-right: var(--spacing);
        }
    </style>

    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGenerateLetter" />
            <asp:PostBackTrigger ControlID="btnGenerateLetter2" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Query Letter Generation</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Query Letter Generation</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="row">
                        <%-- <div class="col-sm-12 offset-md-1 col-md-10 col-lg-8 offset-lg-2 frm-form box-content py-3 font-medium title5">--%>
                        <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">Query Letter Generation</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="DivBorder">
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                                <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label2" runat="server">Common Application Number</label>
                                                <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                            </div>
                                            <div class="col-sm-2 form-group">
                                                <label class="control-label" id="Label3" runat="server">Type of Unit</label>
                                                <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label7" runat="server">Commencement of Commercial Production</label>
                                                <label class="form-control" id="lblDCPdate" runat="server"></label>
                                            </div>
                                        </div>
                                        <div class="row" id="divletterdtls" runat="server">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label5" runat="server">Letter Number</label>
                                                <label class="form-control" id="lblLetterNumber" runat="server"></label>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label8" runat="server">Letter Initiation Date</label>
                                                <label class="form-control" id="lblLetterInitiationDate" runat="server"></label>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label6" runat="server">Letter Initiation by</label>
                                                <label class="form-control" id="lblLetterInitiationby" runat="server"></label>
                                            </div>
                                            <div class="col-sm-3 form-group d-none">
                                                <label class="control-label" id="Label10" runat="server">Letter Approved Date</label>
                                                <label class="form-control" id="lblLetterApprovedDate" runat="server"></label>
                                            </div>
                                             <div class="col-sm-3 text-right  p-4">
                                                <asp:Button ID="btnGenerateLetter2" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Download Letter" OnClick="btnGenerateLetter_Click" />
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="col-sm-3 text-center">
                                                <asp:HyperLink ID="HyplinkViewApplication" Target="_blank" runat="server">Click Here to View Application</asp:HyperLink>
                                            </div>
                                           
                                        </div>
                                    </div>
                                    <div class="DivBorder pt-5" id="divstepperMain" runat="server" visible="false">
                                        <%--  <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Tracker</h5>--%>
                                        <div class="stepper-wrapper" id="divstepper" runat="server">
                                         <%--   <div class="stepper-item completed">
                                                <div class="step-counter">1</div>
                                                <div class="step-name">Sri S.Charan, <span class="c-stepper__desc">Asst.Director</span></div>
                                                <div class="step-name">Sep 7th, 2021 10:05AM</div>
                                            </div>
                                            <div class="stepper-item active">
                                                <div class="step-counter">2</div>
                                                <div class="c-stepper__desc">Joint Director</div>
                                                <div class="step-name">Status : In Progress</div>
                                            </div>
                                             <div class="stepper-item active">
                                                <div class="step-counter">3</div>
                                                <div class="step-name">Third</div>
                                            </div>
                                            <div class="stepper-item">
                                                <div class="step-counter">4</div>
                                                <div class="step-name">Forth</div>
                                            </div>
                                            <div class="stepper-item">
                                                <div class="step-counter">5</div>
                                                <div class="step-name">Fifth</div>
                                            </div>
                                            <div class="stepper-item completed">
                                                <div class="step-counter">6</div>
                                                <div class="step-name">sixth</div>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <div class="row DivBorder">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Add Queries </h6>
                                        <div class="row w-100 m-0" id="DivSalesDetails" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label4" runat="server">Applied Incentives</label>
                                                <asp:DropDownList ID="ddlAppliedIncenties" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-10 form-group" id="divQuery" runat="server">
                                                <label class="control-label label-required" id="lblQueryStatus" runat="server">Query</label>
                                                <asp:TextBox ID="txtQueryRemarks" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnAddQueries" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnAddQueries_Click" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvsalesDetails" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="gvsalesDetails_RowCommand" OnRowDataBound="gvsalesDetails_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSNo" runat="server" Text='<%#Eval("SNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Query Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQueryIdView" runat="server" Text='<%# Bind("QueryId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Query">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuery" runat="server" Text='<%#Eval("Query") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlSaleEdit" CommandName="Rowedit" CssClass="btn btn-warning mx-2 px-4 py-1 title5" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlSaleDelete" CommandName="RowDdelete" CssClass=" btn btn-danger mx-2 px-4 py-1 title5" runat="server"
                                                                OnClientClick="if (!confirm('Are You Sure Want to Delete Record?')) return false;" Text="Delete" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" runat="server" Visible="false" Text='<%# Bind("IncentiveId") %>'></asp:Label>
                                                            <asp:Label ID="lblSubIncentiveID" runat="server" Visible="false" Text='<%# Bind("SubIncentiveID") %>'></asp:Label>
                                                            <asp:Label ID="lblQueryId" runat="server" Text='<%# Bind("QueryId") %>'></asp:Label>
                                                            <asp:Label ID="lblMainQueryID" runat="server" Text='<%# Bind("MainQueryID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row DivBorder">
                                        <div class="col-sm-12">
                                            <asp:Label ID="lblDetailsofPatners" runat="server" CssClass="label-required text-blue" Font-Bold="True">Attachments</asp:Label>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="gvSubsidy_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSNo" runat="server" Text='<%#Eval("SNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemStyle Width="500px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUploadedStatus" Text='<%#Eval("UploadedStatus")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="140px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlAction" runat="server" class="form-control">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Required"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Not Required"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%#Eval("Remarks")%>' TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCAFFlag" Text='<%#Eval("CAFFlag") %>' runat="server" />
                                                            <asp:Label ID="lblAttachmentId" Text='<%#Eval("AttachmentId") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="DivBorder">
                                    <div class="row">
                                        <div class="col-sm-12 text-center">
                                            <asp:Button ID="BtnSaveDraft" runat="server" CssClass="btn btn-blue m-2" Text="Save Draft" OnClick="BtnSaveDraft_Click" />
                                            <asp:Button ID="btnGenerateLetter" runat="server" CssClass="btn btn-blue mx-2"
                                                TabIndex="5" Text="Download Letter" OnClick="btnGenerateLetter_Click" />
                                        </div>
                                    </div>
                                    <div class="row pt-4" id="divApprove" runat="server">
                                        <div class="col-sm-3 text-right pt-2"  id="divApproveactionlabel" runat="server" >
                                            Action To Be Taken
                                        </div>
                                        <div class="col-sm-3 text-right pt-2" id="divApproveaction" runat="server" visible="false">
                                            <asp:DropDownList ID="ddlApproveaction" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlApproveaction_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="F" Text="Forward"></asp:ListItem>
                                                <asp:ListItem Value="A" Text="Approve"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 text-center pt-2" id="divdeptusers" runat="server" visible="false">
                                            <asp:DropDownList ID="ddldeptusers" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 text-left" id="divbtndeptusers" runat="server">
                                            <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-blue m-2" Text="Approve" OnClick="btnApprove_Click"
                                                OnClientClick="if (!confirm('Are You Sure Want to Submit the File?')) return false;" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 form-group">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtGODate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtLOCDate']").keydown(function () {
            return false;
        });
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtGODate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtLOCDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtGODate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtLOCDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });

    </script>


    <style type="text/css">
        .ui-da font-size: 8pt !important; padding: 0.2em 0.2em 0; width: 250px; color: Black;
        }

        select {
            color: Black !important;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
