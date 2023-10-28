using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void PlayFootstep()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Footsteps");
    }
}
