<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_layout/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="Ocean_Loss_Monthly_.aspx.cs" Inherits="IOCL_MARINE_NEW.Dashboard_layout.Ocean_Loss_Monthly_" %>
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
                                            <h5 class="card-title">Ocean Loss Monthly</h5>
                                                <div class="row" style="margin-bottom:24px">
                                                    <asp:HiddenField ID="lblOceanMonthlyId" Value="" runat="server" />
                                                    <div class="col-md-4">
                                                    <label for="exampleEmail" class="">Select Month</label>
                                                        <asp:DropDownList ID="ddlmonth" CssClass="form-control-sm form-control"   runat="server"></asp:DropDownList>
                                                        <asp:HiddenField ID="HDN_month" Value="" runat="server" />
                                                        
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="cum" ControlToValidate="ddlmonth" InitialValue="0" CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="Please Select ..."></asp:RequiredFieldValidator>
                                                      </div>
                                                    <div class="col-md-4">
                                                    <label for="exampleEmail" class="">KIP Percentage</label>
                                                        <asp:TextBox ID="txt_KlPercentage"  CssClass="form-control-sm form-control num"  runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="cum" ControlToValidate="txt_KlPercentage"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                      </div>
                                                    <div class="col-md-1" style="margin-top: 1%;">
                                                        <asp:Button ID="btnsubmit" ValidationGroup="cum" OnClick="btn_action"  CssClass="btn btn-primary mt_top" runat="server" Text="SUBMIT" />
                                                      </div>
                                                    <div class="col-md-1" style="margin-top: 1%;">
                                                        <asp:Button ID="btncal"  OnClick="btn_action"  CssClass="btn btn-danger mt_top" runat="server" Text="CANCEL" />
                                                      </div>
                                                </div>
                                               <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:GridView ID="grid_Ocean_Loss_Monthly" CssClass="table table-hover table-striped table-bordered mt_top sorting_" OnRowDeleting="grid_Ocean_Loss_Monthly_RowDeleting" OnRowEditing="grid_Ocean_Loss_Monthly_RowEditing" OnRowCommand="grid_Ocean_Loss_Monthly_RowCommand" AutoGenerateColumns="false" runat="server">
                                                            <Columns>
                                                        <asp:TemplateField HeaderText="Transaction Id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("OceanLossId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Month">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmonthid" Visible="false" runat="server" Text='<%# Eval("Mon_Id") %>'></asp:Label>
                                                                <asp:Label ID="lblmonth" runat="server" Text='<%# Eval("Month") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="KIP Percentage">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblKlPercentage" runat="server" Text='<%# Eval("KlPercentage") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LnkEdit" CssClass="btn btn-primary" CommandName="Edit" CommandArgument='<%# ((GridViewRow) Container).RowIndex  %>' Style="color: #fff" Text="EDIT" runat="server"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DELETE">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Lnkdlt" CssClass="btn btn-danger" CommandName="DELETE" OnClientClick="return ConfirmationBox();" CommandArgument='<%# ((GridViewRow) Container).RowIndex  %>' Style="color: #fff" Text="DELETE" runat="server"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                        </asp:GridView>
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
  <script src="assets/jquery_2_min.js"></script>
  <script>
      $(document).ready(function () {
          $(".num").keypress(function (event) {
              return isNumber(event, this);
          });
      });
      function isNumber(evt, element) {
          var charCode = (evt.which) ? evt.which : event.keyCode
          if (
              (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
              (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
              (charCode < 48 || charCode > 57))
              return false;
          return true;
      }
</script>
    <script type="text/javascript">
        function ConfirmationBox() {
            var result = confirm('Are you sure you want to delete Details');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
        //$(function () {
        //    $(".sorting_").DataTable(
        //    {
        //        bLengthChange: true,
        //        lengthMenu: [[5, 10, -1], [5, 10, "All"]],
        //        bFilter: true,
        //        bSort: true,
        //        bPaginate: true
        //    });
        //});
</script>

</asp:Content>
