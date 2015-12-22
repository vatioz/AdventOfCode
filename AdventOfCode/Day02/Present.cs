using System;

namespace AdventOfCode.Day02
{
    internal class Present
    {
        #region | Dimensions

        private int Height { get; set; }
        private int Width { get; set; }
        private int Length { get; set; }

        #endregion

        #region | Init

        public Present(string line)
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

        #endregion

        #region | Area

        public int Area => 2 * TopArea + 2 * SideArea + 2 * FrontArea;

        private int FrontArea => Height * Width;

        private int SideArea => Height * Length;

        private int TopArea => Width * Length;

        public int GetSmallestArea() => Math.Min(FrontArea, Math.Min(SideArea, TopArea));

        #endregion

        #region | Perimeter

        private int TopPerimeter => 2 * Width + 2 * Length;

        private int FrontPerimeter => 2 * Width + 2 * Height;

        private int SidePerimeter => 2 * Height + 2 * Length;

        public int GetSmallestPerimeter() => Math.Min(FrontPerimeter, Math.Min(SidePerimeter, TopPerimeter));

        #endregion

        #region | Volume

        public int Volume => Height * Width * Length;

        #endregion
    }
}