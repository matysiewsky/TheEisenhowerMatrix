using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    public static class MatrixManager
    {

        private static string NewRow(string firstParametr, string secondParametr)
        {
            return String.Format("| {0, -50} | {1, -50} |", firstParametr, secondParametr);
        }


        private static void AddTaskColored(List<Item> listOfItems, int j, string parametr)
        {
            if (listOfItems[j]._type != null)
            {
                ConsoleColor color = listOfItems[j].GetColor();
                Console.ForegroundColor = color;
            }

            Console.Write("{0, -50}", parametr);
            Console.ResetColor();

        }


        private static void CreateMatrixPart(List<Item> listOfItems1, List<Item> listOfItems2)
        {
            int list1Length = listOfItems1.Count;
            int list2Length = listOfItems2.Count;
            
            List<Item> shorterList = (list1Length < list2Length) ? listOfItems1: listOfItems2;
            int longerListLength = (list1Length < list2Length) ? list2Length : list1Length;

            int difference = Math.Abs(list1Length - list2Length);

            for (int l = 0; l < difference; l++)
            {
                shorterList.Add(new Item());
            }

            for (int j = 0; j < longerListLength; j++)
            {
                string firstParametr = (listOfItems1[j]._type == null) ? "" : $"{j + 1}) {listOfItems1[j]}";
                string secondParametr = (listOfItems2[j]._type == null) ? "" : $"{j + 1}) {listOfItems2[j]}";

                Console.Write("| ");
                AddTaskColored(listOfItems1, j, firstParametr);
                Console.Write(" | ");
                AddTaskColored(listOfItems2, j, secondParametr);
                Console.WriteLine(" |");
            }
        }


        private static List<Item> CreateListsOfItems(Dictionary<ItemType, List<Item>> ToDoMatrix, ItemType key)
        {
            var list = new List<Item>();

            foreach (var item in ToDoMatrix)
            {
                if (item.Key == key)
                {
                    foreach (var i in item.Value)
                    {
                        list.Add(i);
                    }
                }
            }

            return list;
        }


        public static void CreateAndDisplayMatrix(Dictionary<ItemType, List<Item>> dictionaryOfItems)
        {
            string line = "-----------------------------------------------------------------------------------------------------------";
            Console.WriteLine(line);
            Console.WriteLine(NewRow("A. important & urgent", "B. important & not urgent"));
            Console.WriteLine(line);

            var importantAndUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Urgentimportant);
            var importantAndNotUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Noturgentimportant);
            var notImportantAndUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Urgentnotimportant);
            var notImportantAndNotUrgentItems = CreateListsOfItems(dictionaryOfItems, ItemType.Noturgentnotimportantitems);

            CreateMatrixPart(importantAndUrgentItems, importantAndNotUrgentItems);
            Console.WriteLine(line);
            Console.WriteLine(NewRow("C. not important & urgent", "D. not important & not urgent"));
            Console.WriteLine(line);
            CreateMatrixPart(notImportantAndUrgentItems, notImportantAndNotUrgentItems);
            Console.WriteLine(line);

        }

    }
}