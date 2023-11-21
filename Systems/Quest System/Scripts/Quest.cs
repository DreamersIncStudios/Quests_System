using System.Collections;
using System.Collections.Generic;
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
        public IMission CurrentStep;
        private int currentStepIndex;
        private bool QuestCompleted => currentStepIndex >= Missions.Count;
        public uint RewardExp { get; }
        public uint RewardGold { get; }        
       [SerializeReference] public List<IMission> Missions;

        public void AcceptQuest()
        {
            QuestManager.ActiveQuests.Add(Instantiate(this));
            if (Missions.Count > 1)
                CurrentStep = Missions[0];
        }

        public bool IsCancelable => isCancelable;
        [SerializeField] private bool isCancelable = false;
        public void CancelQuest()
        {
            if (isCancelable)
            {
                QuestManager.ActiveQuests.Remove(this);
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
    }
}
