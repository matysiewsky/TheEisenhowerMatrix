using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    public static class MatrixManager
    {
        private static void CreateTask(List<ToDoItem> listOfItems, int j, string task)
        {
            if (listOfItems[j]._type != null)
            {
                ConsoleColor color = listOfItems[j].GetColor();
                Display.PrintColoredTask(color, task);
            }
            else
            {
                Display.PirintEmptySpace();
            }
        }


        private static void CreateMatrixPart(List<ToDoItem> listOfItems1, List<ToDoItem> listOfItems2)
        {
            int list1Length = listOfItems1.Count;
            int list2Length = listOfItems2.Count;
            
            List<ToDoItem> shorterList = (list1Length < list2Length) ? listOfItems1: listOfItems2;
            int longerListLength = (list1Length < list2Length) ? list2Length : list1Length;

            int difference = Math.Abs(list1Length - list2Length);

            for (int l = 0; l < difference; l++)
            {
                shorterList.Add(new ToDoItem());
            }

            for (int j = 0; j < longerListLength; j++)
            {
                string firstParametr = (listOfItems1[j]._type == null) ? "" : $"{j + 1}) {listOfItems1[j]}";
                string secondParametr = (listOfItems2[j]._type == null) ? "" : $"{j + 1}) {listOfItems2[j]}";

                Display.PrintHorizontalLine(LinePosition.Left);
                CreateTask(listOfItems1, j, firstParametr);
                Display.PrintHorizontalLine(LinePosition.Center);
                CreateTask(listOfItems2, j, secondParametr);
                Display.PrintHorizontalLine(LinePosition.Right);
            }
        }


        private static List<ToDoItem> CreateListsOfItems(Dictionary<ItemType, List<ToDoItem>> ToDoMatrix, ItemType key)
        {
            var list = new List<ToDoItem>();

            foreach (var item in ToDoMatrix)
            {
                if (item.Key == key)
                {
                    list = item.Value;
                }
            }
            return list;
        }


        public static void CreateMatrix(Dictionary<ItemType, List<ToDoItem>> dictionaryOfItems)
        {
            var importantAndUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Urgentimportant);
            var importantAndNotUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Noturgentimportant);
            var notImportantAndUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Urgentnotimportant);
            var notImportantAndNotUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Noturgentnotimportantitems);

            Display.PrintLine();
            Display.PrintHeader("A. important & urgent", "B. important & not urgent");
            Display.PrintLine();
            CreateMatrixPart(importantAndUrgentItems, importantAndNotUrgentItems);
            Display.PrintLine();
            Display.PrintHeader("C. not important & urgent", "D. not important & not urgent");
            Display.PrintLine();
            CreateMatrixPart(notImportantAndUrgentItems, notImportantAndNotUrgentItems);
            Display.PrintLine();
        }
    }

    public enum LinePosition
    {
        Left,
        Center,
        Right
    }
}