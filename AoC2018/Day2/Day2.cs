using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC2018.Day2
{
    class DayTwo
    {
        List<String> box_ids;
        string ResultString2;
        public DayTwo()
        {
            ResultString2 = "";
           this.box_ids = File.ReadAllLines("D://Projekty//AoC2018//AoC2018//Day2//Day2.txt").ToList();
        }

        public void CalculateResult1()
        {
            int checksum = 0;
            int doubles = 0;
            int triples = 0;
            foreach (string line in box_ids)
            {
                if (CheckRepetitions(line, 2))
                {
                    ++doubles;
                }
                if (CheckRepetitions(line, 3))
                {
                    ++triples;
                }
            }
            checksum = doubles * triples;
            Console.WriteLine("Found checksum is "+ checksum.ToString());
        }
        
        public int CalculateResult2()
        {
            for(int i = 0; i < box_ids.Count; i++)
            {
                for(int j = i+1; j < box_ids.Count; j++)
                {
                    if (this.CheckDifferingCharacters(box_ids[i], box_ids[j]))
                    {
                        Console.WriteLine("Common letters are " + this.ResultString2);
                        return 0;
                    }
                    else
                    {
                        this.ResultString2 = "";
                    }
                }
            }
            return -1;
        }

        private bool CheckRepetitions(string boxID, int repetitionCount)
        {
            Dictionary<char, int> letterCount = new Dictionary<char, int>();
            foreach(char character in boxID)
            {
                if (letterCount.ContainsKey(character))
                {
                    ++letterCount[character];
                }
                else
                {
                    letterCount.Add(character, 1);
                }
            }
            return letterCount.ContainsValue(repetitionCount);
        }

        private bool CheckDifferingCharacters(string first, string second)
        {
            bool hasOneDifferent = false;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] == second[i])
                {
                    str.Append(first[i]);
                }
                else if ((first[i] != second[i]) && (!hasOneDifferent))
                {
                    hasOneDifferent = true;
                }
                else
                {
                    return false;
                }
            }
            this.ResultString2 = str.ToString();
            return hasOneDifferent;
        }
    }
}
