using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface ICollectItem
    {
        public List<CollectItem> ItemsToCollect { get; }
    }
    
    [System.Serializable]
    public struct CollectItem
    {
        public uint ItemID;
        public uint AmountToCollect;

        public uint AmountCollected;

        public bool Complete => AmountToCollect <= AmountCollected;
        //Todo Create Interface with Drop/Spawn Systems;
    }
}
