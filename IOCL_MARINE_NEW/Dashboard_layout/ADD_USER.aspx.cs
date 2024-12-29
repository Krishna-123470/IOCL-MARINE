using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;
using IOCL_MARINE_NEW.AppCode;
using System.Data.SqlClient;
using System.Data;

namespace IOCL_MARINE_NEW.Dashboard_layout
{
    public partial class ADD_USER : System.Web.UI.Page
    {
        int row_affect = 0;

        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btn_action(object sender, EventArgs e)
        {
            int userid = 0;
            try
            {
                Button btn = (Button)sender;
                if (btn.ID == "btnsubmit")
                {

                    var check_user_dtl = "SELECT * FROM [dbo].[User] where UserId='" + txt_mail.Text + "'"; 

                    if (dal.getrec(check_user_dtl).Rows.Count == 0)
                    {
                        insert_user(out row_affect, out userid);
                        //row_affect = 1;
                        if (row_affect > 0)
                        {
                            Send_mail();
                        }
                        Response.Write("<script>alert('Record Inserted');window.location.href='ADD_USER.aspx'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Mail ID Already Exist');window.location.href='ADD_USER.aspx'</script>");
                    }
                }
                else
                {

                    Response.Redirect("ADD_USER.aspx");
                }
            }
            catch (Exception ex)
            {
                if (userid != 0)
                {
                   
                    var delete_rec = "DELETE FROM [dbo].[User] WHERE UID = " + userid + "";
                    dal.Db_transact(delete_rec);
                }
                Response.Write("<script>alert('FAILED');window.location.href='ADD_USER.aspx'</script>");
            }
        }

        private void Send_mail()
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("paradiprefinery123@gmail.com");
            message.To.Add(new MailAddress(txt_mail.Text));
            message.Subject = "USER DETAILS (" + txt_u_name.Text + ")";
            message.IsBodyHtml = false; //to make message body as html  
            message.Body = "USER NAME : " + txt_mail.Text + "\n PASSWORD : " + txt_psswd.Text + " \n MAIL ID : " + txt_mail.Text + "";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ioclmarine@gmail.com", "Miocl2021");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            //SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            //using (MailMessage mm = new MailMessage(smtpSection.From, txt_mail.Text.Trim()))
            //{
            //    mm.Subject = "USER DETAILS ("+txt_u_name.Text+")";
            //    mm.Body = "USER NAME : "+ txt_mail.Text + "\n PASSWORD : " + txt_psswd.Text +"";
            //    mm.IsBodyHtml = false;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = smtpSection.Network.Host;
            //    smtp.EnableSsl = smtpSection.Network.EnableSsl;
            //    NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
            //    smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
            //    smtp.Credentials = networkCred;
            //    smtp.Port = smtpSection.Network.Port;
            //    smtp.Send(mm);
            //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email sent.');", true);
            //}

        }

        private void insert_user(out int row_affected, out int uid)
        {
            string qry = "INSERT INTO [dbo].[User](UserName,Password,Mobile,UserEmail,UserId,RoleId) VALUES('" + txt_u_name.Text + "'," +
            "'" + txt_psswd.Text + "','" + txt_phn_no.Text + "','"+ txt_mail.Text + "','"+ txt_mail.Text + "',2)";
            dal.Db_transact(qry);
            string qry1 = "select max(UID) from [dbo].[User]";
            uid = int.Parse(dal.getrec(qry1).Rows[0][0].ToString());
            row_affected = 1;
        }
    }
}