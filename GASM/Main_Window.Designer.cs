namespace GASM
{
    partial class Main_Window
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
            this.asmButton = new System.Windows.Forms.Button();
            this.saveExeButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.fileContents = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // asmButton
            // 
            this.asmButton.Location = new System.Drawing.Point(12, 12);
            this.asmButton.Name = "asmButton";
            this.asmButton.Size = new System.Drawing.Size(113, 23);
            this.asmButton.TabIndex = 0;
            this.asmButton.Text = "Open File";
            this.asmButton.UseVisualStyleBackColor = true;
            this.asmButton.Click += new System.EventHandler(this.asmButton_Click);
            // 
            // saveExeButton
            // 
            this.saveExeButton.Location = new System.Drawing.Point(131, 12);
            this.saveExeButton.Name = "saveExeButton";
            this.saveExeButton.Size = new System.Drawing.Size(113, 23);
            this.saveExeButton.TabIndex = 2;
            this.saveExeButton.Text = "Save Executable";
            this.saveExeButton.UseVisualStyleBackColor = true;
            this.saveExeButton.Click += new System.EventHandler(this.saveExeButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(251, 11);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(42, 40);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // fileContents
            // 
            this.fileContents.Location = new System.Drawing.Point(14, 57);
            this.fileContents.Multiline = true;
            this.fileContents.Name = "fileContents";
            this.fileContents.ReadOnly = true;
            this.fileContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fileContents.Size = new System.Drawing.Size(279, 179);
            this.fileContents.TabIndex = 4;
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 262);
            this.Controls.Add(this.fileContents);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.saveExeButton);
            this.Controls.Add(this.asmButton);
            this.Name = "Main_Window";
            this.Text = "GASM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button asmButton;
        private System.Windows.Forms.Button saveExeButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.TextBox fileContents;

    }
}

