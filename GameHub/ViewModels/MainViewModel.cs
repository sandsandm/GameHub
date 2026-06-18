using GameHub.Views;
using System.Windows.Input;

namespace GameHub.ViewModels;

public class MainViewModel : ContentPage
{
    public ICommand OpenChessCommand { get; }
	public ICommand OpenDnDCommand { get; }
	public ICommand OpenBoardGamesCommand { get; }
	public ICommand OpenDiceCommand { get; }
    public MainViewModel() 
	{
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

		OpenDiceCommand = new Command(async () =>
		{
            await Shell.Current.GoToAsync(nameof(Dice));
        });

    }
}