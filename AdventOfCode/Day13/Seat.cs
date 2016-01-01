namespace AdventOfCode.Day13
{
    public class Seat
    {
        #region | Properties & fields

        public Attendee SittingAttendee { get; }
        public Seat Left { get; set; }
        public Seat Right { get; set; }

        private int HappinessFromLeft => SittingAttendee.PotencialHapinnes[Left.SittingAttendee.Name];
        private int HappinessFromRight => SittingAttendee.PotencialHapinnes[Right.SittingAttendee.Name];

        public int OverallHappiness => HappinessFromLeft + HappinessFromRight;

        #endregion

        #region | ctors

        public Seat(Attendee sittingAttendee)
        {
            SittingAttendee = sittingAttendee;
        }

        #endregion

        #region | Overrides

        public override bool Equals(object obj)
        {
            var seat = (Seat)obj;
            return seat.SittingAttendee.Equals(SittingAttendee);
        }

        public override int GetHashCode()
        {
            return SittingAttendee.GetHashCode();
        }

        #endregion
    }
}