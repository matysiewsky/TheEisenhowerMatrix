using System.Collections.Generic;
using System.Linq;

namespace TheEisenhowerMatrix
{
    public class Matrix
    {

        public string Name;
        private List<Item> _items = new();

        public Matrix(string matrixName)
        {
            Name = matrixName;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void ArchiveAllDoneItems()
        {
            foreach (Item item in _items.ToList())
            {
                if (item.Status != ItemStatus.Unmarked)
                {
                    _items.Remove(item);
                }
            }


            // try this shorter syntax:
            // _items.RemoveAll(item => item.Status != ItemStatus.Unmarked);

        }

        public void RemoveAnItem(Item item)
        {
            _items.Remove(item);
        }

        // public override string ToString()
        // {
        //
        // };


        public Dictionary<ItemType, List<Item>> CreateDictionaryOfItems()
        {

            var dictionaryOfItems = new Dictionary<ItemType, List<Item>>()
            {
                { ItemType.Urgentimportant, SortItems(ItemType.Urgentimportant) },
                { ItemType.Noturgentimportant, SortItems(ItemType.Noturgentimportant) },
                { ItemType.Urgentnotimportant, SortItems(ItemType.Urgentnotimportant) } ,
                { ItemType.Noturgentnotimportantitems, SortItems(ItemType.Noturgentnotimportantitems) }
            };

            return dictionaryOfItems;
        }


        private List<Item> SortItems(ItemType itemType)
        {
            var list = new List<Item>();
            
            foreach (var item in this._items)
            {
                if (item._type == itemType)
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}