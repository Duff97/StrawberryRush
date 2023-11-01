using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : NoteEffect
{
    [SerializeField] private float jumpVelocity = 10;

    public static event Action OnActivated;

    private ConstantForce gravity;

    protected override void Start()
    {
        base.Start();
        gravity = targetBody.GetComponent<ConstantForce>();
    }

    public override void Activate()
    {
        targetBody.velocity = new Vector3(targetBody.velocity.x, jumpVelocity);
        gravity.enabled = true;
        OnActivated?.Invoke();
    }
}
