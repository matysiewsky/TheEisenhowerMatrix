using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace TheEisenhowerMatrix
{
    public static class DataManager
    {
        private static readonly string PathToProject = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static void SaveToCSV(ToDoMatrix toDoMatrix)
        {
            using StreamWriter FileWriter = new($"{PathToProject}/data/{toDoMatrix.Name}.csv");
            using (CsvWriter CSVWriter = new(FileWriter, CultureInfo.CurrentCulture))
            {
                CSVWriter.WriteRecords(toDoMatrix.PrepareItemsForSaving());
            }
        }
        public static List<ToDoItem> ReadFromCSV(string filename)
        {
            List<ToDoItem> records = new();

            using StreamReader FileReader = new($"{PathToProject}/data/{filename}");
            using (CsvReader CSVReader = new(FileReader, CultureInfo.CurrentCulture))
            {
                CSVReader.Read();
                CSVReader.ReadHeader();
                while (CSVReader.Read())
                {
                    string message = CSVReader.GetField<string>("Message");
                    bool isImportant = CSVReader.GetField<bool>("IsImportant");
                    DateTime deadline = CSVReader.GetField<DateTime>("Deadline");
                    ItemStatus status = CSVReader.GetField<ItemStatus>("Status");

                    records.Add(new ToDoItem(message, isImportant, deadline, status));
                }
            }

            return records;
        }

        public static Dictionary<int, string> GetSavedData()
        {
            Dictionary<int, string> savedData = new();
            int counter = 1;

            foreach (string data in Directory.GetFiles($"{PathToProject}/data", "*.csv"))
            {
                savedData.Add(counter, data.Split("/data/")[1]);
                counter++;
            }

            return savedData;
        }

        public static ToDoMatrix ImportUserData(string filename)
        {
            List<ToDoItem> itemsToImport = ReadFromCSV(filename);

            ToDoMatrix importedToDoMatrix = new(filename);

            foreach (ToDoItem item in itemsToImport)
            {
                importedToDoMatrix.AddItem(item);
            }

            return importedToDoMatrix;
        }
    }
}