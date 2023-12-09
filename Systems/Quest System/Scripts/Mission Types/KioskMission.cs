using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests;
using DreamersInc.Quests.Editor;
using UnityEngine;

public class KioskMission : Mission,IInteractWithObject
{
    public uint unlockID;
    public UnlockType Type;
    public override void ActivateMission()
    {
        var kiosks = FindObjectsByType<Kiosk>(FindObjectsSortMode.None);
        foreach (var kiosk in kiosks)
        {
            switch (Type)
            {
                case UnlockType.Bounty:
                    kiosk.UnlockBounty(unlockID);
                    break;

                case UnlockType.Mission:
                    kiosk.UnlockMission(unlockID);

                    break;
                case UnlockType.Trial:
                    kiosk.UnlockTrial(unlockID);
                    break;
            }
        }
    }

    public override void DeactivateMission()
    {
        var kiosks = FindObjectsByType<Kiosk>(FindObjectsSortMode.None);
        foreach (var kiosk in kiosks)
        {
            switch (Type)
            {
                case UnlockType.Bounty:
                    kiosk.LockBounty(unlockID);
                    break;

                case UnlockType.Mission:
                    kiosk.LockMission(unlockID);

                    break;
                case UnlockType.Trial:
                    kiosk.LockTrial(unlockID);
                    break;
            }
        }
    }

    public enum UnlockType
    {
        Bounty, Mission, Trial
    }
}
