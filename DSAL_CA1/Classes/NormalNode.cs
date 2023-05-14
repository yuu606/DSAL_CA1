using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    [Serializable]
    internal class NormalNode : BaseNode
    {
        //properties 
        private Seat _seat;
        private NormalNode _prev;
        private NormalNode _next;

        //constructor
        public NormalNode() { }
        public NormalNode(Seat pSeat)
        {
            this._seat = pSeat;
            _next = null;
            _prev = null;
        }

        //methods 
        public Seat Seat 
        { 
            get { return _seat; } 
            set { _seat = value; }
        }  

        public NormalNode Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public NormalNode Prev
        {
            get { return _prev; }
            set { _next = value; }
        }
       
    }//end of class
}//end of namespace
