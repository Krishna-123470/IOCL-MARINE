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
    public partial class Turn_Arround_Time_graph : System.Web.UI.Page
    {
        DAL dal = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_grid();
            }
        }

        private void bind_grid()
        {
            string qry = "select b.Year Year1, a.TurnArroundTime TurnArroundTime,a.TankerNumber TankerNumber From Turn_Arround_Time a,Year b Where a.Id = b.Id ORDER BY b.Year";
            gdv_turn_arnd_time.DataSource = dal.getrec(qry);
            gdv_turn_arnd_time.DataBind();
        }

        [System.Web.Services.WebMethod]
        public static dynamic turn_arnd_time()
        {
            List<Turn_Arround_Time> adts = new List<Turn_Arround_Time>();
            DAL dal = new DAL();
            string qry = "select b.Year Year1, a.TurnArroundTime TurnArroundTime,a.TankerNumber TankerNumber From Turn_Arround_Time a,Year b Where a.Id = b.Id ORDER BY b.Year";
            DataTable dt = dal.getrec(qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Turn_Arround_Time adt = new Turn_Arround_Time();
                adt.Year1 = dt.Rows[i]["Year1"].ToString();
                adt.TankerNumber = dt.Rows[i]["TankerNumber"].ToString();
                adt.TurnArroundTime = dt.Rows[i]["TurnArroundTime"].ToString();
                adts.Add(adt);
            }
            return adts;
        }
    }
}