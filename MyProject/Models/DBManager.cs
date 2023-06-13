using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyProject.Models
{
    public class DBManager
    {
        SqlConnection con = new SqlConnection("Data Source=WAHEED\\SQLEXPRESS;" +
            " Initial Catalog=ProjectDB; " +
            "Integrated Security=True");

        internal bool ExecuteMyInsertUpdateOrDelete(string CommandText )
        {
            try
            {
                SqlCommand cmd = new SqlCommand(CommandText, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int n = cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }

            
        }

         internal DataTable ExecuteMySelect(string CommandText )
        {
            SqlDataAdapter da= new SqlDataAdapter(CommandText, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }


    }
}