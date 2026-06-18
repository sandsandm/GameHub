using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GameHub.Models
{
    public class Team : INotifyPropertyChanged
    {
        private int score;
        public string Name { get; set; }
        public List<string> Players { get; set; } = new();

        public int Score
        {
            get => score;
            set
            {
                if (score != value)
                {
                    score = value;
                    OnPropertyChanged(nameof(Score));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
