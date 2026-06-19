using GameHub.Models;
using GameHub.ViewModels;

namespace GameHub.Views.Modules;

public partial class ScoreBoardView : ContentView
{
    public ScoreBoardView()
    {
        InitializeComponent();
        BindingContext = new ScoreBoardViewModel();
        TeamsList.ItemsSource = TeamStore.Teams;
    }

    private void OnScoreChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && entry.BindingContext is Team team)
        {
            if (int.TryParse(e.NewTextValue, out int newScore))
            {
                team.Score = newScore;
            }
        }
    }
}