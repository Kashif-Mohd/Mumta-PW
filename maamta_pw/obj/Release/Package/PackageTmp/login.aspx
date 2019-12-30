<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="maamta_pw.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mumta Trial PW</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src="js/index.js"></script>
    <link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>



    <link id="Link1" runat="server" rel="icon" href="~/assets/img/mom-child-orange.png" type="image/png" />
    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" />
    <style type="text/css">
        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            .forMob {
                padding-left: 20%;
            }
        }


        /* For Web Browser*/

        @media only screen and (min-width: 40em) {
            .forMob {
                padding-left: 38%;
            }
        }
    </style>
</head>
<body>
    <div class="login-page">
        <div class="form">
            <form class="login-form" id="form1" runat="server">
                <asp:Panel ID="panel1" runat="server">

                    <table style="width: 100%; margin-top: 120px;">
                        <tr>
                            <td class="forMob">
                                <table style="background-color: #41495c; border-collapse: collapse; border-radius: 6px; box-shadow: inset 0 0 1px #bdc3c7, 0 0 17px #95a5a6; width: 340PX; height: 380px; text-align: center">
                                    <tr style="background-color: #ff5533; height: 70px; font-family: Arial">
                                        <td class="auto-style1" style="color: ghostwhite; text-align: center; font-family: Arial;">
                                            <h4>Mumta Trial PW</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td style="padding-right: 20px; padding-left: 20px">
                                            <asp:TextBox ID="txtUserNme" runat="server" class="form-control" placeholder="username" MaxLength="30"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td style="padding-right: 20px; padding-left: 20px">
                                            <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control" placeholder="password" MaxLength="18"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding-right: 20px; padding-left: 20px">
                                            <asp:Button ID="btnLogin" runat="server" Text="SIGN IN" OnClick="btnLogin_Click" Style="padding: 10px" class="btn btn-theme btn-block" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr style="margin-bottom: 10px">
                                            <a href="http://www.vitalpakistan.org.pk/" target="_blank" style="color: #BFBFBF; text-align: center; font-size: 10px; font-family: Arial">VITAL Pakistan Trust (VPT)</a></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </form>
        </div>
    </div>


    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script>
          $.backstretch("assets/img/pw_back.jpg", { speed: 500 });
        //$.backstretch("assets/img/aablur.jpg", { speed: 500 });
    </script>

</body>
</html>
