using GameHub.Views;
using System.Windows.Input;

namespace GameHub.ViewModels;

public class MainViewModel : ContentPage
{
    public ICommand OpenChessCommand { get; }
    public MainViewModel() 
	{
		OpenChessCommand = new Command(async () =>
		{
			await Shell.Current.GoToAsync("///ChessHubPage");
		});
		
	}
}