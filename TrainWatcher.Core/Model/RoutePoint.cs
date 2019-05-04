using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TrainWatcher.Core.Model
{
	public class RoutePoint
	{
		public int Code { get; set; }
		public string Station { get; set; }
		[JsonProperty("stationTrain")]
		public string TrainName { get; set; }
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public long SortTime { get; set; }
		public DateTime SrcDate { get; set; }
	}
}
