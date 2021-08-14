using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	/// <summary>
	/// The Trigger type of a Common Event.
	/// </summary>
	public enum Trigger
	{
		/// <summary>
		/// This Common Event has no Trigger - it will only run when explicitly called.
		/// </summary>
		None = 0,

		/// <summary>
		/// This Common Event will pause the game and run as long as <see cref="CommonEvent.SwitchId"/> is ON.
		/// </summary>
		Autorun = 1,

		/// <summary>
		/// This Common Event will run as long as <see cref="CommonEvent.SwitchId"/> is ON. The game will not pause.
		/// </summary>
		Parallel = 2
	}

	/// <summary>
	/// A model of the data RPG Maker MV saves for a Common Event.
	/// </summary>
	[DebuggerDisplay("{Name}")]
	public class CommonEvent
	{
		/// <summary>
		/// The internal ID of this Common Event.
		/// </summary>
		[JsonProperty("id")]
		public int Id { get; set; }

		/// <summary>
		/// The name of this CommonEvent.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		#region Trigger

		/// <summary>
		/// The type of Trigger this Common Event has.
		/// </summary>
		[JsonProperty("trigger")]
		public Trigger Trigger { get; set; }

		/// <summary>
		/// The Switch that this Common Event triggers off of.
		/// </summary>
		[JsonProperty("switchId")]
		public int SwitchId { get; set; }

		#endregion Trigger

		/// <summary>
		/// The list of Event Commands this Common Event executes. See <see cref="EventCommand"/>.
		/// </summary>
		[JsonProperty("list")]
		public IList<EventCommand> Commands { get; set; }
	}
}