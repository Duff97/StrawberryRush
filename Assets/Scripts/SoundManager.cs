using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private const string noteValueTmp = "[noteValue]";

    //Contains every FMOD events, makes it easier to manage when this script gets bigger
    private Dictionary<string, string> FMODEvents = new Dictionary<string, string>
    {
        {"Jump", "event:/SFX/Jump"},
        {"Footstep", "event:/SFX/Footsteps"},
        {"Note", $"event:/Notes/{noteValueTmp} - Note Collect"},
        {"Splat", "event:/SFX/Splat"}
    };

    
    private void Start()
    {
        //Bind functions to game events 
        JumpEffect.OnActivated += HandleJumpEffect;
        PlayerFootstep.OnFootstep += HandlePlayerFootstep;
        Note.OnNoteCollected += HandleNoteCollected;
        FallDetector.OnFallDetected += GameOver;
        FallDetector.OnFallDetected += Splat;
        WallDetector.OnWallDetected += GameOver;
        WallDetector.OnWallDetected += Splat;

    }

    private void HandlePlayerFootstep()
    {
        //This will be called every time a footstep is detected
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Footstep"]);
    }

    private void HandleJumpEffect()
    {
        //This will be called every time the player jumps!
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Jump"]);

    }

    private void HandleNoteCollected(string noteValue)
    {
        string fmodEvent = FMODEvents["Note"].Replace(noteValueTmp, noteValue);
        FMODUnity.RuntimeManager.PlayOneShot(fmodEvent);
        
    }

    private void GameOver()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Game State", 2);

    }

    private void Splat()
    {
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Splat"]);

    }

    private void OnDestroy()
    {
        //Unbind functions (not necessary, but could be usefull in case the game grows and has multiple scenes)
        JumpEffect.OnActivated -= HandleJumpEffect;
        PlayerFootstep.OnFootstep -= HandlePlayerFootstep;
        Note.OnNoteCollected -= HandleNoteCollected;
        FallDetector.OnFallDetected -= GameOver;
        WallDetector.OnWallDetected -= GameOver;
        WallDetector.OnWallDetected -= Splat;
    }


}
