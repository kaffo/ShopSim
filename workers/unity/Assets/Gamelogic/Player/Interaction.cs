using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Core;
using Improbable.Unity;
using Improbable.Unity.CodeGeneration;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Player
{
    //[WorkerType(WorkerPlatform.UnityClient)]
    public class Interaction : MonoBehaviour
    {
        [HideInInspector]
        public bool pickup = false;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Debug.Log("Has Click");
                pickup = true;
            } else
            {
                pickup = false;
            }
        }
    }
}