using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSAL_CA1.Classes
{
    [Serializable]
    public class SeatDoubleLinkedList : DoubleLinkedList<Seat>
    {
        public SeatDoubleLinkedList() { }//end of constructor

        public Seat SearchByRowAndColumn(int pRow, int pColumn)
        {
            Node<Seat> p = Head;
            while (p != null)
            {
                if ((p.Data.Column == pColumn) && (p.Data.Row == pRow))
                {
                    //If the node referenced by p satisfies the search criteria, exit the loop
                    break;
                }
                p = p.Next;
            }
            if (p == null)
            {
                return null;
            }
            else
            {
                return p.Data;
            }
        }

        /*public void InsertAtBeginning(Seat pSeatData)
        {
            SeatNode newNode = new SeatNode(pSeatData);
            if (this.Start == null)
            {
                this.Start = newNode;
            } else
            {
                newNode.Next = this.Start;
                this.Start.Prev = newNode;
                this.Start = newNode;
            }
        }

        public void InsertAtEnd(Seat pSeatData)
        {
            SeatNode newNode = new SeatNode(pSeatData);
            if (this.Start == null)
            {
                this.Start = newNode;
                return;
            }
            SeatNode p = this.Start;

            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = newNode;
            newNode.Prev = p;
        }//end of InsertAtEnd*/


    }//end of class
}//end of namespace
