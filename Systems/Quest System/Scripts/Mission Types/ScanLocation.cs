using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    public class ScanLocation : ScriptableObject,IMission
    {
        public string Name => NameMission;
        [SerializeField] private string NameMission;
        public uint ID => id;
        [SerializeField] private uint id;
        public string Description => desc;
        [TextArea(4,10)]
        [SerializeField] private string desc;
        public string Lore { get; }
        public uint RewardExp { get; }
        public uint RewardGold { get; }
        public List<Object> RewardItem { get; }
        [SerializeField] private Vector3 Location;
        [SerializeField] private uint SceneID;
        public void StartMission()
        {
            QuestManager.ActiveMissions.Add(this);
        }

        public void CompleteMission()
        {
            QuestManager.ActiveMissions.Remove(this);
            Debug.Log($"Get player singleton and Character Inventory and Give player {RewardExp} EXP and {RewardGold}G");

        }
    }
}
