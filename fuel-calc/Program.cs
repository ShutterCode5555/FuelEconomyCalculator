using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection.Metadata.Ecma335;
namespace fuel_calc
{
    class Program
    {
        static void Main(string[] ags)
        {
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
            const string TRAVELLED = "travelled";
            const string PUMPED = "pumped";
            bool quit = false;
            do
            {
                bool hasParsedMenuEntry;
                int menuChoice;
                do
                {
                Console.Clear();
                Console.WriteLine("Fuel Economy Calculator\n" + "=======================");
                Console.WriteLine("\n");
                Console.WriteLine("[1] Calculate MPG - litres/miles");
                Console.WriteLine("[2] Calculate MPG  - gallons(US or Imperial)/miles");
                Console.WriteLine("[3] Calculate L/100km - litres/kilometres");
                Console.WriteLine("[4] Calculate KPL - litres/kilometres");
                Console.WriteLine("\n");
                Console.WriteLine("[5] View History");
                Console.WriteLine("[6] Instructions");
                Console.WriteLine("[7] Quit");
                Console.WriteLine("\n");
                Console.WriteLine("Please type the corresponding number for desired menu option and press ENTER:");
                string menuChoiceString = Console.ReadLine();
                hasParsedMenuEntry = Int32.TryParse(menuChoiceString, out menuChoice);
                }
                while (!hasParsedMenuEntry);
                    switch (menuChoice)
                    {
                        //MPG
                        case 1:
                            double outputCase1;
                            double fuelAmountCase1;
                            outputCase1 = CalcEntry(MIN_LITRES, MAX_LITRES, "litres", PUMPED);
                            fuelAmountCase1 = outputCase1;
                            double milesCase1;
                            double outputCase1a;
                            outputCase1a = CalcEntry(MIN_MILES, MAX_MILES, "miles", TRAVELLED);
                            milesCase1 = outputCase1a;
                            double outputResult;
                            outputResult = FuelEconomyCalc4var(fuelAmountCase1, milesCase1, LITRES2GALLONS, MPG_FILENAME);
                            Console.WriteLine($"Your MPG is: {outputResult}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //MPG (US/Imperial)
                        case 2:
                            double outputCase2;
                            double fuelAmountCase2;
                            outputCase2 = CalcEntry(MIN_GALLONS, MAX_GALLONS, "gallons", PUMPED);
                            fuelAmountCase2 = outputCase2;
                            double milesCase2;
                            double outputCase2a;
                            outputCase2a = CalcEntry(MIN_MILES, MAX_MILES, "miles", TRAVELLED);
                            milesCase2 = outputCase2a;
                            double outputResult2;
                            outputResult2 = FuelEconomyCalc3var(fuelAmountCase2, milesCase2, MPG_FILENAME);
                            Console.WriteLine($"Your MPG is: {outputResult2}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //LperKm100
                        case 3:
                            double outputCase3;
                            double fuelAmountCase3;
                            outputCase3 = CalcEntry(MIN_LITRES, MAX_LITRES, "litres", PUMPED);
                            fuelAmountCase3 = outputCase3;
                            double milesCase3;
                            double outputCase3a;
                            outputCase3a = CalcEntry(MIN_KM, MAX_KM, "km", TRAVELLED);
                            milesCase3 = outputCase3a;
                            double outputResult3;
                            outputResult3 = FuelEconomyCalc4var(fuelAmountCase3, milesCase3, LP100KM, MPG_FILENAME);
                            Console.WriteLine($"Your L/100km is: {outputResult3}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //KPL
                        case 4:
                            double outputCase4;
                            double fuelAmountCase4;
                            outputCase4 = CalcEntry(MIN_LITRES, MAX_LITRES, "litres", PUMPED);
                            fuelAmountCase4 = outputCase4;
                            double milesCase4;
                            double outputCase4a;
                            outputCase4a = CalcEntry(MIN_KM, MAX_KM, "km", TRAVELLED);
                            milesCase4 = outputCase4a;
                            double outputResult4;
                            outputResult4 = FuelEconomyCalc3var(fuelAmountCase4, milesCase4, MPG_FILENAME);
                            Console.WriteLine($"Your KPL is: {outputResult4}");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        //History
                        case 5:
                        int historyChoice;
                        string historyChoiceString;
                        bool historyQuit = false;
                        bool hasParsedHistoryChoice;
                        do
                        {
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
                                hasParsedHistoryChoice = Int32.TryParse(historyChoiceString, out historyChoice);
                            }
                            while (!hasParsedHistoryChoice);
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
                                    string confirm = "no";
                                    Console.WriteLine("Are you sure you want to CLEAR ALL HISTORY LOGS.");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("!!THIS WILL PERMANENTLY DELETE ALL LOGS!!");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Type 'yes' and then press ENTER to confirm");
                                    confirm = Console.ReadLine();
                                    while (confirm == "yes")
                                    {
                                        HistoryClear(MPG_FILENAME);
                                        HistoryClear(LP100KM_FILENAME);
                                        HistoryClear(KPL_FILENAME);
                                        Console.WriteLine("HISTORY CLEARED!");
                                        break;
                                    }
                                    confirm = "no";
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Press ENTER to continue");
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    historyQuit = true;
                                    break;
                                default:
                                    Console.Clear();
                                    break;
                            }
                        }
                        while (!historyQuit);
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Instructions");
                            Console.WriteLine("\n");
                            Console.WriteLine("To use this program, you must first fill your car's\n" + "fuel tank to the brim, then zero your trip counter. Then\n" + 
                            "drive for a week and then refuel, making a note of the\n" + "litres or gallons it took to refill the tank. Then after taking\n" +
                            "a note of the miles or km on the trip counter an zeroing the trip\n" + "put the two sets of numbers into the calculator for the unit of\n" +
                            "measurement chosen.\n" + "\n" + "Each calculator has the units of measurement used for the calculation\n" + "next to it's menu option on the main menu.");
                            Console.WriteLine("\n");
                            Console.WriteLine("\n");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            break;
                        case 7:
                            quit = true;
                            break;
                        default:
                            Console.Clear();
                            break;
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
        static void HistoryClear(string filename)
        {
                StreamWriter writer;
                writer = new StreamWriter($"{filename}.txt");
                writer.WriteLine(DateTime.Now);
                writer.WriteLine("HISTORY CLEARED");
                writer.Close();
        }
        static double CalcEntry(double constantMin, double constantMax, string entryTypeWriteline, string verb)
        {
            double output;
            do
            {
                Console.Clear();
                Console.WriteLine($"Type {entryTypeWriteline} {verb}:");
                string entryString = Console.ReadLine();
                bool hasParsedEntry = Double.TryParse(entryString, out output);
                if (!hasParsedEntry)
                {
                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                    Console.ReadLine();
                    output = 0;
                }
            }
            while (output < constantMin || output > constantMax);
            return output;
        }
    }
}