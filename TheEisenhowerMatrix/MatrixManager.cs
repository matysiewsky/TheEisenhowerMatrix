using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    // static class MatrixManager - to create a console table 
    public static class MatrixManager
    {
        // GetConsoleColor() method to select color of console depends on deadline
        private static ConsoleColor GetConsoleColor(DeadlineStatus deadlineStatus)
        {
            switch (deadlineStatus)
            {
                case DeadlineStatus.OneDayLeft:
                    return ConsoleColor.Red;
                case DeadlineStatus.ThreeDaysLeft:
                    return ConsoleColor.DarkYellow;
                case DeadlineStatus.MoreThanThreeDaysLeft:
                    return ConsoleColor.Green;
                default:
                    return ConsoleColor.Green;
            }
        }

        // CreateTask() method to Display colored ToDoItem
        private static void CreateTask(List<ToDoItem> listOfItems, int listPosition, string task)
        {
            if (listOfItems[listPosition].Status != ItemStatus.Empty)
            {
                DeadlineStatus deadlineStatus = listOfItems[listPosition].GetDeadlineStatus();
                ConsoleColor color = GetConsoleColor(deadlineStatus);
                Display.PrintColoredTask(color, task);
            }
            else
            {
                Display.PrintEmptySpace();
            }
        }


        // CreateMatrixPart() method takes two list of ToDoItems (which will be shown next to each other)
        // and have a logic to create rows in matrix representing by each ToDoItem in that lists
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
                string firstParametr = (listOfItems1[j].Status == ItemStatus.Empty) ? "" : $"{j + 1}) {listOfItems1[j]}";
                string secondParametr = (listOfItems2[j].Status == ItemStatus.Empty) ? "" : $"{j + 1}) {listOfItems2[j]}";

                if((listOfItems1[j].Status != ItemStatus.Empty) || (listOfItems2[j].Status != ItemStatus.Empty))
                {
                    Display.PrintHorizontalLine(LinePosition.Left);
                    CreateTask(listOfItems1, j, firstParametr);
                    Display.PrintHorizontalLine(LinePosition.Center);
                    CreateTask(listOfItems2, j, secondParametr);
                    Display.PrintHorizontalLine(LinePosition.Right);
                }
            }
        }


        //CreateMatrix() method gets list of lists of ToDoItems and have a logic to display its in
        //console matrix table
        public static void CreateMatrix(List<List<ToDoItem>> listOfQuarters)
        {
            var importantAndUrgentItems = listOfQuarters[0];
            var importantAndNotUrgentItems = listOfQuarters[1];
            var notImportantAndUrgentItems = listOfQuarters[2];
            var notImportantAndNotUrgentItems = listOfQuarters[3];

            importantAndUrgentItems.Sort();
            importantAndNotUrgentItems.Sort();
            notImportantAndUrgentItems.Sort();
            notImportantAndNotUrgentItems.Sort();

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


    // enum represents variants of position of horizontal lines in printed matrix
    public enum LinePosition
    {
        Left,
        Center,
        Right
    }
}