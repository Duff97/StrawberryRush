using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private GroundDetector groundDetector;
    [SerializeField] private ConstantForce gravity;

    private Rigidbody rb;
    private bool isInGame = false;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        GameManager.OnGameStarted += HandleGameStarted;
        GameManager.OnGameFinished += HandleGameFinished;
    }

    private void FixedUpdate()
    {

        if (!isInGame) return;

        rb.velocity = new Vector3 (velocity, rb.velocity.y);

        if (!groundDetector.isGrounded() || !Input.GetKey(jumpKey)) return;

        Jump();

    }

    private void Jump()
    {
        rb.velocity = new Vector3(velocity, jumpVelocity);

        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Jump");
    }

    private void HandleGameStarted()
    {
        gravity.enabled = true;
        transform.position = startPosition;
        isInGame = true;
    }

    private void HandleGameFinished()
    {
        gravity.enabled = false;
        rb.velocity = Vector3.zero;
        isInGame = false;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStarted;
        GameManager.OnGameStarted -= HandleGameFinished;
    }
}
