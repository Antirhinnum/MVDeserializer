using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum ItemTypeId
	{
		Regular,
		Key,
		HiddenA,
		HiddenB
	}

	/// <summary>
	/// A model of the data RPG Maker MV saves for an Item.
	/// </summary>
	[DebuggerDisplay("{Name}")]
	public class Item
	{
		/// <summary>
		/// The internal ID of this Item.
		/// </summary>
		[JsonProperty("id")]
		public int Id { get; set; }

		#region General Settings

		/// <summary>
		/// The name of this Item.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// The index of this Item's icon. Index is from img/system/IconSet.png.
		/// </summary>
		[JsonProperty("iconIndex")]
		public int IconIndex { get; set; }

		/// <summary>
		/// The description of this Item.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// The type of Item this is.
		/// </summary>
		[JsonProperty("itypeId")]
		public ItemTypeId ItemTypeId { get; set; }

		/// <summary>
		/// The default price of this Item.
		/// </summary>
		[JsonProperty("price")]
		public int Price { get; set; }

		/// <summary>
		/// Whether or not this Item is consumable.
		/// </summary>
		[JsonProperty("consumable")]
		public bool Consumable { get; set; }

		/// <summary>
		/// What this Item will affect when used.
		/// </summary>
		[JsonProperty("scope")]
		public Scope Scope { get; set; }

		/// <summary>
		/// When this Item can be used.
		/// </summary>
		[JsonProperty("occasion")]
		public Occasion Occasion { get; set; }

		#endregion General Settings

		#region Invocation

		/// <summary>
		/// How much is added to the user's Agility stat when using this Item.
		/// </summary>
		[JsonProperty("speed")]
		public int Speed { get; set; }

		/// <summary>
		/// The percent change that using this Item succeeds.
		/// </summary>
		[JsonProperty("successRate")]
		public int SuccessRate { get; set; }

		/// <summary>
		/// The number of times this Item's effects are applied to its target.
		/// </summary>
		[JsonProperty("repeats")]
		public int Repeats { get; set; }

		/// <summary>
		/// How much TP the user of this Item gains on use.
		/// </summary>
		[JsonProperty("tpGain")]
		public int TPGain { get; set; }

		/// <summary>
		/// The hit type of this Item.
		/// </summary>
		[JsonProperty("hitType")]
		public HitType HitType { get; set; }

		/// <summary>
		/// The internal ID of the Animation to play when using this Item.
		/// </summary>
		[JsonProperty("animationId")]
		public int AnimationId { get; set; }

		#endregion Invocation

		/// <summary>
		/// The damage this Item deals.
		/// </summary>
		[JsonProperty("damage")]
		public Damage Damage { get; set; }

		/// <summary>
		/// The effects activated when this Item is used.
		/// </summary>
		[JsonProperty("effects")]
		public IList<Effect> Effects { get; set; }

		/// <summary>
		/// This Item's Notes field.
		/// </summary>
		[JsonProperty("note")]
		public string Note { get; set; }
	}
}