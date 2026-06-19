namespace GameHub.Views;
using GameHub.ViewModels;
public partial class ToolsHubPage : ContentPage
{
	public ToolsHubPage()
	{
		InitializeComponent();
		BindingContext = new ToolsViewModel();	
	}
}