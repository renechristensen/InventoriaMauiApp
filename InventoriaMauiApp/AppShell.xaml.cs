using InventoriaMauiApp.View;

namespace InventoriaMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DataRackDetailsPage), typeof(DataRackDetailsPage));
        }
    }
}
