namespace PDM_Project;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void RecordsPageToolbarItem_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecordsPage());
    }
}

