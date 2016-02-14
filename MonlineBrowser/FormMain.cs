using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MonlineBrowser
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        #region Field
        /// <summary>
        /// WebBrowser上のゲーム画面の位置
        /// X 30:X座標
        /// Y 40:DMMのヘッダー
        /// Y 36:空白部分
        /// </summary>
        Point mGamePositionInWeb = new Point(30, 40 + 36);

        /// <summary>
        /// スクリーンショットの情報
        /// </summary>
        struct ScreenshotInfo
        {
            public RadioButton extensionRadioButton;
            public System.Drawing.Imaging.ImageFormat imageFormat;
            public String extensionName;
        }
        ScreenshotInfo[] mScreenshotInfos = null;

        /// <summary>
        /// モン娘の情報
        /// </summary>
        struct DeckMonmusuInfo
        {
            public PictureBox[] rebirths;
            public Label level;
            public Label rarity;
            public Label name;
            public Label race;
            public PictureBox element;
            public Label hpValue;
            public ProgressBar hpBar;
            public Label tensionValue;
            public ProgressBar tensionBar;
            public Label satietyValue;
            public ProgressBar satietyBar;
            public PictureBox likeFood;

            public void Initialize()
            {
                rebirths = new PictureBox[3];
            }
        }
        DeckMonmusuInfo[] mDeckMonmusuInfos = new DeckMonmusuInfo[5];
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            this.Focus();

#if DEBUG
#else
            // Release時、Debug用の機能を呼び出すボタンは表示しない
            this.textBoxUrl.Visible = false;
            this.buttonNavi.Visible = false;
            this.buttonMaster.Visible = false;

            // 自動でURLを開く
            DoNavigation(this, EventArgs.Empty);
#endif

            // モン娘情報を初期化する
            InitializeDeckMonmusuInfos();
            // スクリーンショット情報を初期化する
            InitializeScreenshotInfos();

            // 基本情報を更新する
            UpdatePlayerName();
            UpdatePlayerLevel();
            UpdatePlayerExp();
            UpdatePossessionMeal();
            UpdatePossessionRuby();
            UpdateLabelMonmusuWholeCount();
            // 編成情報を更新する。初期化用。
            UpdateDeck(0);
            // 初期表示するパネルを編成情報にする
            ChangeVisiblePanel(DataPanel.FORMATION);

            // スクリーンショットの保存先が未記載なら、起動したパスを代入しておく
            string screenshotPath = Properties.Settings.Default.ScreenshotPath;
            if (screenshotPath == string.Empty)
            {
                Properties.Settings.Default.ScreenshotPath = Application.StartupPath;
            }
            textBoxScreenshotPath.Text = Properties.Settings.Default.ScreenshotPath;

            // スクリーンショットの拡張子選択を初期化する
            Int32 ssExtIndex = Properties.Settings.Default.ScreenshotExtensionIndex;
            if (0 <= ssExtIndex && ssExtIndex < mScreenshotInfos.Length)
            {
                mScreenshotInfos[ssExtIndex].extensionRadioButton.Checked = true;
            }
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
                mDeckMonmusuInfos[i].Initialize();
            }

            // 1体目
            mDeckMonmusuInfos[0].rebirths[0] = pictureBoxDeckMonmusuRebirth11;
            mDeckMonmusuInfos[0].rebirths[1] = pictureBoxDeckMonmusuRebirth12;
            mDeckMonmusuInfos[0].rebirths[2] = pictureBoxDeckMonmusuRebirth13;
            mDeckMonmusuInfos[0].level = labelDeckMonmusuLevelValue1;
            mDeckMonmusuInfos[0].rarity = labelDeckMonmusuRarityName1;
            mDeckMonmusuInfos[0].name = labelDeckMonmusuName1;
            mDeckMonmusuInfos[0].race = labelDeckMonmusuRaceName1;
            mDeckMonmusuInfos[0].element = pictureBoxDeckMonmusuElement1;
            mDeckMonmusuInfos[0].hpValue = labelDeckMonmusuHPValue1;
            mDeckMonmusuInfos[0].hpBar = progressBarDeckMonmusuHP1;
            mDeckMonmusuInfos[0].tensionValue = labelDeckMonmusuTensionValue1;
            mDeckMonmusuInfos[0].tensionBar = progressBarDeckMonmusuTension1;
            mDeckMonmusuInfos[0].satietyValue = labelDeckMonmusuSatietyValue1;
            mDeckMonmusuInfos[0].satietyBar = progressBarDeckMonmusuSatiety1;
            mDeckMonmusuInfos[0].likeFood = pictureBoxDeckMonmusuLikeFood1;

            // 2体目
            mDeckMonmusuInfos[1].rebirths[0] = pictureBoxDeckMonmusuRebirth21;
            mDeckMonmusuInfos[1].rebirths[1] = pictureBoxDeckMonmusuRebirth22;
            mDeckMonmusuInfos[1].rebirths[2] = pictureBoxDeckMonmusuRebirth23;
            mDeckMonmusuInfos[1].level = labelDeckMonmusuLevelValue2;
            mDeckMonmusuInfos[1].rarity = labelDeckMonmusuRarityName2;
            mDeckMonmusuInfos[1].name = labelDeckMonmusuName2;
            mDeckMonmusuInfos[1].race = labelDeckMonmusuRaceName2;
            mDeckMonmusuInfos[1].element = pictureBoxDeckMonmusuElement2;
            mDeckMonmusuInfos[1].hpValue = labelDeckMonmusuHPValue2;
            mDeckMonmusuInfos[1].hpBar = progressBarDeckMonmusuHP2;
            mDeckMonmusuInfos[1].tensionValue = labelDeckMonmusuTensionValue2;
            mDeckMonmusuInfos[1].tensionBar = progressBarDeckMonmusuTension2;
            mDeckMonmusuInfos[1].satietyValue = labelDeckMonmusuSatietyValue2;
            mDeckMonmusuInfos[1].satietyBar = progressBarDeckMonmusuSatiety2;
            mDeckMonmusuInfos[1].likeFood = pictureBoxDeckMonmusuLikeFood2;

            // 3体目
            mDeckMonmusuInfos[2].rebirths[0] = pictureBoxDeckMonmusuRebirth31;
            mDeckMonmusuInfos[2].rebirths[1] = pictureBoxDeckMonmusuRebirth32;
            mDeckMonmusuInfos[2].rebirths[2] = pictureBoxDeckMonmusuRebirth33;
            mDeckMonmusuInfos[2].level = labelDeckMonmusuLevelValue3;
            mDeckMonmusuInfos[2].rarity = labelDeckMonmusuRarityName3;
            mDeckMonmusuInfos[2].name = labelDeckMonmusuName3;
            mDeckMonmusuInfos[2].race = labelDeckMonmusuRaceName3;
            mDeckMonmusuInfos[2].element = pictureBoxDeckMonmusuElement3;
            mDeckMonmusuInfos[2].hpValue = labelDeckMonmusuHPValue3;
            mDeckMonmusuInfos[2].hpBar = progressBarDeckMonmusuHP3;
            mDeckMonmusuInfos[2].tensionValue = labelDeckMonmusuTensionValue3;
            mDeckMonmusuInfos[2].tensionBar = progressBarDeckMonmusuTension3;
            mDeckMonmusuInfos[2].satietyValue = labelDeckMonmusuSatietyValue3;
            mDeckMonmusuInfos[2].satietyBar = progressBarDeckMonmusuSatiety3;
            mDeckMonmusuInfos[2].likeFood = pictureBoxDeckMonmusuLikeFood3;

            // 4体目
            mDeckMonmusuInfos[3].rebirths[0] = pictureBoxDeckMonmusuRebirth41;
            mDeckMonmusuInfos[3].rebirths[1] = pictureBoxDeckMonmusuRebirth42;
            mDeckMonmusuInfos[3].rebirths[2] = pictureBoxDeckMonmusuRebirth43;
            mDeckMonmusuInfos[3].level = labelDeckMonmusuLevelValue4;
            mDeckMonmusuInfos[3].rarity = labelDeckMonmusuRarityName4;
            mDeckMonmusuInfos[3].name = labelDeckMonmusuName4;
            mDeckMonmusuInfos[3].race = labelDeckMonmusuRaceName4;
            mDeckMonmusuInfos[3].element = pictureBoxDeckMonmusuElement4;
            mDeckMonmusuInfos[3].hpValue = labelDeckMonmusuHPValue4;
            mDeckMonmusuInfos[3].hpBar = progressBarDeckMonmusuHP4;
            mDeckMonmusuInfos[3].tensionValue = labelDeckMonmusuTensionValue4;
            mDeckMonmusuInfos[3].tensionBar = progressBarDeckMonmusuTension4;
            mDeckMonmusuInfos[3].satietyValue = labelDeckMonmusuSatietyValue4;
            mDeckMonmusuInfos[3].satietyBar = progressBarDeckMonmusuSatiety4;
            mDeckMonmusuInfos[3].likeFood = pictureBoxDeckMonmusuLikeFood4;

            // 5体目
            mDeckMonmusuInfos[4].rebirths[0] = pictureBoxDeckMonmusuRebirth51;
            mDeckMonmusuInfos[4].rebirths[1] = pictureBoxDeckMonmusuRebirth52;
            mDeckMonmusuInfos[4].rebirths[2] = pictureBoxDeckMonmusuRebirth53;
            mDeckMonmusuInfos[4].level = labelDeckMonmusuLevelValue5;
            mDeckMonmusuInfos[4].rarity = labelDeckMonmusuRarityName5;
            mDeckMonmusuInfos[4].name = labelDeckMonmusuName5;
            mDeckMonmusuInfos[4].race = labelDeckMonmusuRaceName5;
            mDeckMonmusuInfos[4].element = pictureBoxDeckMonmusuElement5;
            mDeckMonmusuInfos[4].hpValue = labelDeckMonmusuHPValue5;
            mDeckMonmusuInfos[4].hpBar = progressBarDeckMonmusuHP5;
            mDeckMonmusuInfos[4].tensionValue = labelDeckMonmusuTensionValue5;
            mDeckMonmusuInfos[4].tensionBar = progressBarDeckMonmusuTension5;
            mDeckMonmusuInfos[4].satietyValue = labelDeckMonmusuSatietyValue5;
            mDeckMonmusuInfos[4].satietyBar = progressBarDeckMonmusuSatiety5;
            mDeckMonmusuInfos[4].likeFood = pictureBoxDeckMonmusuLikeFood5;
        }

        /// <summary>
        /// スクリーンショットの情報を初期化する
        /// </summary>
        private void InitializeScreenshotInfos()
        {
            // インスタンスを作成する
            mScreenshotInfos = new ScreenshotInfo[5];
            for (int i = 0; i < mScreenshotInfos.Length; ++i)
            {
                mScreenshotInfos[i] = new ScreenshotInfo();
            }

            int index = -1;

            // BMP
            ++index;
            mScreenshotInfos[index].extensionRadioButton = this.radioButtonScreenshotExtensionBmp;
            mScreenshotInfos[index].extensionName = "bmp";
            mScreenshotInfos[index].imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;

            // JPG
            ++index;
            mScreenshotInfos[index].extensionRadioButton = this.radioButtonScreenshotExtensionJpg;
            mScreenshotInfos[index].extensionName = "jpg";
            mScreenshotInfos[index].imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

            // PNG
            ++index;
            mScreenshotInfos[index].extensionRadioButton = this.radioButtonScreenshotExtensionPng;
            mScreenshotInfos[index].extensionName = "png";
            mScreenshotInfos[index].imageFormat = System.Drawing.Imaging.ImageFormat.Png;

            // GIF
            ++index;
            mScreenshotInfos[index].extensionRadioButton = this.radioButtonScreenshotExtensionGif;
            mScreenshotInfos[index].extensionName = "gif";
            mScreenshotInfos[index].imageFormat = System.Drawing.Imaging.ImageFormat.Gif;

            // TIFF
            ++index;
            mScreenshotInfos[index].extensionRadioButton = this.radioButtonScreenshotExtensionTiff;
            mScreenshotInfos[index].extensionName = "tiff";
            mScreenshotInfos[index].imageFormat = System.Drawing.Imaging.ImageFormat.Tiff;
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

            // 設定を保存する
            Properties.Settings.Default.ScreenshotPath = this.textBoxScreenshotPath.Text;

            for (Int32 i = 0; i < mScreenshotInfos.Length; ++i)
            {
                ScreenshotInfo ssInfo = mScreenshotInfos[i];
                if (ssInfo.extensionRadioButton.Checked)
                {
                    Properties.Settings.Default.ScreenshotExtensionIndex = i;
                    break;
                }
            }

            Properties.Settings.Default.Save();

            // インターネット一時ファイルを削除する
            System.Diagnostics.Process process = ClearTemporaryFiles(true);
        }

        /// <summary>
        /// インターネット一時ファイルを削除します。
        /// これを行わないと、二回目以降のFlashの再生が行われず進行しなくなります。
        /// </summary>
        private System.Diagnostics.Process ClearTemporaryFiles(bool isWaitFinish)
        {
            // これを行わないと、二回目以降Flashの再生が行われず進行しなくなる。
            System.Diagnostics.Process process = System.Diagnostics.Process.Start("RunDll32", "InetCpl.cpl,ClearMyTracksByProcess 8");

            if (isWaitFinish)
            {
                while (!process.HasExited)
                {
                    process.WaitForExit(10);
                }
            }

            return process;
        }

        /// <summary>
        /// 現在選択しているデッキIDを取得する
        /// </summary>
        /// <returns>現在選択中のデッキID。異常な場合は0を返す。</returns>
        public Int32 GetCurrentCheckDeckId()
        {
            foreach (Control ctrl in panelFormation.Controls)
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

        public delegate void UpdateDelegate0();
        public delegate void UpdateDelegate1(Int32 var1);

        private void FiddlerApplication_AfterSessionComplete(Fiddler.Session oSession)
        {
            FiddlerUtil.AfterSessionComplete(oSession, this);
        }
        #endregion

        #region WebBrowser
        private void DoNavigation(object sender, EventArgs e)
        {
            // 一時ファイルを削除する
            ClearTemporaryFiles(true);

            // WebBrowserコントロールに指定URIを開かせる
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
                // WebBrowserのWindow位置をスクロールする
                ScrollWebWindowToGame();

                // スクロールバーを非表示にする
                webBrowser1.ScrollBarsEnabled = false;
            }
        }
        #endregion

        #region 基本情報
        /// <summary>
        /// プレイヤー名の標示を更新する
        /// </summary>
        public void UpdatePlayerName()
        {
            String text = UserData.Instance.PlayerData.name;
            if (text == null)
            {
                text = "----------------";
            }
            labelPlayerName.Text = text;
        }

        /// <summary>
        /// プレイヤーレベルの表示を更新する
        /// </summary>
        public void UpdatePlayerLevel()
        {
            labelPlayerLevel.Text = UserData.Instance.PlayerData.level.ToString();
        }

        /// <summary>
        /// プレイヤーの経験値の表示を更新する
        /// </summary>
        public void UpdatePlayerExp()
        {
            Int64 nowExp = (Int64)UserData.Instance.PlayerData.exp;
            Int64 nextExp = (Int64)(UserData.Instance.PlayerData.expMaxForNextLevel + nowExp);
            
            String text = String.Format("{0}/{1}", nowExp, nextExp);
            labelPlayerExp.Text = text;
        }

        /// <summary>
        /// プレイヤーの所持食材の表示を更新する
        /// </summary>
        public void UpdatePossessionMeal()
        {
            labelMeatCount.Text = UserData.Instance.PlayerData.meat.ToString();
            labelVegetableCount.Text = UserData.Instance.PlayerData.vegetable.ToString();
            labelBreadCount.Text = UserData.Instance.PlayerData.bread.ToString();
        }

        /// <summary>
        /// プレイヤーの所持ルビーの表示を更新する
        /// </summary>
        public void UpdatePossessionRuby()
        {
            labelRuby.Text = UserData.Instance.PlayerData.ruby.ToString();
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

            // 限界突破
            if (info.rebirths != null)
            {
                Int32 rebirthCount = UserDataUtil.GetMonmusuRebirthCount(deckId, monmusuIndex);
                for (Int32 i = 0; i < info.rebirths.Length; ++i)
                {
                    PictureBox pic = info.rebirths[i];
                    if (pic != null)
                    {
                        bool isRebirth = (i < rebirthCount);
                        Image rebirthImgOn = ResourceUtil.GetPictureRebirth(isRebirth);
                        pic.Image = rebirthImgOn;
                    }
                }
            }

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

            // 属性
            if (info.element != null)
            {
                Int32 element = UserDataUtil.GetMonmusuElement(deckId, monmusuIndex);
                ResourceUtil.ElementType elementType = (ResourceUtil.ElementType)element;
                info.element.Image = ResourceUtil.GetPictureElement(elementType);
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

        #region アイテム
        /// <summary>
        /// 所持アイテム一覧の表示を更新する
        /// </summary>
        public void UpdateItem()
        {
            if (0 < UserData.Instance.ItemDatas.Count)
            {
                dataGridViewItem.Rows.Clear();

                for (int i = 0; i < UserData.Instance.ItemDatas.Count; ++i)
                {
                    ItemData data = UserData.Instance.ItemDatas[i];

                    // 行を追加する
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridViewItem);
                    Int32 rowIndex = dataGridViewItem.Rows.Add(row);

                    // 行の追加後に情報を入れる
                    // DataGridViewから取得しないと2行目以降でインデックスエラーが出る
                    dataGridViewItem["ColumnItemImage", rowIndex].Value = ResourceUtil.GetPictureItem(data.itemMstId);
                    dataGridViewItem["ColumnItemName", rowIndex].Value = DBMstUtil.GetItemName(data.itemMstId);
                    dataGridViewItem["ColumnItemNum", rowIndex].Value = data.itemCount.ToString();
                }
            }
        }
        #endregion

        #region スクリーンショット
        /// <summary>
        /// スクリーンショットの保存先パスをダイアログで指定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonScreenshotPathDialog_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            // フォルダーを開く設定にする
            dialog.IsFolderPicker = true;

            // 読み取り専用フォルダとコントロールパネルは開かせない
            dialog.EnsureReadOnly = false;
            dialog.AllowNonFileSystemItems = false;

            // 表示する最初のフォルダを指定する
            dialog.DefaultDirectory = Application.StartupPath;
            dialog.InitialDirectory = textBoxScreenshotPath.Text;

            // 開く
            dialog.Title = "スクリーンショットの保存先フォルダを選択";
            CommonFileDialogResult result = dialog.ShowDialog();

            // 決定したフォルダのパスを代入する
            if (result == CommonFileDialogResult.Ok &&
                dialog.FileName != String.Empty)
            {
                textBoxScreenshotPath.Text = dialog.FileName;
            }
        }


        // ole32.dllのOleDrawを使用する(Const定義)
        const int DVASPECT_CONTENT = 1;

        // ole32.dllのOleDrawを使用する(DllImport定義)
        [System.Runtime.InteropServices.DllImport("ole32.dll")]
        extern static int OleDraw(
            IntPtr pUnk,
            int dwAspect,
            IntPtr hdcDraw,
            ref Rectangle lprcBounds);

        private void buttonScreenShot_Click(object sender, EventArgs e)
        {
            // WebBrowserのサイズ(WEBページのサイズ)に合わせてBitmap生成
            Bitmap bmp = new Bitmap(webBrowser1.Width, webBrowser1.Height);

            // BitmapのGraphicsを取得
            Graphics gra = Graphics.FromImage(bmp);

            // BitmapのGraphicsのHdcを取得
            IntPtr hdc = gra.GetHdc();

            // WebBrowser(WEBページ)のオブジェクト取得
            IntPtr web =
                System.Runtime.InteropServices.Marshal.GetIUnknownForObject(
                webBrowser1.ActiveXInstance);

            // WebBrowser(WEBページ)のイメージをBitmapにコピー
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            OleDraw(web, DVASPECT_CONTENT, hdc, ref rect);

            // WebBrowser(WEBページ)のオブジェクト使用終了
            System.Runtime.InteropServices.Marshal.Release(web);

            // BitmapのGraphicsの使用終了
            gra.Dispose();

            // Bitmapを保存する
            if (textBoxScreenshotPath.Text == String.Empty)
            {
                // パスが空欄の場合、exeと同じディレクトリを自動で代入する
                textBoxScreenshotPath.Text = Application.StartupPath;
            }

            String savePath = textBoxScreenshotPath.Text;
            if (savePath.Last() != '\\')
            {
                savePath += '\\';
            }
            if (System.IO.Directory.Exists(savePath))
            {
                // ファイル名を追加する
                savePath += "Monline_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // 拡張子を追加する
                String extName = "jpg";
                System.Drawing.Imaging.ImageFormat imgFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                for (Int32 i = 0; i < mScreenshotInfos.Length; ++i)
                {
                    ScreenshotInfo ssInfo = mScreenshotInfos[i];
                    if (ssInfo.extensionRadioButton.Checked)
                    {
                        extName = ssInfo.extensionName;
                        imgFormat = ssInfo.imageFormat;
                        break;
                    }
                }
                savePath += "." + extName;

                // 保存する
                bmp.Save(savePath, imgFormat);
            }
        }

        private void buttonScreenshotPathExlorer_Click(object sender, EventArgs e)
        {
            // フォルダをエクスプローラーで開く
            String path = textBoxScreenshotPath.Text;
            if (System.IO.Directory.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                System.Diagnostics.Process.Start(Application.StartupPath);
            }
        }
        #endregion

        #region パネル変更
        /// <summary>
        /// パネルの種類。
        /// 要素を増減させる時は、使用している箇所も対応させること。
        /// </summary>
        private enum DataPanel
        {
            FORMATION,
            ITEM,
            CONFIG,
        }

        /// <summary>
        /// 表示するパネルを変更する
        /// </summary>
        /// <param name="eDataPanel">パネルの種類</param>
        private void ChangeVisiblePanel(DataPanel eDataPanel)
        {
            Panel[] panels = new Panel[]
            {
                this.panelFormation,
                this.panelItem,
                this.panelConfig,
            };

            // 一旦全てを非表示にする
            for (Int32 i = 0; i < panels.Length; ++i)
            {
                panels[i].Visible = false;
            }

            // 対象のパネルだけを表示する
            panels[(int)eDataPanel].Visible = true;
        }

        private void buttonFormation_Click(object sender, EventArgs e)
        {
            ChangeVisiblePanel(DataPanel.FORMATION);
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            ChangeVisiblePanel(DataPanel.CONFIG);
        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            ChangeVisiblePanel(DataPanel.ITEM);
        }

        #endregion

        #region ゲーム画面位置修正
        /// <summary>
        /// WebBrowserのWindow位置をゲーム画面にスクロールします
        /// </summary>
        private void ScrollWebWindowToGame()
        {
            HtmlDocument doc = webBrowser1.Document;
            if (doc != null)
            {
                doc.Window.ScrollTo(mGamePositionInWeb);
            }
        }

        private void buttonModifyWebPosition_Click(object sender, EventArgs e)
        {
            ScrollWebWindowToGame();
        }
        #endregion

        #region モン娘一覧
        /// <summary>
        /// モン娘一覧のフォームを開く
        /// </summary>
        private void OpenFormMonmusuList()
        {
            FormMonmusuList form = FormMonmusuList.Instance;
            form.Show();
            form.Focus();
        }

        private void buttonMonmusuList_Click(object sender, EventArgs e)
        {
            OpenFormMonmusuList();
        }

        /// <summary>
        /// モン娘の総数表示を更新する
        /// </summary>
        public void UpdateLabelMonmusuWholeCount()
        {
            // テキストを設定する
            Int32 wholeCountNow = UserDataUtil.GetMonmusuWholeCountCurrent();
            Int32 wholeCountMax = UserDataUtil.GetMonmusuWholeCountMax();
            String text = String.Format("{0}/{1}", wholeCountNow, wholeCountMax);
            labelMonmusuWholeCount.Text = text;

            // 最大値を超えていたら色を変更する
            System.Drawing.Color color = System.Drawing.Color.White;
            if (wholeCountMax <= wholeCountNow)
            {
                color = System.Drawing.Color.Red;
            }
            labelMonmusuWholeCount.ForeColor = color;
        }
        #endregion

    }
}
