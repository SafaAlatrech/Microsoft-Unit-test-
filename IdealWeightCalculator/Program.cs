﻿namespace IdealWeightCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            WeightCalculator weightCalculator = new WeightCalculator
            {
                Height = 180,
                Sex = 'm'

            };

            double weight = weightCalculator.GetIdealBodyWeight();

            Console.WriteLine($"The Ideal Body Weight: is {weight}");

            if (weight == 72.5)
            {   
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("test succeded");
            }else
            {   
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("test failed");
            }

            weightCalculator.Sex = 'w'; 
            weight = weightCalculator.GetIdealBodyWeight();


            if (weight == 72.5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("test succeded");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("test failed");
            }

        }
    }
}