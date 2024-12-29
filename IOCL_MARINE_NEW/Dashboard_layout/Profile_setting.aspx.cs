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
    public partial class Profile_setting : System.Web.UI.Page
    {
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
                        txt_mail.Text = dt.Rows[0]["UserEmail"].ToString();
                        txt_u_name.Text = dt.Rows[0]["UserName"].ToString();
                        txt_phn_no.Text = dt.Rows[0]["Mobile"].ToString();
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
        protected void btn_action(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.ID == "btnupdate")
                {
                    update_user(int.Parse(Session["userid"].ToString()));
                    Response.Write("<script>alert('Record Updated');window.location.href='Profile_setting.aspx'</script>");
                }
                else
                {
                    Response.Redirect("Profile_setting.aspx");
                }
            }
            catch
            {
                Response.Write("<script>alert('FAILED');window.location.href='Profile_setting.aspx'</script>");
            }
        }

        private void update_user(int userid)
        {
            var upd_details = "UPDATE [dbo].[User] SET UserName='" + txt_u_name.Text + "',UserId='" + txt_mail.Text + "'," +
            "UserEmail='" + txt_mail.Text + "',Mobile='" + txt_phn_no.Text + "' WHERE UID=" + userid + "";
            dal.Db_transact(upd_details);
        }
    }
}