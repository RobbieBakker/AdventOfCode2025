using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5_dec
{
    internal class Program
    {
        static List<(long, long)> rangesList = new List<(long, long)>();
        static List<long> ingredientList = new List<long>();
        static void Main(string[] args)
        {
            readFile();
            var watch = Stopwatch.StartNew(); // Set stopwatch for tracking execution time in ms

            partA();

            partB2();


            watch.Stop(); // Stop stopwatch and print
            Console.WriteLine("Total execution time: " + watch.ElapsedMilliseconds);
        }

        static void partA()
        {
            var watch = Stopwatch.StartNew(); // Set stopwatch for tracking execution time in ms
            int freshIngredients = 0;

            foreach (long ingredient in ingredientList)
            {
                foreach ((long, long) range in rangesList)
                {
                    long start = range.Item1;
                    long end = range.Item2;

                    if (ingredient >= start && ingredient <= end)
                    {
                        freshIngredients++;
                        break;
                    }
                }
            }

            Console.WriteLine("Part A: " + freshIngredients);

            watch.Stop(); // Stop stopwatch and print
            Console.WriteLine("Part A execution time: " + watch.ElapsedMilliseconds + "\n");
        }


        static void partB2()
        {
            var watch = Stopwatch.StartNew(); // Set stopwatch for tracking execution time in ms
            long fresh = 0;

            rangesList.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            for (int i = 0; i < rangesList.Count - 1; i++)
            {

                if (rangesList[i].Item2 >= rangesList[i + 1].Item1 && rangesList[i].Item2 < rangesList[i+1].Item2) // this.2 > next.1 && this.2 < next.2
                {
                    rangesList[i] = (rangesList[i].Item1, rangesList[i + 1].Item2);
                    rangesList.RemoveAt(i + 1);
                    i--;
                }
                else if (rangesList[i].Item2 >= rangesList[i + 1].Item1 && rangesList[i].Item2 >= rangesList[i + 1].Item2) // this.2 >= next.1 && this.2 >= next.2
                {
                    rangesList.RemoveAt(i + 1);
                    i--;
                }
            }

            foreach ((long, long) range in rangesList)
            {
                fresh += range.Item2 - range.Item1 + 1;
            }

            Console.WriteLine("Part B: " + fresh);

            watch.Stop(); // Stop stopwatch and print
            Console.WriteLine("Part B execution time: " + watch.ElapsedMilliseconds + "\n");
        }

        static void readFile()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2025\\5 dec\\input.txt");
                //Read the first line of text
                line = sr.ReadLine();

                bool ranges = true;

                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (line == "")
                    {
                        ranges = false;
                    }
                    else if (ranges)
                    {
                        rangesList.Add((long.Parse(line.Split('-').First()), long.Parse(line.Split('-').Last())));
                    }
                    else
                    {
                        ingredientList.Add(long.Parse(line));
                    }
                        //write the line to console window
                        //Read the next line
                        line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
