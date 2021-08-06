using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
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
}