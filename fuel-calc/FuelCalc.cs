using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace fuel_calc
{
    public static class FuelCalc
    {
        public static double FuelEconomyCalc(double fuel, double distance, string filename, double multiplier)
        {
            double result = (distance / fuel) * multiplier;
            StreamWriter writer;
            writer = File.AppendText($"{filename}.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(result);
            writer.Close();
            return result;
        }
        public static double FuelEconomyCalc(double fuel, double distance, string filename)
        {
            double result = distance / fuel;
            StreamWriter writer;
            writer = File.AppendText($"{filename}.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(result);
            writer.Close();
            return result;
        }
    }
}
