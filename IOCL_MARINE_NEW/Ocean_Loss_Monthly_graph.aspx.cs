using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IOCL_MARINE_NEW.AppCode;
using System.Data.SqlClient;
using System.Data;

namespace IOCL_MARINE_NEW
{
    public partial class Ocean_Loss_Monthly_graph : System.Web.UI.Page
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
            string qry = "select b.Month Month1, a.KlPercentage KlPercentage From Ocean_Loss_Monthly a,Month b Where a.Mon_Id = b.Mon_Id ORDER BY b.Mon_Id";
            gdv_ocean_loss_monthly.DataSource = dal.getrec(qry);
            gdv_ocean_loss_monthly.DataBind();
        }
        [System.Web.Services.WebMethod]
        public static dynamic ocean_loss_monthly()
        {
            List<Ocean_Loss_Monthly> adts = new List<Ocean_Loss_Monthly>();
            DAL dal = new DAL();
            string qry = "select b.Month Month1, a.KlPercentage KlPercentage From Ocean_Loss_Monthly a,Month b Where a.Mon_Id = b.Mon_Id ORDER BY b.Mon_Id";
            DataTable dt = dal.getrec(qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ocean_Loss_Monthly adt = new Ocean_Loss_Monthly();
                adt.Month1 = dt.Rows[i]["Month1"].ToString();
                adt.KlPercentage = dt.Rows[i]["KlPercentage"].ToString();
                adts.Add(adt);
            }
            return adts;
        }
    }
}