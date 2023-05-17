using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class EnableAllSeatsAction : BaseActions
    {
        public override void Execute(List<Label> labelSeats, SeatDoubleLinkedList seatList)
        {
            Node<Seat> current = seatList.Head;
            while (seatList != null)
            {
                current.Data.CanBook = true;
                current = current.Next;
            }

            foreach (Label lbl in labelSeats)
            {
                lbl.BackColor = Color.Green;
            }
        }

        public override void Undo(List<Label> labelSeats, SeatDoubleLinkedList seatList)
        {
            Node<Seat> current = seatList.Head;
            while (seatList != null)
            {
                current.Data.CanBook = false;
                current = current.Next;
            }

            foreach (Label lbl in labelSeats)
            {
                lbl.BackColor = Color.DarkRed;
            }
        }
    }
}
