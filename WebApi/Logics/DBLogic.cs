using System;
using System.Data;
using System.Data.SqlClient;

using WebApi.Models;

namespace WebApi.Logics
{
    public static class DBLogic
    {
        private static string conString = "Server=localhost,1433;Database=WebAPI;User Id=sa;Password=Strong.Pwd-123;";

        /// <summary>
        /// Insert user data with list of product, handle with transaction schema
        /// </summary>
        public static string InsertUserWithTask(Users user)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.Transaction = con.BeginTransaction();

                    try
                    {
                        cmd.CommandText = "INSERT INTO Users([name]) VALUES (@name); SELECT SCOPE_IDENTITY();";
                        cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = user.name ?? "" });

                        decimal pk_id = (decimal)cmd.ExecuteScalar(); // SCOPE_IDENTITY() type is decimal
                        cmd.Parameters.Clear();

                        foreach (Models.Task task in user.tasks) //ini isinya apa
                        {
                            cmd.CommandText = "INSERT INTO Tasks(task_detail, fk_user_id) VALUES (@task_detail, @fk_user_id)";
                            cmd.Parameters.Add(new SqlParameter("@task_detail", SqlDbType.VarChar) { Value = task.task_detail ?? "" });
                            cmd.Parameters.Add(new SqlParameter("@fk_user_id", SqlDbType.Int) { Value = pk_id });

                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }

                        cmd.Transaction.Commit();
                        con.Close();
                        return "Success";
                    }
                    catch
                    {
                        cmd.Transaction.Rollback();
                        con.Close();
                        throw;
                    }

                } // end SqlCommand

            } // end SqlConnection
        }

        public static List <Users> GetUserWithTask()
        {
            List<Users> ListOf = new List<Users>();
            string queryUsers = "SELECT*FROM Users";
            DataTable TableUser = CRUD.ExecuteQuery(queryUsers);
            string queryTask = "SELECT pk_tasks_id, task_detail FROM Tasks WHERE fk_user_id=@userid";

            foreach(DataRow rowUser in TableUser.Rows)
                {
                    List<Models.Task> ListTask = new List<Models.Task>();
                    int tempUserid = (int)rowUser["pk_id"];
                    SqlParameter[] sqlParams =  new SqlParameter[]
                    {
                        new SqlParameter("@userid",SqlDbType.Int){Value=tempUserid}
                    };

                    DataTable TableTask = CRUD.ExecuteQuery(queryTask, sqlParams);
                    foreach(DataRow rowTask in TableTask.Rows)
                    {
                        Models.Task task = new Models.Task
                        {
                            pk_tasks_id = (int)rowTask["pk_tasks_id"],
                            task_detail = (string)rowTask["task_detail"]
                        };
                        ListTask.Add(task);
                    }
                    Users users = new Users
                    {
                        pk_id = tempUserid,
                        name = (string)rowUser["name"],
                        tasks = ListTask
                    };
                    ListOf.Add(users);
                }

            return ListOf;
        }

        

    }
}

