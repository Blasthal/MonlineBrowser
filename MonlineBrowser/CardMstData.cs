using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class CardMstData
    {
        public Int32 likeFood;
        public Int32 materialType;
        public Int32 hp;
        public Int32 sellPrice;
        public Int32 type;
        public Int32 outingFeelFull;
        public Int32 skill2MstId;
        public Int32 speed;
        public Int32 battleFeelFull;
        public Int32 defense;
        public Int32 attack;
        public String name;
        public String nickname;
        public Int32 feelFullMax;
        public Int32 skill1MstId;
        public String kana;
        public Int32 skill3MstId;
        public Int32 cardMstId;
        public Int32 rarityMstId;

        /// <summary>
        /// FluorineFx.ASObjectからパースを行う
        /// </summary>
        public void Parse(FluorineFx.ASObject asObject)
        {
            AMFUtil.GetInt32Value(asObject, "likeFood", out likeFood);
            AMFUtil.GetInt32Value(asObject, "materialType", out materialType);
            AMFUtil.GetInt32Value(asObject, "hp", out hp);
            AMFUtil.GetInt32Value(asObject, "sellPrice", out sellPrice);
            AMFUtil.GetInt32Value(asObject, "type", out type);
            AMFUtil.GetInt32Value(asObject, "outingFeelFull", out outingFeelFull);
            AMFUtil.GetInt32Value(asObject, "skill2MstId", out skill2MstId);
            AMFUtil.GetInt32Value(asObject, "speed", out speed);
            AMFUtil.GetInt32Value(asObject, "battleFeelFull", out battleFeelFull);
            AMFUtil.GetInt32Value(asObject, "defense", out defense);
            AMFUtil.GetInt32Value(asObject, "attack", out attack);
            AMFUtil.GetStringValue(asObject, "name", out name);
            AMFUtil.GetStringValue(asObject, "nickname", out nickname);
            AMFUtil.GetInt32Value(asObject, "feelFullMax", out feelFullMax);
            AMFUtil.GetInt32Value(asObject, "skill1MstId", out skill1MstId);
            AMFUtil.GetStringValue(asObject, "kana", out kana);
            AMFUtil.GetInt32Value(asObject, "skill3MstId", out skill3MstId);
            AMFUtil.GetInt32Value(asObject, "cardMstId", out cardMstId);
            AMFUtil.GetInt32Value(asObject, "rarityMstId", out rarityMstId);
        }
    }
}
