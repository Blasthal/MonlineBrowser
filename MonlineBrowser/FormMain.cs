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
        #region Field
        /// <summary>
        /// モン娘の情報
        /// </summary>
        struct DeckMonmusuInfo
        {
            public Label level;
            public Label rarity;
            public Label name;
            public Label race;
            public Label hpValue;
            public ProgressBar hpBar;
            public Label tensionValue;
            public ProgressBar tensionBar;
            public Label satietyValue;
            public ProgressBar satietyBar;
            public PictureBox likeFood;
        }
        DeckMonmusuInfo[] mDeckMonmusuInfos = new DeckMonmusuInfo[5];
        #endregion

        public FormMain()
        {
            InitializeComponent();

            // モン娘情報を初期化する
            InitializeDeckMonmusuInfos();

            // 一度更新しておく
            UpdateDeck(0);
        }

        /// <summary>
        /// モン娘のデッキ情報を初期化する
        /// </summary>
        private void InitializeDeckMonmusuInfos()
        {
            // インスタンスを作成する
            for (int i = 0; i < mDeckMonmusuInfos.Length; ++i)
            {
                mDeckMonmusuInfos[i] = new DeckMonmusuInfo();
            }

            // 1体目
            mDeckMonmusuInfos[0].level = labelDeckMonmusuLevelValue1;
            mDeckMonmusuInfos[0].rarity = labelDeckMonmusuRarityName1;
            mDeckMonmusuInfos[0].name = labelDeckMonmusuName1;
            mDeckMonmusuInfos[0].race = labelDeckMonmusuRaceName1;
            mDeckMonmusuInfos[0].hpValue = labelDeckMonmusuHPValue1;
            mDeckMonmusuInfos[0].hpBar = progressBarDeckMonmusuHP1;
            mDeckMonmusuInfos[0].tensionValue = labelDeckMonmusuTensionValue1;
            mDeckMonmusuInfos[0].tensionBar = progressBarDeckMonmusuTension1;
            mDeckMonmusuInfos[0].satietyValue = labelDeckMonmusuSatietyValue1;
            mDeckMonmusuInfos[0].satietyBar = progressBarDeckMonmusuSatiety1;
            mDeckMonmusuInfos[0].likeFood = pictureBoxDeckMonmusuLikeFood1;

            // 2体目
            mDeckMonmusuInfos[1].level = labelDeckMonmusuLevelValue2;
            mDeckMonmusuInfos[1].rarity = labelDeckMonmusuRarityName2;
            mDeckMonmusuInfos[1].name = labelDeckMonmusuName2;
            mDeckMonmusuInfos[1].race = labelDeckMonmusuRaceName2;
            mDeckMonmusuInfos[1].hpValue = labelDeckMonmusuHPValue2;
            mDeckMonmusuInfos[1].hpBar = progressBarDeckMonmusuHP2;
            mDeckMonmusuInfos[1].tensionValue = labelDeckMonmusuTensionValue2;
            mDeckMonmusuInfos[1].tensionBar = progressBarDeckMonmusuTension2;
            mDeckMonmusuInfos[1].satietyValue = labelDeckMonmusuSatietyValue2;
            mDeckMonmusuInfos[1].satietyBar = progressBarDeckMonmusuSatiety2;
            mDeckMonmusuInfos[1].likeFood = pictureBoxDeckMonmusuLikeFood2;

            // 3体目
            mDeckMonmusuInfos[2].level = labelDeckMonmusuLevelValue3;
            mDeckMonmusuInfos[2].rarity = labelDeckMonmusuRarityName3;
            mDeckMonmusuInfos[2].name = labelDeckMonmusuName3;
            mDeckMonmusuInfos[2].race = labelDeckMonmusuRaceName3;
            mDeckMonmusuInfos[2].hpValue = labelDeckMonmusuHPValue3;
            mDeckMonmusuInfos[2].hpBar = progressBarDeckMonmusuHP3;
            mDeckMonmusuInfos[2].tensionValue = labelDeckMonmusuTensionValue3;
            mDeckMonmusuInfos[2].tensionBar = progressBarDeckMonmusuTension3;
            mDeckMonmusuInfos[2].satietyValue = labelDeckMonmusuSatietyValue3;
            mDeckMonmusuInfos[2].satietyBar = progressBarDeckMonmusuSatiety3;
            mDeckMonmusuInfos[2].likeFood = pictureBoxDeckMonmusuLikeFood3;

            // 4体目
            mDeckMonmusuInfos[3].level = labelDeckMonmusuLevelValue4;
            mDeckMonmusuInfos[3].rarity = labelDeckMonmusuRarityName4;
            mDeckMonmusuInfos[3].name = labelDeckMonmusuName4;
            mDeckMonmusuInfos[3].race = labelDeckMonmusuRaceName4;
            mDeckMonmusuInfos[3].hpValue = labelDeckMonmusuHPValue4;
            mDeckMonmusuInfos[3].hpBar = progressBarDeckMonmusuHP4;
            mDeckMonmusuInfos[3].tensionValue = labelDeckMonmusuTensionValue4;
            mDeckMonmusuInfos[3].tensionBar = progressBarDeckMonmusuTension4;
            mDeckMonmusuInfos[3].satietyValue = labelDeckMonmusuSatietyValue4;
            mDeckMonmusuInfos[3].satietyBar = progressBarDeckMonmusuSatiety4;
            mDeckMonmusuInfos[3].likeFood = pictureBoxDeckMonmusuLikeFood4;

            // 5体目
            mDeckMonmusuInfos[4].level = labelDeckMonmusuLevelValue5;
            mDeckMonmusuInfos[4].rarity = labelDeckMonmusuRarityName5;
            mDeckMonmusuInfos[4].name = labelDeckMonmusuName5;
            mDeckMonmusuInfos[4].race = labelDeckMonmusuRaceName5;
            mDeckMonmusuInfos[4].hpValue = labelDeckMonmusuHPValue5;
            mDeckMonmusuInfos[4].hpBar = progressBarDeckMonmusuHP5;
            mDeckMonmusuInfos[4].tensionValue = labelDeckMonmusuTensionValue5;
            mDeckMonmusuInfos[4].tensionBar = progressBarDeckMonmusuTension5;
            mDeckMonmusuInfos[4].satietyValue = labelDeckMonmusuSatietyValue5;
            mDeckMonmusuInfos[4].satietyBar = progressBarDeckMonmusuSatiety5;
            mDeckMonmusuInfos[4].likeFood = pictureBoxDeckMonmusuLikeFood5;
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //プロキシ設定を外す
            Fiddler.URLMonInterop.ResetProxyInProcessToDefault();

            //Fiddlerを終了させる
            Fiddler.FiddlerApplication.Shutdown();
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

        #region WebBrowser
        private void DoNavigation(object sender, EventArgs e)
        {
            // インターネット一時ファイルを削除する
            // これを行わないと、二回目以降Flashの再生が行われず進行しなくなる。
            System.Diagnostics.Process.Start("RunDll32", "InetCpl.cpl,ClearMyTracksByProcess 8");

            //WebBrowserコントロールに指定URIを開かせる
            webBrowser1.Navigate(textBoxUrl.Text);
        }

        private void OpenFormMaster(object sender, EventArgs e)
        {
            // フォームを一意に開く
            FormMasterViewer.Instance.Show();
            FormMasterViewer.Instance.Focus();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // モンラインでないならreturn
            bool isMonline = e.Url.OriginalString.Contains("app_id=365723");
            if (!isMonline)
            {
                return;
            }

            // WebBrowserコントロールにゲーム画面を合わせる
            HtmlDocument doc = webBrowser1.Document;
            if (doc != null && doc.Body != null)
            {
                // 不要な要素を消すstyleを埋め込む
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
        #endregion

        #region 編成
        /// <summary>
        /// デッキ情報のモン娘の表示を更新する
        /// </summary>
        /// <param name="deckId">出来ID</param>
        /// <param name="monmusuIndex">デッキ内の順番</param>
        public void UpdateDeckMonmusu(Int32 deckId, Int32 monmusuIndex)
        {
            DeckMonmusuInfo info = mDeckMonmusuInfos[monmusuIndex];

            // レアリティ
            if (info.rarity != null)
            {
                info.rarity.Text = UserDataUtil.GetMonmusuRarityName(deckId, monmusuIndex);
                info.rarity.ForeColor = UserDataUtil.GetRarityNameColor(deckId, monmusuIndex);
            }

            // 名前
            if (info.name != null)
            {
                info.name.Text = UserDataUtil.GetMonmusuName(deckId, monmusuIndex);
            }

            // 種族名
            if (info.race != null)
            {
                info.race.Text = UserDataUtil.GetRaceName(deckId, monmusuIndex);
            }

            // レベル
            if (info.level != null)
            {
                info.level.Text = UserDataUtil.GetMonmusuLevel(deckId, monmusuIndex).ToString();
            }

            // HP
            if (info.hpValue != null && info.hpBar != null)
            {
                Int32 hp = UserDataUtil.GetMonmusuHP(deckId, monmusuIndex);
                info.hpValue.Text = hp.ToString();

                Int32 hpMax = UserDataUtil.GetMonmusuHPMax(deckId, monmusuIndex);
                info.hpBar.Minimum = 0;
                info.hpBar.Maximum = hpMax;
                info.hpBar.Value = hp;
            }

            // テンション
            if (info.tensionValue != null && info.tensionBar != null)
            {
                Int32 tension = UserDataUtil.GetMonmusuTension(deckId, monmusuIndex);
                info.tensionValue.Text = tension.ToString();
                info.tensionBar.Minimum = 0;
                info.tensionBar.Maximum = 100;
                info.tensionBar.Value = Math.Min(tension, progressBarDeckMonmusuTension1.Maximum);
            }

            // 満腹度
            if (info.satietyValue != null && info.satietyBar != null)
            {
                String satietyText = UserDataUtil.GetMonmusuSatietyText(deckId, monmusuIndex);
                info.satietyValue.Text = satietyText;

                Int32 satiety = UserDataUtil.GetMonmusuSatiety(deckId, monmusuIndex);
                Int32 satietyMax = UserDataUtil.GetMonmusuSatietyMax(deckId, monmusuIndex);
                info.satietyBar.Minimum = 0;
                info.satietyBar.Maximum = satietyMax;
                info.satietyBar.Value = satiety;
            }

            // 好物
            if (info.likeFood != null)
            {
                info.likeFood.Image = UserDataUtil.GetMonmusuLikeFoodPicture(deckId, monmusuIndex);
            }
        }

        /// <summary>
        /// デッキ情報の表示を更新する
        /// </summary>
        /// <param name="deckId">デッキID</param>
        public void UpdateDeck(Int32 deckId)
        {
            // デッキ名を更新する
            labelGroupName.Text = UserDataUtil.GetDeckName(deckId);

            // グループ編成を更新する
            for (Int32 i = 0; i < mDeckMonmusuInfos.Length; ++i)
            {
                UpdateDeckMonmusu(deckId, i);
            }
        }

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

        private void radioButtonDeck3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio != null
                && radio.Checked)
            {
                UpdateDeck(3);
            }
        }

        private void radioButtonDeck4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio != null
                && radio.Checked)
            {
                UpdateDeck(4);
            }
        }

        private void radioButtonDeck5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio != null
                && radio.Checked)
            {
                UpdateDeck(5);
            }
        }
        #endregion
    }
}
