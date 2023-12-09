using System;
using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests.Editor;
using UnityEngine;

namespace DreamersInc.Quests
{
    [RequireComponent(typeof(BoxCollider))]
    public class LocationInteract : MonoBehaviour
    {
        [SerializeField] private uint missionID;
        private InteractionType type;
        public void Setup(uint ID, InteractionType interaction)
        {
            this.missionID = ID;
            type = interaction;
        }

        private void Awake()
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            switch (type)
            {
                case InteractionType.CompleteOnInteract:
                    // create UI button
                    Debug.Log("Create UI interface");
                    QuestManagerC.CompleteActiveMission(missionID);
                    Destroy(this.gameObject);
                    break;
                case InteractionType.CompleteOnEnter:
                    // create UI button
                    Debug.Log("Create UI interface");
                    QuestManagerC.CompleteActiveMission(missionID);
                    Destroy(this.gameObject);
                    break;

                case InteractionType.CompleteAfterTime:
                    break;
                case InteractionType.CompleteWhenNoEnemyPresent:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            // create UI button
            Debug.Log("Destroy UI interface");
        }
    }

    public enum InteractionType
    {
        CompleteOnEnter, CompleteOnInteract, CompleteAfterTime, CompleteWhenNoEnemyPresent
    }
}
