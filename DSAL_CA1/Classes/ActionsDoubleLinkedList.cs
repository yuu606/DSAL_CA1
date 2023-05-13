using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class ActionsDoubleLinkedList
    {
        public ActionNode Start { get; set; }

        public ActionsDoubleLinkedList() 
        {
            this.Start = null;
        }

        public void InsertAtBeginning(Action pAction)
        {
            ActionNode newNode = new ActionNode(pAction);
            if (this.Start == null)
            {
                this.Start = newNode;
            }
            else
            {
                newNode.Next = this.Start;
                this.Start.Previous = newNode;
                this.Start = newNode;
            }
        }

        public void InsertAtEnd(Action pAction)
        {
            ActionNode newNode = new ActionNode(pAction);
            if (this.Start == null)
            {
                this.Start = newNode;
                return;
            }
            ActionNode p = this.Start;

            while (p.Next != null)
            {
                p = (ActionNode)p.Next;
            }
            p.Next = newNode;
            newNode.Previous = p;
        }

        public void InsertBefore()
        {

        }

        public void InsertAfter() 
        { 
        
        }

    }
}
