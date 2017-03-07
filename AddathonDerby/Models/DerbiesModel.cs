using System.Collections.Generic;

namespace AddathonDerby.Models
{
    public class DerbiesModel
    {
        public List<DerbyModel> Derbies { get; set; }

        public DerbiesModel()
        {
            Derbies = new List<DerbyModel>();
        }
    }
}