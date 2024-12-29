using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOCL_MARINE_NEW.AppCode;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace IOCL_MARINE_NEW.Dashboard_layout
{
    public partial class Tanker_Milestone_ : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bind_grid();
                }
            }
            catch
            { }
        }

        private void bind_grid()
        {
            var get_Tanker_Milestone_detail = "SELECT * FROM Tanker_Milestone";
            DataTable dt = dal.getrec(get_Tanker_Milestone_detail);
            grid_Tanker_Milestone.DataSource = dt;
            grid_Tanker_Milestone.DataBind();

            grid_Tanker_Milestone.UseAccessibleHeader = true;
            grid_Tanker_Milestone.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void btn_action(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string s = txt_date.Text;
                DateTime dts = DateTime.ParseExact(s, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                if (btn.ID == "btnsubmit")
                {
                    if (btnsubmit.Text == "SUBMIT")
                    {
                        
                        var check_duplicate_val = dal.getrec("SELECT * FROM Tanker_Milestone WHERE Date='" + dts.ToString("yyyy-MM-dd") + "'").Rows.Count;
                        if (check_duplicate_val == 0)
                        {
                            insert_Tanker_Milestone();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Tanker_Milestone_.aspx'</script>");
                        }

                    }
                    else
                    {
                        var check_duplicate_val_upd = 0;

                        if (txt_date.Text != HDN_dt_.Value)
                        {
                            check_duplicate_val_upd = dal.getrec("SELECT * FROM Tanker_Milestone WHERE Date='" + dts.ToString("yyyy-MM-dd") + "'").Rows.Count;
                        }
                        if (check_duplicate_val_upd == 0)
                        {
                            Update_Tanker_Milestone();
                        }
                        else
                        {
                            Response.Write("<script>alert('Already Exist');window.location.href='Tanker_Milestone_.aspx'</script>");
                        }

                    }
                }
                else
                {
                    Response.Redirect("Tanker_Milestone_.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Tanker_Milestone_.aspx'</script>");
            }
        }

        private void Update_Tanker_Milestone()
        {
            string s = txt_date.Text;
            DateTime dts = DateTime.ParseExact(s, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            string qry = "UPDATE Tanker_Milestone SET Date='" + dts.ToString("yyyy-MM-dd") + "'," +
            "TankerNumber='" + txt_Tanker_no.Text + "' WHERE MilestoneId=" + int.Parse(lblTanker_Milestone.Value) + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('UPDATED SUCCESSFULLY');window.location.href='Tanker_Milestone_.aspx'</script>");
        }

        private void insert_Tanker_Milestone()
        {
            string s = txt_date.Text;
            DateTime dts = DateTime.ParseExact(s, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            string qry = "INSERT INTO Tanker_Milestone(Date,TankerNumber) VALUES('" + dts.ToString("yyyy-MM-dd") + "'," +
            "'" + txt_Tanker_no.Text + "')";
            dal.Db_transact(qry);
            Response.Write("<script>alert('TRANSACTION SUCCESSFUL');window.location.href='Tanker_Milestone_.aspx'</script>");
        }

        protected void grid_Tanker_Milestone_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Tanker_Milestone.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    Label lbldate = rw.FindControl("lbldate") as Label;
                    Label lblTanker_no = rw.FindControl("lblTanker_no") as Label;
                    lblTanker_Milestone.Value = lblid.Text;
                    txt_date.Text = lbldate.Text;
                    HDN_dt_.Value = lbldate.Text;
                    txt_Tanker_no.Text = lblTanker_no.Text;
                    btnsubmit.Text = "UPDATE";
                }
                if (e.CommandName == "DELETE")
                {
                    int rwindx = int.Parse(e.CommandArgument.ToString());
                    GridViewRow rw = grid_Tanker_Milestone.Rows[rwindx];
                    Label lblid = rw.FindControl("lblid") as Label;
                    var delete_rec = "DELETE FROM Tanker_Milestone WHERE MilestoneId = " + int.Parse(lblid.Text) + "";
                    dal.Db_transact(delete_rec);
                    Response.Write("<script>alert('RECORD DELETED')</script>");
                }
                bind_grid();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='Tanker_Milestone_.aspx'</script>");
            }
        }

        protected void grid_Tanker_Milestone_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grid_Tanker_Milestone_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}