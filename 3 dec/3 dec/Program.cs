using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_dec
{
    internal class Program
    {
        static List<string> allLines = new List<string>();
        static void Main(string[] args)
        {
            readFile();

            partA();
            partB();
        }

        static void partB()
        {
            long sumJoltages = 0;
            foreach(string line in allLines) // foreach line
            {
                int buffer = line.Length - 12; // check how much numbers we can skip
                string joltage = "";
                int count = 0;

                for (int i = 0; i < line.Length; i++) // loop through all numbers
                {
                    if (count < 12) // lost the reason of this one, but without it my code breaks XD
                    {
                        int currentHighest = (int)char.GetNumericValue(line[i]);
                        //pos = i;
                        if(buffer > 0)
                        {
                            for (int j = i + 1; j < (i + 1 + buffer); j++) // check the next numbers if there is still buffer left
                            {
                                if (line.Length > j && char.GetNumericValue(line[j]) > currentHighest)
                                {
                                    currentHighest = (int)char.GetNumericValue(line[j]);
                                    buffer -= j - i; // subtract the difference in indexes to decrease the buffer as it's used
                                    i = j; // to skip the first loop a few checks, as we checked it in this loop
                                }
                            }
                        }
                        joltage += currentHighest;
                        count++; // Counting another number we found, we need 12
                    }
                }
                sumJoltages += long.Parse(joltage);
            }
            Console.WriteLine("Puzzle 2: " + sumJoltages);
        }

        static void partA()
        {
            int joltage = 0;
            foreach (string line in allLines) // find highest number & position
            {
                int high1 = 0;
                int pos = 0;
                int high2 = 0;
                for (int i = 0; i < line.Length - 1; i++)
                {
                    if (char.GetNumericValue(line[i]) > high1)
                    {
                        high1 = (int)char.GetNumericValue(line[i]);
                        pos = i;
                    }
                }
                for (int i = pos +1; i < line.Length; i++)
                {
                    if (char.GetNumericValue(line[i]) > high2)
                    {
                        high2 = (int)char.GetNumericValue(line[i]);
                    }
                }
                joltage += int.Parse(high1.ToString() + high2.ToString());
            }

            Console.WriteLine("Puzzle 1: " + joltage + "\n");
        }

        //static int highest(string line, int startPosition, )
        //{
        //    int highest = 0;
            
        //    for (int i = 0; i < line.Length - 1; i++)
        //    {
        //        if (char.GetNumericValue(line[i]) > highest)
        //        {
        //            highest = (int)char.GetNumericValue(line[i]);
        //        }
        //    }

        //    return highest;
        //}

        static void readFile()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2025\\3 dec\\sample.txt");
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
