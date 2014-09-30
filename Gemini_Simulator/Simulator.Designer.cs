namespace Gemini_Simulator
{
    partial class Simulator
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
            this.loadObj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pcRegText = new System.Windows.Forms.Label();
            this.PCText = new System.Windows.Forms.Label();
            this.accRegText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.ARegText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BRegText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.MARRegText = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MDRRegText = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TEMPRegText = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.IRRegText = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.CCRegText = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadObj
            // 
            this.loadObj.Location = new System.Drawing.Point(12, 12);
            this.loadObj.Name = "loadObj";
            this.loadObj.Size = new System.Drawing.Size(75, 23);
            this.loadObj.TabIndex = 0;
            this.loadObj.Text = "Load File";
            this.loadObj.UseVisualStyleBackColor = true;
            this.loadObj.Click += new System.EventHandler(this.loadObj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CCRegText);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.IRRegText);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.TEMPRegText);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.MDRRegText);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.MARRegText);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BRegText);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ARegText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pcRegText);
            this.groupBox1.Controls.Add(this.accRegText);
            this.groupBox1.Controls.Add(this.PCText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 214);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers";
            // 
            // pcRegText
            // 
            this.pcRegText.AutoSize = true;
            this.pcRegText.Location = new System.Drawing.Point(50, 16);
            this.pcRegText.Name = "pcRegText";
            this.pcRegText.Size = new System.Drawing.Size(66, 13);
            this.pcRegText.TabIndex = 3;
            this.pcRegText.Text = "0x00000000";
            // 
            // PCText
            // 
            this.PCText.AutoSize = true;
            this.PCText.Location = new System.Drawing.Point(18, 16);
            this.PCText.Name = "PCText";
            this.PCText.Size = new System.Drawing.Size(24, 13);
            this.PCText.TabIndex = 2;
            this.PCText.Text = "PC:";
            // 
            // accRegText
            // 
            this.accRegText.AutoSize = true;
            this.accRegText.Location = new System.Drawing.Point(50, 33);
            this.accRegText.Name = "accRegText";
            this.accRegText.Size = new System.Drawing.Size(66, 13);
            this.accRegText.TabIndex = 1;
            this.accRegText.Text = "0x00000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acc:";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(229, 12);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(43, 40);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(12, 272);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(56, 23);
            this.stepButton.TabIndex = 3;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // ARegText
            // 
            this.ARegText.AutoSize = true;
            this.ARegText.Location = new System.Drawing.Point(50, 50);
            this.ARegText.Name = "ARegText";
            this.ARegText.Size = new System.Drawing.Size(66, 13);
            this.ARegText.TabIndex = 5;
            this.ARegText.Text = "0x00000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "A:";
            // 
            // BRegText
            // 
            this.BRegText.AutoSize = true;
            this.BRegText.Location = new System.Drawing.Point(50, 67);
            this.BRegText.Name = "BRegText";
            this.BRegText.Size = new System.Drawing.Size(66, 13);
            this.BRegText.TabIndex = 7;
            this.BRegText.Text = "0x00000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "B:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "0x00000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Zero:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "0x00000001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "One:";
            // 
            // MARRegText
            // 
            this.MARRegText.AutoSize = true;
            this.MARRegText.Location = new System.Drawing.Point(50, 118);
            this.MARRegText.Name = "MARRegText";
            this.MARRegText.Size = new System.Drawing.Size(66, 13);
            this.MARRegText.TabIndex = 13;
            this.MARRegText.Text = "0x00000000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "MAR:";
            // 
            // MDRRegText
            // 
            this.MDRRegText.AutoSize = true;
            this.MDRRegText.Location = new System.Drawing.Point(50, 135);
            this.MDRRegText.Name = "MDRRegText";
            this.MDRRegText.Size = new System.Drawing.Size(66, 13);
            this.MDRRegText.TabIndex = 15;
            this.MDRRegText.Text = "0x00000000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "MDR:";
            // 
            // TEMPRegText
            // 
            this.TEMPRegText.AutoSize = true;
            this.TEMPRegText.Location = new System.Drawing.Point(50, 152);
            this.TEMPRegText.Name = "TEMPRegText";
            this.TEMPRegText.Size = new System.Drawing.Size(66, 13);
            this.TEMPRegText.TabIndex = 17;
            this.TEMPRegText.Text = "0x00000000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "TEMP:";
            // 
            // IRRegText
            // 
            this.IRRegText.AutoSize = true;
            this.IRRegText.Location = new System.Drawing.Point(50, 169);
            this.IRRegText.Name = "IRRegText";
            this.IRRegText.Size = new System.Drawing.Size(66, 13);
            this.IRRegText.TabIndex = 19;
            this.IRRegText.Text = "0x00000000";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 169);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "IR:";
            // 
            // CCRegText
            // 
            this.CCRegText.AutoSize = true;
            this.CCRegText.Location = new System.Drawing.Point(50, 186);
            this.CCRegText.Name = "CCRegText";
            this.CCRegText.Size = new System.Drawing.Size(66, 13);
            this.CCRegText.TabIndex = 21;
            this.CCRegText.Text = "0x00000000";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 186);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "CC:";
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 307);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loadObj);
            this.Name = "Simulator";
            this.Text = "Gemini Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadObj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label accRegText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Label pcRegText;
        private System.Windows.Forms.Label PCText;
        private System.Windows.Forms.Label CCRegText;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label IRRegText;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label TEMPRegText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label MDRRegText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label MARRegText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label BRegText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ARegText;
        private System.Windows.Forms.Label label3;
    }
}

