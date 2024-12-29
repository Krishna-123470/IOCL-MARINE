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
    public partial class Total_Tanker_Vlcc_graph : System.Web.UI.Page
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
            string qry = "select b.Year Year1, a.Total_Tanker Total_Tanker, a.VLCC VLCC From Total_Tanker_Vlcc a,Year b Where a.Id = b.Id ORDER BY b.Year";
            gdv_vlcc.DataSource = dal.getrec(qry);
            gdv_vlcc.DataBind();

        }
        [System.Web.Services.WebMethod]
        public static dynamic Total_Tanker_Vlcc()
        {
            List<Total_Tanker_Vlcc> adts = new List<Total_Tanker_Vlcc>();
            DAL dal = new DAL();
            string qry = "select b.Year Year1, a.Total_Tanker Total_Tanker, a.VLCC VLCC From Total_Tanker_Vlcc a,Year b Where a.Id = b.Id ORDER BY b.Year";
            DataTable dt = dal.getrec(qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Total_Tanker_Vlcc adt = new Total_Tanker_Vlcc();
                adt.Year1 = dt.Rows[i]["Year1"].ToString();
                adt.Total_Tanker = dt.Rows[i]["Total_Tanker"].ToString();
                adt.VLCC = dt.Rows[i]["VLCC"].ToString();
                adts.Add(adt);
            }
            return adts;
        }
    }
}