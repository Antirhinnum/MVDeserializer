using Newtonsoft.Json;
using System.Diagnostics;

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
}