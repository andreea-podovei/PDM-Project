namespace PDM_Project;
using System.Diagnostics;
public partial class SuggestionsPage : ContentPage
{
    List<Prognoza> listaPrognoza = new List<Prognoza>();
    public SuggestionsPage()
	{
		InitializeComponent();
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

        HashSet<string> fenomene = new HashSet<string>();
        foreach (Prognoza prognoza in listaPrognoza)
        {
            foreach (PrognozaPeZi prognozaPeZi in prognoza.PrognozaPeZi)
            {
                fenomene.Add(prognozaPeZi.Descriere);
            }

        }

        
        foreach (string fenomen in fenomene)
        {
            Debug.WriteLine(fenomen + " ,");
        }

        listViewFenomene.ItemsSource = fenomene;
    }
    
    
    private void listViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        DisplayAlert("Activități", (e.SelectedItem as string), "ok");

    }
}