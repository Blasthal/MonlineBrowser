using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class PlayerData
    {
        public String volumeSe;
        public Int32 attackBoost;
        public Boolean isMute;
        public Int32 foodRecoverMax;
        public Int32 stamina;
        public Int32 vegetable;
        public String meatLostTime;
        public Int32 foodMax;
        public Double exp;
        public Int32 battleWinCount;
        public String vegitableLostTime;
        public Double playerId;
        public Int32 outingSuccessCount;
        public Int32 bread;
        public String volumeVoice;
        public Boolean isLeave;
        public Int32 level;
        public String start;
        public String volumeBgm;
        public String breadLostTime;
        public Double userId;
        public Int32 ruby;
        public Int32 cardMax;
        public Int32 expBoost;
        public Int32 outingCount;
        public String name;
        public Int32 meat;
        public Int32 defenseBoost;
        public Int32 jobCount;
        public Int32 battleCount;
        public Int32 tutorialState;
        public Double expMaxForNextLevel;

        public void Parse(FluorineFx.ASObject asObject)
        {
            if (asObject != null)
            {
                AMFUtil.GetStringValue(asObject, "volumeSe", out volumeSe);
                AMFUtil.GetInt32Value(asObject, "attackBoost", out attackBoost);
                AMFUtil.GetBooleanValue(asObject, "isMute", out isMute);
                AMFUtil.GetInt32Value(asObject, "foodRecoverMax", out foodRecoverMax);
                AMFUtil.GetInt32Value(asObject, "stamina", out stamina);
                AMFUtil.GetInt32Value(asObject, "vegetable", out vegetable);
                AMFUtil.GetStringValue(asObject, "meatLostTime", out meatLostTime);
                AMFUtil.GetInt32Value(asObject, "foodMax", out foodMax);
                AMFUtil.GetDoubleValue(asObject, "exp", out exp);
                AMFUtil.GetInt32Value(asObject, "battleWinCount", out battleWinCount);
                AMFUtil.GetStringValue(asObject, "vegitableLostTime", out vegitableLostTime);
                AMFUtil.GetDoubleValue(asObject, "playerId", out playerId);
                AMFUtil.GetInt32Value(asObject, "outingSuccessCount", out outingSuccessCount);
                AMFUtil.GetInt32Value(asObject, "bread", out bread);
                AMFUtil.GetStringValue(asObject, "volumeVoice", out volumeVoice);
                AMFUtil.GetBooleanValue(asObject, "isLeave", out isLeave);
                AMFUtil.GetInt32Value(asObject, "level", out level);
                AMFUtil.GetStringValue(asObject, "start", out start);
                AMFUtil.GetStringValue(asObject, "volumeBgm", out volumeBgm);
                AMFUtil.GetStringValue(asObject, "breadLostTime", out breadLostTime);
                AMFUtil.GetDoubleValue(asObject, "userId", out userId);
                AMFUtil.GetInt32Value(asObject, "ruby", out ruby);
                AMFUtil.GetInt32Value(asObject, "cardMax", out cardMax);
                AMFUtil.GetInt32Value(asObject, "expBoost", out expBoost);
                AMFUtil.GetInt32Value(asObject, "outingCount", out outingCount);
                AMFUtil.GetStringValue(asObject, "name", out name);
                AMFUtil.GetInt32Value(asObject, "meat", out meat);
                AMFUtil.GetInt32Value(asObject, "defenseBoost", out defenseBoost);
                AMFUtil.GetInt32Value(asObject, "jobCount", out jobCount);
                AMFUtil.GetInt32Value(asObject, "battleCount", out battleCount);
                AMFUtil.GetInt32Value(asObject, "tutorialState", out tutorialState);
                AMFUtil.GetDoubleValue(asObject, "expMaxForNextLevel", out expMaxForNextLevel);
            }
        }
    }
}
