using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests;
using UnityEngine;

public class MultiStageMission : Mission
{
    [SerializeField] private List<Bounty> bounties;
    private uint index;
    public bool missionComplete => index + 1 >= bounties.Count;
    public override void ActivateMission()
    {
       bounties[0].AcceptBounty();
       index = 0;
    }

    public override void DeactivateMission()
    {
        throw new System.NotImplementedException();
    }

    public void CompleteStage()
    { 
        index++;
        if(!missionComplete)
            bounties[(int)index].AcceptBounty();
        else
        {
            CompleteMission();
        }
        
    }
}
