using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Lab6
{
    public class Ellipse : Shape
    {
        public Ellipse()
        {



        }

        public Ellipse(int x, int y, int x2, int y2, int p, int b, int width, bool fO, bool oO)
        {//x and y are coordinates, p is the pen color, brush is the fill brush color, width is the width of the pen, fo is if fill is on, oO is if outline is on        
            coord_x = x;//setting the x 
            coord_y = y;//setting the y

            coord_x2 = x2;
            coord_y2 = y2;

            pC = p;//pen color
            fC = b;//fill color
            w = width;//pen width

            fillOn = fO;
            outlineOn = oO;
        }

        public override void DrawShape(Graphics g)
        {
            int wid = Math.Abs(coord_x2 - coord_x);//this is the width of the rectangle

            int height = Math.Abs(coord_y2 - coord_y);//this is the height of the rectangle

            Rectangle r = new Rectangle(Math.Min(coord_x, coord_x2), Math.Min(coord_y, coord_y2), wid, height);//use the lower of x and y because that will be the top left corner of the rectangle

            if ((fillOn == false) && (outlineOn == false))
            {
                MessageBox.Show("Fill and or outline must be checked");
            }
            else
            {
                p.Width = w;

                if (fillOn == true)
                {
                    SolidBrush brush = new SolidBrush(Color.White);

                    if (fC == 0)      { brush.Color = Color.White; g.FillEllipse(brush, r); }
                    else if (fC == 1) { brush.Color = Color.Black; g.FillEllipse(brush, r); }
                    else if (fC == 2) { brush.Color = Color.Red;   g.FillEllipse(brush, r); }
                    else if (fC == 3) { brush.Color = Color.Blue;  g.FillEllipse(brush, r); }
                    else if (fC == 4) { brush.Color = Color.Green; g.FillEllipse(brush, r); }
                }
                if (outlineOn == true)
                {
                    if      (pC == 0) { p.Color = Color.Black; }
                    else if (pC == 1) { p.Color = Color.Red; }
                    else if (pC == 2) { p.Color = Color.Blue; }
                    else if (pC == 3) { p.Color = Color.Green; }

                    g.DrawEllipse(p, r);
                }
            }
        }
    }
}
