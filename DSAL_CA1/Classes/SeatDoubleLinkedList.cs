﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSAL_CA1.Classes
{
    [Serializable]
    class SeatDoubleLinkedList
    {
        public NormalNode Start { get; set; }

        public SeatDoubleLinkedList()
        {
            this.Start = null;
        }//end of constructor

        public void InsertAtBeginning(Seat pSeatData)
        {
            NormalNode newNode = new NormalNode(pSeatData);
            if (this.Start == null)
            {
                this.Start = newNode;
            } else
            {
                newNode.Next = this.Start;
                this.Start.Previous = newNode;
                this.Start = newNode;
            }
        }

        public void InsertAtEnd(Seat pSeatData)
        {
            NormalNode newNode = new NormalNode(pSeatData);
            if (this.Start == null)
            {
                this.Start = newNode;
                return;
            }
            NormalNode p = this.Start;

            while (p.Next != null)
            {
                p = (NormalNode)p.Next;
            }
            p.Next = newNode;
            newNode.Previous = p;
        }//end of InsertAtEnd

        public void deleteAllNodes()
        {
            NormalNode temp = new NormalNode();
            while (this.Start != null)
            {
                temp = this.Start;
                this.Start = (NormalNode)this.Start.Next;
                temp = null;
            }
            Console.WriteLine("All nodes are deleted successfully.");
        }

        public Seat SearchByRowAndColumn(int pRow, int pColumn)
        {
            NormalNode p = this.Start;
            while(p !=null)
            {
                if ((p.Seat.Column == pColumn) && (p.Seat.Row == pRow))
                {
                    //If the node referenced by p satisfies the search criteria, exit the loop
                    break;
                }
                p = (NormalNode)p.Next;
            }
            if (p == null)
            {
                return null;
            }
            else
            {
                return p.Seat;
            }
        }
    }//end of class
}//end of namespace
