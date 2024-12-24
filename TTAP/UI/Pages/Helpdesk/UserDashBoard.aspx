<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserDashBoard.aspx.cs" Inherits="eTicketingSystem.UI.UserDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Dashboard</title>

    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <link href="../assets/css/custom.css" rel="stylesheet" />

    <link href="../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <style>
        /*#content {
            margin-top: 27px !important;
        }*/

        .col-md-3 {
            padding-right: 37px !important;
            padding-left: 80px !important;
            padding-top: 80px !important;
            width: 16% !important;
            float: left !important;
        }
    </style>
    <div id="content">
        <div id="content-header" class="d-none">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom" runat="server" id="ehome"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Dashboard1</a>
            </div>
            <%--  <h1>Fill Industry Details</h1>--%>
        </div>
        <div class="breadcrumb-bg">
            <ul class="breadcrumb font-medium title5 container">
                <li class="breadcrumb-item"><i class="fa fa-home title4" aria-hidden="true"></i> Home</li>
                <li class="breadcrumb-item">Dashboard</li>
            </ul>
        </div>
        <div class="container mt-4 pb-4" id="Receipt" runat="server">
            <div class="w-100 px-4 frm-form box-content py-4 font-medium title5 mt-sm-5">
                <h5 class="text-blue mt-1 mb-3 font-SemiBold h2 text-center">Dashboard</h5>
                <div class="widget-content nopadding">
                    <div class="row">
                        <div style="height: 200px">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
