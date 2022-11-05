namespace PDM_Project;

using System.ComponentModel;
using System.Diagnostics;

public partial class ForecastPage : ContentPage
{
    PickerCityModel pickerViewModel;

    public ForecastPage()
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