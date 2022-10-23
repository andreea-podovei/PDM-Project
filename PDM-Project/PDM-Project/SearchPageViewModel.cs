using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDM_Project
{
	internal class SearchPageViewModel : INotifyPropertyChanged
	{
		public List<Prognoza> ListaPrognoza { get; set; }

		//SelectedItem
		public Prognoza PrognozaSursa { get; set; }
		//public Prognoza PrognozaDestinatie { get; set; }

		//Button
		//Command
		public ICommand SearchCommand { get; set; }

		public SearchPageViewModel(){

		}


		public event PropertyChangedEventHandler PropertyChanged;
	}
}
