using System.Collections.Generic;

namespace AddathonDerby.Models
{
    public class TeamsModel
    {
        public List<TeamModel> Teams { get; set; }

        public TeamsModel()
        {
            Teams = new List<TeamModel>();
        }
    }
}