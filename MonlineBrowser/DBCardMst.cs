using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// CardMstの情報
    /// </summary>
    static class DBCardMst
    {
        /// <summary>
        /// CardMstのリスト
        /// </summary>
        public static readonly List<CardMstData> CardMstDatas = new List<CardMstData>();

        /// <summary>
        /// AFMからパースする
        /// </summary>
        public static void Parse(FluorineFx.ASObject bodyAsObject)
        {
            Object cardMstObj = null;
            if (bodyAsObject.TryGetValue("cardMst", out cardMstObj))
            {
                Object[] cardMstObjs = (Object[])cardMstObj;
                if (cardMstObjs != null)
                {
                    CardMstDatas.Clear();
                    for (int i = 0; i < cardMstObjs.Length; ++i)
                    {
                        FluorineFx.ASObject asObj = cardMstObjs[i] as FluorineFx.ASObject;
                        if (asObj != null)
                        {
                            CardMstData data = new CardMstData();
                            data.Parse(asObj);

                            CardMstDatas.Add(data);
                        }
                    }
                }
            }
        }
    }
}
