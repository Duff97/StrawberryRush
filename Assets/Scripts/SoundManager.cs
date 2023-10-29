using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string notePrefix = "Note";

    //Contains every FMOD events, makes it easier to manage when this script gets bigger
    private Dictionary<string, string> FMODEvents = new Dictionary<string, string>
    {
        {"Jump", "event:/SFX/Jump"},
        {"Footstep", "event:/SFX/Footsteps"},
        {$"{notePrefix}0", ""}, //Default note sound
        {$"{notePrefix}1", ""},
        {$"{notePrefix}2",  ""},
        {$"{notePrefix}3", ""}
    };

    
    private void Start()
    {
        //Bind functions to game events 
        PlayerMovement.OnPlayerJump += HandlePlayerJump;
        PlayerFootstep.OnFootstep += HandlePlayerFootstep;
        Note.OnNoteCollected += HandleNoteCollected;

    }

    private void HandlePlayerFootstep()
    {
        //This will be called every time a footstep is detected
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Footstep"]);
    }

    private void HandlePlayerJump()
    {
        //This will be called every time the player jumps!
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Jump"]);

    }

    private void HandleNoteCollected(int noteNumber)
    {
        string fmodEvent = FMODEvents.ContainsKey($"{notePrefix}{noteNumber}") ? FMODEvents[$"{notePrefix}{noteNumber}"] : "";

        if (fmodEvent == "")
        {
            Debug.LogWarning("Soundmanager Error: note sound was not found");
            return;
        }

        FMODUnity.RuntimeManager.PlayOneShot(fmodEvent);
    }

    private void OnDestroy()
    {
        //Unbind functions (not necessary, but could be usefull in case the game grows and has multiple scenes)
        PlayerMovement.OnPlayerJump -= HandlePlayerJump;
        PlayerFootstep.OnFootstep -= HandlePlayerFootstep;
        Note.OnNoteCollected -= HandleNoteCollected;
    }


}
