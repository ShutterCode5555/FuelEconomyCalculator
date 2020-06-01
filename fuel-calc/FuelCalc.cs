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
            double mpg = (distance / fuel) * multiplier;
            StreamWriter writer;
            writer = File.AppendText($"{filename}.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(mpg);
            writer.Close();
            return mpg;
        }
        public static double FuelEconomyCalc(double fuel, double distance, string filename)
        {
            double mpg = distance / fuel;
            StreamWriter writer;
            writer = File.AppendText($"{filename}.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(mpg);
            writer.Close();
            return mpg;
        }
    }
}
