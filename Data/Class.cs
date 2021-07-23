using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	[DebuggerDisplay("[{BaseValue}, {ExtraValue}, {AccelerationA}, {AccelerationB}]")]
	[JsonConverter(typeof(EXPParametersConverter))]
	public struct EXPParameters
	{
		public int BaseValue { get; set; }
		public int ExtraValue { get; set; }
		public int AccelerationA { get; set; }
		public int AccelerationB { get; set; }
	}

	public struct LearntSkill
	{
		[JsonProperty("level")]
		public int Level { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("skillId")]
		public SkillID SkillID { get; set; }
	}

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

	public class EXPParametersConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(EXPParameters);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
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

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}

	public class ParameterCurvesConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(ParameterCurves);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
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

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}

	[DebuggerDisplay("{Name}")]
	public class Class
	{
		[JsonProperty("id")]
		public ClassID ID { get; set; }

		[JsonProperty("expParams")]
		public EXPParameters EXPParameters { get; set; }

		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		[JsonProperty("learnings")]
		public IList<LearntSkill> LearntSkills { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("params")]
		public ParameterCurves ParameterCurves { get; set; }
	}
}