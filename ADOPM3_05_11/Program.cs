using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_05_11
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
            Console.WriteLine(originalList.Sum(r=> r.Area)); // 34675  (total Area)

            // All and Any
            Console.WriteLine(originalList.All(r => r.Color == RectColor.pink)); // False (Not all rectangles are Pink)
            Console.WriteLine(originalList.All(r => r.Area > 100)); // True
            Console.WriteLine(originalList.Any(r => r.Color == RectColor.pink)); // True (There is a pink rectangle)
            Console.WriteLine(originalList.Any(r => r.Area < 100)); // False

            // Range
            // Generate a sequence of integers from 1 to 10
            // and then select their squares.
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            foreach (int num in squares)
            {
                Console.WriteLine(num); //1, 4, 9, ...81, 100
            }
        }
    }
    //Excercise
    //1.    Use Range and Select to create an IEnumerable<(int, string)> with a message for each number. Printout the last five elements  
    //2.    Create your own class type and implement IEquatable<> and when needed EqualityComparer<T> and Comparer<T>. Create various
    //      Generic collections of your type and populate them. Use various Linq Operators on your collection to sort, filter, order,
    //      select etc. In particular use the Linq operators where I have not provided example for.
    //3.    Play around with Join, GroupBy and Zip, they are the most complicated Linq operators. 

}

