
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
					if (xmlReader.Name == "localitate nume")
					{
						Prognoza prognoza = new Prognoza();
						prognoza.Oras = xmlReader["localitate nume"];

						if (xmlReader.Name == "prognoza data")
						{
							data = DateTime.Parse(xmlReader["prognoza data"]);


							if (xmlReader.Name == "temp_min unit")
							{
								prognoza.Minim = int.Parse(xmlReader["temp_min unit"]);
							}
							
							if (xmlReader.Name == "temp_max unit")
							{
								prognoza.Maxim = int.Parse(xmlReader["temp_max unit"]);
							}

						}

						prognoza.Data = data;

						listaPrognoza.Add(prognoza);
					}
				}
			}

			return listaPrognoza;
		}
	}
}
