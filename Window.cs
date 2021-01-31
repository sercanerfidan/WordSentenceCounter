using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordSentenceCounter.Services;

namespace WordSentenceCounter
{
    public partial class MainWindow : Form
    {
        public readonly IWordCounterService wordCounterService;
        public readonly string inputText = string.Empty;
        public MainWindow(IWordCounterService wordCounterService)
        {
            this.wordCounterService = wordCounterService;
            InitializeComponent();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog.ShowDialog();
            string text = string.Empty;
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;

                string fileExtension = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.') + 1).ToLower();
                if (fileExtension != "txt")
                {
                    MessageBox.Show("File extension is not txt! Please upload a text file");
                    return;
                }
                else {
                    try
                    {

                        filePath.Text = openFileDialog.FileName;
                        text = File.ReadAllText(file);
                        size = text.Length;
                        textContent.Text = text;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("An error occured error : ", ex.Message);

                    }

                }

               
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {

            int threadCount = Convert.ToInt32(taskCount.Text);
            if (string.IsNullOrEmpty(textContent.Text))
            {
                MessageBox.Show("Text content empty!");
                return;
            }
           string result = wordCounterService.StartUp(threadCount, textContent.Text).Result;
           resultText.Text = result;
        }

        private void taskCount_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(taskCount.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!");
                taskCount.Text = taskCount.Text.Remove(taskCount.Text.Length - 1);
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
