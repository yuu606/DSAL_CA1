using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class Action
    {
        //properties 
        bool hasBooked;
        Seat seat;

        //default constructor
        public Action() { }

        public bool HasBooked 
        { 
            get {  return hasBooked; } 
            set { hasBooked = value; }  
        }

        public Seat Seat 
        { 
            get { return seat; } 
            set { seat = value; }
        }
    }
}
