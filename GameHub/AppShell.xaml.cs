using GameHub.ViewModels;
using GameHub.Views;
namespace GameHub
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Dice), typeof(Dice));
            Routing.RegisterRoute(nameof(GamerRandom), typeof(GamerRandom));
            Routing.RegisterRoute(nameof(TimerPage), typeof(TimerPage));

        }

    }
}
