using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class Seat
    {
        private bool _bookStatus = false;
        private bool _canBook = false;
        private int _row;
        private int _column;

        public Seat( int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row //property
        {
            get { return _row; }//get method
            set
            {
                _row = value;
            }//set method
        }

        public int Column //property
        {
            get { return _column; } //get method
            set
            {
                _column = value;
            } //set method
        }

        public bool CanBook
        {
            get { return _canBook; } //get method
            set
            {
                _canBook = value;
            }
        }

        public bool BookStatus
        {
            get { return _bookStatus; } //get method
            set
            {
                _bookStatus = value;
            }
        }

        public string ComputeSeatLabel()
        {
            return ((char)(_row + 64)).ToString() + _column.ToString();
        }//end of ComputeSeatLabel

        public Label generateSeatLabel()
        {
            Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
            labelSeat.Text = ComputeSeatLabel();//Set the Text property by using a string
            labelSeat.Location = new Point((60 * (_column - 1)) + 60 + (20 * (_column - 1)), (60 * (_row - 1)) + 60 + (20 * (_row - 1)));//Create a Point type object which has x,y coordinate info
            labelSeat.Size = new Size(60, 60);//Create a Size type object which has the width, height info
            labelSeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;//Align the Text to mid - center
            labelSeat.BorderStyle = BorderStyle.FixedSingle;//Make the border visible
            labelSeat.BackColor = Color.LightBlue;//Set the background color
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = _row, Column = _column };
            if (this.BookStatus == true)
            {
                labelSeat.BackColor = Color.LightGreen;
            }
            return labelSeat;
        }

    }//end of Seat Class
}//end of namespace
