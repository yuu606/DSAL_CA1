using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    internal class SmartNode
    {
        private SmartSeat _smartSeat;

        public SmartNode() : base(){ }

        public SmartNode(SmartSeat pSmartSeat)
        {
            _smartSeat = pSmartSeat;
        }

        public SmartSeat SmartSeat
        {
            get { return _smartSeat; }
            set { _smartSeat = value; }
        }

        
    }
}
