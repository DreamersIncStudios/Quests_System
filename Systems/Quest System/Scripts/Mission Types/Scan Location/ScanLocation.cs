using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DreamersInc.Quests
{
    [CreateAssetMenu]
    public class ScanLocation : ScriptableObject,IMission
    {
        public string Name => nameMission;
        [SerializeField] private string nameMission;
        public uint ID => id;
        public uint SceneID => sceneID;
        [SerializeField] private uint id;
        public string Description => desc;
        [TextArea(4,10)]
        [SerializeField] private string desc;

        public string Lore => lore;
        [SerializeField][TextArea(4,10)]
        private string lore;
        public bool PartOfQuest => partOfQuest;
        [SerializeField] private bool partOfQuest;
        [ShowIf("PartOfQuest")] [SerializeField]private uint questID;
        public uint QuestID => questID;
        [SerializeField]private uint rewardExp;
        [SerializeField]private uint rewardGold;
        [SerializeField]private List<Object> rewardItems;
        public uint RewardExp => rewardExp;
        public uint RewardGold => rewardGold;
        public List<Object> RewardItem => rewardItems;
        [SerializeField] private Vector3 size;
        [SerializeField] private Vector3 location;
        [SerializeField] private uint sceneID;
        private GameObject go;
        public void ActivateMission()
        {
            QuestManager.ActiveMissions.Add(this);
             go = new GameObject();
            var box = go.AddComponent<BoxCollider>();
            box.size =size;
            go.transform.position = location;
            go.AddComponent<LocationInteract>().Setup(ID);
        }

        public void DeactivateMission()
        {
           Destroy(go);
        }

        public void CompleteMission()
        {
            QuestManager.ActiveMissions.Remove(this);
            Debug.Log($"Get player singleton and Character Inventory and Give player {RewardExp} EXP and {RewardGold}G");

        }
    }
}
