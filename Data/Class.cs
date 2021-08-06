using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	/// <summary>
	/// The parameters used for a Class's EXP curve given names.
	/// </summary>
	[DebuggerDisplay("[{BaseValue}, {ExtraValue}, {AccelerationA}, {AccelerationB}]")]
	[JsonConverter(typeof(EXPParametersConverter))]
	public struct EXPParameters
	{
		public int BaseValue { get; set; }
		public int ExtraValue { get; set; }
		public int AccelerationA { get; set; }
		public int AccelerationB { get; set; }
	}

	/// <summary>
	/// A set of information about a 'learning': A skill a Class learns at a certain level.
	/// </summary>
	public struct Learning
	{
		/// <summary>
		/// The internal ID of the Skill to learn.
		/// </summary>
		[JsonProperty("skillId")]
		public int SkillID { get; set; }

		/// <summary>
		/// The level <see cref="SkillID"/> is learned at.
		/// </summary>
		[JsonProperty("level")]
		public int Level { get; set; }

		/// <summary>
		/// This Learning's Notes field.
		/// </summary>
		[JsonProperty("note")]
		public string Note { get; set; }
	}

	/// <summary>
	/// A set of information about a Class's stats per level.
	/// Each list is indexed by level (MaxHP[1] is Max HP at Level 1).
	/// </summary>
	[JsonConverter(typeof(ParameterCurvesConverter))]
	public struct ParameterCurves
	{
		public IList<int> MaxHP { get; set; }
		public IList<int> MaxMP { get; set; }
		public IList<int> Attack { get; set; }
		public IList<int> Defense { get; set; }
		public IList<int> MagicAttack { get; set; }
		public IList<int> MagicDefense { get; set; }
		public IList<int> Agility { get; set; }
		public IList<int> Luck { get; set; }
	}

	public class EXPParametersConverter : JsonConverter<EXPParameters>
	{
		public override EXPParameters ReadJson(JsonReader reader, Type objectType, EXPParameters existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IList<int> parameters = serializer.Deserialize<IList<int>>(reader);
			return new EXPParameters()
			{
				BaseValue = parameters[0],
				ExtraValue = parameters[1],
				AccelerationA = parameters[2],
				AccelerationB = parameters[3]
			};
		}

		public override void WriteJson(JsonWriter writer, EXPParameters value, JsonSerializer serializer)
		{
			IList<int> toList = new List<int> { value.BaseValue, value.ExtraValue, value.AccelerationA, value.AccelerationB };
			serializer.Serialize(writer, toList);
		}
	}

	public class ParameterCurvesConverter : JsonConverter<ParameterCurves>
	{
		public override ParameterCurves ReadJson(JsonReader reader, Type objectType, ParameterCurves existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IList<IList<int>> curves = serializer.Deserialize<IList<IList<int>>>(reader);
			return new ParameterCurves()
			{
				MaxHP = curves[0],
				MaxMP = curves[1],
				Attack = curves[2],
				Defense = curves[3],
				MagicAttack = curves[4],
				MagicDefense = curves[5],
				Agility = curves[6],
				Luck = curves[7],
			};
		}

		public override void WriteJson(JsonWriter writer, ParameterCurves value, JsonSerializer serializer)
		{
			IList<IList<int>> toList = new List<IList<int>> { value.MaxHP, value.MaxMP, value.Attack, value.Defense, value.MagicAttack, value.MagicDefense, value.Agility, value.Luck };
			serializer.Serialize(writer, toList);
		}
	}

	/// <summary>
	/// A representation of the data RPG Maker MV saves for a Class.
	/// </summary>
	[DebuggerDisplay("{Name}")]
	public class Class
	{
		/// <summary>
		/// The internal ID of this Class.
		/// </summary>
		[JsonProperty("id")]
		public int ID { get; set; }

		/// <summary>
		/// The name of this Class.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		#region Class Data

		/// <summary>
		/// The parameters this Class uses for its EXP Curve.
		/// </summary>
		[JsonProperty("expParams")]
		public EXPParameters EXPParameters { get; set; }

		/// <summary>
		/// The values this Class uses for its stat curves.
		/// </summary>
		[JsonProperty("params")]
		public ParameterCurves ParameterCurves { get; set; }

		/// <summary>
		/// The Skills this Class learns and when it learns them.
		/// </summary>
		[JsonProperty("learnings")]
		public IList<Learning> LearntSkills { get; set; }

		/// <summary>
		/// The set of Traits this Class has intrinsically.
		/// </summary>
		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		#endregion Class Data

		/// <summary>
		/// This Class's Notes field.
		/// </summary>
		[JsonProperty("note")]
		public string Note { get; set; }
	}
}