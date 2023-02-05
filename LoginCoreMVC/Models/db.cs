using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LoginCoreMVC.Models;

namespace LoginCoreMVC.Models
{
    public class db
    { 
        SqlConnection conn = new SqlConnection("Data Source=MCTX-ZAFEER\\SQLEXPRESS;Initial Catalog=ZKAbid_Db;Persist Security Info=True;User ID=sa;Password=sa@1234");
        public int checkLogin(Ad_login ad)
        {
            SqlCommand cmd = new SqlCommand("Sp_Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Admin_id", ad.Ad_id);
            cmd.Parameters.AddWithValue("@Password", ad.Ad_Password);
            // cmd.InsertCommand.Connection = connection1;
            SqlParameter objLogin = new SqlParameter();
            objLogin.ParameterName = "@isValid";
            objLogin.SqlDbType = SqlDbType.Bit;
            objLogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(objLogin);

            conn.Open();
            cmd.ExecuteNonQuery();
            int res = Convert.ToInt32(objLogin.Value);
            conn.Close();
            return res;
        }

    }
}
