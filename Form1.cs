using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabCalendar_Click(object sender, EventArgs e)
        {

        }

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
            check_bonus =this.txtPfSklDisableDevice.Text;
            DiceRoller(check_bonus);
        }

        private void btnPfSklPreform_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            string check_bonus;
            // convert this to an integer for roll use
            check_bonus =this.txtPfSklPreform.Text;
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

        private void txtPfSklintimidate_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNRollD20_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int DiceRoller = random.Next(1, 20);
            TableOutputTXTarea.AppendText("you rolled a D20: " + DiceRoller + "\r\n");
        }

        private void BTNRollD100_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int DiceRoller = random.Next(1, 100);
            TableOutputTXTarea.AppendText("you rolled a D100: " + DiceRoller + "\r\n");
            
        }

        private void TableOutputTXTarea_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNnewChar_Click(object sender, EventArgs e)
        {
            //variable declarations for use in storing character information
            

        }




        private statBlockPF Save_Character()
        {
            // pulling needed information to call the constructor for a statblockPF

            string playername = this.inputPfPName.Text;
            string charactername = this.inputPfCName.Text;
            string race_level = this.inputPfRace.Text;

            // statblock is created with the above information, error checking will be implemented to ensure the required information
            // is available

            statBlockPF temp = new statBlockPF(0, charactername, playername, race_level);

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
            temp.sklLing = Convert.ToInt32(this.txtPfSklLinguistics.Text); temp.sklPerc = Convert.ToInt32(this.txtPfSklPerception.Text);
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

        private void btnPfAddSpell_Click(object sender, EventArgs e)
        {
            //this function is to add spells to the list box
            string added_item;
            added_item = this.inputPfAddSpell.Text;

            TXTBOXknownSpells.Items.Add(added_item);
            this.inputPfAddSpell.Text = "";
        }

        private void btnPfRemoveItem_Click(object sender, EventArgs e)
        {
            //this function is to remove equipment to the list box
            string selected = LSTBOXitemsEquip.SelectedItem.ToString();

            LSTBOXitemsEquip.Items.Remove(selected);
        }

        private void btnPfRemoveSpell_Click(object sender, EventArgs e)
        {
            //this function is to remove spells to the list box
            string selected = TXTBOXknownSpells.SelectedItem.ToString();

            TXTBOXknownSpells.Items.Remove(selected);
        }

        




    }
}
