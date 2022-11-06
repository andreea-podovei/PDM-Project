using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
    internal class StatisticsPageViewModel
    {
        public List<Prognoza> listaPrognoza { get; set; }
        public List<PrognozaPeZi> PrognozaPeZi { get; set; }

        // public List<Prognoza> listaPrognoza = new List<Prognoza>();


        public StatisticsPageViewModel()
        {
            //this.listaPrognoza = new DaoPrognoza().ObtineToateOrasele();
        }
    }
}
