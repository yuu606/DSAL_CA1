using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class ActionNode : BaseNode
    { 
        //properties
        private Action _action;

        //constructor
        public ActionNode(Action action)
        {
            this._action = action;
            Previous = null;
            Next = null;
        }

        //methods
        public Action Action
        {
            get { return _action; }
            set { _action = value; }
        }
    }
}
