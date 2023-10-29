using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Contains every FMOD events, makes it easier to manage when this script gets bigger
    private Dictionary<string, string> FMODEvents = new Dictionary<string, string>
    {
        {"Jump", "event:/SFX/Jump"},
        {"Footstep", "event:/SFX/Footsteps"}
    };

    
    private void Start()
    {
        //Bind functions to game events 
        PlayerMovement.OnPlayerJump += HandlePlayerJump;

    }

    private void HandlePlayerJump()
    {
        //This will be called every time the player jumps!
        FMODUnity.RuntimeManager.PlayOneShot(FMODEvents["Jump"]);

    }

    private void OnDestroy()
    {
        //Unbind functions (not necessary, but could be usefull in case the game grows and has multiple scenes)
        PlayerMovement.OnPlayerJump -= HandlePlayerJump;
    }


}
