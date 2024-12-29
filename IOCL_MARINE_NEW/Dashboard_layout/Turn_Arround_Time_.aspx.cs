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
    public partial class Turn_Arround_Time_ : System.Web.UI.Page
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
            string qry = "SELECT x.TurnArroundId,x.Id,a.Year,x.TankerNumber,x.TurnArroundTime";
            qry = qry + " FROM Turn_Arround_Time x,Year a WHERE a.Id=x.Id";
            DataTable dt = dal.getrec(qry);
            grid_turn_arnd_time.DataSource = dt;
            grid_turn_arnd_time.DataBind();

            grid_turn_arnd_time.UseAccessibleHeader = true;
            grid_turn_arnd_time.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        
                        var check_duplicate_val = dal.getrec("SELECT * FROM Turn_Arround_Time WHERE Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "").Rows.Count;
                        if (check_duplicate_val == 0)
                        {
                            insert_ta_time();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Turn_Arround_Time_.aspx'</script>");
                        }
                    }
                    else
                    {
                        var check_duplicate_val_upd = 0;

                        if (ddlyr.SelectedItem.Value.ToString() != HDN_year.Value)
                        {
                            check_duplicate_val_upd = dal.getrec("SELECT * FROM Turn_Arround_Time WHERE Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "").Rows.Count;
                        }
                        if (check_duplicate_val_upd == 0)
                        {
                            Update_ta_time();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Turn_Arround_Time_.aspx'</script>");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Turn_Arround_Time_.aspx");
                }
            }
            catch
            {
                Response.Write("<script>alert('FAILED');window.location.href='Turn_Arround_Time_.aspx'</script>");
            }
        }

        private void Update_ta_time()
        {
            string qry = "UPDATE Turn_Arround_Time SET Id=" + int.Parse(ddlyr.SelectedItem.Value.ToString()) + "," +
            "TankerNumber='" + txt_tot_tanker.Text + "',TurnArroundTime='"+ txt_turn_arnd_time .Text+ "' WHERE TurnArroundId=" + int.Parse(lblTurnArroundId.Value) + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('UPDATED SUCCESSFULLY');window.location.href='Turn_Arround_Time_.aspx'</script>");
        }

        private void insert_ta_time()
        {
            string qry = "INSERT INTO Turn_Arround_Time(Id,TankerNumber,TurnArroundTime) VALUES(" + int.Parse(ddlyr.SelectedItem.Value) + "," +
            "'" + txt_tot_tanker.Text + "','"+ txt_turn_arnd_time.Text + "')";
            dal.Db_transact(qry);
            Response.Write("<script>alert('TRANSACTION SUCCESSFUL');window.location.href='Turn_Arround_Time_.aspx'</script>");
        }

        protected void grid_turn_arnd_time_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_turn_arnd_time.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    Label lblyr_id = rw.FindControl("lblyrid") as Label;
                    Label lblTotal_Tanker = rw.FindControl("lblTotal_Tanker") as Label;
                    Label lblta_time = rw.FindControl("lblta_time") as Label;
                    lblTurnArroundId.Value = lblid.Text;
                    HDN_year.Value = lblyr_id.Text;
                    ddlyr.ClearSelection();
                    PArent_CL.parentcl((DashboardMaster)this.Master).bind_fin_year(ddlyr);
                    ddlyr.Items.FindByValue(lblyr_id.Text).Selected = true;
                    txt_tot_tanker.Text = lblTotal_Tanker.Text;
                    txt_turn_arnd_time.Text = lblta_time.Text;
                    btnsubmit.Text = "UPDATE";
                }
                if (e.CommandName == "DELETE")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_turn_arnd_time.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    var delete_rec = "DELETE FROM Turn_Arround_Time WHERE TurnArroundId = " + int.Parse(lblid.Text) + "";
                    dal.Db_transact(delete_rec);
                    Response.Write("<script>alert('RECORD DELETED')</script>");
                }
                bind_grid();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Turn_Arround_Time_.aspx'</script>");
            }
        }

        protected void grid_turn_arnd_time_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grid_turn_arnd_time_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}