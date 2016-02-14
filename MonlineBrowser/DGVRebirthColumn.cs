using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonlineBrowser
{
    class DGVRebirthColumn : DataGridViewColumn
    {
        public DGVRebirthColumn()
        {
            this.CellTemplate = new DGVRebirthCell();
        }
    }

    class HogeComparer : System.Collections.Generic.Comparer<DGVRebirthCell>
    {
        public override int Compare(DGVRebirthCell x, DGVRebirthCell y)
        {
            Int32 int1 = (x.Value == null) ? 0 : (Int32)x.Value;
            Int32 int2 = (x.Value == null) ? 0 : (Int32)y.Value;
            return (int1 - int2);
        }
    }
}
