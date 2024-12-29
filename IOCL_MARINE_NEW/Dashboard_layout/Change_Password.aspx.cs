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
    public partial class Change_Password : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_action(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.ID == "btnsubmit")
                {

                    var check_old_pssd = dal.getrec("SELECT * FROM [dbo].[User] where UID=" + int.Parse(Session["userid"].ToString()) + " AND Password='"+ txt_old_pssd.Text + "'").Rows.Count;
                    if (check_old_pssd > 0)
                    {
                        update_password(int.Parse(Session["userid"].ToString()));
                    }
                    else
                    {
                        Response.Write("<script>alert('Incorrect Old Password');window.location.href='Change_Password.aspx'</script>");
                    }
                }
                else
                {
                    Response.Redirect("Change_Password.aspx");
                }
            }
            catch
            {
                Response.Write("<script>alert('FAILED');window.location.href='Change_Password.aspx'</script>");
            }
        }

        private void update_password(int userid)
        {
            string qry = "UPDATE [dbo].[User] SET Password='" + txt_psswd.Text + "' WHERE UID=" + userid + "";
            dal.Db_transact(qry);
            Response.Write("<script>alert('Password Updated');window.location.href='Change_Password.aspx'</script>");
        }


    }
}