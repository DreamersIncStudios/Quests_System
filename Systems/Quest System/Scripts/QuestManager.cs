using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DreamersInc.Quests
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance;
        public List<Quest> ActiveQuests;
        public List<Quest> CompletedQuest;

        public Quest HighlightedQuest { get; private set; }

        public List<Mission> ActiveMissions;
        public IBounty[] Bounties = new IBounty[16];
   public List<uint> ScenesLoaded { get; private set; }

   private void Awake()
   {
       if (Instance)
           Destroy(this.gameObject);
       else
       {
           Instance = this;
       }

       ScenesLoaded = new List<uint>();
       SceneLoadEventSystem.OnSceneLoad += (object sender, SceneLoadEventSystem.OnSceneLoadEventArgs eventArgs) =>
       {
           if (!ScenesLoaded.Contains(eventArgs.SceneID))
               ScenesLoaded.Add(eventArgs.SceneID);
           foreach (var mission in ActiveMissions.Where(mission => eventArgs.SceneID == mission.SceneID))
           {
               mission.ActivateMission();
           }
       };
       SceneLoadEventSystem.OnSceneUnload += (object sender, SceneLoadEventSystem.OnSceneUnloadEventArgs eventArgs) =>
       {
           if (ScenesLoaded.Contains(eventArgs.SceneID))
               ScenesLoaded.Remove(eventArgs.SceneID);
           foreach (var mission in ActiveMissions.Where(mission => eventArgs.SceneID == mission.SceneID))
           {
               mission.DeactivateMission();
           }
       };
   }

   public  void DisplayQuestMenu()
        {
        }

        public void LoadData()
        {
        }

        public void SaveData()
        {
        }

        public  bool CompleteActiveMission(uint MissionID)
        {
            foreach (var mission in ActiveMissions.Where(mission=> MissionID== mission.SceneID))
            {
                mission.CompleteMission();
                if (!mission.PartOfQuest) return true;
                foreach (var quest in ActiveQuests.Where(quest => mission.QuestID == quest.ID ))
                {
                    quest.CompleteQuestStep();
                }

                return true;
            }

            return false;
        }
    }
}
