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

        public static void WrongInput()
        {
            Console.WriteLine("Wrong key pressed. Please try again!");
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
    }
}