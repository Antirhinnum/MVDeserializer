using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum ItemTypeID
	{
		Regular,
		Key,
		HiddenA,
		HiddenB
	}

	[DebuggerDisplay("{Name}")]
	public class Item
	{
		[JsonProperty("id")]
		public ItemID ID { get; set; }

		[JsonProperty("animationId")]
		public AnimationID AnimationID { get; set; }

		[JsonProperty("consumable")]
		public bool Consumable { get; set; }

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

		[JsonProperty("itypeId")]
		public ItemTypeID ItemTypeID { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("occasion")]
		public Occasion Occasion { get; set; }

		[JsonProperty("price")]
		public int Price { get; set; }

		[JsonProperty("repeats")]
		public int Repeats { get; set; }

		[JsonProperty("scope")]
		public Scope Scope { get; set; }

		[JsonProperty("speed")]
		public int Speed { get; set; }

		[JsonProperty("successRate")]
		public int SuccessRate { get; set; }

		[JsonProperty("tpGain")]
		public int TPGain { get; set; }
	}
}