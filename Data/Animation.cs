using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace MVDeserializer.Data
{
	/// <summary>
	/// The position an Animation plays at.
	/// </summary>
	public enum AnimationPosition
	{
		Head = 0,
		Center = 1,
		Feet = 2,
		Screen = 3
	}

	/// <summary>
	/// The Blend Mode used when drawing an Animation.
	/// </summary>
	public enum BlendMode
	{
		Normal = 0,
		Add = 1,
		Multiply = 2,
		Screen = 3
	}

	/// <summary>
	/// The scope of what should be affected by a flash.
	/// </summary>
	public enum FlashScope
	{
		None = 0,
		Target = 1,
		Screen = 2,
		HideTarget = 3
	}

	/// <summary>
	/// A set of information about an animation frame's flashes and sound effects.
	/// </summary>
	public struct AnimationTiming
	{
		/// <summary>
		/// The color of the flash.
		/// </summary>
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

	/// <summary>
	/// A set of information about this specific animation frame.
	/// </summary>
	[JsonConverter(typeof(AnimationCellConverter))]
	public struct AnimationCell
	{
		/// <summary>
		/// The index of this cell's pattern. If Pattern < 100, the first image is used.
		/// </summary>
		public int Pattern { get; set; }

		/// <summary>
		/// The horizontal position of this cell.
		/// </summary>
		public float X { get; set; }

		/// <summary>
		/// The vertical position of this cell.
		/// </summary>
		public float Y { get; set; }

		/// <summary>
		/// The scale at which this cell is drawn. 100 means 100% scale, negative values flip.
		/// </summary>
		public float Scale { get; set; }

		/// <summary>
		/// This cell's rotation in degrees.
		/// </summary>
		public int Rotation { get; set; }

		/// <summary>
		/// Whether or not the sprite should be horizontally flipped in this cell.
		/// </summary>
		public bool Flip { get; set; }

		/// <summary>
		/// This cell's opacity. 255 is fully opaque, 0 is fully transparent.
		/// </summary>
		public int Opacity { get; set; }

		/// <summary>
		/// The method this cell should be drawn on the screen using.
		/// </summary>
		public BlendMode BlendMode { get; set; }
	}

	public class AnimationCellConverter : JsonConverter<AnimationCell>
	{
		public override AnimationCell ReadJson(JsonReader reader, Type objectType, AnimationCell existingValue, bool hasExistingValue, JsonSerializer serializer)
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

		public override void WriteJson(JsonWriter writer, AnimationCell value, JsonSerializer serializer)
		{
			IList<float> toList = new List<float> { value.Pattern, value.X, value.Y, value.Scale, value.Rotation, value.Flip ? 0f : 1f, value.Opacity, (int)value.BlendMode };
			serializer.Serialize(writer, toList);
		}
	}

	/// <summary>
	/// A model of the data RPG Maker MV stores for an Animation.
	/// </summary>
	[DebuggerDisplay("{Name}")]
	public class Animation
	{
		/// <summary>
		/// The internal ID of this Animation.
		/// </summary>
		[JsonProperty("id")]
		public int ID { get; set; }

		/// <summary>
		/// The name of this Animation.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// The name of the first image used in this Animation.
		/// </summary>
		[JsonProperty("animation1Name")]
		public string Animation1Name { get; set; }

		/// <summary>
		/// The hue of the first image used in this Animation.
		/// </summary>
		[JsonProperty("animation1Hue")]
		public int Animation1Hue { get; set; }

		/// <summary>
		/// The name of the second image used in this Animation.
		/// </summary>
		[JsonProperty("animation2Name")]
		public string Animation2Name { get; set; }

		/// <summary>
		/// The hue of the second image used in this Animation.
		/// </summary>
		[JsonProperty("animation2Hue")]
		public int Animation2Hue { get; set; }

		/// <summary>
		/// The base position of this Animation.
		/// </summary>
		[JsonProperty("position")]
		public AnimationPosition Position { get; set; }

		/// <summary>
		/// The maximum number of frames this Animation has.
		/// </summary>
		public int MaxFrames => Frames.Count;

		/// <summary>
		/// The flash and sound effect data of this Animation.
		/// </summary>
		[JsonProperty("timings")]
		public IList<AnimationTiming> Timings { get; set; }

		/// <summary>
		/// The frame-by-frame data of the Animation.
		/// </summary>
		[JsonProperty("frames")]
		public IList<IList<AnimationCell>> Frames { get; set; }
	}
}