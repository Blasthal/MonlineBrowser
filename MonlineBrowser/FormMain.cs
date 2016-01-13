using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonlineBrowser
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            InitializeComponent();

            // 一度更新しておく
            UpdateDeck(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // クライアントからレスポンスを送る前に呼ばれるイベント
            Fiddler.FiddlerApplication.BeforeRequest += new Fiddler.SessionStateHandler(FiddlerApplication_BeforeRequest);
            //クライアントへレスポンスを返した後に呼ばれるイベント
            Fiddler.FiddlerApplication.AfterSessionComplete += new Fiddler.SessionStateHandler(FiddlerApplication_AfterSessionComplete);

            //Fiddlerを開始。ポートは自動選択
            Fiddler.FiddlerApplication.Startup(0, Fiddler.FiddlerCoreStartupFlags.ChainToUpstreamGateway);

            //当該プロセスのプロキシを設定する。WebBroweserコントロールはこの設定を参照
            string proxy = string.Format("127.0.0.1:{0}", Fiddler.FiddlerApplication.oProxy.ListenPort);
            Fiddler.URLMonInterop.SetProxyInProcess(proxy, "<local>");

            // ★？
            Fiddler.CONFIG.IgnoreServerCertErrors = false;
        }

        private void DoNavigation(object sender, EventArgs e)
        {
            //WebBrowserコントロールに指定URIを開かせる
            webBrowser1.Navigate(textBoxUrl.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //プロキシ設定を外す
            Fiddler.URLMonInterop.ResetProxyInProcessToDefault();

            //Fiddlerを終了させる
            Fiddler.FiddlerApplication.Shutdown();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // モンラインでないならreturn
            bool isMonline = e.Url.OriginalString.Contains("app_id=365723");
            if (!isMonline)
            {
                return;
            }

            // ★WebBrowserコントロールにゲーム画面を合わせる
            HtmlDocument doc = webBrowser1.Document;
            if (doc != null && doc.Body != null)
            {
                // ★styleを埋め込む
                HtmlElement elem = doc.CreateElement("style");
                elem.SetAttribute("type", "text/css");
                elem.InnerHtml =
                    ".clearfix{display:none;}" +
                    ".naviapp{display:none;}" +
                    "#foot{display:none;}";

                doc.Body.InsertAdjacentElement(HtmlElementInsertionOrientation.BeforeEnd, elem);

                // 消すのが難しい部分は残して、スクロールで対応する。
                if (doc.Window != null)
                {
                    doc.Window.ScrollTo(30, 16);
                }
            }
        }

        private void OpenFormMaster(object sender, EventArgs e)
        {
            // フォームを一意に開く
            FormMasterViewer.Instance.Show();
            FormMasterViewer.Instance.Focus();
        }

        /// <summary>
        /// デッキ情報の表示を更新する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        public void UpdateDeck(Int32 deckId)
        {
            // デッキ名を更新する
            labelGroupName.Text = UserDataUtil.GetDeckName(deckId);

            //... グループ編成を更新する
            int monmusuIndex = -1;

            // 1
            ++monmusuIndex;
            {
                // レアリティ
                labelDeckMonmusuRarityName1.Text = UserDataUtil.GetMonmusuRarityName(deckId, monmusuIndex);
                labelDeckMonmusuRarityName1.ForeColor = UserDataUtil.GetRarityNameColor(deckId, monmusuIndex);

                // 名前
                labelDeckMonmusuName1.Text = UserDataUtil.GetMonmusuName(deckId, monmusuIndex);

                // 種族名
                labelDeckMonmusuRaceName1.Text = UserDataUtil.GetRaceName(deckId, monmusuIndex);

                // レベル
                labelDeckMonmusuLevelValue1.Text = UserDataUtil.GetMonmusuLevel(deckId, monmusuIndex).ToString();

                // HP
                Int32 hp = UserDataUtil.GetMonmusuHP(deckId, monmusuIndex);
                labelDeckMonmusuHPValue1.Text = hp.ToString();

                Int32 hpMax = UserDataUtil.GetMonmusuHPMax(deckId, monmusuIndex);
                progressBarDeckMonmusuHP1.Minimum = 0;
                progressBarDeckMonmusuHP1.Maximum = hpMax;
                progressBarDeckMonmusuHP1.Value = hp;

                // テンション
                Int32 tension = UserDataUtil.GetMonmusuTension(deckId, monmusuIndex);
                labelDeckMonmusuTensionValue1.Text = tension.ToString();
                progressBarDeckMonmusuTension1.Minimum = 0;
                progressBarDeckMonmusuTension1.Maximum = 100;
                progressBarDeckMonmusuTension1.Value = Math.Min(tension, progressBarDeckMonmusuTension1.Maximum);

                // 満腹度
                String satietyText = UserDataUtil.GetMonmusuSatietyText(deckId, monmusuIndex);
                labelDeckMonmusuSatietyValue1.Text = satietyText;

                Int32 satiety = UserDataUtil.GetMonmusuSatiety(deckId, monmusuIndex);
                Int32 satietyMax = UserDataUtil.GetMonmusuSatietyMax(deckId, monmusuIndex);
                progressBarDeckMonmusuSatiety1.Minimum = 0;
                progressBarDeckMonmusuSatiety1.Maximum = satietyMax;
                progressBarDeckMonmusuSatiety1.Value = satiety;
            }

            // 2
            ++monmusuIndex;
            labelDeckMonmusuName2.Text = UserDataUtil.GetMonmusuName(deckId, monmusuIndex);

            // 3
            ++monmusuIndex;
            labelDeckMonmusuName3.Text = UserDataUtil.GetMonmusuName(deckId, monmusuIndex);

            // 4
            ++monmusuIndex;
            labelDeckMonmusuName4.Text = UserDataUtil.GetMonmusuName(deckId, monmusuIndex);

            // 5
            ++monmusuIndex;
            labelDeckMonmusuName5.Text = UserDataUtil.GetMonmusuName(deckId, monmusuIndex);
        }

        /// <summary>
        /// 現在選択しているデッキIDを取得する
        /// </summary>
        /// <returns>現在選択中のデッキID。異常な場合は0を返す。</returns>
        public Int32 GetCurrentCheckDeckId()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl.GetType() == typeof(RadioButton))
                {
                    RadioButton radio = (RadioButton)ctrl;
                    if (radio.Checked)
                    {
                        int deckId = 0;
                        if (Int32.TryParse(radio.Text, out deckId))
                        {
                            return deckId;
                        }
                    }
                }
            }

            return 0;
        }

        #region Fiddler

        private void FiddlerApplication_BeforeRequest(Fiddler.Session oSession)
        {
            FiddlerUtil.BeforeRequest(oSession);
        }

        public delegate void UpdateDeckDele(Int32 deckId);

        private void FiddlerApplication_AfterSessionComplete(Fiddler.Session oSession)
        {
            FiddlerUtil.AfterSessionComplete(oSession, this);
        }

        #endregion

        private void radioButtonDeck1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio != null
                && radio.Checked)
            {
                UpdateDeck(1);
            }
        }

        private void radioButtonDeck2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio != null
                && radio.Checked)
            {
                UpdateDeck(2);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio != null
                && radio.Checked)
            {
                UpdateDeck(3);
            }
        }
    }
}
