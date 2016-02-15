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
}
