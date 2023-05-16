using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAL_CA1.Classes
{
    class SaveState
    {
        SaveState() { }
        SeatDoubleLinkedList SeatList { get; set; }
        int RowCount { get; set; }
        int ColumnCount { get; set; }
        string RowDivs { get; set; }
        string ColumnDivs { get; set; }
        int PplCount { get; set; }
        int MaxSeats { get; set; }
    }
}
