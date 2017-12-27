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
using System.IO;


namespace Lab7
{
    public partial class Form1 : Form
    {
        string filePath;//this is the string that will hold the file path
        string key;//this is the key

        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab 7 by Adam Surette";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//filename textbox
        {
            filePath = textBox1.Text;//sets the filePath string to be what the use typed in
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//key textbox
        {
            key = textBox2.Text;//sets the key to be what the user typed in
        }

        private void button1_Click(object sender, EventArgs e)//encrypt button, will call the encryption/decryption algorithm
        {
            encryptionAlg(true);//the true tells the algorithm it is encrypting
        }

        private void button2_Click(object sender, EventArgs e)//decrypt button, will call the encryption/decryption algorithm
        {

            encryptionAlg(false);//the false tells the algorithm it is decrypting

        }

        private void button3_Click(object sender, EventArgs e)//filepath button
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;

                textBox1.Text = filePath;

            }

        }

        private void encryptionAlg(bool crypt)//the filepath and the key
        {

            if(File.Exists(filePath))//checks if the file exists
            {
                //if it does don't do anything
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();

                MessageBox.Show("Could not open source or destination file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               

                return;//return so we do not try and open a file that doesnt exist

            }

            if(key == null)//if they didn't enter a key
            {
                System.Media.SystemSounds.Hand.Play();

                MessageBox.Show("Please enter a key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            string filePathEnc;//make the (de/en)ncryption filepath

            if (crypt == true)//if encrypting it need to add a .enc
            {
                filePathEnc = filePath + ".enc";//this is the filepath but with the .enc, this is where we will be writing the file
            }
            else//if decrypting it need to remove the last .enc
            {
                if(filePath.Substring(Math.Max(0, filePath.Length - 4)) != ".enc")//if it isnt an enc file
                {
                    System.Media.SystemSounds.Hand.Play();

                    MessageBox.Show("Not a .enc file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;//exit the algorithm since we can't decrypt an unencrypted file

                }
                else//if it does end in .enc meaning it is an encrypted file
                {

                    filePathEnc = filePath.Remove(filePath.Length - 4);//this is the filepath but with the .enc, this is where we will be writing the file

                }
                
            }           

            byte[] file = File.ReadAllBytes(filePath);//reads all the bytes in the filepath
            int l = file.Length;//the length of the array of bytes
            byte[] fileEnc = Enumerable.Repeat((byte)0x00, l).ToArray();//setting up an array of bytes that we will overwrite with the encrypted file and then write it later, did this because I had issues with casting later on
            int keyLength = key.Length;//gives us the length of the key
            int count = 0;
            
            //loops through the file byte by byte and XOR it with the letter of the key
            for (int i = 0; i < l; i++)
            {
                fileEnc[i] = (byte)((int)file[i] ^ key[count]);

                count++;

                if(count == keyLength)//if you are over the end of the key go back the the start of the key, loops the key effectively
                {
                    count = 0;
                }

            }

            if(File.Exists(filePathEnc))//if the file already exists
            {
                //creates the overwrite message box and if the use choses yes write the file
                if (MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    using (FileStream fileStream = new FileStream(filePathEnc, FileMode.Create))
                    {
                        for (int j = 0; j < l; j++)
                        {

                            fileStream.WriteByte(fileEnc[j]);

                        }
                    }

                }
                else//user pressed no
                {

                    return;//return so we do not do anything

                }
                          
            }
            else//file doesn't exist just write the file
            {

                using (FileStream fileStream = new FileStream(filePathEnc, FileMode.Create))
                {
                    for (int j = 0; j < l; j++)
                    {

                        fileStream.WriteByte(fileEnc[j]);

                    }
                }

                MessageBox.Show("Operation created successfully", "Success", MessageBoxButtons.OK);

            }          

        }

    }
}
