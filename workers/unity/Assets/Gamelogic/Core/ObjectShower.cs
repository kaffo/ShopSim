using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Core
{
    [WorkerType(WorkerPlatform.UnityClient)]
    public class ObjectShower : MonoBehaviour
    {
        [Require]
        private Position.Writer PositionWriter;

        public GameObject[] listToEnable;

        private void OnEnable()
        {
            if (listToEnable.Length > 0)
            {
                foreach (var go in listToEnable)
                {
                    go.SetActive(true);
                }
            }
        }
    }
}