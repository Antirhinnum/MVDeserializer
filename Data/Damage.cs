using Newtonsoft.Json;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum DamageType
	{
		None,
		HPDamage,
		MPDamage,
		HPRecover,
		MPRecover,
		HPDrain,
		MPDrain
	}

	/// <summary>
	/// A set of data used to determine Item and Skill damage.
	/// </summary>
	[DebuggerDisplay("{DamageFormula}")]
	public struct Damage
	{
		/// <summary>
		/// The type of damage dealt.
		/// </summary>
		[JsonProperty("type")]
		public DamageType Type { get; set; }

		/// <summary>
		/// The element this damage is. See <see cref="RPGSystem.Elements"/>.
		/// </summary>
		[JsonProperty("elementId")]
		public int ElementID { get; set; }

		/// <summary>
		/// The formula used for calculating damage.
		/// </summary>
		[JsonProperty("formula")]
		public string DamageFormula { get; set; }

		/// <summary>
		/// The percent variance in damage dealt.
		/// </summary>
		[JsonProperty("variance")]
		public int Variance { get; set; }

		/// <summary>
		/// Whether or not this damage can be a critical hit.
		/// </summary>
		[JsonProperty("critical")]
		public bool CanBeCritical { get; set; }
	}
}