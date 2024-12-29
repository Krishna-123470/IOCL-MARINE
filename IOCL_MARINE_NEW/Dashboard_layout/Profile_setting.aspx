<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_layout/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="Profile_setting.aspx.cs" Inherits="IOCL_MARINE_NEW.Dashboard_layout.Profile_setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="app-main__outer">

    <div class="app-main__inner">
 
                    <div class="tab-content">
                        <div class="tab-pane tabs-animation fade active show" id="tab-content-0" role="tabpanel">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="main-card mb-3 card">
                                        <div class="card-body">
                                            <h5 class="card-title">CHANGE USER DETAIL</h5>
                                                
                                               <div class="row">
                                                   <div class="col-md-4">
                                                       <p>User Name</p>
                                                       <asp:textbox ID="txt_u_name" CssClass="form-control-sm form-control"  runat="server"></asp:textbox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="cum" ControlToValidate="txt_u_name"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                   </div>
                                                   <div class="col-md-4">
                                                       <p>User Email Id</p>
                                                       <asp:textbox ID="txt_mail" CssClass="form-control-sm form-control"  runat="server"></asp:textbox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="cum" ControlToValidate="txt_mail"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="cum" runat="server" ControlToValidate="txt_mail"
     ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    Display = "Dynamic" CssClass="validation_style" ErrorMessage = "Invalid email address"/>

                                                        </div>
                                                   <div class="col-md-4">
                                                       <p>Mobile No</p>
                                                       <asp:textbox ID="txt_phn_no" CssClass="form-control-sm form-control"  runat="server"></asp:textbox>
                                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_phn_no" ErrorMessage="Invalid Mobile No" CssClass="validation_style" Display="Dynamic"   ValidationGroup="cum" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                                         <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="cum" ControlToValidate="txt_phn_no"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>--%>
                                                   </div>
                                                   
                                                    <div class="col-md-1" style="margin-top: 2.3%;">
                                                        <asp:Button ID="btnupdate" ValidationGroup="cum" OnClick="btn_action"  CssClass="btn btn-primary mt_top" runat="server" Text="UPDATE" />
                                                      </div>
                                                    <div class="col-md-1" style="margin-top:2.3%;">
                                                        <asp:Button ID="btncal"  OnClick="btn_action"  CssClass="btn btn-danger mt_top" runat="server" Text="CANCEL" />
                                                      </div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
             
                    </div>
                </div>
                </div>
</asp:Content>
