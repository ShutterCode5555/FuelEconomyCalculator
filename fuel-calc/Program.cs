using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

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
            var nl = Environment.NewLine;
            do
            {
                bool hasParsedMenuEntry;
                int menuChoice;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Fuel Economy Calculator{nl}======================={nl}");
                    Console.WriteLine("[1] Calculate MPG - litres/miles");
                    Console.WriteLine("[2] Calculate MPG  - gallons(US or Imperial)/miles");
                    Console.WriteLine("[3] Calculate L/100km - litres/kilometres");
                    Console.WriteLine($"[4] Calculate KPL - litres/kilometres{nl}{nl}");
                    Console.WriteLine("[5] View History");
                    Console.WriteLine("[6] Instructions");
                    Console.WriteLine($"[7] Quit{nl}");
                    Console.WriteLine("Please type the corresponding number for desired menu option and press ENTER:");
                    string menuChoiceString = Console.ReadLine();
                    hasParsedMenuEntry = Int32.TryParse(menuChoiceString, out menuChoice);
                }
                while (!hasParsedMenuEntry);
                switch (menuChoice)
                {
                    //MPG

                    case 1:
                        var fuelEntry = new FuelCalcv2();
                        double fuelResult = fuelEntry.Entry(MIN_LITRES, MAX_LITRES, "litres", PUMPED);
                        var distanceEntry = new FuelCalcv2();
                        double distanceResult = distanceEntry.Entry(MIN_MILES, MAX_MILES, "miles", TRAVELLED);
                        double resultData = distanceEntry.Calculate(distanceResult, fuelResult, MPG_FILENAME, LITRES2GALLONS);
                        Console.Clear();
                        Console.WriteLine($"Your MPG is: {resultData}{nl}");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;
                    //MPG (US/Imperial)
                    case 2:
                        var fuelEntry2 = new FuelCalcv2();
                        double fuelResult2 = fuelEntry2.Entry(MIN_GALLONS, MAX_GALLONS, "gallons", PUMPED);
                        var distanceEntry2 = new FuelCalcv2();
                        double distanceResult2 = distanceEntry2.Entry(MIN_MILES, MAX_MILES, "miles", TRAVELLED);
                        double resultData2 = distanceEntry2.Calculate(distanceResult2, fuelResult2, MPG_FILENAME);
                        Console.Clear();
                        Console.WriteLine($"Your MPG is: {resultData2}{nl}");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;
                    //LperKm100
                    case 3:
                        var fuelEntry3 = new FuelCalcv2();
                        double fuelResult3 = fuelEntry3.Entry(MIN_LITRES, MAX_LITRES, "litres", PUMPED);
                        var distanceEntry3 = new FuelCalcv2();
                        double distanceResult3 = distanceEntry3.Entry(MIN_KM, MAX_KM, "km", TRAVELLED);
                        double resultData3 = distanceEntry3.Calculate(fuelResult3, distanceResult3, LP100KM_FILENAME, LP100KM); //distance/fuel inputs reversed due to calc difference
                        Console.Clear();
                        Console.WriteLine($"Your MPG is: {resultData3}{nl}");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;
                    //KPL
                    case 4:
                        var fuelEntry4 = new FuelCalcv2();
                        double fuelResult4 = fuelEntry4.Entry(MIN_GALLONS, MAX_GALLONS, "gallons", PUMPED);
                        var distanceEntry4 = new FuelCalcv2();
                        double distanceResult4 = distanceEntry4.Entry(MIN_MILES, MAX_MILES, "miles", TRAVELLED);
                        double resultData4 = distanceEntry4.Calculate(distanceResult4, fuelResult4, MPG_FILENAME);
                        Console.Clear();
                        Console.WriteLine($"Your MPG is: {resultData4}{nl}");
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
                                Console.WriteLine($"History Menu{nl}============{nl}");
                                Console.WriteLine("[1] MPG History");
                                Console.WriteLine("[2] L/100km History");
                                Console.WriteLine($"[3] KPL History{nl}");
                                Console.WriteLine("[4] Clear History");
                                Console.WriteLine($"[5] Back to Main Menu{nl}");
                                Console.WriteLine("Please type the corresponding number for desired menu option and press ENTER:");
                                historyChoiceString = Console.ReadLine();
                                hasParsedHistoryChoice = Int32.TryParse(historyChoiceString, out historyChoice);
                            }
                            while (!hasParsedHistoryChoice);
                            switch (historyChoice)
                            {
                                case 1:
                                    MPGHistory("MPG History", MPG_FILENAME);
                                    Console.WriteLine($"{nl}Press ENTER to continue");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    MPGHistory("L/100km History", LP100KM_FILENAME);
                                    Console.WriteLine($"{nl}Press ENTER to continue");
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    MPGHistory("KPL History", KPL_FILENAME);
                                    Console.WriteLine($"{nl}Press ENTER to continue");
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    string confirm = "no";
                                    Console.WriteLine($"Are you sure you want to CLEAR ALL HISTORY LOGS.{nl}");
                                    Console.WriteLine($"!!THIS WILL PERMANENTLY DELETE ALL LOGS!!{nl}");
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
                                    Console.WriteLine($"{nl}Press ENTER to continue");
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
                        Console.WriteLine($"{nl}To use this program, you must first fill your car's{nl}fuel tank to the brim, then zero your trip counter. Then{nl}" +
                            $"drive for a week and then refuel, making a note of the{nl}litres or gallons it took to refill the tank. Then after taking{nl}" +
                            $"a note of the miles or km on the trip counter an zeroing the trip{nl}put the two sets of numbers into the calculator for the unit of{nl}" +
                            $"measurement chosen.{nl}{nl}Each calculator has the units of measurement used for the calculation{nl}next to it's menu option on the main menu.{nl}{nl}");
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
        static void MPGHistory(string writeLine, string filename)
        {
            var nl = Environment.NewLine;
            Console.Clear();
            Console.WriteLine($"{writeLine}{nl}");
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