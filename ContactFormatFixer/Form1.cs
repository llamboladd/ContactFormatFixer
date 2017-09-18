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
using System.Collections;

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

            //  The format of the input is as such:
            //  First Name, Last Name, Family Name, Email Address, Phone Number

            public string firstName { get; set; }
            public string lastName { get; set; }
            public string familyName { get; set; }
            public string emailAddress { get; set; }
            public string phoneNumber { get; set; }

            public inputLine()
            {
                this.firstName = "";
                this.lastName = "";
                this.familyName = "";
                this.emailAddress = "bugmenot@bugmenot.com";
                this.phoneNumber = "";
            }

            public inputLine(string firstName, string lastName, string familyName, string emailAddress, string phoneNumber)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.familyName = familyName;
                this.emailAddress = emailAddress;
                this.phoneNumber = phoneNumber;
            }

            public override string ToString()
            {
                return (this.firstName + "\t" + this.lastName + "\t" + this.familyName + "\t" + this.emailAddress + "\t" + this.phoneNumber);
            }

            public inputLine(outputLine outputLine)
            {
                this.firstName = outputLine.GivenName;
                this.lastName = outputLine.FamilyName;
                this.familyName = outputLine.FamilyName;
                this.emailAddress = outputLine.Email1Value;
                this.phoneNumber = outputLine.Phone1Value;
            }

            public outputLine toOutputLine()
            {
                outputLine newLine = new outputLine(this);
                return newLine;
            }

            public List<string> toList()
            {
                List<string> newList = new List<string>();
                newList.Add(this.firstName);
                newList.Add(this.lastName);
                newList.Add(this.familyName);
                newList.Add(this.emailAddress);
                newList.Add(this.phoneNumber);
                return newList;
            }

            internal void fromList(List<string> lineItems)
            {
                this.firstName = lineItems.ElementAt(0);
                this.lastName = lineItems.ElementAt(1);
                this.familyName = lineItems.ElementAt(2);
                this.emailAddress = lineItems.ElementAt(3);
                this.phoneNumber = lineItems.ElementAt(4);
            }
        }


        public class outputLine
        {

            //  The format of the output is as such:
            //  Name, Given Name, Additional Name, Family Name, Yomi Name, Given Name Yomi, Additional Name Yomi, Family Name Yomi, Name Prefix, Name Suffix, Initials, Nickname, Short Name, Maiden Name, Birthday, Gender, Location, Billing Information, Directory Server, Mileage, Occupation, Hobby, Sensitivity, Priority, Subject, Notes, Group Membership, E-mail 1 - Type, E-mail 1 - Value, E-mail 2 - Type, E-mail 2 - Value, IM 1 - Type, IM 1 - Service, IM 1 - Value, Phone 1 - Type, Phone 1 - Value, Phone 2 - Type, Phone 2 - Value, Phone 3 - Type, Phone 3 - Value, Address 1 - Type, Address 1 - Formatted, Address 1 - Street, Address 1 - City, Address 1 - PO Box, Address 1 - Region, Address 1 - Postal Code, Address 1 - Country, Address 1 - Extended Address, Organization 1 - Type, Organization 1 - Name, Organization 1 - Yomi Name, Organization 1 - Title, Organization 1 - Department, Organization 1 - Symbol, Organization 1 - Location, Organization 1 - Job Description, Website 1 - Type, Website 1 - Value

            public string Name { get; set; }
            public string GivenName { get; set; }
            public string AdditionalName { get; set; }
            public string FamilyName { get; set; }
            public string YomiName { get; set; }
            public string GivenNameYomi { get; set; }
            public string AdditionalNameYomi { get; set; }
            public string FamilyNameYomi { get; set; }
            public string NamePrefix { get; set; }
            public string NameSuffix { get; set; }
            public string Initials { get; set; }
            public string Nickname { get; set; }
            public string ShortName { get; set; }
            public string MaidenName { get; set; }
            public string Birthday { get; set; }
            public string Gender { get; set; }
            public string Location { get; set; }
            public string BillingInformation { get; set; }
            public string DirectoryServer { get; set; }
            public string Mileage { get; set; }
            public string Occupation { get; set; }
            public string Hobby { get; set; }
            public string Sensitivity { get; set; }
            public string Priority { get; set; }
            public string Subject { get; set; }
            public string Notes { get; set; }
            public string GroupMembership { get; set; }
            public string Email1Type { get; set; }
            public string Email1Value { get; set; }
            public string Email2Type { get; set; }
            public string Email2Value { get; set; }
            public string IM1Type { get; set; }
            public string IM1Service { get; set; }
            public string IM1Value { get; set; }
            public string Phone1Type { get; set; }
            public string Phone1Value { get; set; }
            public string Phone2Type { get; set; }
            public string Phone2Value { get; set; }
            public string Phone3Type { get; set; }
            public string Phone3Value { get; set; }
            public string Address1Type { get; set; }
            public string Address1Formatted { get; set; }
            public string Address1Street { get; set; }
            public string Address1City { get; set; }
            public string Address1POBox { get; set; }
            public string Address1Region { get; set; }
            public string Address1PostalCode { get; set; }
            public string Address1Country { get; set; }
            public string Address1ExtendedAddress { get; set; }
            public string Organization1Type { get; set; }
            public string Organization1Name { get; set; }
            public string Organization1YomiName { get; set; }
            public string Organization1Title { get; set; }
            public string Organization1Department { get; set; }
            public string Organization1Symbol { get; set; }
            public string Organization1Location { get; set; }
            public string Organization1JobDescription { get; set; }
            public string Website1Type { get; set; }
            public string Website1Value { get; set; }

            public outputLine()
            {
                //  All values are initially set to null strings.
                this.Name = this.GivenName = this.AdditionalName = this.FamilyName = this.YomiName = this.GivenNameYomi = this.AdditionalNameYomi = this.FamilyNameYomi = this.NamePrefix = this.NameSuffix = this.Initials = this.Nickname = this.ShortName = this.MaidenName = this.Birthday = this.Gender = this.Location = this.BillingInformation = this.DirectoryServer = this.Mileage = this.Occupation = this.Hobby = this.Sensitivity = this.Priority = this.Subject = this.Notes = this.GroupMembership = this.Email1Type = this.Email1Value = this.Email2Type = this.Email2Value = this.IM1Type = this.IM1Service = this.IM1Value = this.Phone1Type = this.Phone1Value = this.Phone2Type = this.Phone2Value = this.Phone3Type = this.Phone3Value = this.Address1Type = this.Address1Formatted = this.Address1Street = this.Address1City = this.Address1POBox = this.Address1Region = this.Address1PostalCode = this.Address1Country = this.Address1ExtendedAddress = this.Organization1Type = this.Organization1Name = this.Organization1YomiName = this.Organization1Title = this.Organization1Department = this.Organization1Symbol = this.Organization1Location = this.Organization1JobDescription = this.Website1Type = this.Website1Value = "";
            }

            public outputLine(inputLine inputLine)
            {
                this.Name = inputLine.firstName + " " + inputLine.lastName;
                this.GivenName = inputLine.firstName;
                this.FamilyName = inputLine.familyName;
                this.Email1Value = inputLine.emailAddress;
                this.Phone1Value = inputLine.phoneNumber;
            }

            public inputLine toInputLine()
            {
                inputLine newLine = new inputLine(this);
                return newLine;
            }

            internal void fromList(List<outputLine> lineItems)
            {
                outputLine newLine = new outputLine();
                newLine.Name = lineItems[0].ToString();
                newLine.GivenName = lineItems[1].ToString();
                newLine.AdditionalName = lineItems[2].ToString();
                newLine.FamilyName = lineItems[3].ToString();
                newLine.YomiName = lineItems[4].ToString();
                newLine.GivenNameYomi = lineItems[5].ToString();
                newLine.AdditionalNameYomi = lineItems[6].ToString();
                newLine.FamilyNameYomi = lineItems[7].ToString();
                newLine.NamePrefix = lineItems[8].ToString();
                newLine.NameSuffix = lineItems[9].ToString();
                newLine.Initials = lineItems[10].ToString();
                newLine.Nickname = lineItems[11].ToString();
                newLine.ShortName = lineItems[12].ToString();
                newLine.MaidenName = lineItems[13].ToString();
                newLine.Birthday = lineItems[14].ToString();
                newLine.Gender = lineItems[15].ToString();
                newLine.Location = lineItems[16].ToString();
                newLine.BillingInformation = lineItems[17].ToString();
                newLine.DirectoryServer = lineItems[18].ToString();
                newLine.Mileage = lineItems[19].ToString();
                newLine.Occupation = lineItems[20].ToString();
                newLine.Hobby = lineItems[21].ToString();
                newLine.Sensitivity = lineItems[22].ToString();
                newLine.Priority = lineItems[23].ToString();
                newLine.Subject = lineItems[24].ToString();
                newLine.Notes = lineItems[25].ToString();
                newLine.GroupMembership = lineItems[26].ToString();
                newLine.Email1Type = lineItems[27].ToString();
                newLine.Email1Value = lineItems[28].ToString();
                newLine.Email2Type = lineItems[29].ToString();
                newLine.Email2Value = lineItems[30].ToString();
                newLine.IM1Type = lineItems[31].ToString();
                newLine.IM1Service = lineItems[32].ToString();
                newLine.IM1Value = lineItems[33].ToString();
                newLine.Phone1Type = lineItems[34].ToString();
                newLine.Phone1Value = lineItems[35].ToString();
                newLine.Phone2Type = lineItems[35].ToString();
                newLine.Phone2Value = lineItems[36].ToString();
                newLine.Phone3Type = lineItems[37].ToString();
                newLine.Phone3Value = lineItems[38].ToString();
                newLine.Address1Type = lineItems[39].ToString();
                newLine.Address1Formatted = lineItems[40].ToString();
                newLine.Address1Street = lineItems[41].ToString();
                newLine.Address1City = lineItems[42].ToString();
                newLine.Address1POBox = lineItems[43].ToString();
                newLine.Address1Region = lineItems[44].ToString();
                newLine.Address1PostalCode = lineItems[45].ToString();
                newLine.Address1Country = lineItems[46].ToString();
                newLine.Address1ExtendedAddress = lineItems[47].ToString();
                newLine.Organization1Type = lineItems[48].ToString();
                newLine.Organization1Name = lineItems[49].ToString();
                newLine.Organization1YomiName = lineItems[50].ToString();
                newLine.Organization1Title = lineItems[51].ToString();
                newLine.Organization1Department = lineItems[52].ToString();
                newLine.Organization1Symbol = lineItems[53].ToString();
                newLine.Organization1Location = lineItems[54].ToString();
                newLine.Organization1JobDescription = lineItems[55].ToString();
                newLine.Website1Type = lineItems[56].ToString();
                newLine.Website1Value = lineItems[57].ToString();
            }
        }

        public string originalFile = "";
        public string newFile = "";
        public List<inputLine> listItems = new List<inputLine>();

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
            foreach (string originalLine in originalLines)
            {
                List<string> lineItems = originalLine.Split(',').ToList();
                inputLine newLine = new inputLine();
                newLine.fromList(lineItems);
                listItems.Add(newLine);
            }


            foreach (inputLine lineItem in listItems)
            {
                Console.Out.WriteLine(lineItem.ToString());
            }

            ShowMessage("File Fixed Successfully!");
        }
    }
}
