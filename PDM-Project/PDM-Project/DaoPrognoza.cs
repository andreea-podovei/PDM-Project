using SQLite;
using SQLiteNetExtensions.Extensions;
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
				conn.CreateTable<PrognozaPeZi>();					
		}

		public void AdaugaListaPrognoza(List<Prognoza> listaPrognoza)
		{
			conn.InsertAll(listaPrognoza);	
			
		}
		
		public void AdaugaListaPrognozaPeZi(List<PrognozaPeZi> listaPrognozaPeZi)
		{
			 conn.InsertAll(listaPrognozaPeZi);
		}
		
		public List<Prognoza> ObtineToateInregistrarile()
		{
			return conn.Query<Prognoza>("SELECT * FROM Prognoza p JOIN PrognozaPeZi z ON p.Id = z.Id");
		}
		
		
		public List<Prognoza> ObtineToateInregistrarile1()
		{
			return conn.Query<Prognoza>("SELECT * FROM Prognoza");
		}
		
		public List<PrognozaPeZi> ObtineToateInregistrarile2()
		{
			return conn.Query<PrognozaPeZi>("SELECT * FROM PrognozaPeZi");
		}
		
		public List<Prognoza> ObtinePrognozaDinData(DateTime dataPrognoza)
		{
			//return conn.Query<Prognoza>("SELECT * FROM Prognoza WHERE date(Data) = ?", data.ToString("yyyy-MM-dd"));
			return conn.Query<Prognoza>("SELECT * FROM Prognoza WHERE dataPrognoza = ?", dataPrognoza.ToString("yyyy-MM-dd"));
		}

		
	}
}
