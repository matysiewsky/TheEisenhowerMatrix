using System;

namespace TheEisenhowerMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
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