using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PorticoManual.controller;
using RobotOM;

namespace PorticoManual
{
    public partial class MainForm : Form
    {

        static readonly double GRAVITY_ACCELERATION = 9.81; 

        //Atributes
        double load, dimensionA, dimensionB, dimensionC, dimensionD, dimensionE, dimensionF, dimensionG;

        int divisionNumber; //Number of column division 

        private void nupNumericDivision_ValueChanged(object sender, EventArgs e)
        {
            if(nupNumericDivision.Value < 0)
            {
                nupNumericDivision.Value = 0;
                return;
            }
            if(nupNumericDivision.Value > 15)
            {
                nupNumericDivision.Value = 15;
                return;
            }

            //Disable cbColumnBraket
            if(nupNumericDivision.Value == 0)
            {
                cbColumnBracket.Enabled = false;
            } else
            {
                cbColumnBracket.Enabled = true;
            }

        }

        Structure structure;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string message = errorMessage();
            if(message.Length == 0)
            {
                //Recover data from screen elements
                dimensionA = double.Parse(tbDimensionA.Text) / 1000;
                dimensionB = double.Parse(tbDimensionB.Text) / 1000;
                dimensionC = double.Parse(tbDimensionC.Text) / 1000;
                dimensionD = double.Parse(tbDimensionD.Text) / 1000;
                dimensionE = double.Parse(tbDimensionE.Text) / 1000;
                dimensionF = double.Parse(tbDimensionF.Text) / 1000;
                dimensionG = double.Parse(tbDimensionG.Text) / 1000;

                load = -1 * double.Parse(tbLiftingLoad.Text) * GRAVITY_ACCELERATION; //load converted to Newton 

                //Profile labels
                string railBeam = cbBeamSection.Text;
                string column = cbPipeSection.Text;
                string wheelBeam = cbWheelBeamSection.Text;
                
                //Store profiles labels in the current project
                //W shape profile
                structure.storeSectionLabelFromDB("CISC", IRobotLabelType.I_LT_BAR_SECTION, railBeam);
                structure.storeSectionLabelFromDB("CISC", IRobotLabelType.I_LT_BAR_SECTION, wheelBeam);
                //Pipe shape
                structure.storeSectionLabelFromDB("AISC", IRobotLabelType.I_LT_BAR_SECTION, column);

                //Creates the geometry of the structure
                structure.createFrame(dimensionG, dimensionD, dimensionB, dimensionC, dimensionE, railBeam, column, wheelBeam);
                lblStatus.Text = "Status: Geometria pronta";

                divisionNumber = int.Parse(nupNumericDivision.Text);
                if(divisionNumber > 0)
                {
                    //Profile label
                    string columnBracket = cbColumnBracket.Text;
                    //Store the profile labels in the current project
                    structure.storeSectionLabelFromDB("AISC", IRobotLabelType.I_LT_BAR_SECTION, columnBracket);
                    structure.divideColumns(divisionNumber, columnBracket);
                }

                //Console.WriteLine("Número de divisoes das pernas: " + divisionNumber);

                //Creates the loads in the structure
                structure.generateStructureLoads(load, dimensionC, dimensionE);
                lblStatus.Text = "Status: Carregamento e combinações prontos";

                //Calculates the strutucture
                if (!structure.calculateStructure())
                {
                    string calcMessage = "Erro ao calcular a estrutura.";
                    MessageBox.Show(calcMessage, "Cálculo da estrutura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblStatus.Text = "Erro ao calcular a estrutura.";
                }

                lblStatus.Text = "Status: Esforços calculados.";

            }
            else
            {
                MessageBox.Show(message, "Entrada de dados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }//btnCalculate_Click

        private string errorMessage()
        {
            string message = "";

            if(tbLiftingLoad.Text.Length == 0)
            {
                message += "Valor de carga não informado.\n\n";
            }
            if(!double.TryParse(tbLiftingLoad.Text,out load))
            {
                message += "Valor de carga não é um número\n\n";
            }
            if (tbDimensionA.Text.Length == 0)
            {
                message += "Valor da dimensão 'A' não informado.\n\n";
            }
            if (!double.TryParse(tbDimensionA.Text, out dimensionA))
            {
                message += "Valor da dimensão 'A' não é um número\n\n";
            }
            if (tbDimensionB.Text.Length == 0)
            {
                message += "Valor da dimensão 'B' não informado.\n\n";
            }
            if (!double.TryParse(tbDimensionB.Text, out dimensionB))
            {
                message += "Valor da dimensão 'B' não é um número\n\n";
            }
            if (tbDimensionC.Text.Length == 0)
            {
                message += "Valor da dimensão 'C' não informado.\n\n";
            }
            if (!double.TryParse(tbDimensionC.Text, out dimensionC))
            {
                message += "Valor da dimensão 'C' não é um número\n\n";
            }
            if (tbDimensionD.Text.Length == 0)
            {
                message += "Valor da dimensão 'D' não informado.\n\n";
            }
            if (!double.TryParse(tbDimensionD.Text, out dimensionD))
            {
                message += "Valor da dimensão 'D' não é um número\n\n";
            }
            if (tbDimensionE.Text.Length == 0)
            {
                message += "Valor da dimensão 'E' não informado.\n\n";
            }
            if (!double.TryParse(tbDimensionE.Text, out dimensionE))
            {
                message += "Valor da dimensão 'E' não é um número\n\n";
            }
            if (tbDimensionF.Text.Length == 0)
            {
                message += "Valor da dimensão 'F' não informado.\n\n";
            }
            if (!double.TryParse(tbDimensionF.Text, out dimensionF))
            {
                message += "Valor da dimensão 'F' não é um número\n\n";
            }
            if (tbDimensionG.Text.Length == 0)
            {
                message += "Valor da dimensão 'G' não informado.\n\n";
            }
            if (!double.TryParse(tbDimensionG.Text, out dimensionF))
            {
                message += "Valor da dimensão 'G' não é um número\n\n";
            }


            return message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Start connection with Robot
            structure = Structure.getInstance();
            structure.createProject();
            lblStatus.Text = "Status: Projeto pronto.";

            //Adding itens to the profile combo boxes
            //Beans section
            //lblStatus.Text = "Status: Carregando banco de dados de perfis...";
            IRobotNamesArray ciscSection = structure.loadProfileDatabase("CISC", "W ");
            IRobotNamesArray pipeSection = structure.loadProfileDatabase("AISC", "P ");

            for(int i = 1; i < ciscSection.Count; i++)
            {
                cbBeamSection.Items.Add(ciscSection.Get(i));
                cbWheelBeamSection.Items.Add(ciscSection.Get(i));
            }

            for(int i = 1; i < pipeSection.Count; i++)
            {
                cbPipeSection.Items.Add(pipeSection.Get(i));
                cbColumnBracket.Items.Add(pipeSection.Get(i));
            }

            if(nupNumericDivision.Value == 0)
            {
                cbColumnBracket.Enabled = false;
            }

            cbBeamSection.SelectedIndex = 0;
            cbWheelBeamSection.SelectedIndex = 0;
            cbPipeSection.SelectedIndex = 0;
            cbColumnBracket.SelectedIndex = 0;

            //Setting the default units
            structure.unitSettings("mm", "mm");
        }
    }
}
