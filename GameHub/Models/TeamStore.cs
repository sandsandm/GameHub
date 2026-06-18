using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GameHub.Models
{
   public static class TeamStore
    {
        public static ObservableCollection<Team> Teams { get; set; } = new();
    }
}
