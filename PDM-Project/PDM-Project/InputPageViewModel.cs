using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDM_Project
{
	internal class InputPageViewModel : INotifyPropertyChanged
	{   //entry valoare
		//Text
		public string Valoare { get; set; }

		public List<Prognoza> ListPrognoza { get; set; }

		//SelectedItem
		public Prognoza PrognozaSursa { get; set; }

		//Button
		//Command
		public ICommand SearchCommand { get; set; }

		public InputPageViewModel(){

			Valoare = "";

			//this.ListPrognoza = new DaoPrognoza().ObtinePrognozaDinData(DateTime.Now.AddDays(-1));
			this.ListPrognoza = new DaoPrognoza().ObtinePrognozaDinData(DateTime.Parse("2022-10-13"));
			this.ListPrognoza.Add(new Prognoza() { Oras = "Bucuresti"});
			this.ListPrognoza.Add(new Prognoza() { Oras = "Brasov"});

			foreach (Prognoza prognoza in this.ListPrognoza)
			{
				if (Valoare == prognoza.Oras)
					DisplayAlert("Info", Valoare.ToString(), "OK");
			}
		}

		private void DisplayAlert(string v1, object value, string v2)
		{
			throw new NotImplementedException();
		}

		/*public Prognoza Cauta(string value)
		{
			foreach(Prognoza prognoza in this.ListPrognoza)
			{
				if (value == prognoza.Oras)
					return prognoza;
			}
		}*/

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotificaInterfata([CallerMemberName] String name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		}

	}
}
