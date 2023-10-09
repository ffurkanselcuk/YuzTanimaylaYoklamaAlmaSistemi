using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
namespace YuzTanima
{
   public  class classFunction
    {
        classCommon commonclases = new classCommon();
        ConnectionString cs = new ConnectionString();
        public void LogFunc(string st1, DateTime st2, string st3)
        {

            commonclases.con = new SqlConnection(cs.DBConn);
            commonclases.con.Open();
            string cb = "insert into Logs(UserID,Date,Operation) VALUES (@d1,@d2,@d3)";
            commonclases.cmd = new SqlCommand(cb);
            commonclases.cmd.Connection = commonclases.con;
            commonclases.cmd.Parameters.AddWithValue("@d1",st1);
            commonclases.cmd.Parameters.AddWithValue("@d2",st2);
            commonclases.cmd.Parameters.AddWithValue("@d3",st3);
            commonclases.con.Close();
        }
    }
}
