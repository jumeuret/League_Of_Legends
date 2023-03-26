using System;
using Model;

namespace StubLib
{
	public partial class StubData
	{
		private readonly List<Skin> skins = new();

		private void InitSkins()
		{
			skins.Add(new Skin(1,"Stinger", champions[0]));
			skins.Add(new Skin(2,"Infernal", champions[0]));
			skins.Add(new Skin(3,"All-Star", champions[0]));
			skins.Add(new Skin(4,"Justicar", champions[1]));
			skins.Add(new Skin(5,"Mecha", champions[1]));
			skins.Add(new Skin(6,"Sea Hunter", champions[1]));
			skins.Add(new Skin(7,"Dynasty", champions[2]));
			skins.Add(new Skin(8,"Midnight", champions[2]));
			skins.Add(new Skin(9,"Foxfire", champions[2]));
			skins.Add(new Skin(10,"Cyber Pop", champions[3]));
			skins.Add(new Skin(11,"Crystal Rose", champions[3]));
			skins.Add(new Skin(12,"Elderwood", champions[4]));
			skins.Add(new Skin(13,"Snow Day", champions[4]));
			skins.Add(new Skin(14,"Bard", champions[4]));
			skins.Add(new Skin(15,"Black", champions[5]));
			skins.Add(new Skin(16,"Golden", champions[5]));
			skins.Add(new Skin(17,"Matador", champions[5]));
		}

		public class SkinsManager : ISkinsManager
        {
            private readonly StubData parent;

            public SkinsManager(StubData parent)
                => this.parent = parent;

            public Task<Skin?> AddItem(Skin? item)
                => parent.skins.AddItem(item);

            public Task<bool> DeleteItem(Skin? item)
                => parent.skins.DeleteItem(item);

            public Task<IEnumerable<Skin?>> GetItems(int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.skins.GetItemsWithFilterAndOrdering(
                    skin => true,
                    index, count, orderingPropertyName, descending);

            private static Func<Skin, Champion?, bool> filterByChampion = (skin, champion) => champion != null && skin.Champion.Equals(champion!);

            private static Func<Skin, string, bool> filterByName = (skin, substring) => skin.Name.Contains(substring, StringComparison.InvariantCultureIgnoreCase);

            public Task<IEnumerable<Skin?>> GetItemsByChampion(Champion? champion, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.skins.GetItemsWithFilterAndOrdering(
                    skin => filterByChampion(skin, champion),
                    index, count, orderingPropertyName, descending);
            
            public Task<Skin?> GetItemByChampion(Champion champion, Skin skin)
	            => Task.FromResult(parent.skins.SingleOrDefault(skin => filterByChampion(skin, champion)));

            public Task<IEnumerable<Skin?>> GetItemsByName(string substring, int index, int count, string? orderingPropertyName = null, bool descending = false)
                => parent.skins.GetItemsWithFilterAndOrdering(
                    skin => filterByName(skin, substring),
                    index, count, orderingPropertyName, descending);

            public Task<int> GetNbItems()
                => parent.skins.GetNbItemsWithFilter(
                    c => true);

            public Task<int> GetNbItemsByChampion(Champion? champion)
                => parent.skins.GetNbItemsWithFilter(
                    skin => filterByChampion(skin, champion));

            public Task<int> GetNbItemsByName(string substring)
                => parent.skins.GetNbItemsWithFilter(
                    skin => filterByName(skin, substring));

            public Task<Skin?> UpdateItem(Skin? oldItem, Skin? newItem)
                => parent.skins.UpdateItem(oldItem, newItem);
            
            private Func<Skin, int, bool> filterById = (skin, id) => skin.Id==id;
            public Task<Skin> GetById(int id) 
	            => Task.FromResult(parent.skins.SingleOrDefault(skin => filterById(skin, id)));

        }
	}
}

