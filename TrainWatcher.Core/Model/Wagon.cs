using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainWatcher.Core.Model
{
	public class Wagon
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Letter { get; set; }
		public uint Places { get; set; }
	}
}
