using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    public interface IAction
    {
        void Execute();
        void Undo();
    }
}
