using System.Collections.Generic;
using System.Linq;

namespace TheEisenhowerMatrix
{
    public class Matrix
    {
        public override string ToString();

        private List<Item> _items;

        public void ArchiveAllDoneItems()
        {
            foreach (Item item in _items.ToList())
            {
                if (item.Status != ItemStatus.unmarked)
                {
                    _items.Remove(item);
                }
            }
        }

        public void RemoveAnItem(Item item)
        {
            _items.Remove(item);
        }

    }
}