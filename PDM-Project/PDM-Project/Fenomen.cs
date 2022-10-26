using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
    public class Fenomen
    {

        public string FenomenDescriere { get; set; }
        public string ResursaFenomen
        {
            get
            {
                return FenomenDescriere.ToLower().Replace(" ", "").Replace(",", "").Trim() + ".png";
            }
        }

        public override string ToString()
        {
            return FenomenDescriere;
        }

    }
    
}
