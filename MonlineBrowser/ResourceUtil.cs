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
            Vegetable = 20001,
            Meat,
            Bread,
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

        #endregion
    }
}
