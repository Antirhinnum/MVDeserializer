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
		public TilesetID ID { get; set; }

		[JsonProperty("flags")]
		public IList<TilesetFlag> Flags { get; set; }

		[JsonProperty("mode")]
		public TilesetMode Mode { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("tilesetNames")]
		public TilesetNames TilesetNames { get; set; }
	}

	public class TilesetNamesConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(TilesetNames);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
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

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}

	//public struct TilesetFlag
	//{
	//	public short Flag { get; set; }

	//	public bool ImpassableDownward => (Flag & 0x0001) == 0x0001;
	//	public bool ImpassableLeftward => (Flag & 0x0002) == 0x0002;
	//}

	//public class TilesetFlagSerializer : JsonConverter
	//{
	//	public override bool CanConvert(Type objectType)
	//	{
	//		return objectType == typeof(IList<TilesetFlag>);
	//	}

	//	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	//	{
	//		throw new NotImplementedException();
	//	}
	//}
}