using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace DSAL_CA1.Classes
{
    public class ActionsDoubleLinkedList
    {
        private ActionNode _head;
        private ActionNode _tail;
        private Stack<IAction> _undoStack;
        private Stack<IAction> _redoStack;

        public ActionNode Start { get; set; }

        public ActionsDoubleLinkedList() 
        {
            _head = null;
            _tail = null;
            _undoStack = new Stack<IAction>();
            _redoStack = new Stack<IAction>();
        }

        public void InsertAfter(ActionNode actionNode, Action _action) 
        {
            ActionNode newNode = new ActionNode(_action);

            if (actionNode == null)
            {
                newNode.Next = _head;
                if (_head != null)
                {
                    _head.Previous = newNode;
                }
                _head = newNode;
                if (_tail == null)
                {
                    _tail = _head;
                } else
                {
                    newNode.Next = actionNode.Next; 
                    if (actionNode.Next != null) 
                    { 
                        actionNode.Next.Previous = newNode;
                    }
                    actionNode.Next = newNode;
                    newNode.Previous = actionNode;
                    if (actionNode == _tail)
                    {
                        _tail = newNode;
                    }
                }

                IAction action = new InsertAction(this, _action, newNode);
                _undoStack.Push(action);
                _redoStack.Clear();
            }
        }

        public void Remove(ActionNode actionNode)
        {
            if (actionNode == null)
            {
                return;
            }

            if (actionNode.Previous != null)
            {
                actionNode.Previous.Next = actionNode.Next;
            } else
            {
                _head = (ActionNode)actionNode.Next;
            }

            if (actionNode.Next != null)
            {
                actionNode.Next.Previous = actionNode.Previous;
            }
            else
                _tail = (ActionNode)actionNode.Previous;

            IAction action = new RemoveAction(this, actionNode);
            _undoStack.Push(action);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0)
                return;

            IAction action = _undoStack.Pop();
            action.Undo();
            _redoStack.Push(action);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
                return;

            IAction action = _redoStack.Pop();
            action.Execute();
            _undoStack.Push(action);
        }
    }
}
