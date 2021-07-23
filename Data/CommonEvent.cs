using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum Trigger
	{
		None = 0,
		Autorun = 1,
		Parallel = 2
	}

	[DebuggerDisplay("{Name}")]
	public class CommonEvent
	{
		[JsonProperty("id")]
		public CommonEventID ID { get; set; }

		[JsonProperty("list")]
		public IList<EventCommand> Commands { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("switchId")]
		public SwitchID SwitchID { get; set; }

		[JsonProperty("trigger")]
		public Trigger Trigger { get; set; }
	}
}