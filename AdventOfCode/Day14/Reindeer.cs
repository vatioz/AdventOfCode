using System;

namespace AdventOfCode.Day14
{
    public class Reindeer
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int ActiveTime { get; set; }
        public int RestingTime { get; set; }

        public int TraveledDistance { get; private set; } = 0;

        private void TravelOneRound()
        {
            TravelFor(ActiveTime);
        }

        private void TravelFor(int time)
        {
            TraveledDistance += Speed * time;
        }


        public Reindeer(string name, int speed, int activeTime, int restingTime)
        {
            Name = name;
            Speed = speed;
            ActiveTime = activeTime;
            RestingTime = restingTime;
        }

        public void AdvanceBy(int seconds)
        {
            int rounds = seconds / (ActiveTime + RestingTime);
            TraveledDistance = rounds * (Speed * ActiveTime);


            int remainder = seconds % (ActiveTime + RestingTime);
            int remainderActiveTime = Math.Min(remainder, ActiveTime);
            TraveledDistance += remainderActiveTime * Speed;
        }
    }
}
