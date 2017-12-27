using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Lab6
{
    using System;

    public class Shape
    {
        public int coord_x;//the x position
        public int coord_y;//the y position

        public int coord_x2;
        public int coord_y2;

        public Pen p = new Pen(Color.Black, 1);

        public int pC;//the pen color uses same values as in form2's color. For example 0 is black etc
        public int fC;//the fill color, uses same values as form2's fill colors 
        public int w;//the width

        public bool fillOn;

        public bool outlineOn;

        public Shape()//default constructor
        {

        }

        public Shape(int x, int y, int x2, int y2, int p, int b, int width)//constructor we will use
        {//x and y are coordinates, p is the pen color, brush is the fill brush, width is the width of the pen        
        }

        public virtual void DrawShape(Graphics g)//will be used to draw a shape depending on what it is, will be changed in the children of this class
        {
            Console.WriteLine("You reached the default shape DrawShape");
        }

    }


}

