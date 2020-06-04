using System.IO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace fuel_calc
{
    class FuelCalcv2
    {
        private double dataEntry;
        private bool hasParsedEntry;
        private double result;
        public double DataEntry
        {
            get { return dataEntry; }
        }
        public double Result
        {
            get { return result; }
        }
        public double Entry(double constantMin, double constantMax, string entryTypeWriteline, string verb)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Type {entryTypeWriteline} {verb}:");
                string entryString = Console.ReadLine();
                hasParsedEntry = Double.TryParse(entryString, out dataEntry);
                if (!hasParsedEntry)
                {
                    Console.WriteLine("Invalid number entered, press ENTER to try again");
                    Console.ReadLine();
                    dataEntry = 0;
                }
            }
            while (dataEntry < constantMin || dataEntry > constantMax);
            return DataEntry;
        }
        public double Calculate(double input1, double input2, string filename, double multiplier = 1)
        {
            result = (input1 / input2) * multiplier;
            StreamWriter writer;
            writer = File.AppendText($"{filename}.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(result);
            writer.Close();
            return Result;
        }
    }
}