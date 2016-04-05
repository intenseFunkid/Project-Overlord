using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectOverlord {
    public partial class Form1 : Form {

        gameDateList testgDate = new gameDateList();
        dateList testDate = new dateList();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        //TEST
        private void btnTestAssign_Click(object sender, EventArgs e) {
            dateEntry newEntry = new dateEntry(Convert.ToInt32(txtGDateID.Text), 
                                                txtGEntry.Text,
                                                txtSessionEntry.Text, 
                                                Convert.ToInt32(txtGDSID.Text), 
                                                Convert.ToInt32(txtGDEID.Text));
            testDate.addEntry(newEntry);
        }

        //TEST
        private void btnTestRecall_Click(object sender, EventArgs e) {
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
            txtGDateID.Text = testDate.getFirstID().ToString();
        }

        private void txtTestRemove_Click(object sender, EventArgs e)
        {
            testDate.removeEntry(Convert.ToInt32(txtGDateID.Text));
        }

    }
}
