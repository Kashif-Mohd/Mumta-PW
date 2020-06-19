<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="azithromycin.aspx.cs" Inherits="maamta_pw.azithromycin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }



        .btnChng {
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            font-family: arial;
            font-size: 16px;
            padding: 4px 28px;
            text-decoration: none;
            font-weight: bold;
        }

            .btnChng:active {
                position: relative;
                top: 1px;
            }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="color: #ff6b6b; font-size: 22px; width: 100%; margin-top: 15px; padding-left: 2%;">
        Azithromycin:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
    </div>
    <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


    <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: -17px">
        <tr>
            <%--            <td>
                <asp:Button ID="btnGraph" OnClick="btnGraph_Click" CssClass="btnChng" runat="server" Text="Graph" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
            </td>--%>
            <td>
                <asp:Button ID="btnPending" OnClick="btnPending_Click" CssClass="btnChng" runat="server" Text="Pending" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px; border-bottom-left-radius: 14px; border-top-left-radius: 14px;" />
            </td>
            <td>
                <asp:Button ID="btnDose" OnClick="btnDose_Click" CssClass="btnChng" runat="server" Text="Dose" Width="100%" Style="text-align: center; border-bottom-right-radius: 0px; border-top-right-radius: 0px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
            </td>
            <td>
                <asp:Button ID="btnDose_Distabance" OnClick="btnDose_Distabance_Click" CssClass="btnChng" runat="server" Text="Disturbance" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px; " />
            </td>
        </tr>
    </table>










    <div style="padding-left: 2%; margin-top: 15px;" id="divDoseDistabance" runat="server">
        <div id="div2" runat="server" style="text-align: right; margin-top: -5px">
            <button type="button" id="Button4" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExportDoseDisturbance_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
        <div id="div7" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: 0px;">
            <asp:DropDownList ID="DropDownList3" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">20 Weeks</asp:ListItem>
                <asp:ListItem Value="1">28 Weeks</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="div8" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">


            <div id="Div9" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssidDoseDisturbance" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="Button5" runat="server" style="height: 20px" onserverclick="btnSearchDoseDisturbance_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView5" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Number" />
                    <asp:BoundField DataField="pw_crf5a_02" HeaderText="Date of Visit" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="gestational_age" HeaderText="gestational_age" />
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




            <asp:GridView ID="GridView6" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Number" />
                    <asp:BoundField DataField="pw_crf5a_02" HeaderText="Date of Visit" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="gestational_age" HeaderText="gestational_age" />
                </Columns>
            </asp:GridView>
        </div>
    </div>


















    <div style="padding-left: 2%; margin-top: 15px;" id="divPending" runat="server">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -5px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExportPending_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
        <div id="div1" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: 0px;">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">20 Weeks</asp:ListItem>
                <asp:ListItem Value="1">28 Weeks</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">


            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssidPending" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearchPending_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound1" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="true">

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




            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="true">
            </asp:GridView>
        </div>
    </div>











    <div style="padding-left: 2%; margin-top: 15px;" id="divDose" runat="server">

        <div id="div3" runat="server" style="text-align: right; margin-top: -5px">
            <button type="button" id="Button2" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExportDose_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
        <div id="div4" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: 0px;">
            <asp:DropDownList ID="DropDownList2" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">20 Weeks</asp:ListItem>
                <asp:ListItem Value="1">28 Weeks</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="div5" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">


            <div id="Div6" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssidDose" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="Button3" runat="server" style="height: 20px" onserverclick="btnSearchDose_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView3" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">

                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Number" />
                    <asp:BoundField DataField="pw_crf5a_02" HeaderText="Date of Visit" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="gestational_age" HeaderText="gestational_age" />
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




            <asp:GridView ID="GridView4" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Number" />
                    <asp:BoundField DataField="pw_crf5a_02" HeaderText="Date of Visit" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="gestational_age" HeaderText="gestational_age" />
                </Columns>
            </asp:GridView>
        </div>
    </div>


</asp:Content>
