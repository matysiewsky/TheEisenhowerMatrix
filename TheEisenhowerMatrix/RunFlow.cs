using System;
using System.Collections.Generic;

namespace TheEisenhowerMatrix
{
    class RunFlow
    {
        public static ToDoMatrix GetDataBeforeRun()
        {
            // Hello window for an user with description of the program.

            Display.DisplayHelloMessage();
            Display.FreezeDisplay(4);
            //

            // Choosing running program mode logic - with adequate input and display in classes Input and Display.

            ProgramMode modeSet = Input.ChooseMode();
            //

            // Based on chosen mode - instantiating adequate ToDoMatrix (blank or imported) and returning it.
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
            //
        }

        public static void ProgramRunning(ToDoMatrix currentUserToDoMatrix)
        {
            // Program runs until MatrixRunning is set to true.

            bool matrixRunning = true;
            //

            while (matrixRunning)
            {
                // Generating UI over every iteration of while loop: clearing display, loading current state of
                // Matrix, displaying Matrix name, printing Matrix using MatrixManager class, displaying
                // possible operations.

                Display.ClearDisplay();
                List<List<ToDoItem>> matrixToPrint = currentUserToDoMatrix.CreateListOfListsOfItems();

                Display.MatrixNamePrint(currentUserToDoMatrix);
                MatrixManager.CreateMatrix(matrixToPrint);
                Display.PrintPossibleOperationsOnMatrix();
                //

                // Switch responsible for choosing adequate operation based on recognizing key pressed from
                // Console.ReadKey().KeyChar method.

                switch (Console.ReadKey().KeyChar)
                {
                    // CREATING ITEM:
                    case '1':
                        ToDoItem newToDoItem = Input.CreateItem();
                        currentUserToDoMatrix.AddItem(newToDoItem);
                        break;
                    //

                    // MARKING AN ITEM AS DONE:
                    case '2':
                        Tuple<int, int> coordinatesToMarkAsDone = Input.MarkingAndRemovingCoords(0);

                        try
                        {
                            ToDoItem toDoItemToMarkAsDone =
                                matrixToPrint[coordinatesToMarkAsDone.Item1][
                                    coordinatesToMarkAsDone.Item2];

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
                    //

                    // MARKING AN ITEM AS UNDONE:
                    case '3':
                        Tuple<int, int> coordinatesToMarkAsUndone = Input.MarkingAndRemovingCoords(1);

                        try
                        {
                            ToDoItem toDoItemToMarkAsUndone =
                                matrixToPrint[coordinatesToMarkAsUndone.Item1][
                                    coordinatesToMarkAsUndone.Item2];

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
                    //

                    // REMOVING AN ITEM:
                    case '4':
                        Tuple<int, int> coordinatesToRemove = Input.MarkingAndRemovingCoords(2);

                        try
                        {
                            currentUserToDoMatrix.ToDoQuarters[coordinatesToRemove.Item1]
                                .RemoveAnItem(coordinatesToRemove.Item2);
                        }
                        catch
                        {
                            Display.WrongInput(2);
                            Display.FreezeDisplay(2);
                        }

                        break;
                    //

                    // ARCHIVING ALL DONE ITEMS:
                    case '5':
                        currentUserToDoMatrix.ArchiveAllDoneItems();
                        break;
                    //

                    // QUITTING THE PROGRAM:
                    case '9':
                        DataManager.SaveToCSV(currentUserToDoMatrix);
                        matrixRunning = false;
                        break;
                    //
                }
            }
        }
    }
}