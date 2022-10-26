using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
	
	public class PrognozaPeZi 
	{
		[PrimaryKey, AutoIncrement]
		public int Prognoza_id { get; set; }
		public int Temp_min { get; set; }
		public int Temp_max { get; set; }
		public string Descriere { get; set; }
		public DateTime Data { get; set; }

		[ForeignKey(typeof(Prognoza))]
		public int Id {get; set; }	

		public PrognozaPeZi()
		{
		}

		public override string ToString()
		{
			return "Temp min: " + Temp_min + " Temp max: " + Temp_max + " Descriere: " + Descriere;
		}

		
	}

}
