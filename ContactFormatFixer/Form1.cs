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

        public class inputLine
        {

        }

        public class outputLine
        {
            //  The format of the output is as such:
            //  Name, Given Name, Additional Name, Family Name, Yomi Name, Given Name Yomi, Additional Name Yomi, Family Name Yomi, Name Prefix, Name Suffix, Initials, Nickname, Short Name, Maiden Name, Birthday, Gender, Location, Billing Information, Directory Server, Mileage, Occupation, Hobby, Sensitivity, Priority, Subject, Notes, Group Membership, E-mail 1 - Type, E-mail 1 - Value, E-mail 2 - Type, E-mail 2 - Value, IM 1 - Type, IM 1 - Service, IM 1 - Value, Phone 1 - Type, Phone 1 - Value, Phone 2 - Type, Phone 2 - Value, Phone 3 - Type, Phone 3 - Value, Address 1 - Type, Address 1 - Formatted, Address 1 - Street, Address 1 - City, Address 1 - PO Box, Address 1 - Region, Address 1 - Postal Code, Address 1 - Country, Address 1 - Extended Address, Organization 1 - Type, Organization 1 - Name, Organization 1 - Yomi Name, Organization 1 - Title, Organization 1 - Department, Organization 1 - Symbol, Organization 1 - Location, Organization 1 - Job Description, Website 1 - Type, Website 1 - Value


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
