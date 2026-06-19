using GameHub.Views;
using System.Windows.Input;

namespace GameHub.ViewModels;

public class ToolsViewModel
{

    public ICommand ChessCommand { get; }
	public ICommand DiceCommand { get; }
	public ICommand GamerRandomCommand { get; }
	public ICommand RandomCommand { get; }
	public ICommand TimerCommand { get; }
	public ICommand CountCommand { get; }
	public ToolsViewModel()
	{
        DiceCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(Dice));
        });

        GamerRandomCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(GamerRandom));
        });
        RandomCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(RandomPage));
        });

        TimerCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(TimerPage));
        });
        CountCommand = new Command(async () =>
        {
            await NavigateToAsync(nameof(ScoreBoardPage));
        });

    }
    private async Task NavigateToAsync(string pageName)
    {
        await Shell.Current.GoToAsync(pageName);

    }
}