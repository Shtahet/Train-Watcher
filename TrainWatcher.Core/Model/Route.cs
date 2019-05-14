using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainWatcher.Core.Model
{
	public enum CategoryType
	{
		Fast = 0,
		InterCity = 2
	}

	public class Route
	{
		[JsonProperty("num")]
		public string Number { get; set; }
		public CategoryType Category { get; set; }
		public bool IsTransformer { get; set; }
		public TimeSpan TravelTime { get; set; }
		public RoutePoint From { get; set; }
		public RoutePoint To { get; set; }
		[JsonProperty("types")]
		public List<Wagon> Wagons { get; set; }
		public ChildRouteInfo Child { get; set; }
		public bool AllowStudent { get; set; }
		public bool AllowBooking { get; set; }
		public bool isCis { get; set; }
		public bool isEurope { get; set; }
		public bool AllowPrivilege { get; set; }
		public bool DisabledPrivilegeByDate { get; set; }
	}

	public class ChildRouteInfo
	{
		public DateTime MinDate { get; set; }
		public DateTime MaxDate { get; set; }
	}
}
