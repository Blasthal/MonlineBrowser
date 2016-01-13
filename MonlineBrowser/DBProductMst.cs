using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// ProductMstの情報
    /// </summary>
    static class DBProductMst
    {
        /// <summary>
        /// ProductMstのリスト
        /// </summary>
        static List<ProductMstData> ProductMstDatas = new List<ProductMstData>();

        /// <summary>
        /// AFMからパースする
        /// </summary>
        public static void Parse(FluorineFx.ASObject bodyAsObject)
        {
            Object mstObj = null;
            if (bodyAsObject.TryGetValue("productMst", out mstObj))
            {
                Object[] mstObjs = (Object[])mstObj;
                if (mstObjs != null)
                {
                    ProductMstDatas.Clear();
                    for (int i = 0; i < mstObjs.Length; ++i)
                    {
                        FluorineFx.ASObject asObj = mstObjs[i] as FluorineFx.ASObject;
                        if (asObj != null)
                        {
                            ProductMstData data = new ProductMstData();
                            data.Parse(asObj);

                            ProductMstDatas.Add(data);
                        }
                    }
                }
            }
        }
    }
}
