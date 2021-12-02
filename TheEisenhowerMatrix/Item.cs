using System;

namespace TheEisenhowerMatrix
{
    public class Item : IItem
    {
        private readonly ItemType _type;
        private DateTime _deadline;
        private string _message;

        public ItemStatus Status
        {
            get; private set;
        }

        public Item(string message, ItemType type, DateTime deadline)
        {
            _message = message;
            _type = type;
            _deadline = deadline;
            Status = ItemStatus.Unmarked;
        }

        public void SetStatus(ItemStatus status)
        {
            Status = status;
        }

        public void MarkAsMarked()
        {
            Status = ItemStatus.Marked;
        }

        public void MarkAsUnmarked()
        {
            Status = ItemStatus.Unmarked;
        }

        public void MarkAsArchived()
        {
            Status = ItemStatus.Archived;
        }

        // public string GetFormattedDeadline()
        // {
        //
        // }
    }

    public enum ItemType
    {
        Urgentimportant,
        Noturgentimportant,
        Urgentnotimportant,
        Noturgentnotimportantitems
    }

    public enum ItemStatus
    {
        Unmarked,
        Marked,
        Archived
    }
}