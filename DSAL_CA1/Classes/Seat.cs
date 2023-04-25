using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    internal class Seat
    {
        private bool _bookStatus = false;
        private bool _canBook = false;
        private int _row;
        private int _column;

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
    }//end of Seat Class
}//end of namespace
