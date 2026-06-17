namespace GameHub.ViewModels;
using GameHub.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class PlayerRandomizerViewModel : BaseViewModel
{
    private string _newPlayerName;
    private string _winnerName;
    private Random _random = new Random();

    public ObservableCollection<Player> Players { get; set; }

    public string NewPlayerName
    {
        get => _newPlayerName;
        set
        {
            _newPlayerName = value;
            OnPropertyChanged();
        }
    }

    public string WinnerName
    {
        get => _winnerName;
        set
        {
            _winnerName = value;
            OnPropertyChanged();
        }
    }

    public string PlayerCountText => Players.Count == 0 ?
        "Нет игроков" :
        $"Количество игроков: {Players.Count}";

    public bool CanSelectWinner => Players.Count >= 2;

    public ICommand AddPlayerCommand { get; }
    public ICommand RemovePlayerCommand { get; }
    public ICommand SelectWinnerCommand { get; }

    public PlayerRandomizerViewModel()
    {
        Players = new ObservableCollection<Player>();

        AddPlayerCommand = new Command(AddPlayer);
        RemovePlayerCommand = new Command<Player>(RemovePlayer);
        SelectWinnerCommand = new Command(SelectWinner);
    }

    private void AddPlayer()
    {
        if (!string.IsNullOrWhiteSpace(NewPlayerName))
        {
            Players.Add(new Player { Name = NewPlayerName.Trim() });
            NewPlayerName = string.Empty;
            WinnerName = string.Empty;

            OnPropertyChanged(nameof(PlayerCountText));
            OnPropertyChanged(nameof(CanSelectWinner));

            foreach (var player in Players)
            {
                player.IsSelected = false;
            }
        }
    }

    private void RemovePlayer(Player player)
    {
        if (player != null)
        {
            Players.Remove(player);
            WinnerName = string.Empty;

            OnPropertyChanged(nameof(PlayerCountText));
            OnPropertyChanged(nameof(CanSelectWinner));
        }
    }

    private void SelectWinner()
    {
        if (Players.Count < 2) return;

        foreach (var player in Players)
        {
            player.IsSelected = false;
        }

        var randomIndex = _random.Next(Players.Count);
        var winner = Players[randomIndex];
        winner.IsSelected = true;
        WinnerName = winner.Name;
    }
}