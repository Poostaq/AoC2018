using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2018.Day5
{
    class DayFive
    {
        string input = "";
        string fullpolymer = "";
        StringBuilder Result = new StringBuilder();
        StringBuilder inputWithoutUnit = new StringBuilder();
        List<char> listOfUsedUnits = new List<char>();
        List<int> lengthsWithoutOneUnit = new List<int>();

        public DayFive()
        {
            this.input = File.ReadAllText("D://Repos//AoC2018//AoC2018//Day5//Day5.txt");
        }

        public void CalculateResult1()
        {
            for (int i = 0; i < this.input.Length; i++)
            {
                this.evaluatePolymer(i);
            }

            Console.WriteLine(Result.Length);
        }

        public void CalculateResult2()
        {
            this.fullpolymer = this.input;
            this.checkUsedUnits();
            for(int i = 0; i < this.listOfUsedUnits.Count; i++)
            {
                inputWithoutUnit.Clear();
                removeUnitFromPolymer(listOfUsedUnits[i]);
                for (int j = 0; j < this.input.Length; j++)
                {
                    this.evaluatePolymer(j);
                }
                lengthsWithoutOneUnit.Add(Result.Length);
                //Console.WriteLine(Result.Length);
                this.input = this.fullpolymer;
            }

            Console.WriteLine(lengthsWithoutOneUnit.Min());
        }

        private void evaluatePolymer(int currentIndex)
        {
            if (Result.Length > 0)
            {
                if (this.isPolarUnit(currentIndex))
                {
                    Result.Remove(Result.Length - 1, 1);
                }
                else
                {
                    Result.Append(input[currentIndex]);
                }
            }
            else
            {
                Result.Append(input[currentIndex]);
            }
        }

        private bool isPolarUnit(int currentIndex)
        {
            if (Math.Abs(input[currentIndex] - Result[Result.Length - 1]) == 32) { return true; } else { return false; }
        }

        private void removeUnitFromPolymer(char unit)
        {
            for (int i = 0; i < this.input.Length; i++)
            {
                if (char.ToLower(unit) != char.ToLower(this.input[i]))
                {
                    inputWithoutUnit.Append(this.input[i]);
                }
            }
            this.input = this.inputWithoutUnit.ToString();
        }

        private void checkUsedUnits()
        {
            for (int i = 0; i < this.input.Length; i++)
            {
                if (!listOfUsedUnits.Contains(char.ToLower(this.input[i])))
                {
                    listOfUsedUnits.Add(char.ToLower(this.input[i]));
                }
            }
        }
    }
}
