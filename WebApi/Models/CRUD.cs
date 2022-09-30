using System;

using System.Data;
using System.Data.SqlClient;
namespace WebApi.Models
{
    public static class CRUD
    {
        private static string conString = "Server=localhost,1433;Database=WebAPI;User Id=sa;Password=Strong.Pwd-123;";

        #region ExecuteQuery
        /// <summary>
        /// ExecuteQuery untuk menjalankan query yang return banyak data
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] sqlParams = null)
        {
            DataTable result = new DataTable();

            // begin connection
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                #region query process to database
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (sqlParams != null) cmd.Parameters.AddRange(sqlParams);

                    // mengisi dengan SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(result);
                }
                #endregion

                // close connection
                con.Close();
            }

            return result;
        }
        #endregion

    }
}

