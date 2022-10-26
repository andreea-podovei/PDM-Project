using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
    public class PrognozaPeZi
    {
        public int Temp_min { get; set; }
        public int Temp_max { get; set; }
        public string Descriere { get; set; }
        public DateTime Data { get; set; }

        public PrognozaPeZi()
        {

        }

        public override string ToString()
        {
            return "Temp min: " + Temp_min + " Temp max: " + Temp_max + " Descriere: " + Descriere;
        }
    }
}
