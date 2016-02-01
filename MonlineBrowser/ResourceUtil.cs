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
            switch (foodType)
            {
                case FoodType.Vegetable:
                    return Properties.Resources.FoodType_1;

                case FoodType.Meat:
                    return Properties.Resources.FoodType_2;

                case FoodType.Bread:
                    return Properties.Resources.FoodType_3;
            }

            return null;
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
            switch (elementType)
            {
                case ElementType.Cute: return Properties.Resources.Element_Cute;
                case ElementType.Cool: return Properties.Resources.Element_Cool;
                case ElementType.Passion: return Properties.Resources.Element_Passion;
                case ElementType.Pure: return Properties.Resources.Element_Pure;
                case ElementType.Devil: return Properties.Resources.Element_Devil;
            }

            return null;
        }
        #endregion

        #endregion
    }
}
