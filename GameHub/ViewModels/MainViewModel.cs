using GameHub.Views;
using System.Windows.Input;

namespace GameHub.ViewModels;

public class MainViewModel
{
    private readonly Random _random = new();

    private readonly string[] _randomRoutes =
    {
		"///ChessHubPage",
		"///DnDHubPage",
		"///BoardGamesHubPage",
		"///AddTeamPage",
		"///DicePage",
		"///GamerRandomPage",
		"///PartyHubPage",
		"TimerPage"
	};
    public ICommand OpenChessCommand { get; }
	public ICommand OpenDnDCommand { get; }
	public ICommand OpenBoardGamesCommand { get; }
	public ICommand OpenDiceCommand { get; }
	public ICommand OpenGamerRandomCommand { get; }
	public ICommand OpenTimerCommand { get; }
	public ICommand OpenTeamCommand { get; }
	public ICommand ContinueCommand => new Command(async () =>
	{
		var lastMode = Preferences.Default.Get("last_mode", "none");

		switch (lastMode)
		{
			case "dnd":
                await Shell.Current.GoToAsync("///DnDHubPage");
                break;
            case "chess":
                await Shell.Current.GoToAsync("///ChessHubPage");
                break;
            case "board":
                await Shell.Current.GoToAsync("///BoardGamesHubPage");
                break;
			case "addTeam":
				await Shell.Current.GoToAsync("///AddTeamPage");
				break;
			case "dice":
				await Shell.Current.GoToAsync(nameof(Dice));
				break;
			case "gamerRandom":
				await Shell.Current.GoToAsync(nameof(GamerRandom));
				break;
			case "partyhub":
				await Shell.Current.GoToAsync("///PartyHubPage");
				break;
			case "timer":
				await Shell.Current.GoToAsync(nameof(TimerPage));
				break;
			default:
                await Shell.Current.GoToAsync("///MainPage");
                break;

        }
	});
    public ICommand RandomModeCommand { get; }


    public MainViewModel() 
	{
		//кнопки страниц
		OpenChessCommand = new Command(async () =>
		{
			await Shell.Current.GoToAsync("///ChessHubPage");
		});

		OpenDnDCommand = new Command(async () =>
		{
			await Shell.Current.GoToAsync("///DnDHubPage");
		});

		OpenBoardGamesCommand = new Command(async () =>
		{
			await Shell.Current.GoToAsync("///BoardGamesHubPage");
		});
		OpenTeamCommand = new Command(async () =>
		{
			await Shell.Current.GoToAsync("///AddTeamPage");
		});

		//кнопки утилит
		OpenDiceCommand = new Command(async () =>
		{
            await Shell.Current.GoToAsync(nameof(Dice));
        });

        OpenGamerRandomCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(GamerRandom));
        });

        OpenTimerCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(TimerPage));
        });

		//рандомный режим
        RandomModeCommand = new Command(async () =>
        {
            var route = _randomRoutes[_random.Next(_randomRoutes.Length)];
            await Shell.Current.GoToAsync(route);
        });


    }
}