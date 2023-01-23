namespace GISApps.Framework;

public partial class SecureStoragePage : ContentPage
{
    public SecureStoragePage()
    {
        InitializeComponent();
    }

    private async void OnSaveKeyClicked(System.Object sender, System.EventArgs e)
    {
        if (string.IsNullOrEmpty(Key.Text))
        {
            await DisplayAlert("Error", "Key is empty!", "OKAY");

            return;
        }

        try
        {
            await SecureStorage.Default.SetAsync(Key.Text, Value.Text);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Operation failed!", ex.Message, "OKAY");

            return;
        }

        await DisplayAlert("Result", $"{Key.Text} has been saved: {Value.Text}", "OKAY");
    }

    private async void OnLoadKeyClicked(System.Object sender, System.EventArgs e)
    {
        if (string.IsNullOrEmpty(Key.Text))
        {
            await DisplayAlert("Error", "Key is empty!", "OKAY");

            return;
        }

        string value = "";

        try
        {
            value = await SecureStorage.GetAsync(Key.Text);

            Value.Text = value;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Operation failed", ex.Message, "OKAY");

            return;
        }

        await DisplayAlert("Result", $"{Key.Text}: {value}", "OKAY");
    }

    private async void OnRemoveKeyClicked(System.Object sender, System.EventArgs e)
    {
        if (string.IsNullOrEmpty(Key.Text))
        {
            await DisplayAlert("Error", "Key is empty!", "OKAY");

            return;
        }

        bool success = false;

        try
        {
            success = SecureStorage.Remove(Key.Text);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Operation failed", ex.Message, "OKAY");

            return;
        }

        await DisplayAlert("Result", $"{Key.Text} has been removed: {success}", "OKAY");
    }
}
