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
        StringBuilder Result = new StringBuilder();
        public DayFive()
        {
            this.input = File.ReadAllText("D://Repos//AoC2018//AoC2018//Day5//Day5.txt");      }

        public void CalculateResult1()
        {
            Result.Append(input[0]);
            for(int i = 1; i < this.input.Length; i++)
            {
                this.checkIfPolymer(i);
            }

            Console.WriteLine(Result.Length);
        }


        private void checkIfPolymer(int currentIndex)
        {
            if(Result.Length > 0)
            {
                if (char.IsLower(input[currentIndex]))
                {
                    if (char.IsUpper(Result[Result.Length-1]))
                    {
                        if(char.ToUpper(input[currentIndex]) == Result[Result.Length - 1])
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
                if (char.IsUpper(input[currentIndex]))
                {
                    if (char.IsLower(Result[Result.Length - 1]))
                    {
                        if(char.ToLower(input[currentIndex])== Result[Result.Length - 1])
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
            }
            else
            {
                Result.Append(input[currentIndex]);
            }
        }

        private string createNeighbours(int currentIndex)
        {
            StringBuilder newString = new StringBuilder();
            if(currentIndex > 0)
            {
                if(this.Result.Length > 0)
                {
                    newString.Append(this.Result[this.Result.Length - 1]);
                }
            }
            newString.Append(input[currentIndex]);
            if(currentIndex < this.input.Length - 1)
            {
                newString.Append(this.input[currentIndex + 1]);
            }
            return newString.ToString();
        }
    }
}
