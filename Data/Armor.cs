using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	[DebuggerDisplay("{Name}")]
	public class Armor
	{
		/// <summary>
		/// The internal ID of this Armor.
		/// </summary>
		[JsonProperty("id")]
		public ArmorID ID { get; set; }

		/// <summary>
		/// The user-defined type of this Armor. See <see cref="RPGSystem.ArmorTypes"/>.
		/// </summary>
		[JsonProperty("atypeId")]
		public ArmorTypeID ArmorTypeID { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("etypeId")]
		public EquipmentTypeID EquipmentTypeID { get; set; }

		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		[JsonProperty("iconIndex")]
		public int IconIndex { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("params")]
		public StatParameters Parameters { get; set; }

		[JsonProperty("price")]
		public int Price { get; set; }
	}
}