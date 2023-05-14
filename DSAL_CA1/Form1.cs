using DSAL_CA1.Classes;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace DSAL_CA1
{
    public partial class Form1 : Form
    {
        SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();
        ActionsDoubleLinkedList actions = new ActionsDoubleLinkedList();
        SaveObject saveObject = new SaveObject();
        Color[] colorArr = { Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Purple, Color.Brown, Color.Pink };
        char[] charArr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        int numRows;
        int SeatsPRow;
        int undoRedoCount = 0;
        int count = 0;
        int i;

        public Form1()
        {
            InitializeComponent();
            disableManualEditor1();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Close form 
        //=============================================================================
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ParentForm)this.MdiParent).form1 = null;
        }
        //=============================================================================


        //event handler when labelSeat is clicked 
        //=============================================================================
        private void labelSeat_Click(object sender, EventArgs e)
        {
            if (textMaxSeats.Text.Length > 0)
            {
                int maxSeats = Int32.Parse(textMaxSeats.Text);
                Label label = (Label)sender;
                SeatInfo seatInfo = (SeatInfo)label.Tag;
                Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                if (seat.CanBook == false)
                {
                    MessageBox.Show("This seat is unavailable for booking");
                }
                else
                {
                    if (seat.BookStatus == false)
                    {
                        seat.BookStatus = true;
                        label.BackColor = colorArr[i];
                        count++;
                    }
                    else
                    {
                        seat.BookStatus = false;
                        label.BackColor = Color.DarkGray;
                        count--;
                    }

                    if (count >= maxSeats)
                    {
                        MessageBox.Show("Maximum number of seats reached");
                        String name = "personBookingButton" + charArr[i];
                        Control btn = this.Controls[name];
                        btn.Enabled = false;
                        count = maxSeats;

                        seat.BookStatus = false;
                        label.BackColor= Color.DarkGray;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input maximum number of seats first");
            }

        }
        //=============================================================================

        //event handler when person button is clicked 
        //=============================================================================
        private void personBookingButton_Click(object sender, EventArgs e)
        {
            count = 0;
            Button btn = (Button)sender;
            String[] arr = btn.Text.Split(" ");
            Char _char = Char.Parse(arr[1]);
            for (i = 0; i < charArr.Length; i++)
            {
                if (_char == charArr[i])
                {
                    break;
                }
            }
        }
        //=============================================================================

        //event handler when load button is clicked 
        //=============================================================================
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            saveObject.ReadFromFile(seatList);

            foreach (Label seatLabel in panelSeats.Controls.OfType<Label>().ToList())
            {
                panelSeats.Controls.Remove(seatLabel);
            }//remove previous seatlabels (if any)

            List<Label> labelList = seatList.GenerateListLabels();

            foreach (Label label in labelList)
            {
                {
                    label.Click += new System.EventHandler(labelSeat_Click);
                    panelSeats.Controls.Add(label);
                }
            }
        }//end of buttonLoad 
        //=============================================================================

        //event handler when save button is clicked 
        //=============================================================================
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveObject.SaveToFile(seatList);
            saveObject.SaveToFile(actions);
        }//end of buttonSave
        //=============================================================================

        //event handler when generate button is clicked 
        //=============================================================================
        private void buttonGenerateSeats_Click_1(object sender, EventArgs e)
        {
            foreach (Label seatLabel in panelSeats.Controls.OfType<Label>().ToList())
            {
                panelSeats.Controls.Remove(seatLabel);
            }//remove previous seatlabels (if any)
            seatList.deleteAllNodes();

            //input values
            if (textNumRows.Text.Length > 0 && textSeatPRow.Text.Length > 0 && textRowDivider.Text.Length > 0 && textColumnDivider.Text.Length > 0)
            {
                numRows = Int32.Parse(textNumRows.Text);
                SeatsPRow = Int32.Parse(textSeatPRow.Text);

                String[] arrRowDivider = textRowDivider.Text.Split(",");
                textMessageStatus.Text = arrRowDivider[0];

                //parsing logic for row divider 
                if (arrRowDivider.Length > 4)
                {
                    MessageBox.Show("Not more than 4 row dividers");
                }

                String[] arrColumnDivider = textColumnDivider.Text.Split(",");

                //parsing logic for column divider 
                if (arrRowDivider.Length > 4)
                {
                    MessageBox.Show("Not more than 4 column dividers");
                }

                int i = 0;
                int j = 0;
                int yOffsetMultiplier = 0;

                for (i = 1; i <= numRows; i++)
                {
                    int xOffsetMultiplier = 0;

                    for (j = 1; j <= SeatsPRow; j++)
                    {
                        Seat s = new Seat(i, j);
                        seatList.InsertAtEnd(s);
                        Label labelSeat = s.generateSeatLabel();
                        int x = 0;
                        int y = 0;
                        int xOffset = 0;
                        int yOffset = 0;

                        xOffset = xOffsetMultiplier * 50;
                        x = 80 + (80 * (j - 1)) + xOffset;

                        yOffset = yOffsetMultiplier * 50;
                        y = 100 + (80 * (i - 1)) + yOffset;

                        labelSeat.Location = new Point(x, y);
                        labelSeat.Click += new EventHandler(labelSeat_Click);
                        //Add control to panelSeats
                        this.panelSeats.Controls.Add(labelSeat);
                        if (xOffsetMultiplier < arrColumnDivider.Length && j == int.Parse(arrColumnDivider[xOffsetMultiplier]))
                        {
                            xOffsetMultiplier++;
                        }
                    }
                    if (yOffsetMultiplier < arrRowDivider.Length && i == int.Parse(arrRowDivider[yOffsetMultiplier]))
                    {
                        yOffsetMultiplier++;
                    }
                }

                generateBookingButtons(); // generate booking buttons
                disableManualEditor2();
            }
            else
            {
                MessageBox.Show("please input values before generating");
            }
        }//end of generate seats
        //=============================================================================

        //event handler when button end simulation is clicked 
        //=============================================================================
        private void buttonEndSimulation_Click(object sender, EventArgs e)
        {
            var bookingButtons = this.Controls.OfType<Button>().Where(c => c.Tag != null && c.Tag.ToString() == "personBookingButton").ToList();
            foreach (var btn in bookingButtons)
            {
                btn.Enabled = false;
            } 
            foreach (var seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                seatLabel.Enabled = false;
            }
        }//end of end simulation
        //=============================================================================

        // event handler when button reset simulation is clicked 
        //=============================================================================
        private void buttonResetSimulation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulation has reset");
            disableManualEditor1();

            foreach (var seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                seatLabel.BackColor = Color.Green;
                seatLabel.Click -= new EventHandler(labelSeat_Click);
            }
            foreach (var seat in this.panelSeats.Controls.OfType<Seat>())
            {
                seat.BookStatus = true;
            }
        }//end of reset simulation
        //=============================================================================

        //generate booking button function
        //=============================================================================
        private void generateBookingButtons()
        {
            short num;
            int intNumPeople = 4;

            if (Int16.TryParse(textNumPeople.Text, out num))
            {
                if (num < 4)
                {
                    MessageBox.Show("There needs to be at least 4 people");
                }
                if (num > 0)
                {
                    intNumPeople = num;
                }
            }

            for (int i = 0; i < intNumPeople; i++)
            {
                Person person = new Person(charArr[i]);
                Button newButton = person.generatePersonButton(colorArr[i]);
                newButton.Location = new Point(25, textMaxSeats.Bottom + 10 + (i * 40));
                newButton.Name = "personBookingButton" + charArr[i];
                newButton.Tag = charArr[i];
                this.Controls.Add(newButton);
                newButton.Click += new EventHandler(personBookingButton_Click);
            }
        }
        //=============================================================================

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

        //event handler for when enter editor mode button is clicked 
        //=============================================================================
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
        //=============================================================================

        //event handler for when disabling or enabling seats
        //=============================================================================
        private void enableDisableSeats_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);

            if (radioEnable.Checked)
            {
                seat.CanBook = true;
                label.BackColor = Color.Green;
            }
            else
            {
                seat.CanBook = false;
                label.BackColor = Color.Maroon;
            }
        }
        //=============================================================================

        //event handler when disable all seats button is clicked 
        //=============================================================================
        private void buttonDisableAllSeats_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                SeatInfo seatInfo = (SeatInfo)seatLabel.Tag;
                Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                seatLabel.BackColor = Color.Maroon;
                seat.CanBook = false;
            }
        }
        //=============================================================================

        //event handler when enable all seats button is clicked 
        //=============================================================================
        private void buttonEnableAllSeats_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                SeatInfo seatInfo = (SeatInfo)seatLabel.Tag;
                Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                seatLabel.BackColor = Color.Green;
                seat.CanBook = true;
            }
        }
        //=============================================================================

        //event handler when undo button is clicked 
        //=============================================================================
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            actions.Undo();
        }// end of undo
        //=============================================================================

        //event handler when redo button is clicked 
        //=============================================================================
        private void buttonRedo_Click(object sender, EventArgs e)
        {
            actions.Redo();
        }// end of redo 
    }
}