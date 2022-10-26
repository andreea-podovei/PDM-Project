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
                return FenomenDescriere.ToLower().Replace(" ", "").Trim() + ".png";
            }
        }

        public override string ToString()
        {
            return FenomenDescriere;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Fenomen);
        }

        private bool Equals (Fenomen fenomen)
        {
            return this.FenomenDescriere == fenomen.FenomenDescriere;
        }
    }
    
}
