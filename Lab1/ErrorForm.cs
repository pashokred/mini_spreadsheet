﻿using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string message)
        {
            InitializeComponent();
            ErrorLabel.Text = message;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
