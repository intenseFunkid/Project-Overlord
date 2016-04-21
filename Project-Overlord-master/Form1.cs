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

        //Create Each Linked List
        charStatList characterLL;
        dateList dateLL;
        gameDateList gameDateLL;
        randomTable tableLL;

        //Path variable for de/serializing
        String saveLocation = "";

        /**************************************
         * 
         *      CALENDAR EVENTS
         * 
         **************************************/








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
        //TEST
        private void btnFirstID_Click(object sender, EventArgs e)
        {
            txtGDateID.Text = testDate.getFirst().dateID.ToString();
        }
        //TEST
        private void txtTestRemove_Click(object sender, EventArgs e)
        {
            testDate.removeEntry(Convert.ToInt32(txtGDateID.Text));
        }

        private void tabCalendar_Click(object sender, EventArgs e)
        {

        }

        /************************************
        *
        *       Main Campagin Menu Bar Events
        *
        **************************************/

        private void newCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Give option to cancel, save current campaign, or continue without saving current campaign
            yesNoCancelSaveDialog("new");
        }

        private void loadCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ask if they want to save current Campaign
            yesNoCancelSaveDialog("load");
        }

        private void saveCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Calls save function with path string
            saveCampaign(saveLocation);
        }
         
        private void saveCampaignAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCampagainAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ask if you would like to save 
            yesNoCancelExitDialog();
        }

        //Save function
        public void saveCampaign(String path)
        {
            if (path == "") //Path is unset
            {
                saveCampagainAs();
            }
            else //Path is set
            {
                //Checks if File Exists to Save To
                if (File.Exists(path))
                {
                    //Handles opening of file
                    FileStream fs = new FileStream(path, FileMode.Open);

                    System.Xml.Serialization.XmlSerializer writer =
                        new System.Xml.Serialization.XmlSerializer(typeof(serializationWrapper));

                    //Creation of wrapper object for serialization
                    serializationWrapper myTester = new serializationWrapper();

                    //Saves GameDate Info into serialization class
                    gameDateEntry index = gameDateLL.getFirst();
                    while (index.gameDateID < gameDateLL.getLast().gameDateID)
                    {
                        myTester.gameDateHolder.Add(index);
                        index = gameDateLL.getNext(index.gameDateID);
                    }
                    //Adds last entry of gameDate to serialization object after while loop exits
                    myTester.gameDateHolder.Add(index);

                    //Saves charStatList infor into serialization class
                    //myTester.charStatHolder.Add(BK_char1);
                    //myTester.charStatHolder.Add(BK_char2);

                    //Write to file and close it
                    writer.Serialize(fs, myTester);
                    fs.Close();
                }
                else //File does NOT exist to save to
                {
                    saveCampagainAs();
                }
            }
        }
        
        public void saveCampagainAs()
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

        public void loadCampaign()
        {
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

                    //TEST DATA
                    //gameDateList testgDate2 = new gameDateList();   //Holds info for loading

                    //Read XML file and assign to serializationWrapper object
                    serializationWrapper myTester = (serializationWrapper)reader.Deserialize(file);
                    file.Close();

                    //Loads objects into dateLL
                    for (int x = 0; x < myTester.dateHolder.Count; x++)
                    {

                        dateLL.addEntry(myTester.dateHolder[x]);
                    }

                    //Loads obects into gameDateLL
                    for (int x = 0; x < myTester.gameDateHolder.Count; x++)
                    {
                        System.Windows.Forms.MessageBox.Show(myTester.gameDateHolder[x].entry);
                        gameDateLL.addEntry(myTester.gameDateHolder[x]);
                    }

                    //Loads objects into characterLL
                    for (int x = 0; x < myTester.charStatHolder.Count; x++)
                    {
                        System.Windows.Forms.MessageBox.Show(myTester.charStatHolder[x].name +
                            myTester.charStatHolder[x].blockID);
                        characterLL.addEntry(myTester.charStatHolder[x]);
                    }

                    //Loads objects into tableLL

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

        public void yesNoCancelExitDialog()
        {
            switch (MessageBox.Show("Do you want to save before closing?",
                "Save Before Closing",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    saveCampaign(saveLocation);
                    break;
                case DialogResult.No:
                    Close();
                    break;
                case DialogResult.Cancel:
                    break;
            } 
        }

        public void yesNoCancelSaveDialog(string decision)
        {
            switch (MessageBox.Show("Do you want to save before closing your current campaign?",
                "Save Before Closing Current Campagin",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    saveCampaign(saveLocation);
                    if (decision == "new")
                    {
                        //
                    }
                    else //decision == load
                    {

                    }
                    break;
                case DialogResult.No:
                    //Clears all fields on the form

                    //Empties all data structures
                    if (decision == "new")
                    {
                        //Clears all fields on the form
                        //Empties all data structures

                    }
                    else //decision == load
                    {

                    }
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }
        private void Calender_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
