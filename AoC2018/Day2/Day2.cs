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
        public DayTwo()
        {
           this.box_ids = File.ReadAllLines("D://Projekty//AoC2018//AoC2018//Day2//Day2.txt").ToList();
        }

        public void CalculateResult1()
        {
            int checksum = 0;
            int doubles = 0;
            int triples = 0;
            Console.WriteLine("Found checksum is");
        }

        public void CalculateDoubles()
        {

        }
    }
}
