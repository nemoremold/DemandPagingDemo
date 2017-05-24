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
            System.Environment.Exit(0);
            UIController.Abort();
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            int tabIndex = 0;
            this.textBoxes = new System.Windows.Forms.TextBox[3];
            this.buttons = new System.Windows.Forms.Button[2];
            this.labels = new System.Windows.Forms.Label[4];
            for (int i = 0; i < 3; ++i)
            {
                textBoxes[i] = new System.Windows.Forms.TextBox();
            }
            for (int i = 0; i < 2; ++i)
            {
                buttons[i] = new System.Windows.Forms.Button();
            }
            for (int i = 0; i < 4; ++i)
            {
                labels[i] = new System.Windows.Forms.Label();
            }
            this.SuspendLayout();

            // 
            // textBoxes
            // 
            for (int i = 0; i < 3; ++i)
            {
                this.textBoxes[i].Location = new System.Drawing.Point(100, 60 + i * 60);
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
                this.buttons[i].Size = new System.Drawing.Size(50, 50);
            }
            this.buttons[0].Text = "Run";
            this.buttons[1].Text = "Stop";
            this.buttons[0].Click += new System.EventHandler(this.confirmButtonClick);
            this.buttons[1].Click += new System.EventHandler(this.cancelButtonClick);
            //
            // labels
            //
            this.labels[0].Location = new System.Drawing.Point(30,220);
            this.labels[0].Name = "pagingFaultRate";
            this.labels[0].Text = "Paging Fault Rate:";
            this.labels[0].Size = new System.Drawing.Size(2000, 400);
            this.labels[1].Location = new System.Drawing.Point(30, 30);
            this.labels[1].Name = "procedure";
            this.labels[1].Text = "Process:";
            this.labels[1].Size = new System.Drawing.Size(2000, 400);
            //
            // IceboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 250);
            for (int i = 0; i < 3; ++i)
            {
                this.Controls.Add(textBoxes[i]);
            }
            for (int i = 0; i < 2; ++i)
            {
                this.Controls.Add(buttons[i]);
            }
            for (int i = 0; i < 4; ++i)
            {
                this.Controls.Add(labels[i]);
            }
            this.Name = "IceboxForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.TextBox[] textBoxes;
        private System.Windows.Forms.Button[] buttons;
        private System.Windows.Forms.Label[] labels;
    }
}

