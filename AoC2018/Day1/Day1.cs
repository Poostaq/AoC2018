using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC2018.Day1
{
    class DayOne
    {
        int frequency;
        bool duplicate_frequency_found;
        List<string> input;
        List<int> list_of_frequencies;

        public DayOne()
        {
            this.frequency = 0;
            this.duplicate_frequency_found = false;
            this.list_of_frequencies = new List<int>
            {
                this.frequency
            };
            this.input = File.ReadAllLines("D://Projekty//AoC2018//AoC2018//Day1//Day1.txt").ToList();
        }

        public void CalculateResult1()
        {
            this.frequency = 0;
            for(int i = 0; i < this.input.Count; i++)
            {
                this.ModifyFrequency(this.input[i]);
            }
            System.Console.WriteLine("The result of Day1 part one is " + this.frequency);
        }

        public void CalculateResult2()
        {
            this.frequency = 0;
            while (!this.duplicate_frequency_found)
            {
                for (int i = 0; i < this.input.Count; i++)
                {
                    this.ModifyFrequency(this.input[i]);
                    for (int j = 0; j < this.list_of_frequencies.Count; j++)
                    {
                        if ((this.list_of_frequencies[j] == this.frequency) && (!this.duplicate_frequency_found))
                        {
                            Console.WriteLine("FOUND DUPLICATE " + this.frequency.ToString());
                            this.duplicate_frequency_found = true;
                            break;
                        }
                    }
                    this.list_of_frequencies.Add(this.frequency);
                }
            }    
        }

        private void ModifyFrequency(string instruction)
        {
            if (instruction[0] == '-')
            {
                int number = Int32.Parse(instruction.Substring(1));
                this.frequency -= number;
            }
            if (instruction[0] == '+')
            {
                int number = Int32.Parse(instruction.Substring(1));
                this.frequency += number;
            }
        }
    }
}
