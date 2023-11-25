using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DreamersInc.Quests
{
    public class SceneLoadEventSystem : MonoBehaviour
    {
       

        private void Start()
        {
        
        }

        public class OnSceneLoadEventArgs : EventArgs
        {
            public uint SceneID;

            public OnSceneLoadEventArgs()
            {
            }

            public OnSceneLoadEventArgs(uint sceneID)
            {
                SceneID = sceneID;
            }
        }

        public static EventHandler<OnSceneLoadEventArgs> OnSceneLoad;
        public class OnSceneUnloadEventArgs : EventArgs
        {
            public uint SceneID;
            public OnSceneUnloadEventArgs()
            {
            }

            public OnSceneUnloadEventArgs(uint sceneID)
            {
                SceneID = sceneID;
            }
        }

        public static EventHandler<OnSceneUnloadEventArgs> OnSceneUnload;

    }
}
