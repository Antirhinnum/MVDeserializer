using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace MVDeserializer.Data
{
	public enum AnimationPosition
	{
		Head = 0,
		Center = 1,
		Feet = 2,
		Screen = 3
	}

	public enum FlashScope
	{
		None = 0,
		Target = 1,
		Screen = 2,
		HideTarget = 3
	}

	public enum BlendMode
	{
		Normal = 0,
		Add = 1,
		Multiply = 2,
		Screen = 3
	}

	public struct AnimationTiming
	{
		[JsonProperty("flashColor")]
		[JsonConverter(typeof(ColorConverter))]
		public Color FlashColor { get; set; }

		/// <summary>
		/// The duration of the flash. Measured in 1/15ths of a second, or sets of 4 frames.
		/// </summary>
		[JsonProperty("flashDuration")]
		public int FlashDuration { get; set; }

		/// <summary>
		/// What the flash should affect.
		/// </summary>
		[JsonProperty("flashScope")]
		public FlashScope FlashScope { get; set; }

		/// <summary>
		/// What frame the flash starts on.
		/// </summary>
		[JsonProperty("frame")]
		public int Frame { get; set; }

		/// <summary>
		/// The Sound Effect to play when the flash happens.
		/// </summary>
		[JsonProperty("se")]
		public Sound SE { get; set; }
	}

	[JsonConverter(typeof(AnimationCellConverter))]
	public struct AnimationCell
	{
		public int Pattern { get; set; }
		public float X { get; set; }
		public float Y { get; set; }
		public float Scale { get; set; }

		/// <summary>
		/// This cell's rotation, in degrees.
		/// </summary>
		public int Rotation { get; set; }

		/// <summary>
		/// Whether or not the sprite should be horizontally flipped in this cell.
		/// </summary>
		public bool Flip { get; set; }

		public int Opacity { get; set; }
		public BlendMode BlendMode { get; set; }
	}

	public class AnimationCellConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(AnimationCell);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			IList<object> list = serializer.Deserialize<IList<object>>(reader);
			return new AnimationCell()
			{
				Pattern = Convert.ToInt32(list[0]),
				X = Convert.ToSingle(list[1]),
				Y = Convert.ToSingle(list[2]),
				Scale = Convert.ToInt32(list[3]),
				Rotation = Convert.ToInt32(list[4]),
				Flip = Convert.ToBoolean(list[5]),
				Opacity = Convert.ToInt32(list[6]),
				BlendMode = (BlendMode)Convert.ToInt32(list[7])
			};
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}

	[DebuggerDisplay("{Name}")]
	public class Animation
	{
		/// <summary>
		/// The internal ID of this Animation.
		/// </summary>
		[JsonProperty("id")]
		public AnimationID ID { get; set; }

		/// <summary>
		/// The hue of the first image used in this Animation.
		/// </summary>
		[JsonProperty("animation1Hue")]
		public int Animation1Hue { get; set; }

		/// <summary>
		/// The name of the first image used in this Animation.
		/// </summary>
		[JsonProperty("animation1Name")]
		public string Animation1Name { get; set; }

		/// <summary>
		/// The hue of the second image used in this Animation.
		/// </summary>
		[JsonProperty("animation2Hue")]
		public int Animation2Hue { get; set; }

		/// <summary>
		/// The name of the second image used in this Animation.
		/// </summary>
		[JsonProperty("animation2Name")]
		public string Animation2Name { get; set; }

		/// <summary>
		/// The frame-by-frame data of the Animation.
		/// </summary>
		[JsonProperty("frames")]
		public IList<IList<AnimationCell>> Frames { get; set; }

		/// <summary>
		/// The name of this Animation.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// The base position of this Animation.
		/// </summary>
		[JsonProperty("position")]
		public AnimationPosition Position { get; set; }

		/// <summary>
		/// The flash and sound effect data of this Animation.
		/// </summary>
		[JsonProperty("timings")]
		public IList<AnimationTiming> Timings { get; set; }
	}
}