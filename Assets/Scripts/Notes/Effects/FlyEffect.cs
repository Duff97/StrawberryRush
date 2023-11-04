using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEffect : NoteEffect
{
    [SerializeField] private Transform destination;

    public static event Action OnActivated;
    public static event Action OnDeactivated;

    public override void Activate()
    {
        float xVelocity = targetBody.velocity.x;

        Vector3 distance = destination.position - targetBody.transform.position;
        float yVelocity = xVelocity * (distance.y / distance.x);
        targetBody.velocity = new Vector3(xVelocity, yVelocity, 0);

        float timeOfArrival = distance.x / xVelocity;

        OnActivated?.Invoke();
        Invoke(nameof(Deactivate), timeOfArrival);
    }

    private void Deactivate()
    {
        OnDeactivated?.Invoke();
    }
}
