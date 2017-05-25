namespace Icebox
{
    partial class IceboxForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            int tabIndex = 0;
            this.pictureBoxes = null;
            this.textBoxes = new System.Windows.Forms.TextBox[3];
            this.buttons = new System.Windows.Forms.Button[2];
            this.labels = new System.Windows.Forms.Label[5];
            this.slowDownButton = new System.Windows.Forms.Button();
            for (int i = 0; i < 3; ++i)
            {
                textBoxes[i] = new System.Windows.Forms.TextBox();
            }
            for (int i = 0; i < 2; ++i)
            {
                buttons[i] = new System.Windows.Forms.Button();
            }
            for (int i = 0; i < 5; ++i)
            {
                labels[i] = new System.Windows.Forms.Label();
            }
            this.SuspendLayout();

            // 
            // textBoxes
            // 
            for (int i = 0; i < 3; ++i)
            {
                this.textBoxes[i].Location = new System.Drawing.Point(100, 40 + i * 70);
                this.textBoxes[i].Name = "TestTextBox" + i.ToString();
                this.textBoxes[i].Text = "TestTextBox" + i.ToString();
                this.textBoxes[i].Size = new System.Drawing.Size(100, 25);
                this.textBoxes[i].TabIndex = tabIndex++;
                this.textBoxes[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputControl);
            }
            // 
            // buttons
            //
            for (int i = 0; i < 2; ++i)
            {
                this.buttons[i].Location = new System.Drawing.Point(10, 80 + i * 60);
                this.buttons[i].Name = "TEST";
                this.buttons[i].Text = "TEST";
                this.buttons[i].TabIndex = tabIndex++;
                this.buttons[i].Size = new System.Drawing.Size(60, 50);
            }
            this.buttons[0].Text = "Run";
            this.buttons[1].Text = "Stop";
            this.buttons[0].Click += new System.EventHandler(this.confirmButtonClick);
            this.buttons[1].Click += new System.EventHandler(this.cancelButtonClick);
            //
            // labels
            //
            this.labels[0].Location = new System.Drawing.Point(1200,220);
            this.labels[0].Name = "pagingFaultRate";
            this.labels[0].Text = "Paging Fault Rate:";
            this.labels[0].Size = new System.Drawing.Size(2000, 400);
            this.labels[0].BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            this.labels[1].Location = new System.Drawing.Point(780, 20);
            this.labels[1].Name = "procedure";
            this.labels[1].Text = "Process:";
            this.labels[1].Size = new System.Drawing.Size(2000, 400);
            this.labels[1].BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            this.labels[2].Location = new System.Drawing.Point(100, 20);
            this.labels[2].Name = "Number of pages";
            this.labels[2].Text = "Number of pages:";
            this.labels[2].Size = new System.Drawing.Size(150, 20);
            this.labels[2].BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            this.labels[3].Location = new System.Drawing.Point(100, 75);
            this.labels[3].Name = "Number of instructions in each page";
            this.labels[3].Text = "Number of instructions in each page:";
            this.labels[3].Size = new System.Drawing.Size(190, 50);
            this.labels[3].BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            this.labels[4].Location = new System.Drawing.Point(100, 145);
            this.labels[4].Name = "Number of memory blocks";
            this.labels[4].Text = "Number of memory blocks:";
            this.labels[4].Size = new System.Drawing.Size(170, 100);
            this.labels[4].BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            //
            // SlowDownButton
            //
            this.slowDownButton.Location = new System.Drawing.Point(700, 10);
            this.slowDownButton.Name = "SlowDownButton";
            this.slowDownButton.Text = "Slowdown";
            this.slowDownButton.TabIndex = tabIndex++;
            this.slowDownButton.Size = new System.Drawing.Size(70, 50);
            this.slowDownButton.Click += new System.EventHandler(this.slowDownButtonClick);
            _slow = false;
            //
            // IceboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 250);
            for (int i = 0; i < 3; ++i)
            {
                this.Controls.Add(textBoxes[i]);
            }
            for (int i = 0; i < 2; ++i)
            {
                this.Controls.Add(buttons[i]);
            }
            for (int i = 0; i < 5; ++i)
            {
                this.Controls.Add(labels[i]);
            }
            this.Controls.Add(slowDownButton);
            this.Name = "IceboxForm";
            this.Text = "Icebox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label[] pictureBoxes;
        private System.Windows.Forms.TextBox[] textBoxes;
        private System.Windows.Forms.Button[] buttons;
        private System.Windows.Forms.Label[] labels;
        private System.Windows.Forms.Button slowDownButton;
        private bool _slow;
    }
}

