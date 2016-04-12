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
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklAcro.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklAppr_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklAppr.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklBluf_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklBluf.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklClimb_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklClim.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklCraft_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklCraft.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklDisguise_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklDisguise.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklHandleAnimal_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklHandleAnimal.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklProfession_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklProfession.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklLinguistics_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklLinguistics.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklHeal_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklHeal.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklEscapeArtist_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklEscapeArtist.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklDiplomacy_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklDiplomacy.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklRide_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklRide.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklPerception_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklPerception.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklFly_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklFly.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklDisableDevice_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklDisableDevice.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklPreform_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklPreform.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklIntimidate_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklIntimidate.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklPlanes_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklPlanes.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklSurvival_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklSurvival.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklNobility_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklNobility.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklSleightofHand_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklSleightofHand.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklHistory_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklHistory.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklArcana_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklArcana.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklSwim_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklSwim.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklEngineering_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklEngineering.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklSpellCraft_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklSpellCraft.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklLocal_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklLocal.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklDungeoneering_Click(object sender, EventArgs e)
        {

            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklDungeoneering.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklReligion_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklReligion.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklStealth_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklStealth.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklNature_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklNature.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklSenseMotive_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklSenseMotive.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklGeography_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklGeography.Text);
            DiceRoller(check_bonus);
        }

        private void btnPfSklUseMagicDevice_Click(object sender, EventArgs e)
        {
            // obtain the skillcheck bonus from the box
            int check_bonus;
            // convert this to an integer for roll use
            check_bonus = Convert.ToInt32(this.txtPfSklUseMagicDevice.Text);
            DiceRoller(check_bonus);
        }






        void DiceRoller(int check_bonus)
        {
            // set up the random dice roller
            // C# uses random.Next as its roller, which is truley random each time, regardless of "seeding"
            Random random = new Random();
            int DiceRoller = random.Next(1, 20);
            // add the bonus to the roll
            DiceRoller = DiceRoller + check_bonus;
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

       
    }
}
