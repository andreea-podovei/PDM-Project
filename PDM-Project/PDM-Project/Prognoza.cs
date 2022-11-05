using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
	public class Prognoza : IEnumerable
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }	
		public string Oras { get; set; }
		public DateTime DataPrognoza { get; set; }
		[OneToMany]
		public List<PrognozaPeZi> PrognozaPeZi { get; set; }

		public override string ToString()
		{
            StringBuilder sb = new StringBuilder();
            sb.Append("Oras: " + Oras + " Data dorita: " + DataPrognoza);

            foreach (PrognozaPeZi zi in PrognozaPeZi)
            {
                sb.Append("[" + zi.ToString() + "], ");
            }

            return sb.ToString();

        }

		public string PrognozaZiString()
		{
			return Oras;
		}

        public IEnumerator GetEnumerator()
		{
			return PrognozaPeZi.GetEnumerator();
		}

		public Prognoza() {
			
		}

	}
}
