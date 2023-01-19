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
