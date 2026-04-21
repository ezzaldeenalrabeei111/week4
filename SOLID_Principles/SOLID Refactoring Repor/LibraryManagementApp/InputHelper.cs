using System;

namespace LibraryManagementApp.Services
{
    public class InputHelper
    {
        public string GetStringInput(string prompt)
        {
            Console.Write("{0}: ", prompt);
            return Console.ReadLine();
        }

        public int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write("{0}: ", prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        public double GetDoubleInput(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write("{0}: ", prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
