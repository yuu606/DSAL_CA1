using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class NormalNode : BaseNode
    {
        //properties 
        private Seat _seat;

        //constructor
        public NormalNode(Seat pSeat)
        {
            this._seat = pSeat;
            Previous = null;
            Next = null;
        }

        //methods 
        public Seat Seat 
        { 
            get { return _seat; } 
            set { _seat = value; }
        }  


       
    }//end of class
}//end of namespace
