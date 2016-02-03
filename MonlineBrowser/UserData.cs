using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// ユーザーごとの情報
    /// </summary>
    class UserData
    {
        #region Field
        /// <summary>
        /// インスタンス
        /// </summary>
        public static UserData Instance
        {
            get { return mInstance; }
        }
        private static UserData mInstance = new UserData();

        /// <summary>
        /// アイテム情報
        /// </summary>
        public List<ItemData> ItemDatas
        {
            get { return mItemDatas; }
        }
        private List<ItemData> mItemDatas = new List<ItemData>();

        /// <summary>
        /// 編成情報
        /// </summary>
        public List<DeckData> DeckDatas
        {
            get { return mDeckDatas; }
        }
        private List<DeckData> mDeckDatas = new List<DeckData>();

        /// <summary>
        /// リフレッシュ情報
        /// </summary>
        public List<RefreshData> RefreshDatas
        {
            get { return mRefreshDatas; }
        }
        private List<RefreshData> mRefreshDatas = new List<RefreshData>();

        /// <summary>
        /// カード情報
        /// </summary>
        public List<CardData> CardDatas
        {
            get { return mCardDatas; }
        }
        private List<CardData> mCardDatas = new List<CardData>();

        /// <summary>
        /// プレイヤー情報
        /// </summary>
        public PlayerData PlayerData
        {
            get { return mPlayerData; }
        }
        private PlayerData mPlayerData = new PlayerData();
        #endregion

        /// <summary>
        /// AFMからパースする
        /// </summary>
        public void Parse(FluorineFx.ASObject bodyAsObject)
        {
            ParseItem(bodyAsObject);
            ParseDeck(bodyAsObject);
            ParseRefresh(bodyAsObject);
            ParseCard(bodyAsObject);
            ParsePlayer(bodyAsObject);
            // ADD:
        }

        #region アイテム
        private void ParseItem(FluorineFx.ASObject asObject)
        {
            Object itemObj = null;
            if (asObject.TryGetValue("item", out itemObj) && itemObj != null)
            {
                // 配列の時とそうでない時の両方に対応する
                Object[] itemObjs = null;
                Type varType = itemObj.GetType();
                if (varType == typeof(FluorineFx.ASObject))
                {
                    itemObjs = new FluorineFx.ASObject[1];
                    itemObjs[0] = (FluorineFx.ASObject)itemObj;
                }
                else if (varType == typeof(Object[]))
                {
                    itemObjs = (Object[])itemObj;
                }

                for (int i = 0; i < itemObjs.Length; ++i)
                {
                    FluorineFx.ASObject asObj = itemObjs[i] as FluorineFx.ASObject;

                    ItemData data = new ItemData();
                    data.Parse(asObj);

                    // 既出なら上書きする
                    Int32 findDataIndex = mItemDatas.FindIndex(
                        delegate(ItemData inData)
                        {
                            return inData.itemMstId == data.itemMstId;
                        }
                    );
                    if (0 <= findDataIndex)
                    {
                        // お使いから帰ってきた場合、増加値が返る。
                        // 結果の値はプレイヤー情報に入っているので、ここでは処理しない。
                        bool isOverride = !IsReturnHome(asObject);
                        if (isOverride)
                        {
                            mItemDatas[findDataIndex] = data;
                        }
                    }
                    // 新出なら追加する
                    else
                    {
                        mItemDatas.Add(data);
                    }
                }
            }
        }
        #endregion

        #region デッキ
        private void ParseDeck(FluorineFx.ASObject asObject)
        {
            // 配列の時と、そうでない時がある。
            // 前者はグループ編成画面を開いた時、後者は戦闘開始前やお使い終了時など。
            Object deckObj = null;
            if (asObject.TryGetValue("deck", out deckObj) && deckObj != null)
            {
                Object[] deckObjs = null;

                // 単体の時
                Type varType = deckObj.GetType();
                if (varType == typeof(FluorineFx.ASObject))
                {
                    deckObjs = new FluorineFx.ASObject[1];
                    deckObjs[0] = (FluorineFx.ASObject)deckObj;
                }
                // 配列の時
                else if(varType == typeof(Object[]))
                {
                    deckObjs = (Object[])deckObj;
                }

                for (Int32 i = 0; i < deckObjs.Length; ++i)
                {
                    FluorineFx.ASObject asObj = (FluorineFx.ASObject)deckObjs[i];
                    if (asObj != null)
                    {
                        DeckData parseData = new DeckData();
                        parseData.Parse(asObj);

                        // 既出なら上書きする
                        Int32 findDataIndex = mDeckDatas.FindIndex(
                            delegate(DeckData a)
                            {
                                return (a.deckId == parseData.deckId);
                            }
                        );
                        if (0 <= findDataIndex)
                        {
                            mDeckDatas[findDataIndex] = parseData;
                        }
                        // 新出なら追加する
                        else 
                        {
                            mDeckDatas.Add(parseData);
                        }
                    }
                }
                
                // ID昇順でソートする
                mDeckDatas.Sort(
                    delegate(DeckData a, DeckData b)
                    {
                        return a.deckId - b.deckId;
                    }
                    );
            }
        }
        #endregion

        #region リフレッシュ
        private void ParseRefresh(FluorineFx.ASObject asObject)
        {
            Object refreshObj = null;
            if (asObject.TryGetValue("refresh", out refreshObj) && refreshObj != null)
            {
                Object[] refreshObjs = (Object[])refreshObj;
                if (refreshObjs != null)
                {
                    mRefreshDatas.Clear();
                    for (int i = 0; i < refreshObjs.Length; ++i)
                    {
                        FluorineFx.ASObject asObj = refreshObjs[i] as FluorineFx.ASObject;

                        RefreshData data = new RefreshData();
                        data.Parse(asObj);

                        mRefreshDatas.Add(data);
                    }
                }
            }
        }
        #endregion

        #region カード
        /// <summary>
        /// card情報をパースする
        /// </summary>
        /// <param name="asObject"></param>
        private void ParseCard(FluorineFx.ASObject asObject)
        {
            Object cardObj = null;
            if (asObject.TryGetValue("card", out cardObj) && cardObj != null)
            {
                Object[] cardObjs = null;

                // 配列の時とそうでない時の両方に対応する
                Type varType = cardObj.GetType();
                if (varType == typeof(FluorineFx.ASObject))
                {
                    cardObjs = new FluorineFx.ASObject[1];
                    cardObjs[0] = (FluorineFx.ASObject)cardObj;
                }
                else if (varType == typeof(Object[]))
                {
                    cardObjs = (Object[])cardObj;

                    // cardは強化合成や限界突破によって容易く減る機会が多い
                    // 配列の場合、全情報が入っていると思いたいが食事の時は対象となるモン娘の情報しかない
                    // この違いを"misc"があるかどうかで判断する。あればクリアする。
                    if (FiddlerUtil.IsExistObject(asObject, FiddlerUtil.KeyNameType.MISC) &&
                        // "misc"があってもお使いからの帰宅時は対象外
                        !IsReturnHome(asObject))
                    {
                        mCardDatas.Clear();
                    }
                }

                for (int i = 0; i < cardObjs.Length; ++i)
                {
                    FluorineFx.ASObject asObj = cardObjs[i] as FluorineFx.ASObject;
                    if (asObj != null)
                    {
                        CardData parseData = new CardData();
                        parseData.Parse(asObj);

                        // 既出なら更新する
                        Int32 findDataIndex = mCardDatas.FindIndex(
                            delegate(CardData inData)
                            {
                                return (inData.cardId == parseData.cardId);
                            }
                            );
                        if (0 <= findDataIndex)
                        {
                            mCardDatas[findDataIndex] = parseData;
                        }
                        // 新出なら追加する
                        else
                        {
                            mCardDatas.Add(parseData);
                        }
                    }
                }

                // ソートする
                mCardDatas.Sort(
                    delegate(CardData a, CardData b)
                    {
                        return a.cardId - b.cardId;
                    }
                    );
            }
        }
        #endregion

        #region プレイヤー
        private void ParsePlayer(FluorineFx.ASObject asObject)
        {
            Object playerObj = null;
            if (asObject.TryGetValue("player", out playerObj) && playerObj != null)
            {
                Type varType = playerObj.GetType();
                if (varType == typeof(FluorineFx.ASObject))
                {
                    FluorineFx.ASObject asObj = (FluorineFx.ASObject)playerObj;
                    if (asObj != null)
                    {
                        PlayerData playerData = new PlayerData();
                        playerData.Parse(asObj);

                        // 1つなので常に上書きする
                        mPlayerData = playerData;

                        // ユーザー情報にも保持されている値に反映する
                        ApplyToUserData();
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 帰宅したかどうかを取得する
        /// </summary>
        /// <returns>帰宅したかどうか</returns>
        private bool IsReturnHome(FluorineFx.ASObject asObject)
        {
            Object miscObj = null;
            if (asObject.TryGetValue("misc", out miscObj) && miscObj != null)
            {
                FluorineFx.ASObject miscAsObj = (FluorineFx.ASObject)miscObj;
                Int32 finishType = -1;
                if (FiddlerUtil.IsExistObject(miscAsObj, "finishType"))
                {
                    AMFUtil.GetInt32Value(miscAsObj, "finishType", out finishType);
                    if (finishType == 0)    // お使いから帰ってくると0が入っている
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// ユーザー情報に値を反映する。
        /// 主に食材の値を正しくするために必要。
        /// </summary>
        private void ApplyToUserData()
        {
            UserDataUtil.SetItemCountByTag(DBItemMst.ItemTag.MEAT, mPlayerData.meat);
            UserDataUtil.SetItemCountByTag(DBItemMst.ItemTag.VEGETABLE, mPlayerData.vegetable);
            UserDataUtil.SetItemCountByTag(DBItemMst.ItemTag.BREAD, mPlayerData.bread);
        }
    }
}
