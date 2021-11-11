using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_05_02
{
    class Program
    {
        public enum RectColor
        {
            red, blue, yellow, white, pink
        }
        public class Rectangle : IEquatable<Rectangle>
        {
            public RectColor Color { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public int Area => Height * Width;
            public bool Equals(Rectangle other) => (Height, Width, Color) == (other.Height, other.Width, other.Color);
            public override int GetHashCode() => (Width, Height, Color).GetHashCode();  //Needed to implement as part of IEquatable
            public override bool Equals(object obj) => Equals(obj as Rectangle); //Needed to implement as part of IEquatable
        }
        static void Main(string[] args)
        {
            List<Rectangle> originalList = new List<Rectangle>() {
                new Rectangle() { Color = RectColor.yellow, Height = 100, Width = 100 },
                new Rectangle() { Color = RectColor.white, Height = 15, Width = 200 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.pink, Height = 75, Width = 150 },
                new Rectangle() { Color = RectColor.blue, Height = 10, Width = 20 }};

            //Fist lets call Linq method directly
            IEnumerable<Rectangle> pinkList = System.Linq.Enumerable.Where(originalList, r => r.Color == RectColor.pink);
            pinkList.ToList().ForEach(r => Console.WriteLine(r.Color)); // pink, pink

            //Do the same using extension method an Linq fluent syntax
            IEnumerable<Rectangle> whiteList = originalList.Where(r => r.Color == RectColor.white);
            whiteList.ToList().ForEach(r => Console.WriteLine(r.Color)); // white

            //Yet do the same using Linq Query syntax
            IEnumerable<Rectangle> redList = from r in originalList where r.Color == RectColor.red select r;
            redList.ToList().ForEach(r => Console.WriteLine(r.Color)); // red, red
        }
    }
}
