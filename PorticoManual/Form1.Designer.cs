namespace PorticoManual
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbLiftingLoad = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDimensionA = new System.Windows.Forms.TextBox();
            this.tbDimensionB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDimensionC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDimensionD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDimensionE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDimensionF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDimensionG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBeamSection = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbPipeSection = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbWheelBeamSection = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nupNumericDivision = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cbColumnBracket = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.materiaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarNovoMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumericDivision)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Capacidade da talha (kg)";
            // 
            // tbLiftingLoad
            // 
            this.tbLiftingLoad.Location = new System.Drawing.Point(163, 39);
            this.tbLiftingLoad.Name = "tbLiftingLoad";
            this.tbLiftingLoad.Size = new System.Drawing.Size(100, 20);
            this.tbLiftingLoad.TabIndex = 1;
            this.tbLiftingLoad.Text = "500";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(350, 324);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Geometria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "A:";
            // 
            // tbDimensionA
            // 
            this.tbDimensionA.Location = new System.Drawing.Point(57, 104);
            this.tbDimensionA.Name = "tbDimensionA";
            this.tbDimensionA.Size = new System.Drawing.Size(100, 20);
            this.tbDimensionA.TabIndex = 5;
            this.tbDimensionA.Text = "2800";
            // 
            // tbDimensionB
            // 
            this.tbDimensionB.Location = new System.Drawing.Point(57, 130);
            this.tbDimensionB.Name = "tbDimensionB";
            this.tbDimensionB.Size = new System.Drawing.Size(100, 20);
            this.tbDimensionB.TabIndex = 7;
            this.tbDimensionB.Text = "3000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "B:";
            // 
            // tbDimensionC
            // 
            this.tbDimensionC.Location = new System.Drawing.Point(57, 156);
            this.tbDimensionC.Name = "tbDimensionC";
            this.tbDimensionC.Size = new System.Drawing.Size(100, 20);
            this.tbDimensionC.TabIndex = 9;
            this.tbDimensionC.Text = "3090";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "C:";
            // 
            // tbDimensionD
            // 
            this.tbDimensionD.Location = new System.Drawing.Point(57, 182);
            this.tbDimensionD.Name = "tbDimensionD";
            this.tbDimensionD.Size = new System.Drawing.Size(100, 20);
            this.tbDimensionD.TabIndex = 11;
            this.tbDimensionD.Text = "3102";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "D:";
            // 
            // tbDimensionE
            // 
            this.tbDimensionE.Location = new System.Drawing.Point(57, 208);
            this.tbDimensionE.Name = "tbDimensionE";
            this.tbDimensionE.Size = new System.Drawing.Size(100, 20);
            this.tbDimensionE.TabIndex = 13;
            this.tbDimensionE.Text = "2041";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "E:";
            // 
            // tbDimensionF
            // 
            this.tbDimensionF.Location = new System.Drawing.Point(57, 234);
            this.tbDimensionF.Name = "tbDimensionF";
            this.tbDimensionF.Size = new System.Drawing.Size(100, 20);
            this.tbDimensionF.TabIndex = 15;
            this.tbDimensionF.Text = "3104";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "F:";
            // 
            // tbDimensionG
            // 
            this.tbDimensionG.Location = new System.Drawing.Point(57, 260);
            this.tbDimensionG.Name = "tbDimensionG";
            this.tbDimensionG.Size = new System.Drawing.Size(100, 20);
            this.tbDimensionG.TabIndex = 17;
            this.tbDimensionG.Text = "1734";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "G:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Perfis";
            // 
            // cbBeamSection
            // 
            this.cbBeamSection.FormattingEnabled = true;
            this.cbBeamSection.Location = new System.Drawing.Point(304, 104);
            this.cbBeamSection.Name = "cbBeamSection";
            this.cbBeamSection.Size = new System.Drawing.Size(121, 21);
            this.cbBeamSection.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(222, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Viga";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Pernas";
            // 
            // cbPipeSection
            // 
            this.cbPipeSection.FormattingEnabled = true;
            this.cbPipeSection.Location = new System.Drawing.Point(304, 130);
            this.cbPipeSection.Name = "cbPipeSection";
            this.cbPipeSection.Size = new System.Drawing.Size(121, 21);
            this.cbPipeSection.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(223, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Truques";
            // 
            // cbWheelBeamSection
            // 
            this.cbWheelBeamSection.FormattingEnabled = true;
            this.cbWheelBeamSection.Location = new System.Drawing.Point(304, 156);
            this.cbWheelBeamSection.Name = "cbWheelBeamSection";
            this.cbWheelBeamSection.Size = new System.Drawing.Size(121, 21);
            this.cbWheelBeamSection.TabIndex = 24;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(34, 324);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "Status:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 298);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Divisoes das pernas (max. 15 divisões):";
            // 
            // nupNumericDivision
            // 
            this.nupNumericDivision.Location = new System.Drawing.Point(232, 296);
            this.nupNumericDivision.Name = "nupNumericDivision";
            this.nupNumericDivision.Size = new System.Drawing.Size(120, 20);
            this.nupNumericDivision.TabIndex = 27;
            this.nupNumericDivision.ValueChanged += new System.EventHandler(this.nupNumericDivision_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(223, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Travamentos";
            // 
            // cbColumnBracket
            // 
            this.cbColumnBracket.FormattingEnabled = true;
            this.cbColumnBracket.Location = new System.Drawing.Point(304, 182);
            this.cbColumnBracket.Name = "cbColumnBracket";
            this.cbColumnBracket.Size = new System.Drawing.Size(121, 21);
            this.cbColumnBracket.TabIndex = 29;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materiaisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(496, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // materiaisToolStripMenuItem
            // 
            this.materiaisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarNovoMaterialToolStripMenuItem});
            this.materiaisToolStripMenuItem.Name = "materiaisToolStripMenuItem";
            this.materiaisToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.materiaisToolStripMenuItem.Text = "Materiais";
            // 
            // adicionarNovoMaterialToolStripMenuItem
            // 
            this.adicionarNovoMaterialToolStripMenuItem.Name = "adicionarNovoMaterialToolStripMenuItem";
            this.adicionarNovoMaterialToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.adicionarNovoMaterialToolStripMenuItem.Text = "Adicionar novo material";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 371);
            this.Controls.Add(this.cbColumnBracket);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nupNumericDivision);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cbWheelBeamSection);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbPipeSection);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbBeamSection);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbDimensionG);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbDimensionF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbDimensionE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbDimensionD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbDimensionC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDimensionB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDimensionA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.tbLiftingLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupNumericDivision)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLiftingLoad;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDimensionA;
        private System.Windows.Forms.TextBox tbDimensionB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDimensionC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDimensionD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDimensionE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDimensionF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDimensionG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBeamSection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbPipeSection;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbWheelBeamSection;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nupNumericDivision;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbColumnBracket;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem materiaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarNovoMaterialToolStripMenuItem;
    }
}

