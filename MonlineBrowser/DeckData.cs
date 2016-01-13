using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonlineBrowser
{
    class DeckData
    {
        public Int32 deckId;
        public string deckName;
        public Boolean isOpened;
        public Int32 cardId1;
        public Int32 cardId2;
        public Int32 cardId3;
        public Int32 cardId4;
        public Int32 cardId5;
        public Int32 status;

        public void Parse(FluorineFx.ASObject asObject)
        {
            if (asObject != null)
            {
                AMFUtil.GetInt32Value(asObject, "deckId", out deckId);
                AMFUtil.GetStringValue(asObject, "deckName", out deckName);
                AMFUtil.GetBooleanValue(asObject, "isOpened", out isOpened);
                AMFUtil.GetInt32Value(asObject, "cardId1", out cardId1);
                AMFUtil.GetInt32Value(asObject, "cardId2", out cardId2);
                AMFUtil.GetInt32Value(asObject, "cardId3", out cardId3);
                AMFUtil.GetInt32Value(asObject, "cardId4", out cardId4);
                AMFUtil.GetInt32Value(asObject, "cardId5", out cardId5);
                AMFUtil.GetInt32Value(asObject, "status", out status);
            }
        }
     }
}
