using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Reflection;

namespace MVDeserializer.Data
{
	public interface IEquipmentID
	{
	}

	[DebuggerDisplay("ID = {ID}, Name = {ToString()}")]
	[JsonConverter(typeof(IDConverter))]
	public class IDClass
	{
		public int ID { get; set; }

		public IDClass(int id) => ID = id;

		public IDClass(IDClass other) => ID = other.ID;
	}

	public class IDConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType.IsSubclassOf(typeof(IDClass));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int id = serializer.Deserialize<int>(reader);
			ConstructorInfo constructor = objectType.GetConstructor(new Type[] { typeof(int) });
			return constructor.Invoke(new object[] { id });
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
	}

	public class ActorID : IDClass
	{
		public ActorID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Actors[ID].Name;
	}

	public class AnimationID : IDClass
	{
		public AnimationID(int id) : base(id)
		{
		}

		public override string ToString()
		{
			if (ID == -1) return "Normal Attack";
			if (ID == 0) return "None";
			return MVData.Current.Animations[ID].Name;
		}
	}

	public class ArmorID : IDClass, IEquipmentID, ICanBeDroppedByEnemies
	{
		public ArmorID(int id) : base(id)
		{
		}

		public override string ToString()
		{
			return ID == 0 ? "None" : MVData.Current.Armors[ID].Name;
		}
	}

	public class ArmorTypeID : IDClass
	{
		public ArmorTypeID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.System.ArmorTypes[ID];
	}

	public class ClassID : IDClass
	{
		public ClassID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Classes[ID].Name;
	}

	public class CommonEventID : IDClass
	{
		public CommonEventID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.CommonEvents[ID].Name;
	}

	public class ElementID : IDClass
	{
		public ElementID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.System.Elements[ID];
	}

	public class EnemyID : IDClass
	{
		public EnemyID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Enemies[ID].Name;
	}

	public class EventID : IDClass
	{
		public MapID MapID { get; set; }

		public EventID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Maps[MapID.ID].Events[ID].Name;
	}

	public class EquipmentTypeID : IDClass
	{
		public EquipmentTypeID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.System.EquipTypes[ID];
	}

	public class ItemID : IDClass, ICanBeDroppedByEnemies
	{
		public ItemID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Items[ID].Name;
	}

	public class MapID : IDClass, ICanBeDroppedByEnemies
	{
		public MapID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.MapInfos[ID].Name;
	}

	public class SkillID : IDClass
	{
		public SkillID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Skills[ID].Name;
	}

	public class SkillTypeID : IDClass
	{
		public SkillTypeID(int id) : base(id)
		{
		}

		public override string ToString()
		{
			return ID == 0 ? "None" : MVData.Current.System.SkillTypes[ID];
		}
	}

	public class StateID : IDClass
	{
		public StateID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.States[ID].Name;
	}

	public class SwitchID : IDClass
	{
		public SwitchID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.System.Switches[ID];
	}

	public class TilesetID : IDClass
	{
		public TilesetID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Tilesets[ID].Name;
	}

	public class TroopID : IDClass
	{
		public TroopID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.Troops[ID].Name;
	}

	public class VariableID : IDClass
	{
		public VariableID(int id) : base(id)
		{
		}

		public override string ToString() => MVData.Current.System.Variables[ID];
	}

	public class WeaponID : IDClass, IEquipmentID, ICanBeDroppedByEnemies
	{
		public WeaponID(int id) : base(id)
		{
		}

		public override string ToString()
		{
			return MVData.Current.Weapons[ID].Name;
		}
	}

	public class WeaponTypeID : IDClass
	{
		public WeaponTypeID(int id) : base(id)
		{
		}

		public override string ToString()
		{
			return ID == 0 ? "None / Bare Hands" : MVData.Current.System.WeaponTypes[ID];
		}
	}
}