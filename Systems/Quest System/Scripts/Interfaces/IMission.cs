using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DreamersInc.Quests
{

    public interface IMission
    {
        public string Name { get; }
        public uint ID { get; }
        public Color BackgroundUI { get; }
        public uint SceneID { get; }
        public string Description { get; }
        public string Lore { get; }

        public bool PartOfQuest { get; }
        public uint QuestID { get; }
        public uint RewardExp { get; }
        public uint RewardGold { get; }

        public List<Object> RewardItem { get; }
        public bool Track { get; set; }
        public void ActivateMission();
        public void DeactivateMission();
        public void CompleteMission();

        public bool HasIntroCutscene { get; }
        public bool HasOutroCutscene { get; }
      

    }

    public abstract class Mission : ScriptableObject, IMission
    {
        public string Name => nameMission;
        [SerializeField] private string nameMission;
        public uint ID => id;
        [SerializeField] private uint sceneID;
        public uint SceneID => sceneID;
        [SerializeField] private uint id;
        public string Description => desc;
        [TextArea(4, 10)] [SerializeField] private string desc;

        public string Lore => lore;
        [SerializeField] [TextArea(4, 10)] private string lore;
        public bool PartOfQuest => partOfQuest;
        [SerializeField] private bool partOfQuest;

        [ShowIf("PartOfQuest")] [SerializeField]
        private uint questID;

        public uint QuestID => questID;
        [SerializeField] private uint rewardExp;
        [SerializeField] private uint rewardGold;
        [SerializeField] private List<Object> rewardItems;
        public uint RewardExp => rewardExp;
        public uint RewardGold => rewardGold;
        public List<Object> RewardItem => rewardItems;
        public bool Track { get; set; }
        public bool HasIntroCutscene => hasIntroCutscene;
        public bool HasOutroCutscene => hasOutroCutscene;
        [SerializeField] private bool hasIntroCutscene;
        public Cutscene Intro => intro;
        [ShowIf("hasIntroCutscene")] 
        [SerializeField] Cutscene intro;

        
        [SerializeField] private bool hasOutroCutscene;
        public Cutscene Outro => outro;
        [ShowIf("hasOutroCutscene")]
        [SerializeField] Cutscene outro;
        public abstract void ActivateMission();


        public abstract void DeactivateMission();

        public virtual void CompleteMission()
        {
    
        }

        public Color BackgroundUI => backgroundUI;
        [Header("UI Asset")] [SerializeField] private Color backgroundUI;

        public void SetMissionID(uint count)
        {
            id = count;
        }

    }
}
