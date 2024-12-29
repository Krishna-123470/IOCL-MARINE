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
    public partial class Tanker_Milestone_graph : System.Web.UI.Page
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
            catch { }
        }

        private void bind_grid()
        {
            string qry = "select * From Tanker_Milestone";
            gdv_Tanker_Milestone.DataSource = dal.getrec(qry);
            gdv_Tanker_Milestone.DataBind();

        }
        [System.Web.Services.WebMethod]
        public static dynamic tanker_milestone()
        {
            List<Tanker_Milestone> adts = new List<Tanker_Milestone>();
            DAL dal = new DAL();
            string qry = "select a.Date Date1, a.TankerNumber TankerNumber From Tanker_Milestone a order by a.Date";
            DataTable dt = dal.getrec(qry);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tanker_Milestone adt = new Tanker_Milestone();
                adt.Date1 = Convert.ToDateTime(dt.Rows[i]["Date1"]);
                adt.TankerNumber = dt.Rows[i]["TankerNumber"].ToString();
                adts.Add(adt);
            }
            return adts;
        }
    }
}