//namespace MVDeserializer.Data
//{
//	public enum DataClass
//	{
//		Item,
//		Weapon,
//		Armor,
//		Skill,
//		Null
//	}

//	/// <summary>
//	/// A recreation of RPG Maker MV's Game_Item class.
//	/// Serves as the base for Items, Weapons, Armors, and Skills.
//	/// </summary>
//	public class GameItem
//	{
//		public DataClass DataClass { get; set; }
//		public int ItemID { get; set; }

//		public bool IsItem => DataClass == DataClass.Item;
//		public bool IsWeapon => DataClass == DataClass.Weapon;
//		public bool IsArmor => DataClass == DataClass.Armor;
//		public bool IsSkill => DataClass == DataClass.Skill;
//		public bool IsNull => DataClass == DataClass.Null;

//		public bool IsUsableItem => IsItem || IsSkill;
//		public bool IsEquipItem => IsWeapon || IsArmor;

//		public GameItem(GameItem item = null)
//		{
//			DataClass = DataClass.Null;
//			ItemID = 0;
//			if (item != null)
//			{
//				SetObject(item);
//			}
//		}

//		public void SetEquip(bool isWeapon, int itemID)
//		{
//			DataClass = isWeapon ? DataClass.Weapon : DataClass.Armor;
//			ItemID = itemID;
//		}

//		public void SetObject(GameItem item)
//		{
//			// TODO - Come back and finish this
//		}
//	}
//}