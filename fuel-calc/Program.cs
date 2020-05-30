using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace fuel_calc
{
    class Program
    {
        static void Main(string[] ags)
        {
            //Variables
            int menuChoice;
            int historyChoice;
            string menuChoiceString;
            string historyChoiceString;
            string litresString;
            string milesString;
            string gallonsString;
            string kmString;
            double litres;
            double miles;
            double output;
            double gallons;
            double km;
            bool quit = false;
            bool historyQuit = false;
            const double MIN_LITRES = 1;
            const double MAX_LITRES = 1000;
            const double MIN_MILES = 1;
            const double MAX_MILES = 100000;
            const double MIN_GALLONS = 1;
            const double MAX_GALLONS = 10000;
            const double MIN_KM = 1;
            const double MAX_KM = 100000;
            const double LITRES2GALLONS = 4.544;
            const double LP100KM = 100;
            const string MPG_FILENAME = "MPG-History";
            const string LP100KM_FILENAME = "Lp100km-History";
            const string KPL_FILENAME = "KPL - History";
            do
            {
                historyQuit = false;
                Console.Clear();
                Console.WriteLine("Fuel Economy Calculator");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("[1] Calculate MPG - litres/miles");
                Console.WriteLine("[2] Calculate MPG  - gallons/miles");
                Console.WriteLine("[3] Calculate L/100km - litres/kilometres");
                Console.WriteLine("[4] Calculate KPL - litres/kilometres");
                Console.WriteLine("\n");
                Console.WriteLine("[5] View History");
                Console.WriteLine("[6] Instructions");
                Console.WriteLine("[7] Quit");
                Console.WriteLine("\n");
                Console.WriteLine("Please type the corresponding number for desired menu option and press ENTER:");
                menuChoiceString = Console.ReadLine();
                try
                {
                    //Menu selection and calculation
                    menuChoice = Int32.Parse(menuChoiceString);
                    switch (menuChoice)
                    {
                        //MPG
                        case 1:
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type litres pumped:");
                                    litresString = Console.ReadLine();
                                    litres = Double.Parse(litresString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    litres = 0;
                                }
                            }
                            while (litres < MIN_LITRES || litres > MAX_LITRES);
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type miles travelled:");
                                    milesString = Console.ReadLine();
                                    miles = Double.Parse(milesString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    miles = 0;
                                }
                            }
                            while (miles < MIN_MILES || miles > MAX_MILES);
                            output = FuelEconomyCalc4var(litres, miles, LITRES2GALLONS, MPG_FILENAME);
                            Console.WriteLine($"Your MPG is: {output}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //MPG (US)
                        case 2:
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type gallons pumped:");
                                    gallonsString = Console.ReadLine();
                                    gallons = Double.Parse(gallonsString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    gallons = 0;
                                }
                            }
                            while (gallons < MIN_GALLONS || gallons > MAX_GALLONS);
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type miles travelled:");
                                    milesString = Console.ReadLine();
                                    miles = Double.Parse(milesString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    miles = 0;
                                }
                            }
                            while (miles < MIN_MILES || miles > MAX_MILES);
                            output = FuelEconomyCalc3var(gallons, miles, MPG_FILENAME);
                            Console.WriteLine($"Your MPG is: {output}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //LperKm100
                        case 3:
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type litres pumped:");
                                    litresString = Console.ReadLine();
                                    litres = Double.Parse(litresString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    litres = 0;
                                }
                            }
                            while (litres < MIN_LITRES || litres > MAX_LITRES);
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type KM travelled:");
                                    kmString = Console.ReadLine();
                                    km = Double.Parse(kmString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    km = 0;
                                }
                            }
                            while (km < MIN_KM || km > MAX_KM);
                            output = FuelEconomyCalc4var(litres, km, LP100KM, LP100KM_FILENAME);
                            Console.WriteLine($"Your L/100km is: {output}/100km");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //KPL
                        case 4:
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type litres pumped:");
                                    litresString = Console.ReadLine();
                                    litres = Double.Parse(litresString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    litres = 0;
                                }
                            }
                            while (litres < MIN_LITRES || litres > MAX_LITRES);
                            do
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine("Type KM travelled:");
                                    kmString = Console.ReadLine();
                                    km = Double.Parse(kmString);
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                                    Console.ReadLine();
                                    km = 0;
                                }
                            }
                            while (km < MIN_KM || km > MAX_KM);
                            output = FuelEconomyCalc3var(litres, km, KPL_FILENAME);
                            Console.WriteLine($"Your KPL is: {output}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //History
                        case 5:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("History Menu");
                                Console.WriteLine("\n");
                                Console.WriteLine("Please type the corresponding number for desired menu option and press ENTER:");
                                Console.WriteLine("\n");
                                Console.WriteLine("[1] MPG History");
                                Console.WriteLine("[2] L/100km History");
                                Console.WriteLine("[3] KPL History");
                                Console.WriteLine("\n");
                                Console.WriteLine("[4] Clear History");
                                Console.WriteLine("[5] Back to Main Menu");
                                historyChoiceString = Console.ReadLine();
                                try
                                {
                                    historyChoice = Int32.Parse(historyChoiceString);
                                    switch (historyChoice)
                                    {
                                        case 1:
                                            MPGHistory("MPG History", MPG_FILENAME);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press ENTER to continue");
                                            Console.ReadLine();
                                            break;
                                        case 2:
                                            MPGHistory("L/100km History", LP100KM_FILENAME);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press ENTER to continue");
                                            Console.ReadLine();
                                            break;
                                        case 3:
                                            MPGHistory("KPL History", KPL_FILENAME);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press ENTER to continue");
                                            Console.ReadLine();
                                            break;
                                        case 4:
                                            HistoryClear(MPG_FILENAME, LP100KM_FILENAME, KPL_FILENAME);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press ENTER to continue");
                                            Console.ReadLine();
                                            break;
                                        case 5:
                                            historyQuit = true;
                                            break;
                                        //Wrong number entered
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("Invalid Number Entered");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Press ENTER to continue");
                                            Console.ReadLine();
                                            break;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid Option typed");
                                }
                            }
                            while (!historyQuit);
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Instructions");
                            Console.WriteLine("\n");
                            Console.WriteLine("To use this program, you will need to wait until your LOW FUEL \n" +
                                "warning light comes on, and at that point refuel as normal. \n" +
                                "When you refuel, reset your trip counter, and make a note \n" +
                                "of how much fuel in litres/gallons you put into the car. \n" +
                                "The next time your LOW fuel warning comes on, make a note \n" +
                                "of the miles/kilometres travelled on your trip counter. \n" +
                                "Now you can enter the distance travelled and amount of fuel put \n" +
                                "into the car into this calculator to work out either the MPG, \n" +
                                "L/100km or KPL between the two LOW FUEL warnings.");
                            Console.WriteLine("\n");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        case 7:
                            quit = true;
                            break;
                        //Wrong number entered
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Number Entered");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Option typed");
                }
            }
            while (!quit);
        }
        static double FuelEconomyCalc4var(double fuel, double distance, double multiplier, string filename)
        {
            double mpg = (distance / fuel) * multiplier;
            StreamWriter writer;
            writer = File.AppendText($"{filename}.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(mpg);
            writer.Close();
            return mpg;
        }
        static double FuelEconomyCalc3var(double fuel, double distance, string filename)
        {
            double mpg = distance / fuel;
            StreamWriter writer;
            writer = File.AppendText($"{filename}.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(mpg);
            writer.Close();
            return mpg;
        }
        static void MPGHistory(string writeLine, string filename)
        {
            Console.Clear();
            Console.WriteLine($"{writeLine}");
            Console.WriteLine("\n");
            StreamReader reader = new StreamReader($"{filename}.txt");
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            reader.Close();
        }
        static void HistoryClear(string mpg, string lp100km, string kpl)
        {
            string confirm = "no";
            Console.WriteLine("Are you sure you want to CLEAR ALL HISTORY LOGS.");
            Console.WriteLine("\n");
            Console.WriteLine("!!THIS WILL PERMANENTLY DELETE ALL LOGS!!");
            Console.WriteLine("\n");
            Console.WriteLine("Type 'yes' and then press ENTER to confirm");
            confirm = Console.ReadLine();
            while (confirm == "yes")
            {
                StreamWriter writer;
                writer = new StreamWriter($"{mpg}.txt");
                writer.WriteLine(DateTime.Now);
                writer.WriteLine("HISTORY CLEARED");
                writer.Close();
                StreamWriter writer2;
                writer2 = new StreamWriter($"{lp100km}.txt");
                writer2.WriteLine(DateTime.Now);
                writer2.WriteLine("HISTORY CLEARED");
                writer2.Close();
                StreamWriter writer3;
                writer3 = new StreamWriter($"{kpl}.txt");
                writer3.WriteLine(DateTime.Now);
                writer3.WriteLine("HISTORY CLEARED");
                writer3.Close();
                break;
            }
            confirm = "no";
        }
    }
}