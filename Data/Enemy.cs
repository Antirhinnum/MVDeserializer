using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVDeserializer.Data
{
	public enum ConditionType
	{
		Always = 0,

		/// <summary>
		/// This action is available starting on turn <see cref="EnemyAction.ConditionParam1"/> and every <see cref="EnemyAction.ConditionParam2"/> turns after.
		/// </summary>
		Turn = 1,

		/// <summary>
		/// This action is available if HP is between <see cref="EnemyAction.ConditionParam1"/>% and <see cref="EnemyAction.ConditionParam2"/>% of Max HP.
		/// </summary>
		HP = 2,

		/// <summary>
		/// This action is available if MP is between <see cref="EnemyAction.ConditionParam1"/>% and <see cref="EnemyAction.ConditionParam2"/>% of Max MP.
		/// </summary>
		MP = 3,

		/// <summary>
		/// This action is available if this Enemy has State ID <see cref="EnemyAction.ConditionParam1"/>.
		/// </summary>
		State = 4,

		/// <summary>
		/// This action is available if the party's level is <see cref="EnemyAction.ConditionParam1"/> or above.
		/// </summary>
		PartyLevel = 5,

		/// <summary>
		/// This action is available if Switch ID <see cref="EnemyAction.ConditionParam1"/> is ON.
		/// </summary>
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
		/// <summary>
		/// The Skill to perform if conditions are met.
		/// </summary>
		[JsonProperty("skillId")]
		public int SkillID { get; set; }

		[JsonProperty("rating")]
		public int Rating { get; set; }

		/// <summary>
		/// The type of condition this action checks for. See <see cref="Data.ConditionType"/> for how parameters are used.
		/// </summary>
		[JsonProperty("conditionType")]
		public ConditionType ConditionType { get; set; }

		[JsonProperty("conditionParam1")]
		public int ConditionParam1 { get; set; }

		[JsonProperty("conditionParam2")]
		public int ConditionParam2 { get; set; }
	}

	public struct DroppedItem
	{
		[JsonProperty("kind")]
		public ItemDropKind Kind { get; set; }

		/// <summary>
		/// The internal ID of the dropped item. Can be an Item, Weapon, or Armor.
		/// </summary>
		[JsonProperty("dataId")]
		public int DataID { get; set; }

		/// <summary>
		/// The denominator of the drop chance. Drop chance is 1/Denominator.
		/// </summary>
		[JsonProperty("denominator")]
		public int Denominator { get; set; }

		public override string ToString()
		{
			return Kind == ItemDropKind.None ? "None" : $"{DataID}, 1 / {Denominator} chance";
		}
	}

	/// <summary>
	/// A model of the data RPG Maker MV saves for an Enemy.
	/// </summary>
	[DebuggerDisplay("{Name}")]
	public class Enemy
	{
		/// <summary>
		/// The internal ID of this Enemy.
		/// </summary>
		[JsonProperty("id")]
		public int ID { get; set; }

		#region General Settings

		/// <summary>
		/// The name of this Enemy.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// The name of thie Enemy's image, found in img/enemies/.
		/// </summary>
		[JsonProperty("battlerName")]
		public string BattlerName { get; set; }

		/// <summary>
		/// The color this Enemy's image is drawn in
		/// </summary>
		[JsonProperty("battlerHue")]
		public int BattlerHue { get; set; }

		/// <summary>
		/// This Enemy's stats.
		/// </summary>
		[JsonProperty("params")]
		public StatParameters Parameters { get; set; }

		#endregion General Settings

		#region Rewards

		/// <summary>
		/// The amount of EXP this Enemy drops on death.
		/// </summary>
		[JsonProperty("exp")]
		public int EXP { get; set; }

		/// <summary>
		/// The amount of gold this Enemy drops on death.
		/// </summary>
		[JsonProperty("gold")]
		public int Gold { get; set; }

		#endregion Rewards

		/// <summary>
		/// A list of the item drops this Enemy has.
		/// </summary>
		[JsonProperty("dropItems")]
		public IList<DroppedItem> DroppedItems { get; set; }

		/// <summary>
		/// A list of the actions this Enemy can take.
		/// </summary>
		[JsonProperty("actions")]
		public IList<EnemyAction> ActionPatterns { get; set; }

		/// <summary>
		/// The Traits this Enemy has.
		/// </summary>
		[JsonProperty("traits")]
		public IList<Trait> Traits { get; set; }

		/// <summary>
		/// This Enemy's Notes field.
		/// </summary>
		[JsonProperty("note")]
		public string Note { get; set; }
	}
}