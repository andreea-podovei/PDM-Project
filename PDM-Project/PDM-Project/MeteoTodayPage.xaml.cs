namespace PDM_Project;

public partial class MeteoTodayPage : ContentPage
{
    PickerCityModel pickerViewModel;
    public MeteoTodayPage()
	{
        InitializeComponent();
        pickerViewModel = new PickerCityModel();
        this.BindingContext = pickerViewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await pickerViewModel.GetData();
    }
}