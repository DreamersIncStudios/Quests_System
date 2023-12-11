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
        public static Bounty[] Bounties => Manager.Bounties;
        public static List<Bounty> MissionBounties => Manager.MissionQuestBounties;
        public static List<uint> ScenesLoaded => Manager.ScenesLoaded;
        public static bool CompleteActiveMission(uint missionID)
        {
            return Manager.CompleteActiveMission(missionID);

        }

        public static bool CompleteActiveBounty(uint bountyID)
        {
          return  Manager.CompleteActiveBounty(bountyID);
        }
    }
}
