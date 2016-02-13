using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    /// <summary>
    /// リソースに関する機能を提供するクラス
    /// </summary>
    static class ResourceUtil
    {
        #region 列挙体
        /// <summary>
        /// 食べ物の種類
        /// </summary>
        public enum FoodType
        {
            /// <summary>
            /// 野菜
            /// </summary>
            Vegetable = 20001,

            /// <summary>
            /// 肉
            /// </summary>
            Meat,

            /// <summary>
            /// パン
            /// </summary>
            Bread,
        }

        /// <summary>
        /// 属性の種類
        /// 実際に取得できる値に対応させる
        /// </summary>
        public enum ElementType
        {
            /// <summary>
            /// キュート
            /// </summary>
            Cute = 1,

            /// <summary>
            /// クール
            /// </summary>
            Cool,

            /// <summary>
            /// パッション
            /// </summary>
            Passion,

            /// <summary>
            /// ピュア
            /// </summary>
            Pure,

            /// <summary>
            /// ダーク
            /// </summary>
            Devil,
        }
        #endregion

        #region Method

        #region 食事の種類
        /// <summary>
        /// 食べ物の種類に対応した画像を取得する
        /// </summary>
        /// <param name="foodType">食べ物の種類</param>
        /// <returns>食べ物の画像</returns>
        public static Bitmap GetPictureFoodType(FoodType foodType)
        {
            Bitmap img = null;

            switch (foodType)
            {
                case FoodType.Vegetable:
                    img = Properties.Resources.FoodType_1;
                    img.Tag = (Int32)FoodType.Vegetable;
                    break;

                case FoodType.Meat:
                    img = Properties.Resources.FoodType_2;
                    img.Tag = (Int32)FoodType.Meat;
                    break;

                case FoodType.Bread:
                    img = Properties.Resources.FoodType_3;
                    img.Tag = (Int32)FoodType.Bread;
                    break;

                default:
                    break;
            }

            return img;
        }
        #endregion

        #region アイテム
        /// <summary>
        /// itemMstIdに対応した画像を取得する
        /// </summary>
        /// <param name="itemMstId">マスターID</param>
        /// <returns>アイテムの画像</returns>
        public static Bitmap GetPictureItem(Int32 itemMstId)
        {
            Bitmap bitmap = null;
            switch (itemMstId)
            {
                    // TODO:各種ケース

                default:
                    break;
            }

            return bitmap;
        }
        #endregion

        #region 限界突破
        /// <summary>
        /// 限界突破しているかどうかの表示画像を取得する
        /// </summary>
        /// <param name="isRebirth">限界突破しているかどうか</param>
        /// <returns>対応した画像</returns>
        public static Bitmap GetPictureRebirth(bool isRebirth)
        {
            if (isRebirth)
            {
                return Properties.Resources.RebirthOn;
            }
            else
            {
                return Properties.Resources.RebirthOff;
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 属性の種類に対応した画像を取得する
        /// </summary>
        /// <param name="elementType">属性の種類</param>
        /// <returns>対応した画像</returns>
        public static Bitmap GetPictureElement(ElementType elementType)
        {
            Bitmap img = null;
            switch (elementType)
            {
                case ElementType.Cute:
                    img = Properties.Resources.Element_Cute;
                    img.Tag = (Int32)ElementType.Cute;
                    break;

                case ElementType.Cool:
                    img = Properties.Resources.Element_Cool;
                    img.Tag = (Int32)ElementType.Cool;
                    break;

                case ElementType.Passion:
                    img = Properties.Resources.Element_Passion;
                    img.Tag = (Int32)ElementType.Passion;
                    break;

                case ElementType.Pure:
                    img = Properties.Resources.Element_Pure;
                    img.Tag = (Int32)ElementType.Pure;
                    break;

                case ElementType.Devil:
                    img = Properties.Resources.Element_Devil;
                    img.Tag = (Int32)ElementType.Devil;
                    break;

                default:
                    break;
            }

            return img;
        }
        #endregion

        #endregion
    }
}
