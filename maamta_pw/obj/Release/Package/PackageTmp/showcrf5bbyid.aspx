<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf5bbyid.aspx.cs" Inherits="maamta_pw.showcrf5bbyid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media only screen and (min-width: 40em) {

            .WidthFix {
                width: 65%;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="margin-top: 5px; font-size: 18px">
        <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back
        </button>
    </div>

    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%;">
            <div style="color: #ff6b6b; font-size: 18px;">
                Study-ID:
            <asp:Label ID="lbeStudyId" ForeColor="#10ac84" Font-Bold="true" runat="server" Text=""></asp:Label>
            </div>
            24 Hours FOOD RECALL: 
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">




        <asp:GridView ID="GridView1" runat="server" Font-Size="4.0mm" CssClass="footable WidthFix" CellPadding="20" ForeColor="#333333" OnRowDataBound="OnRowDataBound" AutoGenerateColumns="true">
            <RowStyle BackColor="#00b894" ForeColor="WhiteSmoke" />
        </asp:GridView>


        <br />

        <div style="color: #ff6b6b; font-size: 18px; margin-top: 30px; margin-bottom: 5px; font-family: Arial; font-weight: bold">
            <u>Q23 to Q45 (24 Hours FOOD RECALL)</u>:
        </div>
        <div style="width: 100%; overflow-x: scroll">
            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CellPadding="20" OnRowDataBound="OnRowDataBound1" ForeColor="#333333" CssClass="footable WidthFix" AutoGenerateColumns="true">
                <RowStyle BackColor="#00b894" ForeColor="WhiteSmoke" />

            </asp:GridView>
        </div>


    </div>
</asp:Content>
