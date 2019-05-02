using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainWatcher.Core.Model;

namespace TrainWatcher.UnitTests
{
	[TestFixture]
	class ModelTest
	{
		[Test]
		public void DeserializeStationFromJson()
		{
			//Arrange
			string jsonData = "{\"title\":\"Киевская Русановка\",\"region\":null,\"value\":2201180}";

			//Act
			Station obj = JsonConvert.DeserializeObject<Station>(jsonData);

			//Assert
			Assert.Multiple(() =>
			{
				Assert.That(obj.Region, Is.Null);
				Assert.That(obj.Title, Is.EqualTo("Киевская Русановка"));
				Assert.That(obj.Code, Is.EqualTo(2201180));
			});
		}
	}
}
