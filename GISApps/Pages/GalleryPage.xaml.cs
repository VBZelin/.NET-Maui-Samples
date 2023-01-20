using GISApps.Assets;
using GISApps.Models;

namespace GISApps.Pages;

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

        init();
    }

    async void OnItemTapped(Object sender, ItemTappedEventArgs e)
    {
        Sample item = e.Item as Sample;

        await Shell.Current.GoToAsync($"/{item.FileName}");
    }

    void init()
    {
        Root.Title = CategoryToTitleConverter(Category);

        CreateCollection();
    }

    void CreateCollection()
    {
        var items = Samples.All;

        var filteredItems = from item in items
                            where item.Category == Category
                            select item;

        ListView.ItemsSource = filteredItems;
    }

    string CategoryToTitleConverter(Category category)
    {
        switch (category)
        {
            case Category.UI:
                return "UI samples";

            case Category.ArcGISRuntime:
                return "ArcGIS Runtime samples";

            case Category.Framework:
                return "Framework samples";

            default:
                return "";
        }
    }
}