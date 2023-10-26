using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private GroundDetector groundDetector;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3 (velocity, rb.velocity.y);

        if (!groundDetector.isGrounded() || !Input.GetKey(jumpKey)) return;

        Jump();

    }

    private void Jump()
    {
        rb.velocity = new Vector3(velocity, jumpVelocity);
    }

}
