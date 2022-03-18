using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_05_10
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
        public class ColorComparer : EqualityComparer<Rectangle>
        {
            public override bool Equals(Rectangle x, Rectangle y) => x.Color == y.Color;
            public override int GetHashCode(Rectangle r) => r.Color.GetHashCode();
        }

        static void Main(string[] args)
        {
            var List1 = new List<Rectangle>() {
                new Rectangle() { Color = RectColor.yellow, Height = 100, Width = 100 },
                new Rectangle() { Color = RectColor.white, Height = 15, Width = 200 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.red, Height = 55, Width = 95 } };

            var List2 = new List<Rectangle>() {
                new Rectangle() { Color = RectColor.pink, Height = 75, Width = 150 },
                new Rectangle() { Color = RectColor.orange, Height = 75, Width = 40 },
                new Rectangle() { Color = RectColor.green, Height = 30, Width = 15 },
                new Rectangle() { Color = RectColor.orange, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 }};

            //Union
            List1.Union(List2)
                        .ToList().ForEach(r => Console.WriteLine(r)); // all the rectangles

            //Intersect
            Console.WriteLine();
            List1.Intersect(List2)
                        .ToList().ForEach(r => Console.WriteLine(r)); // only red

            //Distinct
            Console.WriteLine();

            //No duplicates using IEquatable<Rectangle> to determine equality
            List1.Union(List2).Distinct()
                        .ToList().ForEach(r => Console.WriteLine(r)); // only those that are no duplicates
                                                                      //No duplicates using IEquatable<Rectangle> to determine equality

            Console.WriteLine();
            List1.Union(List2).Distinct(new ColorComparer())
                        .ToList().ForEach(r => Console.WriteLine(r)); // only one from each color
        }

        //Exercise:
        //1. Remove GetHashCode from Rectangle. What happens? Why?
    }
}

