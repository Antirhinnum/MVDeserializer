//namespace MVDeserializer.Data
//{
//	public class GameAction
//	{
//		public int SubjectActorID { get; set; }
//		public int SubjectActorIndex { get; set; }
//		public int SubjectEnemyIndex { get; set; }
//		public bool Forcing { get; set; }

//		public GameItem Item { get; set; }
//		public int TargetIndex { get; set; }

//		public GameAction(object subject, bool forcing = false)
//		{
//			SubjectActorID = 0;
//			SubjectActorIndex = -1;
//			Forcing = forcing;
//			//SetSubject(subject);
//			Clear();
//		}

//		// TODO - Finish

//		public void Clear()
//		{
//			Item = new GameItem();
//			TargetIndex = -1;
//		}

//		public enum Effect
//		{
//			RecoverHP = 11,
//			RecoverMP = 12,
//			GainTP = 13,
//			AddState = 21,
//			RemoveState = 22,
//			AddBuff = 31,
//			AddDebuff = 32,
//			RemoveBuff = 33,
//			RemoveDebuff = 34,
//			Special = 41,
//			Grow = 42,
//			LearnSkill = 43,
//			CommonEvent = 44
//		}

//		public enum SpecialEffect
//		{
//			Escape = 0
//		}

//		public enum HitType
//		{
//			Certain = 0,
//			Physical = 1,
//			Magical = 2
//		}
//	}
//}