using System;

namespace TheEisenhowerMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            // FOR TESTS:
            //Matrix matrix1 = new Matrix("matrix1");

            //matrix1.AddItem(new Item("learn to code", ItemType.Urgentimportant, new DateTime(2021, 12, 09)));
            //matrix1.AddItem(new Item("sleep", ItemType.Noturgentimportant, new DateTime(2021, 12, 05)));
            //matrix1.AddItem(new Item("watch tv", ItemType.Noturgentnotimportantitems, new DateTime(2021, 12, 07)));
            //matrix1.AddItem(new Item("read book", ItemType.Noturgentnotimportantitems, new DateTime(2021, 12, 22)));
            //matrix1.AddItem(new Item("shopping", ItemType.Noturgentnotimportantitems, new DateTime(2021, 12, 16)));

            //var dictionary = matrix1.CreateDictionaryOfItems();
            //MatrixManager.CreateAndDisplayMatrix(dictionary);


            Display.DisplayHelloMessage();
            Display.FreezeDisplay(4);
            // Display.ClearDisplay();
            ProgramMode modeSet = Input.ChooseMode();

            Matrix currentUserMatrix;

            if (modeSet == ProgramMode.ExistingCSV)
            {
                Display.FileChoiceMessage();
                string[] savedData = DataManager.GetSavedData();
                string fileName = Input.ChooseFromSavedData(savedData);

                currentUserMatrix = DataManager.ImportUserData(fileName);
            }
            else if (modeSet == ProgramMode.NewCSV)
            {
                string nameChoice = Input.ChooseNameForMatrix();

                currentUserMatrix = new(nameChoice);
            }

            bool MatrixRunning = true;

            while (MatrixRunning)
            {
                // Display.
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Input.CreateItem();
                        break;
                }
            }
        }
    }
}