using DSAL_CA1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAL_CA1
{
    public partial class Form2 : Form
    {
        SmartSeatDoubleLinkedList seatList = new SmartSeatDoubleLinkedList();

        private SaveObject saveObject;
        Color[] colorArr = { Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Purple, Color.Brown, Color.Pink };
        char[] charArr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        int numRows;
        int SeatsPRow;
        int undoRedoCount = 0;
        int count = 0;
        int i;

        public Form2()
        {
            InitializeComponent();
        }

        //Close form 
        //=============================================================================
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ParentForm)this.MdiParent).form2 = null;
        }
        //=============================================================================


        //event handler when load button is clicked 
        //=============================================================================
        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when save button is clicked 
        //=============================================================================
        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when undo button is clicked 
        //=============================================================================
        private void buttonUndo_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when redo button is clicked 
        //=============================================================================
        private void buttonRedo_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when generate seats button is clicked 
        //=============================================================================
        private void buttonGenerateSeats_Click(object sender, EventArgs e)
        {

        }

        //event handler when set up safe dist. mode button is clicked 
        //=============================================================================
        private void buttonSafeDistMode_Click(object sender, EventArgs e)
        {

        }
        //=============================================================================

        //event handler when end sim. button is clicked 
        //=============================================================================
        private void buttonEndSimulation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulation has ended");
            var bookingButtons = this.Controls.OfType<Button>().Where(c => c.Tag != null && c.Tag.ToString() == "personBookingButton").ToList();
            foreach (var btn in bookingButtons)
            {
                btn.Enabled = false;
            }
            foreach (var seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                seatLabel.Enabled = false;
            }
        }
        //=============================================================================

        //event handler when reste sim. button is clicked 
        //=============================================================================
        private void buttonResetSimulation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulation has reset");
            disableManualEditor1();

            foreach (var seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                seatLabel.BackColor = Color.Green;
                //seatLabel.Click -= new EventHandler(labelSeat_Click);
            }
            foreach (var seat in this.panelSeats.Controls.OfType<Seat>())
            {
                seat.BookStatus = true;
            }
        }

        //disable manual editor function
        //=============================================================================
        private void disableManualEditor1()
        {
            buttonEditorMode.Enabled = true;
            radioDisable.Enabled = false;
            radioEnable.Enabled = false;
            buttonDisableAllSeats.Enabled = false;
            buttonEnableAllSeats.Enabled = false;
        }
        //=============================================================================

        private void disableManualEditor2()
        {
            buttonEditorMode.Enabled = false;
            radioDisable.Enabled = false;
            radioEnable.Enabled = false;
            buttonDisableAllSeats.Enabled = false;
            buttonEnableAllSeats.Enabled = false;
        }
        private void enableManualEditor()
        {
            buttonEditorMode.Enabled = false;
            radioDisable.Enabled = true;
            radioEnable.Enabled = true;
            buttonDisableAllSeats.Enabled = true;
            buttonEnableAllSeats.Enabled = true;
        }

        private void buttonEditorMode_Click(object sender, EventArgs e)
        {
            enableManualEditor();
            textMessageStatus.Text = "Editor mode has been enabled";

            foreach (var seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                seatLabel.BackColor = Color.Green;
                seatLabel.Click += new EventHandler(enableDisableSeats_Click);
            }
        }

        //event handler for when disabling or enabling seats
        //=============================================================================
        private void enableDisableSeats_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            //Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);

            if (radioEnable.Checked)
            {
                //seat.CanBook = true;
                label.BackColor = Color.Green;
            }
            else
            {
                //seat.CanBook = false;
                label.BackColor = Color.Maroon;
            }
        }
        //=============================================================================

        private void buttonEnableAllSeats_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                SeatInfo seatInfo = (SeatInfo)seatLabel.Tag;
                //Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                seatLabel.BackColor = Color.Maroon;
                //seat.CanBook = false;
            }
        }

        private void buttonDisableAllSeats_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                SeatInfo seatInfo = (SeatInfo)seatLabel.Tag;
               // Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                seatLabel.BackColor = Color.Green;
                //seat.CanBook = true;
            }
        }
        //=============================================================================
    }
}
