using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotOM;

namespace MyFirstRobotApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RobotOM.RobotApplication robotapp = new RobotApplication();

            robotapp.Project.Structure.Nodes.Create(robotapp.Project.Structure.Nodes.FreeNumber, 0, 0, 0);

            robotapp.Project.ViewMngr.Refresh();
        }
    }
}
