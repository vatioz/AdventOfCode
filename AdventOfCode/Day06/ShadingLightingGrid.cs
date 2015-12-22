namespace AdventOfCode.Day06
{
    public class ShadingLightingGrid : LightingGridBase
    {
        #region | Overrides

        protected override void TurnOn(int i, int j)
        {
            _grid[i, j] += 1;
        }

        protected override void Toggle(int i, int j)
        {
            _grid[i, j] += 2;
        }

        protected override void TurnOff(int i, int j)
        {
            if (_grid[i, j] != 0)
                _grid[i, j] -= 1;
        }

        #endregion
    }
}