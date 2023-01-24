namespace GISApps.UI
{
    public partial class CustomImagePage : ContentPage
    {
        public CustomImagePage()
        {
            InitializeComponent();
        }

        private void OnLoadRemoteImageClicked(System.Object sender, System.EventArgs e)
        {
            var url = ImageUrlEntry.Text;

            CustomImage.ImageSource = url;
        }

        private void OnLoadExampleOneClicked(System.Object sender, System.EventArgs e)
        {
            var url = "https://upload.wikimedia.org/wikipedia/commons/d/df/ArcGIS_logo.png";

            CustomImage.ImageSource = url;
        }

        private void OnLoadExampleTwoClicked(System.Object sender, System.EventArgs e)
        {
            var url = "https://aka.ms/campus.jpg";

            CustomImage.ImageSource = url;
        }
    }
}
