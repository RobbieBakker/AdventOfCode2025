using System;
using System.Collections.Generic;
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

            //partA();
            //Console.WriteLine("Part A: " + partA() + "\n");

            partB();

        }

        static void partB()
        {
            int removed = 0;
            int removedThisIteration = 1;
            while (removedThisIteration > 0)
            {
                removedThisIteration = partA();
                removed += removedThisIteration;
                Console.WriteLine("Removed this iteration: " + removedThisIteration);
            }

            Console.WriteLine("Total removed: " + removed);
        }

        static Boolean checkIfPaper(int i, int j)
        {
            int[,] dirs =
            {
                {-1, -1}, {-1, 0}, {-1, 1},
                { 0, -1},          { 0, 1},
                { 1, -1}, { 1, 0}, { 1, 1}
            };

            for(int d = 0; d < dirs.GetLength(0); d++)
            {
                int ni = i + dirs[d, 0];
                int nj = j + dirs[d, 1];

                if (ni >= 0 && ni < allLines.Count &&
                    nj >= 0 && nj < allLines[ni].Count)
                {
                    return true;
                }
            }

            return false;
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
                        int adjacent = 0;
                        if (i-1 >= 0 && j-1 >= 0 && allLines[i-1][j-1] == '@') // row above
                        {
                            adjacent++;
                        }
                        if (i - 1 >= 0 && allLines[i - 1][j] == '@')
                        {
                            adjacent++;
                        }
                        if (i - 1 >= 0 && j + 1 < allLines[i-1].Count && allLines[i - 1][j + 1] == '@')
                        {
                            adjacent++;
                        }
                        if (j - 1 >= 0 && allLines[i][j - 1] == '@') // same row
                        {
                            adjacent++;
                        }
                        if (j+1 < allLines[i].Count && allLines[i][j + 1] == '@')
                        {
                            adjacent++;
                        }
                        if (i + 1 < allLines.Count && j-1 >= 0 && allLines[i + 1][j - 1] == '@') // row below
                        {
                            adjacent++;
                        }
                        if (i + 1 < allLines.Count && allLines[i + 1][j] == '@')
                        {
                            adjacent++;
                        }
                        if (i + 1 < allLines.Count && j + 1 < allLines[i + 1].Count && allLines[i + 1][j + 1] == '@')
                        {
                            adjacent++;
                        }

                        if (adjacent < 4) // if adjacent @ less than 4
                        {
                            allLines[i][j] = '.';
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
