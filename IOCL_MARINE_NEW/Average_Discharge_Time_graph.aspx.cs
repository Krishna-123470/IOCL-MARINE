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
    public partial class Average_Discharge_Time_graph : System.Web.UI.Page
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
            string qry = "select b.Year Year1, a.TurnArroundTime TurnArroundTime,a.TankerNumber TankerNumber From Average_Discharge_Time a,Year b Where a.Id = b.Id ORDER BY b.Year";
            gdv_avg_dis_time.DataSource = dal.getrec(qry);
            gdv_avg_dis_time.DataBind();

        }

        [System.Web.Services.WebMethod]
        public static dynamic Avg_dis_time()
        {
            List<Average_Discharge_Time> adts = new List<Average_Discharge_Time>();
            DAL dal = new DAL();
            string qry = "select b.Year Year1, a.TurnArroundTime TurnArroundTime,a.TankerNumber TankerNumber From Average_Discharge_Time a,Year b Where a.Id = b.Id ORDER BY b.Year";
            DataTable dt = dal.getrec(qry);
            for (int i=0;i < dt.Rows.Count;i++)
            {
                Average_Discharge_Time adt = new Average_Discharge_Time();
                adt.Year1 = dt.Rows[i]["Year1"].ToString();
                adt.TurnArroundTime = dt.Rows[i]["TurnArroundTime"].ToString();
                adt.TankerNumber = dt.Rows[i]["TankerNumber"].ToString();
                adts.Add(adt);
            }
            return adts;
        }
    }
}