using System;

namespace AdventOfCode.Day06
{
    public class BinaryLightingGrid : LightingGridBase
    {
        protected override void TurnOn(int i, int j)
        {
            _grid[i, j] = 1;
        }

        protected override void Toggle(int i, int j)
        {
            _grid[i, j] = Math.Abs(_grid[i, j] - 1);
        }

        protected override void TurnOff(int i, int j)
        {
            _grid[i, j] = 0;
        }
    }
}