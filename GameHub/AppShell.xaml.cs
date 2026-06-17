using GameHub.Views;
namespace GameHub
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ChessHubPage), typeof(ChessHubPage));
            Routing.RegisterRoute(nameof(DnDHubPage), typeof(DnDHubPage));
            Routing.RegisterRoute(nameof(PartyHubPage), typeof(PartyHubPage));
            Routing.RegisterRoute(nameof(ToolsHubPage), typeof(ToolsHubPage));
            Routing.RegisterRoute(nameof(BoardGamesHubPage), typeof(BoardGamesHubPage));
        }
    }
}
