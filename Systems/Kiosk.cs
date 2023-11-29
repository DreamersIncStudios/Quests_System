using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests;
using DreamersInc.Quests.Editor;
using UnityEngine;

public class Kiosk : MonoBehaviour,IMissionInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        EnableMissionInteraction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<uint> MissionID => missionID;

    [SerializeField] private List<uint> missionID;
    public void EnableMissionInteraction()
    {
        foreach (var ID in missionID)
        {

            foreach (var mission in QuestManagerC.ActiveMissions)
            {
                if (mission.ID == ID)
                {
                    Debug.Log("This Kiosk has an event;");
                }
            }
        }
    }
}
