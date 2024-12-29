<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_layout/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="Average_Discharge_Time_.aspx.cs" Inherits="IOCL_MARINE_NEW.Dashboard_layout.Average_Discharge_Time_" %>
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
                                            <h5 class="card-title">Average Discharge Time</h5>
                                                <div class="row" style="margin-bottom:24px">
                                                    <asp:HiddenField ID="lblDischargeId" Value="" runat="server" />
                                                    <div class="col-md-4">
                                                    <label for="exampleEmail" class="">Select Financial Year</label>
                                                        <asp:DropDownList ID="ddlyr"  CssClass="form-control-sm form-control"   runat="server"></asp:DropDownList>
                                                        <asp:HiddenField ID="lblyr" Value="" runat="server" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="adt" ControlToValidate="ddlyr" InitialValue="0" CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="Please Select ..."></asp:RequiredFieldValidator>
                                                      </div>
                                                    <div class="col-md-4">
                                                    <label for="exampleEmail" class="">Tanker Number</label>
                                                        <asp:TextBox ID="txt_TankerNumber"  CssClass="form-control-sm form-control num"  runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="adt" ControlToValidate="txt_TankerNumber"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                      </div>
                                                     <div class="col-md-4">
                                                    <label for="exampleEmail" class="">Turn Arround Time</label>
                                                        <asp:TextBox ID="txt_TurnArroundTime"  CssClass="form-control-sm form-control num"  runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="adt" ControlToValidate="txt_TurnArroundTime"  CssClass="validation_style" Display="Dynamic" runat="server" ErrorMessage="This Field Can't be blank ..."></asp:RequiredFieldValidator>
                                                      </div>
                                                    <div class="col-md-1">
                                                        <asp:Button ID="btnsubmit" ValidationGroup="adt" OnClick="btn_action"  CssClass="btn btn-primary mt_top" runat="server" Text="SUBMIT" />
                                                      </div>
                                                    <div class="col-md-1">
                                                        <asp:Button ID="btncal"  OnClick="btn_action"  CssClass="btn btn-danger mt_top" runat="server" Text="CANCEL" />
                                                      </div>
                                                </div>
                                               <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:GridView ID="grid_avg_disc_time" CssClass="table table-hover table-striped table-bordered mt_top sorting_" OnRowDeleting="grid_avg_disc_time_RowDeleting" OnRowEditing="grid_avg_disc_time_RowEditing" OnRowCommand="grid_avg_disc_time_RowCommand" AutoGenerateColumns="false" runat="server">
                                                            <Columns>
                                                        <asp:TemplateField HeaderText="Transaction Id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server" Text='<%# Eval("DischargeId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Year">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblyrid" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                                <asp:Label ID="lblyr" runat="server" Text='<%# Eval("Year") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tanker Number">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTankerNumber" runat="server" Text='<%# Eval("TankerNumber") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Turn Arround Time">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTurnArroundTime" runat="server" Text='<%# Eval("TurnArroundTime") %>'></asp:Label>
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
    $(document).ready(function() {
        $(".num").keypress(function(event){ 
            return isNumber(event, this);
        });
    });
    //$("#ContentPlaceHolder1_ddlyr").change(function () {
    //    $("#ContentPlaceHolder1_lblyr").val($("#ContentPlaceHolder1_ddlyr").val())
    //})
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
