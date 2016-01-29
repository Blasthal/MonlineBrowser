using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonlineBrowser
{
    class FiddlerUtil
    {
        /// <summary>
        /// オブジェクトのキー名の種類。
        /// キー名は小文字に変換して検索するので留意。
        /// </summary>
        public enum KeyNameType
        {
            PLAYER,
            CARD,
            DECK,
            ITEM,
            // ADD
        }

        /// <summary>
        /// リクエスト前に処理する
        /// </summary>
        /// <param name="oSession">セッション情報</param>
        public static void BeforeRequest(Fiddler.Session oSession)
        {
            // ★キャストエラーのチェックテスト
            //object obj = (Int32)32;
            //float f = (float)obj;

            // モンラインのみを対象にする
            if (!oSession.hostname.StartsWith("monmusugame"))
            {
                oSession.Ignore();
                return;
            }

        }

        /// <summary>
        /// セッション完了後に処理する
        /// </summary>
        /// <param name="oSession">セッション情報</param>
        public static void AfterSessionComplete(Fiddler.Session oSession, FormMain form)
        {
            //取り敢えずログを吐く
            string text = string.Format("Session {0}({3}):HTTP {1} for {2}",
                    oSession.id,
                    oSession.responseCode,
                    oSession.fullUrl,
                    oSession.oResponse.MIMEType
                    );

            System.Diagnostics.Debug.WriteLine(text);

            // AMF形式のレスが来たら覗いてみる
            if (oSession.oResponse.MIMEType.Contains("amf"))
            {
                using (System.IO.Stream stream = new System.IO.MemoryStream(oSession.ResponseBody))
                {
                    // AMF形式の情報をデシリアライズする
                    FluorineFx.IO.AMFDeserializer amfDeserializer = new FluorineFx.IO.AMFDeserializer(stream);
                    FluorineFx.IO.AMFMessage responseMessage = amfDeserializer.ReadAMFMessage();

                    // BODYからContentを取得する
                    FluorineFx.IO.AMFBody responseBody = responseMessage.GetBodyAt(0);
                    FluorineFx.ASObject contentAsObj = responseBody.Content as FluorineFx.ASObject;
                    Object bodyObj = null;
                    if (contentAsObj.TryGetValue("body", out bodyObj))
                    {
                        FluorineFx.ASObject bodyAsObj = bodyObj as FluorineFx.ASObject;

                        // girlLevelMst
                        DBGirlLevelMst.Parse(bodyAsObj);
                        // productMst
                        DBProductMst.Parse(bodyAsObj);
                        // TODO:memorialMst
                        // TODO:requestMst
                        // TODO:skillLevelMst
                        // TODO:productPackMst
                        // TODO:skillEffectMst
                        // TODO:skillMst
                        // cardMessageMst
                        DBCardMessageMst.Parse(bodyAsObj);
                        // itemMst
                        DBItemMst.Parse(bodyAsObj);
                        // TODO:careMst
                        // cardMst
                        DBCardMst.Parse(bodyAsObj);
                        // rarityMst
                        DBRarityMst.Parse(bodyAsObj);
                        // TODO:jobMst
                        // TODO:playerLevelMst
                        // TODO:tuningMst
                        // TODO:rubyMst

                        /* UserData */

                        UserData.Instance.Parse(bodyAsObj);

                        
                        // プレイヤー情報の表示を更新する
                        if (IsExistObject(bodyAsObj, KeyNameType.PLAYER))
                        {
                            form.Invoke(new FormMain.UpdateDelegate0(form.UpdatePlayerName));
                            form.Invoke(new FormMain.UpdateDelegate0(form.UpdatePlayerLevel));
                            form.Invoke(new FormMain.UpdateDelegate0(form.UpdatePlayerExp));
                            form.Invoke(new FormMain.UpdateDelegate0(form.UpdatePossessionMeal));
                            form.Invoke(new FormMain.UpdateDelegate0(form.UpdatePossessionRuby));
                        }

                        // デッキ表示を更新する
                        // 別スレッドなのでinvokeが必要になる
                        if (IsExistObject(bodyAsObj, KeyNameType.CARD) ||
                            IsExistObject(bodyAsObj, KeyNameType.DECK))
                        {
                            Int32 deckId = form.GetCurrentCheckDeckId();
                            if (0 < deckId)
                            {
                                form.Invoke(new FormMain.UpdateDelegate1(form.UpdateDeck), deckId);
                            }
                        }

                        // 道具情報を更新する
                        // 別スレッドなのでinvokeが必要になる
                        if (IsExistObject(bodyAsObj, KeyNameType.PLAYER) ||
                            IsExistObject(bodyAsObj, KeyNameType.ITEM))
                        {
                            form.Invoke(new FormMain.UpdateDelegate0(form.UpdateItem));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ActionScriptObjectの直下にある指定のキー名のオブジェクトを取得する
        /// 無い場合はnullが入る
        /// </summary>
        /// <param name="asObject">対象先オブジェクト</param>
        /// <param name="keyName">キー名</param>
        /// <param name="obj">取得先オブジェクト</param>
        /// <returns>オブジェクトがある場合はtrue、無い場合はfalseを返す</returns>
        public static bool TryGetObject(FluorineFx.ASObject asObject, String keyName, out Object obj)
        {
            obj = null;
            if (asObject.TryGetValue(keyName, out obj))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// ActionScriptObjectの直下にある指定のキー名のオブジェクトがあるかどうかを取得する
        /// </summary>
        /// <param name="asObject">対象先オブジェクト</param>
        /// <param name="keyName">キー名</param>
        /// <returns>オブジェクトがある場合はtrue、無い場合はfalseを返す</returns>
        public static bool IsExistObject(FluorineFx.ASObject asObject, String keyName)
        {
            Object obj = null;
            bool isExist = TryGetObject(asObject, keyName, out obj);

            return isExist;
        }

        public static bool IsExistObject(FluorineFx.ASObject asObject, KeyNameType keyName)
        {
            String text = keyName.ToString();
            text = text.ToLower();

            return IsExistObject(asObject, text);
        }

    }
}
