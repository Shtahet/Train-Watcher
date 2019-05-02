using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainWatcher.Core.Model
{
	public class Station
	{
		private static Station __kherson;
		private static Station __kyiv;
		public string Title { get; set; }
		public string Region { get; set; }
		[JsonProperty("value")]
		public int Code { get; set; }

		public static Station GetKherson()
		{
			if (__kherson == null)
			{
				__kherson = new Station
				{
					Title = "Херсон",
					Code = 2208530
				};
			}
			return __kherson;
		}

		public static Station GetKyiv()
		{
			if (__kyiv == null)
			{
				__kyiv = new Station
				{
					Title = "Киев",
					Code = 2200001
				};
			}
			return __kyiv;
		}
	}
}
