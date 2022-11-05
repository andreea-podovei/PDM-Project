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
            
        };
        if (radioButton.Content.ToString() == "Nitescu Marisa")
        {

        };
        if (radioButton.Content.ToString() == "Podovei Andreea")
        {

        };
        if (radioButton.Content.ToString() == "Stoica Radu")
        {
            labelDespre.Text = "radu";
        };
        if (radioButton.Content.ToString() == "Talaba Adina")
        {
            labelDespre.Text = "adina";
        };


    }
}