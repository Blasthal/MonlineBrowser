using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    static class AMFUtil
    {
        public static void GetBooleanValue(FluorineFx.ASObject asObject, string key, out Boolean outValue)
        {
            outValue = false;
            object dataObj;
            if (asObject.TryGetValue(key, out dataObj) && dataObj != null)
            {
                outValue = (bool)dataObj;
            }
        }

        public static void GetDoubleValue(FluorineFx.ASObject asObject, string key, out Double outValue)
        {
            outValue = 0.0f;
            object dataObj;
            if (asObject.TryGetValue(key, out dataObj) && dataObj != null)
            {
                outValue = (Double)dataObj;
            }
        }

        public static void GetStringValue(FluorineFx.ASObject asObject, string key, out String outValue)
        {
            outValue = String.Empty;
            object dataObj;
            if (asObject.TryGetValue(key, out dataObj) && dataObj != null)
            {
                outValue = (String)dataObj;
            }
        }

        public static void GetInt32Value(FluorineFx.ASObject asObject, string key, out Int32 outValue)
        {
            outValue = 0;
            object dataObj;
            if (asObject.TryGetValue(key, out dataObj) && dataObj != null)
            {
                outValue = (Int32)dataObj;
            }
        }
    }
}
