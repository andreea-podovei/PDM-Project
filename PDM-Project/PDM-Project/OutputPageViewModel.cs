using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM_Project
{
	internal class OutputPageViewModel
	{
		public List<Prognoza> ListPrognoza { get; set; }
		public List<PrognozaPeZi> ListPrognozaPeZi { get; set; }

		public OutputPageViewModel()
		{
			this.ListPrognoza = new DaoPrognoza().ObtineToateInregistrarile();
			this.ListPrognozaPeZi = new DaoPrognoza().ObtineToateInregistrarilePeZi();
		}
	}
}
