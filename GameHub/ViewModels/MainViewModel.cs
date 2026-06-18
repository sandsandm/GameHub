using GameHub.Views;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameHub.ViewModels;

public class MainViewModel 
{
    public ICommand OpenChessCommand { get; }
    public ICommand OpenDnDCommand { get; }
    public ICommand OpenBoardGamesCommand { get; }
    public ICommand OpenDiceCommand { get; }
    public ICommand OpenGamerRandomCommand { get; }
    public ICommand OpenTimerCommand { get; }
    public ICommand OpenTeamCommand { get; }
  
    public MainViewModel() 
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