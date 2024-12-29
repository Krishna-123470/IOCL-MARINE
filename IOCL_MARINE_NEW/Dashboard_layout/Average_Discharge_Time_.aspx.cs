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
    public partial class Average_Discharge_Time_ : System.Web.UI.Page
    {
        DB_CON db = new DB_CON();
        Average_Discharge_Time adt = new Average_Discharge_Time();
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
            string qry = "SELECT a.DischargeId,a.Id,a.TankerNumber,a.TurnArroundTime,b.Year ";
            qry = qry+ " FROM Average_Discharge_Time a,Year b WHERE a.Id=b.Id";
            DataTable dt = dal.getrec(qry);

            grid_avg_disc_time.DataSource = dt;
            grid_avg_disc_time.DataBind();
            grid_avg_disc_time.UseAccessibleHeader = true;
            grid_avg_disc_time.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        var check_duplicate_val = "SELECT * FROM Average_Discharge_Time WHERE Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "";
                        if (dal.getrec(check_duplicate_val).Rows.Count == 0)
                        {
                            insert_Average_disc_time();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Average_Discharge_Time_.aspx'</script>");
                        }
                    }
                    else
                    {
                        var check_duplicate_val_upd = 0;

                        if (ddlyr.SelectedItem.Value.ToString() != lblyr.Value)
                        {
                            string qry = "SELECT * FROM Average_Discharge_Time WHERE Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "";
                            check_duplicate_val_upd = dal.getrec(qry).Rows.Count;
                        }
                        if (check_duplicate_val_upd == 0)
                        {
                            Update_Average_disc_time();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Average_Discharge_Time_.aspx'</script>");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Average_Discharge_Time_.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Average_Discharge_Time_.aspx'</script>");
            }
        }

        private void Update_Average_disc_time()
        {
            string qry = "UPDATE Average_Discharge_Time SET Id="+ int.Parse(ddlyr.SelectedItem.Value.ToString()) + ","+
            "TankerNumber='"+ txt_TankerNumber.Text + "',TurnArroundTime='"+txt_TurnArroundTime.Text+ "' WHERE DischargeId="+ int.Parse(lblDischargeId.Value) + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('UPDATED SUCCESSFULLY');window.location.href='Average_Discharge_Time_.aspx'</script>");
        }

        private void insert_Average_disc_time()
        {
            string  qry = "INSERT INTO Average_Discharge_Time(Id,TankerNumber,TurnArroundTime) VALUES("+ int.Parse(ddlyr.SelectedItem.Value) + "," +
            "'" + txt_TankerNumber.Text + "','" + txt_TurnArroundTime.Text + "')";
            dal.Db_transact(qry);
            Response.Write("<script>alert('TRANSACTION SUCCESSFUL');window.location.href='Average_Discharge_Time_.aspx'</script>");
        }

        protected void grid_avg_disc_time_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_avg_disc_time.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    Label lblyr_id = rw.FindControl("lblyrid") as Label;
                    Label lblTankerNumber = rw.FindControl("lblTankerNumber") as Label;
                    Label lblTurnArroundTime = rw.FindControl("lblTurnArroundTime") as Label;
                    lblDischargeId.Value = lblid.Text;
                    lblyr.Value = lblyr_id.Text;
                    ddlyr.ClearSelection();
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_fin_year(ddlyr);
                    ddlyr.Items.FindByValue(lblyr_id.Text).Selected = true;
                    txt_TankerNumber.Text = lblTankerNumber.Text;
                    txt_TurnArroundTime.Text = lblTurnArroundTime.Text;
                    btnsubmit.Text = "UPDATE";
                }
                if (e.CommandName == "DELETE")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_avg_disc_time.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    var delete_rec = "DELETE FROM Average_Discharge_Time WHERE DischargeId = "+int.Parse(lblid.Text)+"";
                    dal.Db_transact(delete_rec);
                    Response.Write("<script>alert('RECORD DELETED')</script>");
                }
                bind_grid();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Average_Discharge_Time_.aspx'</script>");
            }
        }

        protected void grid_avg_disc_time_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grid_avg_disc_time_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}