using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	[DebuggerDisplay("{Name}")]
	public class Skill
	{
		[JsonProperty("id")]
		public SkillID ID { get; set; }

		[JsonProperty("animationId")]
		public AnimationID AnimationID { get; set; }

		[JsonProperty("damage")]
		public Damage Damage { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("effects")]
		public IList<Effect> Effects { get; set; }

		[JsonProperty("hitType")]
		public HitType HitType { get; set; }

		[JsonProperty("iconIndex")]
		public int IconIndex { get; set; }

		[JsonProperty("message1")]
		public string Message1 { get; set; }

		[JsonProperty("message2")]
		public string Message2 { get; set; }

		[JsonProperty("mpCost")]
		public int MPCost { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("occasion")]
		public Occasion Occasion { get; set; }

		[JsonProperty("repeats")]
		public int Repeats { get; set; }

		[JsonProperty("requiredWtypeId1")]
		public WeaponTypeID RequiredWeaponTypeID1 { get; set; }

		[JsonProperty("requiredWtypeId2")]
		public WeaponTypeID RequiredWeaponTypeID2 { get; set; }

		[JsonProperty("scope")]
		public Scope Scope { get; set; }

		[JsonProperty("speed")]
		public int Speed { get; set; }

		[JsonProperty("stypeId")]
		public SkillTypeID SkillTypeID { get; set; }

		[JsonProperty("successRate")]
		public int SuccessRate { get; set; }

		[JsonProperty("tpCost")]
		public int TPCost { get; set; }

		[JsonProperty("tpGain")]
		public int TPGain { get; set; }
	}
}