using System;
using System.Collections.Generic;
using System.Linq;

namespace ADOPM3_05_08
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
        public class AlertMessage
        {
            public RectColor Color { get; set; }
            public string Message { get; set; }
        }

        public class CombinedElement
        {
            public Rectangle rect { get; set; }
            public AlertMessage alert { get; set; }
        }

        static void Main(string[] args)
        {
            var originalList = new List<Rectangle>() {
                new Rectangle() { Color = RectColor.yellow, Height = 100, Width = 100 },
                new Rectangle() { Color = RectColor.white, Height = 15, Width = 200 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle() { Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle() { Color = RectColor.pink, Height = 75, Width = 150 },
                new Rectangle() { Color = RectColor.blue, Height = 10, Width = 20 }};

            var messageList = new List<AlertMessage>() {
                new AlertMessage() { Color = RectColor.red, Message = "A Message for all the Red Rectangles" },
                new AlertMessage() { Color = RectColor.blue, Message = "A Message for all the Blue Rectangles" },
                new AlertMessage() { Color = RectColor.yellow, Message = "A Message for all the Yellow Rectangles" },
                new AlertMessage() { Color = RectColor.white, Message = "A Message for all the White Rectangles" },
                new AlertMessage() { Color = RectColor.pink, Message = "A Message for all the Pink Rectangles" }};

            //Use Join to list all rectangles with Message added according to Color
            Console.WriteLine("Join");
            var myAnoList = originalList.Join(messageList, r => r.Color, m => m.Color, (r, m) => new { Color = r.Color, Area = r.Area, Message = m.Message });
            myAnoList.ToList().ForEach( e => Console.WriteLine($"Color: {e.Color}  Area: {e.Area}  Message: {e.Message}"));

            //Use Join to create a new list of CombinedElement
            Console.WriteLine();
            var myList = originalList.Join(messageList, r => r.Color, m => m.Color, (r, m) => new CombinedElement { rect=r, alert=m });
            myList.ToList().ForEach(e => Console.WriteLine($"Color: {e.rect.Color}  Message: {e.alert.Message}"));


            //return only rectangles whith a matching position of true in selectList
            var selectList = new bool[] { false, true, true, false, false, true, true };
            Console.WriteLine("\nZip");
            originalList.Zip(selectList, (r, b) =>
            {
                if (b) return r;
                return null;
            }).Where(r => r is not null)
              .ToList().ForEach(e => Console.WriteLine($"Color: {e.Color}  Area: {e.Area}"));
                        //white, red, pink, blue
            


        }

        //Exercise:
        //1.    Modify the code so the message will only be for rectangles of each color over a certain size, e.g. 
        //      "A message for all the large Red Rectangles" and so on for each color
        //2.    What happens if you remove the Where operator in the Zip example?
    }
}
