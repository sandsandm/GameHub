using System.Windows.Input;

namespace GameHub.ViewModels;

public class ChessCountViewModel : BindableObject
{
    private int _team1Score;
    private int _team2Score;

    public int Team1Score
    {
        get => _team1Score;
        set
        {
            if (_team1Score == value) return;
            _team1Score = value;
            OnPropertyChanged(nameof(Team1Score));
        }
    }

    public int Team2Score
    {
        get => _team2Score;
        set
        {
            if (_team2Score == value) return;
            _team2Score = value;
            OnPropertyChanged(nameof(Team2Score));
        }
    }

    public ICommand Team1PlusCommand { get; }
    public ICommand Team1MinusCommand { get; }
    public ICommand Team2PlusCommand { get; }
    public ICommand Team2MinusCommand { get; }
    public ICommand ResetCommand { get; }
    public ChessCountViewModel()
	{
        Team1PlusCommand = new Command(() => Team1Score++);
        Team1MinusCommand = new Command(() =>
        {
            if (Team1Score > 0)
                Team1Score--;
        });

        Team2PlusCommand = new Command(() => Team2Score++);
        Team2MinusCommand = new Command(() =>
        {
            if (Team2Score > 0)
                Team2Score--;
        });

        ResetCommand = new Command(() =>
        {
            Team1Score = 0;
            Team2Score = 0;
        });

    }
}