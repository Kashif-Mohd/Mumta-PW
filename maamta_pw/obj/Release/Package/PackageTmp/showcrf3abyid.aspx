<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf3abyid.aspx.cs" Inherits="maamta_pw.showcrf3abyid" %>
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
                Assessment-ID:
            <asp:Label ID="lbeAssid" ForeColor="#10ac84" Font-Bold="true" runat="server" Text=""></asp:Label>
            </div>
            Randomization Form:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">




        <asp:GridView ID="GridView1" runat="server" Font-Size="4.0mm" CssClass="footable WidthFix" CellPadding="20" ForeColor="#333333" OnRowDataBound="OnRowDataBound" AutoGenerateColumns="true">
            <RowStyle BackColor="#00b894" ForeColor="WhiteSmoke" />
        </asp:GridView>


      

    </div>
</asp:Content>
