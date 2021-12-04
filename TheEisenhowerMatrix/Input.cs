#nullable enable
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
            string? choice = null;
            Display.MatrixNameChoiceMessage();

            while (choice != null)
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

        public static Item CreateItem()
        {
            string? itemDescription = null;
            ItemType? itemType = null;
            DateTime? itemDeadline = null;

            Display.ItemAddingMessages(1);

            while (itemDescription == null)
            {
                string userInput = Console.ReadLine();

                if (userInput.Length >= 5)
                {
                    itemDescription = userInput;
                }
                else
                {
                    Display.WrongInput();
                }
            }

            Display.ItemAddingMessages(2);

            while (itemType == null)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int chosenType) && chosenType is >= 1 and <= 4)
                {
                    itemType = (ItemType) chosenType;
                    break;
                }

                Display.WrongInput();
            }

            Display.ItemAddingMessages(3);

            while (itemDeadline == null)
            {
                string userInput = Console.ReadLine();

                if (DateTime.TryParse(userInput, out DateTime chosenDeadline) &&
                    chosenDeadline >= DateTime.Now)
                {
                    itemDeadline = chosenDeadline;
                }

                Display.WrongInput();
            }

            return new Item(itemDescription, itemType, itemDeadline);

        }
    }
}