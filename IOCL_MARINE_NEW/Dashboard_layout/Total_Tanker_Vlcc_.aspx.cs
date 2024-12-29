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
    public partial class Total_Tanker_Vlcc_ : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_fin_year(ddlyr);
                    bind_grid();
                }
            }
            catch
            { }
        }

        private void bind_grid()
        {
            string qry = "SELECT x.VLCCId,x.Id,a.Year,x.Total_Tanker,x.VLCC";
            qry = qry + " FROM Total_Tanker_Vlcc x,Year a WHERE a.Id=x.Id";
            DataTable dt = dal.getrec(qry);
            grid_vlcc.DataSource = dt;
            grid_vlcc.DataBind();

            grid_vlcc.UseAccessibleHeader = true;
            grid_vlcc.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        var check_duplicate_val = dal.getrec("SELECT * FROM Total_Tanker_Vlcc WHERE Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "").Rows.Count;
                        if (check_duplicate_val == 0)
                        {
                            insert_VLCC();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Total_Tanker_Vlcc_.aspx'</script>");
                        }
                    }
                    else
                    {
                        var check_duplicate_val_upd = 0;

                        if (ddlyr.SelectedItem.Value.ToString() != HDN_year.Value)
                        {
                            check_duplicate_val_upd = dal.getrec("SELECT * FROM Total_Tanker_Vlcc WHERE Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "").Rows.Count;
                        }
                        if (check_duplicate_val_upd == 0)
                        {
                            Update_VLCC();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Total_Tanker_Vlcc_.aspx'</script>");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Total_Tanker_Vlcc_.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Total_Tanker_Vlcc_.aspx'</script>");
            }
        }

        private void Update_VLCC()
        {
            string qry = "UPDATE Total_Tanker_Vlcc SET Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "," +
            "Total_Tanker='" + txt_tot_tanker.Text + "',VLCC='" + txtvlcc.Text + "' WHERE VLCCId=" + int.Parse(lblvlccid.Value) + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('UPDATED SUCCESSFULLY');window.location.href='Total_Tanker_Vlcc_.aspx'</script>");
        }

        private void insert_VLCC()
        {
            string qry = "INSERT INTO Total_Tanker_Vlcc(Id,Total_Tanker,VLCC) VALUES(" + int.Parse(ddlyr.SelectedItem.Value) + "," +
            "'" + txt_tot_tanker.Text + "','" + txtvlcc.Text + "')";
            dal.Db_transact(qry);
            Response.Write("<script>alert('TRANSACTION SUCCESSFUL');window.location.href='Total_Tanker_Vlcc_.aspx'</script>");
        }

        protected void grid_vlcc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_vlcc.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    Label lblyr_id = rw.FindControl("lblyrid") as Label;
                    Label lblTotal_Tanker = rw.FindControl("lblTotal_Tanker") as Label;
                    Label lblvlcc = rw.FindControl("lblvlcc") as Label;
                    lblvlccid.Value = lblid.Text;
                    HDN_year.Value = lblyr_id.Text;
                    ddlyr.ClearSelection();
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_fin_year(ddlyr);
                    ddlyr.Items.FindByValue(lblyr_id.Text).Selected = true;
                    txt_tot_tanker.Text = lblTotal_Tanker.Text;
                    txtvlcc.Text = lblvlcc.Text;
                    btnsubmit.Text = "UPDATE";
                }
                if (e.CommandName == "DELETE")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_vlcc.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    var delete_rec = "DELETE FROM Total_Tanker_Vlcc WHERE VLCCId = " + int.Parse(lblid.Text) + "";
                    dal.Db_transact(delete_rec);
                    Response.Write("<script>alert('RECORD DELETED')</script>");
                }
                bind_grid();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Total_Tanker_Vlcc_.aspx'</script>");
            }
        }

        protected void grid_vlcc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grid_vlcc_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}