﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public class ActionNode : Node<Action>
    {
        //constructor
        public ActionNode(Action action) : base(Action) { }
    }
}
