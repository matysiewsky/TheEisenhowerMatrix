using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    class RunFlow
    {
        public static ToDoMatrix GetDataBeforeRun()
        {
            Display.DisplayHelloMessage();
            Display.FreezeDisplay(4);
            ProgramMode modeSet = Input.ChooseMode();

            ToDoMatrix currentUserToDoMatrix;

            if (modeSet == ProgramMode.ExistingCSV)
            {
                Dictionary<int, string> savedData = DataManager.GetSavedData();
                Display.ShowSavedData(savedData);
                string fileName = Input.ChooseFromSavedData(savedData);

                currentUserToDoMatrix = DataManager.ImportUserData(fileName);
            }

            else
            {
                string nameChoice = Input.ChooseNameForMatrix();

                currentUserToDoMatrix = new(nameChoice);
            }

            return currentUserToDoMatrix;
        }

        public static void ProgramRunning(ToDoMatrix currentUserToDoMatrix)
        {
            bool MatrixRunning = true;

            while (MatrixRunning)
            {
                Display.ClearDisplay();
                Dictionary<QuarterType, List<ToDoItem>> matrixToPrint = currentUserToDoMatrix.CreateDictionaryOfItems();

                Display.MatrixNamePrint(currentUserToDoMatrix);
                MatrixManager.CreateAndDisplayMatrix(matrixToPrint);
                Display.PrintPossibleOperationsOnMatrix();

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        ToDoItem newToDoItem = Input.CreateItem();
                        currentUserToDoMatrix.AddItem(newToDoItem);
                        break;

                    case '2':
                        Tuple<int, int> coordinatesToMarkAsDone = Input.MarkingAndRemovingCoords(0);

                        try
                        {
                            ToDoItem toDoItemToMarkAsDone =
                                matrixToPrint[(QuarterType) coordinatesToMarkAsDone.Item1][coordinatesToMarkAsDone.Item2];

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
                            Display.FreezeDisplay(2);
                        }

                        break;

                    case '3':
                        Tuple<int, int> coordinatesToMarkAsUndone = Input.MarkingAndRemovingCoords(1);

                        try
                        {
                            ToDoItem toDoItemToMarkAsUndone =
                                matrixToPrint[(QuarterType) coordinatesToMarkAsUndone.Item1][coordinatesToMarkAsUndone.Item2];

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
                            Display.FreezeDisplay(2);
                        }

                        break;

                    case '4':
                        Tuple<int, int> coordinatesToRemove = Input.MarkingAndRemovingCoords(2);

                        try
                        {
                            ToDoItem toDoItemToBeRemoved =
                                matrixToPrint[(QuarterType) coordinatesToRemove.Item1][coordinatesToRemove.Item2];

                            currentUserToDoMatrix.ToDoQuarters[coordinatesToRemove.Item1]
                                .RemoveAnItem(coordinatesToRemove.Item2);
                        }
                        catch
                        {
                            Display.WrongInput(2);
                            Display.FreezeDisplay(2);
                        }

                        break;

                    case '5':
                        currentUserToDoMatrix.ArchiveAllDoneItems();
                        break;

                    case '9':
                        DataManager.SaveToCSV(currentUserToDoMatrix);
                        MatrixRunning = false;
                        break;
                }
            }
        }
    }
}