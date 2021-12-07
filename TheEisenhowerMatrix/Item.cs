using System;

namespace TheEisenhowerMatrix
{
    public class Item : IItem
    {
        public ItemType? _type { get; private set; }
        private DateTime? _deadline;
        private string? _message;

        public ItemStatus Status
        {
            get; private set;
        }

        public Item(string? message, ItemType? type, DateTime? deadline)
        {
            _message = message;
            _type = type;
            _deadline = deadline;
            Status = ItemStatus.Unmarked;
        }

        public Item()
        {
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

        public string GetFormattedDeadline() => $"{_deadline:dd-MM}";


        public ConsoleColor GetColor()
        {
            if (((DateTime)this._deadline - DateTime.Today).Days <= 1)
            {
                return ConsoleColor.Red;
            }
            else if(((DateTime)this._deadline - DateTime.Today).Days <= 3)
            {
                return ConsoleColor.DarkYellow;
            }
            return ConsoleColor.Green;
        }


        public override string ToString()
        {
            return (this.Status == ItemStatus.Unmarked) ? $"[] {this.GetFormattedDeadline()} {_message}":
                $"[x] {this.GetFormattedDeadline()} {_message}";
        }
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