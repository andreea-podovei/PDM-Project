using System.ComponentModel;
using System.Text;

namespace PDM_Project;

public partial class StatisticsPage : ContentPage
{
    List<Prognoza> listaPrognoza = new List<Prognoza>();
    List<string> listaOrase = new List<string>();

    public StatisticsPage()
	{
		InitializeComponent();
        BindingContext = new ForecastPageViewModel();
        pickerOras.SelectedIndex = 1;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        DaoPrognoza daoPrognoza = new DaoPrognoza();
        listaPrognoza = daoPrognoza.ObtineToateOrasele();


        foreach (Prognoza p in listaPrognoza)
        {
            listaOrase.Add(p.Oras);
        }

        pickerOras.ItemsSource = listaOrase;
        //listViewPrognoza.ItemsSource = listaPrognozaPeZi;
        pickerOras.SelectedIndex = 1;
       
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        double tempMedie = 0;
        double[] tempMedii = new double[10];
        string orasSelectat = pickerOras.SelectedItem.ToString();

        List<Prognoza> listaProg = await ServiciuPrognoza.PreiaPrognoza();

        foreach (Prognoza prognoza in listaProg)
        {
            if (prognoza.Oras == orasSelectat)
            {
                for (int i = 0; i < 5; i++)
                {

                    tempMedii[i] = prognoza.PrognozaPeZi[i].GetTempMedie(prognoza.PrognozaPeZi[i].Temp_min, prognoza.PrognozaPeZi[i].Temp_max);
                }
                tempMedie = tempMedii.Average();
            }
            labelTempMedie.Text = tempMedie.ToString();
        }

    }

}