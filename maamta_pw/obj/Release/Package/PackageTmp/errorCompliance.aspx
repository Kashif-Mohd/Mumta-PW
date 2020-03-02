<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="errorCompliance.aspx.cs" Inherits="maamta_pw.errorCompliance" %>

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
        /* For Web Browser*/

        @media only screen and (min-width: 40em) {

            .Mobile {
                padding-left: 20%;
                text-align: center;
                width: 75%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding-left: 2%; margin-top: 15px;">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Error LNS Compliance (Xtra Sachet)
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>








        <div style="width: 100%; height: 455px; overflow: scroll; margin-top: 10px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
               <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="form_crf_4_id" HeaderText="form_crf_4_id" />
                <asp:BoundField DataField="study_code" HeaderText="Study-ID" />
                <asp:BoundField DataField="followup_num" HeaderText="Followup No." />
                <asp:BoundField DataField="DOV" HeaderText="DOV" />
                <asp:BoundField DataField="TOV" HeaderText="TOV" />
                <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                <asp:BoundField DataField="Required_Sachet_26" HeaderText="Required Sachet Q26" />
                <asp:BoundField DataField="Sachet_Received_27" HeaderText="Sachet Received Q27" />
                <asp:BoundField DataField="Sachet_used_by_PW_28" HeaderText="Sachet used by PW Q28" />
                <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                <asp:BoundField DataField="Xtra_Sachet_Used_by_PW" HeaderText="Xtra Sachet used by PW" />
                <asp:BoundField DataField="sra_name" HeaderText="SRA_Name" />
            </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>


        <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
               <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="form_crf_4_id" HeaderText="form_crf_4_id" />
                <asp:BoundField DataField="study_code" HeaderText="Study-ID" />
                <asp:BoundField DataField="followup_num" HeaderText="Followup No." />
                <asp:BoundField DataField="DOV" HeaderText="DOV" />
                <asp:BoundField DataField="TOV" HeaderText="TOV" />
                <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                <asp:BoundField DataField="Required_Sachet_26" HeaderText="Required Sachet Q26" />
                <asp:BoundField DataField="Sachet_Received_27" HeaderText="Sachet Received Q27" />
                <asp:BoundField DataField="Sachet_used_by_PW_28" HeaderText="Sachet used by PW Q28" />
                <asp:BoundField DataField="Percentage" HeaderText="Percentage" />
                <asp:BoundField DataField="Xtra_Sachet_Used_by_PW" HeaderText="Xtra Sachet used by PW" />
                <asp:BoundField DataField="sra_name" HeaderText="SRA_Name" />
            </Columns>
            
        </asp:GridView>
    </div>
</asp:Content>
