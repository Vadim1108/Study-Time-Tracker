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
        // Make folders pathes
        string path = @"C:\temp\Study Time Tracker";
        string path1 = @"C:\temp\Study Time Tracker\1";
        string path2 = @"C:\temp\Study Time Tracker\2";
        string path3 = @"C:\temp\Study Time Tracker\3";
        string path4 = @"C:\temp\Study Time Tracker\4";
        string path5 = @"C:\temp\Study Time Tracker\5";
        string path6 = @"C:\temp\Study Time Tracker\6";
        string path7 = @"C:\temp\Study Time Tracker\7";

        // Make data files pathes
        string path1Hours = @"C:\temp\Study Time Tracker\1\hours.txt";
        string path1Minutes = @"C:\temp\Study Time Tracker\1\minutes.txt";
        string path2Number = @"C:\temp\Study Time Tracker\2\number.txt";
        string path3Hours = @"C:\temp\Study Time Tracker\3\hours.txt";
        string path3Minutes = @"C:\temp\Study Time Tracker\3\minutes.txt";
        string path4Hours = @"C:\temp\Study Time Tracker\4\hours.txt";
        string path4Minutes = @"C:\temp\Study Time Tracker\4\minutes.txt";
        string path5Number = @"C:\temp\Study Time Tracker\5\number.txt";
        string path6Hours = @"C:\temp\Study Time Tracker\6\hours.txt";
        string path6Minutes = @"C:\temp\Study Time Tracker\6\minutes.txt";
        string path7Hours = @"C:\temp\Study Time Tracker\7\hours.txt";
        string path7Minutes = @"C:\temp\Study Time Tracker\7\minutes.txt";

        int tempHours = 0;
        int tempMinutes = 0;



        public Form1()
        {
            InitializeComponent();
        }

        // When loading
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create work folders
            if (!Directory.Exists(path))
            {

                string zero = "0";

                // Create folders
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path1);
                Directory.CreateDirectory(path2);
                Directory.CreateDirectory(path3);
                Directory.CreateDirectory(path4);
                Directory.CreateDirectory(path5);
                Directory.CreateDirectory(path6);
                Directory.CreateDirectory(path7);

                // Create data files
                File.Create(path1Hours).Close() ;    
                File.Create(path1Minutes).Close();   
                File.Create(path2Number).Close();     
                File.Create(path3Hours).Close();     
                File.Create(path3Minutes).Close();   
                File.Create(path4Hours).Close();     
                File.Create(path4Minutes).Close();   
                File.Create(path5Number).Close();     
                File.Create(path6Hours).Close();     
                File.Create(path6Minutes).Close();  
                File.Create(path7Hours).Close();     
                File.Create(path7Minutes).Close();   

                // Write 0 to data files
                File.WriteAllText(path1Hours, zero);
                File.WriteAllText(path1Minutes, zero);
                File.WriteAllText(path2Number, zero);
                File.WriteAllText(path3Hours, zero);
                File.WriteAllText(path3Minutes, zero);
                File.WriteAllText(path4Hours, zero);
                File.WriteAllText(path4Minutes, zero);
                File.WriteAllText(path5Number, zero);
                File.WriteAllText(path6Hours, zero);
                File.WriteAllText(path6Minutes, zero);
                File.WriteAllText(path7Hours, zero);
                File.WriteAllText(path7Minutes, zero);

            }

            // Set 0 by default to input fields
            textBox8.Text = "0";
            textBox9.Text = "0";

            // Update text boxes
            textBox1.Text = "Time invested in watching tutorials C# is " + File.ReadAllText(path1Hours) + " hours and " + File.ReadAllText(path1Minutes) + " minutes";
            textBox2.Text = $"Number of projects made are: " + File.ReadAllText(path2Number);

        }

        // Add button
        private void button1_Click(object sender, EventArgs e)
        {

            // Read input to vars
            int inputHours = Convert.ToInt32(textBox9.Text);
            int inputMinutes = Convert.ToInt32(textBox8.Text);


            // Select check box and add time to files
            if (checkBox1.Checked)
            {
                // Read data from files and add input time
                tempMinutes = Convert.ToInt32(File.ReadAllText(path1Minutes)) + inputMinutes;
                tempHours = Convert.ToInt32(File.ReadAllText(path1Hours)) + inputHours;

                // Sorting time per 60;
                if (tempMinutes >= 60)
                {
                    tempHours++;
                    tempMinutes = tempMinutes - 60;
                }

                // Reload textbox1
                textBox1.Text = $"Time invested in watching tutorials C# is: {tempHours} hours and {tempMinutes} minutes";

                // Save new date into files
                File.WriteAllText(path1Minutes, Convert.ToString(tempMinutes));
                File.WriteAllText(path1Hours, Convert.ToString(tempHours));

                checkBox1.Checked = false;
            }
            else if (checkBox2.Checked)
            {
                // Read data from file and add input number
                tempMinutes = Convert.ToInt32(File.ReadAllText(path2Number)) + inputMinutes;

                // Reload textbox2
                textBox2.Text = $"Number of projects made are: {tempMinutes}";

                // Save new date into file
                File.WriteAllText(path2Number, Convert.ToString(tempMinutes));

                // Reset field for input hours
                checkBox2.Checked = false;
                textBox9.Enabled = true;


            }
            else
            {
                // Error if you forget to choose ticker and press add button
                MessageBox.Show("You forget to select ticker","Error", MessageBoxButtons.OK);
            }
        }

        // Reset button1
        private void button3_Click(object sender, EventArgs e)
        {
            // Reset button 1 with 0
            File.WriteAllText(path1Minutes, "0");
            File.WriteAllText(path1Hours, "0");

            // Reload  texbox1
            textBox1.Text = "Time invested in watching tutorials C# is " + File.ReadAllText(path1Hours) + " hours and " + File.ReadAllText(path1Minutes) + " minutes";

        }

        // When choose ticker 2 , make available only one field to input number
        private void checkBox2_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = false;
        }

        // Reset button2
        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path2Number, "0");
            textBox2.Text = $"Number of projects made are: " + File.ReadAllText(path2Number);
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }
    }
}
