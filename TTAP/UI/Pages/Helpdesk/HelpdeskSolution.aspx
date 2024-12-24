<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="HelpdeskSolution.aspx.cs" Inherits="eTicketingSystem.UI.Pages.Helpdesk.HelpdeskSolution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        #ContentPlaceHolder1_Button8 {
            background: none !important;
            border: 0px !important;
            color: #fff !important;
            font-weight: 900;
            font-family: revert !important;
        }
    </style>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <!-- Core CSS - Include with every page -->

    <%-- <link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />--%>
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <link href="../assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <link href="../assets/css/main-style.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />
    <!-- Page-Level CSS -->
    <link href="../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <style>
        /*#content {
            margin-top: 27px !important;
        }*/
        .row {
            margin-right: -15px;
            margin-left: -15px;
        }

        /*a {
            color: black !important;
        }*/

        .panel-footer {
            padding: 10px 15px;
            background-color: #f5f5f5;
            border-top: 1px solid #ddd;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
        }

        .panel-body {
            padding: 15px;
        }



        .panel {
            margin-bottom: 20px;
            background-color: #fff;
            border: 1px solid transparent;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
            box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
        }

        @media (min-width: 992px) {
            .col-md-1, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-md-10, .col-md-11, .col-md-12 {
                float: left;
            }

            .col-md-12 {
                width: 100%;
            }

            .col-md-11 {
                width: 91.66666667%;
            }

            .col-md-10 {
                width: 83.33333333%;
            }

            .col-md-9 {
                width: 75%;
            }

            .col-md-8 {
                width: 66.66666667%;
            }

            .col-md-7 {
                width: 58.33333333%;
            }

            .col-md-6 {
                width: 50%;
            }

            .col-md-5 {
                width: 41.66666667%;
            }

            .col-md-4 {
                width: 30%;
            }

            .col-md-3 {
                width: 21% !important;
            }

            .col-md-2 {
                width: 16.66666667%;
            }

            .col-md-1 {
                width: 8.33333333%;
            }

            .col-md-pull-12 {
                right: 100%;
            }

            .col-md-pull-11 {
                right: 91.66666667%;
            }

            .col-md-pull-10 {
                right: 83.33333333%;
            }

            .col-md-pull-9 {
                right: 75%;
            }

            .col-md-pull-8 {
                right: 66.66666667%;
            }

            .col-md-pull-7 {
                right: 58.33333333%;
            }

            .col-md-pull-6 {
                right: 50%;
            }

            .col-md-pull-5 {
                right: 41.66666667%;
            }

            .col-md-pull-4 {
                right: 33.33333333%;
            }

            .col-md-pull-3 {
                right: 25%;
            }

            .col-md-pull-2 {
                right: 16.66666667%;
            }

            .col-md-pull-1 {
                right: 8.33333333%;
            }

            .col-md-pull-0 {
                right: 0;
            }

            .col-md-push-12 {
                left: 100%;
            }

            .col-md-push-11 {
                left: 91.66666667%;
            }

            .col-md-push-10 {
                left: 83.33333333%;
            }

            .col-md-push-9 {
                left: 75%;
            }

            .col-md-push-8 {
                left: 66.66666667%;
            }

            .col-md-push-7 {
                left: 58.33333333%;
            }

            .col-md-push-6 {
                left: 50%;
            }

            .col-md-push-5 {
                left: 41.66666667%;
            }

            .col-md-push-4 {
                left: 33.33333333%;
            }

            .col-md-push-3 {
                left: 25%;
            }

            .col-md-push-2 {
                left: 16.66666667%;
            }

            .col-md-push-1 {
                left: 8.33333333%;
            }

            .col-md-push-0 {
                left: 0;
            }

            .col-md-offset-12 {
                margin-left: 100%;
            }

            .col-md-offset-11 {
                margin-left: 91.66666667%;
            }

            .col-md-offset-10 {
                margin-left: 83.33333333%;
            }

            .col-md-offset-9 {
                margin-left: 75%;
            }

            .col-md-offset-8 {
                margin-left: 66.66666667%;
            }

            .col-md-offset-7 {
                margin-left: 58.33333333%;
            }

            .col-md-offset-6 {
                margin-left: 50%;
            }

            .col-md-offset-5 {
                margin-left: 41.66666667%;
            }

            .col-md-offset-4 {
                margin-left: 33.33333333%;
            }

            .col-md-offset-3 {
                margin-left: 25%;
            }

            .col-md-offset-2 {
                margin-left: 16.66666667%;
            }

            .col-md-offset-1 {
                margin-left: 8.33333333%;
            }

            .col-md-offset-0 {
                margin-left: 0;
            }
        }

        @media (min-width: 1200px) {
            .col-lg-1, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-lg-10, .col-lg-11, .col-lg-12 {
                float: left;
            }

            .col-lg-12 {
                width: 100%;
            }

            .col-lg-11 {
                width: 91.66666667%;
            }

            .col-lg-10 {
                width: 83.33333333%;
            }

            .col-lg-9 {
                width: 75%;
            }

            .col-lg-8 {
                width: 66.66666667%;
            }

            .col-lg-7 {
                width: 58.33333333%;
            }

            .col-lg-6 {
                width: 50%;
            }

            .col-lg-5 {
                width: 41.66666667%;
            }

            .col-lg-4 {
                width: 33.33333333%;
            }

            .col-lg-3 {
                width: 21% !important;
            }

            .col-lg-2 {
                width: 16.66666667%;
            }

            .col-lg-1 {
                width: 8.33333333%;
            }

            .col-lg-pull-12 {
                right: 100%;
            }

            .col-lg-pull-11 {
                right: 91.66666667%;
            }

            .col-lg-pull-10 {
                right: 83.33333333%;
            }

            .col-lg-pull-9 {
                right: 75%;
            }

            .col-lg-pull-8 {
                right: 66.66666667%;
            }

            .col-lg-pull-7 {
                right: 58.33333333%;
            }

            .col-lg-pull-6 {
                right: 50%;
            }

            .col-lg-pull-5 {
                right: 41.66666667%;
            }

            .col-lg-pull-4 {
                right: 33.33333333%;
            }

            .col-lg-pull-3 {
                right: 25%;
            }

            .col-lg-pull-2 {
                right: 16.66666667%;
            }

            .col-lg-pull-1 {
                right: 8.33333333%;
            }

            .col-lg-pull-0 {
                right: 0;
            }

            .col-lg-push-12 {
                left: 100%;
            }

            .col-lg-push-11 {
                left: 91.66666667%;
            }

            .col-lg-push-10 {
                left: 83.33333333%;
            }

            .col-lg-push-9 {
                left: 75%;
            }

            .col-lg-push-8 {
                left: 66.66666667%;
            }

            .col-lg-push-7 {
                left: 58.33333333%;
            }

            .col-lg-push-6 {
                left: 50%;
            }

            .col-lg-push-5 {
                left: 41.66666667%;
            }

            .col-lg-push-4 {
                left: 33.33333333%;
            }

            .col-lg-push-3 {
                left: 25%;
            }

            .col-lg-push-2 {
                left: 16.66666667%;
            }

            .col-lg-push-1 {
                left: 8.33333333%;
            }

            .col-lg-push-0 {
                left: 0;
            }

            .col-lg-offset-12 {
                margin-left: 100%;
            }

            .col-lg-offset-11 {
                margin-left: 91.66666667%;
            }

            .col-lg-offset-10 {
                margin-left: 83.33333333%;
            }

            .col-lg-offset-9 {
                margin-left: 75%;
            }

            .col-lg-offset-8 {
                margin-left: 66.66666667%;
            }

            .col-lg-offset-7 {
                margin-left: 58.33333333%;
            }

            .col-lg-offset-6 {
                margin-left: 50%;
            }

            .col-lg-offset-5 {
                margin-left: 41.66666667%;
            }

            .col-lg-offset-4 {
                margin-left: 33.33333333%;
            }

            .col-lg-offset-3 {
                margin-left: 25%;
            }

            .col-lg-offset-2 {
                margin-left: 16.66666667%;
            }

            .col-lg-offset-1 {
                margin-left: 8.33333333%;
            }

            .col-lg-offset-0 {
                margin-left: 0;
            }
        }

        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }
        /*#democss #ContentPlaceHolder1_lblapplicantname, #ContentPlaceHolder1_lblUnitname, #ContentPlaceHolder1_lblMandal,
      #ContentPlaceHolder1_lblMobileNumber,#ContentPlaceHolder1_lblsubmodule,#ContentPlaceHolder1_lblreuestid,#ContentPlaceHolder1_lblMainModule
      {
           border: 0px !important;
       }*/
        #ContentPlaceHolder1_lblForwardedRemarks, #ContentPlaceHolder1_lblusercomments, #ContentPlaceHolder1_DivSolustionDevTeamComments, #ContentPlaceHolder1_lblDepartmentRemarks {
            padding: 5px;
        }
    </style>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="Button8" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current">Helpdesk Solution</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="<%=Page.ResolveClientUrl("~/UI/UserDashBoard.aspx") %>">Home</a></li>
                            <li class="breadcrumb-item">Helpdesk Solution</li>
                        </ul>
                    </div>
                </div>


                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <%--<div class="w-100 px-4 frm-form box-content py-4 font-medium title5 mt-sm-5">--%>

                    <%-- <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">--%>
                    <div class="col-sm-12 offset-md-1 col-md-10 col-lg-10 offset-lg-1 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <h5 class="text-blue mb-3 font-SemiBold">Helpdesk Solution</h5>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <div class="input-group" id="divPriority" runat="server" visible="false">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" style="width: 150px" id="inputGroupFileAddon02">Priority</span>
                                                </div>
                                                <label id="lblPriority" style="margin-bottom: 0rem; border: 1px solid #ced4da; padding: 4px; width: 150px; padding-left: 8px;" runat="server" class="font-SemiBold"></label>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <div class="input-group">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" id="inputGroupFileAddon01">Ticket Status</span>
                                                </div>
                                                <label id="lblcurrentstatus" style="margin-bottom: 0rem; border: 1px solid #ced4da; padding: 4px; width: 150px; padding-left: 8px;" runat="server" class="font-SemiBold"></label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="widget-content nopadding" id="democss">
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">User Name</label>
                                            <label class="form-control font-SemiBold" id="lblapplicantname" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label3" runat="server">District</label>
                                            <label id="lblUnitname" runat="server" class="form-control font-SemiBold"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Mandal</label>
                                            <label id="lblMandal" runat="server" class="form-control font-SemiBold"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Mobile Number</label>
                                            <label id="lblMobileNumber" runat="server" class="form-control font-SemiBold"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">Submission Date</label>
                                            <label class="form-control font-SemiBold" id="lblraiseddate" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label7" runat="server">Request ID</label>
                                            <label id="lblreuestid" runat="server" class="form-control font-SemiBold"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Application</label>
                                            <label id="lblApplication" runat="server" class="form-control font-SemiBold"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Main Module</label>
                                            <div id="lblMainModule" runat="server" style="border: 1px solid #ced4da; min-height: 35px; padding-left: 6px;" class="font-SemiBold"></div>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">Sub Module</label>
                                            <div class="font-SemiBold" style="border: 1px solid #ced4da; min-height: 35px; padding-left: 6px;" id="lblsubmodule" runat="server"></div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label13" runat="server">Problem While</label>
                                            <label id="lblProblemWhile" runat="server" class="form-control font-SemiBold"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label14" runat="server">Feedback Type</label>
                                            <label class="form-control font-SemiBold" id="lblfeedback" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group" id="trDOUserFwd" runat="server">
                                            <label class="control-label" id="Label17" runat="server">Action Taken</label>
                                            <asp:DropDownList ID="ddlAction" runat="server" class="form-control"
                                                TabIndex="1" ValidationGroup="group" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1"> Forward TO CMS </asp:ListItem>
                                                <asp:ListItem Value="2"> Reply </asp:ListItem>
                                                <asp:ListItem Value="3"> Need Approval </asp:ListItem>
                                                <asp:ListItem Value="4"> Forward To </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divPriorityInput" runat="server" visible="false">
                                            <label class="control-label" id="Label20" runat="server">Priority</label>
                                            <asp:DropDownList ID="ddlPriorityInput" runat="server" class="form-control"
                                                TabIndex="1" ValidationGroup="group">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1"> Critical </asp:ListItem>
                                                <asp:ListItem Value="2"> High </asp:ListItem>
                                                <asp:ListItem Value="3"> Medium </asp:ListItem>
                                                <asp:ListItem Value="4"> Low </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row" id="divAssignMain" runat="server" visible="false">
                                        <div class="col-sm-4 form-group" id="divAssign" runat="server" visible="false">
                                            <label class="control-label" id="Label26" runat="server">Assigned To</label>
                                            <asp:DropDownList ID="ddlAsignedto" runat="server" class="form-control"
                                                TabIndex="1" ValidationGroup="group">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divbtnAssign" runat="server" visible="false">
                                            <br />
                                            <asp:Button ID="btnAssign" runat="server" Height="32px" CssClass="btn btn-primary" TabIndex="10"
                                                Text="Assign" ToolTip="To Assign the Ticket" ValidationGroup="group" OnClick="btnAssign_Click" />

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <div class="input-group" id="divPendingWith" runat="server">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text" style="width: 150px" id="SpnPendingWith">Pending With</span>
                                                </div>
                                                <label id="lblPendingWith" style="margin-bottom: 0rem; border: 1px solid #ced4da; padding: 7px;  padding-left: 8px; height:37px" runat="server" class="form-control font-SemiBold"></label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label" id="Label12" runat="server">Problem Description</label>
                                            <div id="lblusercomments" runat="server" class="font-SemiBold border-blue"></div>
                                        </div>
                                    </div>
                                    <div class="row" id="TrForwardedRemark" runat="server" visible="false">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label" id="Label15" runat="server">DRP User Remarks</label>
                                            <div id="lblForwardedRemarks" runat="server" class="font-SemiBold border-blue"></div>
                                        </div>
                                    </div>
                                    <div class="row" id="divDepartmentRemarks" runat="server" visible="false">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label" id="Label19" runat="server">Department Remarks</label>
                                            <div id="lblDepartmentRemarks" runat="server" class="font-SemiBold border-blue"></div>
                                        </div>
                                    </div>
                                    <div class="row" id="DivolustionDevTeamComments" runat="server" visible="false">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label" id="Label18" runat="server">How The Issue Has Been Resolved?</label>
                                            <div id="DivSolustionDevTeamComments" runat="server" class="font-SemiBold border-blue"></div>
                                        </div>
                                    </div>
                                    <div class="row" id="DivApprovalRequestStatus" runat="server">
                                        <div class="col-sm-12 text-black font-SemiBold mb-1">Approval Request Status</div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvApprovalRequestStatus" runat="server" CssClass="table table-bordered title6 pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovalRequestRemarks" HeaderText="Approval Request" />
                                                    <asp:BoundField DataField="ApprovalRequestSentBy" HeaderText="Requested By" />
                                                    <asp:BoundField DataField="ApprovalRequestDate" HeaderText="Date Of Request" />

                                                    <asp:BoundField DataField="Response" HeaderText="Department Response" />
                                                    <asp:BoundField DataField="Respondedby" HeaderText="Responded By" />
                                                    <asp:BoundField DataField="ResponseDate" HeaderText="Date Of Response" />
                                                    <asp:BoundField DataField="ApprovalStatus" HeaderText="Status" />
                                                    <asp:BoundField DataField="RequestStatus" HeaderText="Dept Approval Status" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row" id="Trqueryresponceattachemnts" runat="server" visible="false">
                                        <div class="col-sm-12 text-black font-SemiBold mb-1" style="padding-top: 40px">Attachments (Uploaded by User)</div>
                                        <div class="col-lg-7 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvqueryresponse" runat="server" AutoGenerateColumns="False"
                                                Width="100%" HorizontalAlign="Left" CssClass="table table-bordered title6 alternet-table w-100 NewEnterprise mt-4 mb-0" ShowHeader="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FileName" HeaderText="Document Name" />
                                                    <%--  <asp:TemplateField HeaderText="Documents attached by User">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text='<%#Eval("FileName")%>' NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" CssClass="fa fa-download fa-2x" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row" id="deptcomments" runat="server">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label" id="Label16" runat="server">Reply to The User Query/Remarks</label>
                                            <asp:TextBox ID="txtsubjet" runat="server" class="form-control"
                                                TabIndex="1" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="DivDevTeamComments" runat="server" visible="false">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label" id="Label4" runat="server">How The Issue Has Been Resolved?</label>
                                            <asp:TextBox ID="txtDevTeamComments" runat="server" class="form-control"
                                                TabIndex="1" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="trdeptupoads" runat="server">
                                        <div class="col-sm-6">
                                            <label class="d-block">Upoload Documents(If any)</label>
                                            <%-- <div class="custom-file">
                                                <input type="file" class="custom-file-input" id="customFileLangHTML">
                                                <label class="custom-file-label" for="customFileLangHTML" data-browse="Bestand kiezen">
                                                    Voeg je document toe</label>
                                            </div>--%>

                                            <asp:FileUpload ID="FileUpload10" runat="server" Class="custom-input-file mr-4" />
                                            <div class="btn btn-success btn-sm">
                                                <asp:Button ID="Button8" runat="server" Class="empty" TabIndex="10" Text="Upload" OnClick="Button8_Click" />
                                                <i class="fa fa-upload"></i>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 form-group" id="DivDeptOptions" runat="server" visible="false">
                                            <label class="control-label" id="Label2" runat="server">Action Taken</label>
                                            <asp:DropDownList ID="ddldeptApproval" runat="server" class="form-control"
                                                TabIndex="1" ValidationGroup="group">
                                                <asp:ListItem Value="1"> Approved </asp:ListItem>
                                                <asp:ListItem Value="2"> Rejected </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-sm-7 table-responsive">
                                            <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" align="left"
                                                CssClass="table table-bordered title6 alternet-table w-100 NewEnterprise mt-4 mb-0"
                                                EnableModelValidation="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" CssClass="fa fa-download fa-2x" NavigateUrl='<%#Eval("filepath")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>


                                    <div class="col-sm-12 text-center mt-3" id="trdeptsave" runat="server">
                                        <asp:Button ID="BtnSave" runat="server" Height="32px" CssClass="btn btn-primary" TabIndex="10"
                                            Text="Submit" ToolTip="To Save  the data" ValidationGroup="group" OnClick="BtnSave_Click" />&nbsp;&nbsp;<asp:Button
                                                ID="BtnClosebatchClear" Height="32px" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="100px"
                                                OnClick="BtnClear_Click" />
                                    </div>
                                    <div class="col-sm-12 text-center mt-3" id="trnotresolved" runat="server">
                                        <asp:Button ID="btnopenticket" runat="server" Height="32px" CssClass="btn btn-primary" TabIndex="10"
                                            Text="Issue has not been Resolved/ Reopen Ticket" ToolTip="To Save  the data" ValidationGroup="group" OnClick="btnopenticket_Click" />
                                    </div>

                                    <div class="col-sm-12">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="divTicketHistory" runat="server" visible="false">
                            <div class="span12">
                                <div class="widget-box">
                                    <div class="widget-title">
                                        <span class="icon">
                                            <i class="icon-info-sign"></i>
                                        </span>
                                        <h5>Ticket History</h5>
                                    </div>
                                    <div class="widget-content nopadding">
                                        <table style="width: 100%">
                                            <tr style="height: 15px">
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; width: 100%" id="divPrint" runat="server">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        OnRowDataBound="grdDetails_RowDataBound" Width="100%"
                                                        ShowFooter="false">
                                                        <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                    <asp:Label ID="lblHd_Id" runat="server" Text='<%# Eval("Hd_Id") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblHd_Sub_Id" runat="server" Text='<%# Eval("Hd_Sub_Id") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="REQID" HeaderText="Request ID">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Hd_Remarks" HeaderText="User Comments">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Response" HeaderText="Response">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SOLVEDBY" HeaderText="Replied by">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SUBMITIONDATE" HeaderText="Date of submition">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Solved_Date" HeaderText="Date of Response">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Attachments">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text="View" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="height: 15px">
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px"></td>
                                            </tr>
                                        </table>


                                    </div>
                                </div>
                            </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <script src="../assets/plugins/jquery-1.10.2.js"></script>
    <script src="../assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="../assets/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../assets/plugins/pace/pace.js"></script>
    <script src="../assets/scripts/siminta.js"></script>
    <!-- Page-Level Plugin Scripts-->
    <script src="../assets/plugins/morris/raphael-2.1.0.min.js"></script>
    <script src="../assets/plugins/morris/morris.js"></script>
    <script src="../assets/scripts/dashboard-demo.js"></script>--%>
</asp:Content>
