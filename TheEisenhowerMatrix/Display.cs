using System;
using System.Collections.Generic;
using System.Threading;

namespace TheEisenhowerMatrix
{
    public static class Display
    {

        public static void DisplayHelloMessage()
        {
            Console.WriteLine(@"

Welcome to The Eisenhower Matrix App

The tool, sometimes called the Eisenhower Box or Eisenhower Decision Matrix, is an easy, 
yet an extremely effective way to prioritize and manage tasks and your time.
It is a system that basically makes you separate all your activities into four priority levels. 

Appropriate tasks planning frees your mind from constant memorization 
and let you hold yourself accountable for the tasks you have prioritized on.

Try the method out and let yourself out of procrastination circle.");
        }

        public static void ChooseMode()
        {
            Console.WriteLine(@"
The program runs in two different modes:
1)  For new users
2)  For existing users

Please choose by typing 1 or 2:            
");

        }
        public static void DisplayMatrix(System.Text.StringBuilder matrix)
        {
            Console.WriteLine(matrix);
        }

        public static void WrongInput(int whichMessage)
        {
            string[] messages =
            {
                "Wrong key pressed. Please try again!",
                "Wrong input. Please try again!",
                "There is no such position in the indicated list of the To Do Items!",
                "Position in the indicated list of the To Do Items is already marked as done!",
                "Position in the indicated list of the To Do Items is already marked as undone!"
            };

            Console.WriteLine(messages[whichMessage]);
        }

        public static void ClearDisplay()
        {
            Console.Clear();
        }

        public static void FreezeDisplay(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public static void ShowSavedData(string[] savedData)
        {
            Console.WriteLine(String.Join(Environment.NewLine, savedData));
        }

        public static void FileChoiceMessage()
        {
            Console.WriteLine("Please provide a filename to load.");
        }

        public static void MatrixNameChoiceMessage()
        {
            Console.WriteLine("Please provide a name for your Matrix. Only letters, at least 5 chars.");
        }

        public static void ItemAddingMessages(int whichMessage)
        {
            string[] messages =
            {
                "Please provide To Do Item description, at least 5 chars.",

                @"Please choose one of the following levels of urgency & importance:
Type:
1 for Urgent & important,
2 for Not urgent, but important,
3 for Urgent, but not important,
4 for Not urgent & not important",

                @"Please provide a deadline for the To Do Item formatted in dd/mm/yyyy. 
If the item doesn't have one type: 'Nope'",
            };

            Console.WriteLine(messages[whichMessage - 1]);
        }

        public static void MatrixNamePrint(Matrix currentUserMatrix)
        {
            Console.WriteLine($"The Eisenhower Matrix, name: {currentUserMatrix.Name}");
        }

        public static void PrintPossibleOperationsOnMatrix()
        {
            Console.WriteLine(@"Options, press: 
1 for adding a new To Do Item to your Matrix,
2 for marking the To Do Item as done,
3 for marking the To Do Item as not done,
4 for remove the item,
5 for archive all done To Do Items,
9 for quitting The App.");
        }

        public static void MarkingAsMessages(int whichMessage)
        {
            string[] messages =
            {
                "DONE: Please assign the level of urgency & importance (1-4) and the position of the item in the list. (ex. 1-10)",
                "UNDONE: Please assign the level of urgency & importance (1-4) and the position of the item in the list. (ex. 1-10)"
            };

            Console.WriteLine(messages[whichMessage]);
        }
    }
}