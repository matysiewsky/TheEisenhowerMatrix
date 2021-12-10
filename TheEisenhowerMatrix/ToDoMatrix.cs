using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    public class ToDoMatrix
    {
        public string Name;

        public List<ToDoQuarter> ToDoQuarters
        {
            get;
        }

        private List<QuarterType> _quartersToCreate = new()
        {
            QuarterType.Urgentimportant,
            QuarterType.Noturgentimportant,
            QuarterType.Urgentnotimportant,
            QuarterType.Noturgentnotimportant
        };

        public ToDoMatrix(string matrixName)
        {
            Name = matrixName;
            ToDoQuarters = new();

            foreach (QuarterType quarter in _quartersToCreate)
            {
                ToDoQuarters.Add(new ToDoQuarter(quarter));
            }
        }

        public void AddItem(ToDoItem toDoItem)
        {
            TimeSpan urgencyTimeSpan = new TimeSpan(3, 0, 0, 0);

            switch (toDoItem.IsImportant)
            {
                case true:
                    if ((toDoItem.Deadline - DateTime.Now) < urgencyTimeSpan) ToDoQuarters[0].AddItem(toDoItem);
                    else ToDoQuarters[1].AddItem(toDoItem);
                    break;
                case false:
                    if ((toDoItem.Deadline - DateTime.Now) < urgencyTimeSpan) ToDoQuarters[2].AddItem(toDoItem);
                    else ToDoQuarters[3].AddItem(toDoItem);
                    break;
            }
        }

        public void ArchiveAllDoneItems()
        {
            foreach (ToDoQuarter quarter in ToDoQuarters)
            {
                quarter.ArchiveAllDoneItems();
            }
        }

        public Dictionary<QuarterType, List<ToDoItem>> CreateDictionaryOfItems()
        {

            return new()
            {
                {QuarterType.Urgentimportant, ToDoQuarters[0].GetItemsFromQuarter()},
                {QuarterType.Noturgentimportant, ToDoQuarters[1].GetItemsFromQuarter()},
                {QuarterType.Urgentnotimportant, ToDoQuarters[2].GetItemsFromQuarter()},
                {QuarterType.Noturgentnotimportant, ToDoQuarters[3].GetItemsFromQuarter()}
            };
        }

        public List<ToDoItem> PrepareItemsForSaving()
        {
            List<ToDoItem> allItemsToSave = new();

            foreach (ToDoQuarter quarter in ToDoQuarters)
            {
                allItemsToSave.AddRange(quarter.GetItemsFromQuarter());
            }

            return allItemsToSave;
        }
    }
}