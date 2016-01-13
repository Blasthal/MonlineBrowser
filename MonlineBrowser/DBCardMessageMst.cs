using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// CardMessageMstの情報
    /// </summary>
    static class DBCardMessageMst
    {
        /// <summary>
        /// CardMessageMstのリスト
        /// </summary>
        public static readonly List<CardMessageMstData> CardMessageMstDatas = new List<CardMessageMstData>();

        /// <summary>
        /// AFMからパースする
        /// </summary>
        public static void Parse(FluorineFx.ASObject bodyAsObject)
        {
            Object cardMessageMstObj = null;
            if (bodyAsObject.TryGetValue("cardMessageMst", out cardMessageMstObj))
            {
                Object[] cardMessageMstObjs = (Object[])cardMessageMstObj;
                if (cardMessageMstObjs != null)
                {
                    CardMessageMstDatas.Clear();
                    for (int i = 0; i < cardMessageMstObjs.Length; ++i)
                    {
                        FluorineFx.ASObject asObj = cardMessageMstObjs[i] as FluorineFx.ASObject;
                        if (asObj != null)
                        {
                            CardMessageMstData data = new CardMessageMstData();
                            data.Parse(asObj);

                            CardMessageMstDatas.Add(data);
                        }
                    }
                }
            }
        }
    }
}
