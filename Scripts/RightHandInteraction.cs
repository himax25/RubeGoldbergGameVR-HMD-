using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandInteraction : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public Ball ball;
    public PlayZone playZone;
    public GameManager gameManager;
    private SteamVR_Controller.Device device;

    public float throwForce = 1.5f;

    // Swipe
    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;
    public ObjectMenuManager objectMenuManager;

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        gameManager.gameActive = false;
    }

    // Update is called once per frame
    void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index); 
        if ((device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)) && (!gameManager.gameActive))
        {
            touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x; 
        }
        if ((device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) && (!gameManager.gameActive))
        {
            touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            distance = touchCurrent - touchLast;
            touchLast = touchCurrent;
            swipeSum += distance;
            if (!hasSwipedRight)
            {
                 if(swipeSum > 0.5f)
                {
                    swipeSum = 0;
                    SwipeRight();
                    hasSwipedRight = true;
                    hasSwipedLeft = false;
                }
            }
            if (!hasSwipedLeft)
            {
                 if (swipeSum < 0.5f)
                {
                    swipeSum = 0;
                    SwipeLeft();
                    hasSwipedLeft = true;
                    hasSwipedRight = false;
                }           
            }
        }
        //Exit from the menu choice mode
        //if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            ResetPosition();
        } 
        if((device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) && (!gameManager.gameActive))
        {
            //Spawn object currently selected by menu
            SpawnObject();
            ResetPosition();
        } 
        if((device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) && (!device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) && (!gameManager.gameActive))
        {
            //Switch the menu display
            objectMenuManager.TurnOnOffMenu();
        }
           
    }
    void ResetPosition()
    {
            //Initialize Joystic Position for menu chosen 
            swipeSum = 0;
            touchCurrent = 0;
            touchLast = 0;
            hasSwipedLeft = false;
            hasSwipedRight = false;
            objectMenuManager.TurnOnOffMenu();
    }
    void SpawnObject()
    {
        objectMenuManager.SpawnCurrentObject();
    }
    void SwipeLeft()
    {
        objectMenuManager.MenuLeft();
    }
     void SwipeRight()
    {
        objectMenuManager.MenuRight();
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Throwable") || col.gameObject.CompareTag("Trampoline") || col.gameObject.CompareTag("Structure"))
        {
            // Destroy grabbed object        
            if(device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                DestroyObject(col);
            } else 
            {
                 if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ThrowObject(col);
                }
                 else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    GrabObject(col);
                }
            }           
        }
        
    }
    void GrabObject(Collider col)
    {
        if (col.gameObject.CompareTag("Throwable")) 
        {
            if (playZone.rightLocation)
            {
                if (!gameManager.gameActive) 
                {
                    ball.GameOn();
                }
                else  
                {
                    gameManager.gameActive = false;
                }
            } else
            {
                 // The game will be restarted if the player grabs the ball at the out of playzone.
                gameManager.ResetGame();
            }
        }
        col.transform.SetParent(gameObject.transform);
        col.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(2000);
    }
    void ThrowObject(Collider col)
    {
        col.transform.SetParent(null);
        // This,playZone.rightLocation = true, is Anti-cheat code for the game. 
        if (col.gameObject.CompareTag("Trampoline") || (col.gameObject.CompareTag("Throwable") && (playZone.rightLocation)))
        {
            Rigidbody rigidBody = col.GetComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            rigidBody.velocity = device.velocity * throwForce;
            rigidBody.angularVelocity = device.angularVelocity;
        }
    }
    void DestroyObject(Collider col) 
    {
        int index = 0;
        if (col.name.Equals("MetalPlankObject"))
        {
            index = 0;
        } else if (col.name.Equals("FanObject"))
        {
            index = 1;
        } else if (col.name.Equals("TubeCurveObject"))
        {
            index = 2;
        } else if (col.name.Equals("TrampolineObject"))
        {
            index = 3;
        }
        if (objectMenuManager.noOfObj[index] > 0 )
        {
        objectMenuManager.noOfObj[index] -= 1;
        col.gameObject.SetActive(false);
        }
    }
}