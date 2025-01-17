﻿namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new DataReader();
            reader.ImportData("data.csv");

            var printer = new DataPrinter(reader.ImportedObjects);
            printer.PrintData();
        }
    }
}
