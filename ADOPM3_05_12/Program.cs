using System;
using System.Collections.Generic;
using System.Linq;

namespace Example7_12
{
    class Program
    {
        public enum RectColor
        {
            red, blue, yellow, white, pink, orange, green
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
            public override string ToString() => $"Color: {Color}  Height: {Height}  Width: {Width}  Area: {Area}";
        }
        static void Main(string[] args)
        {
            var originalList = new List<Rectangle>() {
                new Rectangle() { Color = RectColor.yellow, Height = 100, Width = 100 },
                new Rectangle() { Color = RectColor.white, Height = 15, Width = 200 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.red, Height = 55, Width = 95 },
                new Rectangle() { Color = RectColor.pink, Height = 75, Width = 150 },
                new Rectangle() { Color = RectColor.orange, Height = 75, Width = 40 },
                new Rectangle() { Color = RectColor.green, Height = 30, Width = 15 },
                new Rectangle() { Color = RectColor.orange, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 }};

            //First and Last
            Console.WriteLine(originalList.First()); // yellow
            Console.WriteLine(originalList.Last()); // red

            //Single
            Console.WriteLine(originalList.Single(r => r.Color == RectColor.green)); // green
            //Console.WriteLine(originalList.Single(r => r.Color == RectColor.red)); // Exception

            // Sum and Count
            Console.WriteLine(originalList.Count); // 10
            Console.WriteLine(originalList.Sum(r => r.Area)); // 34675  (total Area)

            // All and Any
            Console.WriteLine(originalList.All(r => r.Color == RectColor.pink)); // False (Not all rectangles are Pink)
            Console.WriteLine(originalList.All(r => r.Area > 100)); // True
            Console.WriteLine(originalList.Any(r => r.Color == RectColor.pink)); // True (There is a pink rectangle)
            Console.WriteLine(originalList.Any(r => r.Area < 100)); // False
        }

        //Exercise:
        //1. Remove GetHashCode from Rectangle. What happens? Why?
    }
}
