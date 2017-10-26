using System;

namespace Lab5_DiceRolling_Random
{
    class Program
    {
        static void Main(string[] args)
        {
            bool begin = true;

            Console.Write("Welcome to the Casino!\nWhat is your name? ");
            string yourName = Console.ReadLine();
            do
            {

                Console.WriteLine($"{yourName} would you like to roll some dice (y/n)? ");
                bool enterCasino = GetYesorNo();
                if (enterCasino == false)
                {
                    return;
                }

                while (enterCasino)
                {

                    Console.Write("Entering the Dice Roller!\nPlease enter the number of sides on your dice: ");

                    bool repeat = true;
                    int input = GetInt(yourName);

                    while (repeat)
                    {
                        Random generator = new Random();
                        int diceRoll1 = generator.Next(input) + 1;
                        int diceRoll2 = generator.Next(input) + 1;
                        Console.WriteLine(diceRoll1 + "\n");
                        Console.WriteLine(diceRoll2 + "\n");

                        Console.WriteLine($"You rolled a {diceRoll1} and a {diceRoll2} on die with {input} sides!");

                        if (diceRoll1 == 1 && diceRoll2 == 1)
                        {
                            Console.WriteLine("SNAKE EYES!");
                        }

                        int diceTotal = diceRoll1 + diceRoll2;
                        if (diceTotal == 7 || diceTotal == 11)
                        {
                            Console.WriteLine($"You rolled a natural {diceTotal} in craps");
                        }

                        if (diceRoll1 == 6 && diceRoll2 == 6)
                        {
                            Console.WriteLine("BOX CARS");
                        }

                        Console.Write("Would you like to roll the dice again (y/n)? ");
                        repeat = GetYesorNo();
                        enterCasino = false;
                    }

                }
            } while (begin);
        }

        private static bool GetYesorNo()
        {
            bool valid = true;
            bool repeat = true;
            while (valid)
            {
                string answer = Console.ReadLine().ToLower();
                if (answer == "y" || answer == "yes")
                {
                    valid = false;
                    repeat = true;
                }
                else if (answer == "n" || answer == "no")

                {
                    valid = false;
                    repeat = false;
                }
                else
                {
                    Console.Write("Did not enter a valid input. Please enter (y/n): ");
                }
            }

            return repeat;
        }

        private static int GetInt(string name)
        {
            bool valid = false;
            int input = 0;

            while (!valid)
            {
                string sides = Console.ReadLine();
                valid = int.TryParse(sides, out input);
                Console.WriteLine($"{name}... You didn't enter valid input. Try again: ");
            }

            return input;
        }
    }
}
