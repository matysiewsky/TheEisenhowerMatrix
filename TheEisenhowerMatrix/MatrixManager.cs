using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    public static class MatrixManager
    {
        private static void CreateTask(List<ToDoItem> listOfItems, int j, string task)
        {
            if (listOfItems[j].Message != null)
            {
                ConsoleColor color = listOfItems[j].GetColor();
                Display.PrintColoredTask(color, task);
            }
            else
            {
                Display.PrintEmptySpace();
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
                string firstParametr = (listOfItems1[j].Message == null) ? "" : $"{j + 1}) {listOfItems1[j]}";
                string secondParametr = (listOfItems2[j].Message == null) ? "" : $"{j + 1}) {listOfItems2[j]}";

                if((listOfItems1[j].Message != null) || (listOfItems2[j].Message != null))
                {
                    Display.PrintHorizontalLine(LinePosition.Left);
                    CreateTask(listOfItems1, j, firstParametr);
                    Display.PrintHorizontalLine(LinePosition.Center);
                    CreateTask(listOfItems2, j, secondParametr);
                    Display.PrintHorizontalLine(LinePosition.Right);
                }
            }
        }


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

    public enum LinePosition
    {
        Left,
        Center,
        Right
    }
}