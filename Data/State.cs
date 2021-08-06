using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum AutoRemovalTiming
	{
		None = 0,
		ActionEnd = 1,
		TurnEnd = 2
	}

	public enum BattlerMotion
	{
		Normal = 0,
		Abnormal = 1,
		Sleep = 2,
		Dead = 3
	}

	public enum OverlayIndex
	{
		None = 0,
		Poison = 1,
		Blind = 2,
		Silence = 3,
		Rage = 4,
		Confusion = 5,
		Fascination = 6,
		Sleep = 7,
		Paralyze = 8,
		Curse = 9,
		Fear = 10
	}

	public enum Restriction
	{
		None = 0,
		AttackEnemy = 1,
		AttackAnyone = 2,
		AttackAlly = 3,
		CannotMove = 4
	}

	[DebuggerDisplay("{Name}")]
	public class State
	{
		[JsonProperty("id")]
		public int ID { get; set; }

		#region General Settings

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("iconIndex")]
		public int IconIndex { get; set; }

		[JsonProperty("restiction")]
		public Restriction Restriction { get; set; }

		[JsonProperty("priority")]
		public int Priority { get; set; }

		[JsonProperty("motion")]
		public BattlerMotion Motion { get; set; }

		[JsonProperty("overlay")]
		public OverlayIndex Overlay { get; set; }

		#endregion General Settings

		#region Removal Conditions

		[JsonProperty("removeAtBattleEnd")]
		public bool RemoveAtBattleEnd { get; set; }

		[JsonProperty("removeByRestriction")]
		public bool RemoveByRestriction { get; set; }

		[JsonProperty("autoRemovalTiming")]
		public AutoRemovalTiming AutoRemovalTiming { get; set; }

		[JsonProperty("minTurns")]
		public int MinTurns { get; set; }

		[JsonProperty("maxTurns")]
		public int MaxTurns { get; set; }

		[JsonProperty("removeByDamage")]
		public bool RemoveByDamage { get; set; }

		[JsonProperty("chanceByDamage")]
		public int ChanceByDamage { get; set; }

		[JsonProperty("removeByWalking")]
		public bool RemoveByWalking { get; set; }

		[JsonProperty("stepsToRemove")]
		public int StepsToRemove { get; set; }

		#endregion Removal Conditions

		#region Messages

		[JsonProperty("message1")]
		public string ActorInflictedMessage { get; set; }

		[JsonProperty("message2")]
		public string EnemyInflictedMessage { get; set; }

		[JsonProperty("message3")]
		public string PersistMessage { get; set; }

		[JsonProperty("message4")]
		public string RemoveMessage { get; set; }

		#endregion Messages

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		[JsonProperty("releaseByDamage")]
		public bool ReleasebyDamage { get; set; }
	}
}