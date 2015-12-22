using System;

namespace AdventOfCode.Day03
{
    public class Santa
    {
        #region | Properties & fields

        public Position CurrentPosition { get;}

        #endregion

        #region | ctors

        public Santa()
        {
            CurrentPosition = new Position();
        }

        #endregion

        #region | Public interface

        public void Move(char arrow)
        {
            if (arrow == '^')
                CurrentPosition.Y++;
            else if (arrow == 'v')
                CurrentPosition.Y--;
            else if (arrow == '>')
                CurrentPosition.X++;
            else if (arrow == '<')
                CurrentPosition.X--;
            else
                throw new NotImplementedException("Bad arrow");
        }

        #endregion
    }
}