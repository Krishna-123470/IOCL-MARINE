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
    public partial class Default : System.Web.UI.Page
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
            string qry = "select b.Year Year1, a.MmtYear MmtYear From Crude_Unloaded_Yearly a,Year b Where a.Id = b.Id ORDER BY b.Year";
            gdv_crd_yearly.DataSource = dal.getrec(qry);
            gdv_crd_yearly.DataBind();

        }
        [System.Web.Services.WebMethod]
        public static dynamic crude_onloaded_yearly()
        {
            List<Crude_Unloaded_Yearly> adts = new List<Crude_Unloaded_Yearly>();
            DAL dal = new DAL();
            string qry = "select b.Year Year1, a.MmtYear MmtYear From Crude_Unloaded_Yearly a,Year b Where a.Id = b.Id ORDER BY b.Year";
            DataTable dt = dal.getrec(qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Crude_Unloaded_Yearly adt = new Crude_Unloaded_Yearly();
                adt.Year1 = dt.Rows[i]["Year1"].ToString();
                adt.MmtYear = dt.Rows[i]["MmtYear"].ToString();
                adts.Add(adt);
            }
            return adts;
        }
    }
}