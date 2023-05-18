using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class Person
    {
        
        public Color Color { get; set; }
        public char _Char { get; set; }
        public SeatDoubleLinkedList _PersonSeatNodeDoubleLinkedList { get; set; }

        public Person(char Char, SeatDoubleLinkedList PersonSeatNodeDoubleLinkedList)
        {
            _Char = Char;
            _PersonSeatNodeDoubleLinkedList = PersonSeatNodeDoubleLinkedList;
        }

        public Button generatePersonButton(Color color)
        {
            Button button = new Button();
            button.Size = new Size(200, 25);
            button.Text = "Person " + _Char + " Booking";
            button.BackColor = color;
            button.ForeColor = Color.Black;
            button.Name = "ButtonPerson" + _Char + "Booking";
            return button;
        }
    }
}
