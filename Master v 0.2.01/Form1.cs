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
            //dateList activeDateList = new dateList();
            //dateEntry activeDateEntry = new dateEntry(001, "", "", 001, 001);
            //gameDateList activeGDateList = new gameDateList();
            //gameDateEntry activeGameDate = new gameDateEntry(001, "");
        }

        //Create Each Linked List
        charStatList characterLL = new charStatList();
        dateList dateLL = new dateList();
        gameDateList gameDateLL = new gameDateList();
        randomTableList tableLL = new randomTableList();

        //Path variable for de/serializing
        String saveLocation = "";

        /**************************************
         * 
         *      CALENDAR EVENTS
         * 
         **************************************/

        //STUFF To Test - IAN
        //gameDateList testgDate = new gameDateList();    //Holds info for saving

        //dateList testDate = new dateList();             //Holds info for saving
        //dateList testDate2 = new dateList();            //Holds info for loading


        //TEST
        /*private void btnTestAssign_Click(object sender, EventArgs e)
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
        */
        private void tabCalendar_Click(object sender, EventArgs e)
        {

        }

        private void Calender_DateChanged(object sender, DateRangeEventArgs e)
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

        //Sets Red X to ask if user wants to save
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown
                || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                //Save Campaign
                return;
            }
            else
            {
                e.Cancel = true;
                yesNoCancelExitDialog();
            }
        }

        /************************************************
        *
        *       Functions for Menu Bar Events
        *
        *************************************************/

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
                    //Calls function which saves all form data to data structures
                    saveAllDataStructures();

                    //Handles opening of file
                    FileStream fs = new FileStream(path, FileMode.Open);

                    System.Xml.Serialization.XmlSerializer writer =
                        new System.Xml.Serialization.XmlSerializer(typeof(serializationWrapper));

                    //Indexer objects for moving through data structures
                    gameDateEntry gameDateIndex = gameDateLL.getFirst();
                    statBlockPF statBlockIndex = characterLL.getFirst();
                    dateEntry dateIndex = dateLL.getFirst();

                    //Declare & Initialize serializationWrapper object to save to xml file
                    serializationWrapper wrapper = new serializationWrapper();

                    //Save gameDateLL into serialization object
                    while (gameDateIndex.gameDateID < gameDateLL.getLast().gameDateID)
                    {
                        wrapper.gameDateHolder.Add(gameDateIndex);
                        gameDateIndex = gameDateLL.getNext(gameDateIndex.gameDateID);
                    }
                    //Save last object of gameDateList
                    wrapper.gameDateHolder.Add(gameDateIndex);

                    //Save characterLL into serialization object
                    while (statBlockIndex.blockID != characterLL.getLast().blockID)
                    {
                        wrapper.charStatHolder.Add(statBlockIndex);
                        statBlockIndex = characterLL.getNext(statBlockIndex.blockID);
                    }
                    //Save last object of characterLL
                    wrapper.charStatHolder.Add(statBlockIndex);

                    //Save dateLL into serialization object
                    while (dateIndex.dateID != dateLL.getLast().dateID)
                    {
                        wrapper.dateHolder.Add(dateIndex);
                        dateIndex = dateLL.getNext(dateIndex.dateID);
                    }
                    //Save last object of dateLL
                    wrapper.dateHolder.Add(dateIndex);

                    /*
                            Need to save random tables class still
                    */


                    //Write to file and close it
                    writer.Serialize(fs, wrapper);
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
            //Setting up save dialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.Title = "Save your Campaign";

            //Valid File Name is Entered
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    saveLocation = saveFileDialog1.FileName;
                    
                    //Calls function which saves all form data to data structures
                    saveAllDataStructures();

                    //Creating filestream object
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                    //Creating XmlSerialization object which reads serializationWrapper class objects
                    System.Xml.Serialization.XmlSerializer writer =
                        new System.Xml.Serialization.XmlSerializer(typeof(serializationWrapper));

                    //Indexer objects for moving through data structures
                    gameDateEntry gameDateIndex = gameDateLL.getFirst();
                    statBlockPF statBlockIndex = characterLL.getFirst();
                    dateEntry dateIndex = dateLL.getFirst();

                    //Declare & Initialize serializationWrapper object to save to xml file
                    serializationWrapper wrapper = new serializationWrapper();

                    //Save gameDateLL into serialization object
                    while (gameDateIndex.gameDateID < gameDateLL.getLast().gameDateID)
                    {
                        wrapper.gameDateHolder.Add(gameDateIndex);
                        gameDateIndex = gameDateLL.getNext(gameDateIndex.gameDateID);
                    }
                    //Save last object of gameDateList
                    wrapper.gameDateHolder.Add(gameDateIndex);

                    //Save characterLL into serialization object
                    while (statBlockIndex.blockID != characterLL.getLast().blockID)
                    {
                        wrapper.charStatHolder.Add(statBlockIndex);
                        statBlockIndex = characterLL.getNext(statBlockIndex.blockID);
                    }
                    //Save last object of characterLL
                    wrapper.charStatHolder.Add(statBlockIndex);

                    //Save dateLL into serialization object
                    while (dateIndex.dateID != dateLL.getLast().dateID)
                    {
                        wrapper.dateHolder.Add(dateIndex);
                        dateIndex = dateLL.getNext(dateIndex.dateID);
                    }
                    //Save last object of dateLL
                    wrapper.dateHolder.Add(dateIndex);

                    /*
                            Need to save random tables class still
                    */

                    //Save serialization object to file
                    writer.Serialize(fs, wrapper);
                    //Close file
                    fs.Close();
                }
                catch
                {
                    MessageBox.Show("Error Serializing Data", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    serializationWrapper wrapper = (serializationWrapper)reader.Deserialize(file);
                    file.Close();

                    //Loads objects into dateLL
                    for (int x = 0; x < wrapper.dateHolder.Count; x++)
                    {
                        dateLL.addEntry(wrapper.dateHolder[x]);
                    }

                    //Loads obects into gameDateLL
                    for (int x = 0; x < wrapper.gameDateHolder.Count; x++)
                    {
                        //System.Windows.Forms.MessageBox.Show(wrapper.gameDateHolder[x].entry);
                        gameDateLL.addEntry(wrapper.gameDateHolder[x]);
                    }

                    //Loads objects into characterLL
                    for (int x = 0; x < wrapper.charStatHolder.Count; x++)
                    {
                        //System.Windows.Forms.MessageBox.Show(wrapper.charStatHolder[x].name +
                            //   wrapper.charStatHolder[x].blockID);
                        characterLL.addEntry(wrapper.charStatHolder[x]);
                    }

                    //Loads objects into tableLL

                    try
                    {
                        saveLocation = openFileDialog1.FileName;

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
                    Application.Exit();
                    break;
                case DialogResult.No:
                    Application.Exit();
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
                    //Save all data from form to data structures
                    saveAllDataStructures();

                    //Save all data structures to file
                    saveCampaign(saveLocation);

                    //Clear all data structures
                    clearAllDataStructures();

                    //Empty all fields on form
                    emptyEntireForm();

                    if (decision == "load")
                    {
                        //Load data structure from file
                        loadCampaign();

                        //Load data structure into fields

                    }
                    break;

                case DialogResult.No:
                    //Clears all data structures
                    clearAllDataStructures();

                    //Empties all fields on form
                    emptyEntireForm();

                    if (decision == "load")
                    {
                        //Load data structure from file
                        loadCampaign();

                        //Load data structure into fields

                    }
                    break;

                case DialogResult.Cancel:
                    break;
            }
        }

        public void saveAllDataStructures()
        {
            //Saves form data to CharacterLL
            //characterLL.addEntry(Save_Character());

            //Saves form data to dateLL

            //Saves form data to gameDateLL

            //Saves form data to tableLL

        }

        public void clearAllDataStructures()
        {
            characterLL.clearList();
            dateLL.clearList();
            gameDateLL.clearList();
            tableLL.clearList();
        }

        public void emptyEntireForm()
        {
            //Random Tables Page
            TableListBox.Items.Clear();
            TXTTableNameInput.Clear();
            TXTDescription.Clear();
            TXTWeight.Clear();
            TXTTableEntries.Clear();
            TableOutputTXTarea.Clear();

            //Character Statistics Page
            LSTBOXCharacters.Items.Clear();
            inputPfPName.Clear();
            inputPfCName.Clear();
            inputPfRace.Clear();
            inputPfStr.Clear();
            inputPfDex.Clear();
            inputPfCon.Clear();
            inputPfInt.Clear();
            inputPfWis.Clear();
            inputPfCha.Clear();
            inputPfAC.Clear();
            inputPfFort.Clear();
            inputPfRef.Clear();
            inputPfWill.Clear();
            inputPfSpeed.Clear();
            inputPfReach.Clear();
            inputPfTAC.Clear();
            inputPfFFAC.Clear();
            inputPfBAB.Clear();
            inputPfCMB.Clear();
            inputPfCMD.Clear();
            inputPfInit.Clear();
            txtPfSklAcro.Clear();
            txtPfSklAppr.Clear();
            txtPfSklBluf.Clear();
            txtPfSklClim.Clear();
            txtPfSklCraft.Clear();
            txtPfSklDiplomacy.Clear();
            txtPfSklDisableDevice.Clear();
            txtPfSklDisguise.Clear();
            txtPfSklEscapeArtist.Clear();
            txtPfSklFly.Clear();
            txtPfSklHandleAnimal.Clear();
            txtPfSklHeal.Clear();
            txtPfSklIntimidate.Clear();
            txtPfSklLinguistics.Clear();
            txtPfSklPerception.Clear();
            txtPfSklPreform.Clear();
            txtPfSklProfession.Clear();
            txtPfSklRide.Clear();
            txtPfSklSenseMotive.Clear();
            txtPfSklSleightofHand.Clear();
            txtPfSklSpellCraft.Clear();
            txtPfSklStealth.Clear();
            txtPfSklSurvival.Clear();
            txtPfSklSwim.Clear();
            txtPfSklUseMagicDevice.Clear();
            txtPfSklArcana.Clear();
            txtPfSklDungeoneering.Clear();
            txtPfSklEngineering.Clear();
            txtPfSklGeography.Clear();
            txtPfSklHistory.Clear();
            txtPfSklLocal.Clear();
            txtPfSklNature.Clear();
            txtPfSklNobility.Clear();
            txtPfSklPlanes.Clear();
            txtPfSklReligion.Clear();
            inputPfAddFeat.Clear();
            inputPfAddItem.Clear();
            inputPfAddSpell.Clear();
            LSTBOXClassFeatLang.Items.Clear();
            LSTBOXitemsEquip.Items.Clear();
            TXTBOXknownSpells.Items.Clear();

            //Clear Calendar Page
        }

        /***********************************************
        *
        *       Character Button Roller Events &
        *           Dice Roller Function
        *
        *************************************************/

        private void btnPfSklAcro_Click(object sender, EventArgs e)
        {

            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklAcro.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklAppr_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklAppr.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklBluf_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklBluf.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklClimb_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklClim.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklCraft_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklCraft.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklDisguise_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklDisguise.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklHandleAnimal_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklHandleAnimal.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklProfession_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklProfession.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklLinguistics_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklLinguistics.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklHeal_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklHeal.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklEscapeArtist_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklEscapeArtist.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklDiplomacy_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklDiplomacy.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklRide_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklRide.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklPerception_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklPerception.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklFly_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklFly.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklDisableDevice_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklDisableDevice.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklPreform_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklPreform.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklIntimidate_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklIntimidate.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklPlanes_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklPlanes.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklSurvival_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklSurvival.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklNobility_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklNobility.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklSleightofHand_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklSleightofHand.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklHistory_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklHistory.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklArcana_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklArcana.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklSwim_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklSwim.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklEngineering_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklEngineering.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklSpellCraft_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklSpellCraft.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklLocal_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklLocal.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklDungeoneering_Click(object sender, EventArgs e)
        {

            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklDungeoneering.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklReligion_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklReligion.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklStealth_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklStealth.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklNature_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklNature.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklSenseMotive_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklSenseMotive.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklGeography_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklGeography.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklUseMagicDevice_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus = this.txtPfSklUseMagicDevice.Text;
            DiceRoller(check_bonus);
        }

        void DiceRoller(string check_bonus)
        {

            //error check the check bonus to make sure it's a valid entry, if not, set to 0;

            try
            {
                int result = int.Parse(check_bonus);

            }
            catch
            {
                check_bonus = "0";
            }

            int temp_check_bonus = Convert.ToInt32(check_bonus);

            // set up the random dice roller
            // C# uses random.Next as its roller, which is truley random each time, regardless of "seeding"
            Random random = new Random();
            int DiceRoller = random.Next(1, 20);
            // add the bonus to the roll
            DiceRoller = DiceRoller + temp_check_bonus;
            // output the results to the user through a dialogue box
            System.Windows.Forms.MessageBox.Show("you rolled " + DiceRoller);

        }

        /*********************************************
        *
        *       New Character, Save Character
        *           Feats, Items, Spells
        *
        *********************************************/

        private void BTNnewChar_Click(object sender, EventArgs e)
        {
            //variable declarations for use in storing character information


        }

        private void BTNSaveChar_Click(object sender, EventArgs e)
        {
            Save_Character();
        }

        private statBlockPF Save_Character()
        {
            // pulling needed information to call the constructor for a statblockPF

            string playername = this.inputPfPName.Text;
            string charactername = this.inputPfCName.Text;
            string race_level = this.inputPfRace.Text;

            // statblock is created with the above information, error checking will be implemented to ensure the required information
            // is available

            statBlockPF temp = new statBlockPF(characterLL.getLast().blockID + 1, charactername, playername, race_level);

            temp.STR = Convert.ToInt32(this.inputPfStr.Text);
            temp.DEX = Convert.ToInt32(this.inputPfDex.Text);
            temp.CON = Convert.ToInt32(this.inputPfCon.Text);
            temp.INT = Convert.ToInt32(this.inputPfInt.Text);
            temp.WIS = Convert.ToInt32(this.inputPfWis.Text);
            temp.CHA = Convert.ToInt32(this.inputPfCha.Text);
            temp.AC = Convert.ToInt32(this.inputPfAC.Text);
            temp.fort = Convert.ToInt32(this.inputPfFort.Text);
            temp.reflex = Convert.ToInt32(this.inputPfRef.Text);
            temp.will = Convert.ToInt32(this.inputPfWill.Text);
            temp.speed = Convert.ToInt32(this.inputPfSpeed.Text);
            temp.reach = Convert.ToInt32(this.inputPfReach.Text);
            temp.touchAC = Convert.ToInt32(this.inputPfTAC.Text);
            temp.flatAC = Convert.ToInt32(this.inputPfFFAC.Text);
            temp.BAB = Convert.ToInt32(this.inputPfBAB.Text);
            temp.CMB = Convert.ToInt32(this.inputPfCMB.Text);
            temp.CMD = Convert.ToInt32(this.inputPfCMD.Text);
            temp.initiaitive = Convert.ToInt32(this.inputPfInit.Text);
            temp.sklAcro = Convert.ToInt32(this.txtPfSklAcro.Text);
            temp.sklAppr = Convert.ToInt32(this.txtPfSklAppr.Text);
            temp.sklBluf = Convert.ToInt32(this.txtPfSklBluf.Text);
            temp.sklClim = Convert.ToInt32(this.txtPfSklClim.Text);
            temp.sklCraf = Convert.ToInt32(this.txtPfSklCraft.Text);
            temp.sklDipl = Convert.ToInt32(this.txtPfSklDiplomacy.Text);
            temp.sklDisa = Convert.ToInt32(this.txtPfSklDisableDevice.Text);
            temp.sklDisg = Convert.ToInt32(this.txtPfSklDisguise.Text);
            temp.sklEsca = Convert.ToInt32(this.txtPfSklEscapeArtist.Text);
            temp.sklFly = Convert.ToInt32(this.txtPfSklFly.Text);
            temp.sklHand = Convert.ToInt32(this.txtPfSklHandleAnimal.Text);
            temp.sklHeal = Convert.ToInt32(this.txtPfSklHeal.Text);
            temp.sklInti = Convert.ToInt32(this.txtPfSklIntimidate.Text);
            temp.sklLing = Convert.ToInt32(this.txtPfSklLinguistics.Text);
            temp.sklPerc = Convert.ToInt32(this.txtPfSklPerception.Text);
            temp.sklPerf = Convert.ToInt32(this.txtPfSklPreform.Text);
            temp.sklProf = Convert.ToInt32(this.txtPfSklProfession.Text);
            temp.sklRide = Convert.ToInt32(this.txtPfSklRide.Text);
            temp.sklSens = Convert.ToInt32(this.txtPfSklSenseMotive.Text);
            temp.sklSlei = Convert.ToInt32(this.txtPfSklSleightofHand.Text);
            temp.sklSpel = Convert.ToInt32(this.txtPfSklSpellCraft.Text);
            temp.sklStel = Convert.ToInt32(this.txtPfSklStealth.Text);
            temp.sklSurv = Convert.ToInt32(this.txtPfSklSurvival.Text);
            temp.sklSwim = Convert.ToInt32(this.txtPfSklSwim.Text);
            temp.sklUseD = Convert.ToInt32(this.txtPfSklUseMagicDevice.Text);
            temp.knwArca = Convert.ToInt32(this.txtPfSklArcana.Text);
            temp.knwDung = Convert.ToInt32(this.txtPfSklDungeoneering.Text);
            temp.knwEngi = Convert.ToInt32(this.txtPfSklEngineering.Text);
            temp.knwGeog = Convert.ToInt32(this.txtPfSklGeography.Text);
            temp.knwHist = Convert.ToInt32(this.txtPfSklHistory.Text);
            temp.knwLoca = Convert.ToInt32(this.txtPfSklLocal.Text);
            temp.knwNatu = Convert.ToInt32(this.txtPfSklNature.Text);
            temp.knwNobi = Convert.ToInt32(this.txtPfSklNobility.Text);
            temp.knwPlan = Convert.ToInt32(this.txtPfSklPlanes.Text);
            temp.knwReli = Convert.ToInt32(this.txtPfSklReligion.Text);

            string selected;
            LSTBOXClassFeatLang.BeginUpdate();
            //LSTBOXClassFeatLang.SelectionMode = SelectionMode.MultiExtended;
            for (int i = 0; i < LSTBOXClassFeatLang.Items.Count; i++)
            {
                LSTBOXClassFeatLang.SetSelected(i, true);

                selected = LSTBOXClassFeatLang.SelectedItem.ToString();

                temp.classFeat.Add(LSTBOXClassFeatLang.SelectedItem.ToString());

                System.Windows.Forms.MessageBox.Show(selected);

                //LSTBOXClassFeatLang.Items.Remove(selected);


            }
            LSTBOXClassFeatLang.EndUpdate();

            // return the class to the save buttons call
            return temp;
        }

        private void LSTBOXClassFeatLang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPfAddFeat_Click(object sender, EventArgs e)
        {
            //this function is to add a feat to the feature & language list box
            string added_item;
            added_item = this.inputPfAddFeat.Text;

            LSTBOXClassFeatLang.Items.Add(added_item);
            this.inputPfAddFeat.Text = "";
        }

        private void btnPfRemoveFeat_Click(object sender, EventArgs e)
        {
            //this function is to remove a feat to the feature & language list box
            string selected = LSTBOXClassFeatLang.SelectedItem.ToString();

            LSTBOXClassFeatLang.Items.Remove(selected);

        }

        private void btnPfAddItem_Click(object sender, EventArgs e)
        {
            //this function is to add equipment to the list box
            string added_item;
            added_item = this.inputPfAddItem.Text;

            LSTBOXitemsEquip.Items.Add(added_item);

            this.inputPfAddItem.Text = "";
        }

        private void btnPfRemoveItem_Click(object sender, EventArgs e)
        {
            //this function is to remove equipment to the list box
            string selected = LSTBOXitemsEquip.SelectedItem.ToString();

            LSTBOXitemsEquip.Items.Remove(selected);
        }

        private void btnPfAddSpell_Click(object sender, EventArgs e)
        {
            //this function is to add spells to the list box
            string added_item;
            added_item = this.inputPfAddSpell.Text;

            TXTBOXknownSpells.Items.Add(added_item);
            this.inputPfAddSpell.Text = "";
        }

        private void btnPfRemoveSpell_Click(object sender, EventArgs e)
        {
            //this function is to remove spells to the list box
            string selected = TXTBOXknownSpells.SelectedItem.ToString();

            TXTBOXknownSpells.Items.Remove(selected);
        }

        /**********************************
        *
        *       Random Tables Events
        *
        **********************************/

        private void BTNRollD20_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int DiceRoller = random.Next(1, 20);
            TableOutputTXTarea.Clear();
            TableOutputTXTarea.AppendText("you rolled a D20: " + DiceRoller + "\r\n");
        }

        private void BTNRollD100_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int DiceRoller = random.Next(1, 100);
            TableOutputTXTarea.Clear();
            TableOutputTXTarea.AppendText("you rolled a D100: " + DiceRoller + "\r\n");

        }

        private void BTNNewEntry_Click(object sender, EventArgs e)
        {
            //if a table is not selected - Fail
            if (TableListBox.Text == "")
            {
                MessageBox.Show("Please Select a Table from the dropdown menu" +
                    "\n or create one if you have not already!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Table is selected
            {
                int weight;
                //if description or weight are empty - Fail
                if (TXTDescription.Text == "" || TXTWeight.Text == "")
                {
                    MessageBox.Show("Please Enter a Description & Weight", "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Int32.TryParse(TXTWeight.Text, out weight) == false)
                {
                    MessageBox.Show("Please enter a number for weight!", "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // create new entry in selected table
                {
                    //Figure out which table is selected
                    int index = TableListBox.SelectedIndex;
                    string description = TXTDescription.Text;
                    weight = Convert.ToInt32(TXTWeight.Text);
                    tableLL.updateTable(index, description, weight);
                }
            }
        }

        private void BTNRemoveEntry_Click(object sender, EventArgs e)
        {
            //If empty - do nothing
            if (LSTEntryList.Text != null) //Wrong condition hmmm.
            {

            }
            //else remove currently selected from LSTEntryList
            else
            {

            }
        }

        private void BTNSaveTable_Click(object sender, EventArgs e)
        {
            //Table Name is Present
            if (TXTTableNameInput.Text != "")
            {
                randomTable insert;
                if (tableLL.getFirst() == null) //TableLL is empty
                {
                    insert = new randomTable(0);
                }
                else
                {
                    insert = new randomTable(tableLL.getLast().getID() + 1);
                }

                insert.setTitle(TXTTableNameInput.Text);
                tableLL.addTable(insert);
                TableListBox.Items.Add(TXTTableNameInput.Text);
                TableListBox.SelectedIndex = insert.getID();
                TXTTableNameInput.Clear();
            }
            //Table Name Missing - Error
            else
            {
                MessageBox.Show("Please Enter a Name for Your Table First!", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNDeleteSelectedTable_Click(object sender, EventArgs e)
        {
            tableLL.removeTable(TableListBox.SelectedIndex);
            TableListBox.Items.Clear();
            populateTablesDropdown();
        }

        private void BTNRollCustomTable_Click(object sender, EventArgs e)
        {
            if (TableListBox.SelectedIndex != -1)
            {
                TableOutputTXTarea.Clear();
                TableOutputTXTarea.AppendText(tableLL.retrieveTable(TableListBox.SelectedIndex).rollTable());
            }
            else
            {
                MessageBox.Show("Please Select a Table from the drop Down List!", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LSTEntryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TableListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displays Entries in Rich Text Box
            displayTableEntries(TableListBox.SelectedIndex);

            //Displays Entries in Drop Down
            populateEntriesDropDown();
        }

        /******************************************
        *
        *       Random Tables Functions
        *
        *******************************************/

        public void displayTableEntries(int index)
        {
            tableEntry temp = tableLL.retrieveTable(index).getFirst();
            //Empty TXTTableEntries of text
            TXTTableEntries.Clear();

            //Display each entry on the richtextbox
            for (int i = 0; i < tableLL.retrieveTable(index).getLength(); i++)
            {
                TXTTableEntries.AppendText(temp.entry + ": " + temp.weight + Environment.NewLine);
                temp = tableLL.retrieveTable(index).getNext(i);
            }
        }

        public void populateTablesDropdown()
        {

        }

        public void populateEntriesDropDown()
        {

        }
    }
}
