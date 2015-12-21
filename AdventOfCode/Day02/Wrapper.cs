using System;

namespace AdventOfCode.Day02
{
    internal class Wrapper
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public Wrapper(string line)
        {
            var dimmensions = line.Split(new[] { 'x' });
            var height = int.Parse(dimmensions[0]);
            var width = int.Parse(dimmensions[1]);
            var length = int.Parse(dimmensions[2]);
            Initialize(height, width, length);
        }

        private void Initialize(int height, int width, int length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public int Area
        {
            get { return TopArea + SideArea + FrontArea; }
        }

        public int FrontArea
        {
            get { return 2 * Height * Width; }
        }

        public int SideArea
        {
            get { return 2 * Height * Length; }

        }

        public int TopArea
        {
            get { return 2 * Width * Length; }
        }

        public int SmallestArea
        {
            get { return Math.Min(FrontArea, Math.Min(SideArea, TopArea)) / 2; }
        }

        public int TopPerimeter
        {
            get
            {
                return 2 * Width + 2 * Length;

            }
        }

        public int FrontPerimeter
        {
            get
            {
                return 2 * Width + 2 * Height;

            }
        }
        public int SidePerimeter
        {
            get
            {
                return 2 * Height + 2 * Length;

            }
        }
        public int SmallestPerimeter
        {
            get
            {
                return Math.Min(FrontPerimeter, Math.Min(SidePerimeter, TopPerimeter));

            }
        }

        public int Volume
        {
            get { return Height * Width * Length; }
        }


    }
}