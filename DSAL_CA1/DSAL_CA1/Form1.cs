using DSAL_CA1.Classes;
using System.ComponentModel;
using System.Configuration;
using System.Data.Common;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms.VisualStyles;

namespace DSAL_CA1
{
    public partial class Form1 : Form
    {
        private SeatDoubleLinkedList seatList = new();
        private ActionsList actionsList;
        private List<Person> persons = new();
        private List<Button> personButtons = new();
        private List<Label> labelSeats = new();
        private SaveObject saveObject;
        private CinemaState cinemaState;
        Color[] colorArr = { Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Purple, Color.Brown, Color.Pink };
        char[] charArr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        int numRows;
        int SeatsPRow;
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
                int maxSeats = int.Parse(textMaxSeats.Text);
                Label label = (Label)sender;
                SeatInfo seatInfo = (SeatInfo)label.Tag;
                Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                Node<Seat> seatNode = seatList.GetNode(seatInfo.Row, seatInfo.Column);

                if (seat.CanBook == false)
                {
                    MessageBox.Show("This seat is unavailable for booking");
                }
                else
                {
                    
                    var personSeatTail = persons[i]._PersonSeatNodeDoubleLinkedList.Tail;
                    var personSeatHead = persons[i]._PersonSeatNodeDoubleLinkedList.Head;
                    var Start = seatList.Head;

                    if (count == 0)
                    {
                        persons[i]._PersonSeatNodeDoubleLinkedList.InsertAtEnd(seat);
                        seatNode = persons[i]._PersonSeatNodeDoubleLinkedList.Head;
                    }

                    while (Start != null)
                    {
                        if (personSeatHead.Equals(Start))
                        {
                            personSeatHead = Start;
                        }

                        Start = Start.Next;
                    }
                    while (Start != null)
                    {
                        if (personSeatHead.Equals(Start) && Start.Prev != null)
                        {
                            personSeatHead = Start.Prev;
                        }

                        if (personSeatHead.Equals(personSeatTail) && Start.Next != null)
                        {
                            personSeatTail = Start.Next;
                        }

                        Start = Start.Next;
                    }


                    if (seat.BookStatus == false && count <= maxSeats)
                    {
                        Node<Seat> p = seatList.GetNode(seat.Row, seat.Column);
                        seat.BookStatus = true;
                        seat.Person = persons[i];
                        seat.Color = colorArr[i];
                        label.BackColor = seat.Color;
                        count++;
                        persons[i]._PersonSeatNodeDoubleLinkedList.InsertAtEnd(seat);

                        BookAction book = new(seat, seat.Person, label);
                        actionsList._redoStack.Push(book);
                    }
                    else if (seat.BookStatus == true && count <= maxSeats)
                    {
                        seat.BookStatus = false;
                        seat.Person = persons[i];
                        seat.Color = Color.Gray;
                        label.BackColor = seat.Color;
                        count--;
                        persons[i]._PersonSeatNodeDoubleLinkedList.RemoveAtEnd(seat);

                        UnbookAction unbook = new(seat, seat.Person, label);
                        actionsList._redoStack.Push(unbook);
                    }
                    else
                    {
                        seat.BookStatus = true;
                        seat.Person = persons[i];
                        seat.Color = colorArr[i];
                        label.BackColor = seat.Color;
                        count++;
                        persons[i]._PersonSeatNodeDoubleLinkedList.InsertAtBeginning(seat);

                        BookAction book = new(seat, seat.Person, label);
                        actionsList._redoStack.Push(book);
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
            if (textMaxSeats.Text.Length > 0)
            {
                Button btn = (Button)sender;
                if (btn.Tag.Equals(charArr[0]))
                {
                    foreach (Label labels in labelSeats)
                    {
                        labels.BackColor = Color.Gray;
                    }

                    Node<Seat> start = seatList.Head;

                    while (start != null)
                    {
                        start.Data.CanBook = true;
                        start = start.Next;
                    }
                }

                foreach (Label labels in labelSeats)
                {
                    labels.Click += labelSeat_Click;
                }

                count = 0;
                for (i = 0; i < charArr.Length; i++)
                {
                    if (btn.Tag.Equals(charArr[i]))
                    {
                        break;
                    }
                }

                textMessageStatus.Text = "Person " + persons[i]._Char + " is booking";
            } else
            {
                MessageBox.Show("Please input maximum number of seats first");
            }
        }
        //=============================================================================

        //event handler when load button is clicked 
        //=============================================================================
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (cinemaState != null)
            {
                foreach (Label seatLabel in labelSeats)
                {
                    panelSeats.Controls.Remove(seatLabel);
                }//remove previous seatlabels

                foreach (Button btn in personButtons)
                {
                    Controls.Remove(btn);
                }//remove previous person booking buttons

                cinemaState = saveObject.ReadFromFile();

                numRows = int.Parse(textNumRows.Text);
                SeatsPRow = int.Parse(textSeatPRow.Text);
                String[] arrRowDivider = textRowDivider.Text.Split(",");
                String[] arrColumnDivider = textColumnDivider.Text.Split(",");
                //seatlist
                //persons list
                //personButtons list
                labelSeats = GenerateListLabels(numRows, SeatsPRow, arrColumnDivider, arrRowDivider);

                foreach (Label label in labelSeats)
                {
                    label.Click += new System.EventHandler(labelSeat_Click);
                    panelSeats.Controls.Add(label);

                }
            }
            else
            {
                MessageBox.Show("You have not saved anything");
            }
        }//end of buttonLoad 
        //=============================================================================

        //event handler when save button is clicked 
        //=============================================================================
        private void buttonSave_Click(object sender, EventArgs e)
        {
            cinemaState = new();
            saveObject = new(cinemaState);
            saveObject.SaveToFile();
        }//end of buttonSave
        //=============================================================================

        //event handler when generate button is clicked 
        //=============================================================================
        private void buttonGenerateSeats_Click_1(object sender, EventArgs e)
        {
            foreach (Label seatLabel in labelSeats)
            {
                panelSeats.Controls.Remove(seatLabel); //remove previous seatlabels (if any)
            }

            foreach (Button btn in personButtons)
            {
                Controls.Remove(btn);
            }

            personButtons.Clear();
            labelSeats.Clear();
            persons.Clear();

            //input values
            if (textNumRows.Text.Length > 0 && textSeatPRow.Text.Length > 0 && textRowDivider.Text.Length > 0 && textColumnDivider.Text.Length > 0)
            {
                int numPeople = int.Parse(textNumPeople.Text);
                if (numPeople < 4 || numPeople > 7)
                {
                    MessageBox.Show("The number of people should be between 4 and 7");
                }
                else
                {
                    numRows = int.Parse(textNumRows.Text);
                    SeatsPRow = int.Parse(textSeatPRow.Text);

                    String[] arrRowDivider = textRowDivider.Text.Split(",");

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

                    int yOffsetMultiplier = 0;

                    for (int i = 1; i <= numRows; i++)
                    {
                        int xOffsetMultiplier = 0;

                        for (int j = 1; j <= SeatsPRow; j++)
                        {
                            Seat s = new Seat(i, j);
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
                            //Add control to panelSeats
                            this.panelSeats.Controls.Add(labelSeat);
                            if (xOffsetMultiplier < arrColumnDivider.Length && j == int.Parse(arrColumnDivider[xOffsetMultiplier]))
                            {
                                xOffsetMultiplier++;
                            }

                            labelSeats.Add(labelSeat);
                            seatList.InsertAtEnd(s);
                        }
                        if (yOffsetMultiplier < arrRowDivider.Length && i == int.Parse(arrRowDivider[yOffsetMultiplier]))
                        {
                            yOffsetMultiplier++;
                        }
                    }

                    actionsList = new(labelSeats, seatList);
                    generateBookingButtons(); // generate booking buttons
                    disableManualEditor2();
                }
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
            foreach (Button btn in personButtons)
            {
                btn.Enabled = false;
            }
            foreach (Label lbl in labelSeats)
            {
                lbl.Enabled = false;
            }
            MessageBox.Show("Simulation has ended");
        }//end of end simulation
        //=============================================================================

        // event handler when button reset simulation is clicked 
        //=============================================================================
        private void buttonResetSimulation_Click(object sender, EventArgs e)
        {
            if (seatList != null)
            {
                MessageBox.Show("Simulation has reset");
                disableManualEditor1();

                foreach (Label seatLabel in labelSeats)
                {
                    seatLabel.BackColor = Color.Green;
                }

                Node<Seat> Start = seatList.Head;
                while (Start != null)
                {
                    Start.Data.CanBook = true;
                    Start = Start.Next;
                }
            }
            else
            {
                MessageBox.Show("You have no seats set up");
            }
        }//end of reset simulation
        //=============================================================================

        //generate booking button function
        //=============================================================================
        private void generateBookingButtons()
        {
            foreach (Button btn in personButtons)
            {
                Controls.Remove(btn);
            }

            if (Int16.TryParse(textNumPeople.Text, out short num))
            {
                for (int i = 0; i < num; i++)
                {
                    SeatDoubleLinkedList seatDoubleLinkedList = new();
                    Person person = new Person(charArr[i], seatDoubleLinkedList);
                    Button newButton = person.generatePersonButton(colorArr[i]);

                    newButton.Location = new Point(25, textMaxSeats.Bottom + 10 + (i * 40));
                    newButton.Tag = charArr[i];
                    this.Controls.Add(newButton);
                    newButton.Click += personBookingButton_Click;

                    persons.Add(person);
                    personButtons.Add(newButton);
                }

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
            buttonEditorMode.Enabled = true;
            radioDisable.Enabled = true;
            radioEnable.Enabled = true;
            buttonDisableAllSeats.Enabled = true;
            buttonEnableAllSeats.Enabled = true;
        }

        //event handler for when enter editor mode button is clicked 
        //=============================================================================
        private void buttonEditorMode_Click(object sender, EventArgs e)
        {
            textMessageStatus.Text = "Editor mode has been enabled";

            if (buttonEditorMode.Text.Equals("Enter Editor Mode"))
            {
                enableManualEditor();
                buttonEditorMode.Text = "Exit Editor Mode";
                foreach (var seatLabel in labelSeats)
                {
                    SeatInfo seatInfo = (SeatInfo)seatLabel.Tag;
                    Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                    if (seat.CanBook == true)
                    {
                        seatLabel.BackColor = Color.Green;
                    }
                    seatLabel.Enabled = true;
                    seatLabel.Click -= labelSeat_Click;
                    seatLabel.Click += enableDisableSeats_Click;
                }

                Node<Seat> Start = seatList.Head;
                while (Start != null)
                {
                    Start.Data.CanBook = true;
                    Start = Start.Next;
                }

                textMessageStatus.Text = "Entered Editor Mode";
            }
            else
            {
                buttonEditorMode.Text = "Enter Editor Mode"; //change button text
                disableManualEditor1(); // disable other controls

                foreach (var seatLabel in labelSeats)
                {
                    SeatInfo seatInfo = (SeatInfo)seatLabel.Tag;
                    Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);

                    if (seat.CanBook == true)
                    {
                        seatLabel.BackColor = Color.DarkGray;
                    }// leave disabled seats' color to be red

                    seatLabel.Click -= enableDisableSeats_Click;
                } // change event handler

                textMessageStatus.Text = "Exited Editor Mode";
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
            
            if (radioDisable.Checked)
            {
                seat.CanBook = false;
                label.BackColor = Color.DarkRed;
            }
        }
        //=============================================================================

        //event handler when disable all seats button is clicked 
        //=============================================================================
        private void buttonDisableAllSeats_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in labelSeats)
            {
                SeatInfo seatInfo = (SeatInfo)seatLabel.Tag;
                Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                seatLabel.BackColor = Color.DarkRed;
                seat.CanBook = false;
            }
        }
        //=============================================================================

        //event handler when enable all seats button is clicked 
        //=============================================================================
        private void buttonEnableAllSeats_Click(object sender, EventArgs e)
        {
            foreach (Label seatLabel in labelSeats)
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
            actionsList.Undo();
        }// end of undo
        //=============================================================================

        //event handler when redo button is clicked 
        //=============================================================================
        private void buttonRedo_Click(object sender, EventArgs e)
        {
            actionsList.Redo();
        }// end of redo 

        public List<Label> GenerateListLabels(int numRows, int SeatsPRow, String[] arrColumnDivider, String[] arrRowDivider)
        {
            List<Label> labels = new List<Label>();
            Node<Seat> p = seatList.Head;
            while (p != null)
            {
                int yOffsetMultiplier = 0;

                for (int i = 1; i <= numRows; i++)
                {
                    int xOffsetMultiplier = 0;

                    for (int j = 1; j <= SeatsPRow; j++)
                    {
                        Label labelSeat = p.Data.generateSeatLabel();
                        int x = 0;
                        int y = 0;
                        int xOffset = 0;
                        int yOffset = 0;

                        xOffset = xOffsetMultiplier * 50;
                        x = 80 + (80 * (j - 1)) + xOffset;

                        yOffset = yOffsetMultiplier * 50;
                        y = 100 + (80 * (i - 1)) + yOffset;

                        labelSeat.Location = new Point(x, y);
                        //Add control to panelSeats
                        this.panelSeats.Controls.Add(labelSeat);
                        if (xOffsetMultiplier < arrColumnDivider.Length && j == int.Parse(arrColumnDivider[xOffsetMultiplier]))
                        {
                            xOffsetMultiplier++;
                        }
                        labels.Add(labelSeat);
                    }
                    if (yOffsetMultiplier < arrRowDivider.Length && i == int.Parse(arrRowDivider[yOffsetMultiplier]))
                    {
                        yOffsetMultiplier++;
                    }
                }

                p = p.Next; //Continue to the next node
            }//While loop
            if (p == null)
            {
                return labels;
            }
            else
            {
                return labels;
            }//End of if..else block
        }
    }
}