using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_dec
{
    internal class Program
    {
        List<int> allLines = new List<int>();
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew(); // Set stopwatch for tracking execution time in ms

            readFile();





            watch.Stop(); // Stop stopwatch and print
            Console.WriteLine("Total execution time: " + watch.ElapsedMilliseconds);
        }

        static void readFile()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2025\\6 dec\\sample.txt");
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
                        //allLines.Add((long.Parse(line.Split('-').First()), long.Parse(line.Split('-').Last())));
                    }
                    else
                    {
                        //allLines.Add(long.Parse(line));
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
