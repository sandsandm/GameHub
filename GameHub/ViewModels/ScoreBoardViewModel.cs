namespace GameHub.ViewModels;
using System.Windows.Input;

public class ScoreBoardViewModel 
{
    public ICommand OpenTeamCommand { get; }

    public ScoreBoardViewModel()
	{
        OpenTeamCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync("///AddTeamPage");
        });

    }
}