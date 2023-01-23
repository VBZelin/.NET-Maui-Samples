using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GISApps.Assets;
using GISApps.Models;

namespace GISApps.Pages
{
    public partial class GalleryPage : ContentPage
    {
        public Category Category { get; set; }

        public GalleryPageViewModel ViewModel { get; private set; }

        public GalleryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel = new GalleryPageViewModel();

            BindingContext = ViewModel;
        }

        private async void OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            Sample item = e.Item as Sample;

            await Shell.Current.GoToAsync($"/{item.FileName}");
        }

        private async void OnOpenSortMenu(System.Object sender, System.EventArgs e)
        {
            var action = await DisplayActionSheet(Constants.CHOOSE_CATEGORY, "Cancel", null, "UI", "ArcGIS Runtime", "Framework", "Default");

            switch (action)
            {
                case "UI":
                    ViewModel.SelectCategory(Category.UI);

                    break;

                case "ArcGIS Runtime":
                    ViewModel.SelectCategory(Category.ArcGISRuntime);

                    break;

                case "Framework":
                    ViewModel.SelectCategory(Category.Framework);

                    break;

                case "Default":
                    ViewModel.SelectCategory(Category.Default);

                    break;

                case "Cancel":
                default:
                    return;
            }
        }
    }

    public class GalleryPageViewModel : INotifyPropertyChanged
    {
        public string Title => CategoryToTitleConverter(Category);

        public IEnumerable<Sample> SearchResults => _allSamples.Where(SearchFunction);

        private readonly IEnumerable<Sample> _allSamples;

        private Category _category = Category.Default;

        private string _searchQuery = "";

        public Category Category
        {
            get { return _category; }

            set
            {
                if (value != _category)
                {
                    _category = value;

                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Title));
                    OnPropertyChanged(nameof(SearchResults));
                }
            }
        }

        public string SearchQuery
        {
            get { return _searchQuery; }

            set
            {
                if (value != _searchQuery)
                {
                    _searchQuery = !string.IsNullOrWhiteSpace(value) ? value.ToLower() : "";

                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SearchResults));
                }
            }
        }

        public GalleryPageViewModel()
        {
            Category = Category.Default;
            _allSamples = Samples.All;
        }

        public void SelectCategory(Category category)
        {
            Category = category;
        }

        public bool SearchFunction(Sample sample)
        {
            return (Category == Category.Default || Category == sample.Category)
                && (sample.Name.ToLower().Contains(SearchQuery) || sample.Detail.ToLower().Contains(SearchQuery));
        }

        private static string CategoryToTitleConverter(Category category)
        {
            switch (category)
            {
                case Category.Default:
                    return Constants.ALL_SAMPLES;

                case Category.UI:
                    return Constants.UI_SAMPLES;

                case Category.ArcGISRuntime:
                    return Constants.ARCGIS_RUNTIME_SAMPLES;

                case Category.Framework:
                    return Constants.FRAMEWORK_SAMPLES;

                default:
                    return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}