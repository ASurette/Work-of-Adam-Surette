using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab3
{
    public partial class Form1 : Form
    {

        public ArrayList coordinates = new ArrayList();

        int numDots = 0;//this will be how many dots there are

        public Form1()
        {

            InitializeComponent();
             
            this.Text = "Lab 3 Adam Surette";
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const int WIDTH = 20;
            const int HEIGHT = 20;
            Graphics g = e.Graphics;          

            foreach (My_Dot d in this.coordinates)
            {
                if (d.col == false)
                {

                    g.FillEllipse(Brushes.Black, d.coord_x - WIDTH / 2, d.coord_y - WIDTH / 2, WIDTH, HEIGHT);
                    

                }
                if(d.col == true)
                {

                    g.FillEllipse(Brushes.Red, d.coord_x - WIDTH / 2, d.coord_y - WIDTH / 2, WIDTH, HEIGHT);
                    
                }
            }
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//making a new dot
            {
                My_Dot d = new My_Dot(e.X, e.Y);

                this.coordinates.Add(d);

                numDots++;

                this.Invalidate();

            }
            if (e.Button == MouseButtons.Right)//changing the color of the dot or removing it
            {
                
                for (int i = numDots-1; i >= 0; i--)
                {
                    
                   My_Dot d = (My_Dot)coordinates[i];

                    if(((d.coord_x >= (e.X-10)) && (d.coord_x <= (e.X + 10))) && ((d.coord_y >= (e.Y - 10)) && (d.coord_y <= (e.Y + 10))))//this if statement determines if the mouseclick is inside a circle
                    {                       
                       
                        if (d.col == false)//if it is black make it red
                        {

                            d.col = true;

                        }
                        else if (d.col == true)//if it is red remove the dot
                        {

                            //there is a known issue where if you make a dot red than immediately try to erase it it does not work, however if you wait a moment it will erase with the correct number of clicks

                            this.coordinates.RemoveAt(i);

                            numDots--;
                         
                        }

                    }
                   
                }

                this.Invalidate();

            }

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            numDots = 0;
            this.Invalidate();
        }

    }

    public class My_Dot//the class for My_Dot so that I could add a color
    {
        public int coord_x;//this is for coordinate for x

        public int coord_y;//this is for y coordinate

        public bool col;//0 will be black, 1 will be red

        public My_Dot(int x, int y)
        {
            coord_x = x;

            coord_y = y;

            col = false;

        }

    }

}
