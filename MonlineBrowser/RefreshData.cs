using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class RefreshData
    {
        public Int32 refreshId;
        public Boolean isOpen;
        public Int32 cardId1;
        public Int32 cardId2;
        public Int32 cardId3;
        public Int32 cardId4;
        public Int32 cardId5;
        public String endTime;

        public void Parse(FluorineFx.ASObject asObject)
        {
            if (asObject != null)
            {
                AMFUtil.GetInt32Value(asObject, "refreshId", out refreshId);
                AMFUtil.GetBooleanValue(asObject, "isOpen", out isOpen);
                AMFUtil.GetInt32Value(asObject, "cardId1", out cardId1);
                AMFUtil.GetInt32Value(asObject, "cardId2", out cardId2);
                AMFUtil.GetInt32Value(asObject, "cardId3", out cardId3);
                AMFUtil.GetInt32Value(asObject, "cardId4", out cardId4);
                AMFUtil.GetInt32Value(asObject, "cardId5", out cardId5);
                AMFUtil.GetStringValue(asObject, "endTime", out endTime);
            }
        }
    }
}
