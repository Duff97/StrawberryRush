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
        {$"{notePrefix}0", "event:/Notes/A4 - Note Collect"}, //Default note sound
        {$"{notePrefix}1", "event:/Notes/A5 - Note Collect"},
        {$"{notePrefix}2",  "event:/Notes/Ab4 - Note Collect"},
        {$"{notePrefix}3", "event:/Notes/Ab5 - Note Collect"},
        {$"{notePrefix}4", "event:/Notes/B4 - Note Collect"},
        {$"{notePrefix}5", "event:/Notes/B5 - Note Collect"},
        {$"{notePrefix}6", "event:/Notes/Bb4 - Note Collect"},
        {$"{notePrefix}7", "event:/Notes/Bb5 - Note Collect"},
        {$"{notePrefix}8", "event:/Notes/C4 - Note Collect"},
        {$"{notePrefix}9", "event:/Notes/C5 - Note Collect"},
        {$"{notePrefix}10", "event:/Notes/C6 - Note Collect"},
        {$"{notePrefix}11", "event:/Notes/D5 - Note Collect"},
        {$"{notePrefix}12", "event:/Notes/Eb4 - Note Collect"},
        {$"{notePrefix}13", "event:/Notes/Eb5 - Note Collect"},
        {$"{notePrefix}14", "event:/Notes/F5 - Note Collect"},
        {$"{notePrefix}15", "event:/Notes/G4 - Note Collect"},
        {$"{notePrefix}16", "event:/Notes/Gb4 - Note Collect"},
        {$"{notePrefix}17", "event:/Notes/Gb5 - Note Collect"}
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
