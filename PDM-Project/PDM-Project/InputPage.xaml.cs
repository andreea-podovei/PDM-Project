using System.Linq;

namespace PDM_Project;

public partial class InputPage : ContentPage
{
	List<Prognoza> listaPrognoza = new List<Prognoza>();
	List<PrognozaPeZi> listaPrognozaPeZi = new List<PrognozaPeZi>();
	List<PrognozaTest> listaPrognozaTest = new List<PrognozaTest>();
	bool prognozaInitializat = false;

	public InputPage()
	{
		InitializeComponent();

		BindingContext = new InputPageViewModel();

	}

	protected override async void OnAppearing()
	{
		DaoPrognoza daoPrognoza = new DaoPrognoza();

		if (!prognozaInitializat)
		{
			listaPrognoza = daoPrognoza.ObtineToateInregistrarile1();
			listaPrognozaPeZi = daoPrognoza.ObtineToateInregistrarile2();

			foreach (Prognoza prognoza in listaPrognoza)
			{
				prognoza.PrognozaPeZi = new List<PrognozaPeZi>();
			}

			for (int j = 0; j < 5; j++)
			{
			foreach (Prognoza prognoza in listaPrognoza)
				{ 
				prognoza.PrognozaPeZi.Add(listaPrognozaPeZi[j]);
				}

			}
			
			prognozaInitializat = true;
			
		}

		if (listaPrognoza.Count == 0)
		{
			listaPrognoza = await ServiciuPrognoza.PreiaPrognoza();
			daoPrognoza.AdaugaListaPrognoza(listaPrognoza);

			for (int i = 1; i <= listaPrognoza.Count; i++)
			{
				foreach (PrognozaPeZi prognozaPeZi in listaPrognoza[i - 1].PrognozaPeZi)
				{
					prognozaPeZi.Id = listaPrognoza[i - 1].Id;
				}				
			}

			foreach (Prognoza prognoza in listaPrognoza)
			{
				daoPrognoza.AdaugaListaPrognozaPeZi(prognoza.PrognozaPeZi);
			}


		}

		listViewPrognoza.ItemsSource = listaPrognoza;
	}

	private void listViewPrognoza_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		DisplayAlert("Informatii prognoza meteo", e.SelectedItem.ToString(), "OK");
	
	}
	
	private void listViewPrognozaTest_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		DisplayAlert("Informatii prognoza meteo", e.SelectedItem.ToString(), "OK");
	
	}


}