using MVDeserializer.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVDeserializer
{
	public class MVData
	{
		internal static MVData Current { get; set; }

		public RPGSystem System { get; set; }
		public IList<Actor> Actors { get; set; }
		public IList<Animation> Animations { get; set; }
		public IList<Armor> Armors { get; set; }
		public IList<Class> Classes { get; set; }
		public IList<CommonEvent> CommonEvents { get; set; }
		public IList<Enemy> Enemies { get; set; }
		public IList<Item> Items { get; set; }
		public IList<Skill> Skills { get; set; }
		public IList<State> States { get; set; }
		public IList<Troop> Troops { get; set; }
		public IList<Weapon> Weapons { get; set; }
		public IList<MapInfo> MapInfos { get; set; }
		public IList<Tileset> Tilesets { get; set; }
		public IList<Map> Maps { get; set; }

		public static MVData DeserializeFromPath(string projectPath)
		{
			if (!Directory.Exists(projectPath))
			{
				throw new DirectoryNotFoundException("That folder doesn't exist.");
			}

			if (!File.Exists(Path.Combine(projectPath, "Game.rpgproject")))
			{
				throw new FileNotFoundException("The given directory does not contain a Game.rpgproject file.");
			}

			MVData data = new MVData();
			Current = data;

			string dataPath = Path.Combine(projectPath, "data");
			data.System = JsonConvert.DeserializeObject<RPGSystem>(File.ReadAllText(Path.Combine(dataPath, "System.json")));

			data.Actors = JsonConvert.DeserializeObject<IList<Actor>>(File.ReadAllText(Path.Combine(dataPath, "Actors.json")));
			data.Animations = JsonConvert.DeserializeObject<IList<Animation>>(File.ReadAllText(Path.Combine(dataPath, "Animations.json")));
			data.Armors = JsonConvert.DeserializeObject<IList<Armor>>(File.ReadAllText(Path.Combine(dataPath, "Armors.json")));
			data.Classes = JsonConvert.DeserializeObject<IList<Class>>(File.ReadAllText(Path.Combine(dataPath, "Classes.json")));
			data.CommonEvents = JsonConvert.DeserializeObject<IList<CommonEvent>>(File.ReadAllText(Path.Combine(dataPath, "CommonEvents.json")));
			data.Enemies = JsonConvert.DeserializeObject<IList<Enemy>>(File.ReadAllText(Path.Combine(dataPath, "Enemies.json")));
			data.Items = JsonConvert.DeserializeObject<IList<Item>>(File.ReadAllText(Path.Combine(dataPath, "Items.json")));
			data.Skills = JsonConvert.DeserializeObject<IList<Skill>>(File.ReadAllText(Path.Combine(dataPath, "Skills.json")));
			data.States = JsonConvert.DeserializeObject<IList<State>>(File.ReadAllText(Path.Combine(dataPath, "States.json")));
			data.Troops = JsonConvert.DeserializeObject<IList<Troop>>(File.ReadAllText(Path.Combine(dataPath, "Troops.json")));
			data.Weapons = JsonConvert.DeserializeObject<IList<Weapon>>(File.ReadAllText(Path.Combine(dataPath, "Weapons.json")));

			data.MapInfos = JsonConvert.DeserializeObject<IList<MapInfo>>(File.ReadAllText(Path.Combine(dataPath, "MapInfos.json")));
			data.Tilesets = JsonConvert.DeserializeObject<IList<Tileset>>(File.ReadAllText(Path.Combine(dataPath, "Tilesets.json")));

			data.Maps = new Map[data.MapInfos.Count];
			foreach (string filePath in Directory.GetFiles(dataPath))
			{
				string fileName = Path.GetFileName(filePath);
				if (!fileName.StartsWith("Map") || fileName.StartsWith("MapI"))
				{
					continue;
				}

				int mapNumber = int.Parse(fileName.Substring(3, 3));
				data.Maps[mapNumber] = JsonConvert.DeserializeObject<Map>(File.ReadAllText(filePath));
				data.Maps[mapNumber].ID = new MapID(mapNumber);
				data.Maps[mapNumber].Events.ForEach(ev => { if (ev != null) ev.ID.MapID = new MapID(mapNumber); });
			}
			data.Maps = data.Maps.ToList();

			return data;
		}
	}
}