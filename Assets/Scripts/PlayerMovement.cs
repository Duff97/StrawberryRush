using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpImpulse;
    [SerializeField] private KeyCode jumpKey;

    private Rigidbody rb;
    private bool jumpActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GroundDetector.OnGroundEntered += HandleGroundEntered;
        GroundDetector.OnGroundExited += HandleGroundExited;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3 (velocity, rb.velocity.y);

        if (!jumpActive || !Input.GetKey(jumpKey)) return;

        Jump();

    }

    private void Jump()
    {
        jumpActive = false;
        Vector3 force = new Vector3(0, jumpImpulse);
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void HandleGroundEntered()
    {
        jumpActive = true;
    }

    private void HandleGroundExited()
    {
        jumpActive = false;
    }


    private void OnDestroy()
    {
        GroundDetector.OnGroundEntered -= HandleGroundEntered;
        GroundDetector.OnGroundExited -= HandleGroundExited;
    }

}
