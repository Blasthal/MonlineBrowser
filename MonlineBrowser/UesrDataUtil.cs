using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// ユーザーごとの情報に関する機能提供クラス
    /// </summary>
    static class UserDataUtil
    {
        #region Method

        #region 情報取得
        /// <summary>
        /// デッキ情報を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <returns>デッキ情報。無い場合はnullを返す</returns>
        public static DeckData GetDeckData(Int32 deckId)
        {
            DeckData findData = UserData.Instance.DeckDatas.Find(
                delegate(DeckData inData)
                {
                    return inData.deckId == deckId;
                }
                );

            return findData;
        }

        /// <summary>
        /// カード情報を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>カード情報。無い場合はnullを返す。</returns>
        public static CardData GetCardData(Int32 cardId)
        {
            CardData findData = null;
            if (0 < cardId)
            {
                findData = UserData.Instance.CardDatas.Find(
                    delegate(CardData inData)
                    {
                        return (inData.cardId == cardId);
                    }
                    );

                // nullの場合は出力する
                if (findData == null)
                {
                    String text = string.Empty;
                    text = "CardData is null. cardId={0}";
                    text = String.Format(text, cardId);

                    System.Diagnostics.Debug.WriteLine(text);
                }
            }

            return findData;
        }

        /// <summary>
        /// カードIDを取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>対象のモン娘のカードIDを返す</returns>
        public static Int32 GetCardId(Int32 deckId, Int32 index)
        {
            DeckData findDeckData = GetDeckData(deckId);
            if (findDeckData != null)
            {
                switch (index)
                {
                    case 0: return findDeckData.cardId1;
                    case 1: return findDeckData.cardId2;
                    case 2: return findDeckData.cardId3;
                    case 3: return findDeckData.cardId4;
                    case 4: return findDeckData.cardId5;
                }
            }

            return 0;
        }

        /// <summary>
        /// カードIDからカードマスターIDを取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>カードマスターID</returns>
        public static Int32 GetCardMstId(Int32 cardId)
        {
            // ユーザーのカード情報を探す
            CardData findData = GetCardData(cardId);
            if (findData == null)
            {
                return 0;
            }

            // カード情報からマスター情報を参照する
            CardMstData mstData = DBMstUtil.GetCardMstData(findData.cardMstId);
            if (mstData == null)
            {
                return 0;
            }

            return mstData.cardMstId;
        }
        #endregion

        #region デッキ名
        /// <summary>
        /// デッキ名を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <returns>デッキ名を返す。無い場合は無効な文字列を返す。</returns>
        public static String GetDeckName(Int32 deckId)
        {
            DeckData findData = GetDeckData(deckId);
            if (findData != null)
            {
                return findData.deckName;
            }

            return "-----";
        }
        #endregion

        #region モン娘の名前
        /// <summary>
        /// モン娘の名前を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">モン娘の順番</param>
        /// <returns>モン娘の名前。無い場合は"-----"を返す</returns>
        public static String GetMonmusuName(Int32 deckId, Int32 index)
        {
            String name = "-----";

            DeckData findDeckData = GetDeckData(deckId);
            if (findDeckData != null)
            {
                switch (index)
                {
                    case 0: name = GetMonmusuName(findDeckData.cardId1); break;
                    case 1: name = GetMonmusuName(findDeckData.cardId2); break;
                    case 2: name = GetMonmusuName(findDeckData.cardId3); break;
                    case 3: name = GetMonmusuName(findDeckData.cardId4); break;
                    case 4: name = GetMonmusuName(findDeckData.cardId5); break;
                }
            }

            return name;
        }

        /// <summary>
        /// モン娘の名前を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns></returns>
        public static String GetMonmusuName(Int32 cardId)
        {
            String name = "-----";

            // ユーザーのカード情報を探す
            CardData findData = UserData.Instance.CardDatas.Find(
                delegate(CardData inData)
                {
                    return (inData.cardId == cardId);
                }
                );

            if (findData == null)
            {
                return name;
            }

            // カード情報からマスター情報を参照する
            CardMstData mstData = DBCardMst.CardMstDatas.Find(
                delegate(CardMstData inData)
                {
                    return (inData.cardMstId == findData.cardMstId);
                }
                );

            if (mstData == null)
            {
                return name;
            }

            // 名前を取得する
            name = mstData.name;

            return name;
        }
        #endregion

        #region モン娘の限界突破回数
        /// <summary>
        /// モン娘の限界突破回数を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の限界突破回数</returns>
        public static Int32 GetMonmusuRebirthCount(Int32 deckId, Int32 index)
        {
            Int32 rebirthCount = 0;

            DeckData findDeckData = GetDeckData(deckId);
            if (findDeckData != null)
            {
                switch (index)
                {
                    case 0: rebirthCount = GetMonmusuRebirthCount(findDeckData.cardId1); break;
                    case 1: rebirthCount = GetMonmusuRebirthCount(findDeckData.cardId2); break;
                    case 2: rebirthCount = GetMonmusuRebirthCount(findDeckData.cardId3); break;
                    case 3: rebirthCount = GetMonmusuRebirthCount(findDeckData.cardId4); break;
                    case 4: rebirthCount = GetMonmusuRebirthCount(findDeckData.cardId5); break;
                }
            }

            return rebirthCount;
        }

        /// <summary>
        /// モン娘の限界突破回数を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の限界突破回数</returns>
        public static Int32 GetMonmusuRebirthCount(Int32 cardId)
        {
            Int32 rebirthCount = 0;

            // ユーザーのカード情報を探す
            CardData findData = UserData.Instance.CardDatas.Find(
                delegate(CardData inData)
                {
                    return (inData.cardId == cardId);
                }
                );
            if (findData == null)
            {
                return rebirthCount;
            }

            rebirthCount = findData.rebirthCount;

            return rebirthCount;
        }
        #endregion

        #region モン娘のレベル
        /// <summary>
        /// モン娘のレベルを取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘のレベルを返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuLevel(Int32 deckId, Int32 index)
        {
            Int32 level = 0;

            DeckData findDeckData = GetDeckData(deckId);
            if (findDeckData != null)
            {
                switch (index)
                {
                    case 0: level = GetMonmusuLevel(findDeckData.cardId1); break;
                    case 1: level = GetMonmusuLevel(findDeckData.cardId2); break;
                    case 2: level = GetMonmusuLevel(findDeckData.cardId3); break;
                    case 3: level = GetMonmusuLevel(findDeckData.cardId4); break;
                    case 4: level = GetMonmusuLevel(findDeckData.cardId5); break;
                }
            }

            return level;
        }

        /// <summary>
        /// モン娘のレベルを取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘のレベルを返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuLevel(Int32 cardId)
        {
            Int32 level = 0;

            // ユーザーのカード情報を探す
            CardData findData = UserData.Instance.CardDatas.Find(
                delegate(CardData inData)
                {
                    return (inData.cardId == cardId);
                }
                );

            if (findData == null)
            {
                return level;
            }

            level = findData.level;

            return level;
        }
        #endregion

        #region モン娘のテンション
        /// <summary>
        /// モン娘のテンションを取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘のテンションを返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuTension(Int32 deckId, Int32 index)
        {
            Int32 tension = 0;

            DeckData findDeckData = GetDeckData(deckId);
            if (findDeckData != null)
            {
                switch (index)
                {
                    case 0: tension = GetMonmusuTension(findDeckData.cardId1); break;
                    case 1: tension = GetMonmusuTension(findDeckData.cardId2); break;
                    case 2: tension = GetMonmusuTension(findDeckData.cardId3); break;
                    case 3: tension = GetMonmusuTension(findDeckData.cardId4); break;
                    case 4: tension = GetMonmusuTension(findDeckData.cardId5); break;
                }
            }

            return tension;
        }

        /// <summary>
        /// モン娘のテンションを取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘のテンションを返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuTension(Int32 cardId)
        {
            Int32 tension = 0;

            // ユーザーのカード情報を探す
            CardData findData = GetCardData(cardId);
            if (findData == null)
            {
                return tension;
            }

            tension = findData.tension;

            return tension;
        }
        #endregion

        #region モン娘の気力
        /// <summary>
        /// モン娘の気力を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の気力を返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuHP(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            Int32 hp = GetMonmusuHP(cardId);

            return hp;
        }

        /// <summary>
        /// モン娘の気力を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の気力を返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuHP(Int32 cardId)
        {
            Int32 hp = 0;

            CardData findData = GetCardData(cardId);
            if (findData == null)
            {
                return hp;
            }

            hp = findData.hp;

            return hp;
        }

        /// <summary>
        /// モン娘の最大気力を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の最大気力を返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuHPMax(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            Int32 hp = GetMonmusuMaxHP(cardId);

            return hp;
        }

        /// <summary>
        /// モン娘の最大気力を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の最大気力を返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuMaxHP(Int32 cardId)
        {
            Int32 hpMax = 0;

            CardData findData = GetCardData(cardId);
            if (findData == null)
            {
                return hpMax;
            }

            hpMax = findData.hpMax;

            return hpMax;
        }
        #endregion

        #region モン娘の満腹度
        /// <summary>
        /// モン娘の満腹度を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の満腹度を返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuSatiety(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            Int32 satiety = GetMonmusuSatiety(cardId);

            return satiety;
        }

        /// <summary>
        /// モン娘の満腹度を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の満腹度を返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuSatiety(Int32 cardId)
        {
            Int32 satiety = 0;

            CardData findData = GetCardData(cardId);
            if (findData == null)
            {
                return satiety;
            }

            satiety = findData.feelFull;

            return satiety;
        }

        /// <summary>
        /// モン娘の最大満腹度を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の最大満腹度を返す。モン娘が見つからない場合、0を返す。</returns>
        public static Int32 GetMonmusuSatietyMax(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            Int32 satietyMax = GetMonmusuSatietyMax(cardId);

            return satietyMax;
        }

        /// <summary>
        /// モン娘の最大満腹度を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の最大満腹度を返す</returns>
        public static Int32 GetMonmusuSatietyMax(Int32 cardId)
        {
            Int32 cardMstId = GetCardMstId(cardId);
            Int32 satietyMax = DBMstUtil.GetMonmusuSatietyMax(cardMstId);

            return satietyMax;
        }

        /// <summary>
        /// モン娘の満腹度表示文字列を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の満腹度表示文字列</returns>
        public static String GetMonmusuSatietyText(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            String text = GetMonmusuSatietyText(cardId);
            return text;
        }

        /// <summary>
        /// モン娘の満腹度表示文字列を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の満腹度表示文字列</returns>
        public static String GetMonmusuSatietyText(Int32 cardId)
        {
            Int32 satiety = GetMonmusuSatiety(cardId);
            Int32 satietyMax = GetMonmusuSatietyMax(cardId);
            String text = String.Format("{0}/{1}", satiety, satietyMax);
            return text;
        }
        #endregion

        #region モン娘のレアリティ名
        /// <summary>
        /// モン娘のレアリティ名を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘のレアリティ名を返す</returns>
        public static String GetMonmusuRarityName(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            String rarityName = GetMonmusuRarityName(cardId);

            return rarityName;
        }

        /// <summary>
        /// モン娘のレアリティ名を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘のレアリティ名を返す</returns>
        public static String GetMonmusuRarityName(Int32 cardId)
        {
            Int32 cardMstId = GetCardMstId(cardId);
            CardMstData cardMstData = DBMstUtil.GetCardMstData(cardMstId);
            if (cardMstData != null)
            {
                String rarityName = DBMstUtil.GetMonmusuRarityName(cardMstData.rarityMstId);
                return rarityName;
            }

            return "--";
        }
        #endregion

        #region モン娘の種族名
        /// <summary>
        /// モン娘の種族名を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の種族名を返す</returns>
        public static String GetRaceName(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            String raceName = GetRaceName(cardId);

            return raceName;
        }

        /// <summary>
        /// モン娘の種族名を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の種族名</returns>
        public static String GetRaceName(Int32 cardId)
        {
            Int32 cardMstId = GetCardMstId(cardId);
            String raceName = DBMstUtil.GetCardMessageRaceName(cardMstId);

            return raceName;
        }
        #endregion

        #region モン娘の好物
        /// <summary>
        /// モン娘の好物を画像で取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>モン娘の好物の画像</returns>
        public static Bitmap GetMonmusuLikeFoodPicture(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            Bitmap picture = GetMonmusuLikeFoodPicture(cardId);

            return picture;
        }

        /// <summary>
        /// モン娘の好物を画像で取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>モン娘の好物の画像</returns>
        public static Bitmap GetMonmusuLikeFoodPicture(Int32 cardId)
        {
            Int32 cardMstId = GetCardMstId(cardId);
            Int32 likeFood = DBMstUtil.GetMonmusuLikeFood(cardMstId);
            ResourceUtil.FoodType foodType = (ResourceUtil.FoodType)likeFood;
            Bitmap picture = ResourceUtil.GetPictureFoodType(foodType);

            return picture;
        }
        #endregion

        #region モン娘の属性
        /// <summary>
        /// モン娘の属性を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>属性</returns>
        public static Int32 GetMonmusuElement(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            return GetMonmusuElement(cardId);
        }

        /// <summary>
        /// モン娘の属性を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>属性</returns>
        public static Int32 GetMonmusuElement(Int32 cardId)
        {
            Int32 cardMstId = GetCardMstId(cardId);
            return DBMstUtil.GetMonmusuElement(cardMstId);
        }

        /// <summary>
        /// モン娘の属性の画像を取得する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        /// <param name="index">デッキ内の順番</param>
        /// <returns>属性の画像</returns>
        public static Bitmap GetMonmusuElementPicture(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            return GetMonmusuElementPicture(cardId);
        }
        
        /// <summary>
        /// モン娘の属性の画像を取得する
        /// </summary>
        /// <param name="cardId">カードID</param>
        /// <returns>属性の画像</returns>
        public static Bitmap GetMonmusuElementPicture(Int32 cardId)
        {
            Int32 element = UserDataUtil.GetMonmusuElement(cardId);
            ResourceUtil.ElementType elementType = (ResourceUtil.ElementType)element;
            Bitmap image = ResourceUtil.GetPictureElement(elementType);
            return image;
        }
        #endregion

        #region レアリティの色
        private struct RarityNameColorData
        {
            public String rarityName;
            public Color color;

            public RarityNameColorData(String rarityName, Color color)
            {
                this.rarityName = rarityName;
                this.color = color;
            }
        }

        private static readonly RarityNameColorData[] RarityNameColorDatas = new RarityNameColorData[]
        {
            new RarityNameColorData("N", Color.DeepSkyBlue),
            new RarityNameColorData("R", Color.SandyBrown),
            new RarityNameColorData("HR", Color.LightSteelBlue),
            new RarityNameColorData("SR", Color.Gold),
        };

        public static Color GetRarityNameColor(String rarityName)
        {
            for (Int32 i = 0; i < RarityNameColorDatas.Length; ++i)
            {
                if (rarityName == RarityNameColorDatas[i].rarityName)
                {
                    return RarityNameColorDatas[i].color;
                }
            }

            return Color.White;
        }

        public static Color GetRarityNameColor(Int32 deckId, Int32 index)
        {
            Int32 cardId = GetCardId(deckId, index);
            String rarityName = GetMonmusuRarityName(cardId);
            Color rarityColor = GetRarityNameColor(rarityName);

            return rarityColor;
        }
        #endregion

        #region アイテム
        /// <summary>
        /// タグを指定して所持数を変更する
        /// </summary>
        /// <param name="itemTag">アイテムのタグ</param>
        public static void SetItemCountByTag(DBItemMst.ItemTag itemTag, Int32 count)
        {
            // マスターIDを取得する
            Int32 itemMstId = 0;
            itemMstId = DBItemMst.GetItemMstId(itemTag);
            if (itemMstId == 0)
            {
                return;
            }

            // データを参照して値を変更する
            Int32 findIndex = UserData.Instance.ItemDatas.FindIndex(
                delegate(ItemData inData)
                {
                    return (inData.itemMstId == itemMstId);
                }
                );
            if (0 <= findIndex)
            {
                UserData.Instance.ItemDatas[findIndex].itemCount = count;
            }
        }
        #endregion

        #region モン娘の総数
        /// <summary>
        /// 現在のモン娘の総数を取得します
        /// </summary>
        /// <returns>現在のモン娘の総数</returns>
        public static Int32 GetMonmusuWholeCountCurrent()
        {
            return UserData.Instance.CardDatas.Count;
        }

        /// <summary>
        /// モン娘の最大総数を取得します
        /// </summary>
        /// <returns>モン娘の最大総数</returns>
        public static Int32 GetMonmusuWholeCountMax()
        {
            return UserData.Instance.PlayerData.cardMax;
        }
        #endregion

        #endregion
    }
}
