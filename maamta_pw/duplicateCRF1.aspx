<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="duplicateCRF1.aspx.cs" Inherits="maamta_pw.duplicateCRF1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }

        .StylePager {
            border-radius: 5px;
            text-align: left;
        }

            .StylePager a:hover {
                background-color: #33d9b2;
                margin-right: 3px;
                padding: 3px;
                border-radius: 3px;
            }

            .StylePager a {
                padding: 3px;
                margin-right: 3px;
            }

            .StylePager span {
                background: #FF4081;
                padding: 4px;
                border-radius: 3px;
                margin-right: 3px;
            }


        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            tddd, thhh {
                margin-top: 0.8em;
                display: block;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 24px;">
            Duplicate Screening Forms:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


        <div style="text-align: center; margin-top: -5px; margin-bottom: 15px; visibility: hidden">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export Records &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>



        <div id="div1" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: -5px;">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="1">Duplicate DSS (Same Date)</asp:ListItem>
                <asp:ListItem Value="2">Duplicate DSS (ALL)</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div id="div2" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 5px; margin-top: 5px; text-align: center">
            <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
        </div>



        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DSSID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkDSSID" OnClick="Link_DSSID" Text='<%#Eval("dssid") %>' runat="server" ToolTip="Show Detail"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Duplicate" HeaderText="Duplicate" />
                    <asp:BoundField DataField="DOV" HeaderText="Date of Visit" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
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

            <br />

            <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
            </asp:GridView>
        </div>

    </div>
</asp:Content>
