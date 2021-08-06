using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum ScrollType
	{
		NoLoop = 0,
		LoopVertically = 1,
		LoopHorizontally = 2,
		LoopBoth = 3
	}

	public enum CharacterDirection
	{
		North = 8,
		East = 6,
		South = 2,
		West = 4
	}

	public enum MoveFrequency
	{
		Lowest = 1,
		Low = 2,
		Normal = 3,
		High = 4,
		Higher = 5
	}

	public enum MoveSpeed
	{
		x8Slower = 1,
		x4Slower = 2,
		x2Slower = 3,
		Normal = 4,
		x2Faster = 5,
		x4Faster = 6
	}

	public enum MoveType
	{
		Fixes = 0,
		Random = 1,
		Approach = 2,
		Custom = 3
	}

	public enum PriorityType
	{
		BelowCharacters = 0,
		SameAsCharacters = 1,
		AboveCharacters = 2
	}

	public enum EventTrigger
	{
		ActionButton = 0,
		PlayerTouch = 1,
		EventTouch = 2,
		Autorun = 3,
		Parallel = 4
	}

	[DebuggerDisplay("{TroopID}")]
	public struct MapEncounter
	{
		[JsonProperty("troopId")]
		public int TroopID { get; set; }

		[JsonProperty("weight")]
		public int Weight { get; set; }

		[JsonIgnore]
		public bool EntireMap => Regions.Count == 0;

		[JsonProperty("regionSet")]
		public IList<int> Regions { get; set; }
	}

	[DebuggerDisplay("{CharacterName}")]
	public struct MapEventImage
	{
		[JsonProperty("characterName")]
		public string CharacterName { get; set; }

		[JsonProperty("characterIndex")]
		public int CharacterIndex { get; set; }

		[JsonProperty("direction")]
		public CharacterDirection Direction { get; set; }

		[JsonProperty("pattern")]
		public int Pattern { get; set; }

		[JsonProperty("tileId")]
		public int TileID { get; set; }
	}

	public struct MapPage
	{
		[JsonProperty("conditions")]
		public MapConditions Conditions { get; set; }

		[JsonProperty("image")]
		public MapEventImage Image { get; set; }

		#region Autonomous Movement

		[JsonProperty("moveType")]
		public MoveType MoveType { get; set; }

		[JsonProperty("moveRoute")]
		public MovementRoute MovementRoute { get; set; }

		[JsonProperty("moveSpeed")]
		public MoveSpeed MoveSpeed { get; set; }

		[JsonProperty("moveFrequency")]
		public MoveFrequency MoveFrequency { get; set; }

		#endregion Autonomous Movement

		#region Options

		[JsonProperty("walkAnime")]
		public bool WalkAnimation { get; set; }

		[JsonProperty("stepAnime")]
		public bool StepAnimation { get; set; }

		[JsonProperty("directionFix")]
		public bool DirectionFix { get; set; }

		[JsonProperty("through")]
		public bool Through { get; set; }

		#endregion Options

		[JsonProperty("priorityType")]
		public PriorityType PriorityType { get; set; }

		[JsonProperty("trigger")]
		public EventTrigger Trigger { get; set; }

		[JsonProperty("list")]
		public IList<EventCommand> Contents { get; set; }

		public struct MapConditions
		{
			[JsonProperty("switch1Valid")]
			public bool Switch1Valid { get; set; }

			[JsonProperty("switch1Id")]
			public int Switch1ID { get; set; }

			[JsonProperty("switch2Valid")]
			public bool Switch2Valid { get; set; }

			[JsonProperty("switch2Id")]
			public int Switch2ID { get; set; }

			[JsonProperty("variableValid")]
			public bool VariableValid { get; set; }

			[JsonProperty("variableId")]
			public int VariableID { get; set; }

			[JsonProperty("variableValue")]
			public int VariableValue { get; set; }

			[JsonProperty("selfSwitchValid")]
			public bool SelfSwitchValid { get; set; }

			[JsonProperty("selfSwitchCh")]
			public string SelfSwitchKey { get; set; }

			[JsonProperty("itemValid")]
			public bool ItemValid { get; set; }

			[JsonProperty("itemId")]
			public int ItemID { get; set; }

			[JsonProperty("actorValid")]
			public bool ActorValid { get; set; }

			[JsonProperty("actorId")]
			public int ActorID { get; set; }
		}
	}

	[DebuggerDisplay("{Name}")]
	public class MapEvent
	{
		[JsonProperty("id")]
		public int ID { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("pages")]
		public IList<MapPage> Pages { get; set; }

		[JsonProperty("x")]
		public int X { get; set; }

		[JsonProperty("y")]
		public int Y { get; set; }
	}

	[DebuggerDisplay("{MVData.Current.MapInfos[ID.ID]?.Name ?? \"null (Data exists)\"}")]
	public class Map
	{
		/// <summary>
		/// The internal ID of this Map.
		/// </summary>
		[JsonIgnore]
		public int ID { get; set; }

		#region General Settings

		[JsonIgnore]
		public string Name => MVData.Current.MapInfos[ID].Name;

		[JsonProperty("displayName")]
		public string DisplayName { get; set; }

		[JsonProperty("tilesetId")]
		public int TilesetID { get; set; }

		[JsonProperty("width")]
		public int Width { get; set; }

		[JsonProperty("height")]
		public int Height { get; set; }

		[JsonProperty("scrollType")]
		public ScrollType ScrollType { get; set; }

		[JsonProperty("encounterStep")]
		public int EncounterSteps { get; set; }

		[JsonProperty("autoplayBgm")]
		public bool AutoplayBGM { get; set; }

		[JsonProperty("bgm")]
		public Sound BGM { get; set; }

		[JsonProperty("autoplayBgs")]
		public bool AutoplayBGS { get; set; }

		[JsonProperty("bgs")]
		public Sound BGS { get; set; }

		[JsonProperty("specifyBattleback")]
		public bool SpecifyBattleback { get; set; }

		[JsonProperty("battleback1Name")]
		public string Battleback1Name { get; set; }

		[JsonProperty("battleback2Name")]
		public string Battleback2Name { get; set; }

		[JsonProperty("disableDashing")]
		public bool DisableDashing { get; set; }

		#endregion General Settings

		#region Parallax Background

		[JsonProperty("parallaxName")]
		public string ParallaxName { get; set; }

		[JsonProperty("parallaxLoopX")]
		public bool ParallaxLoopX { get; set; }

		[JsonProperty("parallaxSx")]
		public int ParallaxScrollX { get; set; }

		[JsonProperty("parallaxLoopY")]
		public bool ParallaxLoopY { get; set; }

		[JsonProperty("parallaxSy")]
		public int ParallaxScrollY { get; set; }

		[JsonProperty("parallaxShow")]
		public bool ParallaxShow { get; set; }

		#endregion Parallax Background

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("encounterList")]
		public IList<MapEncounter> Encounters { get; set; }

		[JsonProperty("data")]
		public IList<int?> Data { get; set; }

		[JsonProperty("events")]
		public List<MapEvent> Events { get; set; }
	}

	//public struct MapData
	//{
	//	public const int TileID_B = 0;
	//	public const int TileID_C = 256;
	//	public const int TileID_D = 512;
	//	public const int TileID_E = 768;
	//	public const int TileID_A5 = 1536;
	//	public const int TileID_A1 = 2048;
	//	public const int TileID_A2 = 2816;
	//	public const int TileID_A3 = 4352;
	//	public const int TileID_A4 = 5888;
	//	public const int TileID_Max = 8192;

	//	public int Data { get; set; }

	//	public MapData(int data)
	//	{
	//		Data = data;
	//	}

	//	public bool IsVisible => Data > 0 && Data < TileID_Max;
	//	public bool IsAutotile => Data >= TileID_A1;
	//	// GetAutotileKind
	//	// GetAutotileShape

	//	public int MakeAutotileID(int kind, int shape)
	//	{
	//		return TileID_A1 + (kind * 48) + shape;
	//	}
	//}

	//public class MapDataConverter : JsonConverter
	//{
	//	public override bool CanConvert(Type objectType)
	//	{
	//		return objectType == typeof(int);
	//	}

	//	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	//}
}