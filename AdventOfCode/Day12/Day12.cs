using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Script.Serialization;


namespace AdventOfCode.Day12
{
    public class Day12 : IAdventDay
    {
        private bool RED_MODE = false;

        public string PuzzleName => "JSAbacusFramework.io";

        public string SolvePartOne()
        {
            var input = FileParser.GetAllText("Day12/Day12Input.txt");
            //var parser = new JSONNumberParser();
            //var sum = parser.GetAllNumbers(input).Aggregate((a, b) => a + b);
            RED_MODE = false;
            var sum = GetSum(input);
            return sum.ToString();
        }

        public int GetSum(string input)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var d = jss.Deserialize<dynamic>(input);


            var sum = Sum(d);
            return sum;
        }

        public string SolvePartTwo()
        {
            var input = FileParser.GetAllText("Day12/Day12Input.txt");
            RED_MODE = true;
            var sum = GetSum(input);
            //object json = Json.Decode(input);
            //Type typeOfDynamic = json.GetType();
            //bool exist = typeOfDynamic.GetProperties().Any(p => p.Name.Equals("red"));
            return sum.ToString();
        }


        public int SumupLevel(Dictionary<string, object> level, int sum)
        {
            if (RED_MODE)
            {
                foreach (var member in level)
                {
                    if (member.Value.ToString() == "red")
                        return sum;
                }
            }

            foreach (var member in level)
            {
                sum += Sum(member.Value);
            }

            return sum;
        }

        private int Sum(object member)
        {
            int sum = 0;
            if (member is string)
                return sum;
            else if (member is Dictionary<string, object>)
                sum = SumupLevel((Dictionary<string, object>) member, sum);
            else if (member is object[])
                sum = SumupArray((object[]) member, sum);
            else if (member is int)
                sum = (int) member;
            else
                throw new Exception("WTF is this " + member);
            return sum;
        }

        private int SumupArray(object[] array, int sum)
        {
            foreach (var item in array)
            {
                sum += Sum(item);
            }

            return sum;
        }
    }
}
