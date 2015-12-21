using System;
using System.Drawing;

namespace AdventOfCode.Day06
{
    public abstract class LightingGridBase
    {
        protected int[,] _grid = new int[1000, 1000];

        public void ProcessInstruction(LightInstruction instruction)
        {
            ProcessInstruction(instruction.Mode, instruction.From, instruction.To);
        }

        public void ProcessInstruction(string mode, Point from, Point to)
        {
            for (int i = from.X; i <= to.X; i++)
            {
                for (int j = from.Y; j <= to.Y; j++)
                {
                    switch (mode)
                    {
                        case "turn on":
                            TurnOn(i, j);
                            break;
                        case "turn off":
                            TurnOff(i, j);
                            break;
                        case "toggle":
                            Toggle(i, j);
                            break;
                        default:
                            throw new ArgumentException($"Unknown mode {mode}");
                    }
                }
            }
        }

        protected abstract void TurnOn(int i, int j);

        protected abstract void Toggle(int i, int j);

        protected abstract void TurnOff(int i, int j);

        public void Reset()
        {
            ProcessInstruction("turn off", new Point(0, 0), new Point(999, 999));
        }

        public int HowManyLightsAreLit()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    sum += _grid[i, j];
                }
            }
            return sum;
        }
    }
}