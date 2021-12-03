using System;
using System.Linq;

namespace TheEisenhowerMatrix
{
    public static class Input
    {
        public static ProgramMode ChooseMode()
        {
            ProgramMode mode = ProgramMode.NotSetYet;

            while (mode == ProgramMode.NotSetYet)
            {
                Display.ChooseMode();
                if (Console.ReadKey().KeyChar == '1')
                {
                    mode = ProgramMode.NewCSV;
                }
                else if (Console.ReadKey().KeyChar == '2')
                {
                    mode = ProgramMode.ExistingCSV;
                }
                else
                {
                    Display.WrongInput();
                }
            }

            return mode;
        }

        public static string ChooseFromSavedData(string[] savedData)
        {
            string choice = "";
            Display.FileChoiceMessage();

            while (choice != "")
            {
                string userInput = Console.ReadLine();

                if (Array.Exists(savedData, x => x == userInput))
                {
                    choice = userInput;
                }
                else
                {
                    Display.WrongInput();
                }
            }

            return choice;
        }

        public static string ChooseNameForMatrix()
        {
            string choice = "";
            Display.MatrixNameChoiceMessage();

            while (choice != "")
            {
                string userInput = Console.ReadLine();

                if (userInput.Length >= 5 && userInput.All(Char.IsLetter))
                {
                    choice = userInput;
                }
                else
                {
                    Display.WrongInput();
                }
            }

            return choice;
        }
    }
}