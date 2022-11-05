using Microcharts;

namespace PDM_Project;

public partial class GraphicPage : ContentPage
{
    public GraphicPage()
    {
        InitializeComponent();

    }

    protected override async void OnAppearing()
    {
        List<ChartEntry> chartEntries = new List<ChartEntry>();
        List<Prognoza> listaPrognoza = await ServiciuPrognoza.PreiaPrognoza();
        Random rdn = new Random();

        String localitate = "Arad";

        foreach (Prognoza prognoza in listaPrognoza)
        {
            String oras = prognoza.Oras;
            if (!oras.Equals(localitate))
            {
                continue;
            }

            foreach (PrognozaPeZi prognozaPeZi in prognoza.PrognozaPeZi)
            {
                chartEntries.Add(new ChartEntry((float)prognozaPeZi.Temp_max)
                {
                    Label = prognozaPeZi.Data.ToString("yyyy-MM-dd"),
                    ValueLabel = prognozaPeZi.Temp_max.ToString(),
                    Color = new SkiaSharp.SKColor(
                    (byte)rdn.Next(256),
                    (byte)rdn.Next(256),
                    (byte)rdn.Next(256)

                    )

                }
                );
            }
        }

        chartView.Chart = new BarChart()
        {
            Entries = chartEntries
        };
    }
}