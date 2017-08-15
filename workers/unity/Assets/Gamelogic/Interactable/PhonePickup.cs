using Assets.Gamelogic.Utils;
using Assets.Gamelogic.Player;
using Improbable;
using Improbable.Core;
using Improbable.Unity;
using Improbable.Unity.CodeGeneration;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Interactable
{
    //[WorkerType(WorkerPlatform.UnityClient)]
    public class PhonePickup : MonoBehaviour
    {
        public Transform reciever;
        private PhoneBehaviour recieverBehaviour;
        private Interaction playerInteration = null;

        private float waittime = 0.1f;
        private float timepassed = 0.1f;

        private void OnEnable()
        {
            if (reciever)
            {
                recieverBehaviour = reciever.GetComponent<PhoneBehaviour>();
                if (recieverBehaviour == null)
                {
                    Debug.LogError("Reciever Behavior Not Set!");
                }
            } else
            {
                Debug.LogError("No Reciever Set!");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            GameObject go = other.gameObject;
            //Debug.Log("Entered: " + go.name);
            //GameObject parent = go.transform.parent.gameObject;
            if (go.CompareTag("Player"))
            {
                //Debug.Log("Is Player");
                playerInteration = go.GetComponent<Interaction>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            GameObject go = other.gameObject;
            //Debug.Log("Entered: " + go.name);
            if (playerInteration != null)
            {
                //Debug.Log("Bye Bye Player");
                //playerInteration = null;
            }
        }

        private void Update()
        {
            if (timepassed >= waittime)
            {
                if (playerInteration != null && playerInteration.pickup)
                {
                    //Debug.Log("*** Got Click ***");
                    if (reciever)
                    {
                        //Debug.Log("Has Reciever");
                        OnPlayerClick();
                        timepassed = 0f;
                    }
                }
            }
            else
            {
                timepassed += Time.deltaTime;
            }
        }

        private void OnPlayerClick()
        {
            if (recieverBehaviour.pickedup)
            {
                reciever.parent = transform;
                reciever.localPosition = Vector3.zero;
                reciever.localRotation = UnityEngine.Quaternion.identity;
                recieverBehaviour.pickedup = false;
            } else
            {
                reciever.parent = playerInteration.gameObject.transform;
                reciever.localPosition = new Vector3(0.5f, 0.8f, 0f);
                reciever.localEulerAngles = new Vector3(0f, 0f, -90f);
                recieverBehaviour.pickedup = true;
            }
        }
    }
}