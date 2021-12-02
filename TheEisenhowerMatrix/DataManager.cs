using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;

namespace TheEisenhowerMatrix
{
    public class DataManager
    {
        public List<Item> ReadFromCSV()
        {

        }

        public void SaveToCSV(Matrix matrixName, List<Item> itemsToSave)
        {
            using StreamWriter FileWriter = new($"data/{matrixName}");
            using (CsvWriter CSVWriter = new(FileWriter, CultureInfo.CurrentCulture))
            {
                CSVWriter.WriteRecords(itemsToSave);
            }
        }
    }
}