using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class SeatManager
    {
        SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();

        public SeatManager() { }

        public void AddSeat(Seat pSeat)
        {
            if (seatList.Start == null)
            {
                seatList.InsertAtBeginning(pSeat);
            } else
            {
                seatList.InsertAtEnd(pSeat);
            }
        }// end of AddSeat
        public Seat Search(int pRow, int pCol)
        {
            return seatList.SearchByRowAndColumn(pRow, pCol);

        }
    }
}
