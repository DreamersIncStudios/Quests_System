using System;
using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests;
using DreamersInc.Quests.Editor;
using UnityEngine;

public class Kiosk : MonoBehaviour,IMissionInteractable
{
    [SerializeField] private GameObject interactUI;
    public List<uint> KioskMissionsActive { get; private set; }
    public List<Mission> TrialsMissions { get; private set; }

    public List<IBounty> Bounties { get;private set; }

    public List<Mission> SideQuest { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Load();
        EnableMissionInteraction();
    }

    private void Load()
    {
        TrialsMissions = new List<Mission>();
        SideQuest = new List<Mission>();
        Bounties = new List<IBounty>();
    }

    private void Save()
    {
    }

    public void UnlockTrial(uint ID)
    {
        TrialsMissions.Add(MissionDatabase.GetMission(ID));
    }

    public void UnlockTrial(List<uint> IDs)
    {
        foreach(var id in IDs)
            UnlockTrial(id);
    }

    public void UnlockBounty(uint id)
    {
        
    }

    public void UnlockMission(uint ID)
    {
        SideQuest.Add(MissionDatabase.GetMission(ID));
        
    }
    public void UnlockMission(List<uint> IDs)
    {
        foreach(var id in IDs)
            UnlockMission(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject interact;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact = Instantiate(interactUI);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(interact);
                
        }
    }

    private bool menuOpen;
    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!Input.GetKeyUp(KeyCode.Y)) return;
        if (!menuOpen)
        {
            Destroy(interact);
            menuOpen = true;
        }
        else
        {
            interact = Instantiate(interactUI);
            menuOpen = false;
        }
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

    public void LockTrial(uint unlockID)
    {
        throw new NotImplementedException();
    }

    public void LockMission(uint unlockID)
    {
        throw new NotImplementedException();
    }

    public void LockBounty(uint unlockID)
    {
        throw new NotImplementedException();
    }
}
