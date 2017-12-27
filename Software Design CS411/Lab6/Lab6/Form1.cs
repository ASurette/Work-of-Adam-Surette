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


namespace Lab6
{
    public partial class Form1 : Form
    {
        int shapeChosen;//0 will be a line, 1 will be a rectangle, 2 will be an ellipse, the radio buttons set this value
        int coord_x;//the position of the mouse in the drawsing panel, x axis
        int coord_y;//the position of the mouse in the drawing panel, y axis

        //saving where the mouse was for clicking
        int x;
        int y;
        int x2;
        int y2;

        bool state;//false will be first mouse click, true will be for second

        //the default settings value, these will be passed into the settings form
        //these will be set upon hitting the okay button in form2
        public static int penColor = 0;//0 is black, 1 is red, 2 is blue, 3 is green
        public static int fillColor = 0;//0 is white, 1 is black, 2 is red, 3 is blue, 4 is green
        public static int penWidth = 1;
        public static bool fillOn = false;
        public static bool outlineOn = true;

        Pen p = new Pen(Color.Black, 1);//making the default pen, this is what will be changed in settings

        List<Shape> list = new List<Shape>();//this is the list that all of the drawn shapes will be on      

        public Form1()
        {
            InitializeComponent();

            this.Text = "Lab 6 by Adam Surette";
        }

        //this group of radio buttons determines what class is added to the array list
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            shapeChosen = 0;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            shapeChosen = 1;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            shapeChosen = 2;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {         

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            this.BackColor = Color.Gray;

            Pen whitePen = new Pen(Color.White, .01f);

            Rectangle rect = new Rectangle(46, 59, 218, 105);

            e.Graphics.DrawRectangle(whitePen, rect);

            g.FillRectangle(Brushes.Gray, 54, 59, 30, 10);

            e.Graphics.DrawString("Draw", Font, Brushes.Black, 53, 53);
        }

        private void button1_Click(object sender, EventArgs e)//the settings button that is next to the radio buttons
        {
            Form2 form2 = new Form2(penColor, fillColor, penWidth, fillOn, outlineOn);//the settings form, has the 5 variables that can be changed as inputs so that you can remmeber the last used values

            form2.Show();//brings up form2, the settings form         

        }

        private void panel2_Paint(object sender, PaintEventArgs e)//paint event for the drawing board
        {
            Graphics g = e.Graphics;

            if (list.Count > 0)
            {

                foreach (Shape h in list)
                {

                    h.DrawShape(g);

                }
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)//mouse move event for the drawing board
        {

            coord_x = e.X;

            coord_y = e.Y;           

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)//this is the clear command
        {
            //will delete all of the shapes in the array list
            list.Clear();
            panel2.Invalidate();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//this is the exit command
        {
            Close();//closes the program
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)//the undo command
        {
            
            if(list.Count > 0)
            {
                list.RemoveAt(list.Count - 1);//rmoves the last thing on the list
            }
            panel2.Invalidate();

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)//click event for the drawing panel
        {

            if (state == false)
            {
                x = coord_x;
                
                y = coord_y;

                state = true;//we are now on the second click

            }
            else if (state == true)
            {
                x2 = coord_x;

                y2 = coord_y;

                //making the correct shape and adding it to the arraylist
                Console.WriteLine(penWidth);

                if (shapeChosen == 0)//is a line
                {
                    Line line = new Line(x, y, x2, y2, penColor, fillColor, penWidth);

                    list.Add(line);                   

                }
                else if (shapeChosen == 1)//is a rectangle
                {
                    Rect rect = new Rect(x, y, x2, y2, penColor, fillColor, penWidth, fillOn, outlineOn);

                    list.Add(rect);
                }
                else if (shapeChosen == 2)//is an ellpise
                {
                    Ellipse ellipse = new Ellipse(x, y, x2, y2, penColor, fillColor, penWidth, fillOn, outlineOn);

                    list.Add(ellipse);
                }

                state = false;// go back to a first click
            }

            panel2.Invalidate();
        }

    }
}
