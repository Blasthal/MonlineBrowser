using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// RarityMstの情報
    /// </summary>
    static class DBRarityMst
    {
        /// <summary>
        /// RarityMstのリスト
        /// </summary>
        public static readonly List<RarityMstData> RarityMstDatas = new List<RarityMstData>();

        /// <summary>
        /// AFMからパースする
        /// </summary>
        public static void Parse(FluorineFx.ASObject bodyAsObject)
        {
            Object rarityMstObj = null;
            if (bodyAsObject.TryGetValue("rarityMst", out rarityMstObj))
            {
                Object[] rarityMstObjs = (Object[])rarityMstObj;
                if (rarityMstObjs != null)
                {
                    RarityMstDatas.Clear();
                    for (int i = 0; i < rarityMstObjs.Length; ++i)
                    {
                        FluorineFx.ASObject asObj = rarityMstObjs[i] as FluorineFx.ASObject;
                        if (asObj != null)
                        {
                            RarityMstData data = new RarityMstData();
                            data.Parse(asObj);

                            RarityMstDatas.Add(data);
                        }
                    }
                }
            }
        }
    }
}
