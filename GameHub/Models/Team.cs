using System;
using System.Collections.Generic;
using System.Text;

namespace GameHub.Models
{
    public class Team
    {
        public string Name { get; set; }
        public List<string> Players { get; set; } = new();
        public int Score { get; set; }
    }
}
