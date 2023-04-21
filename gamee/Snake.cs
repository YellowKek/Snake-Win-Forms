using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamee
{
    internal class Snake
    {
        public List<Segment> segments { get; set; }
        public string direction { get; set; }
        public int score { get; set; }
        public Snake() 
        {
            segments = new List<Segment>
            {
                new Segment(100, 100),
                new Segment(90, 100),
                new Segment(80, 100),
            };
            direction = "Right";
            score = 0;
        }
        public void addSegment()
        {
            Segment last = segments.Last();
            segments.Add(new Segment(last.x - 10, last.y - 10));
        }

        private void moveSeg()
        {
            Segment segment = new Segment(segments[0].x, segments[0].y);
            for (int i = 1; i < segments.Count; i++)
            {
                Segment segment1 = new Segment(segments[i].x, segments[i].y);
                segments[i].x = segment.x;
                segments[i].y = segment.y;
                segment.x = segment1.x;
                segment.y = segment1.y;
            }
        }

        public bool appleCheck(int[] apple)
        {
            Rectangle rect1 = new Rectangle(segments[0].x, segments[0].y, 10, 10);
            Rectangle rect2 = new Rectangle(apple[0], apple[1], 10, 10);
            return rect1.IntersectsWith(rect2);
        }
        public void move()
        {
            switch (direction)
            {
                case "Right":
                    moveSeg();
                    segments[0].x += 10;
                    break;
                case "Left":
                    moveSeg();
                    segments[0].x -= 10;
                    break;
                case "Up":
                    moveSeg();
                    segments[0].y -= 10;
                    break;
                case "Down":
                    moveSeg();
                    segments[0].y += 10;
                    break;
            }
        }
        public bool checkDeath()
        {
            if (segments.Skip(1).Any(segment => segment.x == segments[0].x && segment.y == segments[0].y) ||
                (segments[0].x >= 440 || segments[0].x <= 0) || (segments[0].y >= 280 || segments[0].y <= 0))
                return true;
            return false;
        }

    }
}