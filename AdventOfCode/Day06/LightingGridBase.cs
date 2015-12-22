using System;
using System.Drawing;

namespace AdventOfCode.Day06
{
    public abstract class LightingGridBase
    {
        #region | Properties & fields

        protected readonly int[,] _grid;

        #endregion

        #region | ctors

        protected LightingGridBase()
        {
            _grid = new int[1000, 1000];
        }

        #endregion

        #region | Public interface

        public void ProcessInstruction(LightInstruction instruction)
        {
            ProcessInstruction(instruction.Mode, instruction.From, instruction.To);
        }

        public void ProcessInstruction(string mode, Point from, Point to)
        {
            ProcessInstruction(mode, from.X, from.Y, to.X, to.Y);
        }

        public void ProcessInstruction(string mode, int fromX, int fromY, int toX, int toY)
        {
            for (var i = fromX; i <= toX; i++)
            {
                for (var j = fromY; j <= toY; j++)
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

        public void Reset()
        {
            ProcessInstruction("turn off", new Point(0, 0), new Point(999, 999));
        }

        public int HowManyLightsAreLit()
        {
            var sum = 0;
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    sum += _grid[i, j];
                }
            }
            return sum;
        }

        #endregion

        #region | Non-public members

        protected abstract void TurnOn(int i, int j);

        protected abstract void Toggle(int i, int j);

        protected abstract void TurnOff(int i, int j);

        #endregion
    }
}