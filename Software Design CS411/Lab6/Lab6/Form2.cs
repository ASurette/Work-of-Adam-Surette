using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form2 : Form
    {
        //ints that are used to determine the selected values,
        public int penColor;//0 is black, 1 is red, 2 is blue, 3 is green
        public int fillColor;//0 is white, 1 is black, 2 is red, 3 is blue, 4 is green
        public int penWidth;
        public bool fillOn = false;
        public bool outlineOn = true;

        //these are dummy values, the real values we will be using are the ones above.
        //these are what the values are set to and then the real values are set to these upon hitting the okay button
        //if they hit the close button or the X these will be forgotten and nothing changed.
        private int penColorT;//0 is black, 1 is red, 2 is blue, 3 is green
        private int fillColorT;//0 is white, 1 is black, 2 is red, 3 is blue, 4 is green
        private int penWidthT;
        private bool fillOnT;
        private bool outlineOnT;

        public Form2(int pC, int fC, int pW, bool fO, bool oO)//pen color, fill color, pen width, fill on, outline on
        {
            InitializeComponent();
            //adding the items for list box 1
            listBox1.Items.Add("Black");
            listBox1.Items.Add("Red");
            listBox1.Items.Add("Blue");
            listBox1.Items.Add("Green");

            //adding the items for listbox 2
            listBox2.Items.Add("White");
            listBox2.Items.Add("Black");
            listBox2.Items.Add("Red");
            listBox2.Items.Add("Blue");
            listBox2.Items.Add("Green");

            //adding the numbers for listbox3
            listBox3.Items.Add("1");
            listBox3.Items.Add("2");
            listBox3.Items.Add("3");
            listBox3.Items.Add("4");
            listBox3.Items.Add("5");
            listBox3.Items.Add("6");
            listBox3.Items.Add("7");
            listBox3.Items.Add("8");
            listBox3.Items.Add("9");
            listBox3.Items.Add("10");

            //the default settings of opening the program or the last used settings depending on if they have been changed
            penColor  = pC;
            fillColor = fC;
            penWidth  = pW;
            fillOn    = fO;
            outlineOn = oO;

            //the dummy variables also need to be set to the last used values or else you would always use the default values of unchanged settings
            penColorT  = pC;
            fillColorT = fC;
            penWidthT  = pW;
            fillOnT    = fO;
            outlineOnT = oO;

            //setting up the selected values but also making it so it remembers what to select upon calling settings again
            listBox1.SetSelected(pC, true);
            listBox2.SetSelected(fC, true);
            listBox3.SetSelected(pW-1, true);
            checkBox1.Checked = fO;
            checkBox2.Checked = oO;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//list box for pen color
        {
            string curItem = listBox1.SelectedItem.ToString();//gets a string of which color the user selected

            if      (curItem == "Black") { penColorT = 0;}
            else if (curItem == "Red")   { penColorT = 1;}
            else if (curItem == "Blue")  { penColorT = 2;}
            else if (curItem == "Green") { penColorT = 3;}

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)//list box for fill color
        {

            string curItem = listBox2.SelectedItem.ToString();

            if      (curItem == "White") { fillColorT = 0; }
            else if (curItem == "Black") { fillColorT = 1; }
            else if (curItem == "Red")   { fillColorT = 2; }
            else if (curItem == "Blue")  { fillColorT = 3; }
            else if (curItem == "Green") { fillColorT = 4; }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)//list box for selecting pen width
        {

            string curItem = listBox3.SelectedItem.ToString();

            if      (curItem == "1") { penWidthT = 1; }
            else if (curItem == "2") { penWidthT = 2; }
            else if (curItem == "3") { penWidthT = 3; }
            else if (curItem == "4") { penWidthT = 4; }
            else if (curItem == "5") { penWidthT = 5; }
            else if (curItem == "6") { penWidthT = 6; }
            else if (curItem == "7") { penWidthT = 7; }
            else if (curItem == "8") { penWidthT = 8; }
            else if (curItem == "9") { penWidthT = 9; }
            else if (curItem == "10") { penWidthT = 10; }

        }

        private void button1_Click(object sender, EventArgs e)//ok button
        {//sets the actual values to the dummy variables, this will update the settings
            penColor  = penColorT;
            fillColor = fillColorT;
            penWidth  = penWidthT;
            fillOn    = fillOnT;
            outlineOn = outlineOnT;
            Close();
    }

        private void button2_Click(object sender, EventArgs e)//cancel button
        {
            Close();//closes the form
        }

       // private void checkBox1_CheckedChanged(object sender, EventArgs e)

      //  private void checkBox2_CheckedChanged(object sender, EventArgs e)

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.penColor  =  this.penColor;
            Form1.fillColor =  this.fillColor;
            Form1.penWidth  =  this.penWidth;
            Form1.fillOn    =  this.fillOn;
            Form1.outlineOn =  this.outlineOn;
            /*
            Console.WriteLine(Form1.penColor);
            Console.WriteLine(Form1.fillColor);
            Console.WriteLine(Form1.penWidth);
            Console.WriteLine(Form1.fillOn);
            Console.WriteLine(Form1.outlineOn);*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }//unused but removing it breaks the program

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)//Fill, checks when the checkbox is clicked
        {
            //if you click the check box swap these variables
            if (fillOnT == true) { fillOnT = false; }
            else if (fillOnT == false) { fillOnT = true; }

            Console.WriteLine("fillT is {0}", fillOnT);
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)//Outline, checks when the checkbox is clicked
        {
            //if you click the check box swap these variables
            if (outlineOnT == true) { outlineOnT = false; }
            else if (outlineOnT == false) { outlineOnT = true; }

            Console.WriteLine("outlineT is {0}", outlineOnT);
        }
    }
}
