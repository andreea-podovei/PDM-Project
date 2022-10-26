namespace PDM_Project;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

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

        HashSet<Fenomen> fenomene = new HashSet<Fenomen>(new FenomenComparer());
        foreach (Prognoza prognoza in listaPrognoza)
        {
            foreach (PrognozaPeZi prognozaPeZi in prognoza.PrognozaPeZi)
            {
                Fenomen fenomen = new Fenomen();
                fenomen.FenomenDescriere = prognozaPeZi.Descriere;
                fenomene.Add(fenomen);
            }

        }

        
        foreach (Fenomen fen in fenomene)
        {
            Debug.WriteLine(fen.ResursaFenomen + " ,");
        }

        listViewFenomene.ItemsSource = fenomene;
    }
    
    
    private void listViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        switch ((e.SelectedItem as Fenomen).FenomenDescriere)
        {
            
            case "CER VARIABIL":
                string activitati = "";
                activitati += "Vizionare film cinema\nShopping\nÎncercare noi rețete culinare ";
                DisplayAlert("Activități", activitati, "ok");
                break;

            case "CER TEMPORAR NOROS, PLOAIE SLABA":
                activitati = "";
                activitati += "Curățenie în casă\nVizită muzee online\nCumpărături online";
                DisplayAlert("Activități", activitati, "ok");
                break;

            case "CER MAI MULT SENIN":
                activitati = "";
                activitati += "Plimbare cu bicicleta\nPlimbare prin parc\nAlergat\nDrumeție";
                DisplayAlert("Activități", activitati, "ok");
                break;

            case "CER PARTIAL NOROS":
                activitati = "";
                activitati += "Vizită Cărturești\nPlimbare prin parc\nIeșire cu prietenii";
                DisplayAlert("Activități", activitati, "ok");
                break;

            case "CER MAI MULT NOROS, PLOAIE SLABA":
                activitati = "";
                activitati += "Citit\nEscape Room\nNetflix\nBoardgames";
                DisplayAlert("Activități", activitati, "ok");
                break;

            default: break;
        }

    }
}