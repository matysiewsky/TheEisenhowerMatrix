using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    public static class MatrixManager
    {

        private static string NewRow(string firstParametr, string secondParametr)
        {
            string row = String.Format("| {0, -50} | {1, -50} |", firstParametr, secondParametr);
            row += Environment.NewLine;
            return row;
        }


        private static void CreateMatrixPart(List<string> list1, List<string> list2, System.Text.StringBuilder matrix, string line)
        {
            int list1Length = list1.Count;
            int list2Length = list2.Count;
            
            List<string> shorterList = (list1Length < list2Length) ? list1: list2;
            int longerListLength = (list1Length < list2Length) ? list2Length : list1Length;

            int difference = Math.Abs(list1Length - list2Length);

            for (int l = 0; l < difference; l++)
            {
                shorterList.Add("");
            }

            for (int j = 0; j < longerListLength; j++)
            {
                string firstParametr = (list1[j] == "") ? "" : $"{j + 1}) {list1[j]}";
                string secondParametr = (list2[j] == "") ? "" : $"{j + 1}) {list2[j]}";

                matrix.Append(NewRow(firstParametr, secondParametr));
            }

            matrix.Append(line);
        }


        private static List<string> CreateListsOfElements(Dictionary<ItemType, List<Item>> ToDoMatrix, ItemType key)
        {
            var list = new List<string>();

            foreach (var item in ToDoMatrix)
            {
                if (item.Key == key)
                {
                    foreach (var i in item.Value)
                    {
                        list.Add(Convert.ToString(i));
                    }
                }
            }

            return list;
        }


        public static void CreateAndDisplayMatrix(Dictionary<ItemType, List<Item>> dictionaryOfItems)
        {
            System.Text.StringBuilder matrix = new System.Text.StringBuilder();
            string newLine = Environment.NewLine;
            string line = "-----------------------------------------------------------------------------------------------------------" + Environment.NewLine;

            matrix.Append(line);
            matrix.Append(NewRow("A. important & urgent", "B. important & not urgent"));
            matrix.Append(line);

            var importantAndUrgent = CreateListsOfElements(dictionaryOfItems, ItemType.Urgentimportant);
            var importantAndNotUrgent = CreateListsOfElements(dictionaryOfItems, ItemType.Noturgentimportant);
            var notImportantAndUrgent = CreateListsOfElements(dictionaryOfItems, ItemType.Urgentnotimportant);
            var notImportantAndNotUrgent = CreateListsOfElements(dictionaryOfItems, ItemType.Noturgentnotimportantitems);

            CreateMatrixPart(importantAndUrgent, importantAndNotUrgent, matrix, line);
            matrix.Append(NewRow("C. not important & urgent", "D. not important & not urgent"));
            matrix.Append(line);
            CreateMatrixPart(notImportantAndUrgent, notImportantAndNotUrgent, matrix, line);

            Console.WriteLine(matrix);

        }

    }
}