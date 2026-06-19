using GameHub.Views;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameHub.ViewModels;

public class MainViewModel 
{
<<<<<<< HEAD
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
=======
>>>>>>> 4d8c60b992de6f9890192367213ed58df3823835
    public ICommand OpenChessCommand { get; }
    public ICommand OpenDnDCommand { get; }
    public ICommand OpenBoardGamesCommand { get; }
    public ICommand OpenDiceCommand { get; }
    public ICommand OpenGamerRandomCommand { get; }
    public ICommand OpenTimerCommand { get; }
    public ICommand OpenTeamCommand { get; }
  
    public MainViewModel() 
<<<<<<< HEAD
	{
		//кнопки страниц
		OpenChessCommand = new Command(async () =>
		{
			await Shell.Current.GoToAsync("///ChessHubPage");
		});
=======
    {

        // Кнопки страниц
        OpenChessCommand = new Command(async () =>
        {
            await NavigateToAsync("///ChessHubPage");
        });

        OpenDnDCommand = new Command(async () =>
        {
            await NavigateToAsync("///DnDHubPage");
        });
>>>>>>> 4d8c60b992de6f9890192367213ed58df3823835

        OpenBoardGamesCommand = new Command(async () =>
        {
            await NavigateToAsync("///BoardGamesHubPage");
        });

        OpenTeamCommand = new Command(async () =>
        {
            await NavigateToAsync("///AddTeamPage");
        });

        // Кнопки утилит
        OpenDiceCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(Dice));
        });

        OpenGamerRandomCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(GamerRandom));
        });

        OpenTimerCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(TimerPage));
        });

    }
    private async Task NavigateToAsync(string pageName)
    {
         await Shell.Current.GoToAsync(pageName);
        
    }

}