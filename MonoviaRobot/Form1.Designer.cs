namespace MonoviaRobot
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
            this.planesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFrameHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFrameSpam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFrameOffset = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.planesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantidade de porticos:";
            // 
            // planesNumericUpDown
            // 
            this.planesNumericUpDown.Location = new System.Drawing.Point(173, 53);
            this.planesNumericUpDown.Name = "planesNumericUpDown";
            this.planesNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.planesNumericUpDown.TabIndex = 1;
            this.planesNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.planesNumericUpDown.ValueChanged += new System.EventHandler(this.planesNumericUpDown_ValueChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(464, 299);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(106, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Altura do pórtico (mm)";
            // 
            // tbFrameHeight
            // 
            this.tbFrameHeight.Location = new System.Drawing.Point(173, 79);
            this.tbFrameHeight.Name = "tbFrameHeight";
            this.tbFrameHeight.Size = new System.Drawing.Size(120, 20);
            this.tbFrameHeight.TabIndex = 4;
            this.tbFrameHeight.Text = "5400";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vão do pórtico (mm)";
            // 
            // tbFrameSpam
            // 
            this.tbFrameSpam.Location = new System.Drawing.Point(173, 105);
            this.tbFrameSpam.Name = "tbFrameSpam";
            this.tbFrameSpam.Size = new System.Drawing.Size(120, 20);
            this.tbFrameSpam.TabIndex = 6;
            this.tbFrameSpam.Text = "3600";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Distância entre pórticos (mm)";
            // 
            // tbFrameOffset
            // 
            this.tbFrameOffset.Location = new System.Drawing.Point(193, 131);
            this.tbFrameOffset.Name = "tbFrameOffset";
            this.tbFrameOffset.Size = new System.Drawing.Size(100, 20);
            this.tbFrameOffset.TabIndex = 8;
            this.tbFrameOffset.Text = "4000";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 350);
            this.Controls.Add(this.tbFrameOffset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFrameSpam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFrameHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.planesNumericUpDown);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Monovias Robot";
            ((System.ComponentModel.ISupportInitialize)(this.planesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown planesNumericUpDown;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFrameHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFrameSpam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFrameOffset;
    }
}

