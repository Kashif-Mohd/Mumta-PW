<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="del_crf1.aspx.cs" Inherits="maamta_pw.del_crf1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <asp:UpdateProgress ID="updateProgress" runat="server">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                        <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #ff7675; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>




            <div style="padding-left: 2%; margin-top: 15px;">
                <div style="color: #ff6b6b; font-size: 22px; width: 100%">
                    Ultrasound Form Dummy Data &nbsp(Edit and Delete Records):
                </div>
                <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px"/>


                <%--Search Button--%>
                <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 13px; margin-top: 27px;">
                    <div id="imaginary_container">
                        <div class="input-group stylish-input-group">
                            <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                            <span class="input-group-addon">
                                <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>



                <div style="width: 100%; height: 490px; overflow: scroll; margin-top: 10px">
                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="unique_id" HeaderText="unique_id" runat="server" />
                            <asp:BoundField DataField="vr_id" HeaderText="vr_id" runat="server" />
                            <asp:BoundField DataField="no_of_fetus" HeaderText="No. of Fetus" runat="server" />
                            <asp:BoundField DataField="assis_id" HeaderText="assis_id" runat="server" />
                            <asp:BoundField DataField="date_of_attempt" HeaderText="Date of Attempt" />
                            <asp:BoundField DataField="dssid" HeaderText="DSSID" runat="server" />
                            <asp:BoundField DataField="woman_name" HeaderText="Woman Name" runat="server" />
                            <asp:BoundField DataField="husband_name" HeaderText="Husband Name" />
                            <asp:BoundField DataField="server_datetime" HeaderText="server_date" />
                            <asp:BoundField DataField="task_crf2" HeaderText="task_crf2" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link_Delete" OnClick="Link_Delete" Text='Delete' runat="server" ToolTip="Delete Record" CommandArgument='<%#Eval("assis_id")%>' OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
