using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MVDeserializer.Data
{
	/// <summary>
	/// A set of data representing RPG stats.
	/// </summary>
	[JsonConverter(typeof(StatParametersConverter))]
	public struct StatParameters
	{
		public int MaxHP { get; set; }
		public int MaxMP { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int MagicAttack { get; set; }
		public int MagicDefense { get; set; }
		public int Agility { get; set; }
		public int Luck { get; set; }
	}

	public class StatParametersConverter : JsonConverter<StatParameters>
	{
		public override StatParameters ReadJson(JsonReader reader, Type objectType, StatParameters existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IList<int> parameters = serializer.Deserialize<IList<int>>(reader);
			return new StatParameters()
			{
				MaxHP = parameters[0],
				MaxMP = parameters[1],
				Attack = parameters[2],
				Defense = parameters[3],
				MagicAttack = parameters[4],
				MagicDefense = parameters[5],
				Agility = parameters[6],
				Luck = parameters[7],
			};
		}

		public override void WriteJson(JsonWriter writer, StatParameters value, JsonSerializer serializer)
		{
			IList<int> toList = new List<int> { value.MaxHP, value.MaxMP, value.Attack, value.Defense, value.MagicAttack, value.MagicDefense, value.Agility, value.Luck };
			serializer.Serialize(writer, toList);
		}
	}
}