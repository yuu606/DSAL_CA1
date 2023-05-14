using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class RemoveAction : IAction
    {
        private ActionsDoubleLinkedList _actionList;
        private ActionNode _actionNode;
        private Action _action;

        public RemoveAction(ActionsDoubleLinkedList actionList, ActionNode actionNode)
        {
            _actionList = actionList;
            _actionNode = actionNode;
            _action = _actionNode.Action;
        }

        public void Execute()
        {
            _actionList.Remove(_actionNode);
        }

        public void Undo()
        {
            _actionList.InsertAfter((ActionNode)_actionNode.Previous, _action);
        }
    }
}
