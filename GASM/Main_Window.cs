using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GASM_Library;

namespace GASM
{
    public partial class Main_Window : Form
    {
        private Source asmFile;

        private bool fileLoaded;

        public Main_Window()
        {
            InitializeComponent();
            this.fileLoaded = false;
        }

        private void asmButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GASM assembly (*.asm)|*.asm|All files (*.*)|*.*";
            DialogResult clickedOk = ofd.ShowDialog();
            if (clickedOk == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    AsmParser P = new AsmParser(
                        sr,
                        new TranslationUnit { fileName = ofd.FileName },
                        DefaultParserOptions.options);
                    this.asmFile = P.parse();
                    this.fileLoaded = true;
                }
            }
        }

        private void saveExeButton_Click(object sender, EventArgs e)
        {
            if (!this.fileLoaded)
            {
                MessageBox.Show("No assembly file loaded",
                    "Error saving exe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "GASM Executable (*.o)|*.o|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                DialogResult sfdResult = sfd.ShowDialog();
                if (sfdResult == System.Windows.Forms.DialogResult.OK)
                {
                    using (BinaryWriter bw =
                        new BinaryWriter(File.Open(sfd.FileName, FileMode.Create)))
                    {
                        ObjectFile.writeBinary(this.asmFile, bw);
                    }
                }
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
