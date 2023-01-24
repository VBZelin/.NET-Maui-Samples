namespace Controls.UI
{
    public partial class CustomImage : Frame
    {
        public static readonly BindableProperty ShowIndicatorProperty = BindableProperty.Create("ShowIndicator", typeof(bool), typeof(Frame), false, propertyChanged: OnShowIndicatorChanged);

        public bool ShowIndicator
        {
            get => (bool)GetValue(ShowIndicatorProperty);
            set => SetValue(ShowIndicatorProperty, value);
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(Frame), null, propertyChanged: OnImageSourceChanged);

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public CustomImage()
        {
            InitializeComponent();

            Indicator.IsVisible = ShowIndicator;
            Image.Source = null;
        }

        static void OnShowIndicatorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomImage)bindable;

            control.Indicator.IsVisible = (bool)newValue;
        }

        static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomImage)bindable;

            control.Image.Source = null;
            control.Image.Source = (ImageSource)newValue;
        }
    }
}
