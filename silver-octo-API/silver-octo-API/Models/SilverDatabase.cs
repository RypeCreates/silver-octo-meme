using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;
using silver_octo_API.Models;

namespace silver_octo_API.Models
{
    public class SilverDatabase
    {
        // TODO: need to add functional Db connection string here
        SqlConnection connection = new SqlConnection("");

        public int LoginCheck(Login login)
        {
            SqlCommand command = new SqlCommand("Sp_Login",connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", login.Id);
            command.Parameters.AddWithValue("@Password", login.Password);

            SqlParameter oblogin = new SqlParameter
            {
                ParameterName = "@Isvalid",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(oblogin);

            int res = Convert.ToInt32(oblogin.Value);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return res;
        }
    }
}
