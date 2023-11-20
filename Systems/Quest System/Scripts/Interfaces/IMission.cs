using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    
    public interface IMission
    {
        public string Name { get; }
        public uint ID { get; }
        public uint SceneID { get; }
        public string Description { get; }
        public string Lore { get; }
        
        public uint RewardExp { get; }
        public uint RewardGold { get; }

        public List<Object> RewardItem { get; }

        public void StartMission();
        public void ActivateMission();
        public void DeactivateMission();
        public void CompleteMission();
        

    }
}
