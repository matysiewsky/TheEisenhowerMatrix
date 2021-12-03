using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    public class MatrixManager
    {
        System.Text.StringBuilder matrix = new System.Text.StringBuilder();
        string newLine = Environment.NewLine;
        string line = " ----------------------------------------------------------------------------------------------------------" + Environment.NewLine;


        public string NewRow(string firstParametr, string secondParametr)
        {
            string row = String.Format("| {0, -50} | {1, -50} |", firstParametr, secondParametr);
            row += Environment.NewLine;
            return row;
        }


        public void CreateMatrixPart(List<string> list1, List<string> list2)
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


        public List<string> CreateListsOfElements(Dictionary<string, List<string>> ToDoMatrix, string key)
        {
            var list = new List<string>();

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

        public System.Text.StringBuilder CreateMatrix(Dictionary<string, List<string>> dictionaryOfItems)
        {
            // EXAMPLE OF DICTIONARY, only for tests
            //var ToDoMatrix = new Dictionary<string, List<string>>()
            //{
            //    { "IU", new List<string>{"Something important and urgent 1", "Something important and urgent 2", "iu", "do it!", "now.."} },
            //    { "IN", new List<string>{ "imp, not urgent 1", "imp, not urgent 2", "imp, not urgent 3", "4", "5", "6", "7", "8"} },
            //    { "NU", new List<string>{ "sth nu 1", "sth nu 2" , "sth nu 3" , "sth nu 4" } } ,
            //    { "NN", new List<string>{ "sth nn 1"} }
            //};

            matrix.Append(line);
            matrix.Append(NewRow("A) important & urgent", "B) important & not urgent"));
            matrix.Append(line);

            var importantAndUrgent = CreateListsOfElements(dictionaryOfItems, "IU");
            var importantAndNotUrgent = CreateListsOfElements(dictionaryOfItems, "IN");
            var notImportantAndUrgent = CreateListsOfElements(dictionaryOfItems, "NU");
            var notImportantAndNotUrgent = CreateListsOfElements(dictionaryOfItems, "NN");

            CreateMatrixPart(importantAndUrgent, importantAndNotUrgent);
            matrix.Append(NewRow("C) not important & urgent", "D) not important & not urgent"));
            matrix.Append(line);
            CreateMatrixPart(notImportantAndUrgent, notImportantAndNotUrgent);

            return matrix;

        }

    }
}