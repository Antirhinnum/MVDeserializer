using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	/// <summary>
	/// A model of the data RPG Maker MV saves for an Armor.
	/// </summary>
	[DebuggerDisplay("{Name}")]
	public class Armor
	{
		/// <summary>
		/// The internal ID of this Armor.
		/// </summary>
		[JsonProperty("id")]
		public int ID { get; set; }

		#region General Settings

		/// <summary>
		/// The name of this Armor.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// The index of this Armor's icon. Index is from img/system/IconSet.png.
		/// </summary>
		[JsonProperty("iconIndex")]
		public int IconIndex { get; set; }

		/// <summary>
		/// The description of this Armor.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// The user-defined type of this Armor.
		/// See <see cref="RPGSystem.ArmorTypes"/>.
		/// </summary>
		[JsonProperty("atypeId")]
		public int ArmorTypeID { get; set; }

		/// <summary>
		/// The default price of this Armor.
		/// </summary>
		[JsonProperty("price")]
		public int Price { get; set; }

		/// <summary>
		/// The user-defined equipment type of this Armor.
		/// See <see cref="RPGSystem.EquipTypes"/>.
		/// </summary>
		[JsonProperty("etypeId")]
		public EquipmentTypeID EquipmentTypeID { get; set; }

		#endregion General Settings

		/// <summary>
		/// The stat boosts this Armor gives when equipped.
		/// </summary>
		[JsonProperty("params")]
		public StatParameters ParameterChanges { get; set; }

		/// <summary>
		/// The set of Traits this Armor has.
		/// </summary>
		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		/// <summary>
		/// This Armor's Notes field.
		/// </summary>
		[JsonProperty("note")]
		public string Note { get; set; }
	}
}