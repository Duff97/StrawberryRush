using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundManager : MonoBehaviour
{

    FMOD.Studio.Bus Master;
    
    private const string noteValueTmp = "[noteValue]";

    //Contains every FMOD events, makes it easier to manage when this script gets bigger
    private Dictionary<string, string> FMODEvents = new Dictionary<string, string>
    {
        {"Jump", "event:/SFX/Jump"},
        {"Footstep", "event:/SFX/Footsteps"},
        {"Note", $"event:/Notes/{noteValueTmp} - Note Collect"},
        {"Splat", "event:/SFX/Splat"},
        {"Wrong Note", "event:/Notes/Wrong Note"},
        {"Fly", "event:/SFX/Fly"}
    };

    private void Start()
    {
        //Bind functions to game events 
        JumpEffect.OnActivated += HandleJumpEffect;
        PlayerFootstep.OnFootstep += HandlePlayerFootstep;
        Note.OnNoteCollected += HandleNoteCollected;
        PlayerDeath.OnPlayerDeath += GameOver;
        GameManager.OnGameStarted += StartGame;
        Note.OnNoteMissed += BadInput;
        FlyEffect.OnActivated += Fly;

        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
        Master.setVolume(1f);

    }

    public void StartGame()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Game State", 1);
    }

    public void MasterVolumeLevel(float newMasterVolume)
    {
        Master.setVolume(newMasterVolume);
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
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Splat"]);
    }

    private void BadInput()
    {
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Wrong Note"]);
    }

    private void Fly()
    {
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Fly"]);
    }

        private void OnDestroy()
    {
        //Unbind functions (not necessary, but could be usefull in case the game grows and has multiple scenes)
        JumpEffect.OnActivated -= HandleJumpEffect;
        PlayerFootstep.OnFootstep -= HandlePlayerFootstep;
        Note.OnNoteCollected -= HandleNoteCollected;
        PlayerDeath.OnPlayerDeath -= GameOver;
        GameManager.OnGameStarted -= StartGame;
        Note.OnNoteMissed -= BadInput;
        FlyEffect.OnActivated -= Fly;
    }


}
