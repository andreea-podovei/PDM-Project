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
		public string DataString { get; set; }

		[ForeignKey(typeof(Prognoza))]
		public int Id {get; set; }	

		public PrognozaPeZi()
		{
		}

		public override string ToString()
		{
			return "Zi: " + Data + "Temp min: " + Temp_min + " Temp max: " + Temp_max + " Descriere: " + Descriere;
		}

        public string StringForecast()
        {
            return "Pentru ziua: " + Data + ", temperatura minima va fi: " + Temp_min + ", temperatura maxima va fi: " + Temp_max + " si se asteapta: " + Descriere;
        }
        public string StringForecastFahrenheit()
        {
            double tempMinF = Temp_min * 1.8 + 32;
            double tempMaxF = Temp_max + 1.8 + 32;

            return "Pentru ziua: " + Data + ", temperatura minima va fi: " + tempMinF + ", temperatura maxima va fi: " + tempMaxF + " si se asteapta: " + Descriere;

        }

    }

}
