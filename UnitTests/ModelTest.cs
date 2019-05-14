using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainWatcher.Core.Infrastructure;
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

		[Test]
		public void DeserializeRoutePointFromJson()
		{
			//Arrange
			string jsonData = "{\"code\":\"2208530\",\"station\":\"Херсон_station\",\"stationTrain\":\"Херсон_train\",\"date\":\"суббота, 01.06.2019\",\"time\":\"15:52\",\"sortTime\":1559393520,\"srcDate\":\"2019-06-01\"}";
			JsonSerializerSettings settings = new JsonSerializerSettings();
			settings.Converters.Add(MultiDateConverter.DefaultConverter);
			DateTime assertionTime = DateTime.Today;
			assertionTime = assertionTime.AddHours(15).AddMinutes(52);


			//Act
			RoutePoint obj = JsonConvert.DeserializeObject<RoutePoint>(jsonData, settings);

			//Assert
			Assert.Multiple(() =>
			{
				Assert.That(obj.Code, Is.EqualTo(2208530));
				Assert.That(obj.Station, Is.EqualTo("Херсон_station"));
				Assert.That(obj.TrainName, Is.EqualTo("Херсон_train"));
				Assert.That(obj.Date, Is.EqualTo(new DateTime(2019, 06, 01)));
				Assert.That(obj.Time, Is.EqualTo(assertionTime));
				Assert.That(obj.SortTime, Is.EqualTo(1559393520));
				Assert.That(obj.SrcDate, Is.EqualTo(new DateTime(2019, 6, 1)));
			});
		}

		[Test]
		public void DeserializeWagonGenerlaInforFromJson()
		{
			//Arrange
			string jsonData = "{\"id\":\"С1\",\"title\":\"Сидячий первого класса\",\"letter\":\"С1\",\"places\":8}";

			//Act
			Wagon obj = JsonConvert.DeserializeObject<Wagon>(jsonData);

			//Assert
			Assert.Multiple(() =>
			{
				Assert.That(obj.Id, Is.EqualTo("С1"));
				Assert.That(obj.Title, Is.EqualTo("Сидячий первого класса"));
				Assert.That(obj.Letter, Is.EqualTo("С1"));
				Assert.That(obj.Places, Is.EqualTo(8));
			});
		}

		[Test]
		public void DeserializeRouteFromJson()
		{
			//Arrange
			string jsonData = "{\"num\":\"765О\",\"category\":2,\"isTransformer\":0,\"travelTime\":\"7:22\",\"from\":{\"code\":\"2208530\",\"station\":\"Херсон\",\"stationTrain\":\"Херсон\",\"date\":\"суббота, 01.06.2019\",\"time\":\"15:52\",\"sortTime\":1559393520,\"srcDate\":\"2019-06-01\"},\"to\":{\"code\":\"2200001\",\"station\":\"Киев-Пассажирский\",\"stationTrain\":\"Киев-Пассажирский\",\"date\":\"суббота, 01.06.2019\",\"time\":\"23:14\",\"sortTime\":1559420040},\"types\":[{\"id\":\"С1\",\"title\":\"Сидячий первого класса\",\"letter\":\"С1\",\"places\":8},{\"id\":\"С2\",\"title\":\"Сидячий второго класса\",\"letter\":\"С2\",\"places\":72}],\"child\":{\"minDate\":\"2005-06-02\",\"maxDate\":\"2019-05-02\"},\"allowStudent\":1,\"allowBooking\":1,\"isCis\":0,\"isEurope\":0,\"allowPrivilege\":0,\"disabledPrivilegeByDate\":1}";
			JsonSerializerSettings settings = new JsonSerializerSettings();
			settings.Converters.Add(MultiDateConverter.DefaultConverter);

			//Act
			Route obj = JsonConvert.DeserializeObject<Route>(jsonData, settings);

			//Assert
			Assert.Multiple(() =>
			{
				Assert.That(obj.Number, Is.EqualTo("765О"));
				Assert.That(obj.Category, Is.EqualTo(CategoryType.InterCity));
				Assert.That(obj.TravelTime, Is.EqualTo(new TimeSpan(7, 22, 0)));
				Assert.That(obj.Child.MinDate, Is.EqualTo(new DateTime(2005, 6, 2)));
				Assert.That(obj.Child.MaxDate, Is.EqualTo(new DateTime(2019, 5, 2)));
				Assert.That(obj.AllowStudent, Is.True);
				Assert.That(obj.AllowBooking, Is.True);
				Assert.That(obj.isCis, Is.False);
				Assert.That(obj.isEurope, Is.False);
				Assert.That(obj.AllowPrivilege, Is.False);
				Assert.That(obj.DisabledPrivilegeByDate, Is.True);
			});
					}
		//{"data":{"list":[{"num":"765О","category":2,"isTransformer":0,"travelTime":"7:22","from":{"code":"2208530","station":"Херсон","stationTrain":"Херсон","date":"суббота, 01.06.2019","time":"15:52","sortTime":1559393520,"srcDate":"2019-06-01"},"to":{"code":"2200001","station":"Киев-Пассажирский","stationTrain":"Киев-Пассажирский","date":"суббота, 01.06.2019","time":"23:14","sortTime":1559420040},"types":[{"id":"С1","title":"Сидячий первого класса","letter":"С1","places":8},{"id":"С2","title":"Сидячий второго класса","letter":"С2","places":72}],"child":{"minDate":"2005-06-02","maxDate":"2019-05-02"},"allowStudent":1,"allowBooking":1,"isCis":0,"isEurope":0,"allowPrivilege":0,"disabledPrivilegeByDate":1},{"num":"765К","category":0,"isTransformer":0,"travelTime":"7:22","from":,"to":{"code":"2200001","station":"Киев-Пассажирский","stationTrain":"Киев-Пассажирский","date":"суббота, 01.06.2019","time":"23:14","sortTime":1559420040},"types":[],"child":{"minDate":"2005-06-02","maxDate":"2019-05-02"},"allowStudent":1,"allowBooking":1,"isCis":0,"isEurope":0,"allowPrivilege":0,"disabledPrivilegeByDate":1},{"num":"102Ш","category":0,"isTransformer":0,"travelTime":"11:27","from":{"code":"2208530","station":"Херсон","stationTrain":"Херсон","date":"суббота, 01.06.2019","time":"19:29","sortTime":1559406540,"srcDate":"2019-06-01"},"to":{"code":"2200001","station":"Киев-Пассажирский","stationTrain":"Киев-Пассажирский","date":"воскресенье, 02.06.2019","time":"06:56","sortTime":1559447760},"types":[],"child":{"minDate":"2005-06-02","maxDate":"2019-05-02"},"allowStudent":1,"allowBooking":1,"isCis":0,"isEurope":0,"allowPrivilege":0,"disabledPrivilegeByDate":1}]}}
	}
}
