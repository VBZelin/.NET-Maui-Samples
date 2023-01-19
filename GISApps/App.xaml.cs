using GISApps.Pages;
using GISApps.UI;

namespace GISApps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            RegisterAllRoutes();
        }

        private void RegisterAllRoutes()
        {
            Routing.RegisterRoute(nameof(GalleryPage), typeof(GalleryPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(TextButtonPage), typeof(TextButtonPage));
        }
    }
}

