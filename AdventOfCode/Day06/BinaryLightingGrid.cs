using System;

namespace AdventOfCode.Day06
{
    public class BinaryLightingGrid : LightingGridBase
    {
        #region | Overrides

        protected override void TurnOn(int i, int j)
        {
            _grid[i, j] = 1;
        }

        protected override void Toggle(int i, int j)
        {
            _grid[i, j] = Math.Abs(_grid[i, j] - 1); // this switches between 0 and 1 without if statement
        }

        protected override void TurnOff(int i, int j)
        {
            _grid[i, j] = 0;
        }

        #endregion
    }
}