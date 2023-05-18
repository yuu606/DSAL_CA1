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

        public Node<Seat> GetNode(int pRow, int pColumn)
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
                return p;
            }
        }

        public void InsertAtBeginning(Seat pSeatData)
        {
            Node<Seat> newNode = new Node<Seat>(pSeatData);
            if (Head == null)
            {
                Head = newNode;
            } else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
        }

        public void InsertAtEnd(Seat pSeatData)
        {
            Node<Seat> newNode = new Node<Seat>(pSeatData);
            if (Head == null)
            {
                Head = newNode;
                return;
            }
            Node<Seat> p = Head;

            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = newNode;
            newNode.Prev = p;
        }//end of InsertAtEnd


    }//end of class
}//end of namespace
