namespace GameHub.Views.Modules;

using GameHub.ViewModels;
public partial class RandomizerView : ContentView
{
	public RandomizerView()
	{
		InitializeComponent();
		BindingContext = new RandomizerViewModel();
	}
}