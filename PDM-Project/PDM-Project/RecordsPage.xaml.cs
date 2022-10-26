namespace PDM_Project;
using System.Diagnostics;

public partial class RecordsPage : ContentPage
{

    List<Prognoza> listaPrognoza = new List<Prognoza>();
    public RecordsPage()
	{
		InitializeComponent();
        Debug.WriteLine("Salut!");
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listaPrognoza = await ServiciuPrognoza.PreiaPrognoza();
        Debug.WriteLine(listaPrognoza.Count);
        for (var i = 0; i < listaPrognoza.Count; i++)
        {
            Debug.WriteLine(listaPrognoza[i]);
        }
        //listViewPrognoza.ItemsSource = listaPrognoza;
    }

    private void listViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        DisplayAlert("Info", (e.SelectedItem as Prognoza).Oras, "ok");

    }

    private void Button_Clicked1(object sender, EventArgs e)
    {

        var temp_min = 100;
        List<string> orase = new List<string>();

        foreach (Prognoza prognoza in listaPrognoza)
        {
            foreach (PrognozaPeZi prognozaPeZi in prognoza.PrognozaPeZi)
            {
                temp_min = Math.Min(temp_min, prognozaPeZi.Temp_min);
            }
        }

        foreach (Prognoza prognoza in listaPrognoza)
        {
            foreach (PrognozaPeZi prognozaPeZi in prognoza.PrognozaPeZi)
            {
                if (prognozaPeZi.Temp_min == temp_min)
                {
                    orase.Add(prognoza.Oras);
                    break;
                }
            }
        }

        string message = "S-a înregistrat în orașul/orașele: ";
        for (int i = 0; i < orase.Count; i++)
        {
            message += orase[i];
            if (i < orase.Count - 1)
            {
                message += ", ";
            }
        }

        DisplayAlert($"Temperatura minimă: {temp_min} grade Celsius", message, "ok");
    }

    private void Button_Clicked2(object sender, EventArgs e)
    {

        var temp_max = -100;
        List<string> orase = new List<string>();

        foreach (Prognoza prognoza in listaPrognoza)
        {
            foreach (PrognozaPeZi prognozaPeZi in prognoza.PrognozaPeZi)
            {
                temp_max = Math.Max(temp_max, prognozaPeZi.Temp_max);
            }
        }

        foreach (Prognoza prognoza in listaPrognoza)
        {
            foreach (PrognozaPeZi prognozaPeZi in prognoza.PrognozaPeZi)
            {
                if (prognozaPeZi.Temp_max == temp_max)
                {
                    orase.Add(prognoza.Oras);
                    break;
                }
            }
        }

        string message = "S-a înregistrat în orașul/orașele: ";
        for (int i = 0; i < orase.Count; i++)
        {
            message += orase[i];
            if (i < orase.Count - 1)
            {
                message += ", ";
            }
        }

        DisplayAlert($"Temperatura maximă: {temp_max} grade Celsius", message, "ok");
    }



}