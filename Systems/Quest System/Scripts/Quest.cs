using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests.Editor;
using UnityEngine;

namespace DreamersInc.Quests
{
    [CreateAssetMenu]
    public class Quest : ScriptableObject
    {
        public string Name;
        public uint ID => id;
        [SerializeField] private uint id;
        public string Description => description;
        [SerializeField]string description;
        public string Lore { get; private set; }
        public Mission CurrentStep;
        private int currentStepIndex;
        private bool QuestCompleted => currentStepIndex >= Missions.Count;
        public uint RewardExp { get; }
        public uint RewardGold { get; }

        public Sprite BackgroundUI => backgroundUI;
        [Header("UI Asset")] 
        [SerializeField] private Sprite backgroundUI;
        public List<Mission> Missions;
       public bool Track { get; set; }

       public void AcceptQuest()
        {
            QuestManagerC.ActiveQuests.Add(Instantiate(this));
            CurrentStep = Missions[0];
            QuestManagerC.ActiveMissions.Add(CurrentStep);

        }

        public bool IsCancelable => isCancelable;
        [SerializeField] private bool isCancelable = false;
        public void CancelQuest()
        {
            if (isCancelable)
            {
                QuestManagerC.ActiveQuests.Remove(this);
            }
        }

        public void CompleteQuestStep()
        {
            CurrentStep.CompleteMission();
            if (QuestCompleted)
            {
                CompleteQuest();
            }
            else
            {
                currentStepIndex++;
                CurrentStep = Missions[currentStepIndex];
                UpdateLore();
                
            }
        }

        public void CompleteQuest()
        {
            Debug.Log($"Get player singleton and Character Inventory and Give player {RewardExp} EXP and {RewardGold}G");
        }

        void UpdateLore()
        {
            Lore += CurrentStep.Lore;
        }
        public void SetQuestID(uint count)
        {
            id = count;
        }
    }
}
