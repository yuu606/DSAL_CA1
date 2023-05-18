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
        public char Char { get; set; }
        public List<Seat> personSeatList { get; set; }

        public Person(char pChar)
        {
            this.Char = pChar;
        }

        public Button generatePersonButton(Color color)
        {
            Button button = new Button();
            button.Size = new Size(200, 25);
            button.Text = "Person " + this.Char + " Booking";
            button.BackColor = color;
            button.ForeColor = Color.Black;
            button.Name = "ButtonPerson" + this.Char + "Booking";
            return button;
        }
    }
}
