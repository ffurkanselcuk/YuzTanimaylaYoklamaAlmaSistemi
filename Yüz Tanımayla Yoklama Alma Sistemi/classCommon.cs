using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Text;

using System.Data.SqlClient;
namespace YuzTanima
{
    public class classCommon
    {
       public SqlDataReader rdr = null;
       public DataTable dtable = new DataTable();
       public SqlConnection con = null;
       public SqlCommand cmd = null;
       public DataSet ds;
       public SqlDataAdapter da;
    }
}
