using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamee
{
    internal class Segment
    {
        public int x { get; set; }
        public int y { get; set; }
        public Segment(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }    
    }
}
