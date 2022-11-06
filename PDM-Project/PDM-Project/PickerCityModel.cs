using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Linq;

namespace PDM_Project
{
    public class PickerCityModel : INotifyPropertyChanged
    {
        Dictionary<string, List<PrognozaPeZi>> dictPrognoza = new Dictionary<string, List<PrognozaPeZi>>();
        

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Orase { get; } = new ObservableCollection<string>();
        public ObservableCollection<PrognozaPeZi> Dates { get; } = new ObservableCollection<PrognozaPeZi>();

        public string selectedCity;
        public PrognozaPeZi selectedDate;
        public PrognozaPeZi SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; RaisePropertyChanged(); }
        }

        public String SelectedCity {
            get { return selectedCity; }
            set {
                selectedCity = value;
                RaisePropertyChanged("SelectedCity");
                Dates.Clear();
                if (selectedCity != null)
                {
                    foreach (PrognozaPeZi prog in dictPrognoza[selectedCity])
                    {
                        Dates.Add(prog);
                    }
                }
            }
        }

        public async Task GetData()
        {
            var listaPrognoza = await ServiciuPrognoza.PreiaPrognoza();

            foreach (Prognoza prognoza in listaPrognoza)
            {
                Orase.Add(prognoza.Oras);
                dictPrognoza[prognoza.Oras] = prognoza.PrognozaPeZi;
                
            }

        }
    }
}
