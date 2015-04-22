using UnityEngine;
using System.Collections;

public class PlayerLook : MonoBehaviour {

    public float mouseSensitivity = 7.0f; // look speed relative to mouse movement

    // Components
    private Camera playerCamera; // the camera on the player
    private CharacterController cc; // the character controller

    // Constants
    private const float lerpSpeed = 7f;

    // Pitch
    //private float pitch = 0f; // current pitch (up/down)
    //private float pitchRange = 70.0f; // max angle of the pitch in either direction

    // Yaw
    //private float yaw = 0f; // current yaw (left/right)
    private float destYaw = 0f; // destination yaw (for smooth turning)
    private float[] direction = new float[] { 0f, 90f, 180f, 270f };
    private int facing = 0;
    private bool isTurning = false;

    void Start() {
        playerCamera = GetComponentInChildren<Camera>(); // get the camera on the player
        cc = GetComponent<CharacterController>(); // get the character controller on the player
    }

    void Update() {
        // rotation
        // yaw = Input.GetAxis("Mouse X") * mouseSensitivity; // if using mouse
        if (Input.GetKeyDown(KeyCode.Q)) {
            Turn(-1);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            Turn(1);
        }

        // pitch (if using mouse)
        //pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        //pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);
        //playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    private void Turn(int turn) {
        isTurning = true;
        facing += turn;
        if (facing == -1)
            facing = 3;
        else if (facing == 4)
            facing = 0;
        destYaw = direction[facing];
    }

    public void SyncRotation(Quaternion rotation) {
        float rot = rotation.eulerAngles.y;
        //print(rot);
        switch ((int)rot) {
            case 0:
                facing = 0;
                break;
            case 90:
                facing = 1;
                break;
            case 180:
                facing = 2;
                break;
            case 270:
                facing = 3;
                break;
            default:
                break;
        }
        destYaw = direction[facing];
    }

    void LateUpdate() {
        if (isTurning) {
            if (Mathf.Abs(destYaw - transform.rotation.eulerAngles.y) < 0.1f) {
                cc.transform.rotation = Quaternion.Euler(0f, destYaw, 0f);
                isTurning = false;
            } else
                cc.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, destYaw, 0f), lerpSpeed * Time.deltaTime);
        }
    }

    public float Yaw {
        get { return destYaw; }
    }

    public bool IsTurning {
        get { return isTurning; }
    }

    public Camera PlayerCamera {
        get { return playerCamera; }
    }

}
