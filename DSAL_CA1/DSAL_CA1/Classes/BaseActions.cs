using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public abstract class BaseActions
    {
        public abstract void Execute(List<Label> labelSeats, SeatDoubleLinkedList seatList);
        public abstract void Undo(List<Label> labelSeats, SeatDoubleLinkedList seatList);
    }
}
