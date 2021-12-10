using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace TheEisenhowerMatrix
{
    public static class DataManager
    {
        public static void SaveToCSV(ToDoMatrix toDoMatrixName, List<ToDoItem> itemsToSave)
        {
            using StreamWriter FileWriter = new($"data/{toDoMatrixName}");
            using (CsvWriter CSVWriter = new(FileWriter, CultureInfo.CurrentCulture))
            {
                CSVWriter.WriteRecords(itemsToSave);
            }
        }
        public static List<ToDoItem> ReadFromCSV(string filename)
        {
            List<ToDoItem> records;

            using StreamReader FileReader = new($"data/{filename}");
            using (CsvReader CSVReader = new(FileReader, CultureInfo.InvariantCulture))
            {
                records = CSVReader.GetRecords<ToDoItem>().ToList();
            }

            return records;
        }

        public static string[] GetSavedData()
        {
            string[] savedData = Directory.GetFiles("data", "*.csv");

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