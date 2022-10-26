using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
    public class FenomenComparer: IEqualityComparer<Fenomen>
    {
        public bool Equals (Fenomen f1, Fenomen f2)
        {
            return f1.FenomenDescriere.Equals (f2.FenomenDescriere);
        }

        public int GetHashCode(Fenomen obj)
        {
            return obj.FenomenDescriere.GetHashCode();
        }
    }
}
