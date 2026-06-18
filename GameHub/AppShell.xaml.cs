using GameHub.ViewModels;
using GameHub.Views;
using GameHub.Views.Modules;
namespace GameHub
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Dice), typeof(Dice));
            Routing.RegisterRoute(nameof(GamerRandom), typeof(GamerRandom));
            Routing.RegisterRoute(nameof(RandomPage), typeof(RandomPage));
            Routing.RegisterRoute(nameof(TimerPage), typeof(TimerPage));
            Routing.RegisterRoute(nameof(ScoreBoardPage), typeof(ScoreBoardPage));

        }

    }
}
