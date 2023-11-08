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
        float xOffset = transform.position.x - targetBody.transform.position.x;

        Vector3 adjustedDestination = new Vector3(destination.position.x - xOffset, destination.position.y);

        Vector3 distance = adjustedDestination - targetBody.transform.position;
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
