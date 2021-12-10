using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    public class ToDoQuarter
    {
        public QuarterType ToDoQuarterType;

        private List<ToDoItem> _toDoItemsOfTheUrgImp = new();

        public ToDoQuarter(QuarterType givenType)
        {
            ToDoQuarterType = givenType;
        }

        public List<ToDoItem> GetItemsFromQuarter() => _toDoItemsOfTheUrgImp;


        public void AddItem(ToDoItem toDoItem)
        {
            _toDoItemsOfTheUrgImp.Add(toDoItem);
        }

        public void RemoveAnItem(int indexOftoDoItem)
        {
            _toDoItemsOfTheUrgImp.RemoveAt(indexOftoDoItem);
        }

        public void ArchiveAllDoneItems()
        {
            _toDoItemsOfTheUrgImp.RemoveAll(item => item.Status != ItemStatus.Unmarked);
        }

    }

    public enum QuarterType
    {
        Urgentimportant,
        Noturgentimportant,
        Urgentnotimportant,
        Noturgentnotimportant
    }
}