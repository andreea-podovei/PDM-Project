namespace PDM_Project;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

	private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
        RadioButton radioButton = sender as RadioButton;
        if (radioButton.Content.ToString() == "Brezoi Iulia-Stefania")
        {
            labelDespre.Text = "Când afara plouă, Iulia preferă să doarmă";
        };
        if (radioButton.Content.ToString() == "Nitescu Marisa")
        {
            labelDespre.Text = "Când afară este cer variabil, Marisa preferă să danseze";
        };
        if (radioButton.Content.ToString() == "Podovei Andreea")
        {
            labelDespre.Text = "Când afară este cer senin, Andreea preferă să iasă în parc";
        };
        if (radioButton.Content.ToString() == "Stoica Radu")
        {
            labelDespre.Text = "Când afară este cer parțial noros, Radu preferă să citească";
        };
        if (radioButton.Content.ToString() == "Talaba Adina")
        {
            labelDespre.Text = "Când afară este cer temporar noros, Adina preferă să vizioneze un film";
        };


    }
}