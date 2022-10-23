using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
	public class Prognoza
	{
		public int Id { get; set; }	
		public string Oras { get; set; }
		public int Minim { get; set; }	
		public int Maxim { get; set; }	
		public string Descriere { get; set; }
		public DateTime Data { get; set; }	

		public Prognoza() {}

		
	}
}
