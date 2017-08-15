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
    public class PhoneBehaviour : MonoBehaviour
    {
        [Header("Audio Clips")]
        public AudioClip tone;

        [HideInInspector]
        public bool pickedup = false;
        private AudioSource source;

        private void OnEnable()
        {
            source = gameObject.GetComponent<AudioSource>();
            if (source == null)
            {
                Debug.LogError("No Source Found For Phone!");
            }
        }

        private void Update()
        {
            if (pickedup && !source.isPlaying)
            {
                source.clip = tone;
                source.Play();
            } else if (!pickedup && source.isPlaying)
            {
                source.Stop();
            }
        }
    }
}