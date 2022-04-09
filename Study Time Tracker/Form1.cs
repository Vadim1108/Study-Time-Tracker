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
            // Create work folders if they are not present
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
            textBox2.Text = $"Number of projects made are " + File.ReadAllText(path2Number);
            textBox3.Text = $"Time invested in projects is " + File.ReadAllText(path3Hours) + " hours and " + File.ReadAllText(path3Minutes) + " minutes";
            textBox4.Text = $"Time invested in reading books C# is " + File.ReadAllText(path4Hours) + " hours and " + File.ReadAllText(path4Minutes) + " minutes";
            textBox5.Text = $"Number of the books C# was read are " + File.ReadAllText(path5Number);
            textBox6.Text = $"Time invested in googling solutions is " + File.ReadAllText(path6Hours) + " hours and " + File.ReadAllText(path6Minutes) + " minutes";
            textBox7.Text = $"Time invested in reading documentation is " + File.ReadAllText(path7Hours) + "hours and " + File.ReadAllText(path7Minutes) + " minutes";
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

            }
            else if (checkBox2.Checked)
            {
                // Read data from file and add input number
                tempMinutes = Convert.ToInt32(File.ReadAllText(path2Number)) + inputMinutes;

                // Reload textbox2
                textBox2.Text = $"Number of projects made are: {tempMinutes}";

                // Save new date into file
                File.WriteAllText(path2Number, Convert.ToString(tempMinutes));

            }
            else if (checkBox3.Checked)
            {
                // Read data from files and add input time
                tempMinutes = Convert.ToInt32(File.ReadAllText(path3Minutes)) + inputMinutes;
                tempHours = Convert.ToInt32(File.ReadAllText(path3Hours)) + inputHours;

                // Sorting time per 60;
                if (tempMinutes >= 60)
                {
                    tempHours++;
                    tempMinutes = tempMinutes - 60;
                }

                // Reload textbox3
                textBox3.Text = $"Time invested in projects is {tempHours} hours and {tempMinutes} minutes";

                // Save new date into files
                File.WriteAllText(path3Minutes, Convert.ToString(tempMinutes));
                File.WriteAllText(path3Hours, Convert.ToString(tempHours));
            }
            else if (checkBox4.Checked)
            {
                // Read data from files and add input time
                tempMinutes = Convert.ToInt32(File.ReadAllText(path4Minutes)) + inputMinutes;
                tempHours = Convert.ToInt32(File.ReadAllText(path4Hours)) + inputHours;

                // Sorting time per 60;
                if (tempMinutes >= 60)
                {
                    tempHours++;
                    tempMinutes = tempMinutes - 60;
                }

                // Reload textbox4
                textBox4.Text = $"Time invested in reading books C# is {tempHours} hours and {tempMinutes} minutes";

                // Save new date into files
                File.WriteAllText(path4Minutes, Convert.ToString(tempMinutes));
                File.WriteAllText(path4Hours, Convert.ToString(tempHours));
            }
            else if (checkBox5.Checked)
            {
                // Read data from file and add input number
                tempMinutes = Convert.ToInt32(File.ReadAllText(path5Number)) + inputMinutes;

                // Reload textbox2
                textBox5.Text = $"Number of the books C# was read are {tempMinutes}";

                // Save new date into file
                File.WriteAllText(path5Number, Convert.ToString(tempMinutes));


            }
            else if (checkBox6.Checked)
            {
                // Read data from files and add input time
                tempMinutes = Convert.ToInt32(File.ReadAllText(path6Minutes)) + inputMinutes;
                tempHours = Convert.ToInt32(File.ReadAllText(path6Hours)) + inputHours;

                // Sorting time per 60;
                if (tempMinutes >= 60)
                {
                    tempHours++;
                    tempMinutes = tempMinutes - 60;
                }

                // Reload textbox6
                textBox6.Text = $"Time invested in googling solutions is {tempHours} hours and {tempMinutes} minutes";

                // Save new date into files
                File.WriteAllText(path6Minutes, Convert.ToString(tempMinutes));
                File.WriteAllText(path6Hours, Convert.ToString(tempHours));
            }
            else if (checkBox7.Checked)
            {
                // Read data from files and add input time
                tempMinutes = Convert.ToInt32(File.ReadAllText(path7Minutes)) + inputMinutes;
                tempHours = Convert.ToInt32(File.ReadAllText(path7Hours)) + inputHours;

                // Sorting time per 60;
                if (tempMinutes >= 60)
                {
                    tempHours++;
                    tempMinutes = tempMinutes - 60;
                }

                // Reload textbox7
                textBox7.Text = $"Time invested in reading documentation is {tempHours} hours and {tempMinutes} minutes";

                // Save new date into files
                File.WriteAllText(path7Minutes, Convert.ToString(tempMinutes));
                File.WriteAllText(path7Hours, Convert.ToString(tempHours));
            }
            else
            {
                // Error if you forget to choose ticker and press add button
                MessageBox.Show("You forget to select ticker","Error", MessageBoxButtons.OK);
            }
        }

        // Reset buttons
        // Reset button1
        private void button3_Click(object sender, EventArgs e)
        {
            // Reset button 1 with 0
            File.WriteAllText(path1Minutes, "0");
            File.WriteAllText(path1Hours, "0");

            // Reload  texbox1
            textBox1.Text = "Time invested in watching tutorials C# is " + File.ReadAllText(path1Hours) + " hours and " + File.ReadAllText(path1Minutes) + " minutes";

        }

        // Reset button2
        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path2Number, "0");
            textBox2.Text = $"Number of projects made are " + File.ReadAllText(path2Number);
        }

        // Reset button3
        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path3Hours, "0");
            File.WriteAllText(path3Minutes, "0");

            // Reload textbox3
            textBox3.Text = $"Time invested in projects is " + File.ReadAllText(path3Hours) + " hours and " + File.ReadAllText(path3Minutes) + " minutes";
        }

        // Reset button4
        private void button6_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path4Hours, "0");
            File.WriteAllText(path4Minutes, "0");

            // Reload textbox4
            textBox4.Text = $"Time invested in reading books C# is " + File.ReadAllText(path4Hours) + "hours and " + File.ReadAllText(path4Minutes) + " minutes";

        }

        // Reset button5
        private void button7_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path5Number, "0");
            textBox5.Text = $"Number of the books C# was read are " + File.ReadAllText(path5Number);

        }

        // Reset button6
        private void button8_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path6Hours, "0");
            File.WriteAllText(path6Minutes, "0");

            // Reload textbox4
            textBox6.Text = $"Time invested in googling solutions is " + File.ReadAllText(path6Hours) + " hours and " + File.ReadAllText(path6Minutes) + " minutes";

        }
        
        // Reset button7
        private void button9_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path7Hours, "0");
            File.WriteAllText(path7Minutes, "0");

            // Reload textbox4
            textBox7.Text = $"Time invested in reading documentation is " + File.ReadAllText(path7Hours) + "hours and " + File.ReadAllText(path7Minutes) + " minutes";


        }

        // Another functions
        // When choose ticker 2 , make available only one field to input number
        private void checkBox2_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = false;

            // If you remove ticker set back field be enabled
            if (!checkBox2.Checked)
            {
                textBox9.Enabled = true;
            }
        }

        // Click on input field
        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        // Click on input field
        private void textBox8_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        // Make one field to input data and reset if you switch 
        private void checkBox5_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = false;

            // If you remove ticker set back field be enabled
            if (!checkBox5.Checked)
            {
                textBox9.Enabled = true;
            }
        }


    }
}
