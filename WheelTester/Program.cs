using System;
using System.Collections.Generic;

namespace WheelTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Spin the wheel.");
            Console.WriteLine("");
            double averageRate = 1.0;
            int spins = 0;
            double startingCurrency = 2000000;
            double currentCurrency = startingCurrency;
            List<double> allRates = new List<double>();
            while(true)
            {
                Console.WriteLine("Current Money: " + currentCurrency.ToString());
                Console.WriteLine("Spun: " + spins.ToString() + " times.");
                Console.WriteLine("Average Rate: " + AverageList(allRates).ToString());
                Console.WriteLine("Spin the wheel?");
                string read = Console.ReadLine();
                switch(read)
                {
                    case "":
                    case "y":
                        // Spin again.
                        Tuple<double, double> spin = SpinWheel(50000);
                        currentCurrency -= 50000;
                        Console.WriteLine("Spinning with 50000: " + " rate returned " + spin.Item1);
                        allRates.Add(spin.Item1);
                        currentCurrency += spin.Item2;
                        spins += 1;
                        if(currentCurrency < 0)
                        {
                            Console.WriteLine("Failed, currency below zero. Resetting currency.");
                            currentCurrency = 2000000;
                        }
                        break;
                    case "n":
                        // Reset.11
                        currentCurrency = 2000000;
                        break;

                }
            }

        }

        static Tuple<double, double> SpinWheel(double amountGambled)
        {
            double o = 1.0;
            double amountOut = amountGambled;
            List<double> wheelRates = new List<double>();
            wheelRates.Add(0.1);
            wheelRates.Add(0.2);
            wheelRates.Add(0.3);
            wheelRates.Add(0.5);

            wheelRates.Add(1.2);
            wheelRates.Add(1.5);
            wheelRates.Add(1.7);
            wheelRates.Add(2.4);

            o = wheelRates[new Random().Next(0, 8)];
            amountOut *= o;

            return new Tuple<double,double>(o, amountOut);
        }

        public static double AverageList(List<double> listIn)
        {
            double o = 0.0;
            foreach(double d in listIn)
            {
                o += d;
            }
            int c = listIn.Count;
            if (c == 0) c = 1;
            return o / c;
        }
    }

}
