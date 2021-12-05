#nullable enable
using System;
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
                    Display.WrongInput(0);
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
                    Display.WrongInput(1);
                }
            }

            return choice;
        }

        public static string ChooseNameForMatrix()
        {
            string? choice = null;
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
                    Display.WrongInput(1);
                }
            }

            Display.ItemAddingMessages(2);

            while (itemType == null)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int chosenType) && chosenType is >= 1 and <= 4)
                {
                    itemType = (ItemType) chosenType - 1;
                    break;
                }

                Display.WrongInput(1);
            }

            Display.ItemAddingMessages(3);

            while (itemDeadline == null)
            {
                string userInput = Console.ReadLine();

                if (DateTime.TryParseExact(userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime chosenDeadline) &&
                    chosenDeadline >= DateTime.Now)
                {
                    itemDeadline = chosenDeadline;
                }

                Display.WrongInput(1);
            }

            return new Item(itemDescription, itemType, itemDeadline);

        }

        public static Tuple<int, int> MarkItemAs(ItemStatus status)
        {
            Tuple<int, int>? choice = null;

            while (choice == null)
            {
                Display.MarkingAsMessages((int) status);
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