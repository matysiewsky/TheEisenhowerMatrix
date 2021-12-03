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
        public static void SaveToCSV(Matrix matrixName, List<Item> itemsToSave)
        {
            using StreamWriter FileWriter = new($"data/{matrixName}");
            using (CsvWriter CSVWriter = new(FileWriter, CultureInfo.CurrentCulture))
            {
                CSVWriter.WriteRecords(itemsToSave);
            }
        }
        public static List<Item> ReadFromCSV(string filename)
        {
            List<Item> records;

            using StreamReader FileReader = new($"data/{filename}");
            using (CsvReader CSVReader = new(FileReader, CultureInfo.InvariantCulture))
            {
                records = CSVReader.GetRecords<Item>().ToList();
            }

            return records;
        }

        public static string[] GetSavedData()
        {
            string[] savedData = Directory.GetFiles("data", "*.csv");

            return savedData;
        }

        public static Matrix ImportUserData(string filename)
        {
            List<Item> itemsToImport = ReadFromCSV(filename);

            Matrix importedMatrix = new(filename);

            foreach (Item item in itemsToImport)
            {
                importedMatrix.AddItem(item);
            }

            return importedMatrix;
        }
    }
}