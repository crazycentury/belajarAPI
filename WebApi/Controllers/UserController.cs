using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;

using WebApi.Models;
using WebApi.Logics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private string conString = "Server=localhost,1433;Database=WebAPI;User Id=sa;Password=Strong.Pwd-123;";
        [HttpPost]
        [Route("InsertName")]

        public ActionResult InsertName([FromBody]Users users)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Users([name]) VALUES (@paramName)";
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@paramName", SqlDbType = SqlDbType.VarChar, Value = users.name??""});
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                con.Close();
                con.Dispose();
                return Ok("Berhasil");

            }
            catch (Exception eror)
            {
                return BadRequest(eror.Message);
            }
        }

        [HttpPost]
        [Route("api/tasks/AddUserWithTask")]
        public ActionResult ContohTransaction([FromBody] Users body)
        {
            try
            {
                DBLogic.InsertUserWithTask(body);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region 
        [HttpGet]
        [Route("api/tasks/GetUserWithTask")]
        public ActionResult GetUserWithTask()
        {
            try
            {
                List<Users> result = DBLogic.GetUserWithTask();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion



        //    public ActionResult GetUsers()
        //    {
        //        List<UserModel> result = new List<UserModel>();
        //        DataTable dataTable = new DataTable();
        //        string query = "SELECT * FROM Users;";

        //        using
    }


};

