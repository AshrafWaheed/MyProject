using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace MyProject.Models
{
    public class Login
    {
        internal string UserId { get; set; }
        internal string Password { get; set; }
        string command, msg;
        DBManager dm= new DBManager();
        internal bool SaveLoginDetails(Login lg)
        {
            command = "insert into LoginMaster values('" + lg.UserId + "','" + lg.Password + "')";
            bool b = dm.ExecuteMyInsertUpdateOrDelete(command);
            return b;
        }

        internal bool ValidateUserLogin()
        {
            command = "Select *from LoginMaster where UserId='" + UserId + "' and Pass='" + Password + "'";
            DataTable dt=dm.ExecuteMySelect(command);
            if(dt.Rows.Count > 0 )
                return true;
            else 
                return false;
        }
    }
}