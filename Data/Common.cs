using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace MVDeserializer.Data
{
	public enum TraitCode
	{
		ElementRate = 11,
		DebuffRate = 12,
		StateRate = 13,
		StateResist = 14,
		Parameter = 21,
		ExParameter = 22,
		SpParameter = 23,
		AttackElement = 31,
		AttackState = 32,
		AttackSpeed = 33,
		AttackTimes = 34,
		AddSkillType = 41,
		SealSkillType = 42,
		AddSkill = 43,
		SealSkill = 44,
		EquipWeapon = 51,
		EquipArmor = 52,
		LockEquip = 53,
		SealEquip = 54,
		SlotType = 55,
		ActionTimesPlus = 61,
		SpecialFlag = 62,
		CollapseEffect = 63,
		PartyAbility = 64
	}

	public enum SpecialFlagType
	{
		AutoBattle = 0,
		Guard = 1,
		Substitute = 2,
		PreserveTP = 3
	}

	public enum DamageType
	{
		None,
		HPDamage,
		MPDamage,
		HPRecover,
		MPRecover,
		HPDrain,
		MPDrain
	}

	public enum EffectCode
	{
		RecoverHP = 11,
		RecoverMP = 12,
		GainTP = 13,
		AddState = 21,
		RemoveState = 22,
		AddBuff = 31,
		AddDebuff = 32,
		RemoveBuff = 33,
		RemoveDebuff = 34,
		Special = 41,
		Grow = 42,
		LearnSkill = 43,
		CommonEvent = 44
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

	public enum EventCode
	{
		Empty = 0,
		ShowText = 101,
		ShowChoices = 102,
		InputNumber = 103,
		SelectItem = 104,
		ShowScrollingText = 105,
		Comment = 108,
		ConditionalBranch = 111,
		Loop = 112,
		BreakLoop = 113,
		ExitEventProcessing = 115,
		CommonEvent = 117,
		Label = 118,
		JumpToLabel = 119,
		ControlSwitches = 121,
		ControlVariables = 122,
		ControlSelfSwitch = 123,
		ControlTimer = 124,
		ChangeGold = 125,
		ChangeItems = 126,
		ChangeWeapons = 127,
		ChangeArmors = 128,
		ChangePartyMember = 129,
		ChangeBattleBGM = 132,
		ChangeVictoryME = 133,
		ChangeSaveAccess = 134,
		ChangeMenuAccess = 135,
		ChangeEncounterDisable = 136,
		ChangeFormationAccess = 137,
		ChangeWindowColor = 138,
		ChangeDefeatME = 139,
		ChangeVehicleBGM = 140,
		TransferPlayer = 201,
		SetVehicleLocation = 202,
		SetEventLocation = 203,
		ScrollMap = 204,
		SetMovementRoute = 205,
		GetOnOffVehicle = 206,
		ChangeTransparency = 211,
		ShowAnimation = 212,
		ShowBalloonIcon = 213,
		EraseEvent = 214,
		ChangePlayerFollowers = 216,
		GatherFollowers = 217,
		FadeoutScreen = 221,
		FadeinScreen = 222,
		TintScreen = 223,
		FlashScreen = 224,
		ShakeScreen = 225,
		Wait = 230,
		ShowPicture = 231,
		MovePicture = 232,
		RotatePicture = 233,
		TintPicture = 234,
		ErasePicture = 235,
		SetWeatherEffect = 236,
		PlayBGM = 241,
		FadeoutBGM = 242,
		SaveBGM = 243,
		ResumeBGM = 244,
		PlayBGS = 245,
		FadeoutBGS = 246,
		PlayME = 249,
		PlaySE = 250,
		StopSE = 251,
		PlayMovie = 261,
		ChangeMapNameDisplay = 281,
		ChangeTileset = 282,
		ChangeBattleBack = 283,
		ChangeParallax = 284,
		GetLocationInfo = 285,
		BattleProcessing = 301,
		ShopProcessing = 302,
		NameInputProcessing = 303,
		ChangeHP = 311,
		ChangeMP = 312,
		ChangeState = 313,
		RecoverAll = 314,
		ChangeEXP = 315,
		ChangeLevel = 316,
		ChangeParameter = 317,
		ChangeSkill = 318,
		ChangeEquipment = 319,
		ChangeName = 320,
		ChangeClass = 321,
		ChangeActorImages = 322,
		ChangeVehicleImage = 323,
		ChangeNickname = 324,
		ChangeProfile = 325,
		ChangeTp = 326,
		ChangeEnemyHP = 331,
		ChangeEnemyMP = 332,
		ChangeEnemyState = 333,
		EnemyRecoverAll = 334,
		EnemyAppear = 335,
		EnemyTransform = 336,
		ShowBattleAnimation = 337,
		ForceAction = 339,
		AbortBattle = 340,
		ChangeEnemyTP = 342,
		OpenMenuScreen = 351,
		OpenSaveScreen = 352,
		GameOver = 353,
		ReturnToTitleScreen = 354,
		Script = 355,
		PluginCommand = 356,
		TextData = 401,
		When = 402,
		WhenCancel = 403,
		ScrollingTextData = 405,
		CommentData = 408,
		Else = 411,
		RepeatAbove = 413,
		IfWin = 601,
		IfEscape = 602,
		IfLose = 603,
		ShopData = 605,
		ScriptData = 655
	}

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

	public interface ICanBeDroppedByEnemies
	{
	}

	public interface IEquipmentType
	{
		EquipmentTypeID EquipmentTypeID { get; set; }
		StatParameters Parameters { get; set; }
	}

	[DebuggerDisplay("Code = {Code}")]
	public struct Trait
	{
		[JsonProperty("code")]
		public TraitCode Code { get; set; }

		[JsonProperty("dataId")]
		public int DataID { get; set; }

		[JsonProperty("value")]
		public float Value { get; set; }
	}

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

	[DebuggerDisplay("{DamageFormula}")]
	public struct Damage
	{
		[JsonProperty("critical")]
		public bool CanBeCritical { get; set; }

		[JsonProperty("elementId")]
		public ElementID ElementID { get; set; }

		[JsonProperty("formula")]
		public string DamageFormula { get; set; }

		[JsonProperty("type")]
		public DamageType Type { get; set; }

		[JsonProperty("variance")]
		public int Variance { get; set; }
	}

	[DebuggerDisplay("Code = {Code}")]
	public struct Effect
	{
		[JsonProperty("code")]
		public EffectCode Code { get; set; }

		[JsonProperty("dataId")]
		public int DataID { get; set; }

		[JsonProperty("value1")]
		public float Value1 { get; set; }

		[JsonProperty("value2")]
		public float Value2 { get; set; }
	}

	[DebuggerDisplay("Code = {Code}")]
	public struct EventCommand
	{
		[JsonProperty("code")]
		public EventCode Code { get; set; }

		[JsonProperty("indent")]
		public int Indent { get; set; }

		[JsonProperty("parameters")]
		public IList<object> Parameters { get; set; }

		//public IDictionary<string, Type> GetParameters()
		//{
		//	switch (Code)
		//	{
		//		case EventCode.Empty:
		//			return new Dictionary<string, Type>();
		//		case EventCode.ShowText:
		//			return new Dictionary<string, Type>
		//			{
		//				{ "faceName", typeof(string) },
		//				{ "faceIndex", typeof(int) },
		//				{ "background", typeof(TextBackground) },
		//				{ "positionType", typeof(TextWindowPosition) }
		//			};
		//		case EventCode.ShowChoices:
		//			return new Dictionary<string, Type>
		//			{
		//				{ "", typeof() }
		//			};
		//			break;
		//		case EventCode.InputNumber:
		//			break;
		//		case EventCode.SelectItem:
		//			break;
		//		case EventCode.ShowScrollingText:
		//			break;
		//		case EventCode.Comment:
		//			break;
		//		case EventCode.ConditionalBranch:
		//			break;
		//		case EventCode.Loop:
		//			break;
		//		case EventCode.BreakLoop:
		//			break;
		//		case EventCode.ExitEventProcessing:
		//			break;
		//		case EventCode.CommonEvent:
		//			break;
		//		case EventCode.Label:
		//			break;
		//		case EventCode.JumpToLabel:
		//			break;
		//		case EventCode.ControlSwitches:
		//			break;
		//		case EventCode.ControlVariables:
		//			break;
		//		case EventCode.ControlSelfSwitch:
		//			break;
		//		case EventCode.ControlTimer:
		//			break;
		//		case EventCode.ChangeGold:
		//			break;
		//		case EventCode.ChangeItems:
		//			break;
		//		case EventCode.ChangeWeapons:
		//			break;
		//		case EventCode.ChangeArmors:
		//			break;
		//		case EventCode.ChangePartyMember:
		//			break;
		//		case EventCode.ChangeBattleBGM:
		//			break;
		//		case EventCode.ChangeVictoryME:
		//			break;
		//		case EventCode.ChangeSaveAccess:
		//			break;
		//		case EventCode.ChangeMenuAccess:
		//			break;
		//		case EventCode.ChangeEncounterDisable:
		//			break;
		//		case EventCode.ChangeFormationAccess:
		//			break;
		//		case EventCode.ChangeWindowColor:
		//			break;
		//		case EventCode.ChangeDefeatME:
		//			break;
		//		case EventCode.ChangeVehicleBGM:
		//			break;
		//		case EventCode.TransferPlayer:
		//			break;
		//		case EventCode.SetVehicleLocation:
		//			break;
		//		case EventCode.SetEventLocation:
		//			break;
		//		case EventCode.ScrollMap:
		//			break;
		//		case EventCode.SetMovementRoute:
		//			break;
		//		case EventCode.GetOnOffVehicle:
		//			break;
		//		case EventCode.ChangeTransparency:
		//			break;
		//		case EventCode.ShowAnimation:
		//			break;
		//		case EventCode.ShowBalloonIcon:
		//			break;
		//		case EventCode.EraseEvent:
		//			break;
		//		case EventCode.ChangePlayerFollowers:
		//			break;
		//		case EventCode.GatherFollowers:
		//			break;
		//		case EventCode.FadeoutScreen:
		//			break;
		//		case EventCode.FadeinScreen:
		//			break;
		//		case EventCode.TintScreen:
		//			break;
		//		case EventCode.FlashScreen:
		//			break;
		//		case EventCode.ShakeScreen:
		//			break;
		//		case EventCode.Wait:
		//			break;
		//		case EventCode.ShowPicture:
		//			break;
		//		case EventCode.MovePicture:
		//			break;
		//		case EventCode.RotatePicture:
		//			break;
		//		case EventCode.TintPicture:
		//			break;
		//		case EventCode.ErasePicture:
		//			break;
		//		case EventCode.SetWeatherEffect:
		//			break;
		//		case EventCode.PlayBGM:
		//			break;
		//		case EventCode.FadeoutBGM:
		//			break;
		//		case EventCode.SaveBGM:
		//			break;
		//		case EventCode.ResumeBGM:
		//			break;
		//		case EventCode.PlayBGS:
		//			break;
		//		case EventCode.FadeoutBGS:
		//			break;
		//		case EventCode.PlayME:
		//			break;
		//		case EventCode.PlaySE:
		//			break;
		//		case EventCode.StopSE:
		//			break;
		//		case EventCode.PlayMovie:
		//			break;
		//		case EventCode.ChangeMapNameDisplay:
		//			break;
		//		case EventCode.ChangeTileset:
		//			break;
		//		case EventCode.ChangeBattleBack:
		//			break;
		//		case EventCode.ChangeParallax:
		//			break;
		//		case EventCode.GetLocationInfo:
		//			break;
		//		case EventCode.BattleProcessing:
		//			break;
		//		case EventCode.ShopProcessing:
		//			break;
		//		case EventCode.NameInputProcessing:
		//			break;
		//		case EventCode.ChangeHP:
		//			break;
		//		case EventCode.ChangeMP:
		//			break;
		//		case EventCode.ChangeState:
		//			break;
		//		case EventCode.RecoverAll:
		//			break;
		//		case EventCode.ChangeEXP:
		//			break;
		//		case EventCode.ChangeLevel:
		//			break;
		//		case EventCode.ChangeParameter:
		//			break;
		//		case EventCode.ChangeSkill:
		//			break;
		//		case EventCode.ChangeEquipment:
		//			break;
		//		case EventCode.ChangeName:
		//			break;
		//		case EventCode.ChangeClass:
		//			break;
		//		case EventCode.ChangeActorImages:
		//			break;
		//		case EventCode.ChangeVehicleImage:
		//			break;
		//		case EventCode.ChangeNickname:
		//			break;
		//		case EventCode.ChangeProfile:
		//			break;
		//		case EventCode.ChangeTp:
		//			break;
		//		case EventCode.ChangeEnemyHP:
		//			break;
		//		case EventCode.ChangeEnemyMP:
		//			break;
		//		case EventCode.ChangeEnemyState:
		//			break;
		//		case EventCode.EnemyRecoverAll:
		//			break;
		//		case EventCode.EnemyAppear:
		//			break;
		//		case EventCode.EnemyTransform:
		//			break;
		//		case EventCode.ShowBattleAnimation:
		//			break;
		//		case EventCode.ForceAction:
		//			break;
		//		case EventCode.AbortBattle:
		//			break;
		//		case EventCode.ChangeEnemyTP:
		//			break;
		//		case EventCode.OpenMenuScreen:
		//			break;
		//		case EventCode.OpenSaveScreen:
		//			break;
		//		case EventCode.GameOver:
		//			break;
		//		case EventCode.ReturnToTitleScreen:
		//			break;
		//		case EventCode.Script:
		//			break;
		//		case EventCode.PluginCommand:
		//			break;
		//		case EventCode.TextData:
		//			break;
		//		case EventCode.When:
		//			break;
		//		case EventCode.WhenCancel:
		//			break;
		//		case EventCode.ScrollingTextData:
		//			break;
		//		case EventCode.CommentData:
		//			break;
		//		case EventCode.Else:
		//			break;
		//		case EventCode.RepeatAbove:
		//			break;
		//		case EventCode.IfWin:
		//			break;
		//		case EventCode.IfEscape:
		//			break;
		//		case EventCode.IfLose:
		//			break;
		//		case EventCode.ShopData:
		//			break;
		//		case EventCode.ScriptData:
		//			break;
		//		default:
		//			break;
		//	}
		//}
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
			throw new NotImplementedException();
		}
	}

	public class StatParametersConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(StatParameters);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
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

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}