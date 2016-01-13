using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class RarityMstData
    {
        public Int32 compositionSkillRawScore;
        public Int32 baseLevelMax;
        public Int32 compositionCharacterRawScore;
        public Int32 conpositionCharacterAdditionalValue;
        public String name;
        public Int32 rebirthMax;
        public Int32 compositionSkillAdditionalValue;
        public Int32 compositionPowerUpRawScore;
        public Int32 rarityMstId;
        public Int32 additionalLevelMaxByRebirth;

        /// <summary>
        /// FluorineFx.ASObjectからパースを行う
        /// </summary>
        public void Parse(FluorineFx.ASObject asObject)
        {
            AMFUtil.GetInt32Value(asObject, "compositionSkillRawScore", out compositionSkillRawScore);
            AMFUtil.GetInt32Value(asObject, "baseLevelMax", out baseLevelMax);
            AMFUtil.GetInt32Value(asObject, "compositionCharacterRawScore", out compositionCharacterRawScore);
            AMFUtil.GetInt32Value(asObject, "conpositionCharacterAdditionalValue", out conpositionCharacterAdditionalValue);
            AMFUtil.GetStringValue(asObject, "name", out name);
            AMFUtil.GetInt32Value(asObject, "rebirthMax", out rebirthMax);
            AMFUtil.GetInt32Value(asObject, "compositionSkillAdditionalValue", out compositionSkillAdditionalValue);
            AMFUtil.GetInt32Value(asObject, "compositionPowerUpRawScore", out compositionPowerUpRawScore);
            AMFUtil.GetInt32Value(asObject, "rarityMstId", out rarityMstId);
            AMFUtil.GetInt32Value(asObject, "additionalLevelMaxByRebirth", out additionalLevelMaxByRebirth);
        }
    }
}
