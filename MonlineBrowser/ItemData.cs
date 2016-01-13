using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class ItemData
    {
        public Int32 itemMstId;
        public Int32 itemCount;

        public void Parse(FluorineFx.ASObject asObject)
        {
            if (asObject != null)
            {
                AMFUtil.GetInt32Value(asObject, "itemMstId", out itemMstId);
                AMFUtil.GetInt32Value(asObject, "itemCount", out itemCount);
            }
        }
    }
}
