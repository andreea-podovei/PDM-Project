using System.Diagnostics;
using System.Text;
namespace PDM_Project;

public partial class ForecastPage : ContentPage
{

    bool celsius;
    List<Prognoza> listaPrognoza = new List<Prognoza>();
    List<string> listaOrase = new List<string>();
    bool prognozaInitializat = false;

    public ForecastPage()
    {
        InitializeComponent();
        BindingContext = new ForecastPageViewModel();
        pickerOras.SelectedIndex = 1;

    }

    


    protected override async void OnAppearing()
    {
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
        GradeCelsius();
        
    }

    private async void GradeCelsius()
    {
        // DaoPrognoza daoPrognoza = new DaoPrognoza();

        // List<Prognoza> listaPrognoza = daoPrognoza.ObtineToateInregistrarile();

        StringBuilder s = new StringBuilder();

        string orasSelectat = pickerOras.SelectedItem.ToString();
        int nrZile = int.Parse(labelNumarZile.Text);




        List<Prognoza> listaPrognoza = await ServiciuPrognoza.PreiaPrognoza();

        foreach (Prognoza prognoza in listaPrognoza)
        {
            if (prognoza.Oras == orasSelectat)
            {

                for (int i = 0; i < nrZile; i++)
                {

                    s.Append(prognoza.PrognozaPeZi[i].StringForecast() + "\n");
                }
            }
        }


        //StringBuilder sb = new StringBuilder();
        //sb.Append("Oras: " + Oras + " " + DataPrognoza);
        ////?? Eroare null exp -> smr daca stiu de ce
        //foreach (PrognozaPeZi zi in PrognozaPeZi)
        //{
        //	sb.Append("[" + zi.ToString() + "], ");
        //}


        labelRaspuns.Text = s.ToString();
    }


    private async void GradeFahrenheit()
    {
        // DaoPrognoza daoPrognoza = new DaoPrognoza();

        // List<Prognoza> listaPrognoza = daoPrognoza.ObtineToateInregistrarile();

        StringBuilder s = new StringBuilder();

        string orasSelectat = pickerOras.SelectedItem.ToString();
        int nrZile = int.Parse(labelNumarZile.Text);




        List<Prognoza> listaPrognoza = await ServiciuPrognoza.PreiaPrognoza();

        foreach (Prognoza prognoza in listaPrognoza)
        {
            if (prognoza.Oras == orasSelectat)
            {

                for (int i = 0; i < nrZile; i++)
                {

                    s.Append(prognoza.PrognozaPeZi[i].StringForecastFahrenheit() + "\n");
                }
            }
        }


        //StringBuilder sb = new StringBuilder();
        //sb.Append("Oras: " + Oras + " " + DataPrognoza);
        ////?? Eroare null exp -> smr daca stiu de ce
        //foreach (PrognozaPeZi zi in PrognozaPeZi)
        //{
        //	sb.Append("[" + zi.ToString() + "], ");
        //}


        labelRaspuns.Text = s.ToString();
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        labelNumarZile.Text=e.NewValue.ToString();
    }

   

    private void Button_Clicked_F(object sender, EventArgs e)
    {
        GradeFahrenheit();
    }
}