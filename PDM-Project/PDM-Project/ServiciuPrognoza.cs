
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PDM_Project
{
	public class ServiciuPrognoza
	{
		public static async Task<List<Prognoza>> PreiaPrognoza()
		{
			List<Prognoza> listaPrognoza = new List<Prognoza>();
			XmlReaderSettings settings = new XmlReaderSettings()
			{
				Async = true
			};

			XmlReader xmlReader = XmlReader.Create("file:///C:/Users/radux/OneDrive/Desktop/prognoza-orase-5zile%20(1).xml", settings);

			DateTime data = DateTime.Now;

			while (await xmlReader.ReadAsync())
			{
				if (xmlReader.IsStartElement())
				{
					Prognoza prognoza = new Prognoza();
					if (xmlReader.Name == "localitate")
					{						
						prognoza.Oras = xmlReader["nume"];
						System.Diagnostics.Debug.WriteLine(prognoza.Oras);
					}	
					if (xmlReader.Name == "prognoza")
					{
					data = DateTime.Parse(xmlReader["data"]);
						System.Diagnostics.Debug.WriteLine(data);
					}

					if (xmlReader.Name == "temp_min")
					{
						await xmlReader.ReadAsync();
						prognoza.Minim = int.Parse(xmlReader.Value, System.Globalization.CultureInfo.InvariantCulture);
						System.Diagnostics.Debug.WriteLine(prognoza.Minim);
					}

					if (xmlReader.Name == "temp_max")
					{
						await xmlReader.ReadAsync();					
						prognoza.Maxim = int.Parse(xmlReader.Value, System.Globalization.CultureInfo.InvariantCulture);
						System.Diagnostics.Debug.WriteLine(prognoza.Maxim);
					}
					
					if (xmlReader.Name == "fenomen_descriere")
					{
						await xmlReader.ReadAsync();
						prognoza.Descriere = xmlReader.Value;
						System.Diagnostics.Debug.WriteLine(prognoza.Descriere);
					}


					prognoza.Data = data;

					listaPrognoza.Add(prognoza);
					
				}
			}

			return listaPrognoza;
		}
	}
}
