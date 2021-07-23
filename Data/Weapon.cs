using Newtonsoft.Json;
using System.Collections.Generic;

namespace MVDeserializer.Data
{
	public class Weapon
	{
		[JsonProperty("id")]
		public WeaponID ID { get; set; }

		[JsonProperty("animationId")]
		public AnimationID AnimationID { get; set; }

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

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("params")]
		public StatParameters Parameters { get; set; }

		[JsonProperty("price")]
		public int Price { get; set; }

		[JsonProperty("wtypeId")]
		public WeaponTypeID WeaponTypeID { get; set; }
	}
}