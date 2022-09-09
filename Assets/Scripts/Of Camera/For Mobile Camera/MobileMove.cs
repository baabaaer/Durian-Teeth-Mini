using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMove : MonoBehaviour
{
    public PlayerFingerInput fingerInput;

    // References
    [Space(20)]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform graphics;
    [Space(20)]

    // Player settings
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveInputDeadZone;

    // Player movement
    private Vector2 moveTouchStartPosition;
    private Vector2 moveInput;

    private bool isMoving;

    private void Awake()
    {
        if (fingerInput == null)
        {
            fingerInput = GetComponent<PlayerFingerInput>();
        }
        fingerInput.playerMoveCallback += MovingAround;
    }
    // Start is called before the first frame update
    void Start()
    {
        // calculate the movement input dead zone
        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private Touch MovingAround(Touch touching)
    {
        switch (touching.phase)
        {
            case TouchPhase.Began:

                // Set the start position for the movement control finger
                moveTouchStartPosition = touching.position;


                break;
            case TouchPhase.Ended:
                moveInput = Vector2.zero;
                break;
            case TouchPhase.Canceled:

                isMoving = false;



                break;
            case TouchPhase.Moved:

                // calculating the position delta from the start position
                moveInput = touching.position - moveTouchStartPosition;


                break;
            case TouchPhase.Stationary:
                break;


        }

        return touching;
    }

    private void Move()
    {

        // Don't move if the touch delta is shorter than the designated dead zone
        if (moveInput.sqrMagnitude <= moveInputDeadZone)
        {
            isMoving = false;
            return;
        }

        if (!isMoving)
        {
            graphics.localRotation = Quaternion.Euler(0, 0, 0);
            isMoving = true;
        }
        // Multiply the normalized direction by the speed
        Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;
        // Move relatively to the local transform's direction
        characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
    }
}