namespace AdventOfCode.Day09
{
    public class PathToPlace
    {
        #region | Properties & fields

        public Place OtherPlace { get; }
        public int Distance { get; }

        #endregion

        #region | ctors

        public PathToPlace(Place connectedPlace, int distance)
        {
            OtherPlace = connectedPlace;
            Distance = distance;
        }

        #endregion
    }
}