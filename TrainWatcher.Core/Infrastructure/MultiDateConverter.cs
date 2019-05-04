using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainWatcher.Core.Infrastructure
{
	public class MultiDateConverter : JsonConverter
	{
		private static MultiDateConverter _defaultConverter;
		public static MultiDateConverter DefaultConverter
		{
			get
			{
				if (_defaultConverter == null)
				{
					_defaultConverter = new MultiDateConverter();
					_defaultConverter.DateFormats.Add("dddd, dd.MM.yyyy");
					_defaultConverter.DateFormats.Add("HH:mm");
					_defaultConverter.DateFormats.Add("yyyy-MM-dd");
				}
				return _defaultConverter;
			}
		}
		public List<string> DateFormats { get; } = new List<string>();

		public override bool CanConvert(Type objectType)
		{
			return objectType  == typeof(DateTime);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			string jsonDate = reader.Value.ToString();

			foreach(var format in DateFormats)
			{
				if(DateTime.TryParseExact(jsonDate, format, CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out DateTime result))
				{
					return result;
				}
			}

			throw new JsonException($"MultiDateConverter can't serialize date from {existingValue}");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

	}
}
