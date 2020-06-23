<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="CumulativeDatasets.aspx.cs" Inherits="maamta_pw.CumulativeReport" %>
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

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Cumulative Datasets:
        </div>

        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">


            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound1" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">

                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="ARM" HeaderText="ARM" />
                    <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                    <asp:BoundField DataField="Form_Status" HeaderText="Form Status" />
                    <asp:BoundField DataField="Birth_Outcome_Type" HeaderText="Birth Outcome Type" />
                    <asp:BoundField DataField="Baby_Currently_Alive" HeaderText="Baby Currently Alive" />
                    <asp:BoundField DataField="AZO_GA_20_Weeks" HeaderText="AZO Dose G.A 20_Weeks" />
                    <asp:BoundField DataField="AZO_GA_28_Weeks" HeaderText="AZO Dose G.A 28_Weeks" />
                    <asp:BoundField DataField="LNS_Cumulative" HeaderText="LNS Cumulative" />
                    <asp:BoundField DataField="Choline_Cumulative" HeaderText="Choline Cumulative" />
                    <asp:BoundField DataField="Nicotinamide_Cumulative" HeaderText="Nicotinamide Cumulative" />
                </Columns>


                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>


            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="ARM" HeaderText="ARM" />
                    <asp:BoundField DataField="gestational_age" HeaderText="Gestational Age" />
                    <asp:BoundField DataField="Pregnancy_Status" HeaderText="Status" />
                    <asp:BoundField DataField="Form_Status" HeaderText="Form Status" />
                    <asp:BoundField DataField="Birth_Outcome_Type" HeaderText="Birth Outcome Type" />
                    <asp:BoundField DataField="Baby_Currently_Alive" HeaderText="Baby Currently Alive" />
                    <asp:BoundField DataField="AZO_GA_20_Weeks" HeaderText="AZO Dose G.A 20_Weeks" />
                    <asp:BoundField DataField="AZO_GA_28_Weeks" HeaderText="AZO Dose G.A 28_Weeks" />
                    <asp:BoundField DataField="LNS_Cumulative" HeaderText="LNS Cumulative" />
                    <asp:BoundField DataField="Choline_Cumulative" HeaderText="Choline Cumulative" />
                    <asp:BoundField DataField="Nicotinamide_Cumulative" HeaderText="Nicotinamide Cumulative" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
