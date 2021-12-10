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

            ToDoMatrix currentUserToDoMatrix;

            if (modeSet == ProgramMode.ExistingCSV)
            {
                Display.FileChoiceMessage();
                string[] savedData = DataManager.GetSavedData();
                string fileName = Input.ChooseFromSavedData(savedData);

                currentUserToDoMatrix = DataManager.ImportUserData(fileName);
            }

            else
            {
                string nameChoice = Input.ChooseNameForMatrix();

                currentUserToDoMatrix = new(nameChoice);
            }

            bool MatrixRunning = true;

            while (MatrixRunning)
            {
                Display.ClearDisplay();
                Dictionary<ItemType, List<ToDoItem>> matrixToPrint = currentUserToDoMatrix.CreateDictionaryOfItems();

                Display.MatrixNamePrint(currentUserToDoMatrix);
                MatrixManager.CreateMatrix(matrixToPrint);
                Display.PrintPossibleOperationsOnMatrix();

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        ToDoItem newToDoItem = Input.CreateItem();
                        currentUserToDoMatrix.AddItem(newToDoItem);
                        break;

                    case '2':
                        Tuple<int, int> coordinatesToMarkAsDone = Input.MarkItemAs(ItemStatus.Unmarked);

                        try
                        {
                            ToDoItem toDoItemToMarkAsDone = matrixToPrint[(ItemType) coordinatesToMarkAsDone.Item1][coordinatesToMarkAsDone.Item2];

                            if (toDoItemToMarkAsDone.Status == ItemStatus.Marked)
                            {
                                Display.WrongInput(3);
                                Display.FreezeDisplay(2);
                            }
                            else
                            {
                                toDoItemToMarkAsDone.SetStatus(ItemStatus.Marked);
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
                            ToDoItem toDoItemToMarkAsUndone = matrixToPrint[(ItemType) coordinatesToMarkAsUndone.Item1][coordinatesToMarkAsUndone.Item2];

                            if (toDoItemToMarkAsUndone.Status == ItemStatus.Unmarked)
                            {
                                Display.WrongInput(4);
                                Display.FreezeDisplay(2);
                            }
                            else
                            {
                                toDoItemToMarkAsUndone.SetStatus(ItemStatus.Unmarked);
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