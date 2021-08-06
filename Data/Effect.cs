using Newtonsoft.Json;
using System.Diagnostics;

namespace MVDeserializer.Data
{
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
}