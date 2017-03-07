using System;

namespace AddathonDerby.Models
{
    public class DerbyModel
    {
        public int DerbyId { get; set; }

        public string DerbyName { get; set; }

        public DateTime DerbyDate { get; set; }

        public bool IsOpen { get; set; }

        public string ShortName { get; set; }
    }
}