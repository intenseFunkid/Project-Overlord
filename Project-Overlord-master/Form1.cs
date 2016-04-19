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

namespace projectOverlord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Calendar working objects
            dateList activeDateList = new dateList();
            dateEntry activeDateEntry = new dateEntry(001, "", "", 001, 001);
            gameDateList activeGDateList = new gameDateList();
            gameDateEntry activeGameDate = new gameDateEntry(001, "");
        }



        /**************************************
         * 
         *      CALENDAR EVENTS
         * 
         **************************************/

        




        public String saveLocation = "";

        //STUFF To Test - IAN
        gameDateList testgDate = new gameDateList();    //Holds info for saving
        
        dateList testDate = new dateList();             //Holds info for saving
        dateList testDate2 = new dateList();            //Holds info for loading


        //TEST
        private void btnTestAssign_Click(object sender, EventArgs e)
        {
            dateEntry newEntry = new dateEntry(Convert.ToInt32(txtGDateID.Text),
                                                txtGEntry.Text,
                                                txtSessionEntry.Text,
                                                Convert.ToInt32(txtGDSID.Text),
                                                Convert.ToInt32(txtGDEID.Text));
            testDate.addEntry(newEntry);
        }

        //TEST
        private void btnTestRecall_Click(object sender, EventArgs e)
        {
            dateEntry retrievedEntry = new dateEntry();
            retrievedEntry = testDate.retrieveEntry(Convert.ToInt32(txtGDateID.Text));

            txtGDateID.Text = retrievedEntry.dateID.ToString();
            txtGEntry.Text = retrievedEntry.planEntry;
            txtSessionEntry.Text = retrievedEntry.sessionEntry;
            txtGDSID.Text = retrievedEntry.gameDateStartID.ToString();
            txtGDEID.Text = retrievedEntry.gameDateEndID.ToString();
        }

        private void btnFirstID_Click(object sender, EventArgs e)
        {
            txtGDateID.Text = testDate.getFirst().dateID.ToString();
        }

        private void txtTestRemove_Click(object sender, EventArgs e)
        {
            testDate.removeEntry(Convert.ToInt32(txtGDateID.Text));
        }

        private void tabCalendar_Click(object sender, EventArgs e)
        {

        }

        //Main Campagin Menu Bar Events
        //

        private void newCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Give option to cancel, save current campaign, or continue without saving current campaign
           
        }

        private void loadCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ask if they want to save current Campaign
            //  Yes, No, Cancel

            //Set up Load Dialog Box
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML file|*.xml";
            openFileDialog1.Title = "Select your Campaign";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Xml.Serialization.XmlSerializer reader =
                        new System.Xml.Serialization.XmlSerializer(typeof(serializationWrapper));

                    System.IO.StreamReader file = new System.IO.StreamReader
                        (openFileDialog1.FileName);

                    gameDateList testgDate2 = new gameDateList();   //Holds info for loading
                    serializationWrapper myTester = (serializationWrapper)reader.Deserialize(file);
                    file.Close();

                    //Loads objects into 
                    for (int x = 0; x < myTester.dateHolder.Count; x++)
                    {

                    }

                    for (int x = 0; x < myTester.gameDateHolder.Count; x++)
                    {
                        System.Windows.Forms.MessageBox.Show(myTester.gameDateHolder[x].entry);

                    }

                    for (int x = 0; x < myTester.charStatHolder.Count; x++)
                    {
                        System.Windows.Forms.MessageBox.Show(myTester.charStatHolder[x].name +
                            myTester.charStatHolder[x].blockID);
                    }
                    try
                    {
                        saveLocation = Path.GetFullPath(openFileDialog1.FileName);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error: Saving Path Failure" + exc.Message);
                    }
                }
                catch (FileNotFoundException exc)
                {
                    MessageBox.Show("Error: File not Found!\n\n" + exc.Message);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: Could not read file from disk.\n\nOriginal Error: " + exc.Message);
                }
            }
        }

        private void saveCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Calls save function with path string
            saveCampaign(saveLocation);
        }
         

        private void saveCampaignAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TEST DATA FOR gameDateList Class
            gameDateEntry BK_GDEntry1 = new gameDateEntry(0, "Test GD Entry 0");
            gameDateEntry BK_GDEntry2 = new gameDateEntry(1, "Test GD Entry 1");
            gameDateList BK_GDList1 = new gameDateList();
            BK_GDList1.addEntry(BK_GDEntry1);
            BK_GDList1.addEntry(BK_GDEntry2);

            //TEST DATA FOR statBlockPF
            statBlockPF BK_char1 = new statBlockPF();
            BK_char1.blockID = 5;
            BK_char1.name = "This Char Works!";
            statBlockPF BK_char2 = new statBlockPF();
            BK_char2.blockID = 12;
            BK_char2.name = "This Char works too!";

            //Setting up save dialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.Title = "Save your Campaign";

            //Valid File Name is Entered
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(serializationWrapper));
                gameDateEntry index = BK_GDList1.getFirst();

                serializationWrapper myTester = new serializationWrapper();

                while (index.gameDateID < BK_GDList1.getLast().gameDateID)
                {
                    myTester.gameDateHolder.Add(index);
                    index = BK_GDList1.getNext(index.gameDateID);
                }

                myTester.gameDateHolder.Add(index);

                myTester.charStatHolder.Add(BK_char1);
                myTester.charStatHolder.Add(BK_char2);
                writer.Serialize(fs, myTester);
                fs.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ask if you would like to save 
            //      Yes, No, Cancel

            //If Yes
            saveCampaign(saveLocation);
            Close();
        }

        //Save function
        public void saveCampaign(String path)
        {
            System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(serializationWrapper));
            gameDateEntry index = BK_GDList1.getFirst();

            serializationWrapper myTester = new serializationWrapper();

            while (index.gameDateID < BK_GDList1.getLast().gameDateID)
            {
                myTester.gameDateHolder.Add(index);
                index = BK_GDList1.getNext(index.gameDateID);
            }

            myTester.gameDateHolder.Add(index);

            myTester.charStatHolder.Add(BK_char1);
            myTester.charStatHolder.Add(BK_char2);
            writer.Serialize(fs, myTester);
            fs.Close();
        }

        private void Calender_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
