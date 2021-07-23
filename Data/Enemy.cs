using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum ConditionType
	{
		Always = 0,
		Turn = 1,
		HP = 2,
		MP = 3,
		State = 4,
		ParryLevel = 5,
		Switch = 6
	}

	public enum ItemDropKind
	{
		None = 0,
		Item = 1,
		Weapon = 2,
		Armor = 3
	}

	public struct EnemyAction
	{
		[JsonProperty("conditionParam1")]
		public int ConditionParam1 { get; set; }

		[JsonProperty("conditionParam2")]
		public int ConditionParam2 { get; set; }

		[JsonProperty("conditionType")]
		public ConditionType ConditionType { get; set; }
	}

	[DebuggerDisplay("{GetDisplay()}")]
	[JsonConverter(typeof(DroppedItemConverter))]
	public struct DroppedItem
	{
		[JsonProperty("kind")]
		public ItemDropKind Kind { get; set; }

		[JsonProperty("dataId")]
		public ICanBeDroppedByEnemies DataID { get; set; }

		[JsonProperty("denominator")]
		public int Denominator { get; set; }

		public string GetDisplay()
		{
			return Kind == ItemDropKind.None ? "None" : $"{DataID}, 1 / {Denominator} chance";
		}
	}

	public class DroppedItemConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(DroppedItem);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject data = serializer.Deserialize<JObject>(reader);

			DroppedItem item = new DroppedItem()
			{
				Kind = (ItemDropKind)data["kind"].Value<int>(),
				Denominator = (int)data["denominator"].Value<int>()
			};

			int dataID = (int)data["dataId"].Value<int>();
			item.DataID = item.Kind switch
			{
				ItemDropKind.Armor => new ArmorID(dataID),
				ItemDropKind.Item => new ItemID(dataID),
				ItemDropKind.Weapon => new WeaponID(dataID),
				_ => new ArmorID(0)
			};

			return item;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}

	[DebuggerDisplay("{BattlerName}")]
	public class Enemy
	{
		[JsonProperty("id")]
		public EnemyID ID { get; set; }

		[JsonProperty("actions")]
		public IList<EnemyAction> Actions { get; set; }

		[JsonProperty("battlerHue")]
		public int BattlerHue { get; set; }

		[JsonProperty("battlerName")]
		public string BattlerName { get; set; }

		[JsonProperty("dropItems")]
		public IList<DroppedItem> DroppedItems { get; set; }

		[JsonProperty("exp")]
		public int EXP { get; set; }

		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		[JsonProperty("gold")]
		public int Gold { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("params")]
		public StatParameters Parameters { get; set; }
	}
}