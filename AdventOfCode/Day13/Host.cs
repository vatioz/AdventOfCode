using AdventOfCode.Shared;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class Host
    {
        public List<Attendee> Attendees { get; set; }

        public Table PreparedTable { get; set; }

        public Host()
        {
            PreparedTable = new Table();
        }


        public void NoticePersonalities(string letter)
        {
            var lines = InputLineParser.GetAllLines(letter);
            foreach (var line in lines)
            {
                var personality = PersonalityParser.ParsePersonality(line);
                var existingAttendee = Attendees.SingleOrDefault(att => att.Name == personality.Name);
                if (existingAttendee == null)
                {
                    var newAttendee = new Attendee(personality.Name);
                    newAttendee.PotencialHapinnes.Add(personality.Neighbor, personality.Happiness);
                    Attendees.Add(newAttendee);
                }
                else
                {
                    existingAttendee.PotencialHapinnes.Add(personality.Neighbor, personality.Happiness);
                }
            }
        }

        public void TryAllSeatingPlans()
        {
            var seatingPlans = EnumerableHelpers.GetPermutations(Attendees, Attendees.Count);
            foreach (var seatingPlan in seatingPlans)
            {
                SeatEverybody(seatingPlan);
            }
        }

        public void SeatEverybody(IEnumerable<Attendee> seatingPlan)
        {
            foreach (var attendee in seatingPlan)
            {
                PreparedTable.SeatNextOne(attendee);
            }
        }
    }
}
