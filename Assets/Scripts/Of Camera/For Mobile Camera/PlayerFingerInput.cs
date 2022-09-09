using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFingerInput : MonoBehaviour
{
    public static PlayerFingerInput instance;
    
    // Touch detection
    private int leftFingerId, rightFingerId;
    private float halfScreenWidth;

    // For invocations of MobileMove and MobileLookAround

    public Touch t;

    public delegate Touch ForMove(Touch moveId);
    public ForMove playerMoveCallback;

    public delegate Touch ForLook(Touch lookId);
    public ForLook playerLookCallback;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        // id = -1 means the finger is not being tracked
        leftFingerId = -1;
        rightFingerId = -1;

        // only calculate once
        halfScreenWidth = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Handles input
        GetTouchInput();

        for (int i = 0; i < Input.touchCount; i++)
        {
            t = Input.GetTouch(i);
        }


        if (rightFingerId != -1)
        {
            // Ony look around if the right finger is being tracked
            Debug.Log("Rotating");
            playerLookCallback?.Invoke(t);
        }

        if (leftFingerId != -1)
        {
            // Ony move if the left finger is being tracked
            Debug.Log("Moving");
            playerMoveCallback?.Invoke(t);
        }
    }

    
    private void GetTouchInput() // I will separate this for lookaround and move scripts
    {
        
        // Iterate through all the detected touches
        for (int i = 0; i < Input.touchCount; i++)
        {

            t = Input.GetTouch(i);
            
            
            // Check each touch's phase
            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x < halfScreenWidth && leftFingerId == -1)
                    {
                        // Start tracking the left finger if it was not previously being tracked
                        leftFingerId = t.fingerId;
                    }
                    else if (t.position.x > halfScreenWidth && rightFingerId == -1)
                    {
                        // Start tracking the rightfinger if it was not previously being tracked
                        rightFingerId = t.fingerId;
                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                    if (t.fingerId == leftFingerId)
                    {
                        // Stop tracking the left finger
                        leftFingerId = -1;
                        Debug.Log("Stopped tracking left finger");
                    }                    
                    else if (t.fingerId == rightFingerId)
                    {
                        // Stop tracking the right finger
                        rightFingerId = -1;
                        Debug.Log("Stopped tracking right finger");
                    }

                    break;
                case TouchPhase.Moved:
                    
                case TouchPhase.Stationary:
                    // Set the look input to zero if the finger is still
                    
                    break;
            }
            
        }

        
    }
    

    public void ResetInput()
    {
        // id = -1 means the finger is not being tracked
        leftFingerId = -1;
        rightFingerId = -1;
    }

}
