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
        SeatDoubleLinkedList seatList = new();
        ActionsList actionsList;
        List<Person> persons = new();
        List<Button> personButtons = new();
        List<Label> labelSeats = new();
        SaveObject saveObject = new();
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
                if (seat.CanBook == false)
                {
                    MessageBox.Show("This seat is unavailable for booking");
                }
                else
                {
                    if (count >= maxSeats)
                    {
                        MessageBox.Show("Maximum number of seats reached");
                        Button btn = personButtons[i];
                        btn.Enabled = false;
                        foreach (Label labels in labelSeats)
                        {
                            {
                                labels.Click -= new System.EventHandler(labelSeat_Click);
                            }
                        }
                        return;
                    }

                    if (seat.BookStatus == false && count <= maxSeats)
                    {
                        Node<Seat> p = seatList.GetNode(seat.Row, seat.Column);
                        //insert in adjacent seat booking logic here
                        seat.BookStatus = true;
                        seat.Person = persons[i];
                        seat.Color = colorArr[i];
                        label.BackColor = seat.Color;
                        count++;

                        BookAction book = new BookAction(seat, seat.Person, label);
                        actionsList._redoStack.Push(book);
                    }
                    else
                    {
                        seat.BookStatus = false;
                        seat.Person = persons[i];
                        seat.Color = Color.Gray;
                        label.BackColor = seat.Color;
                        count--;

                        UnbookAction unbook = new UnbookAction(seat, seat.Person, label);
                        actionsList._redoStack.Push(unbook);
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
                foreach (Label labels in labelSeats)
                {
                    labels.Click += labelSeat_Click;
                    labels.BackColor = Color.Gray;
                }

                Node<Seat> start = seatList.Head;

                while (start != null)
                {
                    start.Data.CanBook = true;
                    start = start.Next;
                }

                count = 0;
                Button btn = (Button)sender;
                string[] arr = btn.Text.Split(" ");
                char _char = char.Parse(arr[1]);
                for (i = 0; i < charArr.Length; i++)
                {
                    if (_char == charArr[i])
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input maximum number of seats first");
            }
        }
        //=============================================================================

        //event handler when load button is clicked 
        //=============================================================================
        private void buttonLoad_Click(object sender, EventArgs e)
        {

            foreach (Label seatLabel in labelSeats)
            {
                panelSeats.Controls.Remove(seatLabel);
            }//remove previous seatlabels (if any)

            string filePath;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\..\\Data"));
            openFileDialog.Filter = "Data Files (*.dat)|*.dat";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                BinaryFormatter f = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);

                if (stream.Length != 0)
                {
#pragma warning disable SYSLIB0011
                    seatList = (SeatDoubleLinkedList)f.Deserialize(stream);
                }
                stream.Close();
            }

            panelSeats.Controls.Clear();

            numRows = int.Parse(textNumRows.Text);
            SeatsPRow = int.Parse(textSeatPRow.Text);
            String[] arrRowDivider = textRowDivider.Text.Split(",");
            String[] arrColumnDivider = textColumnDivider.Text.Split(",");

            List<Label> labelList = GenerateListLabels(numRows, SeatsPRow, arrColumnDivider, arrRowDivider);

            foreach (Label label in labelList)
            {
                label.Click += new System.EventHandler(labelSeat_Click);
                panelSeats.Controls.Add(label);

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
                numRows = int.Parse(textNumRows.Text);
                SeatsPRow = int.Parse(textSeatPRow.Text);

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
                    seatLabel.Click -= new EventHandler(labelSeat_Click);
                }

                Node<Seat> Start = seatList.Head;
                while (Start != null)
                {
                    Start.Data.CanBook = false;
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

            short num;
            int intNumPeople = 4;

            if (Int16.TryParse(textNumPeople.Text, out num))
            {
                if (num < 4)
                {
                    MessageBox.Show("There needs to be at least 4 people");
                    return;
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
                persons.Add(person);
                personButtons.Add(newButton);

                newButton.Location = new Point(25, textMaxSeats.Bottom + 10 + (i * 40));
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

            foreach (var seatLabel in labelSeats)
            {
                seatLabel.BackColor = Color.Green;
                seatLabel.Click += new EventHandler(enableDisableSeats_Click);
            }

            Node<Seat> Start = seatList.Head;
            while (Start != null)
            {
                Start.Data.CanBook = true;
                Start = Start.Next;
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
            foreach (Label seatLabel in labelSeats)
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