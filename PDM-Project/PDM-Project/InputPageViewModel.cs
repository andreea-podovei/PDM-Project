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
	
		public InputPageViewModel(){
			//this.ListPrognoza = new DaoPrognoza().ObtineToateInregistrarile();			
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotificaInterfata([CallerMemberName] String name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		}

	}
}
