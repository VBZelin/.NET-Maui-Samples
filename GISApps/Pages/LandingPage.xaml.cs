using System.Collections.Generic;
using System.Windows.Input;
using GISApps.Assets;
using GISApps.Pages;

namespace GISApps.Pages
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private async void OnOpenSettings(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"/{nameof(SettingsPage)}");
        }
    }

    public class LandingPageViewModel
    {
        public ICommand OpenSamplesCommand { private set; get; }

        public LandingPageViewModel()
        {
            OpenSamplesCommand = new Command(async (category) =>
            {
                var navigationParams = new Dictionary<string, object> { { "Category", category } };

                await Shell.Current.GoToAsync($"/{nameof(GalleryPage)}", navigationParams);
            });
        }
    }
}
