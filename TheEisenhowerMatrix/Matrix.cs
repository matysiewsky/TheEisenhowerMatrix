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
        }

        public void RemoveAnItem(Item item)
        {
            _items.Remove(item);
        }

        public override string ToString()
        {

        };
    }
}