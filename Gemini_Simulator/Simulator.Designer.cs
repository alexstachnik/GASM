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
            this.CCRegText = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.IRRegText = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TEMPRegText = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.MDRRegText = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.MARRegText = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BRegText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ARegText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pcRegText = new System.Windows.Forms.Label();
            this.accRegText = new System.Windows.Forms.Label();
            this.PCText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.runToEndButton = new System.Windows.Forms.Button();
            this.MemoryGrid = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeGrid = new System.Windows.Forms.DataGridView();
            this.CurInstr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstrAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstrText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cacheGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cacheSizeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.blockSizeBox = new System.Windows.Forms.TextBox();
            this.twoWayAssocButton = new System.Windows.Forms.RadioButton();
            this.directMapButton = new System.Windows.Forms.RadioButton();
            this.noCacheButton = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.cacheStatusLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cacheHitsLabel = new System.Windows.Forms.Label();
            this.cacheMissesLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemoryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeGrid)).BeginInit();
            this.cacheGroupBox.SuspendLayout();
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
            // pcRegText
            // 
            this.pcRegText.AutoSize = true;
            this.pcRegText.Location = new System.Drawing.Point(50, 16);
            this.pcRegText.Name = "pcRegText";
            this.pcRegText.Size = new System.Drawing.Size(66, 13);
            this.pcRegText.TabIndex = 3;
            this.pcRegText.Text = "0x00000000";
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
            // PCText
            // 
            this.PCText.AutoSize = true;
            this.PCText.Location = new System.Drawing.Point(18, 16);
            this.PCText.Name = "PCText";
            this.PCText.Size = new System.Drawing.Size(24, 13);
            this.PCText.TabIndex = 2;
            this.PCText.Text = "PC:";
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
            this.quitButton.Location = new System.Drawing.Point(621, 12);
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
            // runToEndButton
            // 
            this.runToEndButton.Location = new System.Drawing.Point(75, 272);
            this.runToEndButton.Name = "runToEndButton";
            this.runToEndButton.Size = new System.Drawing.Size(75, 23);
            this.runToEndButton.TabIndex = 4;
            this.runToEndButton.Text = "Run To End";
            this.runToEndButton.UseVisualStyleBackColor = true;
            this.runToEndButton.Click += new System.EventHandler(this.runToEndButton_Click);
            // 
            // MemoryGrid
            // 
            this.MemoryGrid.AllowUserToAddRows = false;
            this.MemoryGrid.AllowUserToDeleteRows = false;
            this.MemoryGrid.AllowUserToResizeColumns = false;
            this.MemoryGrid.AllowUserToResizeRows = false;
            this.MemoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Value});
            this.MemoryGrid.Location = new System.Drawing.Point(160, 41);
            this.MemoryGrid.Name = "MemoryGrid";
            this.MemoryGrid.ReadOnly = true;
            this.MemoryGrid.RowHeadersVisible = false;
            this.MemoryGrid.RowHeadersWidth = 45;
            this.MemoryGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MemoryGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MemoryGrid.Size = new System.Drawing.Size(104, 214);
            this.MemoryGrid.TabIndex = 5;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Address.Width = 50;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Value.Width = 50;
            // 
            // CodeGrid
            // 
            this.CodeGrid.AllowUserToAddRows = false;
            this.CodeGrid.AllowUserToDeleteRows = false;
            this.CodeGrid.AllowUserToResizeColumns = false;
            this.CodeGrid.AllowUserToResizeRows = false;
            this.CodeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CodeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurInstr,
            this.InstrAddr,
            this.InstrText});
            this.CodeGrid.Location = new System.Drawing.Point(280, 41);
            this.CodeGrid.Name = "CodeGrid";
            this.CodeGrid.ReadOnly = true;
            this.CodeGrid.RowHeadersVisible = false;
            this.CodeGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CodeGrid.Size = new System.Drawing.Size(216, 150);
            this.CodeGrid.TabIndex = 6;
            // 
            // CurInstr
            // 
            this.CurInstr.HeaderText = "";
            this.CurInstr.Name = "CurInstr";
            this.CurInstr.ReadOnly = true;
            this.CurInstr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurInstr.Width = 20;
            // 
            // InstrAddr
            // 
            this.InstrAddr.HeaderText = "Address";
            this.InstrAddr.Name = "InstrAddr";
            this.InstrAddr.ReadOnly = true;
            this.InstrAddr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InstrAddr.Width = 50;
            // 
            // InstrText
            // 
            this.InstrText.HeaderText = "Instruction";
            this.InstrText.Name = "InstrText";
            this.InstrText.ReadOnly = true;
            this.InstrText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InstrText.Width = 150;
            // 
            // cacheGroupBox
            // 
            this.cacheGroupBox.Controls.Add(this.label4);
            this.cacheGroupBox.Controls.Add(this.cacheSizeBox);
            this.cacheGroupBox.Controls.Add(this.label2);
            this.cacheGroupBox.Controls.Add(this.blockSizeBox);
            this.cacheGroupBox.Controls.Add(this.twoWayAssocButton);
            this.cacheGroupBox.Controls.Add(this.directMapButton);
            this.cacheGroupBox.Controls.Add(this.noCacheButton);
            this.cacheGroupBox.Location = new System.Drawing.Point(280, 195);
            this.cacheGroupBox.Name = "cacheGroupBox";
            this.cacheGroupBox.Size = new System.Drawing.Size(265, 89);
            this.cacheGroupBox.TabIndex = 7;
            this.cacheGroupBox.TabStop = false;
            this.cacheGroupBox.Text = "Cache Options (Requires Reload to Change)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cache Size:";
            // 
            // cacheSizeBox
            // 
            this.cacheSizeBox.Location = new System.Drawing.Point(222, 40);
            this.cacheSizeBox.Name = "cacheSizeBox";
            this.cacheSizeBox.Size = new System.Drawing.Size(26, 20);
            this.cacheSizeBox.TabIndex = 5;
            this.cacheSizeBox.Text = "2";
            this.cacheSizeBox.Validating += new System.ComponentModel.CancelEventHandler(this.cacheSizeBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Block Size:";
            // 
            // blockSizeBox
            // 
            this.blockSizeBox.Location = new System.Drawing.Point(222, 12);
            this.blockSizeBox.Name = "blockSizeBox";
            this.blockSizeBox.Size = new System.Drawing.Size(26, 20);
            this.blockSizeBox.TabIndex = 3;
            this.blockSizeBox.Text = "1";
            this.blockSizeBox.Validating += new System.ComponentModel.CancelEventHandler(this.blockSizeBox_Validating);
            // 
            // twoWayAssocButton
            // 
            this.twoWayAssocButton.AutoSize = true;
            this.twoWayAssocButton.Location = new System.Drawing.Point(7, 50);
            this.twoWayAssocButton.Name = "twoWayAssocButton";
            this.twoWayAssocButton.Size = new System.Drawing.Size(113, 17);
            this.twoWayAssocButton.TabIndex = 2;
            this.twoWayAssocButton.TabStop = true;
            this.twoWayAssocButton.Text = "2-Way Associative";
            this.twoWayAssocButton.UseVisualStyleBackColor = true;
            // 
            // directMapButton
            // 
            this.directMapButton.AutoSize = true;
            this.directMapButton.Location = new System.Drawing.Point(7, 32);
            this.directMapButton.Name = "directMapButton";
            this.directMapButton.Size = new System.Drawing.Size(95, 17);
            this.directMapButton.TabIndex = 1;
            this.directMapButton.TabStop = true;
            this.directMapButton.Text = "Direct Mapped";
            this.directMapButton.UseVisualStyleBackColor = true;
            // 
            // noCacheButton
            // 
            this.noCacheButton.AutoSize = true;
            this.noCacheButton.Checked = true;
            this.noCacheButton.Location = new System.Drawing.Point(7, 15);
            this.noCacheButton.Name = "noCacheButton";
            this.noCacheButton.Size = new System.Drawing.Size(73, 17);
            this.noCacheButton.TabIndex = 0;
            this.noCacheButton.TabStop = true;
            this.noCacheButton.Text = "No Cache";
            this.noCacheButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(514, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cache Status:";
            // 
            // cacheStatusLabel
            // 
            this.cacheStatusLabel.AutoSize = true;
            this.cacheStatusLabel.Location = new System.Drawing.Point(595, 74);
            this.cacheStatusLabel.Name = "cacheStatusLabel";
            this.cacheStatusLabel.Size = new System.Drawing.Size(27, 13);
            this.cacheStatusLabel.TabIndex = 9;
            this.cacheStatusLabel.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(524, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Cache Hits:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(510, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Cache Misses:";
            // 
            // cacheHitsLabel
            // 
            this.cacheHitsLabel.AutoSize = true;
            this.cacheHitsLabel.Location = new System.Drawing.Point(598, 91);
            this.cacheHitsLabel.Name = "cacheHitsLabel";
            this.cacheHitsLabel.Size = new System.Drawing.Size(13, 13);
            this.cacheHitsLabel.TabIndex = 12;
            this.cacheHitsLabel.Text = "0";
            // 
            // cacheMissesLabel
            // 
            this.cacheMissesLabel.AutoSize = true;
            this.cacheMissesLabel.Location = new System.Drawing.Point(598, 111);
            this.cacheMissesLabel.Name = "cacheMissesLabel";
            this.cacheMissesLabel.Size = new System.Drawing.Size(13, 13);
            this.cacheMissesLabel.TabIndex = 13;
            this.cacheMissesLabel.Text = "0";
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 307);
            this.Controls.Add(this.cacheMissesLabel);
            this.Controls.Add(this.cacheHitsLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cacheStatusLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cacheGroupBox);
            this.Controls.Add(this.CodeGrid);
            this.Controls.Add(this.MemoryGrid);
            this.Controls.Add(this.runToEndButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loadObj);
            this.Name = "Simulator";
            this.Text = "Gemini Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemoryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeGrid)).EndInit();
            this.cacheGroupBox.ResumeLayout(false);
            this.cacheGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button runToEndButton;
        private System.Windows.Forms.DataGridView MemoryGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridView CodeGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurInstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrText;
        private System.Windows.Forms.GroupBox cacheGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cacheSizeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox blockSizeBox;
        private System.Windows.Forms.RadioButton twoWayAssocButton;
        private System.Windows.Forms.RadioButton directMapButton;
        private System.Windows.Forms.RadioButton noCacheButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label cacheStatusLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label cacheHitsLabel;
        private System.Windows.Forms.Label cacheMissesLabel;
    }
}

