using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GISApps.Assets;
using GISApps.Models;

namespace GISApps.Pages
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class GalleryPage : ContentPage
    {
        public Category Category { get; set; }

        public GalleryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new GalleryPageViewModel(Category);
        }

        private async void OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            Sample item = e.Item as Sample;

            await Shell.Current.GoToAsync($"/{item.FileName}");
        }
    }

    public class GalleryPageViewModel : INotifyPropertyChanged
    {
        public string Title => CategoryToTitleConverter(Category);

        public IEnumerable<Sample> SearchResults => _allSamples.Where(SearchFunction);

        private readonly IEnumerable<Sample> _allSamples;

        private Category _category = Category.UI;

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

        public GalleryPageViewModel(Category category)
        {
            _category = category;

            var items = Samples.All;

            _allSamples = from item in items
                          where item.Category == _category
                          select item;
        }

        public bool SearchFunction(Sample sample)
        {
            return sample.Name.ToLower().Contains(SearchQuery);
        }

        private string CategoryToTitleConverter(Category category)
        {
            switch (category)
            {
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