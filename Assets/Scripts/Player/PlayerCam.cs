using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    [SerializeField] private Transform follow;
    
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - follow.position;
    }

    private void Update()
    {
        transform.position = follow.position + offset;
    }
}
