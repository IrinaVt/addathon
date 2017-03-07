using AddathonDerby.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace AddathonDerby.Controllers
{
    public class SturgeonController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int id)
        {
            TeamsModel model = new TeamsModel();
            if (id <= 0) return View(model);
            model = LoadAll(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult AndyAdmin()
        {
            var model = LoadAll(0);
            return View(model);
        }

        [HttpGet]
        public ActionResult Team(int id)
        {
            var model = new TeamModel();
            model.TeamId = id;
            // Load scores
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("select name from sturgeonteams where id = @team_id", con))
                    {
                        command.Parameters.Add(new SqlParameter("team_id", model.TeamId));
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.TeamName = reader.GetString(0);
                            }
                        }
                        reader.Close();
                    }

                    using (SqlCommand command = new SqlCommand("select slot, score from sturgeonscores where team_id = @team_id", con))
                    {
                        command.Parameters.Add(new SqlParameter("team_id", model.TeamId));
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.SetScore(reader.GetInt32(0), reader.GetInt32(1));
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Team(TeamModel model)
        {
            // Load scores
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                try
                {
                    string password = null;
                    using (SqlCommand command = new SqlCommand("select id, secret_string from sturgeonteams where team_id = @team_id", con))
                    {
                        command.Parameters.Add(new SqlParameter("name", model.TeamId));
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.TeamId = reader.GetInt32(0);
                                password = reader.GetString(1);
                            }
                        }
                        reader.Close();
                    }

                    if (model.Password != password)
                    {
                        model.ErrorMessage = "Invalid password";
                        return View(model);
                    }


                    using (SqlCommand command = new SqlCommand(@"if exists(select * from sturgeonscores where team_Id = @teamId and slot = @slot)
begin

    update sturgeonscores set score = @score where team_Id = @teamId and slot = @slot
end
else
begin

    insert sturgeonscores(team_id, slot, score) values(@teamId, @slot, @score)
end", con))
                    {
                        var parameterTeamId = command.Parameters.Add(new SqlParameter("teamId", model.TeamId));
                        var parameterSlot = command.Parameters.Add(new SqlParameter("slot", model.TeamId));
                        var parameterScore = command.Parameters.Add(new SqlParameter("score", model.TeamId));

                        // Update scores
                        for (int i = 1; i < 51; i++)
                        {
                            parameterSlot.Value = i;
                            parameterScore.Value = model.GetScore(i);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Index", "Sturgeon", new { id = model.TeamId });
        }

        private TeamsModel LoadAll(int derbyId)
        {
            var model = new TeamsModel();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                try
                {
                    // Load teams
                    using (SqlCommand command = new SqlCommand("select id, name, secret_string from sturgeonteams where derby_id = @derby_id", con))
                    {
                        command.Parameters.Add(new SqlParameter("derby_id", derbyId));
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.Teams.Add(new TeamModel()
                                {
                                    TeamName = reader["name"].ToString(),
                                    Password = reader["secret_string"].ToString(),
                                    TeamId = reader.GetInt32(0)
                                });
                            }
                        }
                        reader.Close();
                    }

                    // Load scores
                    using (SqlCommand command = new SqlCommand(@"select s.team_id, s.slot, s.score 
from sturgeonscores s
	join sturgeonteams t on s.team_id = t.id
where t.derby_id = @derby_id", con))
                    {
                        command.Parameters.Add(new SqlParameter("derby_id", derbyId));
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var team = model.Teams.First(x => x.TeamId == reader.GetInt32(0));
                                team.SetScore(reader.GetInt32(1), reader.GetInt32(2));
                            }
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return model;
        }

        [HttpGet]
        public ActionResult AndyEditTeam(int id)
        {
            var model = new TeamModel();
            model.TeamId = id;
            // Load scores
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("select name, secret_string from sturgeonteams where id = @id", con))
                    {
                        command.Parameters.Add(new SqlParameter("id", model.TeamId));
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                model.TeamName = reader.GetString(0);
                                model.Password = reader.GetString(1);
                            }
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AndyEditTeam(TeamModel team)
        {
            // Load scores
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(@"update sturgeonteams set name = @name, secret_string = @secret_string " +
                        "where id = @teamId", con))
                    {
                        var parameterTeamId = command.Parameters.Add(new SqlParameter("teamId", team.TeamId));
                        var parameterSlot = command.Parameters.Add(new SqlParameter("name", team.TeamName));
                        var parameterScore = command.Parameters.Add(new SqlParameter("secret_string", team.Password));
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("AndyAdmin");
        }
    }

}