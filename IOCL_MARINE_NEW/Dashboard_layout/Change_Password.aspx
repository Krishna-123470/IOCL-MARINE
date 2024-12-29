<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_layout/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="IOCL_MARINE_NEW.Dashboard_layout.Change_Password" %>
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
                                            <h5 class="card-title">CHANGE PASSWORD</h5>
                                                   <div class="col-md-4">
                                                       <p>Old Password</p>
                                                       <asp:textbox ID="txt_old_pssd" CssClass="form-control-sm form-control"  runat="server"></asp:textbox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="cum" ControlToValidate="txt_old_pssd"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                   </div>
                                                   <div class="col-md-4" style="margin-top:10px">
                                                       <p>New Password</p>
                                                       <asp:textbox ID="txt_psswd" CssClass="form-control-sm form-control"  runat="server"></asp:textbox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="cum" ControlToValidate="txt_psswd"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                   </div>
                                                    <div class="col-md-4" style="margin-top:10px">
                                                       <p>Confirm Password</p>
                                                       <asp:textbox ID="txt_psswd_confirm" CssClass="form-control-sm form-control"  runat="server"></asp:textbox>
                                                         <asp:CompareValidator ID="CompareValidator1" runat="server"  ValidationGroup="cum" Display="Dynamic"
     ControlToValidate="txt_psswd_confirm"
     CssClass="validation_style"
     ControlToCompare="txt_psswd"
     ErrorMessage="No Match" 
     ToolTip="Password must be the same" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="cum" ControlToValidate="txt_psswd_confirm"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                   </div>
                                                    <div class="row">
                                                    <div class="col-md-1"  style="margin-top: 2.3%;">
                                                        <asp:Button ID="btnsubmit" ValidationGroup="cum" OnClick="btn_action"  CssClass="btn btn-primary mt_top" runat="server" Text="SUBMIT" />
                                                      </div>
                                                    <div class="col-md-1" style="margin-top:2.3%">
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
