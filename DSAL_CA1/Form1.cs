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

            List<Label> labelList = seatList.GenerateLabels();

            foreach (Label label in labelList)
            {
                {
                    label.Click += new System.EventHandler(labelSeat_Click);
                }
            }
        }//end of buttonLoad 
        //=============================================================================

        //event handler when save button is clicked 
        //=============================================================================
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveObject.SaveToFile(seatList);
        }//end of buttonSave
        //=============================================================================

        //event handler when generate button is clicked 
        //=============================================================================
        private void buttonGenerateSeats_Click_1(object sender, EventArgs e)
        {
            foreach (var seatLabel in this.panelSeats.Controls.OfType<Label>())
            {
                Controls.Remove(seatLabel);
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
                if (arrRowDivider.Length > 3)
                {
                    MessageBox.Show("Not more than 3 row dividers");
                }

                String[] arrColumnDivider = textColumnDivider.Text.Split(",");

                //parsing logic for column divider 
                if (arrRowDivider.Length > 3)
                {
                    MessageBox.Show("Not more than 3 column dividers");
                }

                int i = 0;
                int j = 0;
                int k = 0;
                int l = 0;
                bool done = false;
                bool done2 = false;

                for (i = 1; i <= numRows; i++)
                {
                    for (j = 1; j <= SeatsPRow; j++)
                    {
                        Seat s = new Seat(i, j);
                        seatList.InsertAtEnd(s);
                        Label labelSeat = s.generateSeatLabel();
                        int x = 0;
                        int y = 0;

                        for (k = 0; k < arrColumnDivider.Length; k++)
                        {
                            if (done)
                            {
                                k++;
                            }
                            if (j > Int32.Parse(arrColumnDivider[k]))
                            {
                                int temp = Int32.Parse(arrColumnDivider[k]) * 10 * (k + 1);
                                x = (80 + (80 * (j - 1)) + (temp));
                                break;
                            }
                            else
                            {
                                x = (60 * (j - 1)) + 80 + (20 * (j - 1));
                            }
                        }

                        for (l = 0; l < arrRowDivider.Length; l++)
                        {
                            if (done2)
                            {
                                l++;
                            }

                            if (i > Int32.Parse(arrRowDivider[l]))
                            {
                                int temp = Int32.Parse(arrRowDivider[l]) * 10 * (l + 1);
                                y = (100 + (80 * (i - 1) + (temp)));
                                done2 = true;
                                break;
                            }
                            else
                            {
                                y = (60 * (i - 1)) + 100 + (20 * (i - 1));
                            }
                        }

                        labelSeat.Location = new Point(x, y);
                        labelSeat.Click += new EventHandler(labelSeat_Click);
                        //Add control to panelSeats
                        this.panelSeats.Controls.Add(labelSeat);
                    }
                }

                generateBookingButtons(); // generate booking buttons
                disbaleManualEditor2();
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
                if (num > 0)
                {
                    intNumPeople = num;
                }
            }

            for (int i = 0; i < intNumPeople; i++)
            {
                Person person = new Person(charArr[i]);
                Button newButton = person.generatePersonButton(colorArr[i]);
                newButton.Location = new Point(25, 410 + (i * 40));
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

        private void disbaleManualEditor2()
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
            undoRedoCount--;
        }// end of undo
        //=============================================================================

        //event handler when redo button is clicked 
        //=============================================================================
        private void buttonRedo_Click(object sender, EventArgs e)
        {
            undoRedoCount++;
        }// end of redo 
    }
}