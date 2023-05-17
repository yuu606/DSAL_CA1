using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class UnbookAction : BaseActions
    {
        private Seat _seat;
        private Person _person;
        private Label _seatLabel;

        public UnbookAction(Seat seat, Person person, Label seatLabel)
        {
            _seat = seat;
            _person = person;
            _seatLabel = seatLabel;
        }

        public override void Execute(List<Label> labelSeats, SeatDoubleLinkedList seatList)
        {
            Seat s = seatList.SearchByRowAndColumn(_seat.Row, _seat.Column);
            s.BookStatus = false;
            Label label = labelSeats.First(seat => seat.Tag == new SeatInfo() { Row = _seat.Row, Column = _seat.Column });
            label.BackColor = Color.DarkGray;
        }

        public override void Undo(List<Label> labelSeats, SeatDoubleLinkedList seatList)
        {
            Seat s = seatList.SearchByRowAndColumn(_seat.Row, _seat.Column);
            s.BookStatus = true;
            Label label = labelSeats.First(seat => seat.Tag == new SeatInfo() { Row = _seat.Row, Column = _seat.Column });
            label.BackColor = s.Person.Color;
        }
    }
}
