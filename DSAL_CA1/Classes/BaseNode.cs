using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class BaseNode
    {
        //base properties
        private BaseNode _prev;
        private BaseNode _next;

        //base constructor
        public BaseNode() 
        {
            _prev = null;
            _next = null;
        }

        //base methods
        public BaseNode Next
        {
            get { return _next; }
            set { _next = value; }
        }
        public BaseNode Previous
        {
            get { return _prev; }
            set { _prev = value; }
        }
    }
}
