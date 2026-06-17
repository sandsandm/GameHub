namespace GameHub.Views.Modules;
using GameHub.ViewModels;

public partial class PlayerRandomizerView : ContentView
{
	public PlayerRandomizerView()
	{
		InitializeComponent();
        BindingContext = new PlayerRandomizerViewModel();
    }
}