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
            accRegText.Text = String.Format("0x{0,8:X8}",cpu.registers.acc.val);
            pcRegText.Text = String.Format("0x{0,8:X8}", cpu.registers.PC.val);
            ARegText.Text = String.Format("0x{0,8:X8}", cpu.registers.a);
            BRegText.Text = String.Format("0x{0,8:X8}", cpu.registers.b);
            MARRegText.Text = String.Format("0x{0,8:X8}", cpu.registers.mar.val);
            MDRRegText.Text = String.Format("0x{0,8:X8}", cpu.registers.mdr.val);
            IRRegText.Text = String.Format("0x{0,8:X8}", cpu.registers.IR.val);
            CCRegText.Text = String.Format("0x{0,8:X8}", cpu.registers.CC.val);
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

            try
            {
                cpu.step();
            }
            catch (Memory.MemoryException ex)
            {
                string msg = "Error while access memory at address " + ex.addr;
                MessageBox.Show(msg,
                    "Memory access error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            updateRegisters();
        }
    }
}
