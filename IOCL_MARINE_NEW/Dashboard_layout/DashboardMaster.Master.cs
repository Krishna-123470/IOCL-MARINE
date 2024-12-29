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
    public partial class DashboardMaster : System.Web.UI.MasterPage
    {
        DB_CON db = new DB_CON();
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["userid"] != null && Session["userid"] != "")
                    {
                        string qry = "SELECT * FROM [dbo].[User] WHERE UID=" + int.Parse(Session["userid"].ToString()) + "";
                        DataTable dt = dal.getrec(qry);
                        lblnm0.Text = dt.Rows[0]["UserName"].ToString();
                        lblnm1.Text = dt.Rows[0]["UserName"].ToString();
                        if (Session["roleid"].ToString() == "1")
                        {
                            uid_.Visible = true;
                        }
                        else
                        {
                            uid_.Visible = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("../logout.aspx");
                    }
                }
            }
            catch
            {

            }
        }
        public void bind_fin_year(DropDownList ddl)
        {
            var get_fin_year = "SELECT * FROM Year";
            DataTable dt = dal.getrec(get_fin_year);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataTextField = "Year";
                ddl.DataValueField = "Id";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-- select financial year --", "0"));
            }
        }
        public void bind_MONTH(DropDownList ddl)
        {
            var get_month = "SELECT * FROM Month";
            DataTable dt = dal.getrec(get_month);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataTextField = "Month";
                ddl.DataValueField = "Mon_Id";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-- select month --", "0"));
            }
        }
    }
}