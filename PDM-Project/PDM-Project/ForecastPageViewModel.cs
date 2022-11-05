using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDM_Project
{
    internal class ForecastPageViewModel
    {

        public List<Prognoza> listaPrognoza { get; set; }
        public List<PrognozaPeZi> PrognozaPeZi { get; set; }

       // public List<Prognoza> listaPrognoza = new List<Prognoza>();


        public ForecastPageViewModel()
        {
            //this.listaPrognoza = new DaoPrognoza().ObtineToateOrasele();
        }

    }
}
