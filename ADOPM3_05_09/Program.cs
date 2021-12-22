using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_05_09
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

            //OrderByDescending an ThenBy
            originalList.OrderByDescending(r => r.Area).ThenBy(r => r.Color)
                        .ToList().ForEach(r => Console.WriteLine(r));

            
            //Play around with GroupBy            
            Console.WriteLine();
            var groupedList = originalList.GroupBy(r => r.Color, r => r); //groupedList is IEnumerable<IGrouping<RectColor, Rectangle>>
            
            //Print it out
            groupedList.ToList().ForEach(r => r.ToList().ForEach(r=>Console.WriteLine(r)));

            
            //Make an explicit iteration over the Group to illustrate 
            Console.WriteLine();
            foreach (IGrouping<RectColor, Rectangle> colorGroups in groupedList)
            {
                // Print the key value of the IGrouping.
                Console.WriteLine(colorGroups.Key);
                colorGroups.ToList().ForEach(r => Console.WriteLine(r));
            }
        }

        //Exercise:
        //1. Modify code to produce a groupedList where under each Color group the rectangles are ordered by descedning Area
    }
}
