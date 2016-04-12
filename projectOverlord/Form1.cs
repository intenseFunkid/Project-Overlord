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
        randomTableList testTList = new randomTableList();
        randomTable testTable = new randomTable(0);
        randomTable testTable2 = new randomTable(1);
        randomTable testTable3 = new randomTable(2);
        

        public Form1() {
            InitializeComponent();

            tableEntry tent1 = new tableEntry("test1", 10);
            tableEntry tent2 = new tableEntry("test2", 8);
            tableEntry tent3 = new tableEntry("test3", 15);
            tableEntry tent4 = new tableEntry("test4", 2);
            tableEntry tent5 = new tableEntry("test5", 25);
            tableEntry tent6 = new tableEntry("test6", 14);

            testTable2.addEntry(tent1);
            testTable2.addEntry(tent2);
            testTable2.addEntry(tent3);
            testTable3.addEntry(tent4);
            testTable3.addEntry(tent5);
            testTable3.addEntry(tent6);

            testTList.addTable(testTable2);
            testTList.addTable(testTable3);
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

        private void btnFirstID_Click(object sender, EventArgs e) {
            txtGDateID.Text = testDate.getFirst().dateID.ToString();
        }

        private void txtTestRemove_Click(object sender, EventArgs e) {
            testDate.removeEntry(Convert.ToInt32(txtGDateID.Text));
        }

        //TABLE TEST

        private void BTNNewEntry_Click(object sender, EventArgs e) {
            tableEntry add = new tableEntry(TXTDescription.Text, Convert.ToInt32(TXTWeight.Text));
            testTable.addEntry(add);
            populateTableDisplay(testTable);
        }

        private void BTNRemoveEntry_Click(object sender, EventArgs e) {
            testTable.removeEntry(TXTDescription.Text);
            populateTableDisplay(testTable);
        }

        private void BTNRollCustomTable_Click(object sender, EventArgs e) {
            TableOutputTXTarea.Text = testTable.rollTable();
        }

        private void populateTableDisplay (randomTable table) {
            lstTableDisplay.Items.Clear();

            
            tableEntry index = table.getFirst();

            for (int i = 0; i < table.getLength(); i++) {
                lstTableDisplay.Items.Add((index.weight + " -- " + index.entry));
                index = table.getNext(index.entry);
            }
        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            //testTList.addTable(testTable);
            testTable = testTList.retrieveTable(Convert.ToInt32(txtTableNumber.Text));

            TXTDescription.Text = "";
            TXTWeight.Text = "";
            TXTTableNameInput.Text = testTable.getTitle();

            populateTableDisplay(testTable);
        }

        private void btnTableNew_Click(object sender, EventArgs e)
        {

        }


    }
}
