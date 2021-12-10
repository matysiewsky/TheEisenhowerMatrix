using System.Collections.Generic;
using System.Linq;

namespace TheEisenhowerMatrix
{
    public class ToDoMatrix
    {

        public string Name;
        private List<ToDoItem> _items = new();

        public ToDoMatrix(string matrixName)
        {
            Name = matrixName;
        }

        public void AddItem(ToDoItem toDoItem)
        {
            _items.Add(toDoItem);
        }

        public void ArchiveAllDoneItems()
        {
            foreach (ToDoItem item in _items.ToList())
            {
                if (item.Status != ItemStatus.Unmarked)
                {
                    _items.Remove(item);
                }
            }


            // try this shorter syntax:
            // _items.RemoveAll(item => item.Status != ItemStatus.Unmarked);

        }

        public void RemoveAnItem(ToDoItem toDoItem)
        {
            _items.Remove(toDoItem);
        }

        // public override string ToString()
        // {
        //
        // };


        public Dictionary<ItemType, List<ToDoItem>> CreateDictionaryOfItems()
        {

            var dictionaryOfItems = new Dictionary<ItemType, List<ToDoItem>>()
            {
                { ItemType.Urgentimportant, SortItems(ItemType.Urgentimportant) },
                { ItemType.Noturgentimportant, SortItems(ItemType.Noturgentimportant) },
                { ItemType.Urgentnotimportant, SortItems(ItemType.Urgentnotimportant) } ,
                { ItemType.Noturgentnotimportantitems, SortItems(ItemType.Noturgentnotimportantitems) }
            };

            return dictionaryOfItems;
        }


        private List<ToDoItem> SortItems(ItemType itemType)
        {
            var list = new List<ToDoItem>();
            
            foreach (var item in this._items)
            {
                if (item._type == itemType)
                {
                    list.Add(item);
                }
            }

            list.Sort();
            return list;
        }
    }
}