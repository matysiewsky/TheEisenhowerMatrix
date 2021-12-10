#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
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

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        mode = ProgramMode.NewCSV;
                        break;
                    case '2':
                        mode = ProgramMode.ExistingCSV;
                        break;
                }
            }

            return mode;
        }

        public static string ChooseFromSavedData(Dictionary<int, string> savedData)
        {
            int choice = -1;
            Display.FileChoiceMessage();

            while (choice < 1)
            {
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out int userInput);

                if (userInput > 0 && savedData.ContainsKey(userInput))
                {
                    choice = userInput;
                }
                else
                {
                    Display.WrongInput(1);
                }
            }

            return savedData[choice];
        }

        public static string ChooseNameForMatrix()
        {
            string choice = null;
            Display.MatrixNameChoiceMessage();

            while (choice == null)
            {
                string userInput = Console.ReadLine();

                if (userInput.Length >= 5 && userInput.All(Char.IsLetter))
                {
                    choice = userInput;
                }
                else
                {
                    Display.WrongInput(1);
                }
            }

            return choice;
        }

        public static ToDoItem CreateItem()
        {
            string itemDescription = null;
            bool isImportant = false;
            DateTime itemDeadline = DateTime.MaxValue;

            Display.ItemAddingMessages(1);

            while (itemDescription == null)
            {
                string userInput = Console.ReadLine();

                if (userInput.Length >= 5) itemDescription = userInput;
                else Display.WrongInput(1);
            }

            Display.ItemAddingMessages(2);

            while (isImportant == false)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int chosenImportance) && chosenImportance is >= 1 and <= 2)
                {
                    if (chosenImportance == 1) isImportant = true;
                    else break;
                }

                else Display.WrongInput(1);
            }

            Display.ItemAddingMessages(3);

            while (itemDeadline == DateTime.MaxValue)
            {
                string userInput = Console.ReadLine();

                if (DateTime.TryParseExact(userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime chosenDeadline) &&
                    chosenDeadline >= DateTime.Now.Date)
                {
                    itemDeadline = chosenDeadline;
                }

                else Display.WrongInput(1);
            }

            return new ToDoItem(itemDescription, isImportant, itemDeadline);

        }

        public static Tuple<int, int> MarkingAndRemovingCoords(int whichMessage)
        {
            Tuple<int, int>? choice = null;

            while (choice == null)
            {
                Display.MarkingAndRemovingMessages(whichMessage);
                string userInput = Console.ReadLine();

                try
                {
                    string[] temp = userInput.Split('-');
                    Int32.TryParse(temp[0], out int value1);
                    Int32.TryParse(temp[1], out int value2);

                    if (value1 is >= 1 and <= 4 && value2 is > 0)
                    {
                        choice = new(value1 - 1, value2 - 1);
                    }
                }
                catch (Exception e)
                {
                    Display.WrongInput(1);
                }
            }
            return choice;
        }

    }
}