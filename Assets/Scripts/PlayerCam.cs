using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    [SerializeField] private Transform follow;
    [SerializeField] private float yOffset;

    private void Update()
    {
        transform.position = new Vector3(follow.position.x, follow.position.y + yOffset, transform.position.z);
    }
}
