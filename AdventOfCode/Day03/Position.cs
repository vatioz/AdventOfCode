using System;

namespace AdventOfCode.Day03
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(char arrow)
        {
            if (arrow == '^')
                Y++;
            else if (arrow == 'v')
                Y--;
            else if (arrow == '>')
                X++;
            else if (arrow == '<')
                X--;
            else if (arrow == ' ') // ugly ugly ugly
                ; // even more ugly
            else
                throw new NotImplementedException("Bad arrow");
        }

        public override bool Equals(object obj)
        {
            var pos2 = (Position)obj;
            return pos2.X == X && pos2.Y == Y;
        }



    }
}