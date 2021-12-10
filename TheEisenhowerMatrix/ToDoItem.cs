using System;
using CsvHelper.Configuration;

namespace TheEisenhowerMatrix
{
    public class ToDoItem : IComparable<ToDoItem>
    {
        public string Message { get; private set;}
        public bool IsImportant { get; }
        public DateTime Deadline { get; private set; }
        public ItemStatus Status { get; private set; }


        public ToDoItem(string message, bool isImportant, DateTime deadline)
        {
            IsImportant = isImportant;
            Message = message;
            // _type = type;
            Deadline = deadline;
            Status = ItemStatus.Unmarked;
        }

        public ToDoItem()
        {

        }

        public ToDoItem(string message, bool isImportant, DateTime deadline, ItemStatus status)
        {
            IsImportant = isImportant;
            Message = message;
            // _type = type;
            Deadline = deadline;
            Status = status;
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

        public string GetFormattedDeadline() => $"{Deadline:dd-MM}";

        public ConsoleColor GetColor()
        {
            if ((Deadline - DateTime.Today).Days <= 1)
            {
                return ConsoleColor.Red;
            }

            if((Deadline - DateTime.Today).Days <= 3)
            {
                return ConsoleColor.DarkYellow;
            }
            return ConsoleColor.Green;
        }


        public override string ToString()
        {
            return (Status == ItemStatus.Unmarked) ? $"[] {GetFormattedDeadline()} {Message}":
                $"[x] {GetFormattedDeadline()} {Message}";
        }

        public int CompareTo(ToDoItem other)
        {
            if(Deadline > other.Deadline)
            {
                return 1;
            }

            if(Deadline < other.Deadline)
            {
                return -1;
            }
            return 0;
        }
    }

    public enum ItemStatus
    {
        Unmarked,
        Marked,
        Archived
    }

    public sealed class ToDoItemMap : ClassMap<ToDoItem>
    {
        public void ItemMap()
        {
            Map(m => m.Message).Name("Message");
            Map(m => m.IsImportant).Name("IsImportant");
            Map(m => m.Deadline).Name("Deadline");
            Map(m => m.Status).Name("Status");

        }
    }
}