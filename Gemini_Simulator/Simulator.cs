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
        private string objFileName = "";

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

            if (cpu.registers.IFStallCount.val > 0)
            {
                IFStageLabel.Text="NOP";
            } else
            {
                IFStageLabel.Text = (new BinInstr(cpu.code.peek(cpu.registers.PC.val))).prettyPrint();
            }
            if (cpu.registers.IDStallCount.val > 0)
            {
                IDStageLabel.Text="NOP";
            } else
            {
                IDStageLabel.Text=(new BinInstr((UInt16)cpu.registers.IR.val)).prettyPrint();
            }
            if(cpu.registers.EXStallCount.val>0)
            {
                EXStageLabel.Text="NOP";
            } else
            {
                EXStageLabel.Text=cpu.registers.EXInput.val.prettyPrint();
            }
            if (cpu.registers.WBStallCount.val > 0)
            {
                WBStageLabel.Text="NOP";
            } else
            {
                WBStageLabel.Text=cpu.registers.WBInput.val.prettyPrint();
            }
            

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
            scrollIx = (scrollIx > CodeGrid.RowCount-1) ? CodeGrid.RowCount-1 : scrollIx;
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

        private bool loadObjectFile(String fileName)
        {
            try
            {
                using (BinaryReader br =
                    new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    objFile = ObjectFile.readBinary(br);
                    CPUOptions cpuOptions = new CPUOptions();
                    
                    if (noCacheButton.Checked)
                    {
                        cpuOptions.dataMemory = new Memory(256);
                    }
                    else if (directMapButton.Checked)
                    {
                        uint blockSize = UInt32.Parse(blockSizeBox.Text);
                        uint cacheSize = UInt32.Parse(cacheSizeBox.Text);
                        cpuOptions.dataMemory = new DirectMapCache(256, blockSize, cacheSize);
                    }
                    else if (twoWayAssocButton.Checked)
                    {
                        uint blockSize = UInt32.Parse(blockSizeBox.Text);
                        uint cacheSize = UInt32.Parse(cacheSizeBox.Text);
                        cpuOptions.dataMemory = new TwoWayCache(256, blockSize, cacheSize);
                    }
                    cpu.tearDown();
                    cpu = new CPU(objFile, cpuOptions);

                    initMemoryGrid();
                    initCacheDisplay();
                }
                updateRegisters();
                MethodInvoker handler = CPUCycleComplete;
                cpu.onFinishedCycle += (sender, args) => stepButton.BeginInvoke(handler);
                //cpu.onFinishedCycle += new CPU.CPUCycleFinishedHandler(CPUCycleComplete);

                return true;
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
            return false;
        }

        private void CPUCycleComplete()
        {
            updateRegisters();
            stepButton.Enabled = true;
        }

        private void loadObj_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GASM executable (*.o)|*.o|All files (*.*)|*.*";
            DialogResult clickedOk = ofd.ShowDialog();
            if (clickedOk == System.Windows.Forms.DialogResult.OK)
            {
                if (loadObjectFile(ofd.FileName))
                {
                    this.objFileName = ofd.FileName;
                }
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            cpu.tearDown();
            Application.Exit();
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            cpu.step();
            stepButton.Enabled = false;
        }

        private void runToEndButton_Click(object sender, EventArgs e)
        {
            while (!cpu.registers.halt)
            {
                cpu.step();
                updateRegisters();
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

        private void reloadButton_Click(object sender, EventArgs e)
        {
            if (this.objFileName != "")
            {
                loadObjectFile(this.objFileName);
            }
        }
    }
}
