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
    public partial class Crude_Unloaded_Yearly_ : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_fin_year(ddlYear);
                    bind_grid();
                }
            }
            catch
            { }
        }

        private void bind_grid()
        {
            string qry = "SELECT x.CrudeYearId,x.Id,a.Year,x.MmtYear";
            qry = qry + " FROM Crude_Unloaded_Yearly x,Year a WHERE a.Id=x.Id";
            DataTable dt = dal.getrec(qry);
            grid_Crude_unloaded_yearly.DataSource = dt;
            grid_Crude_unloaded_yearly.DataBind();

            grid_Crude_unloaded_yearly.UseAccessibleHeader = true;
            grid_Crude_unloaded_yearly.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        
                        var check_duplicate_val = dal.getrec("SELECT * FROM Crude_Unloaded_Yearly WHERE Id=" + int.Parse(ddlYear.SelectedItem.Value.ToString()) + "").Rows.Count;
                        if (check_duplicate_val == 0)
                        {
                            insert_Crude_unload_yearly();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Crude_unloaded_yearly_.aspx'</script>");
                        }
                    }
                    else
                    {
                        var check_duplicate_val_upd = 0;

                        if (ddlYear.SelectedItem.Value.ToString() != HDN_year.Value)
                        {
                            check_duplicate_val_upd = dal.getrec("SELECT * FROM Crude_Unloaded_Yearly WHERE Id=" + int.Parse(ddlYear.SelectedItem.Value.ToString()) + "").Rows.Count;
                        }
                        if (check_duplicate_val_upd == 0)
                        {
                            Update_Crude_unload_yearly();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Crude_unloaded_yearly_.aspx'</script>");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Crude_unloaded_yearly_.aspx");
                }
            }
            catch
            {
                Response.Write("<script>alert('FAILED');window.location.href='Crude_unloaded_yearly_.aspx'</script>");
            }
        }

        private void Update_Crude_unload_yearly()
        {
            string qry = "UPDATE Crude_Unloaded_Yearly SET Id=" + int.Parse(ddlYear.SelectedItem.Value.ToString()) + "," +
            "MmtYear='" + txt_mmtYearly.Text + "' WHERE CrudeYearId=" + int.Parse(lblCrudYearId.Value) + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('UPDATED SUCCESSFULLY');window.location.href='Crude_unloaded_yearly_.aspx'</script>");
        }

        private void insert_Crude_unload_yearly()
        {
            string qry = "INSERT INTO Crude_Unloaded_Yearly(Id,MmtYear) VALUES(" + int.Parse(ddlYear.SelectedItem.Value) + "," +
            "'" + txt_mmtYearly.Text + "')";
            dal.Db_transact(qry);
            Response.Write("<script>alert('TRANSACTION SUCCESSFUL');window.location.href='Crude_unloaded_yearly_.aspx'</script>");
        }

        protected void grid_Crude_unloaded_yearly_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Crude_unloaded_yearly.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    Label lblyrid = rw.FindControl("lblyrid") as Label;
                    Label lblMmtYear = rw.FindControl("lblMmtYear") as Label;
                    lblCrudYearId.Value = lblid.Text;
                    HDN_year.Value = lblyrid.Text;
                    ddlYear.ClearSelection();
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_fin_year(ddlYear);
                    ddlYear.Items.FindByValue(lblyrid.Text).Selected = true;
                    txt_mmtYearly.Text = lblMmtYear.Text;
                    btnsubmit.Text = "UPDATE";
                }
                if (e.CommandName == "DELETE")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Crude_unloaded_yearly.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    var delete_rec = "DELETE FROM Crude_Unloaded_Yearly WHERE CrudeYearId = " + int.Parse(lblid.Text) + "";
                    dal.Db_transact(delete_rec);
                    Response.Write("<script>alert('RECORD DELETED')</script>");
                }
                bind_grid();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Crude_unloaded_yearly_.aspx'</script>");
            }
        }

        protected void grid_Crude_unloaded_yearly_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grid_Crude_unloaded_yearly_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}