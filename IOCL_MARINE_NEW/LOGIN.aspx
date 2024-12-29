<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOGIN.aspx.cs" Inherits="IOCL_MARINE_NEW.LOGIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="Content-Language" content="en" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <meta name="viewport"
        content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, shrink-to-fit=no" />
    <script>
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
    <!-- Disable tap highlight on IE -->

<link href="Dashboard_layout/main.d810cf0ae7f39f28f336.css" rel="stylesheet" />
      <style>
        .validation_style{
            color:firebrick;
             font-size:12px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="app-container app-theme-white body-tabs-shadow">
        <div class="app-container">
            <div class="h-100 bg-plum-plate bg-animation">
                <div class="d-flex h-100 justify-content-center align-items-center">
                    <div class="mx-auto app-login-box col-md-8">
                        <div class="modal-dialog w-100 mx-auto">
                            <div class="modal-content"  id="login_pnl" runat="server" >
                                <div class="modal-body">
                                    <div class="h5 modal-title text-center">
                                            <a href="Default.aspx"><img src="images/iocl.gif" /></a>
                                        <h4 class="mt-2">
                                            <span>Please sign in to your account below.</span>
                                        </h4>
                                    </div>
                                        <div class="form-row">
                                            <div class="col-md-12">
                                                <div class="position-relative form-group">
                                                     <label for="exampleEmail" class="">USER ID</label>
                                                <asp:TextBox ID="txt_userid" CssClass="form-control" placeholder="Enter UserId Here ..." runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="entr" ControlToValidate="txt_userid" CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This field cannot be blank ..."></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="position-relative form-group">
                                                    <label for="examplePassword" class="">PASSWORD</label>
                                                <asp:TextBox ID="txt_password" CssClass="form-control" TextMode="Password" placeholder="Password here..." runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="entr" ControlToValidate="txt_password" CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This field cannot be blank ..."></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                
                                   
                                </div>
                                <div class="modal-footer clearfix">
                                    <div class="float-left">
                                        <%--<a href="#" id="btn_fgt_psd" runat="server" class="btn-lg btn btn-link" >Forgot Password</a>--%>
                                        <asp:Button ID="btnforgot_pssd" CssClass="btn btn-primary btn-lg" OnClick="btnforgot_pssd_Click" runat="server" Text="Forgot Password" />
                                    </div>
                                    <div class="float-right">
                                        <asp:Button ID="btnlogin" CssClass="btn btn-primary btn-lg" ValidationGroup="entr" OnClick="btnlogin_Click" runat="server" Text="Login" />
                                    </div>
                                </div>
                            </div>

                            <div class="modal-content" id="forgot_pssd" runat="server" visible="false">
                                <div class="modal-body">
                                    <div class="h5 modal-title text-center">
                                            <a href="Default.aspx"><img src="images/iocl.gif" /></a>
                                    </div>
                                      <div class="form-row">
                                            <div class="col-md-12">
                                                <div class="position-relative form-group">
                                                     <label for="exampleEmail" class="">MAIL ID</label>
                                                <asp:TextBox ID="txt_mail" CssClass="form-control" placeholder="Enter MAIL Id Here ..." runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="fgtpsd" ControlToValidate="txt_mail" CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This field cannot be blank ..."></asp:RequiredFieldValidator>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="fgtpsd" runat="server" ControlToValidate="txt_mail"
     ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    Display = "Dynamic" CssClass="validation_style" ErrorMessage = "Invalid email address"/>

                                                     </div>
                                            </div>
                                        </div>
                                </div>
                                <div class="modal-footer clearfix">
                                     <div class="float-left">
                                        <a href="LOGIN.aspx" class="btn btn-danger btn-lg" >Cancel</a>
                                    </div>
                                    <div class="float-right">
                                        <asp:Button ID="btnsend" CssClass="btn btn-primary btn-lg" OnClick="btnsend_Click"  ValidationGroup="fgtpsd"  runat="server" Text="Send" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <script src="js/jquery_3_min.js"></script>
<script type="text/javascript" src="Dashboard_layout/assets/scripts/main.d810cf0ae7f39f28f336.js"></script>
       <%-- <script>
            $(document).ready(function () {
                $('#btn_fgt_psd').click(function () {
                    $('#login_pnl').hide();
                    $('#forgot_pssd').slideToggle("fast");
         });
    });
  
</script>--%>
    </form>
</body>
</html>
