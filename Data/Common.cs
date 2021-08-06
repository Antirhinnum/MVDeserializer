using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace MVDeserializer.Data
{
	public enum SpecialFlagType
	{
		AutoBattle = 0,
		Guard = 1,
		Substitute = 2,
		PreserveTP = 3
	}

	public enum SpecialEffectType
	{
		Escape = 0
	}

	public enum HitType
	{
		Certain = 0,
		Physical = 1,
		Magical = 2
	}

	public enum Occasion
	{
		Always = 0,
		Battle = 1,
		Menu = 2,
		Never = 3
	}

	public enum Scope
	{
		None = 0,
		OneEnemy = 1,
		AllEnemies = 2,
		OneRandomEnemy = 3,
		TwoRandomEnemies = 4,
		ThreeRandomEnemies = 5,
		FourRandomEnemies = 6,
		OneAlly = 7,
		AllAllies = 8,
		OneAllyDead = 9,
		AllAlliesDead = 10,
		User = 11
	}

	//public enum SoundType
	//{
	//	BackgroundMusic,
	//	BackgroundSound,
	//	MusicEffect,
	//	SoundEffect
	//}

	public enum TextBackground
	{
		Window = 0,
		Dim = 1,
		Transparent = 2
	}

	public enum TextWindowPosition
	{
		Top = 0,
		Middle = 1,
		Bottom = 2
	}

	public enum MoveEventCode
	{
		End = 0,
		MoveDown = 1,
		MoveLeft = 2,
		MoveRight = 3,
		MoveUp = 4,
		MoveLowerLeft = 5,
		MoveLowerRight = 6,
		MoveUpperLeft = 7,
		MoveUpperRight = 8,
		MoveRandom = 9,
		MoveToward = 10,
		MoveAway = 11,
		MoveForward = 12,
		MoveBackward = 13,
		Jump = 14,
		Wait = 15,
		TurnDown = 16,
		TurnLeft = 17,
		TurnRight = 18,
		TurnUp = 19,
		Turn90DegreesRight = 20,
		Turn90DegreesLeft = 21,
		Turn180Degrees = 22,
		Turn90DegreesRightOrLeft = 23,
		TurnRandom = 24,
		TurnToward = 25,
		TurnAway = 26,
		SwitchOn = 27,
		SwitchOff = 28,
		ChangeSpeed = 29,
		ChangeFrequency = 30,
		WalkAnimationOn = 31,
		WalkAnimationOff = 32,
		StepAnimationOn = 33,
		StepAnimationOff = 34,
		DirectionFixOn = 35,
		DirectionFixOff = 36,
		ThroughOn = 37,
		ThroughOff = 38,
		TransparentOn = 39,
		TransparentOff = 40,
		ChangeImage = 41,
		ChangeOpacity = 42,
		ChangeBlendMode = 43,
		PlaySE = 44,
		Script = 45
	}

	public struct MovementRoute
	{
		[JsonProperty("list")]
		public IList<MoveEventCommand> MovementCommands { get; set; }

		[JsonProperty("repeat")]
		public bool Repeat { get; set; }

		[JsonProperty("skippable")]
		public bool Skippable { get; set; }

		[JsonProperty("wait")]
		public bool Wait { get; set; }
	}

	[DebuggerDisplay("Code = {Code}")]
	public struct MoveEventCommand
	{
		[JsonProperty("code")]
		public MoveEventCode Code { get; set; }

		[JsonProperty("parameters")]
		public IList<object> Parameters { get; set; }

		[JsonProperty("indent")]
		public int? Indent { get; set; }
	}

	//[JsonConverter(typeof(SoundConverter))]
	[DebuggerDisplay("{Name} ({Volume}, {Pitch}, {Pan})")]
	public class Sound
	{
		//[JsonIgnore]
		//public SoundType SoundType { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("pan")]
		public int Pan { get; set; }

		[JsonProperty("pitch")]
		public int Pitch { get; set; }

		[JsonProperty("volume")]
		public int Volume { get; set; }
	}

	//public class SoundConverter : JsonConverter
	//{
	//	public override bool CanConvert(Type objectType)
	//	{
	//		return objectType == typeof(AnimationCell);
	//	}

	//	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	//	{
	//		JToken t = JToken.FromObject(existingValue);
	//		((JObject)t).prop

	//		Sound sound = serializer.Deserialize<Sound>(reader);
	//		sound.SoundType =
	//	}

	//	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	//	{
	//		throw new NotImplementedException();
	//	}
	//}

	public class ColorConverter : JsonConverter<Color>
	{
		public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IList<int> rgba = serializer.Deserialize<IList<int>>(reader);
			return Color.FromArgb(rgba[3], rgba[0], rgba[1], rgba[2]);
		}

		public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
		{
			IList<int> toList = new List<int> { value.R, value.G, value.B, value.A };
			serializer.Serialize(writer, toList);
		}
	}
}