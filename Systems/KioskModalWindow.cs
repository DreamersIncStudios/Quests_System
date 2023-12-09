using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KioskModalWindow : MonoBehaviour
{
    Kiosk kioskOpened;
    
    [SerializeField] private Transform sidebar;
    [SerializeField] private Transform contentArea;
    [SerializeField] private GameObject sidebarButton;
    public void OpenKioskUI(Kiosk kioskAccessed)
    {
        kioskOpened = kioskAccessed;
        var trials = Instantiate(sidebarButton, sidebar).GetComponent<Button>();
        trials.onClick.AddListener(DisplayTrials);
        trials.GetComponentInChildren<TextMeshProUGUI>().text = "Accept";

        var storage = Instantiate(sidebarButton, sidebar).GetComponent<Button>();
        storage.onClick.AddListener(DisplayStorage);
        storage.GetComponentInChildren<TextMeshProUGUI>().text = "Accept";
        
        var info = Instantiate(sidebarButton, sidebar).GetComponent<Button>();
        info.GetComponentInChildren<TextMeshProUGUI>().text = "Accept";
        info.onClick.AddListener(DisplayInfo);
        
        var mission = Instantiate(sidebarButton, sidebar).GetComponent<Button>();
        mission.GetComponentInChildren<TextMeshProUGUI>().text = "Accept";
        mission.onClick.AddListener(DisplayMissions);
        
    }

    void DisplayTrials()
    {
        foreach (var trial in kioskOpened.TrialsMissions)
        {
            var button = Instantiate(sidebarButton, contentArea).GetComponent<Button>();
            button.GetComponentInChildren<TextMeshProUGUI>().text = trial.Name;
            button.onClick.AddListener(trial.ActivateMission);
        }
    }

    void DisplayStorage()
    {
    }

    void DisplayInfo()
    {
    }

    void DisplayMissions()
    {
    }
}
