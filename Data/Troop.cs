using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	[DebuggerDisplay("{EnemyId}")]
	public struct TroopMember
	{
		[JsonProperty("enemyId")]
		public int EnemyId { get; set; }

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

		[JsonProperty("span")]
		public TroopPageSpan Span { get; set; }

		[JsonProperty("list")]
		public IList<EventCommand> Commands { get; set; }

		public enum TroopPageSpan
		{
			Battle = 0,
			Turn = 1,
			Moment = 2
		}

		public struct TroopConditions
		{
			[JsonProperty("turnEnding")]
			public bool TurnEnding { get; set; }

			[JsonProperty("turnValid")]
			public bool TurnValid { get; set; }

			[JsonProperty("turnA")]
			public int StartTurn { get; set; }

			[JsonProperty("turnB")]
			public int TurnPeriod { get; set; }

			[JsonProperty("enemyValid")]
			public bool EnemyValid { get; set; }

			[JsonProperty("enemyIndex")]
			public int EnemyIndex { get; set; }

			[JsonProperty("enemyHp")]
			public int EnemyHP { get; set; }

			[JsonProperty("actorValid")]
			public bool ActorValid { get; set; }

			[JsonProperty("actorId")]
			public int ActorId { get; set; }

			[JsonProperty("actorHp")]
			public int ActorHP { get; set; }

			[JsonProperty("switchValid")]
			public bool SwitchValid { get; set; }

			[JsonProperty("switchId")]
			public int SwitchId { get; set; }
		}
	}

	[DebuggerDisplay("{Name}")]
	public class Troop
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("members")]
		public IList<TroopMember> Members { get; set; }

		[JsonProperty("pages")]
		public IList<TroopPage> Pages { get; set; }
	}
}