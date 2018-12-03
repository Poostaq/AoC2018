using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AoC2018.Day3
{
    class DayThree
    {
        List<string> input;
        List<Dictionary<string, int>> Claims;
        List<List<int>> fabric = new List<List<int>>();
        DayThree()
        {
            int fabricWidth = 0;
            int fabricHeigth = 0;
            this.input = File.ReadAllLines("D://Projekty//AoC2018//AoC2018//Day2//Day2.txt").ToList();
            foreach (string claim in input)
            {
                IList<string> splitClaim = claim.Split(" ");
                Dictionary<string, int> newClaim = new Dictionary<string, int>();
                newClaim.Add("ID", Int32.Parse(splitClaim[0].Substring(0)));
                IList<string> leftntop = splitClaim[2].Substring(0, splitClaim[2].Length - 1).Split(".");
                newClaim.Add("Left", Int32.Parse(leftntop[0]));
                newClaim.Add("Top", Int32.Parse(leftntop[1]));
                IList<string> widthnheight = splitClaim[3].Split("x");
                newClaim.Add("Width", Int32.Parse(widthnheight[0]));
                newClaim.Add("Height", Int32.Parse(widthnheight[1]));
                if (newClaim["Left"] + newClaim["Width"] > fabricWidth) fabricWidth = newClaim["Left"] + newClaim["Width"];
                if (newClaim["Top"] + newClaim["Height"] > fabricHeigth) fabricHeigth = newClaim["Top"] + newClaim["Height"];
            }

            for(int i = 0; i < fabricHeigth; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < fabricWidth; j++)
                {
                    row.Add(0);
                }
                fabric.Add(row);
            }
        }

        public void CalculateResult1()
        {

        }

        private void applyClaim()
        {

        }
    }
}
