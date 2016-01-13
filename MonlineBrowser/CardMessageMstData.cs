using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class CardMessageMstData
    {
        public Int32 messageNo;
        public Int32 messageType;
        public String startTime;
        public String endTime;
        public String text;
        public Int32 cardMstId;

        /// <summary>
        /// FluorineFx.ASObjectからパースを行う
        /// </summary>
        public void Parse(FluorineFx.ASObject asObject)
        {
            AMFUtil.GetInt32Value(asObject, "messageNo", out messageNo);
            AMFUtil.GetInt32Value(asObject, "messageType", out messageType);
            AMFUtil.GetStringValue(asObject, "startTime", out startTime);
            AMFUtil.GetStringValue(asObject, "endTime", out endTime);
            AMFUtil.GetStringValue(asObject, "text", out text);
            AMFUtil.GetInt32Value(asObject, "cardMstId", out cardMstId);
        }
    }
}
