using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// ItemMstの情報
    /// </summary>
    static class DBItemMst
    {
        /// <summary>
        /// アイテムのタグ
        /// </summary>
        public enum ItemTag
        {
            VEGETABLE,
            MEAT,
            BREAD,

            COUNT,
        }

        /// <summary>
        /// アイテムのタグに対応したマスターID
        /// </summary>
        private static readonly Int32[] ItemMstIds = new Int32[(Int32)ItemTag.COUNT]
        {
            20001,
            20002,
            20003,
        };

        /// <summary>
        /// ItemMstのリスト
        /// </summary>
        public static readonly List<ItemMstData> ItemMstDatas = new List<ItemMstData>();

        /// <summary>
        /// AFMからパースする
        /// </summary>
        public static void Parse(FluorineFx.ASObject bodyAsObject)
        {
            Object itemMstObj = null;
            if (bodyAsObject.TryGetValue("itemMst", out itemMstObj))
            {
                Object[] itemMstObjs = (Object[])itemMstObj;
                if (itemMstObjs != null)
                {
                    ItemMstDatas.Clear();
                    for (int i = 0; i < itemMstObjs.Length; ++i)
                    {
                        FluorineFx.ASObject asObj = itemMstObjs[i] as FluorineFx.ASObject;
                        if (asObj != null)
                        {
                            ItemMstData data = SubParse(asObj);
                            ItemMstDatas.Add(data);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ItemMst1つ分のパースを行う
        /// </summary>
        private static ItemMstData SubParse(FluorineFx.ASObject asObject)
        {
            ItemMstData data = new ItemMstData();

            AMFUtil.GetDoubleValue(asObject, "effect1", out data.effect1);
            AMFUtil.GetDoubleValue(asObject, "effect2", out data.effect2);
            AMFUtil.GetInt32Value(asObject, "itemMstId", out data.itemMstId);
            AMFUtil.GetStringValue(asObject, "name", out data.name);
            AMFUtil.GetStringValue(asObject, "caption", out data.caption);
            AMFUtil.GetInt32Value(asObject, "type", out data.type);

            return data;
        }

        /// <summary>
        /// アイテムのタグに対応したマスターIDを取得する
        /// </summary>
        /// <param name="itemKind">アイテムの種類</param>
        /// <returns>アイテムのマスターID</returns>
        public static Int32 GetItemMstId(ItemTag itemTag)
        {
            return ItemMstIds[(Int32)itemTag];
        }

    }
}
