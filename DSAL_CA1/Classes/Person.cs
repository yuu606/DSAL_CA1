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
        private char _Char;

        public Person(char pChar)
        {
            this._Char = pChar;
        }

        public char Char
        {
            get { return this._Char; }
            set { this._Char = value; }
        }

        public Button generatePersonButton(Color color)
        {
            Button button = new Button();
            button.Size = new Size(315, 35);
            button.Text = "Person " + this._Char + " Booking";
            button.BackColor = color;
            button.ForeColor = Color.Black;
            button.Name = "ButtonPerson" + this._Char + "Booking";
            return button;
        }

        public Button Button
        {
            get; set;
        }

    }
}
