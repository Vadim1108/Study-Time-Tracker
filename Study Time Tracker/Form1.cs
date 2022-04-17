using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Study_Time_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int tempHours = 0;
        int tempMinutes = 0;
        private SQLiteConnection DB;

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source=data.db");
            DB.Open();

            UpdateTextBox1();
            UpdateTextBox2();
            UpdateTextBox3();
            UpdateTextBox4();
            UpdateTextBox5();
            UpdateTextBox6();
            UpdateTextBox7();
        }

        void UpdateTextBox1()
        {
            textBox1.Text = $@"Time invested in watching tutorials C# is {GetValue("hours1")} hours and {GetValue("minutes1")} minutes";
        }
        void UpdateTextBox2()
        {
            textBox2.Text = $"Number of projects made are {GetValue("number2")}";
        }
        void UpdateTextBox3()
        {
            textBox3.Text = $"Time invested in projects is {GetValue("hours3")} hours and {GetValue("minutes3")} minutes";
        }
        void UpdateTextBox4()
        {
            textBox4.Text = $"Time invested in reading books C# is {GetValue("hours4")} hours and {GetValue("minutes4")} minutes";
        }
        void UpdateTextBox5()
        {
            textBox5.Text = $"Number of the books C# was read are {GetValue("number5")}";
        }
        void UpdateTextBox6()
        {
            textBox6.Text = $"Time invested in googling solutions is {GetValue("hours6")} hours and {GetValue("minutes6")} minutes";
        }
        void UpdateTextBox7()
        {
            textBox7.Text = $"Time invested in reading documentation is {GetValue("hours7")} hours and {GetValue("minutes7")} minutes";
        }

        string GetValue(string dataName) // Read from DB and return string value
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = $@"select Dates from DataStore where Name = '{dataName}'";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.Read())
                return $@"{SQL["Dates"]}";
            else
                return "";
        }
        void WriteValue(string dataName, string dataValue) // Update value to DB
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = $@"update DataStore set Dates = {dataValue} where Name = '{dataName}'";
            CMD.ExecuteNonQuery();
        }
        void ResetValue(string dataName) // Update value with 0 to DB
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = $@"update DataStore set Dates = 0 where Name = '{dataName}'";
            CMD.ExecuteNonQuery();
        }
        void Calculate(string hours, string minutes)
        {
            int inputHours = Convert.ToInt32(textBox9.Text); // Read input fields
            int inputMinutes = Convert.ToInt32(textBox8.Text);

            tempHours = Convert.ToInt32(GetValue(hours)) + inputHours; // Calculate hours and minutes
            tempMinutes = Convert.ToInt32(GetValue(minutes)) + inputMinutes;

            if (tempMinutes >= 60) // Sorting time if minutes >= 60;
            {
                tempHours++;
                tempMinutes = tempMinutes - 60;
            }

            WriteValue(hours, Convert.ToString(tempHours));
            WriteValue(minutes, Convert.ToString(tempMinutes));

        }
        void CalculateNumber(string number)
        {
            int inputMinutes = Convert.ToInt32(textBox8.Text); // Read input
            tempMinutes = Convert.ToInt32(GetValue(number)) + inputMinutes; //Calculate
            WriteValue(number, Convert.ToString(tempMinutes)); // Saving
        }
        void CalculateBack(string hours, string minutes)
        {
            int inputHours = Convert.ToInt32(textBox9.Text);
            int inputMinutes = Convert.ToInt32(textBox8.Text);

            if (Convert.ToInt32(GetValue(hours)) <= 0 & Convert.ToInt32(GetValue(minutes)) < inputMinutes
                || Convert.ToInt32(GetValue(hours)) < inputHours
                || Convert.ToInt32(GetValue(hours)) <= inputHours & Convert.ToInt32(GetValue(minutes)) < inputMinutes) // Check condition
            {
                MessageBox.Show("No possible to go back", "Error", MessageBoxButtons.OK);
            }
            else if (Convert.ToInt32(GetValue(minutes)) < 60) // Add 60 to minutes to be possible to calculate
            {
                int a = Convert.ToInt32(GetValue(minutes)) + 60;
                WriteValue(minutes, Convert.ToString(a));

                int b = Convert.ToInt32(GetValue(hours)) - 1; // Take 1 hour from hours
                WriteValue(hours, Convert.ToString(b));

                tempMinutes = Convert.ToInt32(GetValue(minutes)) - inputMinutes; // Calculate
                tempHours = Convert.ToInt32(GetValue(hours)) - inputHours;

                if (tempMinutes >= 60) // Sort time
                {
                    tempHours++;
                    tempMinutes = tempMinutes - 60;
                }

                WriteValue(minutes, Convert.ToString(tempMinutes));
                WriteValue(hours, Convert.ToString(tempHours));

            }
        }
        void CalculateBackNumber(string minutes)
        {
            int inputMinutes = Convert.ToInt32(textBox8.Text);

            if (Convert.ToInt32(GetValue(minutes)) <= 0
                || Convert.ToInt32(GetValue(minutes)) < inputMinutes) // Check condition
            {
                MessageBox.Show("No possible to go back", "Error", MessageBoxButtons.OK);
            }
            else
            {
                tempMinutes = Convert.ToInt32(GetValue(minutes)) - inputMinutes; // Calculate
                WriteValue(minutes, Convert.ToString(tempMinutes));
            }
        }

        private void button1_Click(object sender, EventArgs e) // Button Add
        {
            if (checkBox1.Checked)
            {
                Calculate("hours1", "minutes1");
                UpdateTextBox1();
            }
            else if (checkBox2.Checked)
            {
                CalculateNumber("number2");
                UpdateTextBox2();
            }
            else if (checkBox3.Checked)
            {
                Calculate("hours3", "minutes3");
                UpdateTextBox3();
            }
            else if (checkBox4.Checked)
            {
                Calculate("hours4", "minutes4");
                UpdateTextBox4();
            }
            else if (checkBox5.Checked)
            {
                CalculateNumber("number5");
                UpdateTextBox5();
            }
            else if (checkBox6.Checked)
            {
                Calculate("hours6", "minutes6");
                UpdateTextBox6();
            }
            else if (checkBox7.Checked)
            {
                Calculate("hours7", "minutes7");
                UpdateTextBox7();
            }
            else // Error if you forget to choose ticker and press add button
            {
                MessageBox.Show("You forget to select ticker", "Error", MessageBoxButtons.OK);
            }
        }
        private void ResetButton1_Click(object sender, EventArgs e)
        {
            ResetValue("hours1");
            ResetValue("minutes1");
            UpdateTextBox1();
        }
        private void button4_Click(object sender, EventArgs e) // Reset Button 2
        {
            ResetValue("number2");
            UpdateTextBox2();
        }
        private void button5_Click(object sender, EventArgs e)  // Reset Button 3
        {
            ResetValue("hours3");
            ResetValue("minutes3");
            UpdateTextBox3();
        }
        private void button6_Click(object sender, EventArgs e) // Reset Button 4
        {
            ResetValue("hours4");
            ResetValue("minutes4");
            UpdateTextBox4();
        }
        private void button7_Click(object sender, EventArgs e) // Reset Button 5
        {
            ResetValue("number5");
            UpdateTextBox5();
        }
        private void button8_Click(object sender, EventArgs e) // Reset Button 6
        {
            ResetValue("hours6");
            ResetValue("minutes6");
            UpdateTextBox6();
        }
        private void button9_Click(object sender, EventArgs e) // Reset Button 7
        {
            ResetValue("hours7");
            ResetValue("minutes7");
            UpdateTextBox7();
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = false;

            if (!checkBox2.Checked)
            {
                textBox9.Enabled = true;
            }
        }
        private void checkBox5_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = false;

            if (!checkBox5.Checked)
            {
                textBox9.Enabled = true;
            }
        }
        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }
        private void textBox8_Click(object sender, EventArgs e) 
        {
            textBox8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) // Button Back
        {
            if (checkBox1.Checked)
            {
                CalculateBack("hours1","minutes1");
                UpdateTextBox1();
            }
            else if (checkBox2.Checked)
            {
                CalculateBackNumber("number2");
                UpdateTextBox2();
            }
            else if (checkBox3.Checked)
            {
                CalculateBack("hours3", "minutes3");
                UpdateTextBox3();
            }
            else if (checkBox4.Checked)
            {
                CalculateBack("hours4", "minutes4");
                UpdateTextBox4();
            }
            else if (checkBox5.Checked)
            {
                CalculateBackNumber("number5");
                UpdateTextBox5();
            }
            else if (checkBox6.Checked)
            {
                CalculateBack("hours6", "minutes6");
                UpdateTextBox6();
            }
            else if (checkBox7.Checked)
            {
                CalculateBack("hours7", "minutes7");
                UpdateTextBox7();
            }
            else // Error
            {
                MessageBox.Show("You forget to select ticker", "Error", MessageBoxButtons.OK);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Closing form
        {
            DB.Close();
        }
        
    }
}