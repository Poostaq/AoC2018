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
        List<List<int>> fabric;
        int fabricArea;
        int correctFabricAreaID;

        public DayThree()
        {
            int fabricWidth = 0;
            int fabricHeigth = 0;
            fabricArea = 0;
            correctFabricAreaID = 0;
            fabric = new List<List<int>>();
            Claims = new List<Dictionary<string, int>>();
            this.input = File.ReadAllLines("D://Repos//AoC2018//AoC2018//Day3//Day3.txt").ToList();
            foreach (string claim in input)
            {
                IList<string> splitClaim = claim.Split(" ");
                Dictionary<string, int> newClaim = new Dictionary<string, int>();

                newClaim.Add("ID", Int32.Parse(splitClaim[0].Substring(1)));

                IList<string> leftntop = splitClaim[2].Substring(0, splitClaim[2].Length - 1).Split(",");
                newClaim.Add("Left", Int32.Parse(leftntop[0]));
                newClaim.Add("Top", Int32.Parse(leftntop[1]));

                IList<string> widthnheight = splitClaim[3].Split("x");
                newClaim.Add("Width", Int32.Parse(widthnheight[0]));
                newClaim.Add("Height", Int32.Parse(widthnheight[1]));

                if (newClaim["Left"] + newClaim["Width"] > fabricWidth) fabricWidth = newClaim["Left"] + newClaim["Width"];
                if (newClaim["Top"] + newClaim["Height"] > fabricHeigth) fabricHeigth = newClaim["Top"] + newClaim["Height"];
                Claims.Add(newClaim);
            }

            for(int i = 0; i < fabricHeigth; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < fabricWidth; j++)
                {
                    row.Add(0);
                }
                this.fabric.Add(row);
            }
        }

        public void CalculateResult1()
        {
            for(int i = 0; i < this.Claims.Count; i++)
            {
                this.applyClaim(this.Claims[i]);
            }
            int result = this.count();
            Console.WriteLine("Fabric Area with more claims is " + result.ToString());
        }

        public void CalculateResult2()
        {
            for (int i = 0; i < this.Claims.Count; i++)
            {
                this.applyClaim(this.Claims[i]);
            }
            for (int i = 0; i < this.Claims.Count; i++)
            {
                this.checkForClaim(this.Claims[i]);
            }
            Console.WriteLine("ID of claim = " + this.correctFabricAreaID.ToString());
        }

        private void applyClaim(Dictionary<string, int> claim)
        {
            for(int i = claim["Top"]; i < claim["Top"] + claim["Height"]; i++)
            {
                for(int j = claim["Left"]; j < claim["Left"]+claim["Width"]; j++)
                {
                    this.fabric[i][j]++;
                }
            }
        }

        private void checkForClaim(Dictionary<string, int> claim)
        {
            bool checkIfProper = true;
            for (int i = claim["Top"]; i < claim["Top"] + claim["Height"]; i++)
            {
                for (int j = claim["Left"]; j < claim["Left"] + claim["Width"]; j++)
                {
                    if (this.fabric[i][j]++ > 1)
                    {
                        checkIfProper = false;
                        break;
                    }
                }
                if (!checkIfProper)
                {
                    break;
                }
            }
            if (checkIfProper)
            {
                this.correctFabricAreaID = claim["ID"];
            }
        }

        private int count()
        {
            for(int i = 0; i < this.fabric.Count; i++)
            {
                for (int j = 0; j < this.fabric[0].Count; j++)
                {
                    if (fabric[i][j] > 1)
                    {
                        this.fabricArea++;
                    }
                }
            }
            return this.fabricArea;
        }
    }
}
