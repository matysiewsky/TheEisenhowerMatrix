using System;
using System.Collections.Generic;

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

            else
            {
                string nameChoice = Input.ChooseNameForMatrix();

                currentUserMatrix = new(nameChoice);
            }

            bool MatrixRunning = true;

            while (MatrixRunning)
            {
                Display.ClearDisplay();
                Dictionary<ItemType, List<Item>> matrixToPrint = currentUserMatrix.CreateDictionaryOfItems();

                Display.MatrixNamePrint(currentUserMatrix);
                MatrixManager.CreateMatrix(matrixToPrint);
                Display.PrintPossibleOperationsOnMatrix();

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Item newItem = Input.CreateItem();
                        currentUserMatrix.AddItem(newItem);
                        break;

                    case '2':
                        Tuple<int, int> coordinatesToMarkAsDone = Input.MarkItemAs(ItemStatus.Unmarked);

                        try
                        {
                            Item itemToMarkAsDone = matrixToPrint[(ItemType) coordinatesToMarkAsDone.Item1][coordinatesToMarkAsDone.Item2];

                            if (itemToMarkAsDone.Status == ItemStatus.Marked)
                            {
                                Display.WrongInput(3);
                                Display.FreezeDisplay(2);
                            }
                            else
                            {
                                itemToMarkAsDone.SetStatus(ItemStatus.Marked);
                            }
                        }
                        catch
                        {
                            Display.WrongInput(2);
                        }
                        break;

                    case '3':
                        Tuple<int, int> coordinatesToMarkAsUndone = Input.MarkItemAs(ItemStatus.Marked);

                        try
                        {
                            Item itemToMarkAsUndone = matrixToPrint[(ItemType) coordinatesToMarkAsUndone.Item1][coordinatesToMarkAsUndone.Item2];

                            if (itemToMarkAsUndone.Status == ItemStatus.Unmarked)
                            {
                                Display.WrongInput(4);
                                Display.FreezeDisplay(2);
                            }
                            else
                            {
                                itemToMarkAsUndone.SetStatus(ItemStatus.Unmarked);
                            }
                        }
                        catch
                        {
                            Display.WrongInput(2);
                        }
                        break;

                    case '9':
                        MatrixRunning = false;
                        break;
                }
            }
        }
    }
}