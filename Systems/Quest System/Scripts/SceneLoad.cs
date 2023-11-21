using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    public class SceneLoad : MonoBehaviour
    {
        [SerializeField] private uint sceneID;
        void Start()
        {
            if (SceneLoadEventSystem.OnSceneLoad != null)
                SceneLoadEventSystem.OnSceneLoad(this,
                    new SceneLoadEventSystem.OnSceneLoadEventArgs(sceneID));
        }

        private void OnDestroy()
        {
            if (SceneLoadEventSystem.OnSceneUnload != null)
                SceneLoadEventSystem.OnSceneUnload(this,
                    new SceneLoadEventSystem.OnSceneUnloadEventArgs(sceneID));
        }
    }
}
