using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Note G");
        Destroy(gameObject);
    }
}
