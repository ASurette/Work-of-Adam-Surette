using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Lab6
{
    public class Line : Shape
    {

        public Line()
        {
        }

        public Line(int x, int y, int x2, int y2, int p, int b, int width)
        {//x and y are coordinates, p is the pen color, brush is the fill brush color, width is the width of the pen       
            coord_x = x;//setting the x 
            coord_y = y;//setting the y

            coord_x2 = x2;
            coord_y2 = y2;

            pC = p;//pen color
            fC = b;//fill color
            w = width;//pen width
           
        }

        public override void DrawShape(Graphics g)
        {
            //changing the pen to the correct color
            if      (pC == 0) { p.Color = Color.Black; }
            else if (pC == 1) { p.Color = Color.Red;   }
            else if (pC == 2) { p.Color = Color.Blue;  }
            else if (pC == 3) { p.Color = Color.Green; }

            p.Width = w;//changing the width

            Point p1 = new Point(coord_x, coord_y);

            Point p2 = new Point(coord_x2, coord_y2);

            g.DrawLine(p, p1, p2);

        }

    }
}
