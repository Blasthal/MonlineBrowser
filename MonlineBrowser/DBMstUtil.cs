using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// マスターの情報に関する機能提供クラス
    /// </summary>
    static class DBMstUtil
    {
        #region Method

        #region 情報取得
        /// <summary>
        /// モン娘のマスター情報を取得する
        /// </summary>
        /// <param name="cardMstId">モン娘のマスターID</param>
        /// <returns>モン娘のマスター情報。無い場合はnullが返る</returns>
        public static CardMstData GetCardMstData(Int32 cardMstId)
        {
            CardMstData findData = DBCardMst.CardMstDatas.Find(
                delegate(CardMstData inData)
                {
                    return (inData.cardMstId == cardMstId);
                }
                );

            return findData;
        }

        /// <summary>
        /// レアリティのマスター情報を取得する
        /// </summary>
        /// <param name="rarityMstId">マスターID</param>
        /// <returns>レアリティのマスター情報</returns>
        public static RarityMstData GetRarityMstData(Int32 rarityMstId)
        {
            RarityMstData findData = DBRarityMst.RarityMstDatas.Find(
                delegate(RarityMstData inData)
                {
                    return (inData.rarityMstId == rarityMstId);
                }
                );

            return findData;
        }
        #endregion

        #region モン娘の名前
        /// <summary>
        /// IDからモン娘の名前を取得する。
        /// 「cardId」と「cardMstId」は別物なので要注意。
        /// </summary>
        /// <param name="cardMstId">モン娘ID</param>
        /// <returns>モン娘の名前</returns>
        public static String GetMonmusuName(Int32 cardMstId)
        {
            CardMstData findData = GetCardMstData(cardMstId);
            if (findData != null)
            {
                return findData.name;
            }

            return "名を知らぬ娘";
        }

        /// <summary>
        /// IDからモン娘の最大満腹度を取得する
        /// </summary>
        /// <param name="cardMstId">モン娘のマスターID</param>
        /// <returns>モン娘の最大満腹度</returns>
        public static Int32 GetMonmusuSatietyMax(Int32 cardMstId)
        {
            CardMstData findData = GetCardMstData(cardMstId);
            if (findData != null)
            {
                return findData.feelFullMax;
            }

            return 0;
        }
        #endregion

        #region モン娘のレアリティ
        /// <summary>
        /// モン娘のレアリティ名を取得する
        /// </summary>
        /// <param name="rarityMstId">レアリティマスターID</param>
        /// <returns>モン娘のレアリティ名を返す</returns>
        public static String GetMonmusuRarityName(Int32 rarityMstId)
        {
            RarityMstData findData = DBRarityMst.RarityMstDatas.Find(
                delegate(RarityMstData inData)
                {
                    return (rarityMstId == inData.rarityMstId);
                }
                );
            if (findData != null)
            {
                return findData.name;
            }

            return "--";
        }

        /// <summary>
        /// モン娘のレアリティ名をCardMstIdから取得する
        /// </summary>
        /// <param name="cardMstId"></param>
        /// <returns></returns>
        public static String GetMonmusuRarityNameByCardMstId(Int32 cardMstId)
        {
            CardMstData cardMstData = GetCardMstData(cardMstId);
            String rarityName = GetMonmusuRarityName(cardMstData.rarityMstId);

            return rarityName;
        }
        #endregion

        #region モン娘の好物
        /// <summary>
        /// モン娘の好物を取得する
        /// </summary>
        /// <param name="cardMstId">マスターID</param>
        /// <returns>モン娘の好物の値</returns>
        public static Int32 GetMonmusuLikeFood(Int32 cardMstId)
        {
            CardMstData mstData = GetCardMstData(cardMstId);
            if (mstData != null)
            {
                return mstData.likeFood;
            }

            return 0;
        }
        #endregion

        #region メッセージ
        /// <summary>
        /// メモリアルで表示するメッセージ情報を取得する
        /// </summary>
        /// <param name="cardMstId">マスターID</param>
        /// <returns>メッセージ情報</returns>
        public static CardMessageMstData GetCardMessageMstDataMemorial(Int32 cardMstId)
        {
            // メモリアルに表示されるテキストはこの番号が割り振られている
            const int MESSAGE_TYPE_MEMORIAL = 2410;

            CardMessageMstData findData = DBCardMessageMst.CardMessageMstDatas.Find(
                delegate(CardMessageMstData inData)
                {
                    return (inData.messageType == MESSAGE_TYPE_MEMORIAL &&
                    inData.cardMstId == cardMstId);
                }
                );

            return findData;
        }

        /// <summary>
        /// モン娘の種族名を取得する。
        /// 種族名だけのDBは無いので、メモリアルに表示するテキストから抽出する。
        /// </summary>
        /// <param name="cardMstId">マスターID</param>
        /// <returns>種族名</returns>
        public static String GetCardMessageRaceName(Int32 cardMstId)
        {
            CardMessageMstData cardMsgMstData = GetCardMessageMstDataMemorial(cardMstId);
            if (cardMsgMstData != null)
            {
                string text = cardMsgMstData.text;

                // 種族名が記載されている文字列の位置を検索する
                const string SEARCH_START_TEXT = "種族：";
                Int32 searchIndex = text.IndexOf(SEARCH_START_TEXT);
                if (0 <= searchIndex)
                {
                    Int32 raceNameStartIndex = searchIndex + SEARCH_START_TEXT.Length;

                    // 種族名の記載が終了する位置を検索する
                    const string SEARCH_END_TEXT = "\\n";
                    Int32 raceNameEndIndex = text.IndexOf(SEARCH_END_TEXT, raceNameStartIndex);
                    if (0 <= raceNameEndIndex)
                    {
                        // 種族名を抽出する
                        Int32 raceNameLength = raceNameEndIndex - raceNameStartIndex;
                        string raceName = text.Substring(raceNameStartIndex, raceNameLength);
                        return raceName;
                    }
                }
            }

            return "-----";
        }

        #endregion


        #endregion
    }
}
