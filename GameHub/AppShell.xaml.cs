using GameHub.Views;
namespace GameHub
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Dice), typeof(Dice));
        }
    }
}
