using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_dec
{
    internal class Program
    {
        static List<List<char>> allLines = new List<List<char>>();
        static void Main(string[] args)
        {
            readFile();
            var watch = Stopwatch.StartNew(); // Set stopwatch for tracking execution time in ms

            //partA();
            //Console.WriteLine("Part A: " + partA() + "\n");

            partB();

            watch.Stop(); // Stop stopwatch and print
            Console.WriteLine("Execution time: " + watch.ElapsedMilliseconds);

        }

        static void partB()
        {
            int removed = 0;
            int removedThisIteration = 1;
            while (removedThisIteration > 0)
            {
                removedThisIteration = partA();
                removed += removedThisIteration;
                //Console.WriteLine("Removed this iteration: " + removedThisIteration);
            }

            Console.WriteLine("Total removed: " + removed);
        }

        static int checkIfPaper(int i, int j)
        {
            int adjacent = 0;
            for (int ni = -1; ni <= 1; ni++) // loops through the Y coordinates
            {
                for (int nj = -1; nj <= 1; nj++) // loops through the X coordinates
                {
                    if (i + ni >= 0 && i + ni < allLines.Count && // checking the validity of the Y coordinate
                        j + nj >= 0 && j + nj < allLines[i+ni].Count && // checking te validity of the X coordinate
                        allLines[i + ni][j + nj] == '@') // checking if it contains @
                    {
                        if (ni != 0 || nj != 0) // To prevent it from checking the original position.
                        {
                            adjacent++;
                        }
                    }
                }
            }

            return adjacent; // return the amount of neighbours containing an @
        }

        static int partA()
        {
            int reachable = 0;
            for (int i = 0; i < allLines.Count; i++) // loop through lines
            {
                for (int j = 0; j < allLines[i].Count; j++) // loop through characters
                {
                    if (allLines[i][j].Equals('@')) // if char is @, check positions around it
                    {
                        int adjacent = checkIfPaper(i, j); // check the neighbours

                        if (adjacent < 4) // if adjacent @ less than 4
                        {
                            allLines[i][j] = '.'; // remove the @ (paper roll)
                            reachable++;
                        }
                    }
                }
            }

            //Console.WriteLine("Removed this iteration: " + reachable);
            return reachable;
        }

        static void readFile()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2025\\4 dec\\input.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    List<char> position = new List<char>();
                    foreach(char c in line)
                    {
                        position.Add(c);
                    }
                    //write the line to console window
                    allLines.Add(position);
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
