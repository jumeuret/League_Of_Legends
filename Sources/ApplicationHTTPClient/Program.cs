using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using API_lol.Mapper;
using DTO;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Newtonsoft.Json;
using StubLib;
using static System.Console;

namespace ConsoleTests
{
	static class Program
	{
		static private readonly  HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
		{
			try
			{
				await DisplayMainMenu();

				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex, "Stopped program because of exception");
				throw;
			}
		}

		public static async Task DisplayMainMenu()
		{
			Dictionary<int, string> choices = new Dictionary<int, string>()
			{
				[1] = "1- Manage Champions",
				[2] = "2- Manage Skins",
				[3] = "3- Manage Runes",
				[4] = "4- Manage Rune Pages",
				[99] = "99- Quit"
			};

			while(true)
			{ 
				int input = DisplayAMenu(choices);

				switch(input)
				{
					case 1:
						await DisplayChampionsMenu();
						break;
					case 2:
						break;
					case 3:
						break;
					case 4:
						break;
					case 99:
						WriteLine("Bye bye!");
						return;
					default:
						break;
				}
			}
		}

		private static int DisplayAMenu(Dictionary<int, string> choices)
		{
			int input=-1;
			while(true)
			{
				WriteLine("What is your choice?");
				WriteLine("--------------------");
				foreach(var choice in choices.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value))
				{
					WriteLine(choice);
				}
				if(!int.TryParse(ReadLine(), out input) || input == -1)
				{
					WriteLine("I do not understand what your choice is. Please try again.");
					continue;
				}
				break;
			}
			WriteLine($"You have chosen: {choices[input]}");
			WriteLine();
			return input;
		}

		public static async Task DisplayChampionsMenu()
		{
			Dictionary<int, string> choices = new Dictionary<int, string>()
			{
				[0] = "0- Get number of champions",
				[1] = "1- Get champions",
				[2] = "2- Find champions by id",
				[3] = "6- Add new champion",
				[4] = "7- Delete a champion",
				[5] = "8- Update a champion",
			};

			int input = DisplayAMenu(choices);

			switch(input)
			{
				case 0:
					HttpResponseMessage nb = await httpClient.GetAsync("https://localhost:7209/Champion/count");
					nb.EnsureSuccessStatusCode();
					WriteLine($"There are {nb} champions");
					WriteLine("**********************");
					break;
				case 1:
					{ 
						int index = ReadAnInt("Please enter the page index");
						int count = ReadAnInt("Please enter the number of elements to display");
						WriteLine($"{count} champions of page {index+1}");
						HttpResponseMessage champions = await httpClient.GetAsync("https://localhost:7209/Champion");
						champions.EnsureSuccessStatusCode();
						var championsResponse = JsonConvert.DeserializeObject<IEnumerable<ChampionDTO>>( await champions.Content.ReadAsStringAsync());
						foreach(var champion in championsResponse)
						{
							WriteLine($"\t{champion.FromDTO()}");
						}
						WriteLine("**********************");
					}
					break;
				case 2:
					{
						string substring = ReadAString("Please enter the int to look for in the id of a champion");
						int index = ReadAnInt("Please enter the page index");
						int count = ReadAnInt("Please enter the number of elements to display");
						HttpResponseMessage champions = await httpClient.GetAsync($"https://localhost:7209/Champion/{nameof(Champion.Id)}");
						champions.EnsureSuccessStatusCode();
						var championsResponse = JsonConvert.DeserializeObject<IEnumerable<ChampionDTO>>( await champions.Content.ReadAsStringAsync());
						foreach(var champion in championsResponse)
						{
							WriteLine($"\t{champion.FromDTO()}");
						}
						WriteLine("**********************");
					}
					break;
				case 3:
					{
						WriteLine("You are going to create a new champion.");
						int id = ReadAnInt("Please enter the champion id:");
						string name = ReadAString("Please enter the champion name:");
						ChampionClass championClass = ReadAnEnum<ChampionClass>($"Please enter the champion class (possible values are: {Enum.GetNames<ChampionClass>().Aggregate("", (name, chaine) => $"{chaine} {name}")}):");
						string bio = ReadAString("Please enter the champion bio:");
						Champion champion = new Champion(id: id, name, championClass, bio: bio);
						DisplayCreationChampionMenu(champion);
						var championJson = JsonConvert.SerializeObject(champion.ToDTO());
						var championData = new StringContent(championJson, Encoding.UTF8, "application/json");
						var response = await httpClient.PostAsync($"https://localhost:7209/Champion/", championData);
						response.EnsureSuccessStatusCode();
					}	
					break;
				case 4:
					{
						WriteLine("You are going to delete a champion.");
						string name = ReadAString("Please enter the champion id:");
						HttpResponseMessage champions = await httpClient.GetAsync($"https://localhost:7209/Champion/{nameof(Champion.Id)}");
						champions.EnsureSuccessStatusCode();
						var someChampions = JsonConvert.DeserializeObject<IEnumerable<ChampionDTO>>( await champions.Content.ReadAsStringAsync());
						var someChampionNames = someChampions.Select(c => c!.Id.ToString());
						var someChampionNamesAsOneString = someChampionNames.Aggregate("", (id, chaine) => $"{chaine} {id}");
						string champName = ReadAStringAmongPossibleValues($"Who do you want to delete among these champions? (type \"Cancel\" to ... cancel) {someChampionNamesAsOneString}", someChampionNames.ToArray());
						if(champName != "Cancel")
						{
							await httpClient.DeleteAsync($"https://localhost:7209/Champion/{nameof(Champion.Id)}");
						}
					}	
					break;
				case 5:
					{
						WriteLine("You are going to update a champion.");
						string name = ReadAString("Please enter the champion name:");
						HttpResponseMessage champions = await httpClient.GetAsync($"https://localhost:7209/Champion/{nameof(Champion.Id)}");
						champions.EnsureSuccessStatusCode();
						var someChampions = JsonConvert.DeserializeObject<IEnumerable<ChampionDTO>>( await champions.Content.ReadAsStringAsync());
						var someChampionNames = someChampions.Select(c => c!.Id.ToString());
						var someChampionNamesAsOneString = someChampionNames.Aggregate("", (id, chaine) => $"{chaine} {id}");
						string champName = ReadAStringAmongPossibleValues($"Who do you want to update among these champions? (type \"Cancel\" to ... cancel) {someChampionNamesAsOneString}", someChampionNames.ToArray());
						if(champName == "Cancel") break;
						ChampionClass championClass = ReadAnEnum<ChampionClass>($"Please enter the champion class (possible values are: {Enum.GetNames<ChampionClass>().Aggregate("", (name, chaine) => $"{chaine} {name}")}):");
						int id = ReadAnInt("Please enter the champion id:");
						string bio = ReadAString("Please enter the champion bio:");
						Champion champion = new Champion(id: id, champName, championClass, bio: bio);
						DisplayCreationChampionMenu(champion);
						var championJson = JsonConvert.SerializeObject(champion.ToDTO());
						var championData = new StringContent(championJson, Encoding.UTF8, "application/json");
						HttpResponseMessage championsResponse = await httpClient.PutAsync($"https://localhost:7209/Champion/", championData);
						champions.EnsureSuccessStatusCode();
					}	
					break;
				default:
					break;
			}

		}

		public static void DisplayCreationChampionMenu(Champion champion)
		{
			Dictionary<int, string> choices = new Dictionary<int, string>()
			{
				[1] = "1- Add a skill",
				[2] = "2- Add a skin",
				[3] = "3- Add a characteristic",
				[99] = "99- Finish"
			};

			while(true)
			{ 
				int input = DisplayAMenu(choices);

				switch(input)
				{
					case 1:
						string skillName = ReadAString("Please enter the skill name:");
						SkillType skillType = ReadAnEnum<SkillType>($"Please enter the skill type (possible values are: {Enum.GetNames<SkillType>().Aggregate("", (name, chaine) => $"{chaine} {name}")}):");
						string skillDescription = ReadAString("Please enter the skill description:");
						Skill skill = new Skill(skillName, skillType, skillDescription);
						champion.AddSkill(skill);
						break;
					case 2:
						string skinName = ReadAString("Please enter the skin name:");
						string skinDescription = ReadAString("Please enter the skin description:");
						float skinPrice = ReadAFloat("Please enter the price of this skin:");
						Skin skin = new Skin(0, skinName, champion, skinPrice, description: skinDescription);
						break;
					case 3:
						string characteristic = ReadAString("Please enter the characteristic:");
						int value = ReadAnInt("Please enter the value associated to this characteristic:");
						champion.AddCharacteristics(Tuple.Create(characteristic, value));
						break;
					case 99:
						return;
					default:
						break;
				}
			}
		}

		private static int ReadAnInt(string message)
		{
			while(true)
			{
				WriteLine(message);
				if(!int.TryParse(ReadLine(), out int result))
				{
					continue;
				}
				return result;
			}
		}

		private static float ReadAFloat(string message)
		{
			while(true)
			{
				WriteLine(message);
				if(!float.TryParse(ReadLine(), out float result))
				{
					continue;
				}
				return result;
			}
		}

		private static string ReadAString(string message)
		{
			while(true)
			{
				WriteLine(message);
				string? line = ReadLine();
				if(line == null)
				{
					continue;
				}
				return line!;
			}
		}

		private static TEnum ReadAnEnum<TEnum>(string message) where TEnum :struct
		{
			while(true)
			{
				WriteLine(message);
				if(!Enum.TryParse<TEnum>(ReadLine(), out TEnum result))
				{
					continue;
				}
				return result;
			}
		}

		private static string ReadAStringAmongPossibleValues(string message, params string[] possibleValues)
		{
			while(true)
			{
				WriteLine(message);
				string? result = ReadLine();
				if(result == null) continue;
				if(result != "Cancel" && !possibleValues.Contains(result!)) continue;
				return result!;
			}
		}
	}
}