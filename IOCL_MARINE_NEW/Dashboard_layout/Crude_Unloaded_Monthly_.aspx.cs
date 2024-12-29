using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOCL_MARINE_NEW.AppCode;
using System.Data.SqlClient;
using System.Data;

namespace IOCL_MARINE_NEW.Dashboard_layout
{
    public partial class Crude_Unloaded_Monthly_ : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_MONTH(ddlmonth);
                    bind_grid();
                }
            }
            catch (Exception ex)
            { }
        }

        private void bind_grid()
        {
            string qry = "SELECT x.CrudMonthlyId,x.Mon_Id,a.Month,x.MmtMonthly";
            qry = qry + " FROM Crude_Unloaded_Monthly x,Month a WHERE a.Mon_Id=x.Mon_Id ORDER BY a.Mon_Id";
            DataTable dt = dal.getrec(qry);
            grid_Crude_unloaded_monthly.DataSource = dt;
            grid_Crude_unloaded_monthly.DataBind();

            grid_Crude_unloaded_monthly.UseAccessibleHeader = true;
            grid_Crude_unloaded_monthly.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btn_action(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.ID == "btnsubmit")
                {
                    if (btnsubmit.Text == "SUBMIT")
                    {
                        var check_duplicate_val = dal.getrec("SELECT * FROM Crude_Unloaded_Monthly WHERE Mon_Id="+ int.Parse(ddlmonth.SelectedItem.Value.ToString()) + "").Rows.Count;
                        if (check_duplicate_val == 0)
                        {
                            insert_Crude_unloaded_monthly();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Crude_Unloaded_Monthly_.aspx'</script>");
                        }
                    }
                    else
                    {
                        var check_duplicate_val_upd = 0;

                        if (ddlmonth.SelectedItem.Value.ToString() != HDN_month.Value)
                        {
                            check_duplicate_val_upd = dal.getrec("SELECT * FROM Crude_Unloaded_Monthly WHERE Mon_Id=" + int.Parse(ddlmonth.SelectedItem.Value.ToString()) + "").Rows.Count;
                        }
                        if (check_duplicate_val_upd == 0)
                        {
                            Update_Crude_unloaded_monthly();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Crude_Unloaded_Monthly_.aspx'</script>");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Crude_Unloaded_Monthly_.aspx");
                }
            }
            catch
            {
                Response.Write("<script>alert('FAILED');window.location.href='Crude_Unloaded_Monthly_.aspx'</script>");
            }
        }

        private void Update_Crude_unloaded_monthly()
        {
            string qry = "UPDATE Crude_Unloaded_Monthly SET Mon_Id=" + int.Parse(ddlmonth.SelectedItem.Value.ToString()) + "," +
            "MmtMonthly='" + txt_mmtmnothly.Text + "' WHERE CrudMonthlyId=" + int.Parse(lblCrudMonthlyId.Value) + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('UPDATED SUCCESSFULLY');window.location.href='Crude_Unloaded_Monthly_.aspx'</script>");
        }

        private void insert_Crude_unloaded_monthly()
        {
            string qry = "INSERT INTO Crude_Unloaded_Monthly(Mon_Id,MmtMonthly) VALUES(" + int.Parse(ddlmonth.SelectedItem.Value) + "," +
            "'" + txt_mmtmnothly.Text + "')";
            dal.Db_transact(qry);
            Response.Write("<script>alert('TRANSACTION SUCCESSFUL');window.location.href='Crude_Unloaded_Monthly_.aspx'</script>");
        }

        protected void grid_Crude_unloaded_monthly_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Crude_unloaded_monthly.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    Label lblmonthid = rw.FindControl("lblmonthid") as Label;
                    Label lblMmtMonthly = rw.FindControl("lblMmtMonthly") as Label;
                    lblCrudMonthlyId.Value = lblid.Text;
                    HDN_month.Value = lblmonthid.Text;
                    ddlmonth.ClearSelection();
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_MONTH(ddlmonth);
                    ddlmonth.Items.FindByValue(lblmonthid.Text).Selected = true;
                    txt_mmtmnothly.Text = lblMmtMonthly.Text;
                    btnsubmit.Text = "UPDATE";
                }
                if (e.CommandName == "DELETE")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Crude_unloaded_monthly.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    var delete_rec = "DELETE FROM Crude_Unloaded_Monthly WHERE CrudMonthlyId = " + int.Parse(lblid.Text) + "";
                    dal.Db_transact(delete_rec);
                    Response.Write("<script>alert('RECORD DELETED')</script>");
                }
                bind_grid();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Crude_Unloaded_Monthly_.aspx'</script>");
            }
        }

        protected void grid_Crude_unloaded_monthly_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grid_Crude_unloaded_monthly_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}