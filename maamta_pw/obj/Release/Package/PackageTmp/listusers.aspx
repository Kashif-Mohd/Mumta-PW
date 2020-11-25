<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="listusers.aspx.cs" Inherits="maamta_pw.listusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 24px;">
            List of Users:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px"/>


        <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 12px; margin-top: -8px;">

            <asp:DropDownList ID="DropDownList1" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select Team</asp:ListItem>
                <asp:ListItem Value="1">Screening</asp:ListItem>
                <asp:ListItem Value="2">ANC</asp:ListItem>
                <asp:ListItem Value="3">Randomization</asp:ListItem>
                <asp:ListItem Value="4">Compliance / FFQ</asp:ListItem>
                <asp:ListItem Value="5">Anthro CRF5c</asp:ListItem>
                <asp:ListItem Value="6">CRF4b (ARM-D)</asp:ListItem>
                <asp:ListItem Value="7">Anthro CRF6</asp:ListItem>
            </asp:DropDownList>
           

            <div id="imaginary_container" style="margin-top:10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtname" CssClass="form-control txtboxx" runat="server" placeholder="Full Name" MaxLength="25" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>
        </div>



        <%--  <table style="text-align: center; width: 100%; margin-top: 30px; margin-bottom: 15px;">
            <tr>
                <td>
                    <asp:TextBox CssClass="input-lg txtboxx" ClientIDMode="Static" ID="txtname" type="text" Width="200px" Height="1.9em" placeholder="Name" MaxLength="25" runat="server"></asp:TextBox>

                    <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
                </td>
            </tr>
        </table>--%>



        
 <div style="width: 100%; overflow: auto">
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound1">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="title" HeaderText="Team Title" />
                <asp:BoundField DataField="site" HeaderText="Assign Site" />
                <asp:BoundField DataField="sra_name" HeaderText="Full Name" />
                <asp:BoundField DataField="user_name" HeaderText="User Name" />
                <asp:BoundField DataField="password" HeaderText="Password" />
            </Columns>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" Height="35px" />
            <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
            <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
     </div>
    </div>
</asp:Content>
