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
        public int Score { get; private set; } = 0;

        private int currentActiveTime;
        private int currentRestingTime;

        public void AdvanceBySecond()
        {
            if (currentActiveTime > 0)
            {
                currentActiveTime--;
                TraveledDistance += Speed;
            }
            else if (currentRestingTime > 1)
            {
                currentRestingTime--;
            }
            else
            {
                currentRestingTime = RestingTime;
                currentActiveTime = ActiveTime;
            }
        }


        public Reindeer(string name, int speed, int activeTime, int restingTime)
        {
            Name = name;
            Speed = speed;
            ActiveTime = activeTime;
            currentActiveTime = activeTime;
            RestingTime = restingTime;
            currentRestingTime = restingTime;
        }

        public void AwardByPoints(int points)
        {
            Score += 1;
        }

        public void RunFor(int seconds)
        {
            int rounds = seconds / (ActiveTime + RestingTime);
            TraveledDistance = rounds * (Speed * ActiveTime);


            int remainder = seconds % (ActiveTime + RestingTime);
            int remainderActiveTime = Math.Min(remainder, ActiveTime);
            TraveledDistance += remainderActiveTime * Speed;
        }
    }
}
