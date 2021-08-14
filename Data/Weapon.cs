using Newtonsoft.Json;
using System.Collections.Generic;

namespace MVDeserializer.Data
{
	public class Weapon
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("iconIndex")]
		public int IconIndex { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("wtypeId")]
		public int WeaponTypeId { get; set; }

		[JsonProperty("price")]
		public int Price { get; set; }

		[JsonProperty("animationId")]
		public int AnimationId { get; set; }

		[JsonProperty("params")]
		public StatParameters Parameters { get; set; }

		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		/// <summary>
		/// Note: Always 1 unless a game does odd things with the weapon system.
		/// </summary>
		[JsonProperty("etypeId")]
		public int EquipmentTypeId { get; set; }
	}
}