using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	/// <summary>
	/// A model of the data RPG Maker MV saves for an Actor.
	/// </summary>
	[DebuggerDisplay("{Name}")]
	public class Actor
	{
		/// <summary>
		/// This Actor's internal ID.
		/// </summary>
		[JsonProperty("id")]
		public int Id { get; set; }

		#region General Settings

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
		/// The internal ID of this Actor's Class.
		/// See <see cref="Class"/>.
		/// </summary>
		[JsonProperty("classId")]
		public int ClassId { get; set; }

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
		/// The profile description of this Actor.
		/// </summary>
		[JsonProperty("profile")]
		public string Profile { get; set; }

		#endregion General Settings

		#region Images

		/// <summary>
		/// The name of this actor's face atlas, found in img/faces/.
		/// </summary>
		[JsonProperty("faceName")]
		public string FaceName { get; set; }

		/// <summary>
		/// The index of this Actor's face in their face atlas.
		/// See <see cref="FaceName"/>.
		/// </summary>
		[JsonProperty("faceIndex")]
		public int FaceIndex { get; set; }

		/// <summary>
		/// The name of this Actor's spritesheet, found in img/characters/.
		/// </summary>
		[JsonProperty("characterName")]
		public string CharacterName { get; set; }

		/// <summary>
		/// The index of this Actor's character in their character spritesheet.
		/// See <see cref="CharacterName"/>.
		/// </summary>
		[JsonProperty("characterIndex")]
		public int CharacterIndex { get; set; }

		/// <summary>
		/// The name of this Actor's battle sheet, found in img/sv_actors/.
		/// </summary>
		[JsonProperty("battlerName")]
		public string BattlerName { get; set; }

		#endregion Images

		/// <summary>
		/// The equipment this Actor starts with.
		/// Can be a <see cref="Weapon"/> or an <see cref="Armor"/>.
		/// <para>Represented as an ID number. The first item will always be a Weapon ID if
		/// <see cref="RPGSystem.EquipTypes"/> has at least one value, with all other values
		/// being Armor IDs. If <see cref="Traits"/> has a Trait with code
		/// <see cref="TraitCode.SlotType"/>, then the second value will also be a Weapon ID.</para>
		/// </summary>
		[JsonProperty("equips")]
		public IList<int> InitialEquipment { get; set; }

		/// <summary>
		/// The set of Traits this Actor has intrinsically.
		/// </summary>
		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		/// <summary>
		/// This Actor's Notes field.
		/// </summary>
		[JsonProperty("note")]
		public string Note { get; set; }
	}
}