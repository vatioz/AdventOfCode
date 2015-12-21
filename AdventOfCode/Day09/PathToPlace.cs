namespace AdventOfCode.Day09
{
    public class PathToPlace
    {
        public PathToPlace(Place connectedPlace, int distance)
        {
            OtherPlace = connectedPlace;
            Distance = distance;
        }

        public Place OtherPlace { get; set; }
        public int Distance { get; set; }
    }
}