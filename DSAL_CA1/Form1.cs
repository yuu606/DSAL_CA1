using DSAL_CA1.Classes;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace DSAL_CA1
{
    public partial class Form1 : Form
    {
        SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();
        SaveObject saveObject = new SaveObject();
        Color[] colorArr = { Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Purple, Color.Brown, Color.Pink };
        char[] charArr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        int numRows;
        int SeatsPRow;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ParentForm)this.MdiParent).form1 = null;
        }

        private void labelSeat_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            if (seat.BookStatus == false)
            {
                seat.BookStatus = true;
                label.BackColor = Color.LightGreen;
            }
            else
            {
                seat.BookStatus = false;
                label.BackColor = Color.LightBlue;
            }
        }

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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveObject.SaveToFile(seatList);
        }//end of buttonSave

        private void buttonGenerateSeats_Click_1(object sender, EventArgs e)
        {
            //input values
            if (textNumRows.Text.Length > 0 && textSeatPRow.Text.Length > 0 && textRowDivider.Text.Length > 0 && textColumnDivider.Text.Length > 0)
            {
                numRows = Int32.Parse(textNumRows.Text);
                SeatsPRow = Int32.Parse(textSeatPRow.Text);

                //parsing logic for row divider 
                if (textRowDivider.Text.Length > 1)
                {
                    String strRowDivider = textRowDivider.ToString();
                    String[] arrRowDivider = strRowDivider.Split(",");
                }
                else
                {
                    int RowDivider = Int32.Parse(textRowDivider.Text);
                }

                //parsing logic for column divider 
                if (textColumnDivider.Text.Length > 1)
                {
                    String strRowDivider = textRowDivider.ToString();
                    String[] arrRowDivider = strRowDivider.Split(",");
                }
                else
                {
                    int ColumnDivider = Int32.Parse(textColumnDivider.Text);
                }

                for (int i = 1; i <= numRows; i++)
                {
                    for (int j = 1; j <= SeatsPRow; j++)
                    {
                        Seat s = new Seat(i, j);
                        seatList.InsertAtEnd(s);
                        Label labelSeat = s.generateSeatLabel();
                        labelSeat.Click += new EventHandler(labelSeat_Click);
                        //Add control to panelSeats
                        this.panelSeats.Controls.Add(labelSeat);
                    }
                }

                generateBookingButtons(); // generate booking buttons
            }
            else
            {
                MessageBox.Show("please input values before generating");
            }
        }//end of generate seats

        private void buttonEndSimulation_Click(object sender, EventArgs e)
        {

        }//end of end simulation

        private void buttonResetSimulation_Click(object sender, EventArgs e)
        {

        }//end of reset simulation

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
                newButton.Location = new Point(25, 390 + (i * 40));
                this.Controls.Add(newButton);
            }
        }

        private void panelSeats_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}