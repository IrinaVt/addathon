using AddathonDerby.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace AddathonDerby.Controllers
{
    public class BaseController : Controller
    {
        protected readonly string _connectionString;

        public BaseController()
        {
            _connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];
        }

        protected DerbiesModel GetDerbies()
        {
            var model = new DerbiesModel();
            // Load scores
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("select id, name, event_date, is_open, short_name from sturgeonderbies", con))
                    {
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.Derbies.Add(new DerbyModel()
                                {
                                    DerbyId = reader.GetInt32(0),
                                    DerbyName = reader.GetString(1),
                                    DerbyDate = reader.GetDateTime(2),
                                    IsOpen = reader.GetBoolean(3),
                                    ShortName = reader.GetString(4)
                                });
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return model;
        }
    }
}