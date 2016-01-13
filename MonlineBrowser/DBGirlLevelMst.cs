using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// GirlLevelMstの情報
    /// </summary>
    static class DBGirlLevelMst
    {
        /// <summary>
        /// GirlLevelMstのリスト
        /// </summary>
        public static readonly List<GirlLevelMstData> GirlLevelMstDatas = new List<GirlLevelMstData>();

        /// <summary>
        /// AFMからパースする
        /// </summary>
        public static void Parse(FluorineFx.ASObject bodyAsObject)
        {
            Object girlLevelMstObj = null;
            if (bodyAsObject.TryGetValue("girlLevelMst", out girlLevelMstObj))
            {
                Object[] girlLevelMstObjs = (Object[])girlLevelMstObj;
                if (girlLevelMstObjs != null)
                {
                    GirlLevelMstDatas.Clear();
                    for (int i = 0; i < girlLevelMstObjs.Length; ++i)
                    {
                        FluorineFx.ASObject asObj = girlLevelMstObjs[i] as FluorineFx.ASObject;
                        if (asObj != null)
                        {
                            GirlLevelMstData data = SubParse(asObj);
                            GirlLevelMstDatas.Add(data);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// GirlLevelMst1つ分のパースを行う
        /// </summary>
        private static GirlLevelMstData SubParse(FluorineFx.ASObject asObject)
        {
            GirlLevelMstData data = new GirlLevelMstData();

            AMFUtil.GetInt32Value(asObject, "diffExp", out data.diffExp);
            AMFUtil.GetInt32Value(asObject, "level", out data.level);
            AMFUtil.GetInt32Value(asObject, "maxDear", out data.maxDear);
            AMFUtil.GetInt32Value(asObject, "totalExp", out data.totalExp);

            return data;
        }
    }
}
