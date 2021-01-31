namespace WordSentenceCounter
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.taskCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.textContent = new System.Windows.Forms.RichTextBox();
            this.filePath = new System.Windows.Forms.Label();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.resultText = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.taskCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.startBtn);
            this.groupBox1.Controls.Add(this.resultText);
            this.groupBox1.Controls.Add(this.textContent);
            this.groupBox1.Controls.Add(this.filePath);
            this.groupBox1.Controls.Add(this.uploadBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 404);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Word Counter";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // taskCount
            // 
            this.taskCount.AcceptsTab = true;
            this.taskCount.Location = new System.Drawing.Point(495, 36);
            this.taskCount.MaxLength = 20;
            this.taskCount.Name = "taskCount";
            this.taskCount.Size = new System.Drawing.Size(100, 23);
            this.taskCount.TabIndex = 6;
            this.taskCount.Text = "5";
            this.taskCount.UseWaitCursor = true;
            this.taskCount.TextChanged += new System.EventHandler(this.taskCount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thread Count :";
            // 
            // startBtn
            // 
            this.startBtn.AllowDrop = true;
            this.startBtn.Location = new System.Drawing.Point(341, 64);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(57, 23);
            this.startBtn.TabIndex = 3;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // textContent
            // 
            this.textContent.Location = new System.Drawing.Point(98, 65);
            this.textContent.Name = "textContent";
            this.textContent.Size = new System.Drawing.Size(237, 315);
            this.textContent.TabIndex = 2;
            this.textContent.Text = "";
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(98, 41);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(0, 15);
            this.filePath.TabIndex = 1;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(6, 64);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(75, 23);
            this.uploadBtn.TabIndex = 0;
            this.uploadBtn.Text = "Upload File";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // resultText
            // 
            this.resultText.Location = new System.Drawing.Point(404, 65);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(354, 315);
            this.resultText.TabIndex = 2;
            this.resultText.Text = "";
            this.resultText.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.Text = "Window";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label filePath;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RichTextBox textContent;
        private System.Windows.Forms.Button startParsingBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button startServiceBtn;
        private System.Windows.Forms.TextBox taskCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox resultText;
    }
}

