using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace IOCL_MARINE_NEW.AppCode
{
    public class DB_CON
    {
        public SqlConnection con;
        public DB_CON()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOCL_GRAPHConnectionString"].ToString());
        }
    }
}