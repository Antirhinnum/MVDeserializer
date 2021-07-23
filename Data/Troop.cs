using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	[DebuggerDisplay("{EnemyID}")]
	public struct TroopMember
	{
		[JsonProperty("enemyId")]
		public EnemyID EnemyID { get; set; }

		[JsonProperty("x")]
		public int X { get; set; }

		[JsonProperty("y")]
		public int Y { get; set; }

		[JsonProperty("hidden")]
		public bool Hidden { get; set; }
	}

	public struct TroopPage
	{
		[JsonProperty("conditions")]
		public TroopConditions Conditions { get; set; }

		[JsonProperty("list")]
		public IList<EventCommand> Commands { get; set; }

		[JsonProperty("span")]
		public TroopPageSpan Span { get; set; }

		public enum TroopPageSpan
		{
			Battle = 0,
			Turn = 1,
			Moment = 2
		}

		public struct TroopConditions
		{
			[JsonProperty("actorHp")]
			public int ActorHP { get; set; }

			[JsonProperty("actorId")]
			public ActorID ActorID { get; set; }

			[JsonProperty("actorValid")]
			public bool ActorValid { get; set; }

			[JsonProperty("enemyHp")]
			public int EnemyHP { get; set; }

			[JsonProperty("enemyIndex")]
			public int EnemyIndex { get; set; }

			[JsonProperty("switchId")]
			public SwitchID SwitchID { get; set; }

			[JsonProperty("switchValid")]
			public bool SwitchValid { get; set; }

			[JsonProperty("turnA")]
			public int StartTurn { get; set; }

			[JsonProperty("turnB")]
			public int TurnPeriod { get; set; }

			[JsonProperty("turnEnding")]
			public bool TurnEnding { get; set; }

			[JsonProperty("turnValid")]
			public bool TurnValid { get; set; }
		}
	}

	[DebuggerDisplay("{Name}")]
	public class Troop
	{
		[JsonProperty("id")]
		public TroopID ID { get; set; }

		[JsonProperty("members")]
		public IList<TroopMember> Members { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("pages")]
		public IList<TroopPage> Pages { get; set; }
	}
}