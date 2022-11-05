
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;

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

			Debug.WriteLine("In serviciu prognoza");

			XmlReader xmlReader = XmlReader.Create("file:///C:/Users/Andreea/Downloads/prognoza-orase-5zile.xml", settings);

            while (await xmlReader.ReadAsync())
            {
                if (xmlReader.IsStartElement())
                {
                    
                    
                    if (xmlReader.Name == "localitate")
                    {
                        Prognoza prognoza = new Prognoza();
                        prognoza.PrognozaPeZi = new List<PrognozaPeZi>();

                        prognoza.Oras = xmlReader["nume"];
                        Debug.WriteLine(xmlReader["nume"]);

                        XmlReader innerReader = xmlReader.ReadSubtree();

                        innerReader.ReadToFollowing("DataPrognozei");
                        await innerReader.ReadAsync();
                        prognoza.DataPrognoza = DateTime.Parse(innerReader.Value);
                        Debug.WriteLine(prognoza.DataPrognoza);

                        while (innerReader.ReadToFollowing("prognoza"))
                        {
                            PrognozaPeZi prognozaPeZi = new PrognozaPeZi();
                            
                            Debug.WriteLine(innerReader.Name);
                            prognozaPeZi.Data = DateTime.Parse(innerReader["data"]);
                            Debug.WriteLine(prognozaPeZi.Data);

                            innerReader.ReadToDescendant("temp_min");
                            Debug.WriteLine(innerReader.Name);
                            await innerReader.ReadAsync();
                            int temp_min = int.Parse(innerReader.Value, System.Globalization.CultureInfo.InvariantCulture);
                            Debug.WriteLine(temp_min);
                            prognozaPeZi.Temp_min = temp_min;

                            innerReader.ReadToFollowing("temp_max");
                            Debug.WriteLine(innerReader.Name);
                            await innerReader.ReadAsync();
                            int temp_max = int.Parse(innerReader.Value, System.Globalization.CultureInfo.InvariantCulture);
                            Debug.WriteLine(temp_max);
                            prognozaPeZi.Temp_max = temp_max;

                            innerReader.ReadToFollowing("fenomen_descriere");
                            Debug.WriteLine(innerReader.Name);
                            await innerReader.ReadAsync();
                            string descriere = innerReader.Value;
                            Debug.WriteLine(descriere);
                            prognozaPeZi.Descriere = descriere;

                            prognoza.PrognozaPeZi.Add(prognozaPeZi);
                        }

                        listaPrognoza.Add(prognoza);
                        innerReader.Close();
                    }

                }
                
            }

            xmlReader.Close();

            return listaPrognoza;
        }
     
    }
}
