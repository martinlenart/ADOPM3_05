using System;
using System.Collections.Generic;
using System.Linq;

namespace Example7_05
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

            //Nest Where and OrderBy using Linq fluent syntax
            IEnumerable<Rectangle> list = originalList.Where(r => r.Height > 15).OrderBy(r => r.Area);
            list.ToList().ForEach(r => Console.WriteLine(r.Area)); // 675, 10000, 11250

            // Lets simply Reverse the order
            list.Reverse()
                .ToList().ForEach(r => Console.WriteLine(r.Area)); // this line is only for printout: 11250, 10000, 675

            // Lets Take the first 2 elements in the reversed list
            list.Reverse().Take(2)
                .ToList().ForEach(r => Console.WriteLine(r.Area)); // 11250, 10000

            // Lets Skip the first of the two taken elements
            list.Reverse().Take(2).Skip(1)
                .ToList().ForEach(r => Console.WriteLine(r.Area)); // 10000
        }
    }
}
