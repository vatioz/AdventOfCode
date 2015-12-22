using System.Collections.Generic;

namespace AdventOfCode.Day03
{
    public class HouseTour
    {
        #region | Properties & fields

        private readonly Queue<Santa> _circularQueue;
        private readonly List<Position> _housesWithPresent;

        public int HousesWithPresentCount => _housesWithPresent.Count;

        #endregion

        #region | ctors

        public HouseTour()
        {
            _circularQueue = new Queue<Santa>();
            _housesWithPresent = new List<Position>();
        }

        #endregion

        #region | Public interface

        public void AddMultipleDeliveryBoys(int count)
        {
            for (var i = 0; i < count; i++)
            {
                AddDeliveryBoy();
            }
        }

        public void AddDeliveryBoy()
        {
            var santa = new Santa();
            _circularQueue.Enqueue(santa);
            LogPosition(santa);
        }

        public void DeliverNextPresent(char instruction)
        {
            var currentSanta = _circularQueue.Dequeue(); // whose turn is it now?

            currentSanta.Move(instruction);
            LogPosition(currentSanta);

            _circularQueue.Enqueue(currentSanta); // wait for your next turn
        }

        #endregion

        #region | Non-public members

        private void LogPosition(Santa santa)
        {
            if (!_housesWithPresent.Contains(santa.CurrentPosition))
                _housesWithPresent.Add(new Position(santa.CurrentPosition));
        }

        #endregion
    }
}