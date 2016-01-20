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
            // ADD:
        }

        private void ParseItem(FluorineFx.ASObject asObject)
        {
            Object itemObj = null;
            if (asObject.TryGetValue("item", out itemObj) && itemObj != null)
            {
                // 配列の時と、そうでない時があるので検知する
                Type varType = itemObj.GetType();
                if (varType == typeof(FluorineFx.ASObject))
                {
                    // 単体の時
                    FluorineFx.ASObject asObj = itemObj as FluorineFx.ASObject;
                    if (asObj != null)
                    {
                        ItemData data = new ItemData();
                        data.Parse(asObj);

                        // 既出なら上書きする
                        ItemData existData = mItemDatas.Find(
                            delegate(ItemData inData)
                            {
                                return inData.itemMstId == data.itemMstId;
                            }
                        );
                        if (existData != null)
                        {
                            existData = data;
                        }
                        // 新出なら追加する
                        else
                        {
                            mItemDatas.Add(data);
                        }
                    }
                }
                else if (varType == typeof(Object[]))
                {
                    // 配列の時
                    Object[] itemObjs = (Object[])itemObj;
                    if (itemObjs != null)
                    {
                        mItemDatas.Clear();
                        for (int i = 0; i < itemObjs.Length; ++i)
                        {
                            FluorineFx.ASObject asObj = itemObjs[i] as FluorineFx.ASObject;

                            ItemData data = new ItemData();
                            data.Parse(asObj);

                            mItemDatas.Add(data);
                        }
                    }
                }
            }
        }

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
    }
}
