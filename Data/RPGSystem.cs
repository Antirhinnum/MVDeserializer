using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace MVDeserializer.Data
{
	public enum AttackMotionType
	{
		Thrust = 0,
		Swing = 1,
		Missile = 2
	}

	[DebuggerDisplay("{CharacterImageName}")]
	public struct VehicleData
	{
		[JsonProperty("bgm")]
		public Sound BGM { get; set; }

		[JsonProperty("characterIndex")]
		public int CharacterIndex { get; set; }

		[JsonProperty("characterName")]
		public string CharacterImageName { get; set; }

		[JsonProperty("startMapId")]
		public int StartMapId { get; set; }

		[JsonProperty("startX")]
		public int StartX { get; set; }

		[JsonProperty("startY")]
		public int StartY { get; set; }
	}

	[DebuggerDisplay("ItemCommand = {ItemCommand}, SkillCommand = {SkillCommand}, EquipCommand = {EquipCommand}, StatusCommand = {StatusCommand}, FormationCommand = {FormationCommand}, SaveCommand = {SaveCommand}")]
	[JsonConverter(typeof(MenuCommandTogglesConverter))]
	public struct MenuCommandToggles
	{
		public bool ItemCommand { get; set; }
		public bool SkillCommand { get; set; }
		public bool EquipCommand { get; set; }
		public bool StatusCommand { get; set; }
		public bool FormationCommand { get; set; }
		public bool SaveCommand { get; set; }
	}

	[DebuggerDisplay("{Type} with {WeaponImageId}")]
	public struct AttackMotion
	{
		[JsonProperty("type")]
		public AttackMotionType Type { get; set; }

		[JsonProperty("weaponImageId")]
		public int WeaponImageId { get; set; }
	}

	[DebuggerDisplay("Count = 23")]
	[JsonConverter(typeof(SoundsConverter))]
	public struct Sounds
	{
		public Sound Cursor { get; set; }
		public Sound OK { get; set; }
		public Sound Cancel { get; set; }
		public Sound Buzzer { get; set; }
		public Sound Equip { get; set; }
		public Sound Save { get; set; }
		public Sound Load { get; set; }
		public Sound BattleStart { get; set; }
		public Sound Escape { get; set; }
		public Sound EnemyAttack { get; set; }
		public Sound EnemyDamage { get; set; }
		public Sound BossCollapse1 { get; set; }
		public Sound BossCollapse2 { get; set; }
		public Sound ActorDamage { get; set; }
		public Sound ActorCollapse { get; set; }
		public Sound Recovery { get; set; }
		public Sound Miss { get; set; }
		public Sound Evasion { get; set; }
		public Sound MagicEvasion { get; set; }
		public Sound MagicReflection { get; set; }
		public Sound Shop { get; set; }
		public Sound UseItem { get; set; }
		public Sound UseSkill { get; set; }
	}

	public struct Terms
	{
		[JsonProperty("basic")]
		public BasicTerms Basic { get; set; }

		[JsonProperty("commands")]
		public CommandTerms Commands { get; set; }

		[JsonProperty("params")]
		public ParameterTerms Parameters { get; set; }

		[JsonProperty("messages")]
		public MessageTerms Messages { get; set; }

		[DebuggerDisplay("Count = 10")]
		[JsonConverter(typeof(BasicTermsConverter))]
		public struct BasicTerms
		{
			public string Level { get; set; }
			public string LevelAbbreviated { get; set; }
			public string HP { get; set; }
			public string HPAbbreviated { get; set; }
			public string MP { get; set; }
			public string MPAbbreviated { get; set; }
			public string TP { get; set; }
			public string TPAbbreviated { get; set; }
			public string EXP { get; set; }
			public string EXPAbbreviated { get; set; }
		}

		[DebuggerDisplay("Count = 26")]
		[JsonConverter(typeof(CommandTermsConverter))]
		public struct CommandTerms
		{
			public string Fight { get; set; }
			public string Escape { get; set; }
			public string Attack { get; set; }
			public string Guard { get; set; }
			public string Item { get; set; }
			public string Skill { get; set; }
			public string Equip { get; set; }
			public string Status { get; set; }
			public string Formation { get; set; }
			public string Save { get; set; }
			public string GameEnd { get; set; }
			public string Options { get; set; }
			public string Weapon { get; set; }
			public string Armor { get; set; }
			public string KeyItem { get; set; }
			public string UnusedEquip { get; set; }
			public string Optimize { get; set; }
			public string Clear { get; set; }
			public string NewGame { get; set; }
			public string Continue { get; set; }
			public string Unused1 { get; set; }
			public string ToTitle { get; set; }
			public string Cancel { get; set; }
			public string Unused2 { get; set; }
			public string Buy { get; set; }
			public string Sell { get; set; }
		}

		[DebuggerDisplay("Count = 10")]
		[JsonConverter(typeof(ParameterTermsConverter))]
		public struct ParameterTerms
		{
			public string MaxHP { get; set; }
			public string MaxMP { get; set; }
			public string Attack { get; set; }
			public string Defense { get; set; }
			public string MagicAttack { get; set; }
			public string MagicDefense { get; set; }
			public string Agility { get; set; }
			public string Luck { get; set; }
			public string HitRate { get; set; }
			public string EvasionRate { get; set; }
		}

		[DebuggerDisplay("Count = 50")]
		public struct MessageTerms
		{
			[JsonProperty("actionFailure")]
			public string ActionFailure { get; set; }

			[JsonProperty("actorDamage")]
			public string ActorDamage { get; set; }

			[JsonProperty("actorDrain")]
			public string ActorDrain { get; set; }

			[JsonProperty("actorGain")]
			public string ActorGain { get; set; }

			[JsonProperty("actorLoss")]
			public string ActorLoss { get; set; }

			[JsonProperty("actorNoDamage")]
			public string ActorNoDamage { get; set; }

			[JsonProperty("actorNoHit")]
			public string ActorNoHit { get; set; }

			[JsonProperty("actorRecovery")]
			public string ActorRecovery { get; set; }

			[JsonProperty("alwaysDash")]
			public string AlwaysDash { get; set; }

			[JsonProperty("bgmVolume")]
			public string BGMVolume { get; set; }

			[JsonProperty("bgsVolume")]
			public string BGSVolume { get; set; }

			[JsonProperty("buffAdd")]
			public string BuffAdd { get; set; }

			[JsonProperty("buffRemove")]
			public string BuffRemove { get; set; }

			[JsonProperty("commandRemember")]
			public string CommandRemember { get; set; }

			[JsonProperty("counterAttack")]
			public string CounterAttack { get; set; }

			[JsonProperty("criticalToActor")]
			public string CriticalToActor { get; set; }

			[JsonProperty("criticalToEnemy")]
			public string CriticalToEnemy { get; set; }

			[JsonProperty("debuffAdd")]
			public string DebuffAdd { get; set; }

			[JsonProperty("defeat")]
			public string Defeat { get; set; }

			[JsonProperty("emerge")]
			public string Emerge { get; set; }

			[JsonProperty("enemyDamage")]
			public string EnemyDamage { get; set; }

			[JsonProperty("enemyDrain")]
			public string EnemyDrain { get; set; }

			[JsonProperty("enemyGain")]
			public string EnemyGain { get; set; }

			[JsonProperty("enemyLoss")]
			public string EnemyLoss { get; set; }

			[JsonProperty("enemyNoDamage")]
			public string EnemyNoDamage { get; set; }

			[JsonProperty("enemyNoHit")]
			public string EnemyNoHit { get; set; }

			[JsonProperty("enemyRecovery")]
			public string EnemyRecovery { get; set; }

			[JsonProperty("escapeFailure")]
			public string EscapeFailure { get; set; }

			[JsonProperty("escapeStart")]
			public string EscapeStart { get; set; }

			[JsonProperty("evasion")]
			public string Evasion { get; set; }

			[JsonProperty("expNext")]
			public string EXPNext { get; set; }

			[JsonProperty("expTotal")]
			public string EXPTotal { get; set; }

			[JsonProperty("file")]
			public string File { get; set; }

			[JsonProperty("levelUp")]
			public string LevelUp { get; set; }

			[JsonProperty("loadMessage")]
			public string LoadMessage { get; set; }

			[JsonProperty("magicEvasion")]
			public string MagicEvasion { get; set; }

			[JsonProperty("magicReflection")]
			public string MagicReflection { get; set; }

			[JsonProperty("meVolume")]
			public string MEVolume { get; set; }

			[JsonProperty("obtainExp")]
			public string ObtainEXP { get; set; }

			[JsonProperty("obtainGold")]
			public string ObtainGold { get; set; }

			[JsonProperty("obtainItem")]
			public string ObtainItem { get; set; }

			[JsonProperty("obtainSkill")]
			public string ObtainSkill { get; set; }

			[JsonProperty("partyName")]
			public string PartyName { get; set; }

			[JsonProperty("possession")]
			public string Possession { get; set; }

			[JsonProperty("preemptive")]
			public string Preemptive { get; set; }

			[JsonProperty("saveMessage")]
			public string SaveMessage { get; set; }

			[JsonProperty("seVolume")]
			public string SEVolume { get; set; }

			[JsonProperty("substitute")]
			public string Substitute { get; set; }

			[JsonProperty("surprise")]
			public string Surprise { get; set; }

			[JsonProperty("useItem")]
			public string UseItem { get; set; }

			[JsonProperty("victory")]
			public string Victory { get; set; }
		}

		public class BasicTermsConverter : JsonConverter<BasicTerms>
		{
			public override BasicTerms ReadJson(JsonReader reader, Type objectType, BasicTerms existingValue, bool hasExistingValue, JsonSerializer serializer)
			{
				IList<string> terms = serializer.Deserialize<IList<string>>(reader);
				return new BasicTerms()
				{
					Level = terms[0],
					LevelAbbreviated = terms[1],
					HP = terms[2],
					HPAbbreviated = terms[3],
					MP = terms[4],
					MPAbbreviated = terms[5],
					TP = terms[6],
					TPAbbreviated = terms[7],
					EXP = terms[8],
					EXPAbbreviated = terms[9]
				};
			}

			public override void WriteJson(JsonWriter writer, BasicTerms value, JsonSerializer serializer)
			{
				IList<string> toList = new List<string>
				{
					value.Level,
					value.LevelAbbreviated,
					value.HP,
					value.HPAbbreviated,
					value.MP,
					value.MPAbbreviated,
					value.TP,
					value.TPAbbreviated,
					value.EXP,
					value.EXPAbbreviated
				};
				serializer.Serialize(writer, toList);
			}
		}

		public class CommandTermsConverter : JsonConverter<CommandTerms>
		{
			public override CommandTerms ReadJson(JsonReader reader, Type objectType, CommandTerms existingValue, bool hasExistingValue, JsonSerializer serializer)
			{
				IList<string> terms = serializer.Deserialize<IList<string>>(reader);
				return new CommandTerms()
				{
					Fight = terms[0],
					Escape = terms[1],
					Attack = terms[2],
					Guard = terms[3],
					Item = terms[4],
					Skill = terms[5],
					Equip = terms[6],
					Status = terms[7],
					Formation = terms[8],
					Save = terms[9],
					GameEnd = terms[10],
					Options = terms[11],
					Weapon = terms[12],
					Armor = terms[13],
					KeyItem = terms[14],
					UnusedEquip = terms[15],
					Optimize = terms[16],
					Clear = terms[17],
					NewGame = terms[18],
					Continue = terms[19],
					Unused1 = terms[20],
					ToTitle = terms[21],
					Cancel = terms[22],
					Unused2 = terms[23],
					Buy = terms[24],
					Sell = terms[25]
				};
			}

			public override void WriteJson(JsonWriter writer, CommandTerms value, JsonSerializer serializer)
			{
				IList<string> toList = new List<string>
				{
					value.Fight,
					value.Escape,
					value.Attack,
					value.Guard,
					value.Item,
					value.Skill,
					value.Equip,
					value.Status,
					value.Formation,
					value.Save,
					value.GameEnd,
					value.Options,
					value.Weapon,
					value.Armor,
					value.KeyItem,
					value.UnusedEquip,
					value.Optimize,
					value.Clear,
					value.NewGame,
					value.Continue,
					value.Unused1,
					value.ToTitle,
					value.Cancel,
					value.Unused2,
					value.Buy,
					value.Sell,
				};
				serializer.Serialize(writer, toList);
			}
		}

		public class ParameterTermsConverter : JsonConverter<ParameterTerms>
		{
			public override ParameterTerms ReadJson(JsonReader reader, Type objectType, ParameterTerms existingValue, bool hasExistingValue, JsonSerializer serializer)
			{
				IList<string> terms = serializer.Deserialize<IList<string>>(reader);
				return new ParameterTerms()
				{
					MaxHP = terms[0],
					MaxMP = terms[1],
					Attack = terms[2],
					Defense = terms[3],
					MagicAttack = terms[4],
					MagicDefense = terms[5],
					Agility = terms[6],
					Luck = terms[7],
					HitRate = terms[8],
					EvasionRate = terms[9]
				};
			}

			public override void WriteJson(JsonWriter writer, ParameterTerms value, JsonSerializer serializer)
			{
				IList<string> toList = new List<string>
				{
					value.MaxHP,
					value.MaxMP,
					value.Attack,
					value.Defense,
					value.MagicAttack,
					value.MagicDefense,
					value.Agility,
					value.Luck,
					value.HitRate,
					value.EvasionRate
				};
				serializer.Serialize(writer, toList);
			}
		}
	}

	public struct TestBattler
	{
		[JsonProperty("actorId")]
		public int ActorId { get; set; }

		[JsonProperty("equips")]
		public IList<int> Equipment { get; set; }

		[JsonProperty("level")]
		public int Level { get; set; }
	}

	public class MenuCommandTogglesConverter : JsonConverter<MenuCommandToggles>
	{
		public override MenuCommandToggles ReadJson(JsonReader reader, Type objectType, MenuCommandToggles existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IList<bool> toggles = serializer.Deserialize<IList<bool>>(reader);
			return new MenuCommandToggles()
			{
				ItemCommand = toggles[0],
				SkillCommand = toggles[1],
				EquipCommand = toggles[2],
				StatusCommand = toggles[3],
				FormationCommand = toggles[4],
				SaveCommand = toggles[5]
			};
		}

		public override void WriteJson(JsonWriter writer, MenuCommandToggles value, JsonSerializer serializer)
		{
			IList<bool> toList = new List<bool>
			{
				value.ItemCommand, value.SkillCommand, value.EquipCommand, value.StatusCommand, value.FormationCommand, value.SaveCommand
			};
			serializer.Serialize(writer, toList);
		}
	}

	public class SoundsConverter : JsonConverter<Sounds>
	{
		public override Sounds ReadJson(JsonReader reader, Type objectType, Sounds existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IList<Sound> sounds = serializer.Deserialize<IList<Sound>>(reader);
			return new Sounds()
			{
				Cursor = sounds[0],
				OK = sounds[1],
				Cancel = sounds[2],
				Buzzer = sounds[3],
				Equip = sounds[4],
				Save = sounds[5],
				Load = sounds[6],
				BattleStart = sounds[7],
				Escape = sounds[8],
				EnemyAttack = sounds[9],
				EnemyDamage = sounds[10],
				BossCollapse1 = sounds[11],
				BossCollapse2 = sounds[12],
				ActorDamage = sounds[13],
				ActorCollapse = sounds[14],
				Recovery = sounds[15],
				Miss = sounds[16],
				Evasion = sounds[17],
				MagicEvasion = sounds[18],
				MagicReflection = sounds[19],
				Shop = sounds[20],
				UseItem = sounds[21],
				UseSkill = sounds[22]
			};
		}

		public override void WriteJson(JsonWriter writer, Sounds value, JsonSerializer serializer)
		{
			IList<Sound> toList = new List<Sound>
			{
				value.Cursor,
				value.OK,
				value.Cancel,
				value.Buzzer,
				value.Equip,
				value.Save,
				value.Load,
				value.BattleStart,
				value.Escape,
				value.EnemyAttack,
				value.EnemyDamage,
				value.BossCollapse1,
				value.BossCollapse2,
				value.ActorDamage,
				value.ActorCollapse,
				value.Recovery,
				value.Miss,
				value.Evasion,
				value.MagicEvasion,
				value.MagicReflection,
				value.Shop,
				value.UseItem,
				value.UseSkill
			};
			serializer.Serialize(writer, toList);
		}
	}

	[DebuggerDisplay("{GameTitle}")]
	public class RPGSystem
	{
		[JsonProperty("partyMembers")]
		public IList<int> StartingParty { get; set; }

		[JsonProperty("gameTitle")]
		public string GameTitle { get; set; }

		[JsonProperty("currencyUnit")]
		public string Currency { get; set; }

		#region Vehicle Images

		[JsonProperty("boat")]
		public VehicleData Boat { get; set; }

		[JsonProperty("ship")]
		public VehicleData Ship { get; set; }

		[JsonProperty("airship")]
		public VehicleData Airship { get; set; }

		#endregion Vehicle Images

		[JsonConverter(typeof(ColorConverter))]
		[JsonProperty("windowTone")]
		public Color WindowColor { get; set; }

		#region Options

		[JsonProperty("optSideView")]
		public bool ViewSideViewBattle { get; set; }

		[JsonProperty("optTransparent")]
		public bool StartTransparent { get; set; }

		[JsonProperty("optFollowers")]
		public bool ShowPlayerFollowers { get; set; }

		[JsonProperty("optSlipDeath")]
		public bool KnockoutBySlipDamage { get; set; }

		[JsonProperty("optFloorDeath")]
		public bool KnockoutByFloorDamage { get; set; }

		[JsonProperty("optDisplayTp")]
		public bool DisplayTPInBattle { get; set; }

		[JsonProperty("optExtraExp")]
		public bool EXPForReserveMembers { get; set; }

		#endregion Options

		/// <summary>
		/// A list of all user-defined Skill Types that are considered to be magic. See <see cref="SkillTypes"/>
		/// </summary>
		[JsonProperty("magicSkills")]
		public IList<int> MagicSkillTypes { get; set; }

		#region Music

		[JsonProperty("titleBgm")]
		public Sound TitleBGM { get; set; }

		[JsonProperty("battleBgm")]
		public Sound BattleBGM { get; set; }

		[JsonProperty("victoryMe")]
		public Sound VictoryME { get; set; }

		[JsonProperty("defeatMe")]
		public Sound DefeatME { get; set; }

		[JsonProperty("gameoverMe")]
		public Sound GameOverME { get; set; }

		#endregion Music

		[JsonProperty("sounds")]
		public Sounds Sounds { get; set; }

		[JsonProperty("menuCommands")]
		public MenuCommandToggles MenuCommands { get; set; }

		[JsonProperty("attackMotions")]
		public IList<AttackMotion> AttackMotions { get; set; }

		#region Starting Positions

		[JsonProperty("startId")]
		public int StartMapId { get; set; }

		[JsonProperty("startX")]
		public int StartMapX { get; set; }

		[JsonProperty("startY")]
		public int StartMapY { get; set; }

		#endregion Starting Positions

		#region Title Screen

		[JsonProperty("title1Name")]
		public string Title1Name { get; set; }

		[JsonProperty("title2Name")]
		public string Title2Name { get; set; }

		[JsonProperty("optDrawTitle")]
		public bool DrawGameTitle { get; set; }

		#endregion Title Screen

		#region Types

		[JsonProperty("elements")]
		public IList<string> Elements { get; set; }

		[JsonProperty("skillTypes")]
		public IList<string> SkillTypes { get; set; }

		[JsonProperty("weaponTypes")]
		public IList<string> WeaponTypes { get; set; }

		[JsonProperty("armorTypes")]
		public IList<string> ArmorTypes { get; set; }

		[JsonProperty("equipTypes")]
		public IList<string> EquipTypes { get; set; }

		#endregion Types

		[JsonProperty("terms")]
		public Terms Terms { get; set; }

		#region Metadata

		[JsonProperty("editMapId")]
		public int EditMapId { get; set; }

		[JsonProperty("locale")]
		public string Locale { get; set; }

		[JsonProperty("switches")]
		public IList<string> Switches { get; set; }

		[JsonProperty("variables")]
		public IList<string> Variables { get; set; }

		[JsonProperty("versionId")]
		public int VersionId { get; set; }

		#endregion Metadata

		#region Troop Testing

		[JsonProperty("testBattlers")]
		public IList<TestBattler> TestBattlers { get; set; }

		[JsonProperty("testTroopId")]
		public int TestTroopId { get; set; }

		[JsonProperty("battleback1Name")]
		public string Battleback1Name { get; set; }

		[JsonProperty("battleback2Name")]
		public string Battleback2Name { get; set; }

		/// <summary>
		/// Note: Unused.
		/// </summary>
		[JsonProperty("battlerHue")]
		public int BattlerHue { get; set; }

		#endregion Troop Testing
	}
}
