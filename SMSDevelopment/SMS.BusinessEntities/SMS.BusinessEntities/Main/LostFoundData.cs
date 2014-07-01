using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.BusinessEntities.Main

{
    [Serializable]
    public class LostFoundData
    {

        private List<LostFoundItem> _LostId = null;

        public List<LostFoundItem> LostId
        {
            get { return _LostId; }
            set { _LostId = value; }
        }
    }
}