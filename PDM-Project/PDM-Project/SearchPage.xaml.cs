namespace PDM_Project;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();

		BindingContext = new SearchPageViewModel();

		pickerOras.SelectedIndex = 0;
	}
}