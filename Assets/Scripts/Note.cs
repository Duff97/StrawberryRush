using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //Declaring FMOD variable.
    //private FMOD.Studio.EventInstance melody;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        /* 
         * Saving code for future reference.
         * Setting FMOD variable to an FMOD event. Will start and immediately release the event.
            melody = FMODUnity.RuntimeManager.CreateInstance("event:/Notes/Note Collect");
            melody.start();
            melody.release();
        */
        
        gameObject.SetActive(false);
    }

    private void HandleGameStart()
    {
        gameObject.SetActive(true);
    }
}
