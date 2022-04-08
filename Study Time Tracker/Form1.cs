using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study_Time_Tracker
{
    public partial class Form1 : Form
    {
        string path = @"C:\temp\Study Time Tracker"; // Add path

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create work folders
            if (!Directory.Exists(path))
            {
                string hours = "hours.txt";
                string minutes = "minutes.txt";
                string zero = "0";

                // Create folders
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "\\" + textBox1.Text);
                Directory.CreateDirectory(path + "\\" + textBox2.Text);
                Directory.CreateDirectory(path + "\\" + textBox3.Text);
                Directory.CreateDirectory(path + "\\" + textBox4.Text);
                Directory.CreateDirectory(path + "\\" + textBox5.Text);
                Directory.CreateDirectory(path + "\\" + textBox6.Text);
                Directory.CreateDirectory(path + "\\" + textBox7.Text);

                // Create data files
                File.Create(path + "\\" + textBox1.Text + "\\" + hours).Close() ;    
                File.Create(path + "\\" + textBox1.Text + "\\" + minutes).Close();   
                File.Create(path + "\\" + textBox2.Text + "\\" + hours).Close();     
                File.Create(path + "\\" + textBox2.Text + "\\" + minutes).Close();   
                File.Create(path + "\\" + textBox3.Text + "\\" + hours).Close();     
                File.Create(path + "\\" + textBox3.Text + "\\" + minutes).Close();   
                File.Create(path + "\\" + textBox4.Text + "\\" + hours).Close();     
                File.Create(path + "\\" + textBox4.Text + "\\" + minutes).Close();   
                File.Create(path + "\\" + textBox5.Text + "\\" + hours).Close();     
                File.Create(path + "\\" + textBox5.Text + "\\" + minutes).Close();   
                File.Create(path + "\\" + textBox6.Text + "\\" + hours).Close();     
                File.Create(path + "\\" + textBox6.Text + "\\" + minutes).Close();  
                File.Create(path + "\\" + textBox7.Text + "\\" + hours).Close();     
                File.Create(path + "\\" + textBox7.Text + "\\" + minutes).Close();   

                // Write 0 to data files
                File.WriteAllText(path + "\\" + textBox1.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox1.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox2.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox2.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox3.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox3.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox4.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox4.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox5.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox5.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox6.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox6.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox7.Text + "\\" + hours, zero);
                File.WriteAllText(path + "\\" + textBox7.Text + "\\" + hours, zero);

            }



        }
    }
}
