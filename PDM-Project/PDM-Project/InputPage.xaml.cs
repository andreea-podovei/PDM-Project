namespace PDM_Project;

public partial class InputPage : ContentPage
{
	List<Prognoza> listaPrognoza = new List<Prognoza>();
	bool prognozaInitializat = false;

	public InputPage()
	{
		InitializeComponent();

		BindingContext = new InputPageViewModel();

		//pickerOras.SelectedIndex = 0;
		listViewPrognoza.ItemsSource = listaPrognoza;
	}
	protected override async void OnAppearing()
	{
		DaoPrognoza daoPrognoza = new DaoPrognoza();
		if (!prognozaInitializat)
		{
			listaPrognoza = daoPrognoza.ObtinePrognozaDinData(DateTime.Parse("2022-10-13"));
			prognozaInitializat = true;
		}

		if (listaPrognoza.Count == 0)
		{
			listaPrognoza = await ServiciuPrognoza.PreiaPrognoza();
			daoPrognoza.AdaugaListaPrognoza(listaPrognoza);

		}

		listViewPrognoza.ItemsSource = listaPrognoza;

	}

	private void listViewPrognoza_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		DisplayAlert("Info", e.SelectedItem.ToString(), "OK");
	}
}