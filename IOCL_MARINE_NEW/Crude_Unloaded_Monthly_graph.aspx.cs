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
    public partial class Crude_Unloaded_Monthly_graph : System.Web.UI.Page
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
            {

            }
        }

        private void bind_grid()
        {
            string qry = "select b.Month Month1, a.MmtMonthly MmtMonthly From Crude_Unloaded_Monthly a,Month b Where a.Mon_Id = b.Mon_Id ORDER BY b.Mon_Id";
            gdv_crd_monthly.DataSource = dal.getrec(qry);
            gdv_crd_monthly.DataBind();
        }

        [System.Web.Services.WebMethod]
        public static dynamic crude_onloaded_monthly()
        {
           
            List<Crude_Unloaded_Monthly> adts = new List<Crude_Unloaded_Monthly>();
            DAL dal = new DAL();
            string qry = "select b.Month Month1,b.Mon_Id Mon_Id, a.MmtMonthly MmtMonthly From Crude_Unloaded_Monthly a,Month b Where a.Mon_Id = b.Mon_Id ORDER BY b.Mon_Id";
            DataTable dt = dal.getrec(qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Crude_Unloaded_Monthly adt = new Crude_Unloaded_Monthly();
                adt.Month1 = dt.Rows[i]["Month1"].ToString();
                adt.MmtMonthly = dt.Rows[i]["MmtMonthly"].ToString();
                adt.Mon_Id = int.Parse(dt.Rows[i]["Mon_Id"].ToString());
                adts.Add(adt);
            }
            return adts;
        }
    }
}