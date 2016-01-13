using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class CardData
    {
        public Int32 defenseBonus;
        public Int32 love;
        public Int32 skill2Exp;
        public Int32 critical;
        public Int32 deckId;
        public Int32 hp;
        public Int32 skill1ExpMaxForNextLevel;
        public Int32 hpBonus;
        public Int32 skill3ExpMaxForNextLevel;
        public String lostTime;
        public Int32 speedBonus;
        public Int32 speed;
        public Int32 attackBonus;
        public Int32 hpMax;
        public Int32 hit;
        public Int32 skill2Level;
        public Int32 defense;
        public Int32 attack;
        public Boolean isLocked;
        public Int32 exp;
        public Int32 skill2ExpMaxForNextLevel;
        public Int32 tension;
        public Int32 skill1Exp;
        public Int32 skill3Exp;
        public Int32 level;
        public Boolean isLeader;
        public Int32 skill3Level;
        public Int32 orderInDeck;
        public Int32 feelFull;
        public Int32 cardId;
        public Int32 skill1Level;
        public Int32 rebirthCount;
        public Int32 evasion;
        public Int32 cardMstId;
        public Int32 expMaxForNextLevel;
        public Int32 status;

        /// <summary>
        /// FluorineFx.ASObjectからパースを行う
        /// </summary>
        public void Parse(FluorineFx.ASObject asObject)
        {
            AMFUtil.GetInt32Value(asObject, "defenseBonus", out defenseBonus);
            AMFUtil.GetInt32Value(asObject, "love", out love);
            AMFUtil.GetInt32Value(asObject, "skill2Exp", out skill2Exp);
            AMFUtil.GetInt32Value(asObject, "critical", out critical);
            AMFUtil.GetInt32Value(asObject, "deckId", out deckId);
            AMFUtil.GetInt32Value(asObject, "hp", out hp);
            AMFUtil.GetInt32Value(asObject, "skill1ExpMaxForNextLevel", out skill1ExpMaxForNextLevel);
            AMFUtil.GetInt32Value(asObject, "hpBonus", out hpBonus);
            AMFUtil.GetInt32Value(asObject, "skill3ExpMaxForNextLevel", out skill3ExpMaxForNextLevel);
            AMFUtil.GetStringValue(asObject, "lostTime", out lostTime);
            AMFUtil.GetInt32Value(asObject, "speedBonus", out speedBonus);
            AMFUtil.GetInt32Value(asObject, "speed", out speed);
            AMFUtil.GetInt32Value(asObject, "attackBonus", out attackBonus);
            AMFUtil.GetInt32Value(asObject, "hpMax", out hpMax);
            AMFUtil.GetInt32Value(asObject, "hit", out hit);
            AMFUtil.GetInt32Value(asObject, "skill2Level", out skill2Level);
            AMFUtil.GetInt32Value(asObject, "defense", out defense);
            AMFUtil.GetInt32Value(asObject, "attack", out attack);
            AMFUtil.GetBooleanValue(asObject, "isLocked", out isLocked);
            AMFUtil.GetInt32Value(asObject, "exp", out exp);
            AMFUtil.GetInt32Value(asObject, "skill2ExpMaxForNextLevel", out skill2ExpMaxForNextLevel);
            AMFUtil.GetInt32Value(asObject, "tension", out tension);
            AMFUtil.GetInt32Value(asObject, "skill1Exp", out skill1Exp);
            AMFUtil.GetInt32Value(asObject, "skill3Exp", out skill3Exp);
            AMFUtil.GetInt32Value(asObject, "level", out level);
            AMFUtil.GetBooleanValue(asObject, "isLeader", out isLeader);
            AMFUtil.GetInt32Value(asObject, "skill3Level", out skill3Level);
            AMFUtil.GetInt32Value(asObject, "orderInDeck", out orderInDeck);
            AMFUtil.GetInt32Value(asObject, "feelFull", out feelFull);
            AMFUtil.GetInt32Value(asObject, "cardId", out cardId);
            AMFUtil.GetInt32Value(asObject, "skill1Level", out skill1Level);
            AMFUtil.GetInt32Value(asObject, "rebirthCount", out rebirthCount);
            AMFUtil.GetInt32Value(asObject, "evasion", out evasion);
            AMFUtil.GetInt32Value(asObject, "cardMstId", out cardMstId);
            AMFUtil.GetInt32Value(asObject, "expMaxForNextLevel", out expMaxForNextLevel);
            AMFUtil.GetInt32Value(asObject, "status", out status);
        }
    }
}
