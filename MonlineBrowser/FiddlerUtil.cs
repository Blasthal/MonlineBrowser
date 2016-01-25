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

                        // デッキ表示を更新する
                        // 別スレッドなのでinvokeが必要になる
                        Int32 deckId = form.GetCurrentCheckDeckId();
                        if (0 < deckId)
                        {
                            form.Invoke(new FormMain.UpdateDeckDele(form.UpdateDeck), deckId);
                        }

                        // 道具情報を更新する
                        // 別スレッドなのでinvokeが必要になる
                        form.Invoke(new FormMain.UpdateItemDele(form.UpdateItem));
                    }
                }
            }
        }
    }
}
