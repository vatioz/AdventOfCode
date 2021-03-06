﻿using AdventOfCode.Day01;
using AdventOfCode.Day02;
using AdventOfCode.Day03;
using AdventOfCode.Day05;
using AdventOfCode.Day07;
using AdventOfCode.Day08;
using AdventOfCode.Day09;
using AdventOfCode.Day11;
using AdventOfCode.Day12;
using AdventOfCode.Day14;
using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventConsole
{
    public static class Program
    {
        static void Main(string[] args)
        {
            List<IAdventDay> advent = new List<IAdventDay>();
            advent.Add(new Day01());
            advent.Add(new Day02());
            advent.Add(new Day03());
            //advent.Add(new Day04()); // this one is very slow
            advent.Add(new Day05());
            //advent.Add(new Day06()); // slow
            advent.Add(new Day07());
            advent.Add(new Day08());
            advent.Add(new Day09());
            //advent.Add(new Day10()); // slow
            advent.Add(new Day11());
            advent.Add(new Day12());
            //advent.Add(new Day13()); // slow
            advent.Add(new Day14());

            var stopwatch = new Stopwatch();
            foreach (var adventDay in advent)
            {
                Console.WriteLine();
                Console.WriteLine($"**** {adventDay.GetType().Name}: {adventDay.PuzzleName} ****");
                Console.WriteLine($"*");
                stopwatch.Restart();
                var resultPartOne = adventDay.SolvePartOne();
                stopwatch.Stop();
                Console.WriteLine($"*  part one) {resultPartOne} [{stopwatch.ElapsedMilliseconds} ms]");

                stopwatch.Restart();
                var resultPartTwo = adventDay.SolvePartTwo();
                stopwatch.Stop();
                Console.WriteLine($"*  part two) {resultPartTwo} [{stopwatch.ElapsedMilliseconds} ms]");
                Console.WriteLine($"*");
                Console.WriteLine($"************************");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine(Environment.NewLine + "The End");
            Console.ReadKey();
        }
    }
}
