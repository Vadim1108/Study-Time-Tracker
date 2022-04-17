using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Study_Time_Tracker
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;
        public Form1() // Default
        {
            InitializeComponent();
        }

        string path = @"Study Time Tracker"; // Fields
        int tempHours = 0;
        int tempMinutes = 0;

        private void Form1_Load(object sender, EventArgs e) // Loading form
        {
            DB = new SQLiteConnection("Data Source=data.db");
            DB.Open();

            if (!Directory.Exists(path))
            {
                for (int i = 0; i < 8; i++) // Create folders with files and write inside 0;
                {
                    Directory.CreateDirectory($@"{path}\{i}");
                    File.Create($@"{path}\{i}\hours.txt").Close();
                    File.WriteAllText($@"{path}\{i}\hours.txt", "0");
                    File.Create($@"{path}\{i}\minutes.txt").Close();
                    File.WriteAllText($@"{path}\{i}\minutes.txt", "0");
                }
            }

            textBox1.Text = $"Time invested in watching tutorials C# is {ReadFile($@"{path}\{1}\hours.txt")} hours and {ReadFile($@"{path}\{1}\minutes.txt")} minutes";
            textBox2.Text = $"Number of projects made are {ReadFile($@"{path}\{2}\minutes.txt")}";
            textBox3.Text = $"Time invested in projects is {ReadFile($@"{path}\{3}\hours.txt")} hours and {ReadFile($@"{path}\{3}\minutes.txt")} minutes";
            textBox4.Text = $"Time invested in reading books C# is {ReadFile($@"{path}\{4}\hours.txt")} hours and {ReadFile($@"{path}\{4}\minutes.txt")} minutes";
            textBox5.Text = $"Number of the books C# was read are {ReadFile($@"{path}\{5}\minutes.txt")}";
            textBox6.Text = $"Time invested in googling solutions is {ReadFile($@"{path}\{6}\hours.txt")} hours and {ReadFile($@"{path}\{6}\minutes.txt")} minutes";
            textBox7.Text = $"Time invested in reading documentation is {ReadFile($@"{path}\{7}\hours.txt")} hours and {ReadFile($@"{path}\{7}\minutes.txt")} minutes";



            textBox1.Text = SearchNumbers();
        }

        string SearchNumbers()
        {
            SQLiteCommand Search = DB.CreateCommand();
            Search.CommandText = "select count(*) from DataStore";
            return Search.ExecuteScalar().ToString();
        }

        private void button1_Click(object sender, EventArgs e) // Button Add
        {
            if (checkBox1.Checked)
            {
                Calculate($@"{path}\{1}\hours.txt", $@"{path}\{1}\minutes.txt");
                textBox1.Text = $"Time invested in watching tutorials C# is {ReadFile($@"{path}\{1}\hours.txt")} hours and {ReadFile($@"{path}\{1}\minutes.txt")} minutes";
            }
            else if (checkBox2.Checked)
            {
                CalculateNumber($@"{path}\{2}\minutes.txt");
                textBox2.Text = $"Number of projects made are {ReadFile($@"{path}\{2}\minutes.txt")}";
            }
            else if (checkBox3.Checked)
            {
                Calculate($@"{path}\{3}\hours.txt", $@"{path}\{3}\minutes.txt");
                textBox3.Text = $"Time invested in projects is {ReadFile($@"{path}\{3}\hours.txt")} hours and {ReadFile($@"{path}\{3}\minutes.txt")} minutes";
            }
            else if (checkBox4.Checked)
            {
                Calculate($@"{path}\{4}\hours.txt", $@"{path}\{4}\minutes.txt");
                textBox4.Text = $"Time invested in reading books C# is {ReadFile($@"{path}\{4}\hours.txt")} hours and {ReadFile($@"{path}\{4}\minutes.txt")} minutes";
            }
            else if (checkBox5.Checked)
            {
                CalculateNumber($@"{path}\{5}\minutes.txt");
                textBox5.Text = $"Number of the books C# was read are {ReadFile($@"{path}\{5}\minutes.txt")}";
            }
            else if (checkBox6.Checked)
            {
                Calculate($@"{path}\{6}\hours.txt", $@"{path}\{6}\minutes.txt");
                textBox6.Text = $"Time invested in googling solutions is {ReadFile($@"{path}\{6}\hours.txt")} hours and {ReadFile($@"{path}\{6}\minutes.txt")} minutes";
            }
            else if (checkBox7.Checked)
            {
                Calculate($@"{path}\{7}\hours.txt", $@"{path}\{7}\minutes.txt");
                textBox7.Text = $"Time invested in reading documentation is {ReadFile($@"{path}\{7}\hours.txt")} hours and {ReadFile($@"{path}\{7}\minutes.txt")} minutes";
            }
            else // Error if you forget to choose ticker and press add button
            {
                MessageBox.Show("You forget to select ticker", "Error", MessageBoxButtons.OK);
            }
        }
        private void button3_Click(object sender, EventArgs e) // Reset Button 1
        {
            Reset($@"{path}\{1}\hours.txt", $@"{path}\{1}\minutes.txt");
            textBox1.Text = $"Time invested in watching tutorials C# is {ReadFile($@"{path}\{1}\hours.txt")} hours and {ReadFile($@"{path}\{1}\minutes.txt")} minutes";
        }
        private void button4_Click(object sender, EventArgs e) // Reset Button 2
        {
            File.WriteAllText($@"{path}\{2}\minutes.txt", "0");
            textBox2.Text = $"Number of projects made are {ReadFile($@"{path}\{2}\minutes.txt")}";
        }
        private void button5_Click(object sender, EventArgs e)  // Reset Button 3
        {
            Reset($@"{path}\{3}\hours.txt", $@"{path}\{3}\minutes.txt");
            textBox3.Text = $"Time invested in projects is {ReadFile($@"{path}\{3}\hours.txt")} hours and {ReadFile($@"{path}\{3}\minutes.txt")} minutes";
        }
        private void button6_Click(object sender, EventArgs e) // Reset Button 4
        {
            Reset($@"{path}\{4}\hours.txt", $@"{path}\{4}\minutes.txt");
            textBox4.Text = $"Time invested in reading books C# is {ReadFile($@"{path}\{4}\hours.txt")} hours and {ReadFile($@"{path}\{4}\minutes.txt")} minutes";
        }
        private void button7_Click(object sender, EventArgs e) // Reset Button 5
        {
            File.WriteAllText($@"{path}\{5}\minutes.txt", "0");
            textBox5.Text = $"Number of the books C# was read are {ReadFile($@"{path}\{5}\minutes.txt")}";
        }
        private void button8_Click(object sender, EventArgs e) // Reset Button 6
        {
            Reset($@"{path}\{6}\hours.txt", $@"{path}\{6}\minutes.txt");
            textBox6.Text = $"Time invested in googling solutions is {ReadFile($@"{path}\{6}\hours.txt")} hours and {ReadFile($@"{path}\{6}\minutes.txt")} minutes";
        }
        private void button9_Click(object sender, EventArgs e) // Reset Button 7
        {
            Reset($@"{path}\{7}\hours.txt", $@"{path}\{7}\minutes.txt");
            textBox7.Text = $"Time invested in reading documentation is {ReadFile($@"{path}\{7}\hours.txt")} hours and {ReadFile($@"{path}\{7}\minutes.txt")} minutes";
        }
        private void checkBox2_Click(object sender, EventArgs e) // Click CheckBox 2
        {
            textBox9.Enabled = false;

            if (!checkBox2.Checked)
            {
                textBox9.Enabled = true;
            }
        }
        private void textBox9_Click(object sender, EventArgs e) // Clear Text Input Field (Hours)
        {
            textBox9.Text = "";
        }
        private void textBox8_Click(object sender, EventArgs e) // Clear Text Input Field (Minutes)
        {
            textBox8.Text = "";
        }
        private void checkBox5_Click(object sender, EventArgs e) // Click CheckBox 5
        {
            textBox9.Enabled = false;

            if (!checkBox5.Checked)
            {
                textBox9.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e) // Button Back
        {
            if (checkBox1.Checked)
            {
                CalculateBack($@"{path}\{1}\hours.txt", $@"{path}\{1}\minutes.txt");
                textBox1.Text = $"Time invested in watching tutorials C# is {ReadFile($@"{path}\{1}\hours.txt")} hours and {ReadFile($@"{path}\{1}\minutes.txt")} minutes";
            }
            else if (checkBox2.Checked)
            {
                CalculateBackNumber($@"{path}\{2}\minutes.txt");
                textBox2.Text = $"Number of projects made are {ReadFile($@"{path}\{2}\minutes.txt")}";
            }
            else if (checkBox3.Checked)
            {
                CalculateBack($@"{path}\{3}\hours.txt", $@"{path}\{3}\minutes.txt");
                textBox3.Text = $"Time invested in projects is {ReadFile($@"{path}\{3}\hours.txt")} hours and {ReadFile($@"{path}\{3}\minutes.txt")} minutes";
            }
            else if (checkBox4.Checked)
            {
                CalculateBack($@"{path}\{4}\hours.txt", $@"{path}\{4}\minutes.txt");
                textBox4.Text = $"Time invested in reading books C# is {ReadFile($@"{path}\{4}\hours.txt")} hours and {ReadFile($@"{path}\{4}\minutes.txt")} minutes";
            }
            else if (checkBox5.Checked)
            {
                CalculateBackNumber($@"{path}\{5}\minutes.txt");
                textBox5.Text = $"Number of the books C# was read are {ReadFile($@"{path}\{5}\minutes.txt")}";

            }
            else if (checkBox6.Checked)
            {
                CalculateBack($@"{path}\{6}\hours.txt", $@"{path}\{6}\minutes.txt");
                textBox6.Text = $"Time invested in googling solutions is {ReadFile($@"{path}\{6}\hours.txt")} hours and {ReadFile($@"{path}\{6}\minutes.txt")} minutes";
            }
            else if (checkBox7.Checked)
            {
                CalculateBack($@"{path}\{7}\hours.txt", $@"{path}\{7}\minutes.txt");
                textBox7.Text = $"Time invested in reading documentation is {ReadFile($@"{path}\{7}\hours.txt")} hours and {ReadFile($@"{path}\{7}\minutes.txt")} minutes";
            }
            else // Error
            {
                MessageBox.Show("You forget to select ticker", "Error", MessageBoxButtons.OK);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Closing form
        {
            DialogResult result = MessageBox.Show("Delete all data?", "Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {Directory.Delete(path, true);}
            DB.Close();
        }
        string ReadFile(string pathToFile) // Own Method 
        {
            return File.ReadAllText(pathToFile);
        }
        int ReadFileInt(string pathToFile) // Own Method
        {
            return Convert.ToInt32(File.ReadAllText(pathToFile));
        }
        void Calculate(string pathhours, string pathminutes) // Own Method
        {
            int inputHours = Convert.ToInt32(textBox9.Text); // Read input
            int inputMinutes = Convert.ToInt32(textBox8.Text);

            tempHours = Convert.ToInt32(File.ReadAllText(pathhours)) + inputHours; // Calculate hours and minutes
            tempMinutes = Convert.ToInt32(File.ReadAllText(pathminutes)) + inputMinutes;

            if (tempMinutes >= 60) // Sorting time if minutes >= 60;
            {
                tempHours++;
                tempMinutes = tempMinutes - 60;
            }

            File.WriteAllText(pathhours, Convert.ToString(tempHours)); // Save values into files
            File.WriteAllText(pathminutes, Convert.ToString(tempMinutes));
        }
        void CalculateNumber(string pathminutes) // Own Method
        {
            int inputMinutes = Convert.ToInt32(textBox8.Text); // Read input
            tempMinutes = ReadFileInt(pathminutes) + inputMinutes; //Calculate
            File.WriteAllText(pathminutes, Convert.ToString(tempMinutes));  // Saving
        }
        void Reset(string pathhours, string pathminutes) // Own Method
        {
            File.WriteAllText(pathminutes, "0");
            File.WriteAllText(pathhours, "0");
        }
        void CalculateBack(string pathhours, string pathminutes) // Own Method
        {
            int inputHours = Convert.ToInt32(textBox9.Text);
            int inputMinutes = Convert.ToInt32(textBox8.Text);

            if (ReadFileInt(pathhours) <= 0 & ReadFileInt(pathminutes) < inputMinutes
                || ReadFileInt(pathhours) < inputHours
                || ReadFileInt(pathhours) <= inputHours & ReadFileInt(pathminutes) < inputMinutes) // Check condition
            {
                MessageBox.Show("No possible to go back", "Error", MessageBoxButtons.OK);
            }
            else if (ReadFileInt(pathminutes) < 60) // Add 60 to minutes to be possible to calculate
            {
                int a = ReadFileInt(pathminutes) + 60;
                File.WriteAllText(pathminutes, Convert.ToString(a));

                int b = ReadFileInt(pathhours) - 1; // Take 1 hour from hours
                File.WriteAllText(pathhours, Convert.ToString(b));

                tempMinutes = ReadFileInt(pathminutes) - inputMinutes; // Calculate
                tempHours = ReadFileInt(pathhours) - inputHours;

                if (tempMinutes >= 60) // Sort time
                {
                    tempHours++;
                    tempMinutes = tempMinutes - 60;
                }

                File.WriteAllText(pathminutes, Convert.ToString(tempMinutes)); // Saving
                File.WriteAllText(pathhours, Convert.ToString(tempHours));

            }
        }
        void CalculateBackNumber (string pathminutes) // Own Method
        {
            int inputMinutes = Convert.ToInt32(textBox8.Text);

            if (ReadFileInt(pathminutes) <= 0 
                || ReadFileInt(pathminutes) < inputMinutes) // Check condition
            {
                MessageBox.Show("No possible to go back", "Error", MessageBoxButtons.OK);
            }
            else
            {
                tempMinutes = ReadFileInt(pathminutes) - inputMinutes; // Calculate
                File.WriteAllText(pathminutes, Convert.ToString(tempMinutes)); // Saving
            }
        }
    }
}