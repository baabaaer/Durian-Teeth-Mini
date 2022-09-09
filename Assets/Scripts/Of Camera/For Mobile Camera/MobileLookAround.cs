using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLookAround : MonoBehaviour
{
    public PlayerFingerInput fingerInput;

    public enum PlayerControlMode { FirstPerson, ThirdPerson }
    public PlayerControlMode mode;

    [Header("Settings")]

    [Header("First person camera")]
    [SerializeField] private Transform fpCameraTransform;
    [Header("Third person camera")]
    [SerializeField] private Transform cameraPole;
    [SerializeField] private Transform tpCameraTransform;
    [SerializeField] private Transform graphics;
    [Space (20)]
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float lookInputDeadZone;

    [Header("Third person camera settings")]
    [SerializeField] private LayerMask cameraObstacleLayers;
    private float maxCameraDistance;
    private bool isLooking;

    // Camera control
    private Vector2 lookInput;
    private float cameraPitch;
    
    private void Awake()
    {
        if(fingerInput == null)
        {
            fingerInput = GetComponent<PlayerFingerInput>();
        }
        fingerInput.playerLookCallback += LookingAround;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (mode == PlayerControlMode.ThirdPerson)
        {

            // Get the initial angle for the camera pole
            cameraPitch = cameraPole.localRotation.eulerAngles.x;

            // Set max camera distance to the distance the camera is from the player in the editor
            maxCameraDistance = tpCameraTransform.localPosition.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }

    private void FixedUpdate()
    {
        if (mode == PlayerControlMode.ThirdPerson) MoveCamera();
    }

    public Touch LookingAround(Touch touching)
    {
        switch (touching.phase)
        {
            case TouchPhase.Began:

                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                isLooking = false;
                break;
            case TouchPhase.Moved:

                // Get input for looking around
                
                    lookInput = touching.deltaPosition * cameraSensitivity * Time.deltaTime;
                
               
                break;
            case TouchPhase.Stationary:
                // Set the look input to zero if the finger is still
                
                    lookInput = Vector2.zero;
                
                break;
        }
        return touching;
    }

    private void LookAround()
    {

        switch (mode)
        {
            case PlayerControlMode.FirstPerson:
                // vertical (pitch) rotation is applied to the first person camera
                cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
                fpCameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
                break;
            case PlayerControlMode.ThirdPerson:
                // vertical (pitch) rotation is applied to the third person camera pole
                cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
                cameraPole.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
                break;
        }

        if (mode == PlayerControlMode.ThirdPerson && !isLooking)
        {
            // Rotate the graphics in the opposite direction when stationary
            graphics.Rotate(graphics.up, -lookInput.x);
        }
        // horizontal (yaw) rotation
        transform.Rotate(transform.up, lookInput.x);
    }

    private void MoveCamera()
    {
        // Don't move if the touch delta is shorter than the designated dead zone
        if (lookInput.sqrMagnitude <= lookInputDeadZone)
        {
            isLooking = false;
            return;
        }

        if (!isLooking)
        {
            graphics.localRotation = Quaternion.Euler(0, 0, 0);
            isLooking = true;
        }

        Vector3 rayDir = tpCameraTransform.position - cameraPole.position;

        Debug.DrawRay(cameraPole.position, rayDir, Color.red);
        // Check if the camera would be colliding with any obstacle
        if (Physics.Raycast(cameraPole.position, rayDir, out RaycastHit hit, Mathf.Abs(maxCameraDistance), cameraObstacleLayers))
        {
            // Move the camera to the impact point
            tpCameraTransform.position = hit.point;
        }
        else
        {
            // Move the camera to the max distance on the local z axis
            tpCameraTransform.localPosition = new Vector3(0, 0, maxCameraDistance);
        }
    }
}
