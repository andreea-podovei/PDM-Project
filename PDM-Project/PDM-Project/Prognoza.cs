using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{	public class Prognoza
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Oras { get; set; }
        public DateTime DataPrognoza { get; set; }
        public List<PrognozaPeZi> PrognozaPeZi { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Oras: " + Oras + " ");
            foreach (PrognozaPeZi zi in PrognozaPeZi)
            {
                sb.Append("[" + zi.ToString() + "], ");
            }
            return sb.ToString();
        }

    }
}
