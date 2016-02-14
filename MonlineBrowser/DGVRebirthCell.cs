using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonlineBrowser
{
    class DGVRebirthCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// 表示する限界突破画像の枚数
        /// </summary>
        const Int32 REBIRTH_COUNT = 3;


        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates cellState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // Call the base class method to paint the default cell appearance.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                null, null, errorText, cellStyle,
                advancedBorderStyle, paintParts);


            //境界線の内側に範囲を取得する
            Rectangle borderRect = this.BorderWidths(advancedBorderStyle);
            Rectangle innerRect = new Rectangle(
                cellBounds.Left + borderRect.Left,
                cellBounds.Top + borderRect.Top,
                cellBounds.Width - borderRect.Right,
                cellBounds.Height - borderRect.Bottom);

            Point middleCenter = new Point();
            middleCenter.X = innerRect.X + innerRect.Width / 2;
            middleCenter.Y = innerRect.Y + innerRect.Height / 2;

            Int32 rebirthCount = (value == null) ? 0 : (Int32)value;

            for (Int32 i = 0; i < REBIRTH_COUNT; ++i)
            {
                bool isRebirth = (i < rebirthCount);
                Image img = ResourceUtil.GetPictureRebirth(isRebirth);

                Int32 halfImgWidth = img.Width / 2;
                Int32 halfImgHeight = img.Height / 2;

                Rectangle imgRect = new Rectangle(
                    middleCenter.X + img.Width * i - halfImgWidth * REBIRTH_COUNT,
                    middleCenter.Y - halfImgHeight,
                    img.Width + 0,
                    img.Height + 0);

                graphics.DrawImage(img, imgRect);
            }
        }
    }
}
