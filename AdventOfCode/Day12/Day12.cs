﻿using AdventOfCode.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace AdventOfCode.Day12
{
    public class Day12 : IAdventDay
    {
        private bool RED_MODE = false;

        public string PuzzleName => "JSAbacusFramework.io";

        public object SolvePartOne()
        {
            var input = FileParser.GetAllText("Day12/Day12Input.txt");
            RED_MODE = false;
            var sum = GetSum(input);
            return sum;
        }

        public int GetSum(string input)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var d = jss.Deserialize<dynamic>(input);


            var sum = Sum(d);
            return sum;
        }

        public object SolvePartTwo()
        {
            var input = FileParser.GetAllText("Day12/Day12Input.txt");
            RED_MODE = true;
            var sum = GetSum(input);
            return sum;
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
                sum = SumupLevel((Dictionary<string, object>)member, sum);
            else if (member is object[])
                sum = SumupArray((object[])member, sum);
            else if (member is int)
                sum = (int)member;
            else if (member is ArrayList)
                sum = SumupArray(((ArrayList)member).ToArray(), sum);
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
