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

namespace Lab4
{
    public partial class Form1 : Form
    {

        public int numQueens = 0;//the number of queens currently on the board, will increment when placed and decrement when removed

        GlobalBoard GB = new GlobalBoard();//this is a class that allows me to have an array of arrays of Spaces, another class that donotes a space on the board, effectively be global

        bool hintOn = false;//this will be used to check if hints are turened on or not

        public Form1()
        {
            InitializeComponent();

            this.Text = "Eight Queens by Adam Surette";//chaning the title of the form

        }

        //-----------------------Beginning of Events-------------------------

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            String s = String.Format("You have {0} queens on the board.", numQueens);

            g.DrawString(s, Font, Brushes.Black, 190, 38);//writing the you have this number of queens on the board

            //this next section will be drawing the whole board white
            if (hintOn == false)
            {
                e.Graphics.FillRectangle(Brushes.White, 100, 100, 400, 400);
                //this next section will be drawing all the black spaces
                //row 1
                e.Graphics.FillRectangle(Brushes.Black, 150, 100, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 100, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 100, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 100, 50, 50);
                //row 2
                e.Graphics.FillRectangle(Brushes.Black, 100, 150, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 150, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 150, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 150, 50, 50);
                //row 3
                e.Graphics.FillRectangle(Brushes.Black, 150, 200, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 200, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 200, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 200, 50, 50);
                //row 4
                e.Graphics.FillRectangle(Brushes.Black, 100, 250, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 250, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 250, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 250, 50, 50);
                //row 5
                e.Graphics.FillRectangle(Brushes.Black, 150, 300, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 300, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 300, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 300, 50, 50);
                //row 6
                e.Graphics.FillRectangle(Brushes.Black, 100, 350, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 350, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 350, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 350, 50, 50);
                //row 7
                e.Graphics.FillRectangle(Brushes.Black, 150, 400, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 400, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 400, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 400, 50, 50);
                //row 8
                e.Graphics.FillRectangle(Brushes.Black, 100, 450, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 450, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 450, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 450, 50, 50);
            }
            else if (hintOn == true)
            {
                //draw the board normally then draw then red square on top
                e.Graphics.FillRectangle(Brushes.White, 100, 100, 400, 400);
                //this next section will be drawing all the black spaces
                //row 1
                e.Graphics.FillRectangle(Brushes.Black, 150, 100, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 100, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 100, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 100, 50, 50);
                //row 2
                e.Graphics.FillRectangle(Brushes.Black, 100, 150, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 150, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 150, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 150, 50, 50);
                //row 3
                e.Graphics.FillRectangle(Brushes.Black, 150, 200, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 200, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 200, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 200, 50, 50);
                //row 4
                e.Graphics.FillRectangle(Brushes.Black, 100, 250, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 250, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 250, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 250, 50, 50);
                //row 5
                e.Graphics.FillRectangle(Brushes.Black, 150, 300, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 300, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 300, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 300, 50, 50);
                //row 6
                e.Graphics.FillRectangle(Brushes.Black, 100, 350, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 350, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 350, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 350, 50, 50);
                //row 7
                e.Graphics.FillRectangle(Brushes.Black, 150, 400, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 250, 400, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 350, 400, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 450, 400, 50, 50);
                //row 8
                e.Graphics.FillRectangle(Brushes.Black, 100, 450, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 200, 450, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 300, 450, 50, 50);
                e.Graphics.FillRectangle(Brushes.Black, 400, 450, 50, 50);

                for (int i = 0; i < 8; i++)//nested for loop to loop through theBoard
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (GB.theBoard[i, j].isSafe > 0)
                        {

                            e.Graphics.FillRectangle(Brushes.Red, GB.theBoard[i, j].X, GB.theBoard[i, j].Y, 50, 50);//drwaing the red squares for an unsafe spot

                        }



                    }
                }
            }
            //this section does the black borders on the board
            Pen blackPen = new Pen(Color.Black, .01f);
            //setting uo the outlines on the board for when hints are turned on
            Rectangle boardOutline = new Rectangle(100, 100, 400, 400);//outline around the board
            //column lines
            Rectangle cOutline1 = new Rectangle(100, 150, 400, 1);
            Rectangle cOutline2 = new Rectangle(100, 200, 400, 1);
            Rectangle cOutline3 = new Rectangle(100, 250, 400, 1);
            Rectangle cOutline4 = new Rectangle(100, 300, 400, 1);
            Rectangle cOutline5 = new Rectangle(100, 350, 400, 1);
            Rectangle cOutline6 = new Rectangle(100, 400, 400, 1);
            Rectangle cOutline7 = new Rectangle(100, 450, 400, 1);
            //row lines
            Rectangle rowOutline1 = new Rectangle(150, 100, 1, 400);
            Rectangle rowOutline2 = new Rectangle(200, 100, 1, 400);
            Rectangle rowOutline3 = new Rectangle(250, 100, 1, 400);
            Rectangle rowOutline4 = new Rectangle(300, 100, 1, 400);
            Rectangle rowOutline5 = new Rectangle(350, 100, 1, 400);
            Rectangle rowOutline6 = new Rectangle(400, 100, 1, 400);
            Rectangle rowOutline7 = new Rectangle(450, 100, 1, 400);
            //drawing the outlines
            e.Graphics.DrawRectangle(blackPen, boardOutline);
            e.Graphics.DrawRectangle(blackPen, rowOutline1);
            e.Graphics.DrawRectangle(blackPen, rowOutline2);
            e.Graphics.DrawRectangle(blackPen, rowOutline3);
            e.Graphics.DrawRectangle(blackPen, rowOutline4);
            e.Graphics.DrawRectangle(blackPen, rowOutline5);
            e.Graphics.DrawRectangle(blackPen, rowOutline6);
            e.Graphics.DrawRectangle(blackPen, rowOutline7);
            e.Graphics.DrawRectangle(blackPen, cOutline1);
            e.Graphics.DrawRectangle(blackPen, cOutline2);
            e.Graphics.DrawRectangle(blackPen, cOutline3);
            e.Graphics.DrawRectangle(blackPen, cOutline4);
            e.Graphics.DrawRectangle(blackPen, cOutline5);
            e.Graphics.DrawRectangle(blackPen, cOutline6);
            e.Graphics.DrawRectangle(blackPen, cOutline7);
            //this next section is for determining where to draw the Q to represent a queen has been placed there
            Font myFont = new Font("Arial", 30, FontStyle.Bold);//the style for the Q to mark where a queen is

            for (int i = 0; i < 8; i++)//nested for loop to loop through theBoard
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GB.theBoard[i, j].getQueen() == true)
                    {
                        if (hintOn == false)
                        {
                            if (GB.theBoard[i, j].color == false)//if the square is white we need a black Q
                            {
                                e.Graphics.DrawString("Q", myFont, Brushes.Black, GB.theBoard[i, j].X + 2, GB.theBoard[i, j].Y + 2);
                            }
                            else if (GB.theBoard[i, j].color == true)//if the square is black we need a white Q
                            {
                                e.Graphics.DrawString("Q", myFont, Brushes.White, GB.theBoard[i, j].X + 2, GB.theBoard[i, j].Y + 2);
                            }
                        }
                        else
                        {
                            if (GB.theBoard[i, j].isSafe > 0)
                            {
                                e.Graphics.DrawString("Q", myFont, Brushes.Black, GB.theBoard[i, j].X + 2, GB.theBoard[i, j].Y + 2);
                            }
                            else if (GB.theBoard[i, j].color == false)//if the square is white we need a black Q
                            {
                                e.Graphics.DrawString("Q", myFont, Brushes.Black, GB.theBoard[i, j].X + 2, GB.theBoard[i, j].Y + 2);
                            }
                            else if (GB.theBoard[i, j].color == true)//if the square is black we need a white Q
                            {
                                e.Graphics.DrawString("Q", myFont, Brushes.White, GB.theBoard[i, j].X + 2, GB.theBoard[i, j].Y + 2);
                            }
                        }


                    }
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (hintOn == false)
            {
                hintOn = true;
            }
            else if (hintOn == true)
            {
                hintOn = false;
            }

            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)//nested for loop to loop through theBoard
            {
                for (int j = 0; j < 8; j++)
                {
                    GB.theBoard[i, j].setQueen(false);//remove all the queens from all spaces
                    GB.theBoard[i, j].isSafe = 0;//make all the spaces safe again
                }
            }
            numQueens = 0;//number of queens back to 0
            this.Invalidate();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//left click
            {

                //This next part is checking where on the board the player clicked and if that space can have a queen there
                //if the player clicks on a space and it is considered safe and there is not a queen there then place a queen there
                //increment the number of queens on the board and run the safety algorithm to update all the new unsafe spaces


                //I realized after I got too far into the program that this could have been done with some for loops and adding 50 to X simulate going to the next space 
                
                //row 8
                if ((e.X > 100) && (e.Y > 100) && (e.X < 150) && (e.Y < 150) && (GB.theBoard[0, 0].isSafe == 0) && (GB.theBoard[0, 0].isQueen == false)) { GB.theBoard[0, 0].setQueen(true); numQueens++; safetyAlgorithm(0, 0); }//determines if we are in A8

                else if ((e.X > 100) && (e.Y > 100) && (e.X < 150) && (e.Y < 150) && (GB.theBoard[0, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 100) && (e.X < 200) && (e.Y < 150) && (GB.theBoard[0, 1].isSafe == 0) && (GB.theBoard[0, 1].isQueen == false)) { GB.theBoard[0, 1].setQueen(true); numQueens++; safetyAlgorithm(0, 1); }//determines if we are in B8

                else if ((e.X > 150) && (e.Y > 100) && (e.X < 200) && (e.Y < 150) && (GB.theBoard[0, 1].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 100) && (e.X < 250) && (e.Y < 150) && (GB.theBoard[0, 2].isSafe == 0) && (GB.theBoard[0, 2].isQueen == false)) { GB.theBoard[0, 2].setQueen(true); numQueens++; safetyAlgorithm(0, 2); }//determines if we are in C8

                else if ((e.X > 200) && (e.Y > 100) && (e.X < 250) && (e.Y < 150) && (GB.theBoard[0, 2].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 100) && (e.X < 300) && (e.Y < 150) && (GB.theBoard[0, 3].isSafe == 0) && (GB.theBoard[0, 3].isQueen == false)) { GB.theBoard[0, 3].setQueen(true); numQueens++; safetyAlgorithm(0, 3); }//determines if we are in D8

                else if ((e.X > 250) && (e.Y > 100) && (e.X < 300) && (e.Y < 150) && (GB.theBoard[0, 3].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 100) && (e.X < 350) && (e.Y < 150) && (GB.theBoard[0, 4].isSafe == 0) && (GB.theBoard[0, 4].isQueen == false)) { GB.theBoard[0, 4].setQueen(true); numQueens++; safetyAlgorithm(0, 4); }//determines if we are in E8

                else if ((e.X > 300) && (e.Y > 100) && (e.X < 350) && (e.Y < 150) && (GB.theBoard[0, 4].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 100) && (e.X < 400) && (e.Y < 150) && (GB.theBoard[0, 5].isSafe == 0) && (GB.theBoard[0, 5].isQueen == false)) { GB.theBoard[0, 5].setQueen(true); numQueens++; safetyAlgorithm(0, 5); }//determines if we are in F8

                else if ((e.X > 350) && (e.Y > 100) && (e.X < 400) && (e.Y < 150) && (GB.theBoard[0, 5].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 100) && (e.X < 450) && (e.Y < 150) && (GB.theBoard[0, 6].isSafe == 0) && (GB.theBoard[0, 6].isQueen == false)) { GB.theBoard[0, 6].setQueen(true); numQueens++; safetyAlgorithm(0, 6); }//determines if we are in G8

                else if ((e.X > 400) && (e.Y > 100) && (e.X < 450) && (e.Y < 150) && (GB.theBoard[0, 6].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 100) && (e.X < 500) && (e.Y < 150) && (GB.theBoard[0, 7].isSafe == 0) && (GB.theBoard[0, 7].isQueen == false)) { GB.theBoard[0, 7].setQueen(true); numQueens++; safetyAlgorithm(0, 7); }//determines if we are in H8

                else if ((e.X > 450) && (e.Y > 100) && (e.X < 500) && (e.Y < 150) && (GB.theBoard[0, 7].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                //row 7
                if ((e.X > 100) && (e.Y > 150) && (e.X < 150) && (e.Y < 200) && (GB.theBoard[1, 0].isSafe == 0) && (GB.theBoard[1, 0].isQueen == false)) { GB.theBoard[1, 0].setQueen(true); numQueens++; safetyAlgorithm(1, 0); }//determines if we are in A7

                else if ((e.X > 100) && (e.Y > 150) && (e.X < 150) && (e.Y < 200) && (GB.theBoard[1, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 150) && (e.X < 200) && (e.Y < 200) && (GB.theBoard[1, 1].isSafe == 0) && (GB.theBoard[1, 1].isQueen == false)) { GB.theBoard[1, 1].setQueen(true); numQueens++; safetyAlgorithm(1, 1); }//determines if we are in B7

                else if ((e.X > 150) && (e.Y > 150) && (e.X < 200) && (e.Y < 200) && (GB.theBoard[1, 1].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 150) && (e.X < 250) && (e.Y < 200) && (GB.theBoard[1, 2].isSafe == 0) && (GB.theBoard[1, 2].isQueen == false)) { GB.theBoard[1, 2].setQueen(true); numQueens++; safetyAlgorithm(1, 2); }//determines if we are in C7

                else if ((e.X > 200) && (e.Y > 150) && (e.X < 250) && (e.Y < 200) && (GB.theBoard[1, 2].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 150) && (e.X < 300) && (e.Y < 200) && (GB.theBoard[1, 3].isSafe == 0) && (GB.theBoard[1, 3].isQueen == false)) { GB.theBoard[1, 3].setQueen(true); numQueens++; safetyAlgorithm(1, 3); }//determines if we are in D7

                else if ((e.X > 250) && (e.Y > 150) && (e.X < 300) && (e.Y < 200) && (GB.theBoard[1, 3].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 150) && (e.X < 350) && (e.Y < 200) && (GB.theBoard[1, 4].isSafe == 0) && (GB.theBoard[1, 4].isQueen == false)) { GB.theBoard[1, 4].setQueen(true); numQueens++; safetyAlgorithm(1, 4); }//determines if we are in E7

                else if ((e.X > 300) && (e.Y > 150) && (e.X < 350) && (e.Y < 200) && (GB.theBoard[1, 4].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 150) && (e.X < 400) && (e.Y < 200) && (GB.theBoard[1, 5].isSafe == 0) && (GB.theBoard[1, 5].isQueen == false)) { GB.theBoard[1, 5].setQueen(true); numQueens++; safetyAlgorithm(1, 5); }//determines if we are in F7

                else if ((e.X > 350) && (e.Y > 150) && (e.X < 400) && (e.Y < 200) && (GB.theBoard[1, 5].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 150) && (e.X < 450) && (e.Y < 200) && (GB.theBoard[1, 6].isSafe == 0) && (GB.theBoard[1, 6].isQueen == false)) { GB.theBoard[1, 6].setQueen(true); numQueens++; safetyAlgorithm(1, 6); }//determines if we are in G7

                else if ((e.X > 400) && (e.Y > 150) && (e.X < 450) && (e.Y < 200) && (GB.theBoard[1, 6].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 150) && (e.X < 500) && (e.Y < 200) && (GB.theBoard[1, 7].isSafe == 0) && (GB.theBoard[1, 7].isQueen == false)) { GB.theBoard[1, 7].setQueen(true); numQueens++; safetyAlgorithm(1, 7); }//determines if we are in H7

                else if ((e.X > 450) && (e.Y > 150) && (e.X < 500) && (e.Y < 200) && (GB.theBoard[1, 7].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }
                
                //row 6
                if ((e.X > 100) && (e.Y > 200) && (e.X < 150) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe == 0) && (GB.theBoard[2, 0].isQueen == false)) { GB.theBoard[2, 0].setQueen(true); numQueens++; safetyAlgorithm(2, 0); }//determines if we are in A6

                else if ((e.X > 100) && (e.Y > 200) && (e.X < 150) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 200) && (e.X < 200) && (e.Y < 250) && (GB.theBoard[2, 1].isSafe == 0) && (GB.theBoard[2, 1].isQueen == false)) { GB.theBoard[2, 1].setQueen(true); numQueens++; safetyAlgorithm(2, 1); }//determines if we are in B6

                else if ((e.X > 150) && (e.Y > 200) && (e.X < 200) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 200) && (e.X < 250) && (e.Y < 250) && (GB.theBoard[2, 2].isSafe == 0) && (GB.theBoard[2, 2].isQueen == false)) { GB.theBoard[2, 2].setQueen(true); numQueens++; safetyAlgorithm(2, 2); }//determines if we are in C6

                else if ((e.X > 200) && (e.Y > 200) && (e.X < 250) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 200) && (e.X < 300) && (e.Y < 250) && (GB.theBoard[2, 3].isSafe == 0) && (GB.theBoard[2, 3].isQueen == false)) { GB.theBoard[2, 3].setQueen(true); numQueens++; safetyAlgorithm(2, 3); }//determines if we are in D6

                else if ((e.X > 250) && (e.Y > 200) && (e.X < 300) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 200) && (e.X < 350) && (e.Y < 250) && (GB.theBoard[2, 4].isSafe == 0) && (GB.theBoard[2, 4].isQueen == false)) { GB.theBoard[2, 4].setQueen(true); numQueens++; safetyAlgorithm(2, 4); }//determines if we are in E6

                else if ((e.X > 300) && (e.Y > 200) && (e.X < 350) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 200) && (e.X < 400) && (e.Y < 250) && (GB.theBoard[2, 5].isSafe == 0) && (GB.theBoard[2, 5].isQueen == false)) { GB.theBoard[2, 5].setQueen(true); numQueens++; safetyAlgorithm(2, 5); }//determines if we are in F6

                else if ((e.X > 350) && (e.Y > 200) && (e.X < 400) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 200) && (e.X < 450) && (e.Y < 250) && (GB.theBoard[2, 6].isSafe == 0) && (GB.theBoard[2, 6].isQueen == false)) { GB.theBoard[2, 6].setQueen(true); numQueens++; safetyAlgorithm(2, 6); }//determines if we are in G6

                else if ((e.X > 400) && (e.Y > 200) && (e.X < 450) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 200) && (e.X < 500) && (e.Y < 250) && (GB.theBoard[2, 7].isSafe == 0) && (GB.theBoard[2, 7].isQueen == false)) { GB.theBoard[2, 7].setQueen(true); numQueens++; safetyAlgorithm(2, 7); }//determines if we are in H6

                else if ((e.X > 450) && (e.Y > 200) && (e.X < 500) && (e.Y < 250) && (GB.theBoard[2, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                //row 5
                if ((e.X > 100) && (e.Y > 250) && (e.X < 150) && (e.Y < 300) && (GB.theBoard[3, 0].isSafe == 0) && (GB.theBoard[3, 0].isQueen == false)) { GB.theBoard[3, 0].setQueen(true); numQueens++; safetyAlgorithm(3, 0); }//determines if we are in A5

                else if ((e.X > 100) && (e.Y > 250) && (e.X < 150) && (e.Y < 300) && (GB.theBoard[3, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 250) && (e.X < 200) && (e.Y < 300) && (GB.theBoard[3, 1].isSafe == 0) && (GB.theBoard[3, 1].isQueen == false)) { GB.theBoard[3, 1].setQueen(true); numQueens++; safetyAlgorithm(3, 1); }//determines if we are in B5

                else if ((e.X > 150) && (e.Y > 250) && (e.X < 200) && (e.Y < 300) && (GB.theBoard[3, 1].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 250) && (e.X < 250) && (e.Y < 300) && (GB.theBoard[3, 2].isSafe == 0) && (GB.theBoard[3, 2].isQueen == false)) { GB.theBoard[3, 2].setQueen(true); numQueens++; safetyAlgorithm(3, 2); }//determines if we are in C5

                else if ((e.X > 200) && (e.Y > 250) && (e.X < 250) && (e.Y < 300) && (GB.theBoard[3, 2].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 250) && (e.X < 300) && (e.Y < 300) && (GB.theBoard[3, 3].isSafe == 0) && (GB.theBoard[3, 3].isQueen == false)) { GB.theBoard[3, 3].setQueen(true); numQueens++; safetyAlgorithm(3, 3); }//determines if we are in D5

                else if ((e.X > 250) && (e.Y > 250) && (e.X < 300) && (e.Y < 300) && (GB.theBoard[3, 3].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 250) && (e.X < 350) && (e.Y < 300) && (GB.theBoard[3, 4].isSafe == 0) && (GB.theBoard[3, 4].isQueen == false)) { GB.theBoard[3, 4].setQueen(true); numQueens++; safetyAlgorithm(3, 4); }//determines if we are in E5

                else if ((e.X > 300) && (e.Y > 250) && (e.X < 350) && (e.Y < 300) && (GB.theBoard[3, 4].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 250) && (e.X < 400) && (e.Y < 300) && (GB.theBoard[3, 5].isSafe == 0) && (GB.theBoard[3, 5].isQueen == false)) { GB.theBoard[3, 5].setQueen(true); numQueens++; safetyAlgorithm(3, 5); }//determines if we are in F5

                else if ((e.X > 350) && (e.Y > 250) && (e.X < 400) && (e.Y < 300) && (GB.theBoard[3, 5].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 250) && (e.X < 450) && (e.Y < 300) && (GB.theBoard[3, 6].isSafe == 0) && (GB.theBoard[3, 6].isQueen == false)) { GB.theBoard[3, 6].setQueen(true); numQueens++; safetyAlgorithm(3, 6); }//determines if we are in G5

                else if ((e.X > 400) && (e.Y > 250) && (e.X < 450) && (e.Y < 300) && (GB.theBoard[3, 6].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 250) && (e.X < 500) && (e.Y < 300) && (GB.theBoard[3, 7].isSafe == 0) && (GB.theBoard[3, 7].isQueen == false)) { GB.theBoard[3, 7].setQueen(true); numQueens++; safetyAlgorithm(3, 7); }//determines if we are in H5

                else if ((e.X > 450) && (e.Y > 250) && (e.X < 500) && (e.Y < 300) && (GB.theBoard[3, 7].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                //row 4
                if ((e.X > 100) && (e.Y > 300) && (e.X < 150) && (e.Y < 350) && (GB.theBoard[4, 0].isSafe == 0) && (GB.theBoard[4, 0].isQueen == false)) { GB.theBoard[4, 0].setQueen(true); numQueens++; safetyAlgorithm(4, 0); }//determines if we are in A4

                else if ((e.X > 100) && (e.Y > 300) && (e.X < 150) && (e.Y < 350) && (GB.theBoard[4, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 300) && (e.X < 200) && (e.Y < 350) && (GB.theBoard[4, 1].isSafe == 0) && (GB.theBoard[4, 1].isQueen == false)) { GB.theBoard[4, 1].setQueen(true); numQueens++; safetyAlgorithm(4, 1); }//determines if we are in B4

                else if ((e.X > 150) && (e.Y > 300) && (e.X < 200) && (e.Y < 350) && (GB.theBoard[4, 1].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 300) && (e.X < 250) && (e.Y < 350) && (GB.theBoard[4, 2].isSafe == 0) && (GB.theBoard[4, 2].isQueen == false)) { GB.theBoard[4, 2].setQueen(true); numQueens++; safetyAlgorithm(4, 2); }//determines if we are in C4

                else if ((e.X > 200) && (e.Y > 300) && (e.X < 250) && (e.Y < 350) && (GB.theBoard[4, 2].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 300) && (e.X < 300) && (e.Y < 350) && (GB.theBoard[4, 3].isSafe == 0) && (GB.theBoard[4, 3].isQueen == false)) { GB.theBoard[4, 3].setQueen(true); numQueens++; safetyAlgorithm(4, 3); }//determines if we are in D4

                else if ((e.X > 250) && (e.Y > 300) && (e.X < 300) && (e.Y < 350) && (GB.theBoard[4, 3].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 300) && (e.X < 350) && (e.Y < 350) && (GB.theBoard[4, 4].isSafe == 0) && (GB.theBoard[4, 4].isQueen == false)) { GB.theBoard[4, 4].setQueen(true); numQueens++; safetyAlgorithm(4, 4); }//determines if we are in E4

                else if ((e.X > 300) && (e.Y > 300) && (e.X < 350) && (e.Y < 350) && (GB.theBoard[4, 4].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 300) && (e.X < 400) && (e.Y < 350) && (GB.theBoard[4, 5].isSafe == 0) && (GB.theBoard[4, 5].isQueen == false)) { GB.theBoard[4, 5].setQueen(true); numQueens++; safetyAlgorithm(4, 5); }//determines if we are in F4

                else if ((e.X > 350) && (e.Y > 300) && (e.X < 400) && (e.Y < 350) && (GB.theBoard[4, 5].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 300) && (e.X < 450) && (e.Y < 350) && (GB.theBoard[4, 6].isSafe == 0) && (GB.theBoard[4, 6].isQueen == false)) { GB.theBoard[4, 6].setQueen(true); numQueens++; safetyAlgorithm(4, 6); }//determines if we are in G4

                else if ((e.X > 400) && (e.Y > 300) && (e.X < 450) && (e.Y < 350) && (GB.theBoard[4, 6].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 300) && (e.X < 500) && (e.Y < 350) && (GB.theBoard[4, 7].isSafe == 0) && (GB.theBoard[4, 7].isQueen == false)) { GB.theBoard[4, 7].setQueen(true); numQueens++; safetyAlgorithm(4, 7); }//determines if we are in H4

                else if ((e.X > 450) && (e.Y > 300) && (e.X < 500) && (e.Y < 350) && (GB.theBoard[4, 7].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                //row 3
                if ((e.X > 100) && (e.Y > 350) && (e.X < 150) && (e.Y < 400) && (GB.theBoard[5, 0].isSafe == 0) && (GB.theBoard[5, 0].isQueen == false)) { GB.theBoard[5, 0].setQueen(true); numQueens++; safetyAlgorithm(5, 0); }//determines if we are in A3

                else if ((e.X > 100) && (e.Y > 350) && (e.X < 150) && (e.Y < 400) && (GB.theBoard[5, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 350) && (e.X < 200) && (e.Y < 400) && (GB.theBoard[5, 1].isSafe == 0) && (GB.theBoard[5, 1].isQueen == false)) { GB.theBoard[5, 1].setQueen(true); numQueens++; safetyAlgorithm(5, 1); }//determines if we are in B3

                else if ((e.X > 150) && (e.Y > 350) && (e.X < 200) && (e.Y < 400) && (GB.theBoard[5, 1].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 350) && (e.X < 250) && (e.Y < 400) && (GB.theBoard[5, 2].isSafe == 0) && (GB.theBoard[5, 2].isQueen == false)) { GB.theBoard[5, 2].setQueen(true); numQueens++; safetyAlgorithm(5, 2); }//determines if we are in C3

                else if ((e.X > 200) && (e.Y > 350) && (e.X < 250) && (e.Y < 400) && (GB.theBoard[5, 2].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 350) && (e.X < 300) && (e.Y < 400) && (GB.theBoard[5, 3].isSafe == 0) && (GB.theBoard[5, 3].isQueen == false)) { GB.theBoard[5, 3].setQueen(true); numQueens++; safetyAlgorithm(5, 3); }//determines if we are in D3

                else if ((e.X > 250) && (e.Y > 350) && (e.X < 300) && (e.Y < 400) && (GB.theBoard[5, 3].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 350) && (e.X < 350) && (e.Y < 400) && (GB.theBoard[5, 4].isSafe == 0) && (GB.theBoard[5, 4].isQueen == false)) { GB.theBoard[5, 4].setQueen(true); numQueens++; safetyAlgorithm(5, 4); }//determines if we are in E3

                else if ((e.X > 300) && (e.Y > 350) && (e.X < 350) && (e.Y < 400) && (GB.theBoard[5, 4].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 350) && (e.X < 400) && (e.Y < 400) && (GB.theBoard[5, 5].isSafe == 0) && (GB.theBoard[5, 5].isQueen == false)) { GB.theBoard[5, 5].setQueen(true); numQueens++; safetyAlgorithm(5, 5); }//determines if we are in F3

                else if ((e.X > 350) && (e.Y > 350) && (e.X < 400) && (e.Y < 400) && (GB.theBoard[5, 5].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 350) && (e.X < 450) && (e.Y < 400) && (GB.theBoard[5, 6].isSafe == 0) && (GB.theBoard[5, 6].isQueen == false)) { GB.theBoard[5, 6].setQueen(true); numQueens++; safetyAlgorithm(5, 6); }//determines if we are in G3

                else if ((e.X > 400) && (e.Y > 350) && (e.X < 450) && (e.Y < 400) && (GB.theBoard[5, 6].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 350) && (e.X < 500) && (e.Y < 400) && (GB.theBoard[5, 7].isSafe == 0) && (GB.theBoard[5, 7].isQueen == false)) { GB.theBoard[5, 7].setQueen(true); numQueens++; safetyAlgorithm(5, 7); }//determines if we are in H3

                else if ((e.X > 450) && (e.Y > 350) && (e.X < 500) && (e.Y < 400) && (GB.theBoard[5, 7].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                //row 2
                if ((e.X > 100) && (e.Y > 400) && (e.X < 150) && (e.Y < 450) && (GB.theBoard[6, 0].isSafe == 0) && (GB.theBoard[6, 0].isQueen == false)) { GB.theBoard[6, 0].setQueen(true); numQueens++; safetyAlgorithm(6, 0); }//determines if we are in A2

                else if ((e.X > 100) && (e.Y > 400) && (e.X < 150) && (e.Y < 450) && (GB.theBoard[6, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 400) && (e.X < 200) && (e.Y < 450) && (GB.theBoard[6, 1].isSafe == 0) && (GB.theBoard[6, 1].isQueen == false)) { GB.theBoard[6, 1].setQueen(true); numQueens++; safetyAlgorithm(6, 1); }//determines if we are in B2

                else if ((e.X > 150) && (e.Y > 400) && (e.X < 200) && (e.Y < 450) && (GB.theBoard[6, 1].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 400) && (e.X < 250) && (e.Y < 450) && (GB.theBoard[6, 2].isSafe == 0) && (GB.theBoard[6, 2].isQueen == false)) { GB.theBoard[6, 2].setQueen(true); numQueens++; safetyAlgorithm(6, 2); }//determines if we are in C2

                else if ((e.X > 200) && (e.Y > 400) && (e.X < 250) && (e.Y < 450) && (GB.theBoard[6, 2].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 400) && (e.X < 300) && (e.Y < 450) && (GB.theBoard[6, 3].isSafe == 0) && (GB.theBoard[6, 3].isQueen == false)) { GB.theBoard[6, 3].setQueen(true); numQueens++; safetyAlgorithm(6, 3); }//determines if we are in D2

                else if ((e.X > 250) && (e.Y > 400) && (e.X < 300) && (e.Y < 450) && (GB.theBoard[6, 3].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 400) && (e.X < 350) && (e.Y < 450) && (GB.theBoard[6, 4].isSafe == 0) && (GB.theBoard[6, 4].isQueen == false)) { GB.theBoard[6, 4].setQueen(true); numQueens++; safetyAlgorithm(6, 4); }//determines if we are in E2

                else if ((e.X > 300) && (e.Y > 400) && (e.X < 350) && (e.Y < 450) && (GB.theBoard[6, 4].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 400) && (e.X < 400) && (e.Y < 450) && (GB.theBoard[6, 5].isSafe == 0) && (GB.theBoard[6, 5].isQueen == false)) { GB.theBoard[6, 5].setQueen(true); numQueens++; safetyAlgorithm(6, 5); }//determines if we are in F2

                else if ((e.X > 350) && (e.Y > 400) && (e.X < 400) && (e.Y < 450) && (GB.theBoard[6, 5].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 400) && (e.X < 450) && (e.Y < 450) && (GB.theBoard[6, 6].isSafe == 0) && (GB.theBoard[6, 6].isQueen == false)) { GB.theBoard[6, 6].setQueen(true); numQueens++; safetyAlgorithm(6, 6); }//determines if we are in G2

                else if ((e.X > 400) && (e.Y > 400) && (e.X < 450) && (e.Y < 450) && (GB.theBoard[6, 6].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 400) && (e.X < 500) && (e.Y < 450) && (GB.theBoard[6, 7].isSafe == 0) && (GB.theBoard[6, 7].isQueen == false)) { GB.theBoard[6, 7].setQueen(true); numQueens++; safetyAlgorithm(6, 7); }//determines if we are in H2

                else if ((e.X > 450) && (e.Y > 400) && (e.X < 500) && (e.Y < 450) && (GB.theBoard[6, 7].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                //row 1
                if ((e.X > 100) && (e.Y > 450) && (e.X < 150) && (e.Y < 500) && (GB.theBoard[7, 0].isSafe == 0) && (GB.theBoard[7, 0].isQueen == false)) { GB.theBoard[7, 0].setQueen(true); numQueens++; safetyAlgorithm(7, 0); }//determines if we are in A1

                else if ((e.X > 100) && (e.Y > 450) && (e.X < 150) && (e.Y < 500) && (GB.theBoard[7, 0].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 150) && (e.Y > 450) && (e.X < 200) && (e.Y < 500) && (GB.theBoard[7, 1].isSafe == 0) && (GB.theBoard[7, 1].isQueen == false)) { GB.theBoard[7, 1].setQueen(true); numQueens++; safetyAlgorithm(7, 1); }//determines if we are in B1

                else if ((e.X > 150) && (e.Y > 450) && (e.X < 200) && (e.Y < 500) && (GB.theBoard[7, 1].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 200) && (e.Y > 450) && (e.X < 250) && (e.Y < 500) && (GB.theBoard[7, 2].isSafe == 0) && (GB.theBoard[7, 2].isQueen == false)) { GB.theBoard[7, 2].setQueen(true); numQueens++; safetyAlgorithm(7, 2); }//determines if we are in C1

                else if ((e.X > 200) && (e.Y > 450) && (e.X < 250) && (e.Y < 500) && (GB.theBoard[7, 2].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 250) && (e.Y > 450) && (e.X < 300) && (e.Y < 500) && (GB.theBoard[7, 3].isSafe == 0) && (GB.theBoard[7, 3].isQueen == false)) { GB.theBoard[7, 3].setQueen(true); numQueens++; safetyAlgorithm(7, 3); }//determines if we are in D1

                else if ((e.X > 250) && (e.Y > 450) && (e.X < 300) && (e.Y < 500) && (GB.theBoard[7, 3].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 300) && (e.Y > 450) && (e.X < 350) && (e.Y < 500) && (GB.theBoard[7, 4].isSafe == 0) && (GB.theBoard[7, 4].isQueen == false)) { GB.theBoard[7, 4].setQueen(true); numQueens++; safetyAlgorithm(7, 4); }//determines if we are in E1

                else if ((e.X > 300) && (e.Y > 450) && (e.X < 350) && (e.Y < 500) && (GB.theBoard[7, 4].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 350) && (e.Y > 450) && (e.X < 400) && (e.Y < 500) && (GB.theBoard[7, 5].isSafe == 0) && (GB.theBoard[7, 5].isQueen == false)) { GB.theBoard[7, 5].setQueen(true); numQueens++; safetyAlgorithm(7, 5); }//determines if we are in F1

                else if ((e.X > 350) && (e.Y > 450) && (e.X < 400) && (e.Y < 500) && (GB.theBoard[7, 5].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 400) && (e.Y > 450) && (e.X < 450) && (e.Y < 500) && (GB.theBoard[7, 6].isSafe == 0) && (GB.theBoard[7, 6].isQueen == false)) { GB.theBoard[7, 6].setQueen(true); numQueens++; safetyAlgorithm(7, 6); }//determines if we are in G1

                else if ((e.X > 400) && (e.Y > 450) && (e.X < 450) && (e.Y < 500) && (GB.theBoard[7, 6].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                if ((e.X > 450) && (e.Y > 450) && (e.X < 500) && (e.Y < 500) && (GB.theBoard[7, 7].isSafe == 0) && (GB.theBoard[7, 7].isQueen == false)) { GB.theBoard[7, 7].setQueen(true); numQueens++; safetyAlgorithm(7, 7); }//determines if we are in H1

                else if ((e.X > 450) && (e.Y > 450) && (e.X < 500) && (e.Y < 500) && (GB.theBoard[7, 7].isSafe > 0)) { System.Media.SystemSounds.Beep.Play(); }

                this.Invalidate();

                if (numQueens == 8)
                {

                    MessageBox.Show("Congraulations, you solved the puzzle!");

                }

            }

            if (e.Button == MouseButtons.Right)//right click
            {
                //I realized a little late that each of these blocks could have just been a for loop that incremetns e.X by 50 each time and increases the row
                //actually probably could have been a nested for loop that does all of them
                //row 8
                if ((e.X > 100) && (e.Y > 100) && (e.X < 150) && (e.Y < 150) && (GB.theBoard[0, 0].isQueen == true)) { GB.theBoard[0, 0].setQueen(false); numQueens--; unsafetyAlgorithm(0, 0); }//determines if we are in A8
                if ((e.X > 150) && (e.Y > 100) && (e.X < 200) && (e.Y < 150) && (GB.theBoard[0, 1].isQueen == true)) { GB.theBoard[0, 1].setQueen(false); numQueens--; unsafetyAlgorithm(0, 1); }//determines if we are in B8
                if ((e.X > 200) && (e.Y > 100) && (e.X < 250) && (e.Y < 150) && (GB.theBoard[0, 2].isQueen == true)) { GB.theBoard[0, 2].setQueen(false); numQueens--; unsafetyAlgorithm(0, 2); }//determines if we are in C8
                if ((e.X > 250) && (e.Y > 100) && (e.X < 300) && (e.Y < 150) && (GB.theBoard[0, 3].isQueen == true)) { GB.theBoard[0, 3].setQueen(false); numQueens--; unsafetyAlgorithm(0, 3); }//determines if we are in D8
                if ((e.X > 300) && (e.Y > 100) && (e.X < 350) && (e.Y < 150) && (GB.theBoard[0, 4].isQueen == true)) { GB.theBoard[0, 4].setQueen(false); numQueens--; unsafetyAlgorithm(0, 4); }//determines if we are in E8
                if ((e.X > 350) && (e.Y > 100) && (e.X < 400) && (e.Y < 150) && (GB.theBoard[0, 5].isQueen == true)) { GB.theBoard[0, 5].setQueen(false); numQueens--; unsafetyAlgorithm(0, 5); }//determines if we are in F8
                if ((e.X > 400) && (e.Y > 100) && (e.X < 450) && (e.Y < 150) && (GB.theBoard[0, 6].isQueen == true)) { GB.theBoard[0, 6].setQueen(false); numQueens--; unsafetyAlgorithm(0, 6); }//determines if we are in G8
                if ((e.X > 450) && (e.Y > 100) && (e.X < 500) && (e.Y < 150) && (GB.theBoard[0, 7].isQueen == true)) { GB.theBoard[0, 7].setQueen(false); numQueens--; unsafetyAlgorithm(0, 7); }//determines if we are in H8

                //row 7
                if ((e.X > 100) && (e.Y > 150) && (e.X < 150) && (e.Y < 200) && (GB.theBoard[1, 0].isQueen == true)) { GB.theBoard[1, 0].setQueen(false); numQueens--; unsafetyAlgorithm(1, 0); }//determines if we are in A7
                if ((e.X > 150) && (e.Y > 150) && (e.X < 200) && (e.Y < 200) && (GB.theBoard[1, 1].isQueen == true)) { GB.theBoard[1, 1].setQueen(false); numQueens--; unsafetyAlgorithm(1, 1); }//determines if we are in B7
                if ((e.X > 200) && (e.Y > 150) && (e.X < 250) && (e.Y < 200) && (GB.theBoard[1, 2].isQueen == true)) { GB.theBoard[1, 2].setQueen(false); numQueens--; unsafetyAlgorithm(1, 2); }//determines if we are in C7
                if ((e.X > 250) && (e.Y > 150) && (e.X < 300) && (e.Y < 200) && (GB.theBoard[1, 3].isQueen == true)) { GB.theBoard[1, 3].setQueen(false); numQueens--; unsafetyAlgorithm(1, 3); }//determines if we are in D7
                if ((e.X > 300) && (e.Y > 150) && (e.X < 350) && (e.Y < 200) && (GB.theBoard[1, 4].isQueen == true)) { GB.theBoard[1, 4].setQueen(false); numQueens--; unsafetyAlgorithm(1, 4); }//determines if we are in E7
                if ((e.X > 350) && (e.Y > 150) && (e.X < 400) && (e.Y < 200) && (GB.theBoard[1, 5].isQueen == true)) { GB.theBoard[1, 5].setQueen(false); numQueens--; unsafetyAlgorithm(1, 5); }//determines if we are in F7
                if ((e.X > 400) && (e.Y > 150) && (e.X < 450) && (e.Y < 200) && (GB.theBoard[1, 6].isQueen == true)) { GB.theBoard[1, 6].setQueen(false); numQueens--; unsafetyAlgorithm(1, 6); }//determines if we are in G7
                if ((e.X > 450) && (e.Y > 150) && (e.X < 500) && (e.Y < 200) && (GB.theBoard[1, 7].isQueen == true)) { GB.theBoard[1, 7].setQueen(false); numQueens--; unsafetyAlgorithm(1, 7); }//determines if we are in H7

                //row 6
                if ((e.X > 100) && (e.Y > 200) && (e.X < 150) && (e.Y < 250) && (GB.theBoard[2, 0].isQueen == true)) { GB.theBoard[2, 0].setQueen(false); numQueens--; unsafetyAlgorithm(2, 0); }//determines if we are in A6
                if ((e.X > 150) && (e.Y > 200) && (e.X < 200) && (e.Y < 250) && (GB.theBoard[2, 1].isQueen == true)) { GB.theBoard[2, 1].setQueen(false); numQueens--; unsafetyAlgorithm(2, 1); }//determines if we are in B6
                if ((e.X > 200) && (e.Y > 200) && (e.X < 250) && (e.Y < 250) && (GB.theBoard[2, 2].isQueen == true)) { GB.theBoard[2, 2].setQueen(false); numQueens--; unsafetyAlgorithm(2, 2); }//determines if we are in C6
                if ((e.X > 250) && (e.Y > 200) && (e.X < 300) && (e.Y < 250) && (GB.theBoard[2, 3].isQueen == true)) { GB.theBoard[2, 3].setQueen(false); numQueens--; unsafetyAlgorithm(2, 3); }//determines if we are in D6
                if ((e.X > 300) && (e.Y > 200) && (e.X < 350) && (e.Y < 250) && (GB.theBoard[2, 4].isQueen == true)) { GB.theBoard[2, 4].setQueen(false); numQueens--; unsafetyAlgorithm(2, 4); }//determines if we are in E6
                if ((e.X > 350) && (e.Y > 200) && (e.X < 450) && (e.Y < 250) && (GB.theBoard[2, 5].isQueen == true)) { GB.theBoard[2, 5].setQueen(false); numQueens--; unsafetyAlgorithm(2, 5); }//determines if we are in F6
                if ((e.X > 400) && (e.Y > 200) && (e.X < 450) && (e.Y < 250) && (GB.theBoard[2, 6].isQueen == true)) { GB.theBoard[2, 6].setQueen(false); numQueens--; unsafetyAlgorithm(2, 6); }//determines if we are in G6
                if ((e.X > 450) && (e.Y > 200) && (e.X < 500) && (e.Y < 250) && (GB.theBoard[2, 7].isQueen == true)) { GB.theBoard[2, 7].setQueen(false); numQueens--; unsafetyAlgorithm(2, 7); }//determines if we are in H6

                //row 5
                if ((e.X > 100) && (e.Y > 200) && (e.X < 150) && (e.Y < 250) && (GB.theBoard[2, 0].isQueen == true)) { GB.theBoard[2, 0].setQueen(false); numQueens--; unsafetyAlgorithm(3, 0); }//determines if we are in A6
                if ((e.X > 150) && (e.Y > 200) && (e.X < 200) && (e.Y < 250) && (GB.theBoard[2, 1].isQueen == true)) { GB.theBoard[2, 1].setQueen(false); numQueens--; unsafetyAlgorithm(3, 1); }//determines if we are in B6
                if ((e.X > 200) && (e.Y > 200) && (e.X < 250) && (e.Y < 250) && (GB.theBoard[2, 2].isQueen == true)) { GB.theBoard[2, 2].setQueen(false); numQueens--; unsafetyAlgorithm(3, 2); }//determines if we are in C6
                if ((e.X > 250) && (e.Y > 200) && (e.X < 300) && (e.Y < 250) && (GB.theBoard[2, 3].isQueen == true)) { GB.theBoard[2, 3].setQueen(false); numQueens--; unsafetyAlgorithm(3, 3); }//determines if we are in D6
                if ((e.X > 300) && (e.Y > 200) && (e.X < 350) && (e.Y < 250) && (GB.theBoard[2, 4].isQueen == true)) { GB.theBoard[2, 4].setQueen(false); numQueens--; unsafetyAlgorithm(3, 4); }//determines if we are in E6
                if ((e.X > 350) && (e.Y > 200) && (e.X < 450) && (e.Y < 250) && (GB.theBoard[2, 5].isQueen == true)) { GB.theBoard[2, 5].setQueen(false); numQueens--; unsafetyAlgorithm(3, 5); }//determines if we are in F6
                if ((e.X > 400) && (e.Y > 200) && (e.X < 450) && (e.Y < 250) && (GB.theBoard[2, 6].isQueen == true)) { GB.theBoard[2, 6].setQueen(false); numQueens--; unsafetyAlgorithm(3, 6); }//determines if we are in G6
                if ((e.X > 450) && (e.Y > 200) && (e.X < 500) && (e.Y < 250) && (GB.theBoard[2, 7].isQueen == true)) { GB.theBoard[2, 7].setQueen(false); numQueens--; unsafetyAlgorithm(3, 7); }//determines if we are in H6

                //row 4
                if ((e.X > 100) && (e.Y > 300) && (e.X < 150) && (e.Y < 350) && (GB.theBoard[4, 0].isQueen == true)) { GB.theBoard[4, 0].setQueen(false); numQueens--; unsafetyAlgorithm(4, 0); }//determines if we are in A4
                if ((e.X > 150) && (e.Y > 300) && (e.X < 200) && (e.Y < 350) && (GB.theBoard[4, 1].isQueen == true)) { GB.theBoard[4, 1].setQueen(false); numQueens--; unsafetyAlgorithm(4, 1); }//determines if we are in B4
                if ((e.X > 200) && (e.Y > 300) && (e.X < 250) && (e.Y < 350) && (GB.theBoard[4, 2].isQueen == true)) { GB.theBoard[4, 2].setQueen(false); numQueens--; unsafetyAlgorithm(4, 2); }//determines if we are in C4
                if ((e.X > 250) && (e.Y > 300) && (e.X < 300) && (e.Y < 350) && (GB.theBoard[4, 3].isQueen == true)) { GB.theBoard[4, 3].setQueen(false); numQueens--; unsafetyAlgorithm(4, 3); }//determines if we are in D4
                if ((e.X > 300) && (e.Y > 300) && (e.X < 350) && (e.Y < 350) && (GB.theBoard[4, 4].isQueen == true)) { GB.theBoard[4, 4].setQueen(false); numQueens--; unsafetyAlgorithm(4, 4); }//determines if we are in E4
                if ((e.X > 350) && (e.Y > 300) && (e.X < 400) && (e.Y < 350) && (GB.theBoard[4, 5].isQueen == true)) { GB.theBoard[4, 5].setQueen(false); numQueens--; unsafetyAlgorithm(4, 5); }//determines if we are in F4
                if ((e.X > 400) && (e.Y > 300) && (e.X < 450) && (e.Y < 350) && (GB.theBoard[4, 6].isQueen == true)) { GB.theBoard[4, 6].setQueen(false); numQueens--; unsafetyAlgorithm(4, 6); }//determines if we are in G4
                if ((e.X > 450) && (e.Y > 300) && (e.X < 500) && (e.Y < 350) && (GB.theBoard[4, 7].isQueen == true)) { GB.theBoard[4, 7].setQueen(false); numQueens--; unsafetyAlgorithm(4, 7); }//determines if we are in H4

                //row 3
                if ((e.X > 100) && (e.Y > 350) && (e.X < 150) && (e.Y < 400) && (GB.theBoard[5, 0].isQueen == true)) { GB.theBoard[5, 0].setQueen(false); numQueens--; unsafetyAlgorithm(5, 0); }//determines if we are in A3
                if ((e.X > 150) && (e.Y > 350) && (e.X < 200) && (e.Y < 400) && (GB.theBoard[5, 1].isQueen == true)) { GB.theBoard[5, 1].setQueen(false); numQueens--; unsafetyAlgorithm(5, 1); }//determines if we are in B3
                if ((e.X > 200) && (e.Y > 350) && (e.X < 250) && (e.Y < 400) && (GB.theBoard[5, 2].isQueen == true)) { GB.theBoard[5, 2].setQueen(false); numQueens--; unsafetyAlgorithm(5, 2); }//determines if we are in C3
                if ((e.X > 250) && (e.Y > 350) && (e.X < 300) && (e.Y < 400) && (GB.theBoard[5, 3].isQueen == true)) { GB.theBoard[5, 3].setQueen(false); numQueens--; unsafetyAlgorithm(5, 3); }//determines if we are in D3
                if ((e.X > 300) && (e.Y > 350) && (e.X < 350) && (e.Y < 400) && (GB.theBoard[5, 4].isQueen == true)) { GB.theBoard[5, 4].setQueen(false); numQueens--; unsafetyAlgorithm(5, 4); }//determines if we are in E3
                if ((e.X > 350) && (e.Y > 350) && (e.X < 400) && (e.Y < 400) && (GB.theBoard[5, 5].isQueen == true)) { GB.theBoard[5, 5].setQueen(false); numQueens--; unsafetyAlgorithm(5, 5); }//determines if we are in F3
                if ((e.X > 400) && (e.Y > 350) && (e.X < 450) && (e.Y < 400) && (GB.theBoard[5, 6].isQueen == true)) { GB.theBoard[5, 6].setQueen(false); numQueens--; unsafetyAlgorithm(5, 6); }//determines if we are in G3
                if ((e.X > 450) && (e.Y > 350) && (e.X < 500) && (e.Y < 400) && (GB.theBoard[5, 7].isQueen == true)) { GB.theBoard[5, 7].setQueen(false); numQueens--; unsafetyAlgorithm(5, 7); }//determines if we are in H3

                //row 2
                if ((e.X > 100) && (e.Y > 400) && (e.X < 150) && (e.Y < 450) && (GB.theBoard[6, 0].isQueen == true)) { GB.theBoard[6, 0].setQueen(false); numQueens--; unsafetyAlgorithm(6, 0); }//determines if we are in A2
                if ((e.X > 150) && (e.Y > 400) && (e.X < 200) && (e.Y < 450) && (GB.theBoard[6, 1].isQueen == true)) { GB.theBoard[6, 1].setQueen(false); numQueens--; unsafetyAlgorithm(6, 1); }//determines if we are in B2
                if ((e.X > 200) && (e.Y > 400) && (e.X < 250) && (e.Y < 450) && (GB.theBoard[6, 2].isQueen == true)) { GB.theBoard[6, 2].setQueen(false); numQueens--; unsafetyAlgorithm(6, 2); }//determines if we are in C2
                if ((e.X > 250) && (e.Y > 400) && (e.X < 300) && (e.Y < 450) && (GB.theBoard[6, 3].isQueen == true)) { GB.theBoard[6, 3].setQueen(false); numQueens--; unsafetyAlgorithm(6, 3); }//determines if we are in D2
                if ((e.X > 300) && (e.Y > 400) && (e.X < 350) && (e.Y < 450) && (GB.theBoard[6, 4].isQueen == true)) { GB.theBoard[6, 4].setQueen(false); numQueens--; unsafetyAlgorithm(6, 4); }//determines if we are in E2
                if ((e.X > 350) && (e.Y > 400) && (e.X < 400) && (e.Y < 450) && (GB.theBoard[6, 5].isQueen == true)) { GB.theBoard[6, 5].setQueen(false); numQueens--; unsafetyAlgorithm(6, 5); }//determines if we are in F2
                if ((e.X > 400) && (e.Y > 400) && (e.X < 450) && (e.Y < 450) && (GB.theBoard[6, 6].isQueen == true)) { GB.theBoard[6, 6].setQueen(false); numQueens--; unsafetyAlgorithm(6, 6); }//determines if we are in G2
                if ((e.X > 450) && (e.Y > 400) && (e.X < 500) && (e.Y < 450) && (GB.theBoard[6, 7].isQueen == true)) { GB.theBoard[6, 7].setQueen(false); numQueens--; unsafetyAlgorithm(6, 7); }//determines if we are in H2

                //row 1
                if ((e.X > 100) && (e.Y > 450) && (e.X < 150) && (e.Y < 500) && (GB.theBoard[7, 0].isQueen == true)) { GB.theBoard[7, 0].setQueen(false); numQueens--; unsafetyAlgorithm(7, 0); }//determines if we are in A1
                if ((e.X > 150) && (e.Y > 450) && (e.X < 200) && (e.Y < 500) && (GB.theBoard[7, 1].isQueen == true)) { GB.theBoard[7, 1].setQueen(false); numQueens--; unsafetyAlgorithm(7, 1); }//determines if we are in B1
                if ((e.X > 200) && (e.Y > 450) && (e.X < 250) && (e.Y < 500) && (GB.theBoard[7, 2].isQueen == true)) { GB.theBoard[7, 2].setQueen(false); numQueens--; unsafetyAlgorithm(7, 2); }//determines if we are in C1
                if ((e.X > 250) && (e.Y > 450) && (e.X < 300) && (e.Y < 500) && (GB.theBoard[7, 3].isQueen == true)) { GB.theBoard[7, 3].setQueen(false); numQueens--; unsafetyAlgorithm(7, 3); }//determines if we are in D1
                if ((e.X > 300) && (e.Y > 450) && (e.X < 350) && (e.Y < 500) && (GB.theBoard[7, 4].isQueen == true)) { GB.theBoard[7, 4].setQueen(false); numQueens--; unsafetyAlgorithm(7, 4); }//determines if we are in E1
                if ((e.X > 350) && (e.Y > 450) && (e.X < 400) && (e.Y < 500) && (GB.theBoard[7, 5].isQueen == true)) { GB.theBoard[7, 5].setQueen(false); numQueens--; unsafetyAlgorithm(7, 5); }//determines if we are in F1
                if ((e.X > 400) && (e.Y > 450) && (e.X < 450) && (e.Y < 500) && (GB.theBoard[7, 6].isQueen == true)) { GB.theBoard[7, 6].setQueen(false); numQueens--; unsafetyAlgorithm(7, 6); }//determines if we are in G1
                if ((e.X > 450) && (e.Y > 450) && (e.X < 500) && (e.Y < 500) && (GB.theBoard[7, 7].isQueen == true)) { GB.theBoard[7, 7].setQueen(false); numQueens--; unsafetyAlgorithm(7, 7); }//determines if we are in H1


                this.Invalidate();
            }
        }

        //--------------------------------------------End of Events-------------------------------------------------



        //--------------------------------------------Safety Algorithm--------------------------------------------
        void safetyAlgorithm(int x, int y)//this will be called after a click event to check what squares are safe
        {
            //these copies are so I can change the value of x and y without changing the initial value
            //the phase allows me to get out of while loops
            //I have 8 while loops that each represent an axis or diagonal from a space, once it reaches the edge of that particular axis or diagonal it stops and goes to the next
            int copyX = x;
            int copyY = y;
            bool phase = true;       //probably could have just used break

            while (phase == true)//the positive x axis
            {
                GB.theBoard[copyX, y].isSafe++;

                if (copyX == 7)
                {
                    phase = false;
                }

                copyX++;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the negative x axis
            {
                GB.theBoard[copyX, y].isSafe++;

                if (copyX == 0)
                {
                    phase = false;
                }

                copyX--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the positive x axis
            {
                GB.theBoard[x, copyY].isSafe++;

                if (copyY == 7)
                {
                    phase = false;
                }

                copyY++;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the positive x axis
            {
                GB.theBoard[x, copyY].isSafe++;

                if (copyY == 0)
                {
                    phase = false;
                }

                copyY--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the up left diagonal
            {
                GB.theBoard[copyX, copyY].isSafe++;

                if ((copyY == 0) || (copyX == 0))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX--;
                copyY--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the bottom left diagonal
            {
                GB.theBoard[copyX, copyY].isSafe++;

                if ((copyY == 0) || (copyX == 7))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX++;
                copyY--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the bottom left diagonal
            {
                GB.theBoard[copyX, copyY].isSafe++;

                if ((copyY == 7) || (copyX == 0))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX--;
                copyY++;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the bottom right diagonal
            {
                GB.theBoard[copyX, copyY].isSafe++;

                if ((copyY == 7) || (copyX == 7))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX++;
                copyY++;

            }

            GB.theBoard[x, y].isSafe = 1;//setting the space where the queen was placed as unsafe

        }

        void unsafetyAlgorithm(int x, int y)//this will be called after a right click event to check what squares need their isSafe decremented
        {
            //these copies are so I can change the value of x and y without changing the initial value
            //the phase allows me to get out of while loops
            //I have 8 while loops that each represent an axis or diagonal from a space, once it reaches the edge of that particular axis or diagonal it stops and goes to the next
            int copyX = x;
            int copyY = y;
            bool phase = true;       //probably could have just used break

            while (phase == true)//the positive x axis
            {
                GB.theBoard[copyX, y].isSafe--;

                if (copyX == 7)
                {
                    phase = false;
                }

                copyX++;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the negative x axis
            {
                GB.theBoard[copyX, y].isSafe--;

                if (copyX == 0)
                {
                    phase = false;
                }

                copyX--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the positive x axis
            {
                GB.theBoard[x, copyY].isSafe--;

                if (copyY == 7)
                {
                    phase = false;
                }

                copyY++;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the positive x axis
            {
                GB.theBoard[x, copyY].isSafe--;

                if (copyY == 0)
                {
                    phase = false;
                }

                copyY--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the up left diagonal
            {
                GB.theBoard[copyX, copyY].isSafe--;

                if ((copyY == 0) || (copyX == 0))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX--;
                copyY--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the bottom left diagonal
            {
                GB.theBoard[copyX, copyY].isSafe--;

                if ((copyY == 0) || (copyX == 7))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX++;
                copyY--;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the bottom left diagonal
            {
                GB.theBoard[copyX, copyY].isSafe--;

                if ((copyY == 7) || (copyX == 0))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX--;
                copyY++;

            }

            copyX = x;
            copyY = y;
            phase = true;

            while (phase == true)//the bottom right diagonal
            {
                GB.theBoard[copyX, copyY].isSafe--;

                if ((copyY == 7) || (copyX == 7))//check if you hit either boundary
                {
                    phase = false;
                }

                copyX++;
                copyY++;

            }

            GB.theBoard[x, y].isSafe = 0;//reseting the space where the queen was placed

        }

    }
}




//-----------------------------------------Classes----------------------------------------------------------
//----------------------------------------------------------------------------------------------------------
public class Space//this is the class I am using to save information about each square
{
    public int isSafe;//this is an int so that I can see how many queens are attacking that space. That way if I remove a queen I can just decrement the isSafe value.

    public bool isQueen;//this is be true if there is already a queen there

    public int X;//coordinates

    public int Y;//coordiantes

    public bool color;//false is white true is black

    public Space(int x, int y, bool bw)
    {
        X = x;

        Y = y;

        isSafe = 0;

        isQueen = false;

        color = bw;
    }

    public void setQueen(bool x)//setter for isQueen
    {
        this.isQueen = x;
    }

    public bool getQueen()//getter for isQueen
    {
        return isQueen;
    }

}

public class GlobalBoard//this class allows me to make what is essentially a global variable for theBoard, it sets up and array of arrays of class Space
{
    //-----------This segment is setting up and array of arrays of my class Space so that I can check if there is a queen or if the space is unsafe
    //row8
    public static Space A8 = new Space(100, 100, false);
    public static Space B8 = new Space(150, 100, true);
    public static Space C8 = new Space(200, 100, false);
    public static Space D8 = new Space(250, 100, true);
    public static Space E8 = new Space(300, 100, false);
    public static Space F8 = new Space(350, 100, true);
    public static Space G8 = new Space(400, 100, false);
    public static Space H8 = new Space(450, 100, true);

    //row7
    public static Space A7 = new Space(100, 150, true);
    public static Space B7 = new Space(150, 150, false);
    public static Space C7 = new Space(200, 150, true);
    public static Space D7 = new Space(250, 150, false);
    public static Space E7 = new Space(300, 150, true);
    public static Space F7 = new Space(350, 150, false);
    public static Space G7 = new Space(400, 150, true);
    public static Space H7 = new Space(450, 150, false);

    //row6
    public static Space A6 = new Space(100, 200, false);
    public static Space B6 = new Space(150, 200, true);
    public static Space C6 = new Space(200, 200, false);
    public static Space D6 = new Space(250, 200, true);
    public static Space E6 = new Space(300, 200, false);
    public static Space F6 = new Space(350, 200, true);
    public static Space G6 = new Space(400, 200, false);
    public static Space H6 = new Space(450, 200, true);

    //row5
    public static Space A5 = new Space(100, 250, true);
    public static Space B5 = new Space(150, 250, false);
    public static Space C5 = new Space(200, 250, true);
    public static Space D5 = new Space(250, 250, false);
    public static Space E5 = new Space(300, 250, true);
    public static Space F5 = new Space(350, 250, false);
    public static Space G5 = new Space(400, 250, true);
    public static Space H5 = new Space(450, 250, false);

    //row4
    public static Space A4 = new Space(100, 300, false);
    public static Space B4 = new Space(150, 300, true);
    public static Space C4 = new Space(200, 300, false);
    public static Space D4 = new Space(250, 300, true);
    public static Space E4 = new Space(300, 300, false);
    public static Space F4 = new Space(350, 300, true);
    public static Space G4 = new Space(400, 300, false);
    public static Space H4 = new Space(450, 300, true);

    //row3
    public static Space A3 = new Space(100, 350, true);
    public static Space B3 = new Space(150, 350, false);
    public static Space C3 = new Space(200, 350, true);
    public static Space D3 = new Space(250, 350, false);
    public static Space E3 = new Space(300, 350, true);
    public static Space F3 = new Space(350, 350, false);
    public static Space G3 = new Space(400, 350, true);
    public static Space H3 = new Space(450, 350, false);

    //row2
    public static Space A2 = new Space(100, 400, false);
    public static Space B2 = new Space(150, 400, true);
    public static Space C2 = new Space(200, 400, false);
    public static Space D2 = new Space(250, 400, true);
    public static Space E2 = new Space(300, 400, false);
    public static Space F2 = new Space(350, 400, true);
    public static Space G2 = new Space(400, 400, false);
    public static Space H2 = new Space(450, 400, true);

    //row1
    public static Space A1 = new Space(100, 450, true);
    public static Space B1 = new Space(150, 450, false);
    public static Space C1 = new Space(200, 450, true);
    public static Space D1 = new Space(250, 450, false);
    public static Space E1 = new Space(300, 450, true);
    public static Space F1 = new Space(350, 450, false);
    public static Space G1 = new Space(400, 450, true);
    public static Space H1 = new Space(450, 450, false);

    public Space[,] theBoard = new Space[8, 8]; //multidimensional array


    public GlobalBoard()
    {

        // theBoard = new Space[8,8] { row8, row7, row6, row5, row4, row3, row2, row1 };//they are ordered this way so that the board is orientated like the player is playing white in a normal game
        theBoard[0, 0] = A8; theBoard[0, 1] = B8; theBoard[0, 2] = C8; theBoard[0, 3] = D8; theBoard[0, 4] = E8; theBoard[0, 5] = F8; theBoard[0, 6] = G8; theBoard[0, 7] = H8;
        theBoard[1, 0] = A7; theBoard[1, 1] = B7; theBoard[1, 2] = C7; theBoard[1, 3] = D7; theBoard[1, 4] = E7; theBoard[1, 5] = F7; theBoard[1, 6] = G7; theBoard[1, 7] = H7;
        theBoard[2, 0] = A6; theBoard[2, 1] = B6; theBoard[2, 2] = C6; theBoard[2, 3] = D6; theBoard[2, 4] = E6; theBoard[2, 5] = F6; theBoard[2, 6] = G6; theBoard[2, 7] = H6;
        theBoard[3, 0] = A5; theBoard[3, 1] = B5; theBoard[3, 2] = C5; theBoard[3, 3] = D5; theBoard[3, 4] = E5; theBoard[3, 5] = F5; theBoard[3, 6] = G5; theBoard[3, 7] = H5;
        theBoard[4, 0] = A4; theBoard[4, 1] = B4; theBoard[4, 2] = C4; theBoard[4, 3] = D4; theBoard[4, 4] = E4; theBoard[4, 5] = F4; theBoard[4, 6] = G4; theBoard[4, 7] = H4;
        theBoard[5, 0] = A3; theBoard[5, 1] = B3; theBoard[5, 2] = C3; theBoard[5, 3] = D3; theBoard[5, 4] = E3; theBoard[5, 5] = F3; theBoard[5, 6] = G3; theBoard[5, 7] = H3;
        theBoard[6, 0] = A2; theBoard[6, 1] = B2; theBoard[6, 2] = C2; theBoard[6, 3] = D2; theBoard[6, 4] = E2; theBoard[6, 5] = F2; theBoard[6, 6] = G2; theBoard[6, 7] = H2;
        theBoard[7, 0] = A1; theBoard[7, 1] = B1; theBoard[7, 2] = C1; theBoard[7, 3] = D1; theBoard[7, 4] = E1; theBoard[7, 5] = F1; theBoard[7, 6] = G1; theBoard[7, 7] = H1;

    }

}



