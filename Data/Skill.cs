using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	[DebuggerDisplay("{Name}")]
	public class Skill
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		#region General Settings

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("iconIndex")]
		public int IconIndex { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// See <see cref="RPGSystem.SkillTypes"/>.
		/// </summary>
		[JsonProperty("stypeId")]
		public int SkillTypeId { get; set; }

		[JsonProperty("mpCost")]
		public int MPCost { get; set; }

		[JsonProperty("tpCost")]
		public int TPCost { get; set; }

		[JsonProperty("scope")]
		public Scope Scope { get; set; }

		[JsonProperty("occasion")]
		public Occasion Occasion { get; set; }

		#endregion General Settings

		#region Invocation

		[JsonProperty("speed")]
		public int Speed { get; set; }

		[JsonProperty("successRate")]
		public int SuccessRate { get; set; }

		[JsonProperty("repeats")]
		public int Repeats { get; set; }

		[JsonProperty("tpGain")]
		public int TPGain { get; set; }

		[JsonProperty("hitType")]
		public HitType HitType { get; set; }

		[JsonProperty("animationId")]
		public int AnimationId { get; set; }

		#endregion Invocation

		#region Message

		[JsonProperty("message1")]
		public string Message1 { get; set; }

		[JsonProperty("message2")]
		public string Message2 { get; set; }

		#endregion Message

		#region Required Weapon

		[JsonProperty("requiredWtypeId1")]
		public int RequiredWeaponTypeId1 { get; set; }

		[JsonProperty("requiredWtypeId2")]
		public int RequiredWeaponTypeId2 { get; set; }

		#endregion Required Weapon

		[JsonProperty("damage")]
		public Damage Damage { get; set; }

		[JsonProperty("effects")]
		public IList<Effect> Effects { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }
	}
}