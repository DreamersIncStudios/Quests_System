using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DreamersInc.Quests.Editor
{
    public class QuestManagerC
    {
        private static QuestManager Manager = Quests.QuestManager.Instance;
        public static List<Quest> ActiveQuests => Manager.ActiveQuests;
        public static List<Mission> ActiveMissions => Manager.ActiveMissions;
        public static IBounty[] Bounties => Manager.Bounties;
        public static List<uint> ScenesLoaded => Manager.ScenesLoaded;
        public static void CompleteActiveMission(uint missionID)
        {
            Manager.CompleteActiveMission(missionID);

        }
    }
}
