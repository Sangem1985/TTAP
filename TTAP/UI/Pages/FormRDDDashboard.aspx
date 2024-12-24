<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormRDDDashboard.aspx.cs" Inherits="TTAP.UI.Pages.FormRDDDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Js/jquery.min.js"></script>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript" language="javascript">


</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="A2" />
        </Triggers>--%>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Dashboard</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">RDD Distrcits</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">RDD Distrcits</h5>
                        <%-- <table>
                            <tr>
                                <td>
                                    <label style="margin: 6px 4px 5px 16px;">
                                        District : 
                                    </label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlDistricts" class="form-control">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>--%>
                        <div class="row">
                            <div class="col-sm-1 form-group">
                                <label class="control-label" id="Label2" runat="server">District :</label>
                            </div>
                            <div class="col-sm-4 form-group">
                                <asp:DropDownList runat="server" ID="ddlDistrict" class="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4 form-group">
                                <asp:Button ID="btnNavigate" runat="server" Text="Go to Dashboard" OnClientClick="return Navigate();" CssClass="btn btn-blue py-1 title7"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdndcp" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
        function Navigate() {
            if ($('#ContentPlaceHolder1_ddlDistrict').val() == "0") {
                alert('Please select District');
                return false;
            }
            else {
                var DistId = "0";
                DistId = $('#ContentPlaceHolder1_ddlDistrict').val();
                window.location = "frmDLODashboard.aspx?DistId=" + DistId;
            }
        
        }
</script>
</asp:Content>
