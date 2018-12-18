using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2018.Day4
{
    class DayFour
    {
        List<string> input = new List<string>();
        public DayFour()
        {
            this.input = File.ReadAllLines("D://Repos//AoC2018//AoC2018//Day4//Day4.txt").ToList();
        }

        public void CalculateResult1()
        {

        }

        private void sortListofEntries()
        {
            foreach(string line in this.input)
            {
                
            }
        }

        private int toSeconds(string date)
            //this does not count year
        {
            DateTime timestamp = DateTime.Parse(date.Substring(1,16));
            int result = 0;

            return result;
        }
    }

    class Entry
    {
        Dictionary<string, int> Date = new Dictionary<string, int>();


        internal Entry(string Date, string guardID, string task)
        {

        }
    }
}
