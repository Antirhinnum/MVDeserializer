using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	[Flags]
	public enum TilesetFlag : ushort
	{
		ImpassableDownward = 0x0001,
		ImpassableLeftward = 0x0002,
		ImpassableRightward = 0x0004,
		ImpassableUpward = 0x0008,
		OverCharacter = 0x0010,
		Ladder = 0x0020,
		Bush = 0x0040,
		Counter = 0x0080,
		DamageFloor = 0x0100,
		ImpassableBoat = 0x200,
		ImpassableShip = 0x0400,
		NoAirshipLand = 0x0800,
		TerrainTag = 0xF000
	}

	public enum TilesetMode
	{
		World = 0,
		Area = 1
	}

	[JsonConverter(typeof(TilesetNamesConverter))]
	public struct TilesetNames
	{
		public string A1 { get; set; }
		public string A2 { get; set; }
		public string A3 { get; set; }
		public string A4 { get; set; }
		public string A5 { get; set; }
		public string B { get; set; }
		public string C { get; set; }
		public string D { get; set; }
		public string E { get; set; }
	}

	[DebuggerDisplay("{Name}")]
	public class Tileset
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("mode")]
		public TilesetMode Mode { get; set; }

		[JsonProperty("tilesetNames")]
		public TilesetNames TilesetNames { get; set; }

		[JsonProperty("flags")]
		public IList<TilesetFlag> Flags { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }
	}

	public class TilesetNamesConverter : JsonConverter<TilesetNames>
	{
		public override TilesetNames ReadJson(JsonReader reader, Type objectType, TilesetNames existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IList<string> names = serializer.Deserialize<IList<string>>(reader);
			return new TilesetNames()
			{
				A1 = names[0],
				A2 = names[1],
				A3 = names[2],
				A4 = names[3],
				A5 = names[4],
				B = names[5],
				C = names[6],
				D = names[7],
				E = names[8]
			};
		}

		public override void WriteJson(JsonWriter writer, TilesetNames value, JsonSerializer serializer)
		{
			IList<string> toList = new List<string>() 
			{ 
				value.A1, value.A2, value.A3, value.A4, value.A5, value.B, value.C, value.D, value.E
			};
			serializer.Serialize(writer, toList);
		}
	}
}