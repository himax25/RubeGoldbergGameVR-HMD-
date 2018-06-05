using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLocomotionController : MonoBehaviour {
    public SteamVR_TrackedObject trackedObject;
    public SteamVR_Controller.Device device;

    //Teleporter
    private LineRenderer laser;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask laserMask;
    public static float yNudgeAmount = 0.5f;      // specific to teleportAimerObject height
    private static readonly Vector3 yNudgeVector = new Vector3(0f, yNudgeAmount, 0f);

    //Walking
    public Transform playerCam;
    public float moveSpeed = 4f;
    private Vector3 movementDirection;
    
    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();
    }

    void setLaserStart (Vector3 startPos)
    {
        laser.SetPosition(0, startPos);
    }

    void setLaserEnd (Vector3 endPos)
    {
        laser.SetPosition(1, endPos);
    }

    // Update is called once per frame
    void Update () {
        device =SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            movementDirection = playerCam.transform.forward;
            movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
            movementDirection = movementDirection * moveSpeed * Time.deltaTime;
            player.transform.position += movementDirection;
        }
        
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            laser.gameObject.SetActive(true);
            teleportAimerObject.SetActive(true);

            setLaserStart(gameObject.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
            {
                teleportLocation = hit.point;
            }
            else
            {
                teleportLocation = transform.position + 15 * transform.forward;
                RaycastHit groundRay;
                if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                {
                    teleportLocation.y = groundRay.point.y;
                }
            }
            setLaserEnd(teleportLocation);
            // aimer
            teleportAimerObject.transform.position = teleportLocation + yNudgeVector;
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            //&& (laser.gameObject.CompareTag("Floor")))
            laser.gameObject.SetActive(false);
            teleportAimerObject.SetActive(false);
            if ((teleportLocation.y < 1.0f) && (teleportLocation.y > -1.0f)) 
            {
                player.transform.position = teleportLocation;
            }
        }
    }
}