using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NoteEffect : MonoBehaviour
{
    protected Rigidbody targetBody;

    protected virtual void Start()
    {
        targetBody = FindAnyObjectByType<PlayerMovement>().GetComponent<Rigidbody>();
    }
    public abstract void Activate();
}
