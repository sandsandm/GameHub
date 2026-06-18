using GameHub.Models;

namespace GameHub.Views
{
    public partial class AddTeamPage : ContentPage
    {
        private List<string> players = new();

        public AddTeamPage()
        {
            InitializeComponent();
        }

        private void OnAddPlayerClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerEntry.Text))
            {
                players.Add(PlayerEntry.Text);
                PlayersList.ItemsSource = null;
                PlayersList.ItemsSource = players;
                PlayerEntry.Text = "";
            }
        }

        private async void OnSaveTeamClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TeamNameEntry.Text)) return;

            var team = new Team
            {
                Name = TeamNameEntry.Text,
                Players = new List<string>(players),
                Score = 0
            };

            TeamStore.Teams.Add(team);

            
            TeamNameEntry.Text = "";
            PlayerEntry.Text = "";
            players.Clear();
            PlayersList.ItemsSource = null;
            PlayersList.ItemsSource = players;

            await DisplayAlert("Готово", $"Команда «{team.Name}» сохранена", "ОК");

            
        }
    }
}
