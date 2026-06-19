namespace GameHub.Views.Modules;
using GameHub.ViewModels;

public partial class Coin : ContentView
{
	public Coin()
	{
		InitializeComponent();
		BindingContext = new CoinViewModel();
	}
}