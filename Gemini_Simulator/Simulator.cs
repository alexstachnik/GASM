/**
 * Alexander Stachnik
 */

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

            for (int i = 0; i < cpu.data.size(); ++i)
            {
                uint val = cpu.data.peek((uint)i);
                MemoryGrid.Rows[i].Cells[1].Value = String.Format("0x{0,2:X2}", val);
            }
            for (int i=0;i<cpu.code.size();++i)
            {
                if (i == cpu.registers.PC.val)
                {
                    CodeGrid.Rows[i].Selected = true;
                    CodeGrid.Rows[i].Cells[0].Value = "->";
                }
                else
                {
                    CodeGrid.Rows[i].Selected = false;
                    CodeGrid.Rows[i].Cells[0].Value = "";
                }
            }
            CodeGrid.Focus();
            int scrollIx = (int)cpu.registers.PC.val - 1;
            scrollIx = (scrollIx < 0) ? 0 : scrollIx;
            CodeGrid.FirstDisplayedScrollingRowIndex = scrollIx;

            cacheStatusLabel.Text = "";
            if (cpu.data.hitCache())
            {
                cacheStatusLabel.Text = "Cache Hit";
                cacheHitsCount++;
                cacheHitsLabel.Text = cacheHitsCount.ToString();
            }
            if (cpu.data.missedCache())
            {
                cacheStatusLabel.Text = "Cache Missed";
                cacheMissesCount++;
                cacheMissesLabel.Text = cacheMissesCount.ToString();
            }
            cpu.data.clearHitMissFlags();
        }

        private void initMemoryGrid()
        {
            MemoryGrid.Rows.Clear();
            CodeGrid.Rows.Clear();
            for (int i = 0; i < cpu.data.size(); ++i)
            {
                string addr,val;
                addr = String.Format("0x{0,2:X2}", i);
                val = "0x00";
                string[] row={addr,val};
                MemoryGrid.Rows.Add(row);
            }
       
            for (int i=0;i<cpu.code.size();++i)
            {
                string ptr, addr, val;
                ptr = (i==0) ? "->" : "";
                addr = String.Format("0x{0,2:X2}", i);
                BinInstr ins = new BinInstr(cpu.code.peek((uint)i));
                val = ins.prettyPrint();
                string[] row = { ptr, addr, val };
                CodeGrid.Rows.Add(row);
            }
        }

        private int cacheMissesCount;
        private int cacheHitsCount;

        private void initCacheDisplay()
        {
            cacheStatusLabel.Text = "";
            cacheMissesLabel.Text = "0";
            cacheMissesCount = 0;
            cacheHitsLabel.Text = "0";
            cacheHitsCount = 0;
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

                        if (noCacheButton.Checked)
                        {
                            cpu = new CPU(objFile, new Memory(256));
                        }
                        else if (directMapButton.Checked)
                        {
                            uint blockSize = UInt32.Parse(blockSizeBox.Text);
                            uint cacheSize = UInt32.Parse(cacheSizeBox.Text);
                            cpu = new CPU(objFile, new DirectMapCache(256,blockSize,cacheSize));
                        }
                        else if (twoWayAssocButton.Checked)
                        {
                            uint blockSize = UInt32.Parse(blockSizeBox.Text);
                            uint cacheSize = UInt32.Parse(cacheSizeBox.Text);
                            cpu = new CPU(objFile, new TwoWayCache(256, blockSize, cacheSize));
                        }
                        
                        initMemoryGrid();
                        initCacheDisplay();
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
            catch (MemoryException ex)
            {
                string msg = "Error while access memory at address " + ex.addr;
                MessageBox.Show(msg,
                    "Memory access error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            updateRegisters();
        }

        private void runToEndButton_Click(object sender, EventArgs e)
        {
            try
            {
                while (!cpu.registers.halt)
                {
                    cpu.step();
                    updateRegisters();
                }
                
            }
            catch (MemoryException ex)
            {
                string msg = "Error while access memory at address " + ex.addr;
                MessageBox.Show(msg,
                    "Memory access error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void blockSizeBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int n = Int32.Parse(blockSizeBox.Text);
                if (n > 2 || n < 1)
                {
                    blockSizeBox.Text = "1";
                }
            }
            catch (FormatException)
            {
                blockSizeBox.Text = "1";
            }
            catch (OverflowException)
            {
                blockSizeBox.Text = "1";
            }

        }

        private void cacheSizeBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int n = Int32.Parse(cacheSizeBox.Text);
                if (n > 16 || n < 2)
                {
                    cacheSizeBox.Text = "2";
                }
            }
            catch (FormatException)
            {
                cacheSizeBox.Text = "2";
            }
            catch (OverflowException)
            {
                cacheSizeBox.Text = "2";
            }
        }
    }
}
