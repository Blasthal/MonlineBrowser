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
    public partial class FormMasterViewer : Form
    {
        #region Field
        /// <summary>
        /// インスタンス
        /// </summary>
        public static FormMasterViewer Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (mInstance == null || mInstance.IsDisposed)
                {
                    mInstance = new FormMasterViewer();
                }

                return mInstance;
            }
        }
        private static FormMasterViewer mInstance;

        #endregion

        #region Method
        private FormMasterViewer()
        {
            InitializeComponent();

            UpdateDataAll();
        }

        public void UpdateDataAll()
        {
            UpdateGirlLevelMst();
            UpdateItemMst();
            UpdateCardMst();

            UpdateUserItem();
            UpdateUserDeck();
            UpdateUserRefresh();
        }

        #region Master
        private void UpdateGirlLevelMst()
        {
            // 取得内容を確認する為にTreeViewを構築する
            treeViewGirlLevelMst.Nodes.Clear();
            TreeNode rootNode = treeViewGirlLevelMst.Nodes.Add("girlLevelMst");

            int count = 0;
            foreach (GirlLevelMstData data in DBGirlLevelMst.GirlLevelMstDatas)
            {
                TreeNode dataNode = rootNode.Nodes.Add(count.ToString());

                dataNode.Nodes.Add(data.diffExp.ToString());
                dataNode.Nodes.Add(data.level.ToString());
                dataNode.Nodes.Add(data.maxDear.ToString());
                dataNode.Nodes.Add(data.totalExp.ToString());

                ++count;
            }
        }

        private void UpdateItemMst()
        {
            // 取得内容を確認する為にTreeViewを構築する
            treeViewItemMst.Nodes.Clear();
            TreeNode rootNode = treeViewItemMst.Nodes.Add("itemMst");

            int count = 0;
            foreach (ItemMstData data in DBItemMst.ItemMstDatas)
            {
                TreeNode dataNode = rootNode.Nodes.Add(count.ToString());

                dataNode.Nodes.Add("effect1:" + data.effect1.ToString());
                dataNode.Nodes.Add("effect2:" + data.effect2.ToString());
                dataNode.Nodes.Add("itemMstId:" + data.itemMstId.ToString());
                dataNode.Nodes.Add("name:" + data.name);
                dataNode.Nodes.Add("caption:" + data.caption);
                dataNode.Nodes.Add("type:" + data.type.ToString());

                ++count;
            }
        }

        private void UpdateCardMst()
        {
            treeViewCardMst.Nodes.Clear();
            TreeNode rootNode = treeViewCardMst.Nodes.Add("cardMst");

            int count = 0;
            foreach (CardMstData data in DBCardMst.CardMstDatas)
            {
                TreeNode dataNode = rootNode.Nodes.Add(count.ToString());

                dataNode.Nodes.Add("likeFood:" + data.likeFood.ToString());
                dataNode.Nodes.Add("materialType:" + data.materialType.ToString());
                dataNode.Nodes.Add("hp:" + data.hp.ToString());
                dataNode.Nodes.Add("sellPrice:" + data.sellPrice.ToString());
                dataNode.Nodes.Add("type:" + data.type.ToString());
                dataNode.Nodes.Add("outingFeelFull:" + data.outingFeelFull.ToString());
                dataNode.Nodes.Add("skill2MstId:" + data.skill2MstId.ToString());
                dataNode.Nodes.Add("speed:" + data.speed.ToString());
                dataNode.Nodes.Add("battleFeelFull:" + data.battleFeelFull.ToString());
                dataNode.Nodes.Add("defense:" + data.defense.ToString());
                dataNode.Nodes.Add("attack:" + data.attack.ToString());
                dataNode.Nodes.Add("name:" + data.name.ToString());
                dataNode.Nodes.Add("nickname:" + data.nickname.ToString());
                dataNode.Nodes.Add("feelFullMax:" + data.feelFullMax.ToString());
                dataNode.Nodes.Add("skill1MstId:" + data.skill1MstId.ToString());
                dataNode.Nodes.Add("kana:" + data.kana.ToString());
                dataNode.Nodes.Add("skill3MstId:" + data.skill3MstId.ToString());
                dataNode.Nodes.Add("cardMstId:" + data.cardMstId.ToString());
                dataNode.Nodes.Add("rarityMstId:" + data.rarityMstId.ToString());

                ++count;
            }
        }
        #endregion

        #region User
        private void UpdateUserItem()
        {
            // 取得内容を確認する為にTreeViewを構築する
            treeViewUserItem.Nodes.Clear();
            TreeNode rootNode = treeViewUserItem.Nodes.Add("item");

            int count = 0;
            foreach (ItemData data in UserData.Instance.ItemDatas)
            {
                TreeNode dataNode = rootNode.Nodes.Add(count.ToString());

                dataNode.Nodes.Add("itemMstId:" + data.itemMstId.ToString());
                dataNode.Nodes.Add("itemCount:" + data.itemCount.ToString());

                ++count;
            }
        }

        private void UpdateUserDeck()
        {
            // 取得内容を確認する為にTreeViewを構築する
            treeViewUserDeck.Nodes.Clear();
            TreeNode rootNode = treeViewUserDeck.Nodes.Add("deck");

            int count = 0;
            foreach (DeckData data in UserData.Instance.DeckDatas)
            {
                TreeNode dataNode = rootNode.Nodes.Add(count.ToString());

                dataNode.Nodes.Add("deckId:" + data.deckId.ToString());
                dataNode.Nodes.Add("deckName:" + data.deckName.ToString());
                dataNode.Nodes.Add("isOpened:" + data.isOpened.ToString());
                dataNode.Nodes.Add("cardId1:" + data.cardId1.ToString());
                dataNode.Nodes.Add("cardId2:" + data.cardId2.ToString());
                dataNode.Nodes.Add("cardId3:" + data.cardId3.ToString());
                dataNode.Nodes.Add("cardId4:" + data.cardId4.ToString());
                dataNode.Nodes.Add("cardId5:" + data.cardId5.ToString());
                dataNode.Nodes.Add("status:" + data.status.ToString());

                ++count;
            }
        }

        private void UpdateUserRefresh()
        {
            // 取得内容を確認する為にTreeViewを構築する
            treeViewUserRefresh.Nodes.Clear();
            TreeNode rootNode = treeViewUserRefresh.Nodes.Add("refresh");

            int count = 0;
            foreach (RefreshData data in UserData.Instance.RefreshDatas)
            {
                TreeNode dataNode = rootNode.Nodes.Add(count.ToString());

                dataNode.Nodes.Add("refreshId:" + data.refreshId.ToString());
                dataNode.Nodes.Add("isOpen:" + data.isOpen.ToString());
                dataNode.Nodes.Add("cardId1:" + data.cardId1.ToString());
                dataNode.Nodes.Add("cardId2:" + data.cardId2.ToString());
                dataNode.Nodes.Add("cardId3:" + data.cardId3.ToString());
                dataNode.Nodes.Add("cardId4:" + data.cardId4.ToString());
                dataNode.Nodes.Add("cardId5:" + data.cardId5.ToString());
                dataNode.Nodes.Add("endTime:" + data.endTime.ToString());

                ++count;
            }
        }
        #endregion

        #endregion
    }
}
