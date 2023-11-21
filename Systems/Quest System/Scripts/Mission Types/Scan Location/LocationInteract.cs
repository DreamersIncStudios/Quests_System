using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    [RequireComponent(typeof(BoxCollider))]
    public class LocationInteract : MonoBehaviour
    {
        [SerializeField] private uint missionID;

        public void Setup(uint ID)
        {
            this.missionID = ID;
        }

        private void Awake()
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            // create UI button
            Debug.Log("Create UI interface");
            QuestManager.CompleteActiveMission(missionID);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            // create UI button
            Debug.Log("Destroy UI interface");
        }
    }
}
