using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOCL_MARINE_NEW.AppCode;
using System.Data.SqlClient;
using System.Data;

namespace IOCL_MARINE_NEW
{
    public partial class LOGIN : System.Web.UI.Page
    {
        DB_CON db = new DB_CON();
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "SELECT * FROM [dbo].[User] WHERE UserId='" + txt_userid.Text + "' AND Password='" + txt_password.Text + "'";
                DataTable dt = dal.getrec(qry);
                if (dt.Rows.Count > 0)
                {
                    Session["userid"] = dt.Rows[0]["UID"].ToString();
                    Session["roleid"] = dt.Rows[0]["RoleId"].ToString();
                    Response.Redirect("~/Dashboard_layout/index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('INVALID USER');window.location.href='LOGIN.aspx'</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('FAILED');window.location.href='LOGIN.aspx'</script>");
            }
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.ID == "btnsend")
                {
                    string qry = "SELECT * FROM [dbo].[User] WHERE UserId='" + txt_mail.Text + "'";
                    DataTable dt = dal.getrec(qry);
                    if (dt.Rows.Count > 0)
                    {

                        Send_mail(dt.Rows[0]["UserId"].ToString(), dt.Rows[0]["Password"].ToString());
                        Response.Write("<script>alert('MAIL SENT SUCCESSFULLY');window.location.href='LOGIN.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('MAIL ID NOT EXIST');window.location.href='LOGIN.aspx'</script>");
                    }
                }
                else
                {

                    Response.Redirect("LOGIN.aspx");
                }
                //login_pnl.Visible = false;
                //forgot_pssd.Visible = true;

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('FAILED');window.location.href='LOGIN.aspx'</script>");
            }
        }

        private void Send_mail(string uid, string passwd)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("paradiprefinery123@gmail.com");
            message.To.Add(new MailAddress(txt_mail.Text));
            message.Subject = "FORGOT PASSWORD";
            message.IsBodyHtml = false; //to make message body as html  
            message.Body = "USER NAME : " + uid + "\n PASSWORD : " + passwd + "";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ioclmarine@gmail.com", "Miocl2021");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        protected void btnforgot_pssd_Click(object sender, EventArgs e)
        {
            try
            {
                login_pnl.Visible = false;
                forgot_pssd.Visible = true;
            }
            catch
            {
            }
        }
    }
}