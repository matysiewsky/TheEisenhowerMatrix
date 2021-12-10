using System;
using CsvHelper.Configuration;

namespace TheEisenhowerMatrix
{
    public class ToDoItem
    {
        public string Message { get; }
        public bool IsImportant { get; }
        public DateTime Deadline { get; }
        public ItemStatus Status { get; private set; }


        // 3 different constructors:

        // 1) for creating empty ToDoItems needed for proper display:
        public ToDoItem()
        {
            Status = ItemStatus.Empty;
        }

        // 2) for creating item on running Matrix:
        public ToDoItem(string message, bool isImportant, DateTime deadline)
        {
            IsImportant = isImportant;
            Message = message;
            Deadline = deadline;
            Status = ItemStatus.Unmarked;
        }

        // 3) for creating items imported from .csv file:
        public ToDoItem(string message, bool isImportant, DateTime deadline, ItemStatus status)
        {
            IsImportant = isImportant;
            Message = message;
            Deadline = deadline;
            Status = status;
        }

        // SetStatus() method for: marking as done, undone.
        public void SetStatus(ItemStatus status)
        {
            Status = status;
        }


        public string GetFormattedDeadline() => $"{Deadline:dd-MM}";

        public ConsoleColor GetColor()
        {
            if ((Deadline - DateTime.Today).Days <= 1)
            {
                return ConsoleColor.Red;
            }

            if ((Deadline - DateTime.Today).Days <= 3)
            {
                return ConsoleColor.DarkYellow;
            }

            return ConsoleColor.Green;
        }


        public override string ToString()
        {
            return (Status == ItemStatus.Unmarked)
                ? $"[] {GetFormattedDeadline()} {Message}"
                : (Status == ItemStatus.Marked) ? $"[x] {GetFormattedDeadline()} {Message}" : "";
        }

        public int CompareTo(ToDoItem other)
        {
            if (Deadline > other.Deadline)
            {
                return 1;
            }

            if (Deadline < other.Deadline)
            {
                return -1;
            }

            return 0;
        }
    }

    public enum ItemStatus
    {
        // Two possible statuses of an item.
        Unmarked,
        Marked,
        Empty
    }
}