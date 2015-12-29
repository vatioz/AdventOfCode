using System.Diagnostics;

namespace AdventOfCode.Day03
{
    [DebuggerDisplay("{X},{Y}")]
    public class Position
    {
        #region | Properties & fields

        public int X { get; set; }
        public int Y { get; set; }

        #endregion

        #region | ctors

        public Position() : this(0, 0)
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position(Position toCopy) : this(toCopy.X, toCopy.Y)
        {
        }

        #endregion

        #region | Overrides

        public override bool Equals(object obj)
        {
            var pos2 = (Position)obj;
            return pos2.X == X && pos2.Y == Y;
        }

        public override int GetHashCode()
        {
            return $"{X}:{Y}".GetHashCode();
        }

        #endregion
    }
}