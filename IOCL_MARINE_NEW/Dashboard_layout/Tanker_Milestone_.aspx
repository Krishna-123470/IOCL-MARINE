<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_layout/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="Tanker_Milestone_.aspx.cs" Inherits="IOCL_MARINE_NEW.Dashboard_layout.Tanker_Milestone_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/CALENDER_JQUERY_MIN.js"></script>
    <script src="../js/CALENDER_JQUERY.js"></script>
    <link href="../css/CALENDER_UI.css" rel="stylesheet" />
     <script>
         $(function () {
             $("#ContentPlaceHolder1_txt_date").datepicker({
                 showOn: "button",
                 buttonImage: '../images/cal.png',
                 buttonImageOnly: true,
                 changeMonth: true,
                 changeYear: true,
                 yearRange: "-60:+0",
                 dateFormat: 'dd-mm-yy'
             });
         });

      </script>
    <style>
        .ui-datepicker-trigger {
          position: absolute !important;
    right: 5% !important;
    height: 17px !important;
    margin-top: 8.5% !important;
        }
        </style>
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
                                            <h5 class="card-title">Tanker Milestone</h5>
                                                <div class="row" style="margin-bottom:24px">
                                                    <asp:HiddenField ID="lblTanker_Milestone" Value="" runat="server" />
                                                    <div class="col-md-4">
                                                    <label for="exampleEmail" class="">Date</label>
                                                  <asp:TextBox ID="txt_date" AutoComplete="off"  CssClass="form-control-sm form-control typ_dt1" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="HDN_dt_" Value="" runat="server" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="cum" ControlToValidate="txt_date"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                      </div>
                                                    <div class="col-md-4">
                                                    <label for="exampleEmail" class="">Tank Number</label>
                                                        <asp:TextBox ID="txt_Tanker_no"  CssClass="form-control-sm form-control num"  runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="cum" ControlToValidate="txt_Tanker_no"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
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
                                                        <asp:GridView ID="grid_Tanker_Milestone" CssClass="table table-hover table-striped table-bordered mt_top sorting_" OnRowDeleting="grid_Tanker_Milestone_RowDeleting" OnRowEditing="grid_Tanker_Milestone_RowEditing" OnRowCommand="grid_Tanker_Milestone_RowCommand" AutoGenerateColumns="false" runat="server">
                                                            <Columns>
                                                        <asp:TemplateField HeaderText="Transaction Id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("MilestoneId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tanker Number">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTanker_no" runat="server" Text='<%# Eval("TankerNumber") %>'></asp:Label>
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
