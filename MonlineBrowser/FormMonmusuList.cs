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
    public partial class FormMonmusuList : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static FormMonmusuList Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (mInstance == null || mInstance.IsDisposed)
                {
                    mInstance = new FormMonmusuList();
                }

                return mInstance;
            }
        }
        private static FormMonmusuList mInstance = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private FormMonmusuList()
        {
            InitializeComponent();
        }

        private void FormMonmusuList_Load(object sender, EventArgs e)
        {
            UpdateMonmusuList();
        }

        #region モン娘リスト
        /// <summary>
        /// モン娘のリストを更新する
        /// </summary>
        private void UpdateMonmusuList()
        {
            // 情報を代入するためのヘッダー名を用意する
            // GridViewと揃える
            string[] colHeaderNames = new string[]
            {
                "ColumnMonID",
                "ColumnMonLevel",
                "ColumnMonRebirth",
                "ColumnMonName",
                "ColumnMonRace",
                "ColumnMonElement",
                "ColumnMonHP",
                "ColumnMonTension",
                "ColumnMonSatiety",
                "ColumnMonFood",
            };

            dataGridViewMonmusuList.Rows.Clear();
            for (Int32 i = 0; i < UserData.Instance.CardDatas.Count; ++i)
            {
                CardData data = UserData.Instance.CardDatas[i];

                // 行を追加する
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewMonmusuList);
                Int32 rowIndex = dataGridViewMonmusuList.Rows.Add(row);

                // 行の追加後に情報を入れる
                // DataGridViewから取得しないと2行目以降でインデックスエラーが出る
                Int32 colIndex = 0;
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = (i + 1).ToString();
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuLevel(data.cardId);
                colIndex++;
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuName(data.cardId);
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetRaceName(data.cardId);
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuElementPicture(data.cardId);
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuHP(data.cardId);
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuTension(data.cardId);
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuSatietyText(data.cardId);
                dataGridViewMonmusuList[colHeaderNames[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuLikeFoodPicture(data.cardId);
            }

            // ビューの横幅を調整する
            Int32 widthAllCol = 0;
            for (Int32 i = 0; i < dataGridViewMonmusuList.Columns.Count; ++i)
            {
                widthAllCol += dataGridViewMonmusuList.Columns[i].HeaderCell.Size.Width;
            }

            System.Reflection.PropertyInfo pi = dataGridViewMonmusuList.GetType().GetProperty("VerticalScrollBar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (pi != null)
            {
                VScrollBar vsb = pi.GetValue(dataGridViewMonmusuList, null) as VScrollBar;
                if (vsb != null && vsb.Visible)
                {
                    widthAllCol += vsb.Width;
                }
            }

            dataGridViewMonmusuList.Width = widthAllCol;

            // フォームのサイズを変更する
            Size formSize = new Size(0, 0);
            formSize.Width += dataGridViewMonmusuList.Location.X;
            formSize.Width += widthAllCol;
            formSize.Width += this.Padding.Right;

            formSize.Height = this.Size.Height;

            this.SetClientSizeCore(formSize.Width, this.Size.Height);
        }

        private void buttonRefreshMonmusuList_Click(object sender, EventArgs e)
        {
            UpdateMonmusuList();
        }
        #endregion

    }
}
