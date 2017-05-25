using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Icebox
{
    public partial class IceboxForm : Form
    {
        private Page page;
        private Memory memory;
        private PagingController pagingController;
        private Thread UIController;
        Thread operation;

        private int[] criticalData;

        public IceboxForm()
        {
            criticalData = new int[3];
            InitializeComponent();
            initializeData();

            UIController = new Thread(new ThreadStart(UIControl));
            UIController.Start();
        }

        public void UIControl()
        {
            try
            {
                while (true)
                {
                    if(pagingController != null)
                    {
                        double pagingFaultRate = 1.0 * pagingController.getPagingFaults() / pagingController.getNowIndex() * 100;
                        labels[0].Text = "Paging Fault Rate: " + pagingFaultRate.ToString() + '%';
                        double process = pagingController.getNowIndex() * 1.0 / criticalData[0] / criticalData[1] * 100;
                        labels[1].Text = "Process: " + process.ToString() + '%';

                        for (int i = 0; i < criticalData[2]; ++i)
                        {
                            MemoryBlock tempBlock = memory.readMemory(i);
                            if (tempBlock != null && pictureBoxes[i]　!= null)
                            {
                                pictureBoxes[i].Text = "Instruction: " + tempBlock.getInstruction().ToString();
                                pictureBoxes[i].BackColor = Color.AliceBlue;
                            }
                        }
                    }
                    
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void initializeData()
        {
            criticalData[0] = 32;
            criticalData[1] = 10;
            criticalData[2] = 4;

            for (int i = 0; i < 3; ++i)
            {
                textBoxes[i].Text = criticalData[i].ToString();
            }
            createMemoryBlocks();
            //operate();
        }

        private void operate()
        {
            page = new Page(criticalData[0], criticalData[1]);
            memory = new Memory(criticalData[2]);
            pagingController = new PagingController(criticalData[0], criticalData[1], criticalData[2]);
            pagingController.setSlowingStatus(_slow);
            pagingController.operateLeastRecentlyUsedAlgorithm(page, ref memory);

            buttons[0].Text = "Run";
            enableInput();
        }

        void createMemoryBlocks()
        {
            if (this.pictureBoxes != null)
            {
                for (int i = 0; i < pictureBoxes.GetLength(0); ++i)
                {
                    this.Controls.Remove(pictureBoxes[i]);
                    //pictureBoxes[i].Dispose();
                    /*foreach (Control item in this.Controls)
                    {
                        if (item is PictureBox && item.Name.Equals(pictureBoxes[i].Name))
                        {
                            this.Controls.Remove(item);
                        }
                    }*/
                    pictureBoxes[i] = null;
                }
            }
            int rate = 900 / criticalData[2];
            this.pictureBoxes = new System.Windows.Forms.Label[criticalData[2]];
            for (int i = 0; i < criticalData[2]; ++i)
            {
                this.pictureBoxes[i] = new System.Windows.Forms.Label();
                this.pictureBoxes[i].Location = new Point(220 + i * rate, 50);
                this.pictureBoxes[i].Text = "MemoryBlock" + i.ToString();
                this.pictureBoxes[i].Name = "MemoryBlock" + i.ToString();
                this.pictureBoxes[i].Size = new System.Drawing.Size((int)(rate * 0.9), 110);
                this.pictureBoxes[i].BackColor = System.Drawing.Color.White;
                this.Controls.Add(pictureBoxes[i]);
                this.pictureBoxes[i].BringToFront();
            }
        }

        private void enableInput()
        {
            for (int i = 0; i < 3; ++i)
            {
                textBoxes[i].ReadOnly = false;
            }
        }

        private void disableInput()
        {
            for (int i = 0; i < 3; ++i)
            {
                textBoxes[i].ReadOnly = true;
            }
        }

        private void confirmButtonClick(object sender, EventArgs e)
        {
            if (textBoxes[0].Text.Length + textBoxes[1].Text.Length > 8)
            {
                MessageBox.Show("The data is too big to analyse in a short time(Number of pages times number of instructions in each page should not exceed 99999999).");
                return;
            }
            if (Convert.ToInt32(textBoxes[2].Text) > 32)
            {
                MessageBox.Show("Too many memory blocks are placed(No more than 32 blocks is admitted).");
                return;
            }
            if (((Button)sender).Text == "Run")
            {
                disableInput();
                for (int i = 0; i < 3; ++i)
                {
                    criticalData[i] = Convert.ToInt32(textBoxes[i].Text);
                }
                buttons[0].Text = "Pause";
                createMemoryBlocks();
                operation = new Thread(new ThreadStart(operate));
                operation.Start();
            }
            else if (((Button)sender).Text == "Pause")
            {
                buttons[0].Text = "Resume";
                operation.Suspend();
            }
            else if (((Button)sender).Text == "Resume")
            {
                buttons[0].Text = "Pause";
                operation.Resume();
            }
        }

        private void cancelButtonClick(object sender, EventArgs e)
        {
            if (operation == null)
            {
                MessageBox.Show("The calculation is not being proceeded!");
            }
            else if (operation.IsAlive)
            {
                //MessageBox.Show("testing2");
                operation.Abort();
                buttons[0].Text = "Run";
                enableInput();
            }
        }

        private void slowDownButtonClick(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Slowdown")
            {
                _slow = true;
                slowDownButton.Text = "Speedup";
            }
            else
            {
                _slow = false;
                slowDownButton.Text = "Slowdown";
            }
            if (pagingController != null)
            {
                pagingController.setSlowingStatus(_slow);
            }
        }

        private void inputControl(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (((TextBox)sender).Text.Length == 0 && (e.KeyChar <= '0' || e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar < '0' || e.KeyChar > '9')
                {
                    e.Handled = true;
                }
                if (((TextBox)sender).Text.Length >= 6)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
