namespace PDM_Project;

public partial class OutputPage : ContentPage
{
	List<Prognoza> listaPrognoza = new List<Prognoza>();
	bool prognozaInitializat = false;

	public OutputPage()
	{
		InitializeComponent();

		BindingContext = new OutputPageViewModel();

		listViewPrognozaPeZi.ItemsSource = listaPrognoza;
	}

	protected override async void OnAppearing()
	{
		DaoPrognoza daoPrognoza = new DaoPrognoza();
		if (!prognozaInitializat)
		{
			listaPrognoza = daoPrognoza.ObtineToateInregistrarile();
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

		listViewPrognozaPeZi.ItemsSource = listaPrognoza;
	}
}