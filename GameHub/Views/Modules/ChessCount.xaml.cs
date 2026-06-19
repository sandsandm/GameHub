namespace GameHub.Views.Modules;
using GameHub.ViewModels;
public partial class ChessCount : ContentView
{
	public ChessCount()
	{
		InitializeComponent();
		BindingContext = new ChessCountViewModel();
		
	}
}