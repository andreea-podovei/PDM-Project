namespace PDM_Project;

public partial class MainPage : ContentPage
{
    List<Prognoza> listaPrognoza = new List<Prognoza>();
    bool prognozaInitializat = false;

    public MainPage()
	{
		InitializeComponent();
	}

    private void RecordsPageToolbarItem_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecordsPage());
    }

    protected override async void OnAppearing()
    {
        DaoPrognoza daoPrognoza = new DaoPrognoza();
        if (!prognozaInitializat)
        {

            listaPrognoza = daoPrognoza.ObtineToateOrasele();
            //listaPrognozaPeZi = daoPrognoza.ObtineToateInregistrarilePeZi();
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
            listaPrognoza = daoPrognoza.ObtineToateInregistrarile();

        }
    }
}

