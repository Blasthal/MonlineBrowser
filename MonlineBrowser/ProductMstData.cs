using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class ProductMstData
    {
        public Int32 productMstId;
        public Int32 boradId;
        public String name;
        public String caption;
        public String startTime;
        public String endTime;
        public Int32 spendType;
        public Int32 ruby;

        public void Parse(FluorineFx.ASObject asObject)
        {
            AMFUtil.GetInt32Value(asObject, "productMstId", out productMstId);
            AMFUtil.GetInt32Value(asObject, "boradId", out boradId);
            AMFUtil.GetStringValue(asObject, "name", out name);
            AMFUtil.GetStringValue(asObject, "caption", out caption);
            AMFUtil.GetStringValue(asObject, "startTime", out startTime);
            AMFUtil.GetStringValue(asObject, "endTime", out endTime);
            AMFUtil.GetInt32Value(asObject, "spendType", out spendType);
            AMFUtil.GetInt32Value(asObject, "ruby", out ruby);
        }
    }
}
