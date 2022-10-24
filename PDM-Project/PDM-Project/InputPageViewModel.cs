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
	{
		public List<Prognoza> ListPrognoza { get; set; }

		//SelectedItem
		public Prognoza PrognozaSursa { get; set; }

		//Button
		//Command
		public ICommand SearchCommand { get; set; }

		public InputPageViewModel(){
			SearchCommand = new Command(Cauta);

			this.ListPrognoza = new DaoPrognoza().ObtinePrognozaDinData(DateTime.Now.AddDays(-1));
			this.ListPrognoza.Add(new Prognoza() { Oras = "Bucuresti"});
			this.ListPrognoza.Add(new Prognoza() { Oras = "Brasov"});
		}

		public void Cauta()
		{
			new OutputPage();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotificaInterfata([CallerMemberName] String name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		}

	}
}
