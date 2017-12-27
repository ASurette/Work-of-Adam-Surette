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

namespace Lab5
{
    public partial class Palindromes : Form
    {

        string startingNum;//the starting number the user inputs

        int numPalin = 0;//the number of palindromes wanted

        ArrayList list = new ArrayList();

        int count = 0;

        bool turnOff;//turns off a while loop after the correct number of palindromes have been hit

        bool errChk1 = false;//a bool for error checking. This determines if we display the error message or not. False will be everything is fine, true will be that something isn't correct

        bool errChk2 = false;//second one for the second textbox, need this second one so that you don't overwrite a true with a false if the 2nd box you change has a valid input

        public Palindromes()
        {
            InitializeComponent();

            this.Text = "Palindromes by Adam Surette";

        }

        private void Palindromes_Load(object sender, EventArgs e)
        {

        }

        private void Palindromes_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            e.Graphics.DrawString("Enter a Starting Interger (0-1,000,000,000):", Font, Brushes.Black, 122, 106);

            e.Graphics.DrawString("Enter count (1-100):", Font, Brushes.Black, 485, 106);            

            string errorCheck;
            
            if((errChk1 == true) || (errChk2 == true))//something isn't right if one of these is set to true
            {
            
                errorCheck = "Please enter a positive interger within range";
            
            }
            else//everything is fine
            {

                errorCheck = "";//makes the message blank

            }
            
            e.Graphics.DrawString(errorCheck, Font, Brushes.Black, 280, 350);

            Font myFont = new Font("Calibri", 30, FontStyle.Bold);

            e.Graphics.DrawString("Find Numeric Palindromes", myFont, Brushes.Black, 125, 25);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//this text box is for the 1-10000000
        {

            int num;

            if (Int32.TryParse((textBox1.Text), out num) == true)//if you successfully turned it into an int
            {

                int y = Convert.ToInt32(textBox1.Text);//used to make the next line easier to read

                if ( (y > -1) && (y < 1000000001))
                {

                    startingNum = textBox1.Text;

                    errChk1 = false;

                }
                else
                {          

                    errChk1 = true;   

                }

            }
            else
            {

                errChk1 = true;

            }       

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//this text box is for 1-100
        {
            int num;

            if(Int32.TryParse(( textBox2.Text), out num ) == true)//if you sucessfully turned it to an int
                {
                int a = Convert.ToInt32(textBox2.Text);

                    if ( (a > 0) && (a < 101))
                         {

                            numPalin = a;

                            errChk2 = false;//set the error check value to false in case they fixed it

                         }
                    else
                         {

                            errChk2 = true;//it is wrong    

                         }

                }
            else
                {

                    errChk2 = true;

                }

           
        }

        private void button1_Click(object sender, EventArgs e)//the generate button
        {
            if ((errChk1 == false) && (errChk2 == false))//if both textboxes hve valid inputs
            {

                string currentNum = startingNum;//sets the current number to the starting number

                listBox1.Items.Clear();//clear all the items in the box so that you don't just add them to the previous palindromes

                list.Clear();

                turnOff = false;//reseting turnOff

                count = 0;//resetting the counter that tracks how many palindromes have been addedto the list

                while (turnOff == false)//a while loop that ends when the number of palindromes in the arrayList is the same as the number wanted
                {

                    int length = currentNum.Length;//finds the length of the current number

                    double halfLength = (((double)length) / 2);//getting hlaf the length so I know where to stop looping through the string

                    int hLength = (int)halfLength;//interger version of half length

                    int ceilHalfLength = (int)(Math.Ceiling(halfLength));//same thing except for the odd case

                    if ((length % 2) == 0)//if the length is even
                    {
                        for (int i = 0; i < hLength; i++)
                        {
                            if (currentNum[i] == currentNum[length - 1 - i])//if the two values are the same it could still be a palindrome so continue
                            {
                                if ((length - 1 - i) - i == 1)//if the difference between these two values is one then they have met in the middle and all the values are the same
                                {

                                    list.Add(currentNum);//it is a valid palindrome add it to the list

                                    count++;

                                    if (count == numPalin)
                                    {
                                        turnOff = true;
                                    }

                                }

                            }
                            else//if they are not then they aren't a palindrome, leave the loop
                            {
                                break;
                            }
                        }
                    }
                    else//the length is odd
                    {
                        for (int i = 0; i < ceilHalfLength; i++)
                        {
                            if (currentNum[i] == currentNum[length - 1 - i])//if the two values are the same it could still be a palindrome so continue
                            {
                                if ((length - 1 - i) - i == 0)//if the difference between these two values is one then they have met in the middle and all the values are the same
                                {

                                    list.Add(currentNum);//it is a valid palindrome add it to the list

                                    count++;

                                    if (count == numPalin)
                                    {
                                        turnOff = true;
                                    }
                                }

                            }
                            else//if they are not then they aren't a palindrome, leave the loop
                            {
                                break;
                            }
                        }
                    }

                    int a = Convert.ToInt32(currentNum);//convert the current number we are working on from a string to an int so i can increment

                    a++;//increment the current number

                    currentNum = Convert.ToString(a);//convert a back to a string and set currentNum to that value
                }

                foreach (string x in list)
                {

                    listBox1.Items.Add(x);

                }

                list.Clear();//get rid of all the elements in the array list or else you just put all the same palindromes back

            }

            this.Invalidate();
                
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
