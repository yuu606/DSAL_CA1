using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace DSAL_CA1.Classes
{
    public class ActionsList
    {
        public List<Label> labels { get; set; }
        public SeatDoubleLinkedList seatList { get; set; }

        public Stack<BaseActions> _undoStack { get; set; }
        public Stack<BaseActions> _redoStack { get; set; }

        public ActionsList(List<Label> labels, SeatDoubleLinkedList seatList) 
        {
            this.labels = labels;
            this.seatList = seatList;
            _undoStack = new Stack<BaseActions>();
            _redoStack = new Stack<BaseActions>();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0)
                return;

            BaseActions action = _undoStack.Pop();
            action.Undo(labels, seatList);
            _redoStack.Push(action);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
                return;

            BaseActions action = _redoStack.Pop();
            action.Execute(labels, seatList);
            _undoStack.Push(action);
        }
    }
}
