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
            this.accRegText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.PCText = new System.Windows.Forms.Label();
            this.pcRegText = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.pcRegText);
            this.groupBox1.Controls.Add(this.PCText);
            this.groupBox1.Controls.Add(this.accRegText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers";
            // 
            // accRegText
            // 
            this.accRegText.AutoSize = true;
            this.accRegText.Location = new System.Drawing.Point(41, 16);
            this.accRegText.Name = "accRegText";
            this.accRegText.Size = new System.Drawing.Size(66, 13);
            this.accRegText.TabIndex = 1;
            this.accRegText.Text = "0x00000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
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
            this.stepButton.Location = new System.Drawing.Point(12, 227);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(56, 23);
            this.stepButton.TabIndex = 3;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // PCText
            // 
            this.PCText.AutoSize = true;
            this.PCText.Location = new System.Drawing.Point(9, 33);
            this.PCText.Name = "PCText";
            this.PCText.Size = new System.Drawing.Size(24, 13);
            this.PCText.TabIndex = 2;
            this.PCText.Text = "PC:";
            // 
            // pcRegText
            // 
            this.pcRegText.AutoSize = true;
            this.pcRegText.Location = new System.Drawing.Point(41, 33);
            this.pcRegText.Name = "pcRegText";
            this.pcRegText.Size = new System.Drawing.Size(66, 13);
            this.pcRegText.TabIndex = 3;
            this.pcRegText.Text = "0x00000000";
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
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
    }
}

