using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
	public class DaoPrognoza
	{
		SQLiteConnection conn;

		public DaoPrognoza()
		{
			string caleBd = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "prognozaMeteo.db");
			conn = new SQLiteConnection(caleBd, false);
			conn.CreateTable<Prognoza>();
			
		}

		public int AdaugaPrognoza(Prognoza prognoza)
		{
			return conn.Insert(prognoza);
		}

		public int AdaugaListaPrognoza(List<Prognoza> listaPrognoza)
		{
			return conn.InsertAll(listaPrognoza);
		}

		public List<Prognoza> ObtineToateInregistrarile()
		{
			return conn.Query<Prognoza>("SELECT * FROM Prognoza");
		}

		public List<Prognoza> ObtinePrognozaDinData(DateTime data)
		{
			return conn.Query<Prognoza>("SELECT * FROM Prognoza WHERE date(Data) = ?", data.ToString("yyyy-MM-dd"));
		}
	}
}
