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
            Status = ItemStatus.unmarked;
        }

        public void SetStatus(ItemStatus status)
        {
            Status = status;
        }

        public void MarkAsMarked()
        {
            Status = ItemStatus.marked;
        }

        public void MarkAsUnmarked()
        {
            Status = ItemStatus.unmarked;
        }

        public void MarkAsArchived()
        {
            Status = ItemStatus.archived;
        }

        // public string GetFormattedDeadline()
        // {
        //
        // }
    }

    public enum ItemType
    {
        urgentimportant,
        noturgentimportant,
        urgentnotimportant,
        noturgentnotimportantitems
    }

    public enum ItemStatus
    {
        unmarked,
        marked,
        archived
    }
}