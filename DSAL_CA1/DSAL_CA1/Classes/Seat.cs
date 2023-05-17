using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    [Serializable]
    public class Seat
    {
        //properties
        private Person _person;
        private Color _color = Color.DarkGray;
        private bool _bookStatus = false;
        private bool _canBook = false;
        private int _row;
        private int _column;

        //constructor
        public Seat( int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int Row //property
        {
            get { return _row; }//get method
            set { _row = value; }//set method
        }

        public int Column //property
        {
            get { return _column; } //get method
            set { _column = value;} //set method
        }

        public bool CanBook
        {
            get { return _canBook; } //get method
            set { _canBook = value; } //set method
        }

        public bool BookStatus
        {
            get { return _bookStatus; } //get method
            set { _bookStatus = value; } //set method
        }

        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string ComputeSeatLabel()
        {
            return ((char)(_row + 64)).ToString() + _column.ToString();
        }//end of ComputeSeatLabel

        public Label generateSeatLabel()
        {
            Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
            labelSeat.Text = ComputeSeatLabel();//Set the Text property by using a string
            labelSeat.Size = new Size(70, 60);//Create a Size type object which has the width, height info
            labelSeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;//Align the Text to mid - center
            labelSeat.BorderStyle = BorderStyle.FixedSingle;//Make the border visible
            labelSeat.BackColor = Color.DarkRed;//Set the background color
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = _row, Column = _column };

            return labelSeat;
        }
    }//end of Seat Class
}//end of namespace
