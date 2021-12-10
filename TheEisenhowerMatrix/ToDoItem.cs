using System;
using CsvHelper.Configuration;

namespace TheEisenhowerMatrix
{
    public class ToDoItem
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


        public override string ToString()
        {
            return (Status == ItemStatus.Unmarked) ? $"[] {GetFormattedDeadline()} {Message}":
                $"[x] {GetFormattedDeadline()} {Message}";
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