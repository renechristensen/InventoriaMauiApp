using InventoriaMauiApp.View;

namespace InventoriaMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DataRackDetailsPage), typeof(DataRackDetailsPage));
            Routing.RegisterRoute(nameof(DataRackUnitsPage), typeof(DataRackUnitsPage));
            Routing.RegisterRoute(nameof(RackUnitDetailsPage), typeof(RackUnitDetailsPage));
            Routing.RegisterRoute(nameof(ReservationPage), typeof(ReservationPage));
            Routing.RegisterRoute(nameof(ReservationOverviewPage), typeof(ReservationOverviewPage));
            Routing.RegisterRoute(nameof(DataRackOverViewPage), typeof(DataRackOverViewPage));
            Routing.RegisterRoute(nameof(ReservationDetailsPage), typeof(ReservationDetailsPage));
            Routing.RegisterRoute(nameof(ReservedUnitsPage), typeof(ReservedUnitsPage));
            Routing.RegisterRoute(nameof(InsertEquipmentPage), typeof(InsertEquipmentPage));
        }
    }
}
