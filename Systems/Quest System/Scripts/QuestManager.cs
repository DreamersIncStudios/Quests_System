using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DreamersInc.Quests
{
    public class QuestManager : MonoBehaviour
    {
        private static QuestManager instance;
        public static List<Quest> ActiveQuests;
        public List<Quest> CompletedQuest;

        public Quest HighlightedQuest { get; private set; }

        public static List<IMission> ActiveMissions;   
        public List<IBounty> Bounties;

        private void Awake()
        {
            if(instance)
                Destroy(this.gameObject);
            else
            {
                instance = this;
            }
        }

        private void Start()
        {
            SceneLoadEventSystem.OnSceneLoad += (object sender, SceneLoadEventSystem.OnSceneLoadEventArgs eventArgs) =>
            {
                foreach (var mission in ActiveMissions.Where(mission => eventArgs.Scene== mission.SceneID))
                {
                    mission.ActivateMission();
                }
            };
            SceneLoadEventSystem.OnSceneUnload += (object sender, SceneLoadEventSystem.OnSceneUnloadEventArgs eventArgs) =>
            {
                foreach (var mission in ActiveMissions.Where(mission => eventArgs.Scene== mission.SceneID))
                {
                    mission.DeactivateMission();
                }
            };
        }

        public static void DisplayQuestMenu()
        {
        }

        public void LoadData()
        {
        }

        public void SaveData()
        {
        }
    }
}