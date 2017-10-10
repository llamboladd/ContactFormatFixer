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

        [Serializable]
        private enum inputColumn : int
        {
            lastName,
            firstName,
            streetAddress,
            phoneNumber,
            emailAddress
        };

        [Serializable]
        private enum outputColumn : int
        {
            Name,
            GivenName,
            AdditionalName,
            FamilyName,
            YomiName,
            GivenNameYomi,
            AdditionalNameYomi,
            FamilyNameYomi,
            NamePrefix,
            NameSuffix,
            Initials,
            Nickname,
            ShortName,
            MaidenName,
            Birthday,
            Gender,
            Location,
            BillingInformation,
            DirectoryServer,
            Mileage,
            Occupation,
            Hobby,
            Sensitivity,
            Priority,
            Subject,
            Notes,
            GroupMembership,
            Email1Type,
            Email1Value,
            Email2Type,
            Email2Value,
            IM1Type,
            IM1Service,
            IM1Value,
            Phone1Type,
            Phone1Value,
            Phone2Type,
            Phone2Value,
            Phone3Type,
            Phone3Value,
            Address1Type,
            Address1Formatted,
            Address1Street,
            Address1City,
            Address1POBox,
            Address1Region,
            Address1PostalCode,
            Address1Country,
            Address1ExtendedAddress,
            Organization1Type,
            Organization1Name,
            Organization1YomiName,
            Organization1Title,
            Organization1Department,
            Organization1Symbol,
            Organization1Location,
            Organization1JobDescription,
            Website1Type,
            Website1Value
        }

        [Serializable]
        public class inputLine
        {

            //  The format of the input is as such:
            //  Last Name, First Name, Street Address, Phone Number, Email Address
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string streetAddress { get; set; }
            public string phoneNumber { get; set; }
            public string emailAddress { get; set; }

            public inputLine()
            {
                this.lastName = "";
                this.firstName = "";
                this.streetAddress = "";
                this.phoneNumber = "";
                this.emailAddress = "";
            }

            public inputLine(string lastName, string firstName, string streetAddress, string phoneNumber, string emailAddress)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.streetAddress = streetAddress;
                this.phoneNumber = phoneNumber;
                this.emailAddress = emailAddress;
            }

            public override string ToString()
            {
                return (this.lastName + "\t" + this.firstName + "\t" + this.streetAddress + "\t" + this.phoneNumber + "\t" + this.emailAddress);
            }

            public inputLine(outputLine outputLine)
            {
                this.lastName = outputLine.FamilyName;
                this.firstName = outputLine.GivenName;
                this.streetAddress = outputLine.Address1Street;
                this.phoneNumber = outputLine.Phone1Value;
                this.emailAddress = outputLine.Email1Value;
            }

            public outputLine toOutputLine()
            {
                outputLine newLine = new outputLine(this);
                return newLine;
            }

            public List<string> toList()
            {
                List<string> newList = new List<string>();
                newList.Add(this.lastName);
                newList.Add(this.firstName);
                newList.Add(this.streetAddress);
                newList.Add(this.phoneNumber);
                newList.Add(this.emailAddress);
                return newList;
            }

            public inputLine fromList(List<string> lineItems)
            {
                this.lastName = lineItems.ElementAt(0);
                this.firstName = lineItems.ElementAt(1);
                this.streetAddress = lineItems.ElementAt(2);
                this.phoneNumber = lineItems.ElementAt(3);
                this.emailAddress = lineItems.ElementAt(4);
                return this;
            }
        }

        [Serializable]
        public class outputLine
        {
            //  The format of the output is as such:
            //  Name, Given Name, Additional Name, Family Name, Yomi Name, Given Name Yomi, Additional Name Yomi, Family Name Yomi, Name Prefix, Name Suffix, Initials, Nickname, Short Name, Maiden Name, Birthday, Gender, Location, Billing Information, Directory Server, Mileage, Occupation, Hobby, Sensitivity, Priority, Subject, Notes, Group Membership, E-mail 1 - Type, E-mail 1 - Value, E-mail 2 - Type, E-mail 2 - Value, IM 1 - Type, IM 1 - Service, IM 1 - Value, Phone 1 - Type, Phone 1 - Value, Phone 2 - Type, Phone 2 - Value, Phone 3 - Type, Phone 3 - Value, Address 1 - Type, Address 1 - Formatted, Address 1 - Street, Address 1 - City, Address 1 - PO Box, Address 1 - Region, Address 1 - Postal Code, Address 1 - Country, Address 1 - Extended Address, Organization 1 - Type, Organization 1 - Name, Organization 1 - Yomi Name, Organization 1 - Title, Organization 1 - Department, Organization 1 - Symbol, Organization 1 - Location, Organization 1 - Job Description, Website 1 - Type, Website 1 - Value
            //  That's right, 58 separate items just to import into a f***ing contact list...

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

            public outputLine(string headerString)
            {
                this.Name = "Name";
                this.GivenName = "Given Name";
                this.AdditionalName = "Additional Name";
                this.FamilyName = "Family Name";
                this.YomiName = "Yomi Name";
                this.GivenNameYomi = "Given Name Yomi";
                this.AdditionalNameYomi = "Additional Name Yomi";
                this.FamilyNameYomi = "Family Name Yomi";
                this.NamePrefix = "Name Prefix";
                this.NameSuffix = "Name Suffix";
                this.Initials = "Initials";
                this.Nickname = "Nickname";
                this.ShortName = "Short Name";
                this.MaidenName = "Maiden Name";
                this.Birthday = "Birthday";
                this.Gender = "Gender";
                this.Location = "Location";
                this.BillingInformation = "Billing Information";
                this.DirectoryServer = "Directory Server";
                this.Mileage = "Mileage";
                this.Occupation = "Occupation";
                this.Hobby = "Hobby";
                this.Sensitivity = "Sensitivity";
                this.Priority = "Priority";
                this.Subject = "Subject";
                this.Notes = "Notes";
                this.Email1Type = "E-mail 1 - Type";
                this.Email1Value = "E-mail 1 - Value";
                this.Phone1Type = "Phone 1 - Type";
                this.Phone1Value = "Phone 1 - Value";
                this.Address1Type = "Address 1 - Type";
                this.Address1Formatted = "Address 1 - Formatted";
                this.Address1Street = "Address 1 - Street";
                this.Address1City = "Address 1 - City";
                this.Address1POBox = "Address 1 - PO Box";
                this.Address1Region = "Address 1 - Region";
                this.Address1PostalCode = "Address 1 - Postal Code";
                this.Address1Country = "Address 1 - Country";
                this.Address1ExtendedAddress = "Address 1 - Extended Address";
                this.GroupMembership = "Group Membership";
            }

            public override string ToString()
            {
                return this.Name + "\t" + this.GivenName + "\t" + this.AdditionalName + "\t" + this.FamilyName + "\t" + this.YomiName + "\t" + this.GivenNameYomi + "\t" + this.AdditionalNameYomi + "\t" + this.FamilyNameYomi + "\t" + this.NamePrefix + "\t" + this.NameSuffix + "\t" + this.Initials + "\t" + this.Nickname + "\t" + this.ShortName + "\t" + this.MaidenName + "\t" + this.Birthday + "\t" + this.Gender + "\t" + this.Location + "\t" + this.BillingInformation + "\t" + this.DirectoryServer + "\t" + this.Mileage + "\t" + this.Occupation + "\t" + this.Hobby + "\t" + this.Sensitivity + "\t" + this.Priority + "\t" + this.Subject + "\t" + this.Notes + "\t" + this.GroupMembership + "\t" + this.Email1Type + "\t" + this.Email1Value + "\t" + this.Email2Type + "\t" + this.Email2Value + "\t" + this.IM1Type + "\t" + this.IM1Service + "\t" + this.IM1Value + "\t" + this.Phone1Type + "\t" + this.Phone1Value + "\t" + this.Phone2Type + "\t" + this.Phone2Value + "\t" + this.Phone3Type + "\t" + this.Phone3Value + "\t" + this.Address1Type + "\t" + this.Address1Formatted + "\t" + this.Address1Street + "\t" + this.Address1City + "\t" + this.Address1POBox + "\t" + this.Address1Region + "\t" + this.Address1PostalCode + "\t" + this.Address1Country + "\t" + this.Address1ExtendedAddress + "\t" + this.Organization1Type + "\t" + this.Organization1Name + "\t" + this.Organization1YomiName + "\t" + this.Organization1Title + "\t" + this.Organization1Department + "\t" + this.Organization1Symbol + "\t" + this.Organization1Location + "\t" + this.Organization1JobDescription + "\t" + this.Website1Type + "\t" + this.Website1Value;
            }

            public outputLine(inputLine inputLine)
            {
                this.Name = inputLine.firstName + " " + inputLine.lastName;
                this.GivenName = inputLine.firstName;
                this.Address1Street = inputLine.streetAddress;
                this.Phone1Value = inputLine.phoneNumber;
                this.Email1Value = inputLine.emailAddress;
            }

            public inputLine toInputLine()
            {
                inputLine newLine = new inputLine(this);
                return newLine;
            }

            public outputLine fromList(List<outputLine> lineItems)
            {
                this.Name = lineItems[0].ToString();
                this.GivenName = lineItems[1].ToString();
                this.AdditionalName = lineItems[2].ToString();
                this.FamilyName = lineItems[3].ToString();
                this.YomiName = lineItems[4].ToString();
                this.GivenNameYomi = lineItems[5].ToString();
                this.AdditionalNameYomi = lineItems[6].ToString();
                this.FamilyNameYomi = lineItems[7].ToString();
                this.NamePrefix = lineItems[8].ToString();
                this.NameSuffix = lineItems[9].ToString();
                this.Initials = lineItems[10].ToString();
                this.Nickname = lineItems[11].ToString();
                this.ShortName = lineItems[12].ToString();
                this.MaidenName = lineItems[13].ToString();
                this.Birthday = lineItems[14].ToString();
                this.Gender = lineItems[15].ToString();
                this.Location = lineItems[16].ToString();
                this.BillingInformation = lineItems[17].ToString();
                this.DirectoryServer = lineItems[18].ToString();
                this.Mileage = lineItems[19].ToString();
                this.Occupation = lineItems[20].ToString();
                this.Hobby = lineItems[21].ToString();
                this.Sensitivity = lineItems[22].ToString();
                this.Priority = lineItems[23].ToString();
                this.Subject = lineItems[24].ToString();
                this.Notes = lineItems[25].ToString();
                this.GroupMembership = lineItems[26].ToString();
                this.Email1Type = lineItems[27].ToString();
                this.Email1Value = lineItems[28].ToString();
                this.Email2Type = lineItems[29].ToString();
                this.Email2Value = lineItems[30].ToString();
                this.IM1Type = lineItems[31].ToString();
                this.IM1Service = lineItems[32].ToString();
                this.IM1Value = lineItems[33].ToString();
                this.Phone1Type = lineItems[34].ToString();
                this.Phone1Value = lineItems[35].ToString();
                this.Phone2Type = lineItems[35].ToString();
                this.Phone2Value = lineItems[36].ToString();
                this.Phone3Type = lineItems[37].ToString();
                this.Phone3Value = lineItems[38].ToString();
                this.Address1Type = lineItems[39].ToString();
                this.Address1Formatted = lineItems[40].ToString();
                this.Address1Street = lineItems[41].ToString();
                this.Address1City = lineItems[42].ToString();
                this.Address1POBox = lineItems[43].ToString();
                this.Address1Region = lineItems[44].ToString();
                this.Address1PostalCode = lineItems[45].ToString();
                this.Address1Country = lineItems[46].ToString();
                this.Address1ExtendedAddress = lineItems[47].ToString();
                this.Organization1Type = lineItems[48].ToString();
                this.Organization1Name = lineItems[49].ToString();
                this.Organization1YomiName = lineItems[50].ToString();
                this.Organization1Title = lineItems[51].ToString();
                this.Organization1Department = lineItems[52].ToString();
                this.Organization1Symbol = lineItems[53].ToString();
                this.Organization1Location = lineItems[54].ToString();
                this.Organization1JobDescription = lineItems[55].ToString();
                this.Website1Type = lineItems[56].ToString();
                this.Website1Value = lineItems[57].ToString();
                return this;
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

            List<outputLine> outList = new List<outputLine>();
            outList.Add(new outputLine("1337HAX_HEADER_PLZ"));
            foreach (inputLine lineItem in listItems)
            {
                outList.Add(lineItem.toOutputLine());
            }

            StringBuilder outputBuilder = new StringBuilder();
            string[] outArray = new string[outList.Count];
            int i = 0;
            foreach (outputLine item in outList)
            {
                outArray[i++] = item.ToString().Replace('\t',',');
            }

            File.WriteAllLines(newFile, outArray);

            ShowMessage("File Fixed Successfully!");
        }

        private void btnHelp_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnHelp, "Need help?\r\nClick here!");
            toolTip1.Show("Need help?\r\nClick here!", btnHelp);
        }

        private void btnHelp_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(btnHelp);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
