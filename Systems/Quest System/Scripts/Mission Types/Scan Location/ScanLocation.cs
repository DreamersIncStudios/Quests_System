using System.Collections.Generic;
using DreamersInc.Quests.Editor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DreamersInc.Quests
{
    [CreateAssetMenu]
    public class ScanLocation : Mission,IGotoLocation
    {

        public Vector3 Size => size;
        public  Vector3 Location => location;
        [SerializeField] private Vector3 size;
        [SerializeField] private Vector3 location;
        public Color BackgroundUI => backgroundUI;
        [Header("UI Asset")] 
        [SerializeField] private Color backgroundUI;
        
        private GameObject go;
        public override void ActivateMission()
        {
             go = new GameObject();
            var box = go.AddComponent<BoxCollider>();
            box.size =size;
            go.transform.position = location;
            go.AddComponent<LocationInteract>().Setup(ID);
            
        }

        public override void DeactivateMission()
        {
           Destroy(go);
        }

        public override void CompleteMission()
        {
            QuestManagerC.ActiveMissions.Remove(this);
            Debug.Log($"Get player singleton and Character Inventory and Give player {RewardExp} EXP and {RewardGold}G");

        }
    }
}
