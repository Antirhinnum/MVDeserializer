using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	/// <summary>
	/// A collection of a Actor's equipment.
	/// </summary>
	[JsonConverter(typeof(ActorEquipmentConverter))]
	public struct ActorEquipment
	{
		public IList<IEquipmentID> Equipment { get; set; }
	}

	[DebuggerDisplay("{Name}")]
	public class Actor
	{
		/// <summary>
		/// This Actor's internal ID.
		/// </summary>
		[JsonProperty("id")]
		public ActorID ID { get; set; }

		/// <summary>
		/// The name of this Actor's battle sheet, found in img/sv_actors/.
		/// </summary>
		[JsonProperty("battlerName")]
		public string BattlerImageName { get; set; }

		/// <summary>
		/// The index of this Actor's character in their character spritesheet. See <see cref="CharacterImageName"/>.
		/// </summary>
		[JsonProperty("characterIndex")]
		public int CharacterIndex { get; set; }

		/// <summary>
		/// The name of this Actor's spritesheet, found in img/characters/.
		/// </summary>
		[JsonProperty("characterName")]
		public string CharacterImageName { get; set; }

		/// <summary>
		/// The internal ID of this Actor's Class. See <see cref="Data.Class"/>
		/// </summary>
		[JsonProperty("classId")]
		public ClassID ClassID { get; set; }

		/// <summary>
		/// The equipment this Actor starts with.
		/// </summary>
		[JsonConverter(typeof(ActorEquipmentConverter))]
		[JsonProperty("equips")]
		public IList<IEquipmentID> InitialEquipment { get; set; }

		/// <summary>
		/// The index of this Actor's face in their face atlas. See <see cref="FaceImageName"/>.
		/// </summary>

		[JsonProperty("faceIndex")]
		public int FaceIndex { get; set; }

		/// <summary>
		/// The name of this actor's face atlas, found in img/faces/.
		/// </summary>

		[JsonProperty("faceName")]
		public string FaceImageName { get; set; }

		/// <summary>
		/// The set of Traits this Actor has intrinsically.
		/// </summary>

		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		/// <summary>
		/// The level this Actor starts at.
		/// </summary>

		[JsonProperty("initialLevel")]
		public int InitialLevel { get; set; }

		/// <summary>
		/// The maximum level this Actor can reach.
		/// </summary>

		[JsonProperty("maxLevel")]
		public int MaxLevel { get; set; }

		/// <summary>
		/// This Actor's display name.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// This Actor's nickname.
		/// </summary>
		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		/// <summary>
		/// This Actor's Notes field.
		/// </summary>
		[JsonProperty("note")]
		public string Note { get; set; }

		/// <summary>
		/// The profile description of this Actor.
		/// </summary>
		[JsonProperty("profile")]
		public string Profile { get; set; }
	}

	public class ActorEquipmentConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(IList<IEquipmentID>);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			IList<int> list = serializer.Deserialize<IList<int>>(reader);
			IList<IEquipmentID> equipment = new List<IEquipmentID>();

			if (list.Count == 0)
			{
				return equipment;
			}

			equipment.Add(new WeaponID(list[0]));
			for (int i = 1; i < list.Count; i++)
			{
				equipment.Add(new ArmorID(list[i]));
			}

			return equipment;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}