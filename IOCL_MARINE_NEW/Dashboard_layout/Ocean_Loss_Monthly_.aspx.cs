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
    public partial class Ocean_Loss_Monthly_ : System.Web.UI.Page
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
            catch
            { }
        }

        private void bind_grid()
        {
            
            string qry = "SELECT x.OceanLossId,x.Mon_Id,a.Month,x.KlPercentage";
            qry = qry + " FROM Ocean_Loss_Monthly x,Month a WHERE a.Mon_Id=x.Mon_Id";
            DataTable dt = dal.getrec(qry);
            grid_Ocean_Loss_Monthly.DataSource = dt;
            grid_Ocean_Loss_Monthly.DataBind();

            grid_Ocean_Loss_Monthly.UseAccessibleHeader = true;
            grid_Ocean_Loss_Monthly.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        
                        var check_duplicate_val = dal.getrec("SELECT * FROM Ocean_Loss_Monthly WHERE Mon_Id=" + int.Parse(ddlmonth.SelectedItem.Value.ToString()) + "").Rows.Count;
                        if (check_duplicate_val == 0)
                        {
                            insert_Ocean_Loss_Monthly();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Ocean_Loss_Monthly_.aspx'</script>");
                        }

                    }
                    else
                    {
                        var check_duplicate_val_upd = 0;

                        if (ddlmonth.SelectedItem.Value.ToString() != HDN_month.Value)
                        {
                            check_duplicate_val_upd = dal.getrec("SELECT * FROM Ocean_Loss_Monthly WHERE Mon_Id=" + int.Parse(ddlmonth.SelectedItem.Value.ToString()) + "").Rows.Count;
                        }
                        if (check_duplicate_val_upd == 0)
                        {
                            Update_Ocean_Loss_Monthly();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Ocean_Loss_Monthly_.aspx'</script>");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Ocean_Loss_Monthly_.aspx");
                }
            }
            catch
            {
                Response.Write("<script>alert('FAILED');window.location.href='Ocean_Loss_Monthly_.aspx'</script>");
            }
        }

        private void Update_Ocean_Loss_Monthly()
        {
            string qry = "UPDATE Ocean_Loss_Monthly SET Mon_Id=" + int.Parse(ddlmonth.SelectedItem.Value.ToString()) + "," +
            "KlPercentage='" + txt_KlPercentage.Text + "' WHERE OceanLossId=" + int.Parse(lblOceanMonthlyId.Value) + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('UPDATED SUCCESSFULLY');window.location.href='Ocean_Loss_Monthly_.aspx'</script>");
        }

        private void insert_Ocean_Loss_Monthly()
        {
            string qry = "INSERT INTO Ocean_Loss_Monthly(Mon_Id,KlPercentage) VALUES(" + int.Parse(ddlmonth.SelectedItem.Value) + "," +
            "'" + txt_KlPercentage.Text + "')";
            dal.Db_transact(qry);
            Response.Write("<script>alert('TRANSACTION SUCCESSFUL');window.location.href='Ocean_Loss_Monthly_.aspx'</script>");
        }

        protected void grid_Ocean_Loss_Monthly_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Ocean_Loss_Monthly.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    Label lblmonthid = rw.FindControl("lblmonthid") as Label;
                    Label lblKlPercentage = rw.FindControl("lblKlPercentage") as Label;
                    lblOceanMonthlyId.Value = lblid.Text;
                    HDN_month.Value = lblmonthid.Text;
                    ddlmonth.ClearSelection();
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_MONTH(ddlmonth);
                    ddlmonth.Items.FindByValue(lblmonthid.Text).Selected = true;
                    txt_KlPercentage.Text = lblKlPercentage.Text;
                    btnsubmit.Text = "UPDATE";
                }
                if (e.CommandName == "DELETE")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Ocean_Loss_Monthly.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    var delete_rec = "DELETE FROM Ocean_Loss_Monthly WHERE OceanLossId = " + int.Parse(lblid.Text) + "";
                    dal.Db_transact(delete_rec);
                    Response.Write("<script>alert('RECORD DELETED')</script>");
                }
                bind_grid();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Ocean_Loss_Monthly_.aspx'</script>");
            }
        }

        protected void grid_Ocean_Loss_Monthly_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grid_Ocean_Loss_Monthly_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}