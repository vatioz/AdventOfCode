using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class Table
    {
        public Table()
        {
            Seats = new HashSet<Seat>();
        }

        public HashSet<Seat> Seats { get; set; }


        public void SeatNextOne(Attendee attendee)
        {
            var newlySeated = new Seat(attendee);
            var lastSeated = Seats.LastOrDefault();

            if (lastSeated == null) // this is first attendee, so he is also last one
                lastSeated = newlySeated;

            lastSeated.Left = newlySeated;
            newlySeated.Right = lastSeated;

            Seats.Add(newlySeated);
            CloseCircularity(newlySeated);
        }

        /// <summary>
        /// Ensures we have circular table no matter the number of attendees.
        /// </summary>
        /// <param name="newlySeated">The newly seated.</param>
        private void CloseCircularity(Seat newlySeated)
        {
            var firstSeated = Seats.First();

            //if (firstSeated == null)
            //    firstSeated = newlySeated;

            firstSeated.Right = newlySeated;
            newlySeated.Left = firstSeated;
        }


        public int GetTotalHappiness()
        {
            return Seats.Sum(seat => seat.OverallHappiness);
        }

        public void PrepareTable()
        {
            Seats.Clear();
        }
    }
}
