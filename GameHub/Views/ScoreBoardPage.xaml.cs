namespace GameHub.Views;
using GameHub.ViewModels;

public partial class ScoreBoardPage : ContentPage
{
	public ScoreBoardPage()
	{
		InitializeComponent();
		BindingContext = new ScoreBoardViewModel();
	}
}