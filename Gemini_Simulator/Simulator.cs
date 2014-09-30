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

namespace Gemini_Simulator
{
    public partial class Simulator : Form
    {
        private CPU cpu;
        private Memory objFile;

        public Simulator()
        {
            InitializeComponent();
            cpu = new CPU();
        }

        public void updateRegisters()
        {
            accRegText.Text = cpu.registers.acc.ToString();
            pcRegText.Text = cpu.registers.PC.ToString();
        }

        private void loadObj_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GASM executable (*.o)|*.o|All files (*.*)|*.*";
            DialogResult clickedOk = ofd.ShowDialog();
            try
            {
                if (clickedOk == System.Windows.Forms.DialogResult.OK)
                {
                    using (BinaryReader br =
                        new BinaryReader(File.Open(ofd.FileName, FileMode.Open)))
                    {
                        objFile = ObjectFile.readBinary(br);
                        cpu = new CPU(objFile);
                    }
                    updateRegisters();
                }
            }
            catch (ObjectFileReaderException ex)
            {
                MessageBox.Show(ex.Message,
                    "Error reading object file",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (InvalidOpcodeException ex)
            {
                MessageBox.Show(ex.Message,
                    "Error reading object file",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Unknown Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stepButton_Click(object sender, EventArgs e)
        {

            
            cpu.step();
            updateRegisters();
        }
    }
}
