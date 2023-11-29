using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface IMissionInteractable 
    {
        public List<uint> MissionID { get; }

        public void EnableMissionInteraction();
    }
}
