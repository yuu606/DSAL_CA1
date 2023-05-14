using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class InsertAction : IAction
    {
        private ActionsDoubleLinkedList _actionList;
        private Action _action;
        private ActionNode _actionNode;

        public InsertAction(ActionsDoubleLinkedList actionList, Action action, ActionNode actionNode)
        {
            _actionList = actionList;
            _action = action;
            _actionNode = actionNode;
        }

        public void Execute()
        {
            _actionList.InsertAfter(_actionNode, _action);
        }

        public void Undo()
        {
            _actionList.Remove((ActionNode)_actionNode.Next);
        }
    }
}
