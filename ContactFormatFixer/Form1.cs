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

namespace ContactFormatFixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string originalFile = "";
        public string newFile = "";
        public List<List<string>> originalList = new List<List<string>>();
        public List<string> listItems = new List<string>();

        public void ShowMessage(String messageText)
        {
            MessageBox.Show(messageText, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel) { return; }
            else
            {
                try
                {
                    openFileDialog1.OpenFile();
                }
                catch (Exception)
                {
                    ShowMessage("Error - Bad input file.\r\nPlease pick another .CSV or .txt file to input!");
                    btnPickOriginalFile.PerformClick();
                    return;
                }
                btnPickNewFolder.Enabled = true;
                originalFile = openFileDialog1.FileName;
                btnPickNewFolder.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) { return; }
            else
            {
                try
                {
                    saveFileDialog1.OpenFile();
                }
                catch (Exception)
                {
                    ShowMessage("Error - Bad output file.\r\nPlease pick another file to continue!");
                    btnPickNewFolder.PerformClick();
                    return;
                }
                btnFix.Enabled = true;
                newFile = saveFileDialog1.FileName;
                btnFix.Focus();
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                File.ReadAllLines(originalFile).ToList();
            }
            catch (Exception ex)
            {
                ShowMessage("Oops, something went wrong!\r\n~debug info~\r\n" + ex.Message + "\r\nPlease try another input file.");
            }

            List<string> originalLines = File.ReadAllLines(originalFile).ToList();

            foreach (string fileLine in originalLines)
            {
                List<string> lineItems = fileLine.Split(',').ToList();
                foreach (string item in lineItems)
                {
                    listItems.Add(item);
                }
                originalList.Add(lineItems);
            }

            //foreach (string item in listItems)
            //{
            //    System.Console.Out.WriteLine(item.ToString());
            //}

            foreach (List<string> item in originalList)
            {
                foreach (string stringItem in item)
                {
                    System.Console.Out.WriteLine(stringItem.ToString());
                }
            }

            ShowMessage("File Fixed Successfully!");
        }
    }
}
