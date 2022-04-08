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
            if (!Directory.Exists(path)) {Directory.CreateDirectory(path);} // Create work folder

        }
    }
}
