using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DreamersInc.Quests
{
    public class MissionInfoPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI infoText;
        [SerializeField] private GameObject button;
        [SerializeField] private Transform buttonArea;
        public void DisplayMissionInfo(IMission mission)
        {
            var background = this.GetComponent<Image>();
            background.color = mission.BackgroundUI;
            infoText.text = $"{mission.Name}\n mission.Description";
            var moreInfo = Instantiate(button, buttonArea).GetComponent<Button>();
            moreInfo.onClick.AddListener(() =>
            {
                Debug.Log(mission.Lore);
                Debug.Log("Create popup for lore");

            });
            var cancelMission = Instantiate(button, buttonArea).GetComponent<Button>();
            cancelMission.onClick.AddListener(() =>
            {
               Debug.Log("remove from list");
               Destroy(this.gameObject);
            });
            var targetMission = button.GetComponent<Button>();
            var trackText =targetMission.GetComponentInChildren<TextMeshProUGUI>();
            targetMission.onClick.AddListener(() =>
            {
                mission.Track = !mission.Track;
                trackText.text = mission.Track ? "Stop Tracking" : "Track Mission";

            });

            trackText.text = mission.Track ? "Stop Tracking" : "Track Mission";

        }
        public void DisplayQuestInfo(Quest quest)
        {
            var background = this.GetComponent<Image>();
            background.sprite = quest.BackgroundUI;
            var moreInfo = Instantiate(button, buttonArea).GetComponent<Button>();
            moreInfo.onClick.AddListener(() =>
            {
                Debug.Log(quest.Lore);
                Debug.Log("Create popup for lore");

            });

            var targetMission = button.GetComponent<Button>();
            var trackText =targetMission.GetComponentInChildren<TextMeshProUGUI>();
            targetMission.onClick.AddListener(() =>
            {
                quest.Track = !quest.Track;
                trackText.text = quest.Track ? "Stop Tracking" : "Track Mission";

            });

            trackText.text = quest.Track ? "Stop Tracking" : "Track Mission";

        }
    }
}
