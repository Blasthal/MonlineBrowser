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
        /// モン娘リストのヘッダーの種類
        /// </summary>
        enum ColumnHeaderMonList
        {
            ID,
            Level,
            Rebirth,
            Name,
            Kana,
            Race,
            Element,
            HP,
            Tension,
            Satiety,
            Food,

            Count,
        };

        /// <summary>
        /// 情報を代入するためのヘッダー名を用意する
        /// GridViewと揃える
        /// </summary>
        readonly string[] COLUMN_HEADER_NAMES = new string[(int)ColumnHeaderMonList.Count]
        {
            "ColumnMonID",
            "ColumnMonLevel",
            "ColumnMonRebirth",
            "ColumnMonName",
            "ColumnMonKana",
            "ColumnMonRace",
            "ColumnMonElement",
            "ColumnMonHP",
            "ColumnMonTension",
            "ColumnMonSatiety",
            "ColumnMonFood",
        };


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

#if DEBUG
            for (Int32 i = 0; i < 10; ++i)
            {
                dataGridViewMonmusuList.Rows.Add();
            }
#endif
        }

        #region モン娘リスト
        /// <summary>
        /// モン娘のリストを更新する
        /// </summary>
        private void UpdateMonmusuList()
        {
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
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = (i + 1).ToString();
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuLevel(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuRebirthCount(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuName(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuKana(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetRaceName(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuElementPicture(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuHP(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuTension(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuSatietyText(data.cardId);
                dataGridViewMonmusuList[COLUMN_HEADER_NAMES[colIndex++], rowIndex].Value = UserDataUtil.GetMonmusuLikeFoodPicture(data.cardId);
            }

            // ビューの横幅を調整する
            Int32 widthAllCol = 0;
            for (Int32 i = 0; i < dataGridViewMonmusuList.Columns.Count; ++i)
            {
                DataGridViewColumn col = dataGridViewMonmusuList.Columns[i];
                if (col != null && col.Visible)
                {
                    widthAllCol += col.HeaderCell.Size.Width;
                }
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

        #region ソート
        private void dataGridViewMonmusuList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // 名前の場合
            if (e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Name])
            {
                // 仮名でソートする
                DataGridView view = (DataGridView)sender;
                Int32 conRet = GetSortResultViewString(view, (Int32)ColumnHeaderMonList.Kana, e.RowIndex1, e.RowIndex2);
                e.SortResult = conRet;

                e.Handled = true;

                return;
            }
            // 種族の場合
            else if (e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Race])
            {
                DataGridView view = (DataGridView)sender;
                Int32 conRet = GetSortResultViewString(view, (Int32)ColumnHeaderMonList.Race, e.RowIndex1, e.RowIndex2);
                e.SortResult = conRet;

                e.Handled = true;
            }
            // 数値関連の場合
            else if (e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.ID] ||
                e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Level] ||
                e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.HP] ||
                e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Tension] ||
                e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Satiety]
                )
            {
                //指定されたセルの値を文字列として取得する
                string str1 = (e.CellValue1 == null ? "" : e.CellValue1.ToString());
                string str2 = (e.CellValue2 == null ? "" : e.CellValue2.ToString());

                Int32 int1 = 0;
                Int32 int2 = 0;
                if (e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Satiety])
                {
                    // 満腹度は現在値と最大値が表示されているので、現在値だけで判定する
                    Int32 idx1 = str1.IndexOf('/');
                    Int32 idx2 = str2.IndexOf('/');
                    if (idx1 < 0) idx1 = 0;
                    if (idx2 < 0) idx2 = 0;
                    Int32.TryParse(str1.Substring(0, idx1), out int1);
                    Int32.TryParse(str2.Substring(0, idx2), out int2);
                }
                else
                {
                    Int32.TryParse(str1, out int1);
                    Int32.TryParse(str2, out int2);
                }

                e.SortResult = int1 - int2;

                //処理したことを知らせる
                e.Handled = true;
            }
            // 画像関連の場合
            else if (e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Element] ||
                e.Column.Name == COLUMN_HEADER_NAMES[(int)ColumnHeaderMonList.Food]
                )
            {
                Bitmap img1 = (Bitmap)e.CellValue1;
                Bitmap img2 = (Bitmap)e.CellValue2;
                Int32 tag1 = 0;
                Int32 tag2 = 0;
                if (img1 != null)
                {
                    tag1 = (img1.Tag == null ? 0 : (Int32)img1.Tag);
                }
                if (img2 != null)
                {
                    tag2 = (img2.Tag == null ? 0 : (Int32)img2.Tag);
                }

                e.SortResult = tag1 - tag2;

                e.Handled = true;
            }

            // ソート結果が不動なら仮名を考慮する
            if (e.SortResult == 0 && e.Handled)
            {
                DataGridView view = (DataGridView)sender;
                e.SortResult = GetSortResultViewString(view, (Int32)ColumnHeaderMonList.Kana, e.RowIndex1, e.RowIndex2);
            }
        }

        private Int32 GetSortResultString(String str1, String str2)
        {
            str1 = (str1 == null) ? string.Empty : str1;
            str2 = (str1 == null) ? string.Empty : str2;

            Int32 comRet = str1.CompareTo(str2);
            return comRet;
        }

        private Int32 GetSortResultViewString(DataGridView view, Int32 columnIndex, Int32 rowIndex1, Int32 rowIndex2)
        {
            if (view != null)
            {
                DataGridViewRow row1 = view.Rows[rowIndex1];
                DataGridViewRow row2 = view.Rows[rowIndex2];
                String str1 = (string)row1.Cells[columnIndex].Value;
                String str2 = (string)row2.Cells[columnIndex].Value;
                Int32 comRet = GetSortResultString(str1, str2);
                return comRet;
            }

            return 0;
        }
        #endregion

        #endregion

    }
}
