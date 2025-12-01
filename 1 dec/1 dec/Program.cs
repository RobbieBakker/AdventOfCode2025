using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1_dec
{
    internal class Program
    {
        static List<string> allLines = new List<string>();
        static int partOne = 0;
        static int partTwo = 0;
        static int dialNumber = 50;

        static void Main(string[] args)
        {
            readFile();

            var watch = Stopwatch.StartNew(); // Set stopwatch for tracking execution time in ms


            for (int i = 0; i < allLines.Count(); i++)
            {
                dialNumber = rotate(dialNumber, allLines[i][0], Int32.Parse(Regex.Match(allLines[i], @"\d+").Value));
            }
            Console.WriteLine("Part 1: " + partOne.ToString());
            Console.WriteLine("Part 2: " + partTwo.ToString());


            watch.Stop(); // Stop stopwatch and print
            Console.WriteLine("Execution time: " + watch.ElapsedMilliseconds);
        }

        static int rotate(int dialNumber, char direction, int amount)
        {
            if (direction.Equals('R')) // Go RIGHT
            {
                for(int i = 0; i < amount; i++) // every tick
                {
                    dialNumber++;
                    
                    if (dialNumber % 100 == 0) // if comes past 0
                    {
                        dialNumber %= 100; // reset to 0
                        partTwo++; // add a found zero
                    }
                }

                if (dialNumber == 0) // count for part 1
                {
                    partOne++;
                }
            }
            else // Go LEFT
            {
                for (int i = 0; i < amount; i++) // every tick
                {
                    dialNumber--;
                    if (dialNumber % 100 == 0) // if comes past 0
                    {
                        dialNumber %= 100; // reset to 0
                        partTwo++; // add a found zero
                    }
                }

                if (dialNumber == 0) // count for part 1
                {
                    partOne++;
                }

            }

            return dialNumber;
        }



        static void readFile()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2025\\1 dec\\input.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    allLines.Add(line);
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

    
