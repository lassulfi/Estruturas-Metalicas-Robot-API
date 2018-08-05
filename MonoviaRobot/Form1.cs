using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MonoviaRobot.controller;

namespace MonoviaRobot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Setting the minimum values for all the structure parameters
            planesNumericUpDown.Value = 2;
            tbFrameHeight.Text = "5400";
            tbFrameSpam.Text = "3600";
            tbFrameOffset.Text = "4000";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
                        
            if(validateValues().Length > 0)
            {
                MessageBox.Show(validateValues(), "Dados do pórtico");
            }
            else
            {
                //Retrieve data from main form.
                int numberOfPlanes = (int) planesNumericUpDown.Value;
                double frameSpam = double.Parse(tbFrameSpam.Text);
                double frameHeight = double.Parse(tbFrameHeight.Text);
                double frameOffset = double.Parse(tbFrameOffset.Text);
            }

        }

        private void planesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(planesNumericUpDown.Value < 2)
            {
                planesNumericUpDown.Value = 2;
            }
        }

        private string validateValues()
        {
            string message = "";
            double testNumber;
            if (tbFrameHeight.Text.Length == 0)
            {
                message += "Altura do pórtico não informada.\n";
            }
            if (!double.TryParse(tbFrameHeight.Text,out testNumber))
            {
                message += "Altura do pórtico não é um número.\n";
            }
            if(tbFrameSpam.Text.Length == 0)
            {
                message += "Vão do pórtico não informado.\n";
            }
            if(!double.TryParse(tbFrameSpam.Text, out testNumber))
            {
                message += "Vão do pórtico não é número.\n";
            }
            if (tbFrameOffset.Text.Length == 0)
            {
                message += "Distânca entre pórticos não informada.\n";
            }
            if(!double.TryParse(tbFrameOffset.Text, out testNumber))
            {
                message += "Distância entre pórticos não é número.\n";
            }

            return message;
        }

        private void calculateStructure(int frames, double spam, double height, double offset)
        {
            Structure str = new Structure(frames, spam, height, offset);
        }
    }
}
