using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public CharacterController characterController;
    public StickOfHappiness stickOfHappiness;

    [Header("Movement")]
    [Range(0.001f,200f)]public float moveSpeed;
    public float drag;
    public float terminalRotationSpeed;
    [Range(0f, 1f)] public float moveInputDeadZone = 0.1f;
    public Transform graphics;

    public bool isMoving;
    [SerializeField] private Vector2 dir = new Vector2(0f, 0f);

    void Update()
    {
        dir.x = stickOfHappiness.Horizontal();
        dir.y = stickOfHappiness.Vertical();

        Move();

    }

    private void Move()
    {
        if (dir.sqrMagnitude <= moveInputDeadZone)
        {
            isMoving = false;
            return;
        }
        if (!isMoving)
        {
            graphics.localRotation = Quaternion.Euler(0, 0, 0);
            isMoving = true;
        }

        // I put move controls on the outer layer of the background, so I have to recalibrate it
        // as if it is in a new circle

        Vector2 movementDirection = dir.normalized * moveSpeed * Time.deltaTime;
        characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
    }


}
